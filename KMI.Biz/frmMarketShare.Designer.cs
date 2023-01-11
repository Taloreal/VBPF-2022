namespace KMI.Biz
{
	// Token: 0x02000013 RID: 19
	public partial class frmMarketShare : global::System.Windows.Forms.Form
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00008578 File Offset: 0x00007578
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

		// Token: 0x06000081 RID: 129 RVA: 0x000085B4 File Offset: 0x000075B4
		private void InitializeComponent()
		{
			this.marketGraph = new global::KMI.Utility.KMIGraph();
			this.grpShowAs = new global::System.Windows.Forms.GroupBox();
			this.optPieGraph = new global::System.Windows.Forms.RadioButton();
			this.optLineGraph = new global::System.Windows.Forms.RadioButton();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.grpShowAs.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.marketGraph.AutoScaleY = true;
			this.marketGraph.AxisLabelFontSize = 9f;
			this.marketGraph.AxisTitleFontSize = 9f;
			this.marketGraph.Data = null;
			this.marketGraph.DataPointLabelFontSize = 9f;
			this.marketGraph.DataPointLabels = true;
			this.marketGraph.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.marketGraph.GraphType = 1;
			this.marketGraph.GridLinesX = false;
			this.marketGraph.GridLinesY = false;
			this.marketGraph.Legend = true;
			this.marketGraph.LegendFontSize = 9f;
			this.marketGraph.LineWidth = 3;
			this.marketGraph.Location = new global::System.Drawing.Point(0, 0);
			this.marketGraph.MinimumYMax = 1f;
			this.marketGraph.Name = "marketGraph";
			this.marketGraph.PrinterMargin = 100;
			this.marketGraph.ShowPercentagesForHistograms = false;
			this.marketGraph.ShowXTicks = true;
			this.marketGraph.ShowYTicks = true;
			this.marketGraph.Size = new global::System.Drawing.Size(384, 198);
			this.marketGraph.TabIndex = 0;
			this.marketGraph.Title = "Market Share Report";
			this.marketGraph.TitleFontSize = 18f;
			this.marketGraph.XAxisLabels = true;
			this.marketGraph.XAxisTitle = null;
			this.marketGraph.XLabelFormat = null;
			this.marketGraph.YAxisTitle = null;
			this.marketGraph.YLabelFormat = null;
			this.marketGraph.YMax = 0f;
			this.marketGraph.YMin = 0f;
			this.marketGraph.YTicks = 1;
			this.grpShowAs.Controls.Add(this.optPieGraph);
			this.grpShowAs.Controls.Add(this.optLineGraph);
			this.grpShowAs.Location = new global::System.Drawing.Point(16, 8);
			this.grpShowAs.Name = "grpShowAs";
			this.grpShowAs.Size = new global::System.Drawing.Size(224, 48);
			this.grpShowAs.TabIndex = 1;
			this.grpShowAs.TabStop = false;
			this.grpShowAs.Text = "Show As";
			this.optPieGraph.Location = new global::System.Drawing.Point(120, 16);
			this.optPieGraph.Name = "optPieGraph";
			this.optPieGraph.Size = new global::System.Drawing.Size(88, 24);
			this.optPieGraph.TabIndex = 1;
			this.optPieGraph.Text = "&Pie Graph";
			this.optPieGraph.Click += new global::System.EventHandler(this.optPieGraph_Click);
			this.optLineGraph.Location = new global::System.Drawing.Point(16, 16);
			this.optLineGraph.Name = "optLineGraph";
			this.optLineGraph.Size = new global::System.Drawing.Size(88, 24);
			this.optLineGraph.TabIndex = 0;
			this.optLineGraph.Text = "&Line Graph";
			this.optLineGraph.Click += new global::System.EventHandler(this.optLineGraph_Click);
			this.btnClose.Location = new global::System.Drawing.Point(24, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(96, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.grpShowAs);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 198);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(384, 72);
			this.panel1.TabIndex = 0;
			this.panel2.Controls.Add(this.btnHelp);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new global::System.Drawing.Point(248, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(136, 72);
			this.panel2.TabIndex = 0;
			this.btnHelp.Location = new global::System.Drawing.Point(24, 40);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 1;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.SystemColors.ControlDark;
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(368, 192);
			this.label1.TabIndex = 4;
			this.label1.Text = "No businesses exist now";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(384, 270);
			base.Controls.Add(this.marketGraph);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(392, 296);
			base.Name = "frmMarketShare";
			base.ShowInTaskbar = false;
			this.Text = "Market Share";
			base.Load += new global::System.EventHandler(this.frmMarketShare_Load);
			base.Closed += new global::System.EventHandler(this.frmMarketShare_Closed);
			this.grpShowAs.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.GroupBox grpShowAs;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.RadioButton optLineGraph;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.RadioButton optPieGraph;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000077 RID: 119
		private global::KMI.Utility.KMIGraph marketGraph;

		// Token: 0x04000078 RID: 120
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.Button btnHelp;
	}
}
