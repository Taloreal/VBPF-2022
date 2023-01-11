namespace KMI.Biz
{
	// Token: 0x0200000D RID: 13
	public partial class frmFinancials : global::System.Windows.Forms.Form
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00004A20 File Offset: 0x00003A20
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

		// Token: 0x06000047 RID: 71 RVA: 0x00004A5C File Offset: 0x00003A5C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::KMI.Biz.frmFinancials));
			this.cmdClose = new global::System.Windows.Forms.Button();
			this.cmdHelp = new global::System.Windows.Forms.Button();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.panCanvas = new global::System.Windows.Forms.Panel();
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.vScroll = new global::System.Windows.Forms.VScrollBar();
			this.hScroll = new global::System.Windows.Forms.HScrollBar();
			this.picCanvas = new global::System.Windows.Forms.PictureBox();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.btnDetail = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.optUnits = new global::System.Windows.Forms.RadioButton();
			this.optDollars = new global::System.Windows.Forms.RadioButton();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.optGraph = new global::System.Windows.Forms.RadioButton();
			this.optTable = new global::System.Windows.Forms.RadioButton();
			this.chkShowGrid = new global::System.Windows.Forms.CheckBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.optAnnually = new global::System.Windows.Forms.RadioButton();
			this.optQuarterly = new global::System.Windows.Forms.RadioButton();
			this.optWeekly = new global::System.Windows.Forms.RadioButton();
			this.btnExport = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.grpData = new global::System.Windows.Forms.GroupBox();
			this.optBalanceSheet = new global::System.Windows.Forms.RadioButton();
			this.optIncomeStatement = new global::System.Windows.Forms.RadioButton();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.panel6.SuspendLayout();
			this.panCanvas.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpData.SuspendLayout();
			this.panel5.SuspendLayout();
			base.SuspendLayout();
			this.cmdClose.Location = new global::System.Drawing.Point(16, 24);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(72, 24);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "Close";
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdHelp.Location = new global::System.Drawing.Point(16, 56);
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.Size = new global::System.Drawing.Size(72, 24);
			this.cmdHelp.TabIndex = 8;
			this.cmdHelp.Text = "Help";
			this.cmdHelp.Click += new global::System.EventHandler(this.cmdHelp_Click);
			this.panel6.Controls.Add(this.panCanvas);
			this.panel6.Controls.Add(this.panel4);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(632, 425);
			this.panel6.TabIndex = 8;
			this.panel6.Resize += new global::System.EventHandler(this.panCanvas_Resize);
			this.panCanvas.Controls.Add(this.kmiGraph1);
			this.panCanvas.Controls.Add(this.vScroll);
			this.panCanvas.Controls.Add(this.hScroll);
			this.panCanvas.Controls.Add(this.picCanvas);
			this.panCanvas.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panCanvas.Location = new global::System.Drawing.Point(0, 0);
			this.panCanvas.Name = "panCanvas";
			this.panCanvas.Size = new global::System.Drawing.Size(632, 329);
			this.panCanvas.TabIndex = 10;
			this.kmiGraph1.AutoScaleY = true;
			this.kmiGraph1.AxisLabelFontSize = 9f;
			this.kmiGraph1.AxisTitleFontSize = 9f;
			this.kmiGraph1.Data = null;
			this.kmiGraph1.DataPointLabelFontSize = 9f;
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.GraphType = 1;
			this.kmiGraph1.GridLinesX = false;
			this.kmiGraph1.GridLinesY = false;
			this.kmiGraph1.Legend = true;
			this.kmiGraph1.LegendFontSize = 9f;
			this.kmiGraph1.LineWidth = 3;
			this.kmiGraph1.Location = new global::System.Drawing.Point(24, 16);
			this.kmiGraph1.MinimumYMax = 1f;
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowPercentagesForHistograms = false;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(168, 96);
			this.kmiGraph1.TabIndex = 6;
			this.kmiGraph1.Title = null;
			this.kmiGraph1.TitleFontSize = 18f;
			this.kmiGraph1.XAxisLabels = true;
			this.kmiGraph1.XAxisTitle = null;
			this.kmiGraph1.XLabelFormat = null;
			this.kmiGraph1.YAxisTitle = null;
			this.kmiGraph1.YLabelFormat = null;
			this.kmiGraph1.YMax = 0f;
			this.kmiGraph1.YMin = 0f;
			this.kmiGraph1.YTicks = 1;
			this.vScroll.LargeChange = 1;
			this.vScroll.Location = new global::System.Drawing.Point(240, 88);
			this.vScroll.Maximum = 0;
			this.vScroll.Name = "vScroll";
			this.vScroll.Size = new global::System.Drawing.Size(16, 72);
			this.vScroll.TabIndex = 2;
			this.vScroll.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
			this.hScroll.Location = new global::System.Drawing.Point(144, 176);
			this.hScroll.Maximum = 25;
			this.hScroll.Name = "hScroll";
			this.hScroll.Size = new global::System.Drawing.Size(88, 16);
			this.hScroll.TabIndex = 1;
			this.hScroll.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.hScroll_Scroll);
			this.picCanvas.BackColor = global::System.Drawing.Color.White;
			this.picCanvas.Location = new global::System.Drawing.Point(144, 96);
			this.picCanvas.Name = "picCanvas";
			this.picCanvas.Size = new global::System.Drawing.Size(88, 72);
			this.picCanvas.TabIndex = 0;
			this.picCanvas.TabStop = false;
			this.picCanvas.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
			this.picCanvas.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
			this.picCanvas.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
			this.panel4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.btnDetail);
			this.panel4.Controls.Add(this.groupBox2);
			this.panel4.Controls.Add(this.groupBox3);
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Controls.Add(this.btnExport);
			this.panel4.Controls.Add(this.btnPrint);
			this.panel4.Controls.Add(this.grpData);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new global::System.Drawing.Point(0, 329);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(632, 96);
			this.panel4.TabIndex = 0;
			this.btnDetail.Location = new global::System.Drawing.Point(8, 64);
			this.btnDetail.Name = "btnDetail";
			this.btnDetail.Size = new global::System.Drawing.Size(144, 24);
			this.btnDetail.TabIndex = 6;
			this.btnDetail.Text = "More Detail >>";
			this.btnDetail.Click += new global::System.EventHandler(this.btnDetail_Click);
			this.groupBox2.Controls.Add(this.optUnits);
			this.groupBox2.Controls.Add(this.optDollars);
			this.groupBox2.Location = new global::System.Drawing.Point(368, 7);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(88, 80);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Units";
			this.optUnits.Location = new global::System.Drawing.Point(8, 40);
			this.optUnits.Name = "optUnits";
			this.optUnits.Size = new global::System.Drawing.Size(72, 16);
			this.optUnits.TabIndex = 1;
			this.optUnits.Text = "Percents";
			this.optUnits.Click += new global::System.EventHandler(this.optDollarsUnits_Click);
			this.optDollars.Location = new global::System.Drawing.Point(8, 24);
			this.optDollars.Name = "optDollars";
			this.optDollars.Size = new global::System.Drawing.Size(72, 16);
			this.optDollars.TabIndex = 0;
			this.optDollars.Text = "Dollars";
			this.optDollars.Click += new global::System.EventHandler(this.optDollarsUnits_Click);
			this.groupBox3.Controls.Add(this.optGraph);
			this.groupBox3.Controls.Add(this.optTable);
			this.groupBox3.Controls.Add(this.chkShowGrid);
			this.groupBox3.Location = new global::System.Drawing.Point(264, 7);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(96, 80);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Show As";
			this.optGraph.Location = new global::System.Drawing.Point(16, 40);
			this.optGraph.Name = "optGraph";
			this.optGraph.Size = new global::System.Drawing.Size(72, 16);
			this.optGraph.TabIndex = 1;
			this.optGraph.Text = "Graph";
			this.optGraph.Click += new global::System.EventHandler(this.optTableGraph_Click);
			this.optTable.Location = new global::System.Drawing.Point(16, 24);
			this.optTable.Name = "optTable";
			this.optTable.Size = new global::System.Drawing.Size(72, 16);
			this.optTable.TabIndex = 0;
			this.optTable.Text = "Table";
			this.optTable.Click += new global::System.EventHandler(this.optTableGraph_Click);
			this.chkShowGrid.Location = new global::System.Drawing.Point(40, 56);
			this.chkShowGrid.Name = "chkShowGrid";
			this.chkShowGrid.Size = new global::System.Drawing.Size(48, 16);
			this.chkShowGrid.TabIndex = 2;
			this.chkShowGrid.Text = "Grid";
			this.chkShowGrid.CheckedChanged += new global::System.EventHandler(this.chkShowGrid_CheckedChanged);
			this.groupBox1.Controls.Add(this.optAnnually);
			this.groupBox1.Controls.Add(this.optQuarterly);
			this.groupBox1.Controls.Add(this.optWeekly);
			this.groupBox1.Location = new global::System.Drawing.Point(160, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(96, 80);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Frequency";
			this.optAnnually.Location = new global::System.Drawing.Point(16, 56);
			this.optAnnually.Name = "optAnnually";
			this.optAnnually.Size = new global::System.Drawing.Size(72, 16);
			this.optAnnually.TabIndex = 2;
			this.optAnnually.Text = "Annually";
			this.optAnnually.Click += new global::System.EventHandler(this.optFrequency_Click);
			this.optQuarterly.Location = new global::System.Drawing.Point(16, 40);
			this.optQuarterly.Name = "optQuarterly";
			this.optQuarterly.Size = new global::System.Drawing.Size(72, 16);
			this.optQuarterly.TabIndex = 1;
			this.optQuarterly.Text = "Quarterly";
			this.optQuarterly.Click += new global::System.EventHandler(this.optFrequency_Click);
			this.optWeekly.Location = new global::System.Drawing.Point(16, 24);
			this.optWeekly.Name = "optWeekly";
			this.optWeekly.Size = new global::System.Drawing.Size(72, 16);
			this.optWeekly.TabIndex = 0;
			this.optWeekly.Text = "Weekly";
			this.optWeekly.Click += new global::System.EventHandler(this.optFrequency_Click);
			this.btnExport.Image = (global::System.Drawing.Image)resourceManager.GetObject("btnExport.Image");
			this.btnExport.Location = new global::System.Drawing.Point(472, 56);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new global::System.Drawing.Size(32, 32);
			this.btnExport.TabIndex = 5;
			this.btnExport.Click += new global::System.EventHandler(this.btnExport_Click);
			this.btnPrint.Image = (global::System.Drawing.Image)resourceManager.GetObject("btnPrint.Image");
			this.btnPrint.Location = new global::System.Drawing.Point(472, 16);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(32, 32);
			this.btnPrint.TabIndex = 4;
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.grpData.Controls.Add(this.optBalanceSheet);
			this.grpData.Controls.Add(this.optIncomeStatement);
			this.grpData.Location = new global::System.Drawing.Point(8, 8);
			this.grpData.Name = "grpData";
			this.grpData.Size = new global::System.Drawing.Size(144, 52);
			this.grpData.TabIndex = 0;
			this.grpData.TabStop = false;
			this.grpData.Text = "Statement";
			this.optBalanceSheet.Location = new global::System.Drawing.Point(16, 32);
			this.optBalanceSheet.Name = "optBalanceSheet";
			this.optBalanceSheet.Size = new global::System.Drawing.Size(120, 16);
			this.optBalanceSheet.TabIndex = 1;
			this.optBalanceSheet.Text = "Balance Sheet";
			this.optBalanceSheet.Click += new global::System.EventHandler(this.optStatement_Click);
			this.optIncomeStatement.Location = new global::System.Drawing.Point(16, 16);
			this.optIncomeStatement.Name = "optIncomeStatement";
			this.optIncomeStatement.Size = new global::System.Drawing.Size(120, 16);
			this.optIncomeStatement.TabIndex = 0;
			this.optIncomeStatement.Text = "Income Statement";
			this.optIncomeStatement.Click += new global::System.EventHandler(this.optStatement_Click);
			this.panel5.Controls.Add(this.cmdClose);
			this.panel5.Controls.Add(this.cmdHelp);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new global::System.Drawing.Point(526, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(104, 94);
			this.panel5.TabIndex = 7;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(632, 425);
			base.Controls.Add(this.panel6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(640, 300);
			base.Name = "frmFinancials";
			base.ShowInTaskbar = false;
			this.Text = "Financials";
			base.Load += new global::System.EventHandler(this.frmFinancials_Load);
			base.Closed += new global::System.EventHandler(this.frmFinancials_Closed);
			this.panel6.ResumeLayout(false);
			this.panCanvas.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpData.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Button cmdClose;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Button cmdHelp;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Panel panCanvas;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.PictureBox picCanvas;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.HScrollBar hScroll;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.VScrollBar vScroll;

		// Token: 0x0400002C RID: 44
		private global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.GroupBox grpData;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Button btnExport;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.RadioButton optUnits;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.RadioButton optDollars;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.RadioButton optGraph;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.RadioButton optTable;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.CheckBox chkShowGrid;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.RadioButton optWeekly;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.RadioButton optQuarterly;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.RadioButton optAnnually;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.RadioButton optIncomeStatement;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.RadioButton optBalanceSheet;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Button btnDetail;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x0400003F RID: 63
		private global::System.ComponentModel.IContainer components;
	}
}
