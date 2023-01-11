namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayForCar.
	/// </summary>
	// Token: 0x0200006D RID: 109
	public partial class frmMortgage : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002DE RID: 734 RVA: 0x00030F64 File Offset: 0x0002FF64
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
		// Token: 0x060002DF RID: 735 RVA: 0x00030FA0 File Offset: 0x0002FFA0
		private void InitializeComponent()
		{
			this.updDownPayment = new global::System.Windows.Forms.NumericUpDown();
			this.cboDownPaymentSource = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labFinanced = new global::System.Windows.Forms.Label();
			this.labTotalPayments = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.labPMI = new global::System.Windows.Forms.Label();
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
			this.label4 = new global::System.Windows.Forms.Label();
			this.cboType = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.labPayment = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.labPandI = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cboPoints = new global::System.Windows.Forms.ComboBox();
			this.labClosingCosts = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.labCashAtClosing = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updDownPayment).BeginInit();
			base.SuspendLayout();
			this.updDownPayment.Location = new global::System.Drawing.Point(256, 48);
			this.updDownPayment.Name = "updDownPayment";
			this.updDownPayment.Size = new global::System.Drawing.Size(84, 20);
			this.updDownPayment.TabIndex = 2;
			this.updDownPayment.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updDownPayment.ThousandsSeparator = true;
			this.updDownPayment.ValueChanged += new global::System.EventHandler(this.UpdateAll);
			this.cboDownPaymentSource.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDownPaymentSource.Location = new global::System.Drawing.Point(200, 76);
			this.cboDownPaymentSource.Name = "cboDownPaymentSource";
			this.cboDownPaymentSource.Size = new global::System.Drawing.Size(140, 21);
			this.cboDownPaymentSource.TabIndex = 3;
			this.label1.Location = new global::System.Drawing.Point(36, 52);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(140, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Down Payment Amount:";
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(36, 172);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(140, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Amount of Mortgage:";
			this.label3.Location = new global::System.Drawing.Point(36, 76);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(140, 28);
			this.label3.TabIndex = 6;
			this.label3.Text = "Source of Cash Required at Closing:";
			this.labFinanced.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labFinanced.Location = new global::System.Drawing.Point(200, 172);
			this.labFinanced.Name = "labFinanced";
			this.labFinanced.Size = new global::System.Drawing.Size(140, 20);
			this.labFinanced.TabIndex = 7;
			this.labFinanced.Text = "label4";
			this.labFinanced.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labTotalPayments.Location = new global::System.Drawing.Point(244, 292);
			this.labTotalPayments.Name = "labTotalPayments";
			this.labTotalPayments.Size = new global::System.Drawing.Size(96, 20);
			this.labTotalPayments.TabIndex = 9;
			this.labTotalPayments.Text = "label5";
			this.labTotalPayments.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(36, 292);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(204, 20);
			this.label6.TabIndex = 8;
			this.label6.Text = "Total Payments over Life of Mortgage:";
			this.labPMI.Location = new global::System.Drawing.Point(200, 252);
			this.labPMI.Name = "labPMI";
			this.labPMI.Size = new global::System.Drawing.Size(140, 20);
			this.labPMI.TabIndex = 11;
			this.labPMI.Text = "label7";
			this.labPMI.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label8.Location = new global::System.Drawing.Point(36, 252);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(140, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "Monthly PMI Payment:";
			this.labTerm.Location = new global::System.Drawing.Point(200, 212);
			this.labTerm.Name = "labTerm";
			this.labTerm.Size = new global::System.Drawing.Size(140, 20);
			this.labTerm.TabIndex = 13;
			this.labTerm.Text = "label9";
			this.labTerm.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label10.Location = new global::System.Drawing.Point(36, 212);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(140, 20);
			this.label10.TabIndex = 12;
			this.label10.Text = "Term (Years):";
			this.labRate.Location = new global::System.Drawing.Point(200, 192);
			this.labRate.Name = "labRate";
			this.labRate.Size = new global::System.Drawing.Size(140, 20);
			this.labRate.TabIndex = 15;
			this.labRate.Text = "label11";
			this.labRate.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label12.Location = new global::System.Drawing.Point(36, 192);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(140, 20);
			this.label12.TabIndex = 14;
			this.label12.Text = "Interest Rate:";
			this.labPrice.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPrice.Location = new global::System.Drawing.Point(200, 24);
			this.labPrice.Name = "labPrice";
			this.labPrice.Size = new global::System.Drawing.Size(140, 20);
			this.labPrice.TabIndex = 17;
			this.labPrice.Text = "label13";
			this.labPrice.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label14.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new global::System.Drawing.Point(36, 24);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(140, 20);
			this.label14.TabIndex = 16;
			this.label14.Text = "Sale Price:";
			this.btnOK.Location = new global::System.Drawing.Point(24, 372);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(144, 372);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(264, 372);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 22;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label4.Location = new global::System.Drawing.Point(36, 136);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(140, 20);
			this.label4.TabIndex = 25;
			this.label4.Text = "Type of Mortgage:";
			this.cboType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboType.Location = new global::System.Drawing.Point(200, 132);
			this.cboType.Name = "cboType";
			this.cboType.Size = new global::System.Drawing.Size(140, 21);
			this.cboType.TabIndex = 24;
			this.cboType.SelectedIndexChanged += new global::System.EventHandler(this.UpdateAll);
			this.label5.Location = new global::System.Drawing.Point(36, 108);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(140, 20);
			this.label5.TabIndex = 27;
			this.label5.Text = "Points:";
			this.labPayment.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPayment.Location = new global::System.Drawing.Point(200, 272);
			this.labPayment.Name = "labPayment";
			this.labPayment.Size = new global::System.Drawing.Size(140, 20);
			this.labPayment.TabIndex = 29;
			this.labPayment.Text = "label5";
			this.labPayment.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(36, 272);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(140, 20);
			this.label9.TabIndex = 28;
			this.label9.Text = "Total Monthly Payment:";
			this.labPandI.Location = new global::System.Drawing.Point(236, 232);
			this.labPandI.Name = "labPandI";
			this.labPandI.Size = new global::System.Drawing.Size(104, 20);
			this.labPandI.TabIndex = 31;
			this.labPandI.Text = "label7";
			this.labPandI.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label13.Location = new global::System.Drawing.Point(36, 232);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(208, 20);
			this.label13.TabIndex = 30;
			this.label13.Text = "Monthly Principle && Interest Payment:";
			this.cboPoints.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPoints.Items.AddRange(new object[]
			{
				"0",
				"0.5",
				"1",
				"1.5",
				"2"
			});
			this.cboPoints.Location = new global::System.Drawing.Point(256, 104);
			this.cboPoints.Name = "cboPoints";
			this.cboPoints.Size = new global::System.Drawing.Size(84, 21);
			this.cboPoints.TabIndex = 32;
			this.cboPoints.SelectedIndexChanged += new global::System.EventHandler(this.UpdateAll);
			this.labClosingCosts.Location = new global::System.Drawing.Point(244, 312);
			this.labClosingCosts.Name = "labClosingCosts";
			this.labClosingCosts.Size = new global::System.Drawing.Size(96, 20);
			this.labClosingCosts.TabIndex = 34;
			this.labClosingCosts.Text = "label5";
			this.labClosingCosts.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label16.Location = new global::System.Drawing.Point(36, 312);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(204, 20);
			this.label16.TabIndex = 33;
			this.label16.Text = "Closing Costs:";
			this.labCashAtClosing.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labCashAtClosing.Location = new global::System.Drawing.Point(244, 332);
			this.labCashAtClosing.Name = "labCashAtClosing";
			this.labCashAtClosing.Size = new global::System.Drawing.Size(96, 20);
			this.labCashAtClosing.TabIndex = 36;
			this.labCashAtClosing.Text = "label5";
			this.labCashAtClosing.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label18.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.Location = new global::System.Drawing.Point(36, 332);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(204, 20);
			this.label18.TabIndex = 35;
			this.label18.Text = "Cash Required at Closing:";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(392, 410);
			base.Controls.Add(this.labCashAtClosing);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.labClosingCosts);
			base.Controls.Add(this.label16);
			base.Controls.Add(this.cboPoints);
			base.Controls.Add(this.labPandI);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.labPayment);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.cboType);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.labPrice);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.labRate);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.labTerm);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.labPMI);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.labTotalPayments);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.labFinanced);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.cboDownPaymentSource);
			base.Controls.Add(this.updDownPayment);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmMortgage";
			base.ShowInTaskbar = false;
			this.Text = "Pay for Condo";
			base.Load += new global::System.EventHandler(this.frmMortgage_Load);
			((global::System.ComponentModel.ISupportInitialize)this.updDownPayment).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000399 RID: 921
		private global::System.Windows.Forms.NumericUpDown updDownPayment;

		// Token: 0x0400039A RID: 922
		private global::System.Windows.Forms.ComboBox cboDownPaymentSource;

		// Token: 0x0400039B RID: 923
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400039C RID: 924
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400039D RID: 925
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400039E RID: 926
		private global::System.Windows.Forms.Label labFinanced;

		// Token: 0x0400039F RID: 927
		private global::System.Windows.Forms.Label labTotalPayments;

		// Token: 0x040003A0 RID: 928
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040003A1 RID: 929
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040003A2 RID: 930
		private global::System.Windows.Forms.Label labTerm;

		// Token: 0x040003A3 RID: 931
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040003A4 RID: 932
		private global::System.Windows.Forms.Label labRate;

		// Token: 0x040003A5 RID: 933
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040003A6 RID: 934
		private global::System.Windows.Forms.Label labPrice;

		// Token: 0x040003A7 RID: 935
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040003A8 RID: 936
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040003A9 RID: 937
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040003AA RID: 938
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040003AB RID: 939
		private global::System.Windows.Forms.Label labPMI;

		// Token: 0x040003AC RID: 940
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040003AD RID: 941
		private global::System.Windows.Forms.ComboBox cboType;

		// Token: 0x040003AE RID: 942
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040003AF RID: 943
		private global::System.Windows.Forms.Label labPayment;

		// Token: 0x040003B0 RID: 944
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040003B1 RID: 945
		private global::System.Windows.Forms.Label labPandI;

		// Token: 0x040003B2 RID: 946
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040003B3 RID: 947
		private global::System.Windows.Forms.ComboBox cboPoints;

		// Token: 0x040003B4 RID: 948
		private global::System.Windows.Forms.Label labClosingCosts;

		// Token: 0x040003B5 RID: 949
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040003B6 RID: 950
		private global::System.Windows.Forms.Label labCashAtClosing;

		// Token: 0x040003B7 RID: 951
		private global::System.Windows.Forms.Label label18;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040003B8 RID: 952
		private global::System.ComponentModel.Container components = null;
	}
}
