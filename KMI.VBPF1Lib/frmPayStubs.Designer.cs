namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayStubs.
	/// </summary>
	// Token: 0x020000A6 RID: 166
	public partial class frmPayStubs : global::KMI.Sim.frmDrawnReport
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004FD RID: 1277 RVA: 0x00048284 File Offset: 0x00047284
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
		// Token: 0x060004FE RID: 1278 RVA: 0x000482C0 File Offset: 0x000472C0
		private void InitializeComponent()
		{
			this.optShow0 = new global::System.Windows.Forms.RadioButton();
			this.optShow1 = new global::System.Windows.Forms.RadioButton();
			this.cboYear = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnBack = new global::System.Windows.Forms.Button();
			this.btnNext = new global::System.Windows.Forms.Button();
			this.optShow2 = new global::System.Windows.Forms.RadioButton();
			this.pnlBottom.SuspendLayout();
			this.pnlBottom.Controls.Add(this.optShow2);
			this.pnlBottom.Controls.Add(this.btnNext);
			this.pnlBottom.Controls.Add(this.btnBack);
			this.pnlBottom.Controls.Add(this.label3);
			this.pnlBottom.Controls.Add(this.label1);
			this.pnlBottom.Controls.Add(this.cboYear);
			this.pnlBottom.Controls.Add(this.optShow0);
			this.pnlBottom.Controls.Add(this.optShow1);
			this.pnlBottom.Location = new global::System.Drawing.Point(0, 338);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new global::System.Drawing.Size(542, 88);
			this.pnlBottom.Controls.SetChildIndex(this.optShow1, 0);
			this.pnlBottom.Controls.SetChildIndex(this.optShow0, 0);
			this.pnlBottom.Controls.SetChildIndex(this.cboYear, 0);
			this.pnlBottom.Controls.SetChildIndex(this.label1, 0);
			this.pnlBottom.Controls.SetChildIndex(this.label3, 0);
			this.pnlBottom.Controls.SetChildIndex(this.btnBack, 0);
			this.pnlBottom.Controls.SetChildIndex(this.btnNext, 0);
			this.pnlBottom.Controls.SetChildIndex(this.optShow2, 0);
			this.picReport.BackColor = global::System.Drawing.Color.White;
			this.picReport.Name = "picReport";
			this.picReport.Size = new global::System.Drawing.Size(508, 308);
			this.optShow0.Checked = true;
			this.optShow0.Location = new global::System.Drawing.Point(28, 24);
			this.optShow0.Name = "optShow0";
			this.optShow0.Size = new global::System.Drawing.Size(88, 16);
			this.optShow0.TabIndex = 0;
			this.optShow0.TabStop = true;
			this.optShow0.Text = "Pay Stubs";
			this.optShow0.CheckedChanged += new global::System.EventHandler(this.optShow_CheckedChanged);
			this.optShow1.Location = new global::System.Drawing.Point(28, 44);
			this.optShow1.Name = "optShow1";
			this.optShow1.Size = new global::System.Drawing.Size(88, 16);
			this.optShow1.TabIndex = 1;
			this.optShow1.Text = "W-2s";
			this.optShow1.CheckedChanged += new global::System.EventHandler(this.optShow_CheckedChanged);
			this.cboYear.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboYear.Location = new global::System.Drawing.Point(120, 36);
			this.cboYear.Name = "cboYear";
			this.cboYear.Size = new global::System.Drawing.Size(80, 21);
			this.cboYear.TabIndex = 2;
			this.cboYear.SelectedIndexChanged += new global::System.EventHandler(this.cboYear_SelectedIndexChanged);
			this.label1.Location = new global::System.Drawing.Point(120, 20);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Year";
			this.label3.Location = new global::System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(60, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Show";
			this.btnBack.Location = new global::System.Drawing.Point(216, 32);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new global::System.Drawing.Size(64, 24);
			this.btnBack.TabIndex = 7;
			this.btnBack.Text = "<< Back";
			this.btnBack.Click += new global::System.EventHandler(this.btnBack_Click);
			this.btnNext.Location = new global::System.Drawing.Point(288, 32);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new global::System.Drawing.Size(64, 24);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = "Next >>";
			this.btnNext.Click += new global::System.EventHandler(this.btnNext_Click);
			this.optShow2.Location = new global::System.Drawing.Point(28, 64);
			this.optShow2.Name = "optShow2";
			this.optShow2.Size = new global::System.Drawing.Size(88, 16);
			this.optShow2.TabIndex = 9;
			this.optShow2.Text = "1099s";
			this.optShow2.CheckedChanged += new global::System.EventHandler(this.optShow_CheckedChanged);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(542, 426);
			base.Name = "frmPayStubs";
			this.Text = "Pay & Tax Records";
			this.pnlBottom.ResumeLayout(false);
		}

		// Token: 0x040005F4 RID: 1524
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005F5 RID: 1525
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005F6 RID: 1526
		private global::System.Windows.Forms.RadioButton optShow0;

		// Token: 0x040005F7 RID: 1527
		private global::System.Windows.Forms.RadioButton optShow1;

		// Token: 0x040005F8 RID: 1528
		private global::System.Windows.Forms.RadioButton optShow2;

		// Token: 0x040005F9 RID: 1529
		private global::System.Windows.Forms.ComboBox cboYear;

		// Token: 0x040005FA RID: 1530
		private global::System.Windows.Forms.Button btnBack;

		// Token: 0x040005FB RID: 1531
		private global::System.Windows.Forms.Button btnNext;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005FC RID: 1532
		private global::System.ComponentModel.Container components = null;
	}
}
