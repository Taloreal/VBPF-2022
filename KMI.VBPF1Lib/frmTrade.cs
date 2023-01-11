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
	/// Summary description for frmTrade.
	/// </summary>
	// Token: 0x0200004C RID: 76
	public partial class frmTrade : Form
	{
		// Token: 0x06000207 RID: 519 RVA: 0x0001F480 File Offset: 0x0001E480
		public frmTrade(bool retirement, bool buy, Fund targetFund)
		{
			this.InitializeComponent();
			this.funds = A.SA.GetFunds();
			this.bankAccounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			this.myAccounts = A.SA.GetInvestmentAccounts(A.MF.CurrentEntityID, retirement);
			foreach (object obj in this.funds)
			{
				Fund fund = (Fund)obj;
				this.cboFund.Items.Add(fund.Name);
				if (targetFund != null && targetFund.Name == fund.Name)
				{
					this.cboFund.SelectedIndex = this.cboFund.Items.Count - 1;
				}
			}
			this.buy = buy;
			this.LimitAmounts();
			foreach (object obj2 in this.bankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj2;
				if (ba is CheckingAccount)
				{
					this.cboSource.Items.Add(ba);
				}
			}
			this.cboSource.Items.Add("Cash");
			this.cboSource.SelectedIndex = 0;
			this.retirement = retirement;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0001FBE5 File Offset: 0x0001EBE5
		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0001FBF0 File Offset: 0x0001EBF0
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.cboFund.SelectedItem == null)
				{
					MessageBox.Show(A.R.GetString("You must select a fund to buy or sell."));
				}
				else
				{
					long sourceID = -1L;
					if (this.cboSource.SelectedItem is BankAccount)
					{
						sourceID = ((BankAccount)this.cboSource.SelectedItem).AccountNumber;
					}
					if (this.buy)
					{
						A.SA.BuyFund(A.MF.CurrentEntityID, this.cboFund.SelectedItem.ToString(), (float)this.updAmount.Value, sourceID);
					}
					else
					{
						A.SA.SellFund(A.MF.CurrentEntityID, this.cboFund.SelectedItem.ToString(), (float)this.updAmount.Value, sourceID, this.retirement);
					}
					base.Close();
					foreach (Form f in A.MF.OwnedForms)
					{
						if (f is frmMyPortfolio)
						{
							((frmMyPortfolio)f).RefreshData();
						}
					}
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0001FD60 File Offset: 0x0001ED60
		private void LimitAmounts()
		{
			if (this.buy)
			{
				this.updAmount.Value = Math.Min(1000000m, this.updAmount.Value);
				this.updAmount.Maximum = 1000000m;
				this.labSource.Text = "Withdraw money from:";
				this.Text = "Buy Shares";
			}
			else
			{
				InvestmentAccount account = null;
				foreach (object obj in this.myAccounts.Values)
				{
					InvestmentAccount ia = (InvestmentAccount)obj;
					if (this.cboFund.SelectedIndex > -1 && ia.Fund.Name == this.cboFund.SelectedItem.ToString())
					{
						account = ia;
					}
				}
				if (account != null)
				{
					decimal max = (decimal)account.Value;
					if (max < 0m)
					{
						max = 0m;
					}
					this.updAmount.Value = Math.Min(max, this.updAmount.Value);
					this.updAmount.Maximum = max;
					this.labSource.Text = "Deposit money to:";
				}
				this.Text = "Sell Shares";
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0001FEF4 File Offset: 0x0001EEF4
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x04000227 RID: 551
		private ArrayList funds;

		// Token: 0x04000228 RID: 552
		private SortedList bankAccounts;

		// Token: 0x04000229 RID: 553
		private SortedList myAccounts;

		// Token: 0x0400022A RID: 554
		private bool retirement = false;

		// Token: 0x0400022B RID: 555
		private bool buy;
	}
}
