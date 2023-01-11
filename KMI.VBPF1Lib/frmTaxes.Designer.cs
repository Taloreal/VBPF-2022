namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmTaxes.
	/// </summary>
	// Token: 0x02000066 RID: 102
	public partial class frmTaxes : global::System.Windows.Forms.Form, global::KMI.Sim.IConstrainedForm
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000297 RID: 663 RVA: 0x00029AB8 File Offset: 0x00028AB8
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
		// Token: 0x06000298 RID: 664 RVA: 0x00029AF4 File Offset: 0x00028AF4
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panMain = new global::System.Windows.Forms.Panel();
			this.l1 = new global::System.Windows.Forms.Label();
			this.ss2 = new global::System.Windows.Forms.Label();
			this.ss1 = new global::System.Windows.Forms.Label();
			this.TaxTable = new global::System.Windows.Forms.LinkLabel();
			this.l5 = new global::System.Windows.Forms.Label();
			this.l4 = new global::System.Windows.Forms.Label();
			this.t8 = new global::System.Windows.Forms.TextBox();
			this.t7 = new global::System.Windows.Forms.TextBox();
			this.t6 = new global::System.Windows.Forms.TextBox();
			this.t5 = new global::System.Windows.Forms.TextBox();
			this.t3 = new global::System.Windows.Forms.TextBox();
			this.t4 = new global::System.Windows.Forms.TextBox();
			this.t2 = new global::System.Windows.Forms.TextBox();
			this.l3 = new global::System.Windows.Forms.Label();
			this.l2 = new global::System.Windows.Forms.Label();
			this.l0 = new global::System.Windows.Forms.Label();
			this.Year = new global::System.Windows.Forms.Label();
			this.t1 = new global::System.Windows.Forms.TextBox();
			this.t0 = new global::System.Windows.Forms.TextBox();
			this.panReport = new global::System.Windows.Forms.Panel();
			this.btnFile = new global::System.Windows.Forms.Button();
			this.cboOldReturns = new global::System.Windows.Forms.ComboBox();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.TaxYear = new global::System.Windows.Forms.Label();
			this.Instructions = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panMain.SuspendLayout();
			base.SuspendLayout();
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = global::System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.panMain);
			this.panel1.Controls.Add(this.panReport);
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(592, 416);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panMain.Controls.Add(this.l1);
			this.panMain.Controls.Add(this.ss2);
			this.panMain.Controls.Add(this.ss1);
			this.panMain.Controls.Add(this.TaxTable);
			this.panMain.Controls.Add(this.l5);
			this.panMain.Controls.Add(this.l4);
			this.panMain.Controls.Add(this.t8);
			this.panMain.Controls.Add(this.t7);
			this.panMain.Controls.Add(this.t6);
			this.panMain.Controls.Add(this.t5);
			this.panMain.Controls.Add(this.t3);
			this.panMain.Controls.Add(this.t4);
			this.panMain.Controls.Add(this.t2);
			this.panMain.Controls.Add(this.l3);
			this.panMain.Controls.Add(this.l2);
			this.panMain.Controls.Add(this.l0);
			this.panMain.Controls.Add(this.Year);
			this.panMain.Controls.Add(this.t1);
			this.panMain.Controls.Add(this.t0);
			this.panMain.Location = new global::System.Drawing.Point(0, 0);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(568, 669);
			this.panMain.TabIndex = 0;
			this.l1.Location = new global::System.Drawing.Point(504, 53);
			this.l1.Name = "l1";
			this.l1.Size = new global::System.Drawing.Size(32, 12);
			this.l1.TabIndex = 24;
			this.l1.Text = "9999";
			this.ss2.Location = new global::System.Drawing.Point(480, 53);
			this.ss2.Name = "ss2";
			this.ss2.Size = new global::System.Drawing.Size(24, 12);
			this.ss2.TabIndex = 23;
			this.ss2.Text = "XX";
			this.ss1.Location = new global::System.Drawing.Point(448, 53);
			this.ss1.Name = "ss1";
			this.ss1.Size = new global::System.Drawing.Size(24, 12);
			this.ss1.TabIndex = 22;
			this.ss1.Text = "XXX";
			this.TaxTable.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.TaxTable.Location = new global::System.Drawing.Point(408, 448);
			this.TaxTable.Name = "TaxTable";
			this.TaxTable.Size = new global::System.Drawing.Size(48, 14);
			this.TaxTable.TabIndex = 21;
			this.TaxTable.TabStop = true;
			this.TaxTable.Text = "TaxTable";
			this.TaxTable.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTaxTable_LinkClicked);
			this.l5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l5.Location = new global::System.Drawing.Point(270, 630);
			this.l5.Name = "l5";
			this.l5.Size = new global::System.Drawing.Size(50, 13);
			this.l5.TabIndex = 19;
			this.l5.Text = "label5";
			this.l4.Font = new global::System.Drawing.Font("Monotype Corsiva", 9f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.l4.Location = new global::System.Drawing.Point(88, 630);
			this.l4.Name = "l4";
			this.l4.Size = new global::System.Drawing.Size(176, 13);
			this.l4.TabIndex = 18;
			this.l4.Text = "label4";
			this.t8.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t8.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t8.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t8.Location = new global::System.Drawing.Point(456, 546);
			this.t8.Name = "t8";
			this.t8.Size = new global::System.Drawing.Size(72, 11);
			this.t8.TabIndex = 17;
			this.t8.Text = "";
			this.t8.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t7.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t7.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t7.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t7.Location = new global::System.Drawing.Point(456, 473);
			this.t7.Name = "t7";
			this.t7.Size = new global::System.Drawing.Size(72, 11);
			this.t7.TabIndex = 16;
			this.t7.Text = "";
			this.t7.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t6.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t6.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t6.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t6.Location = new global::System.Drawing.Point(456, 448);
			this.t6.Name = "t6";
			this.t6.Size = new global::System.Drawing.Size(72, 11);
			this.t6.TabIndex = 15;
			this.t6.Text = "";
			this.t6.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t5.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t5.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t5.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t5.Location = new global::System.Drawing.Point(456, 354);
			this.t5.Name = "t5";
			this.t5.Size = new global::System.Drawing.Size(72, 11);
			this.t5.TabIndex = 14;
			this.t5.Text = "";
			this.t5.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t3.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t3.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t3.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t3.Location = new global::System.Drawing.Point(456, 316);
			this.t3.Name = "t3";
			this.t3.Size = new global::System.Drawing.Size(72, 11);
			this.t3.TabIndex = 13;
			this.t3.Text = "";
			this.t3.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t3.TextChanged += new global::System.EventHandler(this.textBox3_TextChanged);
			this.t4.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t4.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t4.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t4.Location = new global::System.Drawing.Point(456, 338);
			this.t4.Name = "t4";
			this.t4.Size = new global::System.Drawing.Size(72, 11);
			this.t4.TabIndex = 12;
			this.t4.Text = "";
			this.t4.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t2.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t2.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t2.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t2.Location = new global::System.Drawing.Point(456, 256);
			this.t2.Name = "t2";
			this.t2.Size = new global::System.Drawing.Size(72, 11);
			this.t2.TabIndex = 11;
			this.t2.Text = "";
			this.t2.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.l3.Location = new global::System.Drawing.Point(112, 135);
			this.l3.Name = "l3";
			this.l3.Size = new global::System.Drawing.Size(224, 13);
			this.l3.TabIndex = 10;
			this.l3.Text = "label3";
			this.l2.Location = new global::System.Drawing.Point(112, 102);
			this.l2.Name = "l2";
			this.l2.Size = new global::System.Drawing.Size(224, 13);
			this.l2.TabIndex = 9;
			this.l2.Text = "label2";
			this.l0.Location = new global::System.Drawing.Point(248, 53);
			this.l0.Name = "l0";
			this.l0.Size = new global::System.Drawing.Size(176, 13);
			this.l0.TabIndex = 8;
			this.l0.Text = "label1";
			this.Year.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Year.Location = new global::System.Drawing.Point(304, 16);
			this.Year.Name = "Year";
			this.Year.Size = new global::System.Drawing.Size(88, 24);
			this.Year.TabIndex = 7;
			this.Year.Text = "2008";
			this.t1.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t1.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t1.Location = new global::System.Drawing.Point(456, 208);
			this.t1.Name = "t1";
			this.t1.Size = new global::System.Drawing.Size(72, 11);
			this.t1.TabIndex = 4;
			this.t1.Text = "";
			this.t1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.t0.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.t0.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.t0.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.t0.Location = new global::System.Drawing.Point(456, 184);
			this.t0.Name = "t0";
			this.t0.Size = new global::System.Drawing.Size(72, 11);
			this.t0.TabIndex = 3;
			this.t0.Text = "";
			this.t0.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.panReport.Location = new global::System.Drawing.Point(24, 8);
			this.panReport.Name = "panReport";
			this.panReport.Size = new global::System.Drawing.Size(508, 400);
			this.panReport.TabIndex = 8;
			this.panReport.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panReport_Paint);
			this.btnFile.Location = new global::System.Drawing.Point(200, 432);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new global::System.Drawing.Size(128, 32);
			this.btnFile.TabIndex = 1;
			this.btnFile.Text = "File Tax Return";
			this.btnFile.Click += new global::System.EventHandler(this.btnFile_Click);
			this.cboOldReturns.Location = new global::System.Drawing.Point(56, 440);
			this.cboOldReturns.Name = "cboOldReturns";
			this.cboOldReturns.Size = new global::System.Drawing.Size(112, 21);
			this.cboOldReturns.TabIndex = 4;
			this.cboOldReturns.SelectedIndexChanged += new global::System.EventHandler(this.cboOldReturns_SelectedIndexChanged);
			this.btnClose.Location = new global::System.Drawing.Point(432, 440);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(64, 24);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.button1_Click);
			this.TaxYear.Location = new global::System.Drawing.Point(56, 424);
			this.TaxYear.Name = "TaxYear";
			this.TaxYear.Size = new global::System.Drawing.Size(56, 16);
			this.TaxYear.TabIndex = 6;
			this.TaxYear.Text = "Tax Year:";
			this.Instructions.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Instructions.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.Instructions.Location = new global::System.Drawing.Point(16, 424);
			this.Instructions.Name = "Instructions";
			this.Instructions.Size = new global::System.Drawing.Size(168, 40);
			this.Instructions.TabIndex = 7;
			this.Instructions.Text = "Instructions: Fill in the shaded boxes using information from your W2 forms and 1099-Int forms.";
			this.Instructions.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnHelp.Location = new global::System.Drawing.Point(512, 440);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(64, 24);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnPrint.Location = new global::System.Drawing.Point(352, 440);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(64, 24);
			this.btnPrint.TabIndex = 9;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(592, 478);
			base.Controls.Add(this.btnPrint);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.Instructions);
			base.Controls.Add(this.TaxYear);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.cboOldReturns);
			base.Controls.Add(this.btnFile);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTaxes";
			base.ShowInTaskbar = false;
			this.Text = "Taxes";
			this.panel1.ResumeLayout(false);
			this.panMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.Button btnFile;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.Panel panMain;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.Label Year;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.ComboBox cboOldReturns;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400030C RID: 780
		private global::System.ComponentModel.Container components = null;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.TextBox t1;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.TextBox t0;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.TextBox t2;

		// Token: 0x04000311 RID: 785
		private global::System.Windows.Forms.TextBox t4;

		// Token: 0x04000312 RID: 786
		private global::System.Windows.Forms.TextBox t3;

		// Token: 0x04000313 RID: 787
		private global::System.Windows.Forms.TextBox t5;

		// Token: 0x04000314 RID: 788
		private global::System.Windows.Forms.TextBox t6;

		// Token: 0x04000315 RID: 789
		private global::System.Windows.Forms.TextBox t7;

		// Token: 0x04000316 RID: 790
		private global::System.Windows.Forms.TextBox t8;

		// Token: 0x04000317 RID: 791
		private global::System.Windows.Forms.Label l0;

		// Token: 0x04000318 RID: 792
		private global::System.Windows.Forms.Label l2;

		// Token: 0x04000319 RID: 793
		private global::System.Windows.Forms.Label l3;

		// Token: 0x0400031A RID: 794
		private global::System.Windows.Forms.Label l4;

		// Token: 0x0400031B RID: 795
		private global::System.Windows.Forms.Label l5;

		// Token: 0x0400031C RID: 796
		private global::System.Windows.Forms.Label l1;

		// Token: 0x0400031D RID: 797
		private global::System.Windows.Forms.Label TaxYear;

		// Token: 0x0400031E RID: 798
		private global::System.Windows.Forms.LinkLabel TaxTable;

		// Token: 0x0400031F RID: 799
		private global::System.Windows.Forms.Label ss2;

		// Token: 0x04000320 RID: 800
		private global::System.Windows.Forms.Label ss1;

		// Token: 0x04000321 RID: 801
		private global::System.Windows.Forms.Label Instructions;

		// Token: 0x04000322 RID: 802
		private global::System.Windows.Forms.Panel panReport;

		// Token: 0x04000323 RID: 803
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000324 RID: 804
		private global::System.Windows.Forms.Button btnPrint;
	}
}
