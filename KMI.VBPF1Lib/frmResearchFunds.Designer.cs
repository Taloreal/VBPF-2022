namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmInvesting.
	/// </summary>
	// Token: 0x02000085 RID: 133
	public partial class frmResearchFunds : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000424 RID: 1060 RVA: 0x000386F4 File Offset: 0x000376F4
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
		// Token: 0x06000425 RID: 1061 RVA: 0x00038730 File Offset: 0x00037730
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resources = new global::System.Resources.ResourceManager(typeof(global::KMI.VBPF1Lib.frmResearchFunds));
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.labYield = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.lnkBuy = new global::System.Windows.Forms.LinkLabel();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.lstFunds = new global::System.Windows.Forms.ListBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cboSector = new global::System.Windows.Forms.ComboBox();
			this.lnkExport = new global::System.Windows.Forms.LinkLabel();
			this.labBack = new global::System.Windows.Forms.Label();
			this.label22 = new global::System.Windows.Forms.Label();
			this.labFront = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.lab12b1 = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			this.labTER = new global::System.Windows.Forms.Label();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.labYTD = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.labPrevious = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.labChange = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.labNav = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.labFundName = new global::System.Windows.Forms.Label();
			this.lnk5Year = new global::System.Windows.Forms.LinkLabel();
			this.lnk1Year = new global::System.Windows.Forms.LinkLabel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.kmiGraph1 = new global::KMI.Utility.KMIGraph();
			this.panel7.SuspendLayout();
			this.panel9.SuspendLayout();
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
			this.panel7.Controls.Add(this.labYield);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Controls.Add(this.lnkBuy);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Controls.Add(this.labBack);
			this.panel7.Controls.Add(this.label22);
			this.panel7.Controls.Add(this.labFront);
			this.panel7.Controls.Add(this.label16);
			this.panel7.Controls.Add(this.lab12b1);
			this.panel7.Controls.Add(this.label18);
			this.panel7.Controls.Add(this.labTER);
			this.panel7.Controls.Add(this.label20);
			this.panel7.Controls.Add(this.label14);
			this.panel7.Controls.Add(this.labYTD);
			this.panel7.Controls.Add(this.label11);
			this.panel7.Controls.Add(this.labPrevious);
			this.panel7.Controls.Add(this.label9);
			this.panel7.Controls.Add(this.labChange);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Controls.Add(this.labNav);
			this.panel7.Controls.Add(this.label2);
			this.panel7.Controls.Add(this.labFundName);
			this.panel7.Controls.Add(this.lnk5Year);
			this.panel7.Controls.Add(this.lnk1Year);
			this.panel7.Controls.Add(this.label1);
			this.panel7.Controls.Add(this.kmiGraph1);
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(640, 376);
			this.panel7.TabIndex = 8;
			this.labYield.Location = new global::System.Drawing.Point(128, 216);
			this.labYield.Name = "labYield";
			this.labYield.Size = new global::System.Drawing.Size(56, 16);
			this.labYield.TabIndex = 37;
			this.labYield.Text = "Net Asset Value:";
			this.labYield.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label4.Location = new global::System.Drawing.Point(16, 216);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(88, 16);
			this.label4.TabIndex = 36;
			this.label4.Text = "Yield:";
			this.lnkBuy.Location = new global::System.Drawing.Point(312, 352);
			this.lnkBuy.Name = "lnkBuy";
			this.lnkBuy.Size = new global::System.Drawing.Size(80, 16);
			this.lnkBuy.TabIndex = 35;
			this.lnkBuy.TabStop = true;
			this.lnkBuy.Text = "Buy Shares";
			this.lnkBuy.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lnkBuy.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBuy_LinkClicked);
			this.panel9.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Controls.Add(this.lstFunds);
			this.panel9.Controls.Add(this.label5);
			this.panel9.Controls.Add(this.label7);
			this.panel9.Controls.Add(this.cboSector);
			this.panel9.Controls.Add(this.lnkExport);
			this.panel9.DockPadding.Bottom = 10;
			this.panel9.DockPadding.Left = 10;
			this.panel9.DockPadding.Right = 10;
			this.panel9.Location = new global::System.Drawing.Point(456, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(184, 374);
			this.panel9.TabIndex = 34;
			this.lstFunds.Location = new global::System.Drawing.Point(8, 88);
			this.lstFunds.Name = "lstFunds";
			this.lstFunds.Size = new global::System.Drawing.Size(164, 238);
			this.lstFunds.Sorted = true;
			this.lstFunds.TabIndex = 0;
			this.lstFunds.SelectedIndexChanged += new global::System.EventHandler(this.lstFunds_SelectedIndexChanged_1);
			this.label5.Location = new global::System.Drawing.Point(8, 72);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(88, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Funds:";
			this.label7.Location = new global::System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(96, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "Fund Category:";
			this.cboSector.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSector.ItemHeight = 13;
			this.cboSector.Location = new global::System.Drawing.Point(8, 32);
			this.cboSector.Name = "cboSector";
			this.cboSector.Size = new global::System.Drawing.Size(168, 21);
			this.cboSector.TabIndex = 3;
			this.cboSector.SelectedIndexChanged += new global::System.EventHandler(this.cboSector_SelectedIndexChanged);
			this.lnkExport.Location = new global::System.Drawing.Point(4, 348);
			this.lnkExport.Name = "lnkExport";
			this.lnkExport.Size = new global::System.Drawing.Size(168, 16);
			this.lnkExport.TabIndex = 36;
			this.lnkExport.TabStop = true;
			this.lnkExport.Text = "Export Price Histories to Excel";
			this.lnkExport.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lnkExport.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExport_LinkClicked);
			this.labBack.Location = new global::System.Drawing.Point(128, 344);
			this.labBack.Name = "labBack";
			this.labBack.Size = new global::System.Drawing.Size(56, 16);
			this.labBack.TabIndex = 33;
			this.labBack.Text = "Net Asset Value:";
			this.labBack.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label22.Location = new global::System.Drawing.Point(16, 344);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(88, 16);
			this.label22.TabIndex = 32;
			this.label22.Text = "Back End Load:";
			this.labFront.Location = new global::System.Drawing.Point(128, 320);
			this.labFront.Name = "labFront";
			this.labFront.Size = new global::System.Drawing.Size(56, 16);
			this.labFront.TabIndex = 31;
			this.labFront.Text = "Net Asset Value:";
			this.labFront.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label16.Location = new global::System.Drawing.Point(16, 320);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(88, 16);
			this.label16.TabIndex = 30;
			this.label16.Text = "Front End Load:";
			this.lab12b1.Location = new global::System.Drawing.Point(128, 296);
			this.lab12b1.Name = "lab12b1";
			this.lab12b1.Size = new global::System.Drawing.Size(56, 16);
			this.lab12b1.TabIndex = 29;
			this.lab12b1.Text = "Net Asset Value:";
			this.lab12b1.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label18.Location = new global::System.Drawing.Point(16, 296);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(88, 16);
			this.label18.TabIndex = 28;
			this.label18.Text = "Max 12b1 Fee:";
			this.labTER.Location = new global::System.Drawing.Point(128, 272);
			this.labTER.Name = "labTER";
			this.labTER.Size = new global::System.Drawing.Size(56, 16);
			this.labTER.TabIndex = 27;
			this.labTER.Text = "Net Asset Value:";
			this.labTER.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label20.Location = new global::System.Drawing.Point(16, 272);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(112, 16);
			this.label20.TabIndex = 26;
			this.label20.Text = "Total Expense Ratio:";
			this.label14.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.label14.Location = new global::System.Drawing.Point(16, 248);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(176, 16);
			this.label14.TabIndex = 25;
			this.label14.Text = "Fees && Expenses:";
			this.labYTD.Location = new global::System.Drawing.Point(128, 192);
			this.labYTD.Name = "labYTD";
			this.labYTD.Size = new global::System.Drawing.Size(56, 16);
			this.labYTD.TabIndex = 22;
			this.labYTD.Text = "Net Asset Value:";
			this.labYTD.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label11.Location = new global::System.Drawing.Point(16, 192);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(88, 16);
			this.label11.TabIndex = 21;
			this.label11.Text = "YTD Return:";
			this.labPrevious.Location = new global::System.Drawing.Point(128, 168);
			this.labPrevious.Name = "labPrevious";
			this.labPrevious.Size = new global::System.Drawing.Size(56, 16);
			this.labPrevious.TabIndex = 20;
			this.labPrevious.Text = "Net Asset Value:";
			this.labPrevious.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label9.Location = new global::System.Drawing.Point(16, 168);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(88, 16);
			this.label9.TabIndex = 19;
			this.label9.Text = "Previous Close:";
			this.labChange.Location = new global::System.Drawing.Point(128, 144);
			this.labChange.Name = "labChange";
			this.labChange.Size = new global::System.Drawing.Size(56, 16);
			this.labChange.TabIndex = 18;
			this.labChange.Text = "Net Asset Value:";
			this.labChange.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(16, 144);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(88, 16);
			this.label6.TabIndex = 17;
			this.label6.Text = "Change:";
			this.labNav.Location = new global::System.Drawing.Point(128, 120);
			this.labNav.Name = "labNav";
			this.labNav.Size = new global::System.Drawing.Size(56, 16);
			this.labNav.TabIndex = 16;
			this.labNav.Text = "Net Asset Value:";
			this.labNav.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label2.Location = new global::System.Drawing.Point(16, 120);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "Net Asset Value:";
			this.labFundName.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 255);
			this.labFundName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labFundName.Location = new global::System.Drawing.Point(16, 80);
			this.labFundName.Name = "labFundName";
			this.labFundName.Size = new global::System.Drawing.Size(432, 24);
			this.labFundName.TabIndex = 14;
			this.labFundName.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lnk5Year.Location = new global::System.Drawing.Point(368, 328);
			this.lnk5Year.Name = "lnk5Year";
			this.lnk5Year.Size = new global::System.Drawing.Size(24, 16);
			this.lnk5Year.TabIndex = 13;
			this.lnk5Year.TabStop = true;
			this.lnk5Year.Text = "5 Y";
			this.lnk5Year.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk1Year_LinkClicked);
			this.lnk1Year.Location = new global::System.Drawing.Point(312, 328);
			this.lnk1Year.Name = "lnk1Year";
			this.lnk1Year.Size = new global::System.Drawing.Size(24, 16);
			this.lnk1Year.TabIndex = 12;
			this.lnk1Year.TabStop = true;
			this.lnk1Year.Text = "1 Y";
			this.lnk1Year.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk1Year_LinkClicked);
			this.label1.Image = (global::System.Drawing.Image)resources.GetObject("label1.Image");
			this.label1.Location = new global::System.Drawing.Point(-8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(200, 72);
			this.label1.TabIndex = 11;
			this.kmiGraph1.AutoScaleY = true;
			this.kmiGraph1.AxisLabelFontSize = 9f;
			this.kmiGraph1.AxisTitleFontSize = 9f;
			this.kmiGraph1.BackColor = global::System.Drawing.Color.White;
			this.kmiGraph1.Data = null;
			this.kmiGraph1.DataPointLabelFontSize = 9f;
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.DockPadding.All = 10;
			this.kmiGraph1.GraphType = 1;
			this.kmiGraph1.GridLinesX = true;
			this.kmiGraph1.GridLinesY = true;
			this.kmiGraph1.Legend = false;
			this.kmiGraph1.LegendFontSize = 9f;
			this.kmiGraph1.LineWidth = 4;
			this.kmiGraph1.Location = new global::System.Drawing.Point(208, 112);
			this.kmiGraph1.MinimumYMax = 1f;
			this.kmiGraph1.Name = "kmiGraph1";
			this.kmiGraph1.PrinterMargin = 100;
			this.kmiGraph1.ShowPercentagesForHistograms = false;
			this.kmiGraph1.ShowXTicks = true;
			this.kmiGraph1.ShowYTicks = true;
			this.kmiGraph1.Size = new global::System.Drawing.Size(232, 216);
			this.kmiGraph1.TabIndex = 10;
			this.kmiGraph1.Title = "Fund Performance";
			this.kmiGraph1.TitleFontSize = 18f;
			this.kmiGraph1.XAxisLabels = true;
			this.kmiGraph1.XAxisTitle = null;
			this.kmiGraph1.XLabelFormat = null;
			this.kmiGraph1.YAxisTitle = null;
			this.kmiGraph1.YLabelFormat = null;
			this.kmiGraph1.YMax = 0f;
			this.kmiGraph1.YMin = 0f;
			this.kmiGraph1.YTicks = 1;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(674, 440);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.panel7);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmResearchFunds";
			base.ShowInTaskbar = false;
			this.Text = "Research Funds";
			this.panel7.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000495 RID: 1173
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000496 RID: 1174
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000497 RID: 1175
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000498 RID: 1176
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x04000499 RID: 1177
		private global::KMI.Utility.KMIGraph kmiGraph1;

		// Token: 0x0400049A RID: 1178
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400049B RID: 1179
		private global::System.Windows.Forms.Label labFundName;

		// Token: 0x0400049C RID: 1180
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400049D RID: 1181
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400049E RID: 1182
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400049F RID: 1183
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040004A0 RID: 1184
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040004A1 RID: 1185
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040004A2 RID: 1186
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040004A3 RID: 1187
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040004A4 RID: 1188
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040004A5 RID: 1189
		private global::System.Windows.Forms.LinkLabel lnk5Year;

		// Token: 0x040004A6 RID: 1190
		private global::System.Windows.Forms.LinkLabel lnk1Year;

		// Token: 0x040004A7 RID: 1191
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x040004A8 RID: 1192
		private global::System.Windows.Forms.ListBox lstFunds;

		// Token: 0x040004A9 RID: 1193
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040004AA RID: 1194
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040004AB RID: 1195
		private global::System.Windows.Forms.ComboBox cboSector;

		// Token: 0x040004AC RID: 1196
		private global::System.Windows.Forms.Label labYTD;

		// Token: 0x040004AD RID: 1197
		private global::System.Windows.Forms.Label labPrevious;

		// Token: 0x040004AE RID: 1198
		private global::System.Windows.Forms.Label labChange;

		// Token: 0x040004AF RID: 1199
		private global::System.Windows.Forms.Label labNav;

		// Token: 0x040004B0 RID: 1200
		private global::System.Windows.Forms.Label labBack;

		// Token: 0x040004B1 RID: 1201
		private global::System.Windows.Forms.Label labFront;

		// Token: 0x040004B2 RID: 1202
		private global::System.Windows.Forms.Label lab12b1;

		// Token: 0x040004B3 RID: 1203
		private global::System.Windows.Forms.Label labTER;

		// Token: 0x040004B4 RID: 1204
		private global::System.Windows.Forms.LinkLabel lnkBuy;

		// Token: 0x040004B5 RID: 1205
		private global::System.Windows.Forms.LinkLabel lnkExport;

		// Token: 0x040004B6 RID: 1206
		private global::System.Windows.Forms.Label labYield;

		// Token: 0x040004B7 RID: 1207
		private global::System.Windows.Forms.Label label4;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040004B8 RID: 1208
		private global::System.ComponentModel.Container components = null;
	}
}
