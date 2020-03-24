namespace SimGpsDataUpload
{
	partial class Settings
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.rbBatchCreateTime = new System.Windows.Forms.RadioButton();
			this.rbBatchStartTime = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbKeepOriginal = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.rbSpeedup = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rbSortByRowID = new System.Windows.Forms.RadioButton();
			this.rbSortByStartTime = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.nudSkip = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nudInterval = new System.Windows.Forms.NumericUpDown();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSkip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.rbBatchCreateTime);
			this.groupBox3.Controls.Add(this.rbBatchStartTime);
			this.groupBox3.Location = new System.Drawing.Point(12, 117);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(553, 63);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "groupBox3";
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
			// rbBatchCreateTime
			// 
			this.rbBatchCreateTime.AutoSize = true;
			this.rbBatchCreateTime.Location = new System.Drawing.Point(127, 12);
			this.rbBatchCreateTime.Name = "rbBatchCreateTime";
			this.rbBatchCreateTime.Size = new System.Drawing.Size(127, 17);
			this.rbBatchCreateTime.TabIndex = 8;
			this.rbBatchCreateTime.Text = "Based on CreateTime";
			this.rbBatchCreateTime.UseVisualStyleBackColor = true;
			// 
			// rbBatchStartTime
			// 
			this.rbBatchStartTime.AutoSize = true;
			this.rbBatchStartTime.Checked = true;
			this.rbBatchStartTime.Location = new System.Drawing.Point(127, 35);
			this.rbBatchStartTime.Name = "rbBatchStartTime";
			this.rbBatchStartTime.Size = new System.Drawing.Size(118, 17);
			this.rbBatchStartTime.TabIndex = 9;
			this.rbBatchStartTime.TabStop = true;
			this.rbBatchStartTime.Text = "Based on StartTime";
			this.rbBatchStartTime.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbKeepOriginal);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.rbSpeedup);
			this.groupBox2.Location = new System.Drawing.Point(12, 43);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(553, 67);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.rbSortByRowID);
			this.groupBox1.Controls.Add(this.rbSortByStartTime);
			this.groupBox1.Location = new System.Drawing.Point(12, 186);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(553, 63);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Sort by:";
			// 
			// rbSortByRowID
			// 
			this.rbSortByRowID.AutoSize = true;
			this.rbSortByRowID.Location = new System.Drawing.Point(127, 12);
			this.rbSortByRowID.Name = "rbSortByRowID";
			this.rbSortByRowID.Size = new System.Drawing.Size(58, 17);
			this.rbSortByRowID.TabIndex = 8;
			this.rbSortByRowID.Text = "RowID";
			this.rbSortByRowID.UseVisualStyleBackColor = true;
			// 
			// rbSortByStartTime
			// 
			this.rbSortByStartTime.AutoSize = true;
			this.rbSortByStartTime.Checked = true;
			this.rbSortByStartTime.Location = new System.Drawing.Point(127, 35);
			this.rbSortByStartTime.Name = "rbSortByStartTime";
			this.rbSortByStartTime.Size = new System.Drawing.Size(69, 17);
			this.rbSortByStartTime.TabIndex = 9;
			this.rbSortByStartTime.TabStop = true;
			this.rbSortByStartTime.Text = "Start time";
			this.rbSortByStartTime.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(213, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Skip records count:";
			// 
			// nudSkip
			// 
			this.nudSkip.Location = new System.Drawing.Point(359, 17);
			this.nudSkip.Name = "nudSkip";
			this.nudSkip.Size = new System.Drawing.Size(61, 20);
			this.nudSkip.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Interval(seconds):";
			// 
			// nudInterval
			// 
			this.nudInterval.Location = new System.Drawing.Point(146, 17);
			this.nudInterval.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nudInterval.Name = "nudInterval";
			this.nudInterval.Size = new System.Drawing.Size(61, 20);
			this.nudInterval.TabIndex = 15;
			this.nudInterval.Value = new decimal(new int[] {
			30,
			0,
			0,
			0});
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(489, 255);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 19;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(576, 290);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nudSkip);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nudInterval);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Name = "Settings";
			this.Text = "Settings";
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSkip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton rbBatchCreateTime;
		private System.Windows.Forms.RadioButton rbBatchStartTime;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbKeepOriginal;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rbSpeedup;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbSortByRowID;
		private System.Windows.Forms.RadioButton rbSortByStartTime;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nudSkip;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudInterval;
		private System.Windows.Forms.Button btnOK;
	}
}