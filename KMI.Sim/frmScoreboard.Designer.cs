namespace KMI.Sim
{
	// Token: 0x02000061 RID: 97
	public partial class frmScoreboard : global::System.Windows.Forms.Form
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x0001A2F4 File Offset: 0x000192F4
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

		// Token: 0x060003A5 RID: 933 RVA: 0x0001A330 File Offset: 0x00019330
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnReplay = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.labEmptyMessage = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.kmiGraph1.AutoScaleY = true;
			this.kmiGraph1.AxisLabelFontSize = 9f;
			this.kmiGraph1.AxisTitleFontSize = 9f;
			this.kmiGraph1.BackColor = global::System.Drawing.Color.White;
			this.kmiGraph1.Data = null;
			this.kmiGraph1.DataPointLabelFontSize = 9f;
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.kmiGraph1.GraphType = 1;
			this.kmiGraph1.GridLinesX = false;
			this.kmiGraph1.GridLinesY = false;
			this.kmiGraph1.Legend = true;
			this.kmiGraph1.LegendFontSize = 9f;
			this.kmiGraph1.LineWidth = 3;
			this.kmiGraph1.Location = new global::System.Drawing.Point(0, 0);
			this.kmiGraph1.MinimumYMax = 1f;
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowPercentagesForHistograms = false;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(256, 222);
			this.kmiGraph1.TabIndex = 5;
			this.kmiGraph1.Title = null;
			this.kmiGraph1.TitleFontSize = 14f;
			this.kmiGraph1.XAxisLabels = true;
			this.kmiGraph1.XAxisTitle = null;
			this.kmiGraph1.XLabelFormat = null;
			this.kmiGraph1.YAxisTitle = null;
			this.kmiGraph1.YLabelFormat = "";
			this.kmiGraph1.YMax = 0f;
			this.kmiGraph1.YMin = 0f;
			this.kmiGraph1.YTicks = 1;
			this.panel1.Controls.Add(this.btnReplay);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 222);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(256, 32);
			this.panel1.TabIndex = 6;
			this.btnReplay.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnReplay.Location = new global::System.Drawing.Point(64, 8);
			this.btnReplay.Name = "btnReplay";
			this.btnReplay.Size = new global::System.Drawing.Size(40, 20);
			this.btnReplay.TabIndex = 9;
			this.btnReplay.Text = "Replay";
			this.btnReplay.Click += new global::System.EventHandler(this.btnReplay_Click);
			this.btnPrint.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnPrint.Location = new global::System.Drawing.Point(8, 8);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(40, 20);
			this.btnPrint.TabIndex = 8;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.panel2.Controls.Add(this.btnHelp);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new global::System.Drawing.Point(120, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(136, 32);
			this.panel2.TabIndex = 0;
			this.btnHelp.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnHelp.Location = new global::System.Drawing.Point(72, 8);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(56, 20);
			this.btnHelp.TabIndex = 11;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnClose.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Location = new global::System.Drawing.Point(8, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(56, 20);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.timer1.Interval = 500;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.labEmptyMessage.CausesValidation = false;
			this.labEmptyMessage.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f);
			this.labEmptyMessage.ForeColor = global::System.Drawing.SystemColors.ControlDark;
			this.labEmptyMessage.Location = new global::System.Drawing.Point(0, 0);
			this.labEmptyMessage.Name = "labEmptyMessage";
			this.labEmptyMessage.Size = new global::System.Drawing.Size(256, 216);
			this.labEmptyMessage.TabIndex = 7;
			this.labEmptyMessage.Text = "No scores are available yet";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(256, 254);
			base.Controls.Add(this.kmiGraph1);
			base.Controls.Add(this.labEmptyMessage);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(200, 216);
			base.Name = "frmScoreboard";
			base.ShowInTaskbar = false;
			this.Text = "Scoreboard";
			base.Resize += new global::System.EventHandler(this.frmScoreboard_Resize);
			base.Load += new global::System.EventHandler(this.frmScoreboard_Load);
			base.Closed += new global::System.EventHandler(this.frmScoreboard_Closed);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000252 RID: 594
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000253 RID: 595
		private global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.Button btnReplay;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Label labEmptyMessage;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Button btnClose;
	}
}
