using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimGpsDataUpload
{
	[Serializable]
	public class SimulatorSettings
	{
		public int SkipRecord { get; set; } = 0;

		public int Interval { get; set; } = 2000;

		public TimeStrategy TimeStrategy { get; set; }

		public BatchType BatchType { get; set; }

		public GpsDataSortBy GpsDataSortBy { get; set; }
	}

	public enum TimeStrategy
	{
		KeepOriginal,
		Speedup
	}

	public enum BatchType
	{
		CreateTime,
		StartTime
	}

	public enum GpsDataSortBy
	{
		RowID,
		StartTime
	}
}
