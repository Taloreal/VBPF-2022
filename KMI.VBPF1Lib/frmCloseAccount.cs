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
	/// Summary description for frmDepositWithdrawCash.
	/// </summary>
	// Token: 0x0200000E RID: 14
	public partial class frmCloseAccount : Form
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00005288 File Offset: 0x00004288
		public frmCloseAccount(string bankName)
		{
			this.InitializeComponent();
			SortedList accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (account.BankName == bankName)
				{
					this.cboAccounts.Items.Add(account);
				}
			}
			SortedList CCaccounts = A.SA.GetCreditCardAccounts(A.MF.CurrentEntityID);
			foreach (object obj2 in CCaccounts.Values)
			{
				BankAccount account = (BankAccount)obj2;
				if (account.BankName == bankName && account.EndingBalance() <= 0f)
				{
					this.cboAccounts.Items.Add(account);
				}
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005854 File Offset: 0x00004854
		private void frmDepositWithdrawCash_Load(object sender, EventArgs e)
		{
			if (this.cboAccounts.Items.Count == 0)
			{
				MessageBox.Show(A.R.GetString("You do not have any accounts open at this bank."), Application.ProductName);
				base.Close();
			}
			else
			{
				this.cboAccounts.SelectedIndex = 0;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000058AE File Offset: 0x000048AE
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000058B8 File Offset: 0x000048B8
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.CloseAccount(A.MF.CurrentEntityID, (BankAccount)this.cboAccounts.SelectedItem);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005914 File Offset: 0x00004914
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}
	}
}
