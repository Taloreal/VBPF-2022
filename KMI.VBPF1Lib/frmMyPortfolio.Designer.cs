namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmInvesting.
	/// </summary>
	// Token: 0x0200008D RID: 141
	public partial class frmMyPortfolio : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600044F RID: 1103 RVA: 0x0003BDE8 File Offset: 0x0003ADE8
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
		// Token: 0x06000450 RID: 1104 RVA: 0x0003BE24 File Offset: 0x0003AE24
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resources = new global::System.Resources.ResourceManager(typeof(global::KMI.VBPF1Lib.frmMyPortfolio));
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.lnkBuy = new global::System.Windows.Forms.LinkLabel();
			this.panFunds = new global::System.Windows.Forms.Panel();
			this.labTotal = new global::System.Windows.Forms.Label();
			this.labTotalLabel = new global::System.Windows.Forms.Label();
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.labFundName = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel7.SuspendLayout();
			this.panFunds.SuspendLayout();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(384, 400);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 7;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(264, 400);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(144, 400);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panel7.BackColor = global::System.Drawing.Color.White;
			this.panel7.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.lnkBuy);
			this.panel7.Controls.Add(this.panFunds);
			this.panel7.Controls.Add(this.kmiGraph1);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Controls.Add(this.label5);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Controls.Add(this.label3);
			this.panel7.Controls.Add(this.label2);
			this.panel7.Controls.Add(this.labFundName);
			this.panel7.Controls.Add(this.label1);
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(688, 376);
			this.panel7.TabIndex = 8;
			this.lnkBuy.Location = new global::System.Drawing.Point(152, 352);
			this.lnkBuy.Name = "lnkBuy";
			this.lnkBuy.Size = new global::System.Drawing.Size(136, 24);
			this.lnkBuy.TabIndex = 24;
			this.lnkBuy.TabStop = true;
			this.lnkBuy.Text = "Buy Shares";
			this.lnkBuy.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lnkBuy.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBuy_LinkClicked);
			this.panFunds.AutoScroll = true;
			this.panFunds.Controls.Add(this.labTotal);
			this.panFunds.Controls.Add(this.labTotalLabel);
			this.panFunds.Location = new global::System.Drawing.Point(8, 104);
			this.panFunds.Name = "panFunds";
			this.panFunds.Size = new global::System.Drawing.Size(424, 240);
			this.panFunds.TabIndex = 23;
			this.labTotal.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labTotal.Location = new global::System.Drawing.Point(264, 152);
			this.labTotal.Name = "labTotal";
			this.labTotal.Size = new global::System.Drawing.Size(72, 16);
			this.labTotal.TabIndex = 22;
			this.labTotal.Text = "Total";
			this.labTotal.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labTotalLabel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labTotalLabel.Location = new global::System.Drawing.Point(216, 152);
			this.labTotalLabel.Name = "labTotalLabel";
			this.labTotalLabel.Size = new global::System.Drawing.Size(56, 16);
			this.labTotalLabel.TabIndex = 21;
			this.labTotalLabel.Text = "Total";
			this.labTotalLabel.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
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
			this.kmiGraph1.LegendFontSize = 7f;
			this.kmiGraph1.LineWidth = 4;
			this.kmiGraph1.Location = new global::System.Drawing.Point(440, 152);
			this.kmiGraph1.MinimumYMax = 1f;
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowPercentagesForHistograms = false;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(240, 112);
			this.kmiGraph1.TabIndex = 20;
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
			this.label6.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 255);
			this.label6.Location = new global::System.Drawing.Point(304, 88);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(40, 16);
			this.label6.TabIndex = 19;
			this.label6.Text = "Value";
			this.label5.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 255);
			this.label5.Location = new global::System.Drawing.Point(192, 88);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(88, 16);
			this.label5.TabIndex = 18;
			this.label5.Text = "Price && Change";
			this.label4.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 255);
			this.label4.Location = new global::System.Drawing.Point(144, 88);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(40, 16);
			this.label4.TabIndex = 17;
			this.label4.Text = "Shares";
			this.label3.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 255);
			this.label3.Location = new global::System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(72, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "Fund Name";
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(504, 120);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(96, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "Asset Allocation";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labFundName.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 255);
			this.labFundName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labFundName.Location = new global::System.Drawing.Point(8, 80);
			this.labFundName.Name = "labFundName";
			this.labFundName.Size = new global::System.Drawing.Size(424, 24);
			this.labFundName.TabIndex = 14;
			this.labFundName.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Image = (global::System.Drawing.Image)resources.GetObject("label1.Image");
			this.label1.Location = new global::System.Drawing.Point(-8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(200, 72);
			this.label1.TabIndex = 11;
			this.panel1.BackColor = global::System.Drawing.SystemColors.Highlight;
			this.panel1.Location = new global::System.Drawing.Point(440, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(200, 400);
			this.panel1.TabIndex = 0;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(682, 440);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.panel7);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmMyPortfolio";
			base.ShowInTaskbar = false;
			this.Text = "View Portfolio";
			this.panel7.ResumeLayout(false);
			this.panFunds.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040004D8 RID: 1240
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040004D9 RID: 1241
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040004DA RID: 1242
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040004DB RID: 1243
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040004DC RID: 1244
		private global::System.Windows.Forms.Label labFundName;

		// Token: 0x040004DD RID: 1245
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040004DE RID: 1246
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040004DF RID: 1247
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040004E0 RID: 1248
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040004E1 RID: 1249
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040004E2 RID: 1250
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040004E3 RID: 1251
		private global::KMI.Utility.KMIGraph kmiGraph1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040004E4 RID: 1252
		private global::System.ComponentModel.Container components = null;

		// Token: 0x040004E5 RID: 1253
		private global::System.Windows.Forms.Label labTotalLabel;

		// Token: 0x040004E6 RID: 1254
		private global::System.Windows.Forms.Label labTotal;

		// Token: 0x040004E7 RID: 1255
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040004E8 RID: 1256
		private global::System.Windows.Forms.Panel panFunds;

		// Token: 0x040004E9 RID: 1257
		private global::System.Windows.Forms.LinkLabel lnkBuy;
	}
}
