namespace SimGpsDataUpload
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.txtGpsXmlFile = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRun = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtConnectionString = new System.Windows.Forms.TextBox();
			this.btnTestConnection = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbSpeedup = new System.Windows.Forms.RadioButton();
			this.rbKeepOriginal = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nudSkip = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nudInterval = new System.Windows.Forms.NumericUpDown();
			this.lnkGpsXmlHelp = new System.Windows.Forms.LinkLabel();
			this.label7 = new System.Windows.Forms.Label();
			this.rbStartTime = new System.Windows.Forms.RadioButton();
			this.rbCreateTime = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSkip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// txtGpsXmlFile
			// 
			this.txtGpsXmlFile.Location = new System.Drawing.Point(125, 211);
			this.txtGpsXmlFile.Name = "txtGpsXmlFile";
			this.txtGpsXmlFile.Size = new System.Drawing.Size(376, 20);
			this.txtGpsXmlFile.TabIndex = 0;
			this.txtGpsXmlFile.Text = "C:\\Users\\Administrator\\Desktop\\Vehicle17.xml";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(507, 209);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Browse...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 214);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Gps Xml File:";
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(125, 357);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(78, 39);
			this.btnRun.TabIndex = 3;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 269);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Connection String:";
			// 
			// txtConnectionString
			// 
			this.txtConnectionString.Location = new System.Drawing.Point(125, 266);
			this.txtConnectionString.Multiline = true;
			this.txtConnectionString.Name = "txtConnectionString";
			this.txtConnectionString.Size = new System.Drawing.Size(376, 85);
			this.txtConnectionString.TabIndex = 5;
			this.txtConnectionString.Text = "Server=localhost;Database=Synovia_TFGPS;User Id=tfuser;Password=$transfinder2006;" +
    "";
			// 
			// btnTestConnection
			// 
			this.btnTestConnection.Location = new System.Drawing.Point(507, 266);
			this.btnTestConnection.Name = "btnTestConnection";
			this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
			this.btnTestConnection.TabIndex = 6;
			this.btnTestConnection.Text = "Test";
			this.btnTestConnection.UseVisualStyleBackColor = true;
			this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
			// 
			// txtLog
			// 
			this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLog.Location = new System.Drawing.Point(13, 441);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(568, 232);
			this.txtLog.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 410);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Log:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.nudSkip);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.nudInterval);
			this.groupBox1.Location = new System.Drawing.Point(12, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 195);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// rbSpeedup
			// 
			this.rbSpeedup.AutoSize = true;
			this.rbSpeedup.Location = new System.Drawing.Point(126, 42);
			this.rbSpeedup.Name = "rbSpeedup";
			this.rbSpeedup.Size = new System.Drawing.Size(302, 17);
			this.rbSpeedup.TabIndex = 6;
			this.rbSpeedup.Text = "Speed up gps point time, every 50 millisecond for one point";
			this.rbSpeedup.UseVisualStyleBackColor = true;
			// 
			// rbKeepOriginal
			// 
			this.rbKeepOriginal.AutoSize = true;
			this.rbKeepOriginal.Checked = true;
			this.rbKeepOriginal.Location = new System.Drawing.Point(126, 19);
			this.rbKeepOriginal.Name = "rbKeepOriginal";
			this.rbKeepOriginal.Size = new System.Drawing.Size(259, 17);
			this.rbKeepOriginal.TabIndex = 5;
			this.rbKeepOriginal.TabStop = true;
			this.rbKeepOriginal.Text = "Keep time span unchanged between each record";
			this.rbKeepOriginal.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(115, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Gps data time strategy:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(202, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Skip records count:";
			// 
			// nudSkip
			// 
			this.nudSkip.Location = new System.Drawing.Point(348, 26);
			this.nudSkip.Name = "nudSkip";
			this.nudSkip.Size = new System.Drawing.Size(61, 20);
			this.nudSkip.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Interval(seconds):";
			// 
			// nudInterval
			// 
			this.nudInterval.Location = new System.Drawing.Point(135, 26);
			this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudInterval.Name = "nudInterval";
			this.nudInterval.Size = new System.Drawing.Size(61, 20);
			this.nudInterval.TabIndex = 0;
			this.nudInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// lnkGpsXmlHelp
			// 
			this.lnkGpsXmlHelp.AutoSize = true;
			this.lnkGpsXmlHelp.Location = new System.Drawing.Point(124, 234);
			this.lnkGpsXmlHelp.Name = "lnkGpsXmlHelp";
			this.lnkGpsXmlHelp.Size = new System.Drawing.Size(130, 13);
			this.lnkGpsXmlHelp.TabIndex = 10;
			this.lnkGpsXmlHelp.TabStop = true;
			this.lnkGpsXmlHelp.Text = "How to get gps data xml...";
			this.lnkGpsXmlHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGpsXmlHelp_LinkClicked);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(86, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Data batch type:";
			// 
			// rbStartTime
			// 
			this.rbStartTime.AutoSize = true;
			this.rbStartTime.Checked = true;
			this.rbStartTime.Location = new System.Drawing.Point(127, 35);
			this.rbStartTime.Name = "rbStartTime";
			this.rbStartTime.Size = new System.Drawing.Size(118, 17);
			this.rbStartTime.TabIndex = 9;
			this.rbStartTime.TabStop = true;
			this.rbStartTime.Text = "Based on StartTime";
			this.rbStartTime.UseVisualStyleBackColor = true;
			// 
			// rbCreateTime
			// 
			this.rbCreateTime.AutoSize = true;
			this.rbCreateTime.Location = new System.Drawing.Point(127, 12);
			this.rbCreateTime.Name = "rbCreateTime";
			this.rbCreateTime.Size = new System.Drawing.Size(127, 17);
			this.rbCreateTime.TabIndex = 8;
			this.rbCreateTime.Text = "Based on CreateTime";
			this.rbCreateTime.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbKeepOriginal);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.rbSpeedup);
			this.groupBox2.Location = new System.Drawing.Point(9, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(553, 67);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.rbCreateTime);
			this.groupBox3.Controls.Add(this.rbStartTime);
			this.groupBox3.Location = new System.Drawing.Point(9, 126);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(553, 63);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "groupBox3";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 685);
			this.Controls.Add(this.lnkGpsXmlHelp);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.btnTestConnection);
			this.Controls.Add(this.txtConnectionString);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtGpsXmlFile);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSkip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox txtGpsXmlFile;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtConnectionString;
		private System.Windows.Forms.Button btnTestConnection;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudInterval;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nudSkip;
		private System.Windows.Forms.RadioButton rbSpeedup;
		private System.Windows.Forms.RadioButton rbKeepOriginal;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel lnkGpsXmlHelp;
		private System.Windows.Forms.RadioButton rbStartTime;
		private System.Windows.Forms.RadioButton rbCreateTime;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}

