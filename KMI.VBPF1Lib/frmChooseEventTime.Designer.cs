namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmChooseEventTime.
	/// </summary>
	// Token: 0x02000059 RID: 89
	public partial class frmChooseEventTime : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000262 RID: 610 RVA: 0x00027708 File Offset: 0x00026708
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
		// Token: 0x06000263 RID: 611 RVA: 0x00027744 File Offset: 0x00026744
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cboEnd = new global::System.Windows.Forms.ListBox();
			this.cboStart = new global::System.Windows.Forms.ListBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.Cal = new global::System.Windows.Forms.MonthCalendar();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.cboEnd);
			this.groupBox1.Controls.Add(this.cboStart);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new global::System.Drawing.Point(244, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(208, 192);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Time";
			this.cboEnd.Location = new global::System.Drawing.Point(120, 32);
			this.cboEnd.Name = "cboEnd";
			this.cboEnd.Size = new global::System.Drawing.Size(72, 147);
			this.cboEnd.TabIndex = 4;
			this.cboStart.Location = new global::System.Drawing.Point(16, 32);
			this.cboStart.Name = "cboStart";
			this.cboStart.Size = new global::System.Drawing.Size(72, 147);
			this.cboStart.TabIndex = 3;
			this.label1.Location = new global::System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Time:";
			this.label2.Location = new global::System.Drawing.Point(120, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "End Time:";
			this.groupBox2.Controls.Add(this.Cal);
			this.groupBox2.Location = new global::System.Drawing.Point(16, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(212, 192);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Date";
			this.Cal.Location = new global::System.Drawing.Point(16, 20);
			this.Cal.MaxSelectionCount = 1;
			this.Cal.Name = "Cal";
			this.Cal.ShowToday = false;
			this.Cal.ShowTodayCircle = false;
			this.Cal.TabIndex = 0;
			this.btnHelp.Location = new global::System.Drawing.Point(316, 236);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 12;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(196, 236);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(76, 236);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(472, 278);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmChooseEventTime";
			base.ShowInTaskbar = false;
			this.Text = "Plan Your Party";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.ListBox cboEnd;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.ListBox cboStart;

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.MonthCalendar Cal;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040002D5 RID: 725
		private global::System.ComponentModel.Container components = null;
	}
}
