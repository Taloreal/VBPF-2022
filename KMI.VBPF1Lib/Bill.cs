using System;
using System.Collections;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Bill.
	/// </summary>
	// Token: 0x02000053 RID: 83
	[Serializable]
	public class Bill
	{
		// Token: 0x0600023B RID: 571 RVA: 0x00025024 File Offset: 0x00024024
		public Bill(string from, string description, float amount, BankAccount account)
		{
			this.From = from;
			this.Amount = amount;
			this.Account = account;
			this.Date = A.ST.Now;
			this.ID = A.ST.GetNextID();
			if (account != null && !(account is CreditCardAccount) && !(account is InstallmentLoan))
			{
				this.Account.Transactions.Add(new Transaction(amount, Transaction.TranType.Credit, description, A.ST.Now.AddDays(-1.0)));
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000250DC File Offset: 0x000240DC
		static Bill()
		{
			Bill.sfc.Alignment = StringAlignment.Center;
			Bill.sfr.Alignment = StringAlignment.Far;
			try
			{
				Bill.font2 = new Font("Courier New", 8f);
			}
			catch (Exception ex)
			{
				Bill.font2 = new Font("Arial", 8f);
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000251E4 File Offset: 0x000241E4
		public void PrintPage(Graphics g)
		{
			int a = 80;
			int a2 = 150;
			int a3 = 200;
			int a4 = 321;
			int b = 14;
			int b2 = 64;
			int b3 = 248;
			int b4 = 321;
			int c = 50;
			int c2 = 130;
			int c3 = 210;
			int c4 = 321;
			int lineHeight = 18;
			int h = 425;
			int year = this.Date.Year;
			int month = this.Date.Month;
			int y = 20;
			BankAccount account = this.Account;
			g.DrawImageUnscaled(A.R.GetImage("Logo" + account.BankName), 4, 4);
			g.DrawString(A.R.GetString("Invoice #: {0}", new object[]
			{
				this.ID
			}), Bill.fontL, Bill.brush, (float)c4, (float)(y - 12), Bill.sfr);
			y += 70;
			g.FillRectangle(Bill.brush, a, y, a4 - a, lineHeight);
			g.DrawString(A.R.GetString("DATE"), Bill.font, Bill.white, (float)((a2 + a) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(A.R.GetString("TERMS"), Bill.font, Bill.white, (float)((a3 + a2) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(A.R.GetString("CUSTOMER NAME"), Bill.font, Bill.white, (float)((a4 + a3) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(this.Date.ToShortDateString(), Bill.font2, Bill.brush, (float)((a2 + a) / 2), (float)(y + lineHeight + 3), Bill.sfc);
			g.DrawString(A.R.GetString("Net 30"), Bill.font2, Bill.brush, (float)((a3 + a2) / 2), (float)(y + lineHeight + 3), Bill.sfc);
			g.DrawString(this.Account.OwnerName.ToUpper(), Bill.font2, Bill.brush, (float)((a4 + a3) / 2), (float)(y + lineHeight + 3), Bill.sfc);
			g.DrawLine(Bill.pen, a, y, a, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, a2, y, a2, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, a3, y, a3, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, a4, y, a4, y + 2 * lineHeight);
			y += 2 * lineHeight;
			g.FillRectangle(Bill.brush, b, y, b4 - b, lineHeight);
			g.DrawString(A.R.GetString("DATE"), Bill.font, Bill.white, (float)((b2 + b) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(A.R.GetString("DESCRIPTION"), Bill.font, Bill.white, (float)((b3 + b2) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(A.R.GetString("AMOUNT"), Bill.font, Bill.white, (float)((b4 + b3) / 2), (float)(y + 2), Bill.sfc);
			g.DrawLine(Bill.pen, b, y, b, h);
			g.DrawLine(Bill.pen, b2, y, b2, h);
			g.DrawLine(Bill.pen, b3, y, b3, h);
			g.DrawLine(Bill.pen, b4, y, b4, h);
			g.DrawString(A.R.GetString("Balance Forward"), Bill.font2, Bill.brush, (float)(b2 + this.margin), (float)(y + lineHeight + 3));
			g.DrawString(this.Account.BeginningBalance(year, month).ToString("N2"), Bill.font2, Bill.brush, (float)(b4 - this.margin), (float)(y + lineHeight + 3), Bill.sfr);
			y += lineHeight;
			ArrayList transThisMonth = this.Account.TransactionsForMonth(year, month);
			foreach (object obj in transThisMonth)
			{
				Transaction t = (Transaction)obj;
				g.DrawString(t.Date.ToString("MM/dd"), Bill.font2, Bill.brush, (float)(b + this.margin), (float)(y + lineHeight + 3));
				g.DrawString(t.Description, Bill.font2, Bill.brush, (float)(b2 + this.margin), (float)(y + lineHeight + 3));
				float f = t.Amount;
				if (t.Type == Transaction.TranType.Debit)
				{
					f = -f;
				}
				g.DrawString(f.ToString("N2"), Bill.font2, Bill.brush, (float)(b4 - this.margin), (float)(y + lineHeight + 3), Bill.sfr);
				y += lineHeight;
			}
			y = h;
			g.FillRectangle(Bill.brush, b, y, b4 - b, lineHeight);
			g.DrawString(A.R.GetString("PAST DUE"), Bill.font, Bill.white, (float)((c2 + c) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(A.R.GetString("CURRENT"), Bill.font, Bill.white, (float)((c3 + c2) / 2), (float)(y + 2), Bill.sfc);
			g.DrawString(A.R.GetString("AMOUNT DUE"), Bill.font, Bill.white, (float)((c4 + c3) / 2), (float)(y + 2), Bill.sfc);
			g.DrawLine(Bill.pen, c, y, c, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, c2, y, c2, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, c3, y, c3, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, c4, y, c4, y + 2 * lineHeight);
			g.DrawLine(Bill.pen, c, y + 2 * lineHeight, c4, y + 2 * lineHeight);
			g.DrawString(this.Account.PastDueAmount(this.Date).ToString("N2"), Bill.font2, Bill.brush, (float)(c2 - this.margin), (float)(y + lineHeight + 3), Bill.sfr);
			g.DrawString(this.Account.CurrentCharges(this.Date).ToString("N2"), Bill.font2, Bill.brush, (float)(c3 - this.margin), (float)(y + lineHeight + 3), Bill.sfr);
			g.DrawString(this.Account.EndingBalance(year, month).ToString("N2"), Bill.font2, Bill.brush, (float)(c4 - this.margin), (float)(y + lineHeight + 3), Bill.sfr);
			this.Account.StampStatus(g, year, month);
		}

		// Token: 0x0400029A RID: 666
		public string From;

		// Token: 0x0400029B RID: 667
		public float Amount;

		// Token: 0x0400029C RID: 668
		public DateTime Date;

		// Token: 0x0400029D RID: 669
		public long ID;

		// Token: 0x0400029E RID: 670
		public BankAccount Account;

		// Token: 0x0400029F RID: 671
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x040002A0 RID: 672
		protected static Font font2;

		// Token: 0x040002A1 RID: 673
		protected static Font fontL = new Font("Arial", 10f, FontStyle.Bold);

		// Token: 0x040002A2 RID: 674
		protected static Font fontXL = new Font("Arial", 24f, FontStyle.Bold);

		// Token: 0x040002A3 RID: 675
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x040002A4 RID: 676
		protected static Brush white = new SolidBrush(Color.White);

		// Token: 0x040002A5 RID: 677
		protected static Brush red = new SolidBrush(Color.FromArgb(128, 255, 0, 0));

		// Token: 0x040002A6 RID: 678
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x040002A7 RID: 679
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x040002A8 RID: 680
		protected static Pen pen = new Pen(Bill.brush, 1f);

		// Token: 0x040002A9 RID: 681
		protected int margin = 5;

		// Token: 0x040002AA RID: 682
		protected int col1Width = 120;

		// Token: 0x040002AB RID: 683
		protected int colWidth = 60;
	}
}
