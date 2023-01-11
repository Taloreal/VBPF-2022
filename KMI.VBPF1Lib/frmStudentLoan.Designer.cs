namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayForCar.
	/// </summary>
	// Token: 0x0200000D RID: 13
	public partial class frmStudentLoan : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000034 RID: 52 RVA: 0x00004528 File Offset: 0x00003528
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
		// Token: 0x06000035 RID: 53 RVA: 0x00004564 File Offset: 0x00003564
		private void InitializeComponent()
		{
			this.updLoanAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.labTotalPayments = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.labPayment = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.labTerm = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.labRate = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.labPrice = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.labFirstPaymentDue = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labRemainingBalance = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cboBalanceSource = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.updLoanAmount).BeginInit();
			base.SuspendLayout();
			this.updLoanAmount.Location = new global::System.Drawing.Point(256, 52);
			this.updLoanAmount.Name = "updLoanAmount";
			this.updLoanAmount.Size = new global::System.Drawing.Size(84, 20);
			this.updLoanAmount.TabIndex = 2;
			this.updLoanAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updLoanAmount.ThousandsSeparator = true;
			this.updLoanAmount.ValueChanged += new global::System.EventHandler(this.updLoanAmount_ValueChanged);
			this.label1.Location = new global::System.Drawing.Point(36, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(168, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Amount of Loan Requested:";
			this.labTotalPayments.Location = new global::System.Drawing.Point(200, 172);
			this.labTotalPayments.Name = "labTotalPayments";
			this.labTotalPayments.Size = new global::System.Drawing.Size(140, 20);
			this.labTotalPayments.TabIndex = 9;
			this.labTotalPayments.Text = "label5";
			this.labTotalPayments.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(36, 172);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(140, 20);
			this.label6.TabIndex = 8;
			this.label6.Text = "Total Payments:";
			this.labPayment.Location = new global::System.Drawing.Point(200, 152);
			this.labPayment.Name = "labPayment";
			this.labPayment.Size = new global::System.Drawing.Size(140, 20);
			this.labPayment.TabIndex = 11;
			this.labPayment.Text = "label7";
			this.labPayment.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label8.Location = new global::System.Drawing.Point(36, 152);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(140, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "Monthly Payment:";
			this.labTerm.Location = new global::System.Drawing.Point(200, 132);
			this.labTerm.Name = "labTerm";
			this.labTerm.Size = new global::System.Drawing.Size(140, 20);
			this.labTerm.TabIndex = 13;
			this.labTerm.Text = "label9";
			this.labTerm.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label10.Location = new global::System.Drawing.Point(36, 132);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(140, 20);
			this.label10.TabIndex = 12;
			this.label10.Text = "Term (Months):";
			this.labRate.Location = new global::System.Drawing.Point(200, 92);
			this.labRate.Name = "labRate";
			this.labRate.Size = new global::System.Drawing.Size(140, 20);
			this.labRate.TabIndex = 15;
			this.labRate.Text = "label11";
			this.labRate.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label12.Location = new global::System.Drawing.Point(36, 92);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(140, 20);
			this.label12.TabIndex = 14;
			this.label12.Text = "Interest Rate:";
			this.labPrice.Location = new global::System.Drawing.Point(200, 28);
			this.labPrice.Name = "labPrice";
			this.labPrice.Size = new global::System.Drawing.Size(140, 20);
			this.labPrice.TabIndex = 17;
			this.labPrice.Text = "label13";
			this.labPrice.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label14.Location = new global::System.Drawing.Point(36, 28);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(140, 20);
			this.label14.TabIndex = 16;
			this.label14.Text = "Cost of Course:";
			this.btnOK.Location = new global::System.Drawing.Point(16, 284);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(136, 284);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(256, 284);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 22;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.labFirstPaymentDue.Location = new global::System.Drawing.Point(200, 112);
			this.labFirstPaymentDue.Name = "labFirstPaymentDue";
			this.labFirstPaymentDue.Size = new global::System.Drawing.Size(140, 20);
			this.labFirstPaymentDue.TabIndex = 24;
			this.labFirstPaymentDue.Text = "label11";
			this.labFirstPaymentDue.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label3.Location = new global::System.Drawing.Point(36, 112);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(140, 20);
			this.label3.TabIndex = 23;
			this.label3.Text = "First Payment Due:";
			this.labRemainingBalance.Location = new global::System.Drawing.Point(200, 212);
			this.labRemainingBalance.Name = "labRemainingBalance";
			this.labRemainingBalance.Size = new global::System.Drawing.Size(140, 20);
			this.labRemainingBalance.TabIndex = 26;
			this.labRemainingBalance.Text = "label5";
			this.labRemainingBalance.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label5.Location = new global::System.Drawing.Point(36, 212);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(140, 20);
			this.label5.TabIndex = 25;
			this.label5.Text = "Remaining Balance:";
			this.label7.Location = new global::System.Drawing.Point(36, 236);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(140, 20);
			this.label7.TabIndex = 28;
			this.label7.Text = "To Be Paid from:";
			this.cboBalanceSource.Location = new global::System.Drawing.Point(200, 232);
			this.cboBalanceSource.Name = "cboBalanceSource";
			this.cboBalanceSource.Size = new global::System.Drawing.Size(140, 21);
			this.cboBalanceSource.TabIndex = 27;
			this.cboBalanceSource.Text = "None";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(372, 330);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.cboBalanceSource);
			base.Controls.Add(this.labRemainingBalance);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.labFirstPaymentDue);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.labPrice);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.labRate);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.labTerm);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.labPayment);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.labTotalPayments);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.updLoanAmount);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmStudentLoan";
			base.ShowInTaskbar = false;
			this.Text = "Request Student Loan";
			((global::System.ComponentModel.ISupportInitialize)this.updLoanAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Label labTotalPayments;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Label labPayment;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Label labTerm;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Label labRate;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Label labPrice;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.NumericUpDown updLoanAmount;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.ComboBox cboBalanceSource;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.Label labFirstPaymentDue;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Label labRemainingBalance;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400009E RID: 158
		private global::System.ComponentModel.Container components = null;
	}
}
