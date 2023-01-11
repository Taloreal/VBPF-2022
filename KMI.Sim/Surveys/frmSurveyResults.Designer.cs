namespace KMI.Sim.Surveys
{
	// Token: 0x02000005 RID: 5
	public partial class frmSurveyResults : global::System.Windows.Forms.Form
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002990 File Offset: 0x00001990
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

		// Token: 0x06000019 RID: 25 RVA: 0x000029CC File Offset: 0x000019CC
		private void InitializeComponent()
		{
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cboSurvey = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.cboQuestion = new global::System.Windows.Forms.ComboBox();
			this.btnSegment = new global::System.Windows.Forms.Button();
			this.panTop = new global::System.Windows.Forms.Panel();
			this.labQualifyingName = new global::System.Windows.Forms.Label();
			this.cboQualifier = new global::System.Windows.Forms.ComboBox();
			this.panBottom = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panMain = new global::System.Windows.Forms.Panel();
			this.panTop.SuspendLayout();
			this.panBottom.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panMain.SuspendLayout();
			base.SuspendLayout();
			this.kmiGraph1.AutoScaleY = true;
			this.kmiGraph1.AxisLabelFontSize = 9f;
			this.kmiGraph1.AxisTitleFontSize = 9f;
			this.kmiGraph1.BackColor = global::System.Drawing.Color.White;
			this.kmiGraph1.Data = null;
			this.kmiGraph1.DataPointLabelFontSize = 9f;
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.DockPadding.All = 16;
			this.kmiGraph1.GraphType = 1;
			this.kmiGraph1.GridLinesX = false;
			this.kmiGraph1.GridLinesY = false;
			this.kmiGraph1.Legend = true;
			this.kmiGraph1.LegendFontSize = 9f;
			this.kmiGraph1.LineWidth = 3;
			this.kmiGraph1.Location = new global::System.Drawing.Point(80, 120);
			this.kmiGraph1.MinimumYMax = 1f;
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowPercentagesForHistograms = false;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(152, 88);
			this.kmiGraph1.TabIndex = 0;
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
			this.btnClose.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new global::System.Drawing.Point(16, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(96, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(16, 40);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 1;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label1.Location = new global::System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Survey Taken:";
			this.cboSurvey.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSurvey.Location = new global::System.Drawing.Point(16, 24);
			this.cboSurvey.Name = "cboSurvey";
			this.cboSurvey.Size = new global::System.Drawing.Size(112, 21);
			this.cboSurvey.TabIndex = 1;
			this.cboSurvey.SelectedIndexChanged += new global::System.EventHandler(this.cboSurvey_SelectedIndexChanged);
			this.label2.Location = new global::System.Drawing.Point(144, 8);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(120, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Question:";
			this.btnPrint.Location = new global::System.Drawing.Point(328, 24);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(48, 32);
			this.btnPrint.TabIndex = 0;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.cboQuestion.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboQuestion.Location = new global::System.Drawing.Point(144, 24);
			this.cboQuestion.Name = "cboQuestion";
			this.cboQuestion.Size = new global::System.Drawing.Size(248, 21);
			this.cboQuestion.TabIndex = 3;
			this.cboQuestion.SelectedIndexChanged += new global::System.EventHandler(this.cboQuestion_SelectedIndexChanged);
			this.btnSegment.Location = new global::System.Drawing.Point(32, 16);
			this.btnSegment.Name = "btnSegment";
			this.btnSegment.Size = new global::System.Drawing.Size(232, 40);
			this.btnSegment.TabIndex = 0;
			this.btnSegment.Text = "Segment";
			this.btnSegment.Click += new global::System.EventHandler(this.btnSegment_Click);
			this.panTop.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panTop.Controls.Add(this.labQualifyingName);
			this.panTop.Controls.Add(this.cboQualifier);
			this.panTop.Controls.Add(this.cboSurvey);
			this.panTop.Controls.Add(this.label1);
			this.panTop.Controls.Add(this.label2);
			this.panTop.Controls.Add(this.cboQuestion);
			this.panTop.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panTop.Location = new global::System.Drawing.Point(0, 0);
			this.panTop.Name = "panTop";
			this.panTop.Size = new global::System.Drawing.Size(760, 56);
			this.panTop.TabIndex = 0;
			this.labQualifyingName.Location = new global::System.Drawing.Point(408, 9);
			this.labQualifyingName.Name = "labQualifyingName";
			this.labQualifyingName.Size = new global::System.Drawing.Size(120, 16);
			this.labQualifyingName.TabIndex = 4;
			this.labQualifyingName.Text = "Qualifying Name:";
			this.labQualifyingName.Visible = false;
			this.cboQualifier.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboQualifier.Location = new global::System.Drawing.Point(408, 25);
			this.cboQualifier.Name = "cboQualifier";
			this.cboQualifier.Size = new global::System.Drawing.Size(136, 21);
			this.cboQualifier.TabIndex = 5;
			this.cboQualifier.Visible = false;
			this.cboQualifier.SelectedIndexChanged += new global::System.EventHandler(this.cboQualifier_SelectedIndexChanged);
			this.panBottom.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panBottom.Controls.Add(this.panel4);
			this.panBottom.Controls.Add(this.btnSegment);
			this.panBottom.Controls.Add(this.btnPrint);
			this.panBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panBottom.Location = new global::System.Drawing.Point(0, 444);
			this.panBottom.Name = "panBottom";
			this.panBottom.Size = new global::System.Drawing.Size(760, 72);
			this.panBottom.TabIndex = 2;
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Controls.Add(this.btnHelp);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new global::System.Drawing.Point(638, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(120, 70);
			this.panel4.TabIndex = 1;
			this.panMain.Controls.Add(this.kmiGraph1);
			this.panMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panMain.Location = new global::System.Drawing.Point(0, 56);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(760, 388);
			this.panMain.TabIndex = 1;
			this.panMain.Resize += new global::System.EventHandler(this.panMain_Resize);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(760, 516);
			base.Controls.Add(this.panMain);
			base.Controls.Add(this.panBottom);
			base.Controls.Add(this.panTop);
			this.MinimumSize = new global::System.Drawing.Size(568, 328);
			base.Name = "frmSurveyResults";
			base.ShowInTaskbar = false;
			this.Text = "Survey Results";
			base.Load += new global::System.EventHandler(this.frmSurveyResults_Load);
			this.panTop.ResumeLayout(false);
			this.panBottom.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000011 RID: 17
		protected global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000016 RID: 22
		protected global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000017 RID: 23
		protected global::System.Windows.Forms.ComboBox cboQuestion;

		// Token: 0x04000018 RID: 24
		protected global::System.Windows.Forms.Button btnSegment;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.ComboBox cboSurvey;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400001B RID: 27
		protected global::System.Windows.Forms.Panel panMain;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Panel panTop;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Panel panBottom;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label labQualifyingName;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.ComboBox cboQualifier;

		// Token: 0x04000020 RID: 32
		private global::System.ComponentModel.Container components = null;
	}
}
