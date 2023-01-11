namespace KMI.Biz
{
	// Token: 0x02000010 RID: 16
	public partial class frmConsultant : global::System.Windows.Forms.Form
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00007174 File Offset: 0x00006174
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

		// Token: 0x06000068 RID: 104 RVA: 0x000071B0 File Offset: 0x000061B0
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.chkFullReport = new global::System.Windows.Forms.CheckBox();
			this.panReportArea = new global::System.Windows.Forms.Panel();
			this.picReport = new global::System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panReportArea.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picReport).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.chkFullReport);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 366);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(520, 80);
			this.panel1.TabIndex = 1;
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Controls.Add(this.btnHelp);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new global::System.Drawing.Point(384, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(136, 80);
			this.panel2.TabIndex = 4;
			this.btnClose.Location = new global::System.Drawing.Point(16, 16);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(96, 24);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(16, 48);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnPrint.Location = new global::System.Drawing.Point(16, 16);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(72, 56);
			this.btnPrint.TabIndex = 0;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.chkFullReport.Location = new global::System.Drawing.Point(176, 32);
			this.chkFullReport.Name = "chkFullReport";
			this.chkFullReport.Size = new global::System.Drawing.Size(112, 16);
			this.chkFullReport.TabIndex = 0;
			this.chkFullReport.Text = "Show Full Report";
			this.chkFullReport.Click += new global::System.EventHandler(this.chkFullReport_Click);
			this.panReportArea.AutoScroll = true;
			this.panReportArea.BackColor = global::System.Drawing.Color.White;
			this.panReportArea.Controls.Add(this.picReport);
			this.panReportArea.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panReportArea.Location = new global::System.Drawing.Point(0, 0);
			this.panReportArea.Name = "panReportArea";
			this.panReportArea.Size = new global::System.Drawing.Size(520, 366);
			this.panReportArea.TabIndex = 0;
			this.picReport.Location = new global::System.Drawing.Point(24, 24);
			this.picReport.Name = "picReport";
			this.picReport.Size = new global::System.Drawing.Size(472, 328);
			this.picReport.TabIndex = 0;
			this.picReport.TabStop = false;
			this.picReport.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picReport_Paint);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(520, 446);
			base.Controls.Add(this.panReportArea);
			base.Controls.Add(this.panel1);
			this.MinimumSize = new global::System.Drawing.Size(408, 280);
			base.Name = "frmConsultant";
			base.ShowInTaskbar = false;
			this.Text = "Consultant's Report";
			base.Load += new global::System.EventHandler(this.frmConsultant_Load);
			base.Resize += new global::System.EventHandler(this.frmConsultant_Resize);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panReportArea.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.picReport).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Panel panReportArea;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.PictureBox picReport;

		// Token: 0x0400005E RID: 94
		private global::System.ComponentModel.Container components = null;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.CheckBox chkFullReport;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Button btnClose;
	}
}
