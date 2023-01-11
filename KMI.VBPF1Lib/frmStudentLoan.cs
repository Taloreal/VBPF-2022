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
	// Token: 0x0200000D RID: 13
	public partial class frmStudentLoan : Form
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000042D8 File Offset: 0x000032D8
		public frmStudentLoan(Course course)
		{
			this.InitializeComponent();
			this.course = course;
			this.loan = A.SA.GetStudentLoan(A.MF.CurrentEntityID, course);
			SortedList accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (account is CheckingAccount)
				{
					this.cboBalanceSource.Items.Add(account);
				}
			}
			if (this.cboBalanceSource.Items.Count == 0)
			{
				this.cboBalanceSource.Enabled = false;
				this.updLoanAmount.Enabled = false;
			}
			else
			{
				this.cboBalanceSource.SelectedIndex = 0;
			}
			this.labPrice.Text = Utilities.FC(course.Cost, A.I.CurrencyConversion);
			this.updLoanAmount.Maximum = (decimal)course.Cost;
			this.updLoanAmount.Increment = 50m;
			this.labRate.Text = Utilities.FP(this.loan.InterestRate);
			this.labTerm.Text = this.loan.Term.ToString();
			this.labFirstPaymentDue.Text = this.loan.BeginBilling.AddDays(30.0).ToShortDateString();
			this.updLoanAmount.Value = (decimal)course.Cost;
			if (this.loan.InterestRate == 0f)
			{
				MessageBox.Show(A.R.GetString("Your credit score was too low. You were denied a student loan. You must pay for the class in full if you want to take it now. Otherwise, try raising your credit score above {0}.", new object[]
				{
					0
				}), "Credit Denied");
				this.updLoanAmount.Value = 0m;
				this.updLoanAmount.Maximum = 0m;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000050E8 File Offset: 0x000040E8
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				this.updLoanAmount_ValueChanged(new object(), new EventArgs());
				long accountNumber = -1L;
				BankAccount ba = (BankAccount)this.cboBalanceSource.SelectedItem;
				if (ba != null)
				{
					accountNumber = ba.AccountNumber;
				}
				AppBuildingDrawable.AddOfferingInfo result = A.SA.Enroll(A.MF.CurrentEntityID, this.course.ID, this.loan, accountNumber);
				MessageBox.Show("Congratulations. You've been enrolled!", "Application Accepted");
				if (result.IsFirstTravel)
				{
					AppBuildingDrawable.PickTravelMode();
				}
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000051A4 File Offset: 0x000041A4
		private void updLoanAmount_ValueChanged(object sender, EventArgs e)
		{
			this.loan.OriginalBalance = (float)this.updLoanAmount.Value;
			this.loan.ReComputePayment();
			this.labPayment.Text = Utilities.FC(this.loan.Payment, A.I.CurrencyConversion);
			this.labTotalPayments.Text = Utilities.FC(this.loan.Payment * (float)this.loan.Term, A.I.CurrencyConversion);
			this.labRemainingBalance.Text = Utilities.FC(this.course.Cost - this.loan.OriginalBalance, A.I.CurrencyConversion);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005266 File Offset: 0x00004266
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005270 File Offset: 0x00004270
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Student Loans"));
		}

		// Token: 0x0400009F RID: 159
		private Course course;

		// Token: 0x040000A0 RID: 160
		private InstallmentLoan loan;

		// Token: 0x040000A1 RID: 161
		public AppBuildingDrawable.AddOfferingInfo Result;
	}
}
