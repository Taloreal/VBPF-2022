namespace KMI.Biz
{
	// Token: 0x02000014 RID: 20
	public partial class frmProductReport : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00009008 File Offset: 0x00008008
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

		// Token: 0x06000090 RID: 144 RVA: 0x00009044 File Offset: 0x00008044
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::KMI.Biz.frmProductReport));
			this.cmdClose = new global::System.Windows.Forms.Button();
			this.cmdHelp = new global::System.Windows.Forms.Button();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.panCanvas = new global::System.Windows.Forms.Panel();
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.vScroll = new global::System.Windows.Forms.VScrollBar();
			this.hScroll = new global::System.Windows.Forms.HScrollBar();
			this.picCanvas = new global::System.Windows.Forms.PictureBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panProduct = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.chkProduct = new global::System.Windows.Forms.CheckBox();
			this.chkHalf2 = new global::System.Windows.Forms.CheckBox();
			this.chkHalf1 = new global::System.Windows.Forms.CheckBox();
			this.btnUncheckAll = new global::System.Windows.Forms.Button();
			this.btnCheckAll = new global::System.Windows.Forms.Button();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.optUnits = new global::System.Windows.Forms.RadioButton();
			this.optDollars = new global::System.Windows.Forms.RadioButton();
			this.btnExport = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.optGraph = new global::System.Windows.Forms.RadioButton();
			this.optTable = new global::System.Windows.Forms.RadioButton();
			this.chkShowGrid = new global::System.Windows.Forms.CheckBox();
			this.grpData = new global::System.Windows.Forms.GroupBox();
			this.chkData = new global::System.Windows.Forms.CheckBox();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.panel6.SuspendLayout();
			this.panCanvas.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpData.SuspendLayout();
			this.panel5.SuspendLayout();
			base.SuspendLayout();
			this.cmdClose.Location = new global::System.Drawing.Point(16, 24);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new global::System.Drawing.Size(72, 24);
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "Close";
			this.cmdClose.Click += new global::System.EventHandler(this.cmdClose_Click);
			this.cmdHelp.Location = new global::System.Drawing.Point(16, 56);
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.Size = new global::System.Drawing.Size(72, 24);
			this.cmdHelp.TabIndex = 1;
			this.cmdHelp.Text = "Help";
			this.cmdHelp.Click += new global::System.EventHandler(this.cmdHelp_Click);
			this.panel6.Controls.Add(this.panCanvas);
			this.panel6.Controls.Add(this.panel2);
			this.panel6.Controls.Add(this.panel4);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(632, 446);
			this.panel6.TabIndex = 8;
			this.panel6.Resize += new global::System.EventHandler(this.panCanvas_Resize);
			this.panCanvas.Controls.Add(this.kmiGraph1);
			this.panCanvas.Controls.Add(this.vScroll);
			this.panCanvas.Controls.Add(this.hScroll);
			this.panCanvas.Controls.Add(this.picCanvas);
			this.panCanvas.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panCanvas.Location = new global::System.Drawing.Point(144, 0);
			this.panCanvas.Name = "panCanvas";
			this.panCanvas.Size = new global::System.Drawing.Size(488, 350);
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
			this.vScroll.Location = new global::System.Drawing.Point(240, 88);
			this.vScroll.Name = "vScroll";
			this.vScroll.Size = new global::System.Drawing.Size(16, 72);
			this.vScroll.TabIndex = 2;
			this.vScroll.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
			this.hScroll.Location = new global::System.Drawing.Point(144, 176);
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
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panProduct);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(144, 350);
			this.panel2.TabIndex = 9;
			this.panProduct.AutoScroll = true;
			this.panProduct.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panProduct.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.panProduct.Location = new global::System.Drawing.Point(0, 64);
			this.panProduct.Name = "panProduct";
			this.panProduct.Size = new global::System.Drawing.Size(142, 284);
			this.panProduct.TabIndex = 1;
			this.panProduct.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panProduct_Paint);
			this.panel3.BackColor = global::System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.chkProduct);
			this.panel3.Controls.Add(this.chkHalf2);
			this.panel3.Controls.Add(this.chkHalf1);
			this.panel3.Controls.Add(this.btnUncheckAll);
			this.panel3.Controls.Add(this.btnCheckAll);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(142, 64);
			this.panel3.TabIndex = 0;
			this.chkProduct.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.chkProduct.Location = new global::System.Drawing.Point(8, 8);
			this.chkProduct.Name = "chkProduct";
			this.chkProduct.Size = new global::System.Drawing.Size(112, 16);
			this.chkProduct.TabIndex = 9;
			this.chkProduct.Text = "Total";
			this.chkProduct.Click += new global::System.EventHandler(this.chkProduct_Click);
			this.chkProduct.CheckedChanged += new global::System.EventHandler(this.chkProduct_CheckedChanged);
			this.chkHalf2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.chkHalf2.Location = new global::System.Drawing.Point(8, 44);
			this.chkHalf2.Name = "chkHalf2";
			this.chkHalf2.Size = new global::System.Drawing.Size(112, 16);
			this.chkHalf2.TabIndex = 6;
			this.chkHalf2.Tag = "10";
			this.chkHalf2.Text = "Products Half 2";
			this.chkHalf2.CheckedChanged += new global::System.EventHandler(this.chkHalf2_CheckedChanged);
			this.chkHalf1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.chkHalf1.Location = new global::System.Drawing.Point(8, 28);
			this.chkHalf1.Name = "chkHalf1";
			this.chkHalf1.Size = new global::System.Drawing.Size(112, 16);
			this.chkHalf1.TabIndex = 5;
			this.chkHalf1.Tag = "0";
			this.chkHalf1.Text = "Products Half 1";
			this.chkHalf1.CheckedChanged += new global::System.EventHandler(this.chkHalf1_CheckedChanged);
			this.btnUncheckAll.Location = new global::System.Drawing.Point(192, 32);
			this.btnUncheckAll.Name = "btnUncheckAll";
			this.btnUncheckAll.Size = new global::System.Drawing.Size(72, 24);
			this.btnUncheckAll.TabIndex = 4;
			this.btnUncheckAll.Text = "Uncheck All";
			this.btnUncheckAll.Visible = false;
			this.btnUncheckAll.Click += new global::System.EventHandler(this.btnUncheckAll_Click);
			this.btnCheckAll.Location = new global::System.Drawing.Point(192, 32);
			this.btnCheckAll.Name = "btnCheckAll";
			this.btnCheckAll.Size = new global::System.Drawing.Size(72, 24);
			this.btnCheckAll.TabIndex = 3;
			this.btnCheckAll.Text = "Check All";
			this.btnCheckAll.Visible = false;
			this.btnCheckAll.Click += new global::System.EventHandler(this.btnCheckAll_Click);
			this.panel4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Controls.Add(this.btnExport);
			this.panel4.Controls.Add(this.btnPrint);
			this.panel4.Controls.Add(this.groupBox2);
			this.panel4.Controls.Add(this.grpData);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new global::System.Drawing.Point(0, 350);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(632, 96);
			this.panel4.TabIndex = 0;
			this.groupBox1.Controls.Add(this.optUnits);
			this.groupBox1.Controls.Add(this.optDollars);
			this.groupBox1.Location = new global::System.Drawing.Point(392, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(88, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Units";
			this.optUnits.Location = new global::System.Drawing.Point(8, 40);
			this.optUnits.Name = "optUnits";
			this.optUnits.Size = new global::System.Drawing.Size(56, 16);
			this.optUnits.TabIndex = 1;
			this.optUnits.Text = "Units";
			this.optUnits.Click += new global::System.EventHandler(this.optDollarsUnits_Click);
			this.optDollars.Location = new global::System.Drawing.Point(8, 24);
			this.optDollars.Name = "optDollars";
			this.optDollars.Size = new global::System.Drawing.Size(64, 16);
			this.optDollars.TabIndex = 0;
			this.optDollars.Text = "Dollars";
			this.optDollars.Click += new global::System.EventHandler(this.optDollarsUnits_Click);
			this.btnExport.Image = (global::System.Drawing.Image)resourceManager.GetObject("btnExport.Image");
			this.btnExport.Location = new global::System.Drawing.Point(488, 56);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new global::System.Drawing.Size(32, 32);
			this.btnExport.TabIndex = 4;
			this.btnExport.Click += new global::System.EventHandler(this.btnExport_Click);
			this.btnPrint.Image = (global::System.Drawing.Image)resourceManager.GetObject("btnPrint.Image");
			this.btnPrint.Location = new global::System.Drawing.Point(488, 16);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(32, 32);
			this.btnPrint.TabIndex = 3;
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.groupBox2.Controls.Add(this.optGraph);
			this.groupBox2.Controls.Add(this.optTable);
			this.groupBox2.Controls.Add(this.chkShowGrid);
			this.groupBox2.Location = new global::System.Drawing.Point(288, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(96, 80);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Show As";
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
			this.grpData.Controls.Add(this.chkData);
			this.grpData.Location = new global::System.Drawing.Point(8, 8);
			this.grpData.Name = "grpData";
			this.grpData.Size = new global::System.Drawing.Size(272, 80);
			this.grpData.TabIndex = 0;
			this.grpData.TabStop = false;
			this.grpData.Text = "Data";
			this.chkData.Location = new global::System.Drawing.Point(8, 20);
			this.chkData.Name = "chkData";
			this.chkData.Size = new global::System.Drawing.Size(128, 16);
			this.chkData.TabIndex = 1;
			this.chkData.Text = "Sales";
			this.panel5.Controls.Add(this.cmdClose);
			this.panel5.Controls.Add(this.cmdHelp);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new global::System.Drawing.Point(526, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(104, 94);
			this.panel5.TabIndex = 1;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(632, 446);
			base.Controls.Add(this.panel6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(640, 300);
			base.Name = "frmProductReport";
			base.ShowInTaskbar = false;
			this.Text = "Products";
			base.Load += new global::System.EventHandler(this.frmSales_Load);
			base.Closed += new global::System.EventHandler(this.frmSales_Closed);
			this.panel6.ResumeLayout(false);
			this.panCanvas.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.grpData.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.Button cmdClose;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Button cmdHelp;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Panel panCanvas;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.PictureBox picCanvas;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.HScrollBar hScroll;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.VScrollBar vScroll;

		// Token: 0x04000088 RID: 136
		private global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.CheckBox chkShowGrid;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.CheckBox chkData;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.RadioButton optTable;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.RadioButton optGraph;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.GroupBox grpData;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Panel panProduct;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Button btnUncheckAll;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Button btnCheckAll;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Button btnExport;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.RadioButton optUnits;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.RadioButton optDollars;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.CheckBox chkProduct;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.CheckBox chkHalf2;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.CheckBox chkHalf1;

		// Token: 0x0400009C RID: 156
		private global::System.ComponentModel.IContainer components;
	}
}
