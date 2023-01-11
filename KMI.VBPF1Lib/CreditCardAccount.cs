using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for CreditCardAccount.
	/// </summary>
	// Token: 0x0200007D RID: 125
	[Serializable]
	public class CreditCardAccount : BankAccount
	{
		// Token: 0x06000323 RID: 803 RVA: 0x000357C4 File Offset: 0x000347C4
		public CreditCardAccount(float creditLimit, float interestRate, float latePaymentFee)
		{
			this.Transactions.Add(new Transaction(0f, Transaction.TranType.Credit, "Opening Balance"));
			this.creditLimit = creditLimit;
			this.interestRate = interestRate;
			this.latePaymentFee = latePaymentFee;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000324 RID: 804 RVA: 0x00035818 File Offset: 0x00034818
		public override string AccountTypeFriendlyName
		{
			get
			{
				return A.R.GetString("Credit Card");
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0003583C File Offset: 0x0003483C
		public float LatePaymentFee
		{
			get
			{
				return this.latePaymentFee;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000326 RID: 806 RVA: 0x00035854 File Offset: 0x00034854
		public float CreditLimit
		{
			get
			{
				return this.creditLimit;
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0003586C File Offset: 0x0003486C
		public override string Description()
		{
			return A.R.GetString("Credit card at low APR!. High credit limit. Click for your custom offer!.");
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00035890 File Offset: 0x00034890
		public override void EndMonth()
		{
			float avgDailyBalance = base.AverageDailyBalance(A.ST.Year, A.ST.Month);
			float credits = base.Debits(A.ST.Year, A.ST.Month);
			int lastMonth = A.ST.Month - 1;
			int yearOfLastMonth = A.ST.Year;
			if (lastMonth == 0)
			{
				lastMonth = 12;
				yearOfLastMonth--;
			}
			float previousBalance = base.EndingBalance(yearOfLastMonth, lastMonth);
			if (credits < previousBalance)
			{
				this.Transactions.Add(new Transaction(avgDailyBalance * this.interestRate / 12f, Transaction.TranType.Credit, "Finance Charges", A.ST.Now.AddDays(-1.0)));
			}
			float minDue = this.MinimumPayment(yearOfLastMonth, lastMonth);
			if (minDue == 0f)
			{
				this.PaidMin.Add(0);
			}
			else if (credits < minDue - 0.05f)
			{
				this.Transactions.Add(new Transaction(this.latePaymentFee, Transaction.TranType.Credit, A.R.GetString("Late Fee"), A.ST.Now.AddDays(-1.0)));
				this.PaidMin.Add(-1);
			}
			else
			{
				this.PaidMin.Add(1);
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00035A0C File Offset: 0x00034A0C
		public float MinimumPayment(int year, int month)
		{
			float min = 0.01f * base.EndingBalance(year, month);
			float result;
			if ((double)min < 0.01)
			{
				result = 0f;
			}
			else
			{
				result = min;
			}
			return result;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00035A4C File Offset: 0x00034A4C
		public float FinanceCharges(int year, int month)
		{
			ArrayList trans = base.TransactionsForMonth(year, month);
			float total = 0f;
			foreach (object obj in trans)
			{
				Transaction t = (Transaction)obj;
				if (t.Description == A.R.GetString("Finance Charges"))
				{
					total += t.Amount;
				}
			}
			return total;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00035AF0 File Offset: 0x00034AF0
		public float Payments(int year, int month)
		{
			ArrayList trans = base.TransactionsForMonth(year, month);
			float total = 0f;
			foreach (object obj in trans)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Debit)
				{
					total += t.Amount;
				}
			}
			return total;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00035B84 File Offset: 0x00034B84
		public override void PrintPage(int page, Graphics g, int year, int month, int Pages, int TransactionsPerPage)
		{
			int y = this.margin;
			int headerx = 200;
			ArrayList transThisMonth = base.TransactionsForMonth(year, month);
			g.DrawImageUnscaled(A.R.GetImage("Logo" + this.BankName), 4, 4);
			g.DrawString(A.R.GetString("Page {0} of {1}", new object[]
			{
				page + 1,
				Pages
			}), BankAccount.font, BankAccount.brush, 320f, (float)y, BankAccount.sfr);
			y += 25;
			g.DrawString(this.OwnerName, BankAccount.fontS, BankAccount.brush, (float)headerx, (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Account Number: {0}", new object[]
			{
				base.AccountNumber
			}), BankAccount.fontS, BankAccount.brush, (float)headerx, (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Statement Date: {0}", new object[]
			{
				new DateTime(year, month, 28).ToShortDateString()
			}), BankAccount.fontS, BankAccount.brush, (float)headerx, (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Credit Limit: {0}", new object[]
			{
				Utilities.FC(this.CreditLimit, 2, A.I.CurrencyConversion)
			}), BankAccount.fontS, BankAccount.brush, (float)headerx, (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Available Credit: {0}", new object[]
			{
				Utilities.FC(this.CreditLimit - base.EndingBalance(year, month), 2, A.I.CurrencyConversion)
			}), BankAccount.fontS, BankAccount.brush, (float)headerx, (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Minimum Payment: {0}", new object[]
			{
				Utilities.FC(this.MinimumPayment(year, month), 2, A.I.CurrencyConversion)
			}), BankAccount.fontS, BankAccount.brush, (float)headerx, (float)y);
			y += 25;
			StringFormat sfcb = new StringFormat(BankAccount.sfc);
			sfcb.LineAlignment = StringAlignment.Far;
			Font f = new Font("Times New Roman", 9f, FontStyle.Bold);
			g.DrawString(A.R.GetString("CARDHOLDER SUMMARY"), f, BankAccount.brush, (float)(this.margin + 166), (float)y, BankAccount.sfc);
			y += 15;
			g.DrawRectangle(BankAccount.pen, this.margin, y, 325, 45);
			g.DrawLine(BankAccount.pen, 55 + this.margin, y, 55 + this.margin, y + 45);
			g.DrawLine(BankAccount.pen, 270 + this.margin, y, 270 + this.margin, y + 45);
			g.DrawLine(BankAccount.pen, this.margin, y + 30, 325 + this.margin, y + 30);
			string[] headers = new string[]
			{
				A.R.GetString("Previous Balance"),
				A.R.GetString("- Payments"),
				A.R.GetString("- Credits"),
				A.R.GetString("+Purchases Fees"),
				A.R.GetString("+ Finance Charges"),
				A.R.GetString("= New Balance")
			};
			string[] data = new string[]
			{
				base.BeginningBalance(year, month).ToString("C2"),
				this.Payments(year, month).ToString("C2"),
				(base.Debits(year, month) - this.Payments(year, month)).ToString("C2"),
				(base.Credits(year, month) - this.FinanceCharges(year, month)).ToString("C2"),
				this.FinanceCharges(year, month).ToString("C2"),
				base.EndingBalance(year, month).ToString("C2")
			};
			for (int c = 0; c < 6; c++)
			{
				g.DrawString(headers[c], BankAccount.fontS, BankAccount.brush, new Rectangle(this.margin + 55 * c, y - 15, 55, 45), sfcb);
				g.DrawString(data[c], BankAccount.fontS, BankAccount.brush, new Rectangle(this.margin + 55 * c, y + 33, 55, 15), BankAccount.sfc);
			}
			y += 60;
			g.DrawString(A.R.GetString("CARDHOLDER ACTIVITY"), f, BankAccount.brush, (float)(this.margin + 166), (float)y, BankAccount.sfc);
			y += 15;
			g.DrawRectangle(BankAccount.pen, this.margin, y, 325, 262);
			g.DrawLine(BankAccount.pen, this.margin, y + 30, 325 + this.margin, y + 30);
			StringFormat sfb = new StringFormat();
			sfb.LineAlignment = StringAlignment.Far;
			headers = new string[]
			{
				A.R.GetString("Posting Date"),
				A.R.GetString("Transaction"),
				A.R.GetString("Amount")
			};
			g.DrawString(headers[0], BankAccount.fontS, BankAccount.brush, new Rectangle(this.margin, y, 40, 30), sfb);
			g.DrawString(headers[1], BankAccount.fontS, BankAccount.brush, new Rectangle(this.margin + 60, y, 250, 30), sfb);
			g.DrawString(headers[2], BankAccount.fontS, BankAccount.brush, new Rectangle(this.margin + 285, y, 50, 30), sfb);
			y += 35;
			for (int i = page * TransactionsPerPage; i < Math.Min((page + 1) * TransactionsPerPage, transThisMonth.Count); i++)
			{
				Transaction t = (Transaction)transThisMonth[i];
				g.DrawString(t.Date.ToString("MM-dd"), BankAccount.fontS, BankAccount.brush, (float)(2 * this.margin), (float)y);
				g.DrawString(t.Description, BankAccount.fontS, BankAccount.brush, (float)(this.margin + 60), (float)y);
				if (t.Type == Transaction.TranType.Credit)
				{
					g.DrawString(t.Amount.ToString("N2"), BankAccount.fontS, BankAccount.brush, 325f, (float)y, BankAccount.sfr);
				}
				else
				{
					g.DrawString(t.Amount.ToString("N2"), BankAccount.fontS, BankAccount.brush, 285f, (float)y, BankAccount.sfr);
				}
				y += 9;
			}
			base.StampStatus(g, year, month);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000362E4 File Offset: 0x000352E4
		public override int DaysPastDue(DateTime now)
		{
			int i = this.PaidMin.Count - 1;
			int count = 0;
			while (i >= 0 && (int)this.PaidMin[i] == -1)
			{
				count++;
				i--;
			}
			int result;
			if (count == 0)
			{
				result = 0;
			}
			else
			{
				result = 1 + (count - 1) * 30;
			}
			return result;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00036348 File Offset: 0x00035348
		public int OnTimePayments()
		{
			int count = 0;
			int good = 0;
			while (this.PaidMin.Count - count - 1 >= 0 && count < 36)
			{
				if ((int)this.PaidMin[this.PaidMin.Count - count - 1] == 1)
				{
					good++;
				}
				count++;
			}
			return good;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x000363B4 File Offset: 0x000353B4
		public int MissedPayments()
		{
			int count = 0;
			int bad = 0;
			while (this.PaidMin.Count - count - 1 >= 0 && count < 36)
			{
				if ((int)this.PaidMin[this.PaidMin.Count - count - 1] == -1)
				{
					bad++;
				}
				count++;
			}
			return bad;
		}

		// Token: 0x04000405 RID: 1029
		protected float creditLimit;

		// Token: 0x04000406 RID: 1030
		protected float latePaymentFee;

		// Token: 0x04000407 RID: 1031
		public ArrayList PaidMin = new ArrayList();
	}
}
