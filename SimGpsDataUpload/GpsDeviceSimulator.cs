using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Timers;
using System.Xml;
using static SimGpsDataUpload.Form1;

namespace SimGpsDataUpload
{
	public class GpsDeviceSimulator
	{
		private TimeSpan _timeSpan;
		private Queue<IEnumerable<dynamic>> _pendingGpsDataQueue = new Queue<IEnumerable<dynamic>>();
		private string _connectionString;
		private Timer _saveGpsDataTimer;
		private List<int> _vendorEventTypeIds = new List<int>();

		public event EventHandler<EventArgs> OnComplete;

		public SimulatorSettings Settings { get; set; }

		public Logger Logger { get; set; }

		public void LoadData(string xmlFileName)
		{
			var gpsXmlDoc = ReadGpsXml(xmlFileName);
			dynamic rows = DynamicXml.Parse(gpsXmlDoc);

			IEnumerable<dynamic> vechileEvents = rows.row;
			var orderedByStartTime = vechileEvents.OrderBy(vehicleEvent => DateTime.Parse(vehicleEvent.StartTime)).ToList();
			orderedByStartTime.RemoveRange(0, Settings.SkipRecord);
			var firstRow = orderedByStartTime[0];
			_timeSpan = DateTime.Now - DateTime.Parse(firstRow.StartTime).ToLocalTime() + TimeSpan.FromSeconds(5);

			var gpsData = orderedByStartTime;
			if (Settings.GpsDataSortBy == GpsDataSortBy.StartTime)
			{
				gpsData = orderedByStartTime.OrderBy(vehicleEvent => int.Parse(vehicleEvent.RowID)).ToList();
			}

			var gpsDataList = new List<dynamic>();
			DateTime compareTime;
			var startTime = Settings.BatchType == BatchType.CreateTime ? DateTime.Parse(gpsData[0].CreateDateTime) : DateTime.Parse(gpsData[0].StartTime);
			var endTime = startTime + TimeSpan.FromSeconds(30);
			foreach (var data in gpsData)
			{
				compareTime = Settings.BatchType == BatchType.CreateTime ? DateTime.Parse(data.CreateDateTime) : DateTime.Parse(data.StartTime);
				if (compareTime >= startTime && compareTime <= endTime)
				{
					gpsDataList.Add(data);
					continue;
				}

				_pendingGpsDataQueue.Enqueue(gpsDataList);
				gpsDataList = new List<dynamic>();
				gpsDataList.Add(data);
				startTime = Settings.BatchType == BatchType.CreateTime ? DateTime.Parse(data.CreateDateTime) : DateTime.Parse(data.StartTime);
				//startTime = DateTime.Parse(data.CreateDateTime);
				endTime = startTime + TimeSpan.FromSeconds(30);
			}

			_pendingGpsDataQueue.Enqueue(gpsDataList);

			Logger.WriteLine($"Load data completed.  Total: {gpsData.Count}.  Batch Count:{_pendingGpsDataQueue.Count}");
		}

		private void GetVendorEventTypeIds()
		{
			using (var conn = new SqlConnection(_connectionString))
			using (var cmd = new SqlCommand())
			{
				cmd.Connection = conn;
				cmd.CommandText = "select RowID from VendorEventType";
				conn.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				var table = new DataTable();
				adapter.Fill(table);

				_vendorEventTypeIds = table.AsEnumerable().Select(row => (int)row["RowID"]).ToList();
			}
		}

		public void Run(string connectionString)
		{
			_connectionString = connectionString;

			GetVendorEventTypeIds();

			_eventType = "90";//power on
			_lastTime = DateTime.Now;

			_saveGpsDataTimer = new Timer();
			_saveGpsDataTimer.Interval = Settings.Interval;
			_saveGpsDataTimer.Elapsed += SaveDataTimer_Elapsed;
			_saveGpsDataTimer.Start();

			Logger.WriteLine("Start running...");
		}

		private void SaveDataTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			SaveGpsData();
		}

		private string _eventType;

		public void SaveGpsData()
		{
			//DisposeTimer();
			if (_pendingGpsDataQueue.Count == 0)
			{
				DisposeTimer();
				OnComplete(null, null);
				Logger.WriteLine("Running compeleted.");
				return;
			}

			Logger.WriteLine("Batch start...");
			var gpsData = _pendingGpsDataQueue.Dequeue();
			try
			{
				var count = gpsData.Count();
				var index = 0;
				foreach (var data in gpsData)
				{
					if (_pendingGpsDataQueue.Count == 0)
					{
						index++;
						if (index == count)
						{
							_eventType = "91";//power off
						}
					}
					using (var conn = new SqlConnection(_connectionString))
					using (var cmd = new SqlCommand())
					{
						cmd.Connection = conn;
						conn.Open();
						Insert(conn, data, _eventType);
					}
					_eventType = "1";//gps location
				}

				Logger.WriteLine($"Batch completed.  Next batch will be started after {Settings.Interval / 1000} seconds.");
				//using (var conn = new SqlConnection(_connectionString))
				//using (var cmd = new SqlCommand())
				//{
				//	cmd.Connection = conn;
				//	conn.Open();
				//	var count = gpsData.Count();
				//	var index = 0;
				//	foreach (var data in gpsData)
				//	{
				//		if (_pendingGpsDataQueue.Count == 0)
				//		{
				//			index++;
				//			if (index == count)
				//			{
				//				_eventType = "91";//power off
				//			}
				//		}
				//		Insert(conn, data, _eventType);
				//		_eventType = "1";//gps location
				//	}

				//	Logger.WriteLine($"Batch completed.  Next batch will be started after {Interval / 1000} seconds.");
				//}
			}
			catch (Exception err)
			{
				DisposeTimer();
				Logger.WriteLine(err.Message);
				Logger.WriteLine(err.StackTrace);
				throw err;
			}
		}

		private DateTime _lastTime;
		private object UpdateTimeSpeedup(dynamic time)
		{
			var newTime = ConvertDynamicValueToSqlValue(time);
			if (!(newTime is DBNull))
			{
				newTime = _lastTime + TimeSpan.FromMilliseconds(5000);
				newTime = newTime.ToLocalTime();
			}

			return newTime;
		}

		private object UpdateTimeKeepOriginal(dynamic time)
		{
			var newTime = ConvertDynamicValueToSqlValue(time);
			if (!(newTime is DBNull))
			{
				newTime = DateTime.Parse(time).ToLocalTime() + _timeSpan;
				newTime = newTime.ToLocalTime();
			}

			return newTime;
		}

		private Random _random = new Random((int)DateTime.Now.Ticks);
		private object UpdateTimeRandom(dynamic time)
		{
			var newTime = ConvertDynamicValueToSqlValue(time);
			if (!(newTime is DBNull))
			{
				newTime = _lastTime + TimeSpan.FromMilliseconds(_random.Next(500, 2000));
				newTime = newTime.ToLocalTime();
			}

			return newTime;
		}

		private object UpdateTime(dynamic time)
		{
			//return UpdateTimeRandom(time);
			if (Settings.TimeStrategy == TimeStrategy.KeepOriginal)
			{
				return UpdateTimeKeepOriginal(time);
			}
			else if (Settings.TimeStrategy == TimeStrategy.Speedup)
			{
				return UpdateTimeSpeedup(time);
			}

			return time;
		}

		private string _lastLongitude;
		private string _lastLatitude;
		private void Insert(SqlConnection conn, dynamic data, string eventType)
		{
			//if (data.VehicleID.ToString() != "56")
			//{
			//	return;
			//}

			StringBuilder sqlStr = new StringBuilder("insert into VehicleEvent(VehicleID,Latitude,Longitude,StartTime,EndTime,Duration,Distance,Location,CreateDateTime,Boarded,Load,Speed,");
			sqlStr.Append("Heading,VendorRecordID,VendorEventTypeID,AdjLongitude,AdjLatitude,AdjLocation,StreetSpeed,OnPathStatusID,AtStopStatusID,AtSpeedStatusID,DistanceToStop,TimeToStop,");
			sqlStr.Append("TripID,StopID,SegmentID,SchoolIDs,ProcessedDate,ProcessedFlags,TagID,OnTimeForStopStatusId)");
			sqlStr.Append(" values(@VehicleID,@Latitude,@Longitude,");
			sqlStr.Append("@StartTime,@EndTime,@Duration,@Distance,");
			sqlStr.Append("@Location,@CreateDateTime,@Boarded,@Load,");
			sqlStr.Append("@Speed,@Heading,@VendorRecordID,@VendorEventTypeID,");
			sqlStr.Append("@AdjLongitude,@AdjLatitude,@AdjLocation,@StreetSpeed,");
			sqlStr.Append("@OnPathStatusID,@AtStopStatusID,@AtSpeedStatusID,@DistanceToStop,");
			sqlStr.Append("@TimeToStop,@TripID,@StopID,@SegmentID,");
			sqlStr.Append("@SchoolIDs,@ProcessedDate,@ProcessedFlags,@TagID,");
			sqlStr.Append("@OnTimeForStopStatusId");
			sqlStr.Append(")");
			sqlStr.Append("select @vehicleeventidentity=SCOPE_IDENTITY()");
			SqlCommand cmd = new SqlCommand(sqlStr.ToString(), conn);

			//cmd.Parameters.Add(new SqlParameter("@VehicleID", "99"));
			cmd.Parameters.Add(new SqlParameter("@VehicleID", ConvertDynamicValueToSqlValue(data.VehicleID)));
			cmd.Parameters.Add(new SqlParameter("@Latitude", ConvertDynamicValueToSqlValue(data.Latitude)));
			cmd.Parameters.Add(new SqlParameter("@Longitude", ConvertDynamicValueToSqlValue(data.Longitude)));
			var startTime = UpdateTime(data.StartTime);
			cmd.Parameters.Add(new SqlParameter("@StartTime", startTime));
			cmd.Parameters.Add(new SqlParameter("@EndTime", UpdateTime(data.EndTime)));
			_lastTime = startTime;
			cmd.Parameters.Add(new SqlParameter("@Duration", ConvertDynamicValueToSqlValue(data.Duration)));
			cmd.Parameters.Add(new SqlParameter("@Distance", ConvertDynamicValueToSqlValue(data.Distance)));
			//cmd.Parameters.Add(new SqlParameter("@Location", ConvertDynamicValueToSqlValue(data.Location)));// hard code location to seperate simulate data and actual data.
			cmd.Parameters.Add(new SqlParameter("@Location", "simulate"));
			//cmd.Parameters.Add(new SqlParameter("@CreateDateTime", ConvertDynamicValueToSqlValue(data.CreateDateTime)));
			cmd.Parameters.Add(new SqlParameter("@CreateDateTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
			cmd.Parameters.Add(new SqlParameter("@Boarded", ConvertDynamicValueToSqlValue(data.Boarded)));
			cmd.Parameters.Add(new SqlParameter("@Load", ConvertDynamicValueToSqlValue(data.Load)));
			cmd.Parameters.Add(new SqlParameter("@Speed", ConvertDynamicValueToSqlValue(data.Speed)));
			cmd.Parameters.Add(new SqlParameter("@Heading", ConvertDynamicValueToSqlValue(data.Heading)));
			cmd.Parameters.Add(new SqlParameter("@VendorRecordID", ConvertDynamicValueToSqlValue(data.VendorRecordID)));
			var vendorEventTypeId = ConvertDynamicValueToSqlValue(data.VendorEventTypeID);
			int parsedId;
			if (int.TryParse(vendorEventTypeId, out parsedId))
			{
				if (!_vendorEventTypeIds.Contains(parsedId))
				{
					vendorEventTypeId = 0;
				}
			}
			cmd.Parameters.Add(new SqlParameter("@VendorEventTypeID", vendorEventTypeId));
			var longtitude = ConvertDynamicValueToSqlValue(data.AdjLongitude).ToString();
			var latitude = ConvertDynamicValueToSqlValue(data.AdjLatitude).ToString();
			//if (string.IsNullOrEmpty(_lastLongitude))
			//{
			//	_lastLongitude = longtitude;
			//	_lastLatitude = latitude;
			//}
			//else
			//{
			//	if (_lastLongitude == longtitude && _lastLatitude == latitude)
			//	{
			//		longtitude = (double.Parse(longtitude) + 0.005).ToString("f8");
			//		latitude = (double.Parse(latitude) + 0.005).ToString("f8");
			//	}
			//	_lastLongitude = longtitude;
			//	_lastLatitude = latitude;
			//}

			cmd.Parameters.Add(new SqlParameter("@AdjLongitude", longtitude));
			cmd.Parameters.Add(new SqlParameter("@AdjLatitude", latitude));

			cmd.Parameters.Add(new SqlParameter("@AdjLocation", ConvertDynamicValueToSqlValue(data.AdjLocation)));
			cmd.Parameters.Add(new SqlParameter("@StreetSpeed", ConvertDynamicValueToSqlValue(data.StreetSpeed)));
			cmd.Parameters.Add(new SqlParameter("@OnPathStatusID", ConvertDynamicValueToSqlValue(data.OnPathStatusID)));
			cmd.Parameters.Add(new SqlParameter("@AtStopStatusID", ConvertDynamicValueToSqlValue(data.AtStopStatusID)));
			cmd.Parameters.Add(new SqlParameter("@AtSpeedStatusID", ConvertDynamicValueToSqlValue(data.AtSpeedStatusID)));
			cmd.Parameters.Add(new SqlParameter("@DistanceToStop", ConvertDynamicValueToSqlValue(data.DistanceToStop)));
			cmd.Parameters.Add(new SqlParameter("@TimeToStop", ConvertDynamicValueToSqlValue(data.TimeToStop)));
			cmd.Parameters.Add(new SqlParameter("@TripID", ConvertDynamicValueToSqlValue(data.TripID)));
			cmd.Parameters.Add(new SqlParameter("@StopID", ConvertDynamicValueToSqlValue(data.StopID)));
			cmd.Parameters.Add(new SqlParameter("@SegmentID", ConvertDynamicValueToSqlValue(data.SegmentID)));
			cmd.Parameters.Add(new SqlParameter("@SchoolIDs", ConvertDynamicValueToSqlValue(data.SchoolIDs)));
			cmd.Parameters.Add(new SqlParameter("@ProcessedDate", ConvertDynamicValueToSqlValue(data.ProcessedDate)));
			cmd.Parameters.Add(new SqlParameter("@ProcessedFlags", ConvertDynamicValueToSqlValue(data.ProcessedFlags)));
			cmd.Parameters.Add(new SqlParameter("@TagID", ConvertDynamicValueToSqlValue(data.TagID)));
			cmd.Parameters.Add(new SqlParameter("@OnTimeForStopStatusId", ConvertDynamicValueToSqlValue(data.OnTimeForStopStatusId)));

			var idParameter = new SqlParameter("@vehicleeventidentity", SqlDbType.Int);
			idParameter.Direction = ParameterDirection.Output;
			cmd.Parameters.Add(idParameter);

			var startInsertTime = DateTime.Now;

			cmd.ExecuteNonQuery();

			int vehicleEventIdentity = Convert.ToInt32(idParameter.Value);
			var vehicleEventTypeInsert = $"insert into VehicleEventType values({vehicleEventIdentity},{eventType},'{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')";
			cmd = new SqlCommand(vehicleEventTypeInsert, conn);
			cmd.ExecuteNonQuery();
			var endInsertTime = DateTime.Now;

			Logger.WriteLine($"Insert start from: {startInsertTime} to {endInsertTime}");
		}

		private void DisposeTimer()
		{
			if (_saveGpsDataTimer == null) return;

			_saveGpsDataTimer.Stop();
			_saveGpsDataTimer.Elapsed -= SaveDataTimer_Elapsed;
			_saveGpsDataTimer = null;
		}

		private string ReadGpsXml(string filename)
		{
			XmlReaderSettings settings = new XmlReaderSettings
			{
				ConformanceLevel = ConformanceLevel.Fragment
			};
			XmlReader reader = XmlReader.Create(filename, settings);
			StringBuilder sb = new StringBuilder();
			sb.Append("<root>");

			while (reader.Read())
			{
				sb.AppendLine(reader.ReadOuterXml());
			}

			sb.Append("</root>");
			return sb.ToString();
		}

		private object ConvertDynamicValueToSqlValue(dynamic value, bool stringValue = false)
		{
			if (string.IsNullOrEmpty(value))
			{
				return DBNull.Value;
			}

			if (stringValue)
			{
				return $"'{value}'";
			}

			return value;
		}

		//private string GenerateInsertGpsDataSql(dynamic data)
		//{
		//	var insertSql = $"insert into VehicleEvent values(" +
		//		$"{ConvertDynamicValueToSqlValue(data.VehicleID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Latitude)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Longitude)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.StartTime, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.EndTime, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Duration, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Distance)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Location, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.CreateDateTime, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Boarded)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Load)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Speed)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.Heading)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.VendorRecordID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.VendorEventTypeID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.AdjLongitude)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.AdjLatitude)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.AdjLocation, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.StreetSpeed)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.OnPathStatusID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.AtStopStatusID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.AtSpeedStatusID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.DistanceToStop)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.TimeToStop)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.TripID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.StopID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.SegmentID)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.SchoolIDs, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.ProcessedDate, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.ProcessedFlags)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.TagID, true)}," +
		//		$"{ConvertDynamicValueToSqlValue(data.OnTimeForStopStatusId)}" +
		//		$")";

		//	return insertSql;
		//}
	}
}
