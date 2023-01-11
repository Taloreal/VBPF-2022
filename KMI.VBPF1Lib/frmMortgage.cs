using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayForCar.
	/// </summary>
	// Token: 0x0200006D RID: 109
	public partial class frmMortgage : Form
	{
		// Token: 0x060002DD RID: 733 RVA: 0x00030CC8 File Offset: 0x0002FCC8
		public frmMortgage(Offering offering)
		{
			this.InitializeComponent();
			this.loading = true;
			this.offering = offering;
			Mortgage[] loans = A.SA.GetMortgage(A.MF.CurrentEntityID, offering);
			foreach (Mortgage i in loans)
			{
				this.cboType.Items.Add(i);
			}
			this.loan = loans[0];
			this.salePrice = this.loan.OriginalBalance;
			this.baseInterestRate = this.loan.InterestRate;
			SortedList accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			this.cboType.SelectedIndex = 0;
			this.cboPoints.SelectedIndex = 0;
			this.labPrice.Text = Utilities.FC(this.salePrice, A.I.CurrencyConversion);
			this.updDownPayment.Maximum = (decimal)this.salePrice;
			this.updDownPayment.Value = (decimal)(0.1f * this.salePrice);
			this.updDownPayment.Minimum = (decimal)(0f * this.salePrice);
			if (this.loan.InterestRate == 0f)
			{
				MessageBox.Show(A.R.GetString("Your credit score was too low. You were denied a loan. You can only purchase now by paying the full amount as your down payment. Otherwise, try raising your credit score above {0}.", new object[]
				{
					610
				}), "Credit Denied");
				this.updDownPayment.Value = (decimal)this.salePrice;
				this.updDownPayment.Minimum = (decimal)this.salePrice;
			}
			this.updDownPayment.Increment = 1000m;
			this.labTerm.Text = (this.loan.Term / 12).ToString();
			foreach (object obj in accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (account is CheckingAccount)
				{
					this.cboDownPaymentSource.Items.Add(account);
				}
			}
			this.loading = false;
			this.UpdateAll(new object(), new EventArgs());
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000321B8 File Offset: 0x000311B8
		private void UpdateAll(object sender, EventArgs e)
		{
			if (!this.loading)
			{
				this.loan = (Mortgage)this.cboType.SelectedItem;
				this.loan.OriginalBalance = this.salePrice - (float)this.updDownPayment.Value;
				float points = float.Parse(this.cboPoints.SelectedItem.ToString());
				this.loan.InterestRate = this.baseInterestRate - points / 400f;
				this.loan.ReComputePayment();
				this.labRate.Text = Utilities.FP(this.loan.InterestRate, 2);
				this.labFinanced.Text = Utilities.FC(this.loan.OriginalBalance, A.I.CurrencyConversion);
				this.labPandI.Text = Utilities.FC(this.loan.Payment, A.I.CurrencyConversion);
				this.labPayment.Text = Utilities.FC(this.loan.Payment + this.loan.PMI(this.salePrice), A.I.CurrencyConversion);
				this.labPMI.Text = Utilities.FC(this.loan.PMI(this.salePrice), A.I.CurrencyConversion);
				this.labTotalPayments.Text = Utilities.FC(this.loan.Payment * (float)this.loan.Term + (float)this.updDownPayment.Value, A.I.CurrencyConversion);
				this.labClosingCosts.Text = Utilities.FC(4100f, A.I.CurrencyConversion);
				this.cashAtClosing = 4100f + (float)this.updDownPayment.Value + points / 100f * this.loan.OriginalBalance;
				this.labCashAtClosing.Text = Utilities.FC(this.cashAtClosing, A.I.CurrencyConversion);
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000323D4 File Offset: 0x000313D4
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.UpdateAll(new object(), new EventArgs());
			A.SA.SetMortgage(A.MF.CurrentEntityID, this.loan, this.offering.ID, ((BankAccount)this.cboDownPaymentSource.SelectedItem).AccountNumber, this.cashAtClosing);
			base.Close();
			base.DialogResult = DialogResult.OK;
			new frmHomeOwnersInsurance(this.offering)
			{
				Cancellable = false
			}.ShowDialog(this);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0003245F File Offset: 0x0003145F
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0003246C File Offset: 0x0003146C
		private void frmMortgage_Load(object sender, EventArgs e)
		{
			if (this.cboDownPaymentSource.Items.Count == 0)
			{
				MessageBox.Show("You will need a checking account as the source for cash due at closing. Please open a checking account first.", "Mortgage");
				base.Close();
			}
			else
			{
				this.cboDownPaymentSource.SelectedIndex = 0;
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000324BC File Offset: 0x000314BC
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Condos For Sale"));
		}

		// Token: 0x040003B9 RID: 953
		private Offering offering;

		// Token: 0x040003BA RID: 954
		private Mortgage loan;

		// Token: 0x040003BB RID: 955
		private float salePrice;

		// Token: 0x040003BC RID: 956
		private float baseInterestRate;

		// Token: 0x040003BD RID: 957
		private float cashAtClosing;

		// Token: 0x040003BE RID: 958
		private bool loading;
	}
}
