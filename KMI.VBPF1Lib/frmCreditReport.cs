using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCreditReport.
	/// </summary>
	// Token: 0x0200004F RID: 79
	public partial class frmCreditReport : frmDrawnReport
	{
		// Token: 0x06000225 RID: 549 RVA: 0x000230A8 File Offset: 0x000220A8
		public frmCreditReport()
		{
			this.InitializeComponent();
			frmCreditReport.sfr.Alignment = StringAlignment.Far;
			frmCreditReport.sfc.Alignment = StringAlignment.Center;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00023100 File Offset: 0x00022100
		protected override void DrawReportVirtual(Graphics g)
		{
			int y = this.margin;
			g.DrawString(A.R.GetString("Credit Report"), frmCreditReport.fontL, frmCreditReport.brush, (float)this.margin, (float)y);
			y += 3 * this.spacing;
			g.DrawString(A.R.GetString("PERSONAL IDENTIFICATION INFORMATION"), frmCreditReport.fontB, frmCreditReport.brush, (float)this.margin, (float)y);
			y += this.spacing;
			g.FillRectangle(frmCreditReport.brush, (float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 3f);
			y += this.spacing;
			g.DrawString(this.input.Name, frmCreditReport.font, frmCreditReport.brush, (float)this.margin, (float)y);
			g.DrawString(A.R.GetString("Social Security #: {0}", new object[]
			{
				this.input.SSN
			}), frmCreditReport.font, frmCreditReport.brush, g.ClipBounds.Width / 2f, (float)y);
			y += this.spacing;
			g.DrawString(A.R.GetString("Springfield, USA"), frmCreditReport.font, frmCreditReport.brush, (float)this.margin, (float)y);
			y += 2 * this.spacing;
			g.DrawString(A.R.GetString("PUBLIC RECORD INFORMATION"), frmCreditReport.fontB, frmCreditReport.brush, (float)this.margin, (float)y);
			y += this.spacing;
			g.FillRectangle(frmCreditReport.brush, (float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 3f);
			y += 2 * this.spacing;
			g.DrawString(A.R.GetString("COLLECTION AGENCY ACCOUNT INFORMATION"), frmCreditReport.fontB, frmCreditReport.brush, (float)this.margin, (float)y);
			y += this.spacing;
			g.FillRectangle(frmCreditReport.brush, (float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 3f);
			y += this.spacing;
			foreach (object obj in this.input.Accounts)
			{
				BankAccount account = (BankAccount)obj;
				BankAccount.Status status = account.PastDueStatusPassive(this.input.Now.Year, this.input.Now.Month);
				if (status == BankAccount.Status.NewlyCancelled || status == BankAccount.Status.Cancelled)
				{
					g.DrawString(A.R.GetString("In process of collection. Client: {0} Amount: {1}", new object[]
					{
						account.BankName,
						Utilities.FC(account.EndingBalance(), A.I.CurrencyConversion)
					}), frmCreditReport.font, frmCreditReport.brush, (float)this.margin, (float)y);
					y += this.spacing;
				}
			}
			y += this.spacing;
			g.DrawString(A.R.GetString("CREDIT ACCOUNT INFORMATION"), frmCreditReport.fontB, frmCreditReport.brush, (float)this.margin, (float)y);
			y += this.spacing;
			g.FillRectangle(frmCreditReport.brush, (float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 3f);
			y += 2 * this.spacing;
			int i = 0;
			foreach (string headers in new string[]
			{
				"COMPANY",
				"ACCOUNT",
				"HIGH",
				"",
				"PAST",
				""
			})
			{
				g.DrawString(headers, frmCreditReport.fontS, frmCreditReport.brush, (float)((1 + i++) * this.colWidth), (float)y, frmCreditReport.sfc);
			}
			y += this.spacing;
			i = 0;
			foreach (string headers in new string[]
			{
				"NAME",
				"NUMBER",
				"CREDIT",
				"BALANCE",
				"DUE",
				"STATUS"
			})
			{
				g.DrawString(headers, frmCreditReport.fontS, frmCreditReport.brush, (float)((1 + i++) * this.colWidth), (float)y, frmCreditReport.sfc);
			}
			y += this.spacing;
			g.FillRectangle(frmCreditReport.brush, (float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 1f);
			y += this.spacing;
			int lateLoan = 0;
			int lateCC = 0;
			foreach (object obj2 in this.input.Accounts)
			{
				BankAccount acct = (BankAccount)obj2;
				if (acct is InstallmentLoan || acct is CreditCardAccount)
				{
					float highCredit = 0f;
					if (acct is InstallmentLoan)
					{
						highCredit = ((InstallmentLoan)acct).OriginalBalance;
						lateLoan += ((InstallmentLoan)acct).MissedPayments();
					}
					else if (acct is CreditCardAccount)
					{
						highCredit = ((CreditCardAccount)acct).CreditLimit;
						lateCC += ((CreditCardAccount)acct).MissedPayments();
					}
					g.DrawString(acct.BankName.Substring(0, Math.Min(15, acct.BankName.Length)), frmCreditReport.font, frmCreditReport.brush, (float)this.margin, (float)y);
					g.DrawString(acct.AccountNumber.ToString(), frmCreditReport.font, frmCreditReport.brush, (float)this.margin + 1.5f * (float)this.colWidth, (float)y);
					g.DrawString(Utilities.FC(highCredit, A.I.CurrencyConversion), frmCreditReport.font, frmCreditReport.brush, (float)this.margin + 2.6f * (float)this.colWidth, (float)y);
					g.DrawString(Utilities.FC(acct.EndingBalance(), A.I.CurrencyConversion), frmCreditReport.font, frmCreditReport.brush, (float)this.margin + 3.6f * (float)this.colWidth, (float)y);
					g.DrawString(Utilities.FC(acct.PastDueAmount(this.input.Now), A.I.CurrencyConversion), frmCreditReport.font, frmCreditReport.brush, (float)this.margin + 4.6f * (float)this.colWidth, (float)y);
					g.DrawString(acct.CRStatus(this.input.Now), frmCreditReport.font, frmCreditReport.brush, (float)this.margin + 5.6f * (float)this.colWidth, (float)y);
					y += this.spacing;
				}
			}
			y += (int)(1.5f * (float)this.spacing);
			g.DrawString(A.R.GetString("Previous Payment History:"), frmCreditReport.fontB, frmCreditReport.brush, (float)(2 * this.margin), (float)y);
			y += this.spacing;
			g.DrawString(A.R.GetString("{0} times late on loan payments", new object[]
			{
				lateLoan
			}), frmCreditReport.font, frmCreditReport.brush, (float)(2 * this.margin), (float)y);
			y += this.spacing;
			g.DrawString(A.R.GetString("{0} times late on credit card payments", new object[]
			{
				lateCC
			}), frmCreditReport.font, frmCreditReport.brush, (float)(2 * this.margin), (float)y);
			y += 2 * this.spacing;
			this.picReport.Height = y + 30;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00023A7B File Offset: 0x00022A7B
		protected override void GetDataVirtual()
		{
			this.input = A.SA.GetCreditReport(A.MF.CurrentEntityID);
		}

		// Token: 0x04000272 RID: 626
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x04000273 RID: 627
		protected static Font fontB = new Font("Arial", 8f, FontStyle.Bold);

		// Token: 0x04000274 RID: 628
		protected static Font fontS = new Font("Arial", 7f);

		// Token: 0x04000275 RID: 629
		protected static Font fontL = new Font("Arial", 16f);

		// Token: 0x04000276 RID: 630
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x04000277 RID: 631
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x04000278 RID: 632
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x04000279 RID: 633
		protected static Pen pen = new Pen(frmCreditReport.brush, 1f);

		// Token: 0x0400027A RID: 634
		protected int margin = 10;

		// Token: 0x0400027B RID: 635
		protected int col1Width = 120;

		// Token: 0x0400027C RID: 636
		protected int colWidth = 60;

		// Token: 0x0400027D RID: 637
		protected int spacing = 14;

		// Token: 0x0400027E RID: 638
		private frmCreditReport.Input input;

		// Token: 0x02000050 RID: 80
		[Serializable]
		public struct Input
		{
			// Token: 0x0400027F RID: 639
			public string Name;

			// Token: 0x04000280 RID: 640
			public string SSN;

			// Token: 0x04000281 RID: 641
			public ArrayList Accounts;

			// Token: 0x04000282 RID: 642
			public DateTime Now;
		}
	}
}
