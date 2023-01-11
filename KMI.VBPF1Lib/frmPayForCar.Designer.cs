namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayForCar.
	/// </summary>
	// Token: 0x0200001A RID: 26
	public partial class frmPayForCar : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000094 RID: 148 RVA: 0x0000A4BC File Offset: 0x000094BC
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
		// Token: 0x06000095 RID: 149 RVA: 0x0000A4F8 File Offset: 0x000094F8
		private void InitializeComponent()
		{
			this.radBuy = new global::System.Windows.Forms.RadioButton();
			this.radLease = new global::System.Windows.Forms.RadioButton();
			this.updDownPayment = new global::System.Windows.Forms.NumericUpDown();
			this.cboDownPaymentSource = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labFinanced = new global::System.Windows.Forms.Label();
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
			this.labLeasePayment = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.labNoBuy = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updDownPayment).BeginInit();
			base.SuspendLayout();
			this.radBuy.Location = new global::System.Drawing.Point(32, 24);
			this.radBuy.Name = "radBuy";
			this.radBuy.Size = new global::System.Drawing.Size(196, 24);
			this.radBuy.TabIndex = 0;
			this.radBuy.Text = "Buy Car";
			this.radBuy.CheckedChanged += new global::System.EventHandler(this.radBuy_CheckedChanged);
			this.radLease.Location = new global::System.Drawing.Point(32, 256);
			this.radLease.Name = "radLease";
			this.radLease.Size = new global::System.Drawing.Size(168, 24);
			this.radLease.TabIndex = 1;
			this.radLease.Text = "Lease Car";
			this.radLease.CheckedChanged += new global::System.EventHandler(this.radBuy_CheckedChanged);
			this.updDownPayment.Enabled = false;
			this.updDownPayment.Location = new global::System.Drawing.Point(288, 76);
			this.updDownPayment.Name = "updDownPayment";
			this.updDownPayment.Size = new global::System.Drawing.Size(84, 20);
			this.updDownPayment.TabIndex = 2;
			this.updDownPayment.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updDownPayment.ThousandsSeparator = true;
			this.updDownPayment.ValueChanged += new global::System.EventHandler(this.updDownPayment_ValueChanged);
			this.cboDownPaymentSource.Enabled = false;
			this.cboDownPaymentSource.Location = new global::System.Drawing.Point(232, 104);
			this.cboDownPaymentSource.Name = "cboDownPaymentSource";
			this.cboDownPaymentSource.Size = new global::System.Drawing.Size(140, 21);
			this.cboDownPaymentSource.TabIndex = 3;
			this.cboDownPaymentSource.Text = "comboBox1";
			this.label1.Location = new global::System.Drawing.Point(68, 80);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(140, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Down Payment Amount:";
			this.label2.Location = new global::System.Drawing.Point(68, 136);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(140, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Amount Financed:";
			this.label3.Location = new global::System.Drawing.Point(68, 108);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(140, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Down Payment Source:";
			this.labFinanced.Location = new global::System.Drawing.Point(232, 136);
			this.labFinanced.Name = "labFinanced";
			this.labFinanced.Size = new global::System.Drawing.Size(140, 20);
			this.labFinanced.TabIndex = 7;
			this.labFinanced.Text = "label4";
			this.labFinanced.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labTotalPayments.Location = new global::System.Drawing.Point(232, 216);
			this.labTotalPayments.Name = "labTotalPayments";
			this.labTotalPayments.Size = new global::System.Drawing.Size(140, 20);
			this.labTotalPayments.TabIndex = 9;
			this.labTotalPayments.Text = "label5";
			this.labTotalPayments.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(68, 216);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(140, 20);
			this.label6.TabIndex = 8;
			this.label6.Text = "Total Payments:";
			this.labPayment.Location = new global::System.Drawing.Point(232, 196);
			this.labPayment.Name = "labPayment";
			this.labPayment.Size = new global::System.Drawing.Size(140, 20);
			this.labPayment.TabIndex = 11;
			this.labPayment.Text = "label7";
			this.labPayment.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label8.Location = new global::System.Drawing.Point(68, 196);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(140, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "Monthly Payment:";
			this.labTerm.Location = new global::System.Drawing.Point(232, 176);
			this.labTerm.Name = "labTerm";
			this.labTerm.Size = new global::System.Drawing.Size(140, 20);
			this.labTerm.TabIndex = 13;
			this.labTerm.Text = "label9";
			this.labTerm.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label10.Location = new global::System.Drawing.Point(68, 176);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(140, 20);
			this.label10.TabIndex = 12;
			this.label10.Text = "Term (Months):";
			this.labRate.Location = new global::System.Drawing.Point(232, 156);
			this.labRate.Name = "labRate";
			this.labRate.Size = new global::System.Drawing.Size(140, 20);
			this.labRate.TabIndex = 15;
			this.labRate.Text = "label11";
			this.labRate.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label12.Location = new global::System.Drawing.Point(68, 156);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(140, 20);
			this.label12.TabIndex = 14;
			this.label12.Text = "Interest Rate:";
			this.labPrice.Location = new global::System.Drawing.Point(232, 52);
			this.labPrice.Name = "labPrice";
			this.labPrice.Size = new global::System.Drawing.Size(140, 20);
			this.labPrice.TabIndex = 17;
			this.labPrice.Text = "label13";
			this.labPrice.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label14.Location = new global::System.Drawing.Point(68, 52);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(140, 20);
			this.label14.TabIndex = 16;
			this.label14.Text = "Sale Price:";
			this.labLeasePayment.Location = new global::System.Drawing.Point(232, 288);
			this.labLeasePayment.Name = "labLeasePayment";
			this.labLeasePayment.Size = new global::System.Drawing.Size(140, 20);
			this.labLeasePayment.TabIndex = 19;
			this.labLeasePayment.Text = "label15";
			this.labLeasePayment.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label16.Location = new global::System.Drawing.Point(68, 288);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(140, 20);
			this.label16.TabIndex = 18;
			this.label16.Text = "Monthly Lease Payment:";
			this.btnOK.Enabled = false;
			this.btnOK.Location = new global::System.Drawing.Point(40, 364);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(160, 364);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(280, 364);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 22;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.labNoBuy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labNoBuy.ForeColor = global::System.Drawing.SystemColors.ControlDark;
			this.labNoBuy.Location = new global::System.Drawing.Point(56, 48);
			this.labNoBuy.Name = "labNoBuy";
			this.labNoBuy.Size = new global::System.Drawing.Size(332, 192);
			this.labNoBuy.TabIndex = 23;
			this.labNoBuy.Text = "Option unavailable. No checking account for down payment bank check.";
			this.labNoBuy.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labNoBuy.Visible = false;
			this.label4.Location = new global::System.Drawing.Point(68, 308);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(140, 20);
			this.label4.TabIndex = 24;
			this.label4.Text = "Length of  Lease";
			this.label5.Location = new global::System.Drawing.Point(68, 328);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(172, 20);
			this.label5.TabIndex = 25;
			this.label5.Text = "Penalty for Early Termination";
			this.label7.Location = new global::System.Drawing.Point(232, 308);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(140, 20);
			this.label7.TabIndex = 26;
			this.label7.Text = "2 Years";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label9.Location = new global::System.Drawing.Point(232, 328);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(140, 20);
			this.label9.TabIndex = 27;
			this.label9.Text = "3 Month's Payments";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(420, 402);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.labLeasePayment);
			base.Controls.Add(this.label16);
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
			base.Controls.Add(this.labFinanced);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.cboDownPaymentSource);
			base.Controls.Add(this.radBuy);
			base.Controls.Add(this.radLease);
			base.Controls.Add(this.updDownPayment);
			base.Controls.Add(this.labNoBuy);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPayForCar";
			base.ShowInTaskbar = false;
			this.Text = "Pay For Car";
			((global::System.ComponentModel.ISupportInitialize)this.updDownPayment).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.NumericUpDown updDownPayment;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.ComboBox cboDownPaymentSource;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.Label labFinanced;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Label labTotalPayments;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Label labPayment;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Label labTerm;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Label labRate;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.Label labPrice;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.RadioButton radLease;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.Label labLeasePayment;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.RadioButton radBuy;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Label labNoBuy;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Label label9;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000103 RID: 259
		private global::System.ComponentModel.Container components = null;
	}
}
