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
			this.lnkGpsXmlHelp = new System.Windows.Forms.LinkLabel();
			this.btnSettings = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// txtGpsXmlFile
			// 
			this.txtGpsXmlFile.Location = new System.Drawing.Point(122, 6);
			this.txtGpsXmlFile.Name = "txtGpsXmlFile";
			this.txtGpsXmlFile.Size = new System.Drawing.Size(376, 20);
			this.txtGpsXmlFile.TabIndex = 0;
			this.txtGpsXmlFile.Text = "C:\\Users\\Administrator\\Desktop\\Vehicle17.xml";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(504, 4);
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
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Gps Xml File:";
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(122, 152);
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
			this.label2.Location = new System.Drawing.Point(12, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Connection String:";
			// 
			// txtConnectionString
			// 
			this.txtConnectionString.Location = new System.Drawing.Point(122, 61);
			this.txtConnectionString.Multiline = true;
			this.txtConnectionString.Name = "txtConnectionString";
			this.txtConnectionString.Size = new System.Drawing.Size(376, 85);
			this.txtConnectionString.TabIndex = 5;
			this.txtConnectionString.Text = "Server=localhost;Database=Synovia_TFGPS;User Id=tfuser;Password=$transfinder2006;" +
    "";
			// 
			// btnTestConnection
			// 
			this.btnTestConnection.Location = new System.Drawing.Point(504, 61);
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
			this.txtLog.Location = new System.Drawing.Point(10, 236);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(568, 401);
			this.txtLog.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 205);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Log:";
			// 
			// lnkGpsXmlHelp
			// 
			this.lnkGpsXmlHelp.AutoSize = true;
			this.lnkGpsXmlHelp.Location = new System.Drawing.Point(121, 29);
			this.lnkGpsXmlHelp.Name = "lnkGpsXmlHelp";
			this.lnkGpsXmlHelp.Size = new System.Drawing.Size(130, 13);
			this.lnkGpsXmlHelp.TabIndex = 10;
			this.lnkGpsXmlHelp.TabStop = true;
			this.lnkGpsXmlHelp.Text = "How to get gps data xml...";
			this.lnkGpsXmlHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGpsXmlHelp_LinkClicked);
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(420, 152);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(78, 39);
			this.btnSettings.TabIndex = 11;
			this.btnSettings.Text = "Settings...";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 649);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.lnkGpsXmlHelp);
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
		private System.Windows.Forms.LinkLabel lnkGpsXmlHelp;
		private System.Windows.Forms.Button btnSettings;
	}
}

