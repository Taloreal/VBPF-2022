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
	// Token: 0x0200004B RID: 75
	public partial class frmTransferFunds : Form
	{
		// Token: 0x060001FF RID: 511 RVA: 0x0001EC4C File Offset: 0x0001DC4C
		public frmTransferFunds(string bankName)
		{
			this.InitializeComponent();
			SortedList accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				if (account.BankName == bankName)
				{
					this.cboFromAccounts.Items.Add(account);
					this.cboToAccounts.Items.Add(account);
				}
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0001F2D8 File Offset: 0x0001E2D8
		private void frmDepositWithdrawCash_Load(object sender, EventArgs e)
		{
			if (this.cboFromAccounts.Items.Count < 2)
			{
				MessageBox.Show(A.R.GetString("You have at least two bank accounts to transfer funds."), Application.ProductName);
				base.Close();
			}
			else
			{
				this.cboFromAccounts.SelectedIndex = 0;
				this.cboToAccounts.SelectedIndex = 1;
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0001F341 File Offset: 0x0001E341
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001F34C File Offset: 0x0001E34C
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.cboFromAccounts.SelectedIndex == this.cboToAccounts.SelectedIndex)
			{
				MessageBox.Show("Please make sure the From Account is different from the To Account.", "Please Retry");
			}
			else
			{
				try
				{
					A.SA.TransferFunds(A.MF.CurrentEntityID, ((BankAccount)this.cboFromAccounts.SelectedItem).AccountNumber, ((BankAccount)this.cboToAccounts.SelectedItem).AccountNumber, (float)this.updAmount.Value);
					base.Close();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0001F404 File Offset: 0x0001E404
		private void cboFromAccounts_SelectedIndexChanged(object sender, EventArgs e)
		{
			float max = ((BankAccount)this.cboFromAccounts.SelectedItem).EndingBalance();
			this.updAmount.Value = Math.Max(Math.Min(this.updAmount.Value, (decimal)max), this.updAmount.Minimum);
			this.updAmount.Maximum = (decimal)max;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001F46E File Offset: 0x0001E46E
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}
	}
}
