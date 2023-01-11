namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmDailyRoutine.
	/// </summary>
	// Token: 0x0200004E RID: 78
	public partial class frmDailyRoutine : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000215 RID: 533 RVA: 0x000215C8 File Offset: 0x000205C8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x06000216 RID: 534 RVA: 0x00021604 File Offset: 0x00020604
		private void InitializeComponent()
		{
			this.panMainWD = new global::System.Windows.Forms.Panel();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.AddWorkout = new global::System.Windows.Forms.LinkLabel();
			this.AddRelaxation = new global::System.Windows.Forms.LinkLabel();
			this.AddSleep = new global::System.Windows.Forms.LinkLabel();
			this.AddEat = new global::System.Windows.Forms.LinkLabel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnChangeTravel = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new global::System.Windows.Forms.LinkLabel();
			this.linkLabel3 = new global::System.Windows.Forms.LinkLabel();
			this.linkLabel4 = new global::System.Windows.Forms.LinkLabel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panMainWE = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.btnHostAParty = new global::System.Windows.Forms.Button();
			this.label11 = new global::System.Windows.Forms.Label();
			this.chkEvents = new global::System.Windows.Forms.CheckedListBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.panSpecialEvents = new global::System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.panSpecialEvents.SuspendLayout();
			base.SuspendLayout();
			this.panMainWD.BackColor = global::System.Drawing.Color.White;
			this.panMainWD.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panMainWD.Location = new global::System.Drawing.Point(64, 48);
			this.panMainWD.Name = "panMainWD";
			this.panMainWD.Size = new global::System.Drawing.Size(72, 336);
			this.panMainWD.TabIndex = 0;
			this.btnClose.Location = new global::System.Drawing.Point(464, 16);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.label1.Location = new global::System.Drawing.Point(152, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(48, 32);
			this.label1.TabIndex = 2;
			this.label1.Text = "Add time to:";
			this.AddWorkout.Location = new global::System.Drawing.Point(152, 152);
			this.AddWorkout.Name = "AddWorkout";
			this.AddWorkout.Size = new global::System.Drawing.Size(56, 16);
			this.AddWorkout.TabIndex = 5;
			this.AddWorkout.TabStop = true;
			this.AddWorkout.Tag = "false";
			this.AddWorkout.Text = "Exercise";
			this.AddWorkout.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddWorkout_LinkClicked);
			this.AddRelaxation.Location = new global::System.Drawing.Point(152, 128);
			this.AddRelaxation.Name = "AddRelaxation";
			this.AddRelaxation.Size = new global::System.Drawing.Size(56, 16);
			this.AddRelaxation.TabIndex = 6;
			this.AddRelaxation.TabStop = true;
			this.AddRelaxation.Tag = "false";
			this.AddRelaxation.Text = "Relax";
			this.AddRelaxation.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddRelaxation_LinkClicked);
			this.AddSleep.Location = new global::System.Drawing.Point(152, 176);
			this.AddSleep.Name = "AddSleep";
			this.AddSleep.Size = new global::System.Drawing.Size(56, 16);
			this.AddSleep.TabIndex = 7;
			this.AddSleep.TabStop = true;
			this.AddSleep.Tag = "false";
			this.AddSleep.Text = "Sleep";
			this.AddSleep.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddSleep_LinkClicked);
			this.AddEat.Location = new global::System.Drawing.Point(152, 104);
			this.AddEat.Name = "AddEat";
			this.AddEat.Size = new global::System.Drawing.Size(56, 16);
			this.AddEat.TabIndex = 11;
			this.AddEat.TabStop = true;
			this.AddEat.Tag = "false";
			this.AddEat.Text = "Eat";
			this.AddEat.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddEat_LinkClicked);
			this.label2.BackColor = global::System.Drawing.Color.Violet;
			this.label2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new global::System.Drawing.Point(200, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 24);
			this.label2.TabIndex = 12;
			this.label2.Text = "Est. Travel Time";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Location = new global::System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(152, 32);
			this.label3.TabIndex = 13;
			this.label3.Text = "To edit or delete an existing activity, click it.";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.btnChangeTravel.Location = new global::System.Drawing.Point(312, 16);
			this.btnChangeTravel.Name = "btnChangeTravel";
			this.btnChangeTravel.Size = new global::System.Drawing.Size(128, 24);
			this.btnChangeTravel.TabIndex = 14;
			this.btnChangeTravel.Text = "Change Travel Mode";
			this.btnChangeTravel.Click += new global::System.EventHandler(this.btnChangeTravel_Click);
			this.panel2.Controls.Add(this.btnHelp);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.btnChangeTravel);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Location = new global::System.Drawing.Point(0, 400);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(632, 56);
			this.panel2.TabIndex = 21;
			this.btnHelp.Location = new global::System.Drawing.Point(552, 16);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(64, 24);
			this.btnHelp.TabIndex = 15;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label5.BackColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label5.Location = new global::System.Drawing.Point(208, 0);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(1, 400);
			this.label5.TabIndex = 22;
			this.label4.BackColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label4.Location = new global::System.Drawing.Point(0, 400);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(640, 1);
			this.label4.TabIndex = 23;
			this.label4.Click += new global::System.EventHandler(this.label4_Click);
			this.label6.BackColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label6.Location = new global::System.Drawing.Point(424, 0);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(1, 400);
			this.label6.TabIndex = 30;
			this.linkLabel1.Location = new global::System.Drawing.Point(368, 104);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(56, 16);
			this.linkLabel1.TabIndex = 29;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Tag = "true";
			this.linkLabel1.Text = "Eat";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddEat_LinkClicked);
			this.linkLabel2.Location = new global::System.Drawing.Point(368, 176);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new global::System.Drawing.Size(56, 16);
			this.linkLabel2.TabIndex = 28;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Tag = "true";
			this.linkLabel2.Text = "Sleep";
			this.linkLabel2.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddSleep_LinkClicked);
			this.linkLabel3.Location = new global::System.Drawing.Point(368, 128);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new global::System.Drawing.Size(56, 16);
			this.linkLabel3.TabIndex = 27;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Tag = "true";
			this.linkLabel3.Text = "Relax";
			this.linkLabel3.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddRelaxation_LinkClicked);
			this.linkLabel4.Location = new global::System.Drawing.Point(368, 152);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new global::System.Drawing.Size(56, 16);
			this.linkLabel4.TabIndex = 26;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Tag = "true";
			this.linkLabel4.Text = "Exercise";
			this.linkLabel4.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddWorkout_LinkClicked);
			this.label7.Location = new global::System.Drawing.Point(368, 56);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(48, 32);
			this.label7.TabIndex = 25;
			this.label7.Text = "Add time to:";
			this.panMainWE.BackColor = global::System.Drawing.Color.White;
			this.panMainWE.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panMainWE.Location = new global::System.Drawing.Point(280, 48);
			this.panMainWE.Name = "panMainWE";
			this.panMainWE.Size = new global::System.Drawing.Size(72, 336);
			this.panMainWE.TabIndex = 24;
			this.label8.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label8.Location = new global::System.Drawing.Point(8, 8);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(184, 24);
			this.label8.TabIndex = 31;
			this.label8.Text = "Weekday";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label9.Location = new global::System.Drawing.Point(224, 8);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(184, 24);
			this.label9.TabIndex = 32;
			this.label9.Text = "Weekend";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label10.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label10.Location = new global::System.Drawing.Point(8, 8);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(184, 24);
			this.label10.TabIndex = 33;
			this.label10.Text = "Special Events";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.btnHostAParty.Location = new global::System.Drawing.Point(16, 40);
			this.btnHostAParty.Name = "btnHostAParty";
			this.btnHostAParty.Size = new global::System.Drawing.Size(160, 24);
			this.btnHostAParty.TabIndex = 34;
			this.btnHostAParty.Text = "Host a Party";
			this.btnHostAParty.Click += new global::System.EventHandler(this.btnHostAParty_Click);
			this.label11.Location = new global::System.Drawing.Point(16, 80);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(112, 16);
			this.label11.TabIndex = 35;
			this.label11.Text = "Attend Events:";
			this.chkEvents.CheckOnClick = true;
			this.chkEvents.HorizontalScrollbar = true;
			this.chkEvents.Location = new global::System.Drawing.Point(16, 104);
			this.chkEvents.Name = "chkEvents";
			this.chkEvents.Size = new global::System.Drawing.Size(160, 199);
			this.chkEvents.TabIndex = 36;
			this.chkEvents.SelectedValueChanged += new global::System.EventHandler(this.chkEvents_SelectedValueChanged);
			this.label12.Location = new global::System.Drawing.Point(32, 312);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(128, 16);
			this.label12.TabIndex = 37;
			this.label12.Text = "Check the box to attend.";
			this.label13.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new global::System.Drawing.Point(16, 336);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(168, 56);
			this.label13.TabIndex = 38;
			this.label13.Text = "If the special event begins during a scheduled activity, you will complete that activity first then go to the event. If the event has ended by that time, you will not get credit for attending.";
			this.panSpecialEvents.Controls.Add(this.label10);
			this.panSpecialEvents.Controls.Add(this.btnHostAParty);
			this.panSpecialEvents.Controls.Add(this.label11);
			this.panSpecialEvents.Controls.Add(this.chkEvents);
			this.panSpecialEvents.Controls.Add(this.label12);
			this.panSpecialEvents.Controls.Add(this.label13);
			this.panSpecialEvents.Location = new global::System.Drawing.Point(424, 0);
			this.panSpecialEvents.Name = "panSpecialEvents";
			this.panSpecialEvents.Size = new global::System.Drawing.Size(200, 400);
			this.panSpecialEvents.TabIndex = 39;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(634, 448);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.linkLabel1);
			base.Controls.Add(this.linkLabel2);
			base.Controls.Add(this.linkLabel3);
			base.Controls.Add(this.linkLabel4);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.panMainWE);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.AddEat);
			base.Controls.Add(this.AddSleep);
			base.Controls.Add(this.AddRelaxation);
			base.Controls.Add(this.AddWorkout);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panMainWD);
			base.Controls.Add(this.panSpecialEvents);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmDailyRoutine";
			base.ShowInTaskbar = false;
			this.Text = "Schedule";
			this.panel2.ResumeLayout(false);
			this.panSpecialEvents.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000250 RID: 592
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.LinkLabel AddWorkout;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.LinkLabel AddRelaxation;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.LinkLabel AddSleep;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.LinkLabel AddEat;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.Button btnChangeTravel;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.LinkLabel linkLabel2;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.LinkLabel linkLabel3;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.LinkLabel linkLabel4;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.Panel panMainWD;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.Panel panMainWE;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.Button btnHostAParty;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.Label label11;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.CheckedListBox chkEvents;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.Panel panSpecialEvents;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.Button btnHelp;
	}
}
