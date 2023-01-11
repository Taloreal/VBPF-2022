namespace KMI.Sim
{
	// Token: 0x0200003E RID: 62
	public partial class frmActionsJournal : global::System.Windows.Forms.Form
	{
		// Token: 0x06000263 RID: 611 RVA: 0x00013A48 File Offset: 0x00012A48
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

		// Token: 0x06000264 RID: 612 RVA: 0x00013A84 File Offset: 0x00012A84
		private void InitializeComponent()
		{
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.splitter1 = new global::System.Windows.Forms.Splitter();
			this.txtEntries = new global::System.Windows.Forms.TextBox();
			this.panGraph = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panGraph.SuspendLayout();
			base.SuspendLayout();
			this.kmiGraph1.AutoScaleY = true;
			this.kmiGraph1.AxisLabelFontSize = 9f;
			this.kmiGraph1.AxisTitleFontSize = 9f;
			this.kmiGraph1.BackColor = global::System.Drawing.SystemColors.Control;
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
			this.kmiGraph1.Location = new global::System.Drawing.Point(8, 8);
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(536, 136);
			this.kmiGraph1.TabIndex = 0;
			this.kmiGraph1.Title = null;
			this.kmiGraph1.TitleFontSize = 18f;
			this.kmiGraph1.XAxisLabels = true;
			this.kmiGraph1.XAxisTitle = null;
			this.kmiGraph1.XLabelFormat = null;
			this.kmiGraph1.YAxisTitle = null;
			this.kmiGraph1.YLabelFormat = "";
			this.kmiGraph1.YMax = 0f;
			this.kmiGraph1.YMin = 0f;
			this.kmiGraph1.YTicks = 1;
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 382);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(552, 40);
			this.panel1.TabIndex = 7;
			this.btnPrint.Location = new global::System.Drawing.Point(24, 8);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(96, 24);
			this.btnPrint.TabIndex = 0;
			this.btnPrint.Text = "Print Journal";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.panel2.Controls.Add(this.btnHelp);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new global::System.Drawing.Point(312, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(240, 40);
			this.panel2.TabIndex = 1;
			this.btnHelp.Location = new global::System.Drawing.Point(128, 8);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(104, 24);
			this.btnHelp.TabIndex = 1;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnClose.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new global::System.Drawing.Point(16, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(104, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.panel3.Controls.Add(this.splitter1);
			this.panel3.Controls.Add(this.txtEntries);
			this.panel3.Controls.Add(this.panGraph);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(552, 422);
			this.panel3.TabIndex = 8;
			this.splitter1.BackColor = global::System.Drawing.SystemColors.ControlDark;
			this.splitter1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new global::System.Drawing.Point(0, 228);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new global::System.Drawing.Size(552, 2);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			this.txtEntries.BackColor = global::System.Drawing.Color.White;
			this.txtEntries.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtEntries.Location = new global::System.Drawing.Point(0, 0);
			this.txtEntries.Multiline = true;
			this.txtEntries.Name = "txtEntries";
			this.txtEntries.ReadOnly = true;
			this.txtEntries.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.txtEntries.Size = new global::System.Drawing.Size(552, 230);
			this.txtEntries.TabIndex = 0;
			this.txtEntries.Text = "textBox1";
			this.txtEntries.WordWrap = false;
			this.panGraph.Controls.Add(this.kmiGraph1);
			this.panGraph.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panGraph.DockPadding.All = 8;
			this.panGraph.Location = new global::System.Drawing.Point(0, 230);
			this.panGraph.Name = "panGraph";
			this.panGraph.Size = new global::System.Drawing.Size(552, 152);
			this.panGraph.TabIndex = 6;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(552, 422);
			base.Controls.Add(this.panel3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new global::System.Drawing.Size(384, 344);
			base.Name = "frmActionsJournal";
			base.ShowInTaskbar = false;
			this.Text = "Actions Journal";
			base.Load += new global::System.EventHandler(this.frmActionsJournal_Load);
			base.Closed += new global::System.EventHandler(this.frmActionsJournal_Closed);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panGraph.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400017C RID: 380
		private global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.TextBox txtEntries;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.Splitter splitter1;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.Panel panGraph;

		// Token: 0x04000186 RID: 390
		private global::System.ComponentModel.Container components = null;
	}
}
