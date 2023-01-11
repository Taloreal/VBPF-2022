namespace KMI.Biz
{
	// Token: 0x02000011 RID: 17
	public partial class frmVitalSigns : global::System.Windows.Forms.Form
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00007BA4 File Offset: 0x00006BA4
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

		// Token: 0x06000079 RID: 121 RVA: 0x00007BE0 File Offset: 0x00006BE0
		private void InitializeComponent()
		{
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.labProfitLabel = new global::System.Windows.Forms.Label();
			this.labCumProfit = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.kmiGraph2 = new global::KMI.Utility.KMIGraph();
			this.kmiGraph3 = new global::KMI.Utility.KMIGraph();
			base.SuspendLayout();
			this.kmiGraph1.AutoScaleY = true;
			this.kmiGraph1.AxisLabelFontSize = 7f;
			this.kmiGraph1.AxisTitleFontSize = 9f;
			this.kmiGraph1.BackColor = global::System.Drawing.SystemColors.Control;
			this.kmiGraph1.Data = null;
			this.kmiGraph1.DataPointLabelFontSize = 9f;
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.GraphType = 1;
			this.kmiGraph1.GridLinesX = false;
			this.kmiGraph1.GridLinesY = false;
			this.kmiGraph1.Legend = true;
			this.kmiGraph1.LegendFontSize = 9f;
			this.kmiGraph1.LineWidth = 3;
			this.kmiGraph1.Location = new global::System.Drawing.Point(8, 8);
			this.kmiGraph1.MinimumYMax = 1f;
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowPercentagesForHistograms = false;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(136, 120);
			this.kmiGraph1.TabIndex = 0;
			this.kmiGraph1.Title = null;
			this.kmiGraph1.TitleFontSize = 8f;
			this.kmiGraph1.XAxisLabels = true;
			this.kmiGraph1.XAxisTitle = null;
			this.kmiGraph1.XLabelFormat = null;
			this.kmiGraph1.YAxisTitle = null;
			this.kmiGraph1.YLabelFormat = null;
			this.kmiGraph1.YMax = 0f;
			this.kmiGraph1.YMin = 0f;
			this.kmiGraph1.YTicks = 1;
			this.labProfitLabel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labProfitLabel.Location = new global::System.Drawing.Point(152, 144);
			this.labProfitLabel.Name = "labProfitLabel";
			this.labProfitLabel.Size = new global::System.Drawing.Size(136, 28);
			this.labProfitLabel.TabIndex = 3;
			this.labProfitLabel.Text = "Cumulative Profit";
			this.labProfitLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labCumProfit.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.labCumProfit.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labCumProfit.Location = new global::System.Drawing.Point(152, 176);
			this.labCumProfit.Name = "labCumProfit";
			this.labCumProfit.Size = new global::System.Drawing.Size(136, 32);
			this.labCumProfit.TabIndex = 4;
			this.labCumProfit.Text = "$999,999,999";
			this.labCumProfit.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.Location = new global::System.Drawing.Point(176, 224);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(88, 24);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.kmiGraph2.AutoScaleY = true;
			this.kmiGraph2.AxisLabelFontSize = 7f;
			this.kmiGraph2.AxisTitleFontSize = 9f;
			this.kmiGraph2.BackColor = global::System.Drawing.SystemColors.Control;
			this.kmiGraph2.Data = null;
			this.kmiGraph2.DataPointLabelFontSize = 9f;
			this.kmiGraph2.DataPointLabels = true;
			this.kmiGraph2.GraphType = 1;
			this.kmiGraph2.GridLinesX = false;
			this.kmiGraph2.GridLinesY = false;
			this.kmiGraph2.Legend = true;
			this.kmiGraph2.LegendFontSize = 9f;
			this.kmiGraph2.LineWidth = 3;
			this.kmiGraph2.Location = new global::System.Drawing.Point(152, 8);
			this.kmiGraph2.MinimumYMax = 1f;
			this.kmiGraph2.Name = "kmiGraph2";
			this.kmiGraph2.PrinterMargin = 100;
			this.kmiGraph2.ShowPercentagesForHistograms = false;
			this.kmiGraph2.ShowXTicks = true;
			this.kmiGraph2.ShowYTicks = true;
			this.kmiGraph2.Size = new global::System.Drawing.Size(136, 120);
			this.kmiGraph2.TabIndex = 1;
			this.kmiGraph2.Title = null;
			this.kmiGraph2.TitleFontSize = 8f;
			this.kmiGraph2.XAxisLabels = true;
			this.kmiGraph2.XAxisTitle = null;
			this.kmiGraph2.XLabelFormat = null;
			this.kmiGraph2.YAxisTitle = null;
			this.kmiGraph2.YLabelFormat = null;
			this.kmiGraph2.YMax = 0f;
			this.kmiGraph2.YMin = 0f;
			this.kmiGraph2.YTicks = 1;
			this.kmiGraph3.AutoScaleY = true;
			this.kmiGraph3.AxisLabelFontSize = 7f;
			this.kmiGraph3.AxisTitleFontSize = 9f;
			this.kmiGraph3.BackColor = global::System.Drawing.SystemColors.Control;
			this.kmiGraph3.Data = null;
			this.kmiGraph3.DataPointLabelFontSize = 9f;
			this.kmiGraph3.DataPointLabels = true;
			this.kmiGraph3.GraphType = 1;
			this.kmiGraph3.GridLinesX = false;
			this.kmiGraph3.GridLinesY = false;
			this.kmiGraph3.Legend = true;
			this.kmiGraph3.LegendFontSize = 9f;
			this.kmiGraph3.LineWidth = 3;
			this.kmiGraph3.Location = new global::System.Drawing.Point(8, 136);
			this.kmiGraph3.MinimumYMax = 1f;
			this.kmiGraph3.Name = "kmiGraph3";
			this.kmiGraph3.PrinterMargin = 100;
			this.kmiGraph3.ShowPercentagesForHistograms = false;
			this.kmiGraph3.ShowXTicks = true;
			this.kmiGraph3.ShowYTicks = true;
			this.kmiGraph3.Size = new global::System.Drawing.Size(136, 120);
			this.kmiGraph3.TabIndex = 2;
			this.kmiGraph3.Title = null;
			this.kmiGraph3.TitleFontSize = 8f;
			this.kmiGraph3.XAxisLabels = true;
			this.kmiGraph3.XAxisTitle = null;
			this.kmiGraph3.XLabelFormat = null;
			this.kmiGraph3.YAxisTitle = null;
			this.kmiGraph3.YLabelFormat = null;
			this.kmiGraph3.YMax = 0f;
			this.kmiGraph3.YMin = 0f;
			this.kmiGraph3.YTicks = 1;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(296, 264);
			base.Controls.Add(this.kmiGraph3);
			base.Controls.Add(this.kmiGraph2);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.labCumProfit);
			base.Controls.Add(this.kmiGraph1);
			base.Controls.Add(this.labProfitLabel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmVitalSigns";
			base.ShowInTaskbar = false;
			this.Text = "Vital Signs - Last 8 Weeks";
			base.Load += new global::System.EventHandler(this.frmVitalSigns_Load);
			base.Closed += new global::System.EventHandler(this.frmVitalSigns_Closed);
			base.ResumeLayout(false);
		}

		// Token: 0x04000065 RID: 101
		private global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x04000066 RID: 102
		protected global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000067 RID: 103
		protected global::System.Windows.Forms.Label labCumProfit;

		// Token: 0x04000068 RID: 104
		private global::KMI.Utility.KMIGraph kmiGraph2;

		// Token: 0x04000069 RID: 105
		protected global::System.Windows.Forms.Label labProfitLabel;

		// Token: 0x0400006A RID: 106
		private global::KMI.Utility.KMIGraph kmiGraph3;

		// Token: 0x0400006B RID: 107
		private global::System.ComponentModel.Container components = null;
	}
}
