using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimGpsDataUpload
{
	public partial class Settings : Form
	{
		private SimulatorSettings _settings;

		public Settings(SimulatorSettings settings)
		{
			InitializeComponent();

			_settings = settings;

			nudInterval.Value = settings.Interval / 1000;
			nudSkip.Value = settings.SkipRecord;
			if (settings.TimeStrategy == TimeStrategy.KeepOriginal)
			{
				rbKeepOriginal.Checked = true;
			}
			else
			{
				rbSpeedup.Checked = true;
			}

			if (settings.BatchType == BatchType.CreateTime)
			{
				rbBatchCreateTime.Checked = true;
			}
			else
			{
				rbBatchStartTime.Checked = true;
			}

			if (settings.GpsDataSortBy == GpsDataSortBy.RowID)
			{
				rbSortByRowID.Checked = true;
			}
			else
			{
				rbSortByStartTime.Checked = true;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			_settings.Interval = (int)nudInterval.Value * 1000;
			_settings.SkipRecord = (int)nudSkip.Value;
			_settings.TimeStrategy = rbKeepOriginal.Checked ? TimeStrategy.KeepOriginal : TimeStrategy.Speedup;
			_settings.BatchType = rbBatchCreateTime.Checked ? BatchType.CreateTime : BatchType.StartTime;
			_settings.GpsDataSortBy = rbSortByRowID.Checked ? GpsDataSortBy.RowID : GpsDataSortBy.StartTime;

			Close();
		}
	}
}
