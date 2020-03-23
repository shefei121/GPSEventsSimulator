using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SimGpsDataUpload
{
	public partial class Form1 : Form
	{

		private Logger _logger;
		public Form1()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
			_logger = new Logger(txtLog);
		}

		private List<T> GetArray<T>(string ids, Func<string, T> converter)
		{
			List<T> array = null;
			if (ids != null)
			{
				array = ids.Split(',').Select(converter).ToList();
			}

			return array;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtGpsXmlFile.Text = openFileDialog1.FileName;
			}
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			if (!File.Exists(txtGpsXmlFile.Text))
			{
				MessageBox.Show($"File {txtGpsXmlFile.Text} doesn't exist!");
				return;
			}

			var gpsSimulator = new GpsDeviceSimulator();
			gpsSimulator.Logger = _logger;
			gpsSimulator.SkipRecord = (int)nudSkip.Value;
			gpsSimulator.Interval = (int)nudInterval.Value * 1000;
			gpsSimulator.TimeStrategy = rbKeepOriginal.Checked ? TimeStrategy.KeepOriginal : TimeStrategy.Speedup;
			gpsSimulator.BatchType = rbCreateTime.Checked ? BatchType.CreateTime : BatchType.StartTime;

			gpsSimulator.OnComplete += GpsSimulator_OnComplete;

			gpsSimulator.LoadData(txtGpsXmlFile.Text);

			gpsSimulator.Run(txtConnectionString.Text);
		}

		private void GpsSimulator_OnComplete(object sender, EventArgs e)
		{
			MessageBox.Show("Complete!");
		}

		private void btnTestConnection_Click(object sender, EventArgs e)
		{
			var connStr = txtConnectionString.Text;
			if (string.IsNullOrEmpty(connStr))
			{
				MessageBox.Show("Connection string is missing");
				return;
			}

			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					conn.Open();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show("Failed: " + err.Message);
				return;
			}

			MessageBox.Show("Success");
		}

		public class Logger
		{
			private TextBox _textbox;
			public Logger(TextBox textbox)
			{
				_textbox = textbox;
			}

			public void WriteLine(string text)
			{
				_textbox.AppendText(text + "\r\n");
			}
		}

		private void lnkGpsXmlHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			new GpsXmlHelp().ShowDialog();
		}

		private string _settingsFileName = "settings.txt";
		private void SaveSettings()
		{
			IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.Machine | IsolatedStorageScope.Assembly, null, null);
			if (isoStore.FileExists(_settingsFileName))
			{
				isoStore.DeleteFile(_settingsFileName);
			}

			using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_settingsFileName, FileMode.CreateNew, isoStore))
			{
				using (StreamWriter writer = new StreamWriter(isoStream))
				{
					writer.WriteLine($"xmlpath={txtGpsXmlFile.Text}");
					writer.WriteLine($"connectionstring={txtConnectionString.Text}");
				}
			}
		}

		private void LoadSettings()
		{
			IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.Machine | IsolatedStorageScope.Assembly, null, null);
			if (!isoStore.FileExists(_settingsFileName))
			{
				return;
			}

			using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(_settingsFileName, FileMode.Open, isoStore))
			{
				using (StreamReader reader = new StreamReader(isoStream))
				{
					var xmlpath = reader.ReadLine().Replace("xmlpath=", "");
					txtGpsXmlFile.Text = xmlpath;

					var connString = reader.ReadLine().Replace("connectionstring=", "");
					txtConnectionString.Text = connString;
				}
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			SaveSettings();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadSettings();
		}
	}
}