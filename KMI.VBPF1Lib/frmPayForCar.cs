using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayForCar.
	/// </summary>
	// Token: 0x0200001A RID: 26
	public partial class frmPayForCar : Form
	{
		// Token: 0x06000093 RID: 147 RVA: 0x0000A1A8 File Offset: 0x000091A8
		public frmPayForCar(Bill bill, ArrayList itemNames)
		{
			this.InitializeComponent();
			this.bill = bill;
			this.itemNames = itemNames;
			this.loan = A.SA.GetPayForCar(A.MF.CurrentEntityID, bill.Amount);
			SortedList accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			this.labPrice.Text = Utilities.FC(bill.Amount, A.I.CurrencyConversion);
			this.updDownPayment.Maximum = (decimal)bill.Amount;
			this.updDownPayment.Value = (decimal)(0.1f * bill.Amount);
			this.updDownPayment.Minimum = this.updDownPayment.Value;
			if (this.loan.InterestRate == 0f)
			{
				MessageBox.Show(A.R.GetString("Your credit score was too low. You cannot get a loan. You can only purchase now by paying the full amount as your down payment. Otherwise, try raising your credit score above {0}.", new object[]
				{
					510
				}), "Credit Denied");
				this.updDownPayment.Value = (decimal)bill.Amount;
				this.updDownPayment.Minimum = (decimal)bill.Amount;
			}
			this.updDownPayment.Increment = 500m;
			this.labRate.Text = Utilities.FP(this.loan.InterestRate);
			this.labTerm.Text = this.loan.Term.ToString();
			this.leaseCost = this.loan.Payment * 0.8f;
			if (this.loan.InterestRate == 0f)
			{
				InstallmentLoan temp = new InstallmentLoan(DateTime.MinValue, bill.Amount, 0.07f, 36);
				this.leaseCost = temp.Payment * 0.8f;
			}
			this.labLeasePayment.Text = Utilities.FC(this.leaseCost, A.I.CurrencyConversion);
			foreach (object obj in accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (account is CheckingAccount)
				{
					this.cboDownPaymentSource.Items.Add(account);
				}
			}
			if (this.cboDownPaymentSource.Items.Count == 0)
			{
				this.labNoBuy.Visible = true;
				this.labNoBuy.BringToFront();
				this.radBuy.Enabled = false;
				this.radLease.Checked = true;
			}
			else
			{
				this.cboDownPaymentSource.SelectedIndex = 0;
				this.radBuy.Checked = true;
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000B4A4 File Offset: 0x0000A4A4
		private void updDownPayment_ValueChanged(object sender, EventArgs e)
		{
			this.loan.OriginalBalance = this.bill.Amount - (float)this.updDownPayment.Value;
			this.loan.ReComputePayment();
			this.labFinanced.Text = Utilities.FC(this.bill.Amount - (float)this.updDownPayment.Value, A.I.CurrencyConversion);
			this.labPayment.Text = Utilities.FC(this.loan.Payment, A.I.CurrencyConversion);
			this.labTotalPayments.Text = Utilities.FC(this.loan.Payment * (float)this.loan.Term + (float)this.updDownPayment.Value, A.I.CurrencyConversion);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000B58A File Offset: 0x0000A58A
		private void radBuy_CheckedChanged(object sender, EventArgs e)
		{
			this.updDownPayment.Enabled = this.radBuy.Checked;
			this.cboDownPaymentSource.Enabled = this.radBuy.Checked;
			this.btnOK.Enabled = true;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000B5C8 File Offset: 0x0000A5C8
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				string carName = (string)this.itemNames[0];
				if (this.radLease.Checked)
				{
					A.SA.LeaseCar(A.MF.CurrentEntityID, this.leaseCost, carName);
				}
				else
				{
					A.SA.PurchaseCar(A.MF.CurrentEntityID, this.loan, carName, ((BankAccount)this.cboDownPaymentSource.SelectedItem).AccountNumber, (float)this.updDownPayment.Value);
				}
				base.Close();
				new frmAutoInsurance
				{
					Cancellable = false
				}.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000B698 File Offset: 0x0000A698
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000B6A2 File Offset: 0x0000A6A2
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Shop For Car"));
		}

		// Token: 0x04000104 RID: 260
		private InstallmentLoan loan;

		// Token: 0x04000105 RID: 261
		private Bill bill;

		// Token: 0x04000106 RID: 262
		private ArrayList itemNames;

		// Token: 0x04000107 RID: 263
		private float leaseCost = 0f;
	}
}
