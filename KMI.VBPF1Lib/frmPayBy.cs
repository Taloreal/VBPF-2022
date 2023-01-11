using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayBy.
	/// </summary>
	// Token: 0x02000068 RID: 104
	public partial class frmPayBy : Form
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0002B8C0 File Offset: 0x0002A8C0
		public frmPayBy(Bill bill)
		{
			this.InitializeComponent();
			this.bill = bill;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0002B8E0 File Offset: 0x0002A8E0
		public frmPayBy(Bill bill, ArrayList shoppingList)
		{
			this.InitializeComponent();
			this.bill = bill;
			this.shoppingList = shoppingList;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0002BC8C File Offset: 0x0002AC8C
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.shoppingList != null)
			{
				MessageBox.Show(A.R.GetString("Personal checks are not accepted for merchandise purchases at this store."), A.R.GetString("Please Retry"));
			}
			else
			{
				try
				{
					frmCheckbook f = new frmCheckbook();
					f.FillIn(this.bill);
					if (f.ShowDialog(this) == DialogResult.OK)
					{
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0002BD24 File Offset: 0x0002AD24
		private void button5_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0002BD2E File Offset: 0x0002AD2E
		private void btnCreditCard_Click(object sender, EventArgs e)
		{
			this.PayByCard(true);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0002BD39 File Offset: 0x0002AD39
		private void btnDebitCard_Click(object sender, EventArgs e)
		{
			this.PayByCard(false);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0002BD44 File Offset: 0x0002AD44
		private void PayByCard(bool credit)
		{
			try
			{
				frmSelectCard f = new frmSelectCard(credit);
				f.updAmount.Value = Math.Min(Math.Max(0m, (decimal)this.bill.Amount), f.updAmount.Maximum);
				if (this.bill.Account != null && !(this.bill.Account is InstallmentLoan) && !(this.bill.Account is CreditCardAccount))
				{
					f.updAmount.Value = Math.Max(0m, (decimal)this.bill.Account.EndingBalance());
				}
				if (this.shoppingList != null)
				{
					f.updAmount.Enabled = false;
				}
				f.ShowDialog(this);
				if (f.Card != null)
				{
					this.bill.Amount = (float)f.updAmount.Value;
					A.SA.PayByCard(A.MF.CurrentEntityID, this.bill, (float)f.updAmount.Value, f.Card.AccountNumber, credit);
					if (this.shoppingList != null)
					{
						A.SA.Purchase(A.MF.CurrentEntityID, this.shoppingList);
					}
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0002BEE4 File Offset: 0x0002AEE4
		private void btnCash_Click(object sender, EventArgs e)
		{
			try
			{
				frmPayInCash f = new frmPayInCash();
				f.updAmount.Value = Math.Min(Math.Max(0m, (decimal)this.bill.Amount), f.updAmount.Maximum);
				if (this.bill.Account != null && !(this.bill.Account is InstallmentLoan))
				{
					f.updAmount.Value = Math.Max(0m, (decimal)this.bill.Account.EndingBalance());
				}
				if (this.shoppingList != null)
				{
					f.updAmount.Enabled = false;
				}
				if (this.shoppingList != null || f.ShowDialog(this) == DialogResult.OK)
				{
					this.bill.Amount = (float)f.updAmount.Value;
					A.SA.PayByCash(A.MF.CurrentEntityID, this.bill, (float)f.updAmount.Value);
					if (this.shoppingList != null)
					{
						A.SA.Purchase(A.MF.CurrentEntityID, this.shoppingList);
					}
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x04000334 RID: 820
		private Bill bill;

		// Token: 0x04000335 RID: 821
		private ArrayList shoppingList;
	}
}
