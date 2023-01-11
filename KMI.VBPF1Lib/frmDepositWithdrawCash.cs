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
	// Token: 0x0200006F RID: 111
	public partial class frmDepositWithdrawCash : Form
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x00032734 File Offset: 0x00031734
		public frmDepositWithdrawCash(string bankName, bool withdraw)
		{
			this.InitializeComponent();
			this.withdraw = withdraw;
			if (withdraw)
			{
				this.Text = A.R.GetString("Withdraw Cash");
			}
			else
			{
				this.Text = A.R.GetString("Deposit Funds");
			}
			SortedList accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (!withdraw || account.BankName == bankName)
				{
					this.cboAccounts.Items.Add(account);
				}
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00032D00 File Offset: 0x00031D00
		private void frmDepositWithdrawCash_Load(object sender, EventArgs e)
		{
			if (this.cboAccounts.Items.Count == 0)
			{
				MessageBox.Show(A.R.GetString("You must open a bank account first before depositing or withdrawing funds."), Application.ProductName);
				base.Close();
			}
			else
			{
				this.cboAccounts.SelectedIndex = 0;
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00032D5A File Offset: 0x00031D5A
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00032D64 File Offset: 0x00031D64
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetDepositWithdrawCash(A.MF.CurrentEntityID, this.withdraw, (float)this.updAmount.Value, ((BankAccount)this.cboAccounts.SelectedItem).AccountNumber);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00032DDC File Offset: 0x00031DDC
		private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.withdraw)
			{
				float max = ((BankAccount)this.cboAccounts.SelectedItem).EndingBalance();
				if (max < 0f)
				{
					max = 0f;
				}
				this.updAmount.Value = Math.Min(this.updAmount.Value, (decimal)max);
				this.updAmount.Maximum = (decimal)max;
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00032E5A File Offset: 0x00031E5A
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x040003CB RID: 971
		private bool withdraw;
	}
}
