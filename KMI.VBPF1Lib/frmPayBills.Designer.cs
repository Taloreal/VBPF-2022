namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmLicensing.
	/// </summary>
	// Token: 0x02000069 RID: 105
	public partial class frmPayBills : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002B1 RID: 689 RVA: 0x0002C09C File Offset: 0x0002B09C
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
		// Token: 0x060002B2 RID: 690 RVA: 0x0002C0D8 File Offset: 0x0002B0D8
		private void InitializeComponent()
		{
			this.btnAccept = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnBack = new global::System.Windows.Forms.Button();
			this.btnNext = new global::System.Windows.Forms.Button();
			this.picBill = new global::System.Windows.Forms.PictureBox();
			this.labNoOffers = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panBills = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.labPage = new global::System.Windows.Forms.Label();
			this.updPage = new global::System.Windows.Forms.NumericUpDown();
			this.panBills.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updPage).BeginInit();
			base.SuspendLayout();
			this.btnAccept.Location = new global::System.Drawing.Point(392, 88);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new global::System.Drawing.Size(96, 24);
			this.btnAccept.TabIndex = 0;
			this.btnAccept.Text = "Pay";
			this.btnAccept.Click += new global::System.EventHandler(this.btnAccept_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(392, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(392, 232);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnBack.Location = new global::System.Drawing.Point(120, 528);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new global::System.Drawing.Size(48, 24);
			this.btnBack.TabIndex = 4;
			this.btnBack.Text = "<<";
			this.btnBack.Click += new global::System.EventHandler(this.btnBack_Click);
			this.btnNext.Location = new global::System.Drawing.Point(184, 528);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new global::System.Drawing.Size(48, 24);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = ">>";
			this.btnNext.Click += new global::System.EventHandler(this.btnNext_Click);
			this.picBill.BackColor = global::System.Drawing.Color.White;
			this.picBill.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBill.Location = new global::System.Drawing.Point(16, 20);
			this.picBill.Name = "picBill";
			this.picBill.Size = new global::System.Drawing.Size(337, 484);
			this.picBill.TabIndex = 6;
			this.picBill.TabStop = false;
			this.picBill.Visible = false;
			this.picBill.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picBill_Paint);
			this.labNoOffers.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 21.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labNoOffers.ForeColor = global::System.Drawing.Color.Gray;
			this.labNoOffers.Location = new global::System.Drawing.Point(24, 136);
			this.labNoOffers.Name = "labNoOffers";
			this.labNoOffers.Size = new global::System.Drawing.Size(264, 120);
			this.labNoOffers.TabIndex = 7;
			this.labNoOffers.Text = "There are no more bills.";
			this.label2.BackColor = global::System.Drawing.Color.White;
			this.label2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new global::System.Drawing.Point(20, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(337, 484);
			this.label2.TabIndex = 8;
			this.label2.Visible = false;
			this.panBills.Controls.Add(this.picBill);
			this.panBills.Controls.Add(this.label2);
			this.panBills.Controls.Add(this.label3);
			this.panBills.Controls.Add(this.label4);
			this.panBills.Controls.Add(this.label5);
			this.panBills.Location = new global::System.Drawing.Point(0, 8);
			this.panBills.Name = "panBills";
			this.panBills.Size = new global::System.Drawing.Size(368, 504);
			this.panBills.TabIndex = 9;
			this.label3.BackColor = global::System.Drawing.Color.White;
			this.label3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Location = new global::System.Drawing.Point(24, 12);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(337, 484);
			this.label3.TabIndex = 9;
			this.label3.Visible = false;
			this.label4.BackColor = global::System.Drawing.Color.White;
			this.label4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Location = new global::System.Drawing.Point(28, 8);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(337, 484);
			this.label4.TabIndex = 10;
			this.label4.Visible = false;
			this.label5.BackColor = global::System.Drawing.Color.White;
			this.label5.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new global::System.Drawing.Point(32, 4);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(337, 484);
			this.label5.TabIndex = 11;
			this.label5.Visible = false;
			this.labPage.Location = new global::System.Drawing.Point(392, 24);
			this.labPage.Name = "labPage";
			this.labPage.Size = new global::System.Drawing.Size(40, 16);
			this.labPage.TabIndex = 10;
			this.labPage.Text = "Page:";
			this.updPage.Location = new global::System.Drawing.Point(392, 40);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updPage;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Minimum = new decimal(array);
			this.updPage.Name = "updPage";
			this.updPage.Size = new global::System.Drawing.Size(40, 20);
			this.updPage.TabIndex = 11;
			this.updPage.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updPage;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Value = new decimal(array);
			this.updPage.ValueChanged += new global::System.EventHandler(this.updPage_ValueChanged);
			base.AcceptButton = this.btnAccept;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(514, 560);
			base.Controls.Add(this.updPage);
			base.Controls.Add(this.labPage);
			base.Controls.Add(this.panBills);
			base.Controls.Add(this.btnNext);
			base.Controls.Add(this.btnBack);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnAccept);
			base.Controls.Add(this.labNoOffers);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPayBills";
			base.ShowInTaskbar = false;
			this.Text = "Pay Bills";
			this.panBills.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updPage).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000336 RID: 822
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000337 RID: 823
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000338 RID: 824
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000339 RID: 825
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400033A RID: 826
		private global::System.Windows.Forms.PictureBox picBill;

		// Token: 0x0400033B RID: 827
		private global::System.Windows.Forms.Panel panBills;

		// Token: 0x0400033C RID: 828
		private global::System.Windows.Forms.Button btnBack;

		// Token: 0x0400033D RID: 829
		private global::System.Windows.Forms.Button btnNext;

		// Token: 0x0400033E RID: 830
		private global::System.Windows.Forms.Label labNoOffers;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.Button btnAccept;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000342 RID: 834
		private global::System.Windows.Forms.Label labPage;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.NumericUpDown updPage;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000344 RID: 836
		private global::System.ComponentModel.Container components = null;
	}
}
