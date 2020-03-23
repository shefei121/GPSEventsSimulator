using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimGpsDataUpload
{
	public class GpsData
	{
		//public void LoadData(string xmlFileName)
		//{
		//	var gpsXmlDoc = ReadGpsXml(xmlFileName);
		//	dynamic rows = DynamicXml.Parse(gpsXmlDoc);

		//	IEnumerable<dynamic> vechileEvents = rows.row;
		//	var orderedByStartTime = vechileEvents.OrderBy(vehicleEvent => DateTime.Parse(vehicleEvent.StartTime)).ToList();
		//	orderedByStartTime.RemoveRange(0, SkipRecord);
		//	var firstRow = orderedByStartTime[0];
		//	var firstStartTime = firstRow.StartTime;
		//	_timeSpan = DateTime.Now - DateTime.Parse(firstRow.StartTime).ToLocalTime() + TimeSpan.FromSeconds(5);

		//	var gpsData = orderedByStartTime.OrderBy(vehicleEvent => int.Parse(vehicleEvent.RowID)).ToList();
		//	var gpsDataList = new List<dynamic>();
		//	DateTime createDateTime;
		//	var startTime = DateTime.Parse(gpsData[0].CreateDateTime);
		//	var endTime = startTime + TimeSpan.FromSeconds(30);
		//	foreach (var data in gpsData)
		//	{
		//		createDateTime = DateTime.Parse(data.CreateDateTime);
		//		if (createDateTime >= startTime && createDateTime <= endTime)
		//		{
		//			gpsDataList.Add(data);
		//			continue;
		//		}

		//		_pendingGpsDataQueue.Enqueue(gpsDataList);
		//		gpsDataList = new List<dynamic>();
		//		gpsDataList.Add(data);
		//		startTime = DateTime.Parse(data.CreateDateTime);
		//		endTime = startTime + TimeSpan.FromSeconds(30);
		//	}

		//	Logger.WriteLine($"Load data completed.  Total: {gpsData.Count}.  Batch Count:{_pendingGpsDataQueue.Count}");
		//}
	}
}
