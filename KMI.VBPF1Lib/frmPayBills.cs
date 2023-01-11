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
	/// Summary description for frmLicensing.
	/// </summary>
	// Token: 0x02000069 RID: 105
	public partial class frmPayBills : Form
	{
		// Token: 0x060002B0 RID: 688 RVA: 0x0002C06C File Offset: 0x0002B06C
		public frmPayBills()
		{
			this.InitializeComponent();
			this.RefreshData();
			this.currentIndex = 0;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0002C9FC File Offset: 0x0002B9FC
		private void picBill_Paint(object sender, PaintEventArgs e)
		{
			if (this.bills.Count > 0 && this.currentIndex >= 0 && this.currentIndex < this.bills.Count)
			{
				if (this.currentBill.Account is CreditCardAccount || this.currentBill.Account is InstallmentLoan)
				{
					int transCount = this.currentBill.Account.TransactionsForMonth(this.currentBill.Date.Year, this.currentBill.Date.Month).Count;
					int pages = (int)Math.Max(1.0, Math.Ceiling((double)((float)transCount / (float)this.TransactionsPerPage)));
					this.updPage.Value = Math.Min(this.updPage.Value, pages);
					this.updPage.Maximum = pages;
					this.updPage.Visible = true;
					this.labPage.Visible = true;
					this.currentBill.Account.PrintPage((int)this.updPage.Value - 1, e.Graphics, this.currentBill.Date.Year, this.currentBill.Date.Month, pages, this.TransactionsPerPage);
				}
				else
				{
					this.currentBill.PrintPage(e.Graphics);
					this.updPage.Visible = false;
					this.labPage.Visible = false;
				}
			}
			else if (this.bills.Count == 0)
			{
				this.btnAccept.Enabled = false;
			}
			this.btnBack.Enabled = (this.currentIndex > 0);
			this.btnNext.Enabled = (this.currentIndex < this.bills.Count - 1);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0002CBF7 File Offset: 0x0002BBF7
		private void btnNext_Click(object sender, EventArgs e)
		{
			this.currentIndex++;
			this.picBill.Refresh();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0002CC14 File Offset: 0x0002BC14
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.currentIndex--;
			this.picBill.Refresh();
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0002CC34 File Offset: 0x0002BC34
		private void btnAccept_Click(object sender, EventArgs e)
		{
			try
			{
				frmPayBy f = new frmPayBy(this.currentBill);
				f.ShowDialog(this);
				A.MF.UpdateView();
				this.RefreshData();
				this.picBill.Refresh();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0002CC98 File Offset: 0x0002BC98
		public Bill currentBill
		{
			get
			{
				return (Bill)this.bills.GetByIndex(this.currentIndex);
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0002CCC0 File Offset: 0x0002BCC0
		protected void RefreshData()
		{
			this.bills = A.SA.GetBills(A.MF.CurrentEntityID);
			this.currentIndex = Math.Min(this.currentIndex, this.bills.Count - 1);
			this.panBills.Visible = (this.bills.Count > 0);
			this.btnAccept.Enabled = (this.bills.Count > 0);
			for (int i = 0; i < this.panBills.Controls.Count; i++)
			{
				this.panBills.Controls[i].Visible = (i < this.bills.Count);
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0002CD7E File Offset: 0x0002BD7E
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0002CD88 File Offset: 0x0002BD88
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0002CD97 File Offset: 0x0002BD97
		private void updPage_ValueChanged(object sender, EventArgs e)
		{
			this.picBill.Refresh();
		}

		// Token: 0x04000345 RID: 837
		private SortedList bills;

		// Token: 0x04000346 RID: 838
		private int currentIndex;

		// Token: 0x04000347 RID: 839
		protected int TransactionsPerPage = 24;
	}
}
