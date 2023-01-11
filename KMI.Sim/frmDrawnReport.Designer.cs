namespace KMI.Sim
{
	// Token: 0x02000031 RID: 49
	public partial class frmDrawnReport : global::System.Windows.Forms.Form
	{
		// Token: 0x060001E0 RID: 480 RVA: 0x0000FDD8 File Offset: 0x0000EDD8
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

		// Token: 0x060001E1 RID: 481 RVA: 0x0000FE14 File Offset: 0x0000EE14
		private void InitializeComponent()
		{
			this.picReport = new global::System.Windows.Forms.PictureBox();
			this.pnlMain = new global::System.Windows.Forms.Panel();
			this.pnlBottom = new global::System.Windows.Forms.Panel();
			this.pnlButtons = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.pnlMain.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			base.SuspendLayout();
			this.picReport.Location = new global::System.Drawing.Point(16, 16);
			this.picReport.Name = "picReport";
			this.picReport.Size = new global::System.Drawing.Size(408, 280);
			this.picReport.TabIndex = 0;
			this.picReport.TabStop = false;
			this.picReport.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picReport_Paint);
			this.pnlMain.AutoScroll = true;
			this.pnlMain.Controls.Add(this.picReport);
			this.pnlMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new global::System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new global::System.Drawing.Size(440, 344);
			this.pnlMain.TabIndex = 0;
			this.pnlBottom.Controls.Add(this.pnlButtons);
			this.pnlBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new global::System.Drawing.Point(0, 304);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new global::System.Drawing.Size(440, 40);
			this.pnlBottom.TabIndex = 1;
			this.pnlButtons.Controls.Add(this.btnHelp);
			this.pnlButtons.Controls.Add(this.btnClose);
			this.pnlButtons.Controls.Add(this.btnPrint);
			this.pnlButtons.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pnlButtons.Location = new global::System.Drawing.Point(264, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new global::System.Drawing.Size(176, 40);
			this.pnlButtons.TabIndex = 0;
			this.btnHelp.Location = new global::System.Drawing.Point(120, 8);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(48, 23);
			this.btnHelp.TabIndex = 2;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnClose.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new global::System.Drawing.Point(64, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(48, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnPrint.Location = new global::System.Drawing.Point(8, 8);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(48, 23);
			this.btnPrint.TabIndex = 1;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			base.AcceptButton = this.btnClose;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnClose;
			base.ClientSize = new global::System.Drawing.Size(440, 344);
			base.Controls.Add(this.pnlBottom);
			base.Controls.Add(this.pnlMain);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmDrawnReport";
			base.ShowInTaskbar = false;
			this.Text = "frmDrawnReport";
			base.Load += new global::System.EventHandler(this.frmReport_Load);
			base.Closed += new global::System.EventHandler(this.frmReport_Closed);
			this.pnlMain.ResumeLayout(false);
			this.pnlBottom.ResumeLayout(false);
			this.pnlButtons.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000136 RID: 310
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.Panel pnlMain;

		// Token: 0x0400013B RID: 315
		protected global::System.Windows.Forms.Panel pnlBottom;

		// Token: 0x0400013C RID: 316
		protected global::System.Windows.Forms.PictureBox picReport;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Panel pnlButtons;
	}
}
