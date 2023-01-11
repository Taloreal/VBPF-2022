using System;
using System.Collections;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for BankAccount.
	/// </summary>
	// Token: 0x02000016 RID: 22
	[Serializable]
	public class BankAccount : Offering
	{
		// Token: 0x06000063 RID: 99 RVA: 0x000081AC File Offset: 0x000071AC
		public BankAccount()
		{
			this.GenerateNewAccountNumber();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00008200 File Offset: 0x00007200
		public BankAccount(string bankName, string ownerName)
		{
			this.GenerateNewAccountNumber();
			this.BankName = bankName;
			this.OwnerName = ownerName;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00008260 File Offset: 0x00007260
		static BankAccount()
		{
			BankAccount.sfr.Alignment = StringAlignment.Far;
			BankAccount.sfc.Alignment = StringAlignment.Center;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000082FB File Offset: 0x000072FB
		public void GenerateNewAccountNumber()
		{
			this.ID = 1000L + A.ST.GetNextID();
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00008318 File Offset: 0x00007318
		public long AccountNumber
		{
			get
			{
				return this.ID;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00008330 File Offset: 0x00007330
		public virtual string AccountTypeFriendlyName
		{
			get
			{
				return A.R.GetString("Bank");
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00008354 File Offset: 0x00007354
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				this.AccountTypeFriendlyName,
				" ",
				this.BankName,
				" #",
				this.AccountNumber
			});
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000083A4 File Offset: 0x000073A4
		public string BankURL
		{
			get
			{
				return "www." + this.BankName.Replace(" ", "") + ".com";
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000083DC File Offset: 0x000073DC
		public ArrayList TransactionsForMonth(int year, int month)
		{
			ArrayList temp = new ArrayList();
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Date >= BankAccount.FirstDayOfCycle(year, month) && t.Date < BankAccount.LastDayOfCycle(year, month))
				{
					temp.Add(t);
				}
			}
			return temp;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00008488 File Offset: 0x00007488
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000084A0 File Offset: 0x000074A0
		public float InterestRate
		{
			get
			{
				return this.interestRate;
			}
			set
			{
				this.interestRate = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000084AC File Offset: 0x000074AC
		public DateTime DateOpened
		{
			get
			{
				return ((Transaction)this.Transactions[0]).Date;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000084D4 File Offset: 0x000074D4
		public float EndingBalance()
		{
			return this.EndingBalance(9999, 1);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000084F4 File Offset: 0x000074F4
		public float EndingBalance(int year, int month)
		{
			float balance = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Date < BankAccount.LastDayOfCycle(year, month))
				{
					if (t.Type == Transaction.TranType.Debit)
					{
						balance -= t.Amount;
					}
					else
					{
						balance += t.Amount;
					}
					balance = (float)Math.Round((double)balance, 2);
				}
			}
			return balance;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000085B4 File Offset: 0x000075B4
		public float EndingBalance(DateTime date)
		{
			float balance = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Date > date)
				{
					break;
				}
				if (t.Type == Transaction.TranType.Debit)
				{
					balance -= t.Amount;
				}
				else
				{
					balance += t.Amount;
				}
				balance = (float)Math.Round((double)balance, 2);
			}
			return balance;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000866C File Offset: 0x0000766C
		public override string ThingName()
		{
			return A.R.GetString("Products");
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00008690 File Offset: 0x00007690
		public float BalanceThru(Transaction last)
		{
			float balance = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Debit)
				{
					balance -= t.Amount;
				}
				else
				{
					balance += t.Amount;
				}
				balance = (float)Math.Round((double)balance, 2);
				if (t == last)
				{
					break;
				}
			}
			return balance;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00008740 File Offset: 0x00007740
		public float AverageDailyBalance(int year, int month)
		{
			ArrayList transThisMonth = this.TransactionsForMonth(year, month);
			float bal = this.BeginningBalance(year, month);
			float total = 0f;
			int beginDay = 1;
			if (this.DateOpened.Year == year && this.DateOpened.Month == month)
			{
				beginDay = this.DateOpened.Day;
			}
			int daysCounted = 0;
			for (int day = beginDay; day <= DateTime.DaysInMonth(year, month); day++)
			{
				while (transThisMonth.Count > 0 && ((Transaction)transThisMonth[0]).Date.Day == day)
				{
					Transaction t = (Transaction)transThisMonth[0];
					if (t.Type == Transaction.TranType.Debit)
					{
						bal -= t.Amount;
					}
					else
					{
						bal += t.Amount;
					}
					bal = (float)Math.Round((double)bal, 2);
					transThisMonth.RemoveAt(0);
				}
				total += bal;
				total = (float)Math.Round((double)total, 2);
				daysCounted++;
			}
			return (float)Math.Round((double)(total / (float)daysCounted), 2);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00008874 File Offset: 0x00007874
		public float BeginningBalance(int year, int month)
		{
			if (month == 1)
			{
				month = 12;
				year--;
			}
			else
			{
				month--;
			}
			return this.EndingBalance(year, month);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000088AC File Offset: 0x000078AC
		public virtual void EndMonth()
		{
			int year = A.ST.Year;
			int month = A.ST.Month;
			float avgDailyBalance = this.AverageDailyBalance(year, month);
			float interest = this.interestRate / 12f * avgDailyBalance;
			if (this.DateOpened.Year == year && this.DateOpened.Month == month)
			{
				interest *= ((float)DateTime.DaysInMonth(year, month) - (float)this.DateOpened.Day) / (float)DateTime.DaysInMonth(year, month);
			}
			if (this.interestRate > 0f)
			{
				this.Transactions.Add(new Transaction(interest, Transaction.TranType.Credit, A.R.GetString("Interest earned"), A.ST.Now.AddDays(-1.0)));
			}
			if (avgDailyBalance < this.minimumBalance)
			{
				this.Transactions.Add(new Transaction(this.maintenanceFee, Transaction.TranType.Debit, A.R.GetString("Monthly account fee"), A.ST.Now.AddDays(1.0)));
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000089E8 File Offset: 0x000079E8
		public float Credits(int year, int month)
		{
			float total = 0f;
			ArrayList temp = this.TransactionsForMonth(year, month);
			foreach (object obj in temp)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Credit)
				{
					total += t.Amount;
					total = (float)Math.Round((double)total, 2);
				}
			}
			return total;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00008A88 File Offset: 0x00007A88
		public float Debits(int year, int month)
		{
			float total = 0f;
			ArrayList temp = this.TransactionsForMonth(year, month);
			foreach (object obj in temp)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Debit)
				{
					total += t.Amount;
					total = (float)Math.Round((double)total, 2);
				}
			}
			return total;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00008B28 File Offset: 0x00007B28
		public float Debits(int year, int month, int day)
		{
			float total = 0f;
			ArrayList temp = this.TransactionsForMonth(year, month);
			foreach (object obj in temp)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Debit && t.Date.Day <= day)
				{
					total += t.Amount;
					total = (float)Math.Round((double)total, 2);
				}
			}
			return total;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008BD4 File Offset: 0x00007BD4
		public virtual void PrintPage(int page, Graphics g, int year, int month, int Pages, int TransactionsPerPage)
		{
			int y = this.margin;
			int headerx = 200;
			ArrayList transThisMonth = this.TransactionsForMonth(year, month);
			g.DrawImageUnscaled(A.R.GetImage("Logo" + this.BankName), 4, 4);
			g.DrawString(A.R.GetString("Page {0} of {1}", new object[]
			{
				page + 1,
				Pages
			}), BankAccount.font, BankAccount.brush, 320f, (float)y, BankAccount.sfr);
			y += 30;
			g.DrawString(this.OwnerName, BankAccount.font, BankAccount.brush, (float)headerx, (float)y);
			y += 12;
			g.DrawString(A.R.GetString("Account Number: {0}", new object[]
			{
				this.AccountNumber
			}), BankAccount.font, BankAccount.brush, (float)headerx, (float)y);
			y += 12;
			g.DrawString(A.R.GetString("Statement Date: {0}", new object[]
			{
				new DateTime(year, month, 28).ToShortDateString()
			}), BankAccount.font, BankAccount.brush, (float)headerx, (float)y);
			y += 25;
			g.DrawLine(BankAccount.pen, 0, y, 400, y);
			y += 2;
			g.DrawLine(BankAccount.pen, 0, y, 400, y);
			string[] headers = new string[]
			{
				A.R.GetString("Beginning Balance"),
				A.R.GetString("Credits (+)"),
				A.R.GetString("Debits (-)"),
				A.R.GetString("Ending Balance")
			};
			string[] data = new string[]
			{
				this.BeginningBalance(year, month).ToString("C2"),
				this.Credits(year, month).ToString("C2"),
				this.Debits(year, month).ToString("C2"),
				this.EndingBalance(year, month).ToString("C2")
			};
			for (int c = 0; c < 4; c++)
			{
				g.DrawString(headers[c], BankAccount.fontS, BankAccount.brush, 90f * ((float)c + 0.5f), (float)(y + this.margin), BankAccount.sfc);
				g.DrawLine(BankAccount.pen, c * 90, y, c * 90, y + 40);
				g.DrawString(data[c], BankAccount.font, BankAccount.brush, 90f * ((float)c + 0.5f), (float)(y + 20 + this.margin), BankAccount.sfc);
			}
			y += 20;
			g.DrawLine(BankAccount.pen, 0, y, 400, y);
			y += 20;
			g.DrawLine(BankAccount.pen, 0, y, 400, y);
			y += 2;
			g.DrawLine(BankAccount.pen, 0, y, 400, y);
			for (int c = 0; c < 4; c++)
			{
				int adjust = 0;
				if (c == 3)
				{
					adjust = -this.margin;
				}
				g.DrawLine(BankAccount.pen, this.col1Width + c * this.colWidth + adjust, y, this.col1Width + c * this.colWidth + adjust, 600);
			}
			y += this.margin;
			string[] titles = new string[]
			{
				A.R.GetString("Description"),
				A.R.GetString("Debits"),
				A.R.GetString("Credits"),
				A.R.GetString("Date"),
				A.R.GetString("Balance")
			};
			g.DrawString(titles[0], BankAccount.fontS, BankAccount.brush, (float)(this.col1Width / 2), (float)y, BankAccount.sfc);
			for (int c = 1; c < 5; c++)
			{
				g.DrawString(titles[c], BankAccount.fontS, BankAccount.brush, (float)this.col1Width + ((float)c - 0.5f) * (float)this.colWidth, (float)y, BankAccount.sfc);
			}
			y += 20;
			g.DrawLine(BankAccount.pen, 0, y, 400, y);
			y += this.margin;
			for (int i = page * TransactionsPerPage; i < Math.Min((page + 1) * TransactionsPerPage, transThisMonth.Count); i++)
			{
				Transaction t = (Transaction)transThisMonth[i];
				g.DrawString(t.Description, BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
				if (t.Type == Transaction.TranType.Debit)
				{
					g.DrawString(t.Amount.ToString("N2"), BankAccount.font, BankAccount.brush, (float)(this.col1Width + this.colWidth - this.margin), (float)y, BankAccount.sfr);
				}
				else
				{
					g.DrawString(t.Amount.ToString("N2"), BankAccount.font, BankAccount.brush, (float)(this.col1Width + 2 * this.colWidth - this.margin), (float)y, BankAccount.sfr);
				}
				g.DrawString(t.Date.ToString("M/d"), BankAccount.font, BankAccount.brush, (float)(this.col1Width + 3 * this.colWidth - 2 * this.margin), (float)y, BankAccount.sfr);
				g.DrawString(this.BalanceThru(t).ToString("N2"), BankAccount.font, BankAccount.brush, (float)(this.col1Width + 4 * this.colWidth - this.margin), (float)y, BankAccount.sfr);
				y += 11;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000091F0 File Offset: 0x000081F0
		public BankAccount.Status PastDueStatus(int y, int m)
		{
			BankAccount.Status temp = this.PastDueStatusPassive(y, m);
			if (temp == BankAccount.Status.Cancelled && this.status != BankAccount.Status.Cancelled && this.status != BankAccount.Status.NewlyCancelled)
			{
				this.status = BankAccount.Status.NewlyCancelled;
			}
			else
			{
				this.status = temp;
			}
			return this.status;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00009240 File Offset: 0x00008240
		public virtual BankAccount.Status PastDueStatusPassive(int y, int m)
		{
			int d = this.DaysPastDue(new DateTime(y, m, 28));
			BankAccount.Status result;
			if (d >= 60)
			{
				result = BankAccount.Status.Cancelled;
			}
			else if (d >= 30)
			{
				result = BankAccount.Status.Deliquent;
			}
			else if (d > 0)
			{
				result = BankAccount.Status.PastDue;
			}
			else
			{
				result = BankAccount.Status.Current;
			}
			return result;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000928C File Offset: 0x0000828C
		public void StampStatus(Graphics g, int year, int month)
		{
			Font fontL = new Font("Arial", 10f, FontStyle.Bold);
			Font fontXL = new Font("Arial", 24f, FontStyle.Bold);
			Brush red = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
			BankAccount.Status status = this.PastDueStatusPassive(year, month);
			if (status == BankAccount.Status.PastDue)
			{
				g.DrawString(A.R.GetString("Past Due"), fontXL, red, g.ClipBounds.Width / 2f, g.ClipBounds.Height / 2f, BankAccount.sfc);
			}
			if (status == BankAccount.Status.Deliquent)
			{
				g.DrawString(A.R.GetString("Deliquent"), fontXL, red, g.ClipBounds.Width / 2f, g.ClipBounds.Height / 2f, BankAccount.sfc);
				g.DrawString(A.R.GetString("Pay immediately."), fontL, red, g.ClipBounds.Width / 2f, g.ClipBounds.Height / 2f + 60f, BankAccount.sfc);
			}
			if (status == BankAccount.Status.Cancelled)
			{
				g.DrawString(A.R.GetString("In Collection"), fontXL, red, g.ClipBounds.Width / 2f, g.ClipBounds.Height / 2f, BankAccount.sfc);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000942C File Offset: 0x0000842C
		public float CurrentCharges(DateTime now)
		{
			float total = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Credit && (now - t.Date).Days <= 30)
				{
					total += t.Amount;
					total = (float)Math.Round((double)total, 2);
				}
			}
			return total;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000094DC File Offset: 0x000084DC
		public virtual float PastDueAmount(DateTime now)
		{
			return this.EndingBalance(now) - this.CurrentCharges(now);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00009500 File Offset: 0x00008500
		public virtual int DaysPastDue(DateTime now)
		{
			float totalPayments = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Type == Transaction.TranType.Debit)
				{
					totalPayments += t.Amount;
					totalPayments = (float)Math.Round((double)totalPayments, 2);
				}
			}
			foreach (object obj2 in this.Transactions)
			{
				Transaction t = (Transaction)obj2;
				if (t.Type == Transaction.TranType.Credit)
				{
					totalPayments -= t.Amount;
					totalPayments = (float)Math.Round((double)totalPayments, 2);
					if ((double)totalPayments < -0.01)
					{
						int days = (now - t.Date).Days - 30;
						return Math.Max(0, days);
					}
				}
			}
			return 0;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00009654 File Offset: 0x00008654
		public string CRStatus(DateTime now)
		{
			string s = "O";
			if (this is InstallmentLoan)
			{
				s = "I";
			}
			if (this is CreditCardAccount)
			{
				s = "R";
			}
			int i = this.DaysPastDue(now);
			if (i > 0)
			{
				i = i / 30 + 2;
			}
			else
			{
				i = 1;
			}
			return s + i;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000096C4 File Offset: 0x000086C4
		public static void PreviousMonth(ref int year, ref int month)
		{
			month--;
			if (month == 0)
			{
				month = 12;
				year--;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000096F0 File Offset: 0x000086F0
		public static DateTime FirstDayOfCycle(int year, int month)
		{
			BankAccount.PreviousMonth(ref year, ref month);
			return new DateTime(year, month, 28, 0, 0, 0);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00009718 File Offset: 0x00008718
		public static DateTime LastDayOfCycle(int year, int month)
		{
			return new DateTime(year, month, 28, 0, 0, 0);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00009738 File Offset: 0x00008738
		public int MonthsOpen(DateTime now)
		{
			int y = this.DateOpened.Year;
			int i = this.DateOpened.Month;
			int d = 28;
			int j = 0;
			while (new DateTime(y, i, d) <= now)
			{
				i++;
				if (i > 12)
				{
					i = 1;
					y++;
				}
				j++;
			}
			return j;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000097A8 File Offset: 0x000087A8
		public void ZeroOut()
		{
		}

		// Token: 0x040000C3 RID: 195
		public ArrayList Transactions = new ArrayList();

		// Token: 0x040000C4 RID: 196
		public string BankName;

		// Token: 0x040000C5 RID: 197
		public string OwnerName;

		// Token: 0x040000C6 RID: 198
		public DateTime DateClosed = DateTime.MaxValue;

		// Token: 0x040000C7 RID: 199
		protected float maintenanceFee;

		// Token: 0x040000C8 RID: 200
		protected float interestRate;

		// Token: 0x040000C9 RID: 201
		protected float minimumBalance;

		// Token: 0x040000CA RID: 202
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x040000CB RID: 203
		protected static Font fontS = new Font("Arial", 7f);

		// Token: 0x040000CC RID: 204
		protected static Font bankNameFont = new Font("Times New Roman", 16f, FontStyle.Italic);

		// Token: 0x040000CD RID: 205
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x040000CE RID: 206
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x040000CF RID: 207
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x040000D0 RID: 208
		protected static Pen pen = new Pen(BankAccount.brush, 1f);

		// Token: 0x040000D1 RID: 209
		protected int margin = 5;

		// Token: 0x040000D2 RID: 210
		protected int col1Width = 120;

		// Token: 0x040000D3 RID: 211
		protected int colWidth = 60;

		// Token: 0x040000D4 RID: 212
		protected BankAccount.Status status = BankAccount.Status.Current;

		// Token: 0x02000017 RID: 23
		public enum Status
		{
			// Token: 0x040000D6 RID: 214
			Current,
			// Token: 0x040000D7 RID: 215
			PastDue,
			// Token: 0x040000D8 RID: 216
			Deliquent,
			// Token: 0x040000D9 RID: 217
			NewlyCancelled,
			// Token: 0x040000DA RID: 218
			Cancelled
		}
	}
}
