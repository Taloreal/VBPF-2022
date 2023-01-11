using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmBankStatement.
	/// </summary>
	// Token: 0x02000030 RID: 48
	public partial class frmBankStatement : Form
	{
		// Token: 0x06000181 RID: 385 RVA: 0x00019628 File Offset: 0x00018628
		public frmBankStatement()
		{
			this.InitializeComponent();
			this.bankAccounts = this.GetAccounts();
			this.maxMonth = A.MF.Now.Month;
			this.maxYear = A.MF.Now.Year;
			if (this.maxMonth == 1)
			{
				this.maxMonth = 12;
				this.maxYear--;
			}
			else
			{
				this.maxMonth--;
			}
			this.currentMonth = this.maxMonth;
			this.currentYear = this.maxYear;
			foreach (object obj in this.bankAccounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				this.lstAccount.Items.Add(account);
			}
			if (this.lstAccount.Items.Count > 0)
			{
				this.lstAccount.SelectedIndex = 0;
				this.picStatement.Visible = true;
			}
			this.btnPrint.Enabled = (this.currentAccount != null);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000197B0 File Offset: 0x000187B0
		protected virtual SortedList GetAccounts()
		{
			return A.SA.GetBankAccounts(A.MF.CurrentEntityID);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00019F4C File Offset: 0x00018F4C
		protected void Report_PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			e.Graphics.ScaleTransform(2f, 2f);
			e.HasMorePages = this.PrintPage(this.printerPage, e.Graphics);
			this.printerPage++;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00019F9D File Offset: 0x00018F9D
		private void button1_Click(object sender, EventArgs e)
		{
			this.printerPage = 0;
			Utilities.PrintWithExceptionHandling(this.Text, new PrintPageEventHandler(this.Report_PrintPage));
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00019FC0 File Offset: 0x00018FC0
		private void picStatement_Paint(object sender, PaintEventArgs e)
		{
			this.transThisMonth = this.currentAccount.TransactionsForMonth(this.currentYear, this.currentMonth);
			this.btnPageBack.Enabled = (this.page > 0);
			this.btnPageNext.Enabled = (this.page < this.Pages - 1);
			this.btnMonthBack.Enabled = (this.currentYear > this.currentAccount.DateOpened.Year || (this.currentMonth > this.currentAccount.DateOpened.Month && this.currentYear == this.currentAccount.DateOpened.Year));
			this.btnMonthNext.Enabled = (this.currentYear < A.MF.Now.Year || this.currentMonth < A.MF.Now.Month);
			if (!A.MF.DesignerMode)
			{
				this.btnMonthNext.Enabled = (this.currentYear < this.maxYear || this.currentMonth < this.maxMonth);
			}
			this.PrintPage(this.page, e.Graphics);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0001A10E File Offset: 0x0001910E
		private void btnPageNext_Click(object sender, EventArgs e)
		{
			this.page++;
			this.picStatement.Refresh();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0001A12B File Offset: 0x0001912B
		private void btnPageBack_Click(object sender, EventArgs e)
		{
			this.page--;
			this.picStatement.Refresh();
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0001A148 File Offset: 0x00019148
		protected int Pages
		{
			get
			{
				int result;
				if (this.currentAccount == null)
				{
					result = 0;
				}
				else
				{
					result = (int)Math.Max(1.0, Math.Ceiling((double)((float)this.transThisMonth.Count / (float)this.TransactionsPerPage)));
				}
				return result;
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0001A198 File Offset: 0x00019198
		protected virtual bool PrintPage(int page, Graphics g)
		{
			this.currentAccount.PrintPage(page, g, this.currentYear, this.currentMonth, this.Pages, this.TransactionsPerPage);
			return page < this.Pages - 1;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0001A1DB File Offset: 0x000191DB
		private void lstAccount_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.currentAccount = (BankAccount)this.lstAccount.SelectedItem;
			this.picStatement.Refresh();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0001A200 File Offset: 0x00019200
		private void btnMonthBack_Click(object sender, EventArgs e)
		{
			if (this.currentMonth == 1)
			{
				this.currentMonth = 12;
				this.currentYear--;
			}
			else
			{
				this.currentMonth--;
			}
			this.picStatement.Refresh();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0001A254 File Offset: 0x00019254
		private void btnMonthForward_Click(object sender, EventArgs e)
		{
			if (this.currentMonth == 12)
			{
				this.currentMonth = 1;
				this.currentYear++;
			}
			else
			{
				this.currentMonth++;
			}
			this.picStatement.Refresh();
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0001A2A6 File Offset: 0x000192A6
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x04000199 RID: 409
		protected PrintDocument d = new PrintDocument();

		// Token: 0x0400019A RID: 410
		protected int page = 0;

		// Token: 0x0400019B RID: 411
		protected int printerPage = 0;

		// Token: 0x0400019C RID: 412
		protected int TransactionsPerPage = 27;

		// Token: 0x0400019D RID: 413
		protected SortedList bankAccounts;

		// Token: 0x0400019E RID: 414
		protected BankAccount currentAccount;

		// Token: 0x0400019F RID: 415
		protected int maxMonth;

		// Token: 0x040001A0 RID: 416
		protected int maxYear;

		// Token: 0x040001A1 RID: 417
		protected int currentMonth;

		// Token: 0x040001A2 RID: 418
		protected int currentYear;

		// Token: 0x040001A3 RID: 419
		protected ArrayList transThisMonth;
	}
}
