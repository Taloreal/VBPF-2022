using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;
using KMI.VBPF1Lib.Custom_Controls;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmSelectCard.
	/// </summary>
	// Token: 0x02000084 RID: 132
	public partial class frmSelectCard : Form
	{
		// Token: 0x0600041A RID: 1050 RVA: 0x00037DA4 File Offset: 0x00036DA4
		public frmSelectCard(bool credit)
		{
			this.InitializeComponent();
			this.credit = credit;
			if (credit)
			{
				this.accounts = A.SA.GetGoodCreditCardAccounts(A.MF.CurrentEntityID);
			}
			else
			{
				this.accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			}
			foreach (object obj in this.accounts.Values)
			{
				BankAccount a = (BankAccount)obj;
				if (a is CreditCardAccount || a is CheckingAccount)
				{
					CardControl card = new CardControl(a);
					card.Click += this.Card_Click;
					card.Location = new Point((card.Width + 20) * this.panCards.Controls.Count + 20, 20);
					this.panCards.Controls.Add(card);
				}
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000383D2 File Offset: 0x000373D2
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000383DC File Offset: 0x000373DC
		private void Card_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panCards.Controls)
			{
				CardControl card = (CardControl)obj;
				card.Selected = (card == sender);
			}
			this.Refresh();
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00038450 File Offset: 0x00037450
		private void frmSelectCard_Load(object sender, EventArgs e)
		{
			if (this.panCards.Controls.Count == 0)
			{
				if (this.credit)
				{
					MessageBox.Show(A.R.GetString("You do not have any credit cards. To get a credit card, click on a bank in the City View."), A.R.GetString("No Card"));
				}
				else
				{
					MessageBox.Show(A.R.GetString("You do not have any debit cards. To get a debit card, click on a bank in the City View and open a checking account."), A.R.GetString("No Card"));
				}
				base.Close();
			}
			if (this.panCards.Controls.Count == 1)
			{
				((CardControl)this.panCards.Controls[0]).Selected = true;
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00038510 File Offset: 0x00037510
		private void btnOK_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panCards.Controls)
			{
				CardControl card = (CardControl)obj;
				if (card.Selected)
				{
					this.Card = card.Account;
					base.Close();
					return;
				}
			}
			MessageBox.Show(A.R.GetString("Please select a card by clicking on it."), A.R.GetString("Input Required"));
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x000385BC File Offset: 0x000375BC
		private void btnCancel_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000385C6 File Offset: 0x000375C6
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Pay Bills"));
		}

		// Token: 0x04000492 RID: 1170
		private bool credit;

		// Token: 0x04000493 RID: 1171
		private SortedList accounts;

		// Token: 0x04000494 RID: 1172
		public BankAccount Card;
	}
}
