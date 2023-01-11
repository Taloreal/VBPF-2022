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
	/// Summary description for frmMethodOfPay.
	/// </summary>
	// Token: 0x02000058 RID: 88
	public partial class frmMethodOfPay : Form
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00026FB0 File Offset: 0x00025FB0
		public frmMethodOfPay(long taskID)
		{
			this.InitializeComponent();
			SortedList bankAccounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			SortedList checkingAccounts = new SortedList();
			foreach (object obj in bankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				if (ba is CheckingAccount)
				{
					checkingAccounts.Add(ba.AccountNumber, ba);
				}
			}
			BankAccount directDepositAccount = A.SA.GetDirectDepositAccount(A.MF.CurrentEntityID, taskID);
			if (checkingAccounts.Count > 0)
			{
				this.optDirectDeposit.Enabled = true;
				foreach (object obj2 in checkingAccounts.Values)
				{
					BankAccount account = (BankAccount)obj2;
					this.cboAccounts.Items.Add(account);
				}
				if (directDepositAccount != null)
				{
					this.optDirectDeposit.Checked = true;
					this.cboAccounts.SelectedIndex = checkingAccounts.IndexOfKey(directDepositAccount.AccountNumber);
				}
				else
				{
					this.cboAccounts.SelectedIndex = 0;
				}
			}
			this.taskID = taskID;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00027564 File Offset: 0x00026564
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				long accountNumber = -1L;
				if (this.optDirectDeposit.Checked)
				{
					accountNumber = ((BankAccount)this.cboAccounts.SelectedItem).AccountNumber;
				}
				A.SA.SetDirectDepositAccount(A.MF.CurrentEntityID, this.taskID, accountNumber);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
			base.Close();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000275E4 File Offset: 0x000265E4
		private void optDirectDeposit_CheckedChanged(object sender, EventArgs e)
		{
			this.cboAccounts.Enabled = this.optDirectDeposit.Checked;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000275FE File Offset: 0x000265FE
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Getting Paid"));
		}

		// Token: 0x040002CA RID: 714
		private long taskID;
	}
}
