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
	/// Summary description for frmOpenBankAccount.
	/// </summary>
	// Token: 0x02000057 RID: 87
	public partial class frmOpenBankAccount : Form
	{
		// Token: 0x06000254 RID: 596 RVA: 0x00026784 File Offset: 0x00025784
		public frmOpenBankAccount(int ave, int street, int lot, bool checking)
		{
			this.InitializeComponent();
			ArrayList ProtoAccounts = A.SA.GetOfferings(ave, street, lot);
			if (checking)
			{
				this.protoAccount = (BankAccount)ProtoAccounts[0];
				this.Text = A.R.GetString("Open Checking Account");
			}
			else
			{
				this.protoAccount = (BankAccount)ProtoAccounts[1];
				this.Text = A.R.GetString("Open Savings Account");
			}
			this.accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in this.accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (account.BankName == ((BankAccount)ProtoAccounts[0]).BankName)
				{
					this.cboAccounts.Items.Add(account);
				}
			}
			if (this.cboAccounts.Items.Count > 0)
			{
				this.optTransfer.Enabled = true;
				this.cboAccounts.SelectedIndex = 0;
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00026EDC File Offset: 0x00025EDC
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				long accountNumber = -1L;
				if (this.optTransfer.Checked)
				{
					accountNumber = ((BankAccount)this.cboAccounts.SelectedItem).AccountNumber;
				}
				A.SA.SetBankAccount(A.MF.CurrentEntityID, this.protoAccount, (float)this.updInitDeposit.Value, accountNumber);
				MessageBox.Show("Your new account has been opened.", "Congratulations");
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00026F7C File Offset: 0x00025F7C
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00026F86 File Offset: 0x00025F86
		private void optTransfer_CheckedChanged(object sender, EventArgs e)
		{
			this.cboAccounts.Enabled = this.optTransfer.Checked;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00026FA0 File Offset: 0x00025FA0
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x040002C1 RID: 705
		private BankAccount protoAccount;

		// Token: 0x040002C2 RID: 706
		private SortedList accounts;
	}
}
