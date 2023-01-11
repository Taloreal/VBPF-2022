using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for CheckingAccount.
	/// </summary>
	// Token: 0x0200003A RID: 58
	[Serializable]
	public class InvestmentAccount : BankAccount
	{
		// Token: 0x060001B9 RID: 441 RVA: 0x0001B5A3 File Offset: 0x0001A5A3
		public InvestmentAccount(Fund fund)
		{
			this.Fund = fund;
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0001B5C8 File Offset: 0x0001A5C8
		public override string AccountTypeFriendlyName
		{
			get
			{
				return A.R.GetString("Investment");
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001B5EC File Offset: 0x0001A5EC
		public override string Description()
		{
			return A.R.GetString("Investment account");
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0001B610 File Offset: 0x0001A610
		public override void PrintPage(int page, Graphics g, int year, int month, int Pages, int TransactionsPerPage)
		{
			int y = this.margin;
			int headerx = 220;
			int xright = 330;
			int lineSpace = 15;
			int x2 = 60;
			int x3 = 220;
			int x4 = 275;
			StringFormat sfrb = new StringFormat(BankAccount.sfr);
			sfrb.LineAlignment = StringAlignment.Far;
			StringFormat sflb = new StringFormat();
			sflb.LineAlignment = StringAlignment.Far;
			ArrayList transThisMonth = base.TransactionsForMonth(year, month);
			g.DrawImageUnscaled(A.R.GetImage("Logo" + this.BankName), 2, 4);
			y += 20;
			g.DrawString(A.R.GetString("Monthly Fund"), InvestmentAccount.titleFont, BankAccount.brush, (float)headerx, (float)y);
			y += 20;
			g.DrawString(A.R.GetString("Summary"), InvestmentAccount.titleFont, BankAccount.brush, (float)headerx, (float)y);
			y += 40;
			g.DrawString(A.R.GetString(this.Fund.Name), InvestmentAccount.headerFont, BankAccount.brush, (float)this.margin, (float)y);
			y += 20;
			g.DrawLine(BankAccount.pen, this.margin, y, xright, y);
			y += 30;
			DateTime endOfLastMonth = new DateTime(year, month, 1).AddDays(-1.0);
			DateTime endOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));
			g.DrawString(A.R.GetString("Account Value"), InvestmentAccount.fontB, BankAccount.brush, (float)(xright - 240), (float)y);
			g.DrawString(A.R.GetString("On {0}", new object[]
			{
				endOfLastMonth.ToShortDateString()
			}), BankAccount.font, BankAccount.brush, (float)(xright - 75), (float)y, BankAccount.sfr);
			g.DrawString(A.R.GetString("On {0}", new object[]
			{
				endOfMonth.ToShortDateString()
			}), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 12;
			g.DrawLine(BankAccount.pen, xright - 240, y, xright, y);
			y += 3;
			g.DrawString(Utilities.FC(base.BeginningBalance(year, month) * this.Fund.PriceOn(endOfLastMonth), 2, A.I.CurrencyConversion), BankAccount.font, BankAccount.brush, (float)(xright - 75), (float)y, BankAccount.sfr);
			g.DrawString(Utilities.FC(base.EndingBalance(year, month) * this.Fund.PriceOn(endOfMonth), 2, A.I.CurrencyConversion), InvestmentAccount.fontB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 4 * lineSpace;
			string nl = Environment.NewLine;
			g.DrawString(A.R.GetString("Trade" + nl + "Date"), InvestmentAccount.fontSB, BankAccount.brush, (float)this.margin, (float)y, sflb);
			g.DrawString(A.R.GetString("Transaction"), InvestmentAccount.fontSB, BankAccount.brush, (float)x2, (float)y, sflb);
			g.DrawString(A.R.GetString("Dollar" + nl + "Amount"), InvestmentAccount.fontSB, BankAccount.brush, (float)x3, (float)y, sfrb);
			g.DrawString(A.R.GetString("Shares"), InvestmentAccount.fontSB, BankAccount.brush, (float)x4, (float)y, sfrb);
			g.DrawString(A.R.GetString(string.Concat(new string[]
			{
				"Total",
				nl,
				"Shares",
				nl,
				"Owned"
			})), InvestmentAccount.fontSB, BankAccount.brush, (float)xright, (float)y, sfrb);
			y += 4;
			g.DrawLine(BankAccount.pen, this.margin, y, xright, y);
			y += lineSpace;
			g.DrawString(A.R.GetString("Balance on {0}", new object[]
			{
				endOfLastMonth.ToShortDateString()
			}), InvestmentAccount.fontSB, BankAccount.brush, (float)x2, (float)y);
			g.DrawString(base.BeginningBalance(year, month).ToString("N3"), InvestmentAccount.fontSB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += lineSpace;
			foreach (object obj in transThisMonth)
			{
				Transaction t = (Transaction)obj;
				g.DrawString(t.Date.ToString("MM/dd"), InvestmentAccount.fontSB, BankAccount.brush, (float)this.margin, (float)y);
				g.DrawString(t.Description, InvestmentAccount.fontSB, BankAccount.brush, (float)x2, (float)y);
				g.DrawString(Utilities.FC(t.Amount * this.Fund.PriceOn(t.Date), 2, A.I.CurrencyConversion), InvestmentAccount.fontSB, BankAccount.brush, (float)x3, (float)y, BankAccount.sfr);
				g.DrawString(t.Amount.ToString("N3"), InvestmentAccount.fontSB, BankAccount.brush, (float)x4, (float)y, BankAccount.sfr);
				g.DrawString(base.BalanceThru(t).ToString("N3"), InvestmentAccount.fontSB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
				y += lineSpace;
			}
			g.DrawString(A.R.GetString("Balance on {0}", new object[]
			{
				endOfMonth.ToShortDateString()
			}), InvestmentAccount.fontSB, BankAccount.brush, (float)x2, (float)y);
			g.DrawString(base.EndingBalance(year, month).ToString("N3"), InvestmentAccount.fontSB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0001BC28 File Offset: 0x0001AC28
		public float Value
		{
			get
			{
				return this.Fund.Price * base.EndingBalance();
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0001BC4C File Offset: 0x0001AC4C
		public int ShareAge()
		{
			float totalSales = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Debit)
				{
					totalSales += t.Amount;
				}
			}
			foreach (object obj2 in this.Transactions)
			{
				Transaction t = (Transaction)obj2;
				if (t.Type == Transaction.TranType.Credit)
				{
					totalSales -= t.Amount;
					if (totalSales < 0f)
					{
						return (A.ST.Now - t.Date).Days;
					}
				}
			}
			return 0;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0001BD78 File Offset: 0x0001AD78
		public override void EndMonth()
		{
			float dividend = this.Fund.Dividend / 12f * base.EndingBalance();
			this.Transactions.Add(new Transaction(dividend / this.Fund.Price, Transaction.TranType.Credit, A.R.GetString("Dividend Purchase"), A.ST.Now.AddDays(-1.0)));
			if (!this.Retirement)
			{
				this.CostBasis += dividend;
			}
		}

		// Token: 0x040001CC RID: 460
		public Fund Fund;

		// Token: 0x040001CD RID: 461
		protected static Font titleFont = new Font("Arial", 12f, FontStyle.Bold);

		// Token: 0x040001CE RID: 462
		protected static Font headerFont = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Italic);

		// Token: 0x040001CF RID: 463
		protected static Font fontB = new Font("Arial", 8f, FontStyle.Bold);

		// Token: 0x040001D0 RID: 464
		protected static Font fontSB = new Font("Arial", 7f, FontStyle.Bold);

		// Token: 0x040001D1 RID: 465
		public float CostBasis = 0f;

		// Token: 0x040001D2 RID: 466
		public bool Retirement = false;
	}
}
