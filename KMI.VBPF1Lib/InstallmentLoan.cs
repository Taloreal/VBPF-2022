using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for InstallmentLoan.
	/// </summary>
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class InstallmentLoan : BankAccount
	{
		// Token: 0x06000244 RID: 580 RVA: 0x00025A2C File Offset: 0x00024A2C
		public InstallmentLoan(DateTime date, float amount, float interestRate, int term)
		{
			this.originalBalance = amount;
			this.originationDate = date;
			this.interestRate = interestRate;
			this.term = term;
			this.ReComputePayment();
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00025A78 File Offset: 0x00024A78
		public float Payment
		{
			get
			{
				return this.payment;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00025A90 File Offset: 0x00024A90
		public int Term
		{
			get
			{
				return this.term;
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00025AA8 File Offset: 0x00024AA8
		public int PaymentsRemaining(int year, int month)
		{
			float balance = base.EndingBalance(year, month);
			int i = 0;
			while (i < this.Term && balance > 0f)
			{
				balance += balance * base.InterestRate / 12f - this.Payment;
				i++;
			}
			return i;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00025B00 File Offset: 0x00024B00
		public void ReComputePayment()
		{
			int months = this.term;
			float hi = 100000f;
			float lo = 1f;
			float pay = 500f;
			if (this.originalBalance == 0f)
			{
				this.payment = 0f;
			}
			else
			{
				while (Math.Abs(lo - hi) > 0.01f)
				{
					float balance = this.originalBalance;
					for (int i = 0; i < months; i++)
					{
						balance = balance * (1f + this.interestRate / 12f) - pay;
					}
					if (balance < 0f)
					{
						hi = pay;
					}
					else
					{
						lo = pay;
					}
					pay = (lo + hi) / 2f;
				}
				this.payment = (float)Math.Round((double)hi, 2);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00025BDC File Offset: 0x00024BDC
		// (set) Token: 0x06000249 RID: 585 RVA: 0x00025BD1 File Offset: 0x00024BD1
		public float OriginalBalance
		{
			get
			{
				return this.originalBalance;
			}
			set
			{
				this.originalBalance = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00025BF4 File Offset: 0x00024BF4
		public DateTime OriginationDate
		{
			get
			{
				return this.originationDate;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00025C0C File Offset: 0x00024C0C
		public override void PrintPage(int page, Graphics g, int year, int month, int Pages, int TransactionsPerPage)
		{
			int y = this.margin;
			int headerx = 180;
			int xright = 310;
			int lineSpace = 15;
			int x2 = 50;
			int nextMonth = month + 1;
			int yearOfNextMonth = year;
			if (nextMonth == 13)
			{
				nextMonth = 1;
				yearOfNextMonth = year + 1;
			}
			DateTime endOfThisMonth = new DateTime(year, month, 28);
			DateTime endOfNextMonth = new DateTime(yearOfNextMonth, nextMonth, 28);
			DateTime paymentDue = endOfNextMonth;
			if (this.BeginBilling.AddDays(30.0) > paymentDue)
			{
				paymentDue = this.BeginBilling.AddDays(30.0);
			}
			StringFormat sfcb = new StringFormat(BankAccount.sfc);
			sfcb.LineAlignment = StringAlignment.Far;
			ArrayList transThisMonth = base.TransactionsForMonth(year, month);
			g.DrawImageUnscaled(A.R.GetImage("Logo" + this.BankName), 2, 4);
			y += 20;
			g.DrawString(A.R.GetString("Installment Loan"), InstallmentLoan.titleFont, BankAccount.brush, (float)headerx, (float)y);
			y += 20;
			g.DrawString(A.R.GetString("Monthly Statement"), InstallmentLoan.titleFont, BankAccount.brush, (float)headerx, (float)y);
			y += 40;
			g.DrawString(A.R.GetString("Payment Information"), InstallmentLoan.headerFont, BankAccount.brush, (float)this.margin, (float)y);
			y += 20;
			g.DrawLine(BankAccount.pen, this.margin, y, xright, y);
			y += 10;
			g.DrawString(A.R.GetString("Statement Date:"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(new DateTime(year, month, 28).ToShortDateString(), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += lineSpace;
			g.DrawString(A.R.GetString("Payment Due Date:"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(paymentDue.ToShortDateString(), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 2 * lineSpace;
			g.DrawString(A.R.GetString("Current Payment Due"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(Utilities.FC(this.Payment, 2, A.I.CurrencyConversion), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += lineSpace;
			g.DrawString(A.R.GetString("Past Due Payments"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(Utilities.FC(this.PastDueAmount(endOfThisMonth), 2, A.I.CurrencyConversion), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += lineSpace;
			g.DrawString(A.R.GetString("Total Amount Due"), InstallmentLoan.fontB, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(Utilities.FC(this.Payment + this.PastDueAmount(endOfThisMonth), 2, A.I.CurrencyConversion), InstallmentLoan.fontB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 2 * lineSpace;
			g.DrawString(A.R.GetString("Payoff Summary"), InstallmentLoan.fontB, BankAccount.brush, (float)this.margin, (float)y);
			y += lineSpace;
			g.DrawString(A.R.GetString("Payoff Amount"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(Utilities.FC(base.EndingBalance(year, month), 2, A.I.CurrencyConversion), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += lineSpace;
			g.DrawString(A.R.GetString("Payoff Good Through", new object[]
			{
				Utilities.FC(-99f, 2, A.I.CurrencyConversion)
			}), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(paymentDue.ToShortDateString(), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Account Information"), InstallmentLoan.headerFont, BankAccount.brush, (float)this.margin, (float)y);
			y += 20;
			g.DrawLine(BankAccount.pen, this.margin, y, xright, y);
			y += 10;
			g.DrawString(A.R.GetString("Account Number"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(base.AccountNumber.ToString(), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += lineSpace;
			g.DrawString(A.R.GetString("Payments Remaining"), BankAccount.font, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(this.PaymentsRemaining(year, month).ToString(), BankAccount.font, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Activity Since Last Statement"), InstallmentLoan.headerFont, BankAccount.brush, (float)this.margin, (float)y);
			y += 20;
			g.DrawLine(BankAccount.pen, this.margin, y, xright, y);
			y += 10;
			g.DrawString(A.R.GetString("Date"), InstallmentLoan.fontSB, BankAccount.brush, (float)this.margin, (float)y);
			g.DrawString(A.R.GetString("Description"), InstallmentLoan.fontSB, BankAccount.brush, (float)(x2 + 5), (float)y);
			g.DrawString(A.R.GetString("Amount"), InstallmentLoan.fontSB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
			y += 2 * lineSpace;
			foreach (object obj in transThisMonth)
			{
				Transaction t = (Transaction)obj;
				g.DrawString(t.Date.ToShortDateString(), InstallmentLoan.fontSB, BankAccount.brush, (float)this.margin, (float)y);
				g.DrawString(t.Description, InstallmentLoan.fontSB, BankAccount.brush, (float)(x2 + 5), (float)y);
				int sign = 1;
				if (t.Type == Transaction.TranType.Debit)
				{
					sign = -1;
				}
				g.DrawString(Utilities.FC((float)sign * t.Amount, 2, A.I.CurrencyConversion), InstallmentLoan.fontSB, BankAccount.brush, (float)xright, (float)y, BankAccount.sfr);
				y += lineSpace;
			}
			base.StampStatus(g, year, month);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00026320 File Offset: 0x00025320
		public override void EndMonth()
		{
			if (A.ST.Now > this.BeginBilling)
			{
				this.Transactions.Add(new Transaction(base.EndingBalance() * this.interestRate / 12f, Transaction.TranType.Credit, "Interest", A.ST.Now.AddDays(-1.0)));
				this.Months++;
				float totalPaymentsInMonth = 0f;
				ArrayList temp = base.TransactionsForMonth(A.ST.Year, A.ST.Month);
				if (this.Months > 0)
				{
					foreach (object obj in temp)
					{
						Transaction t = (Transaction)obj;
						if (t.Type == Transaction.TranType.Debit)
						{
							totalPaymentsInMonth += t.Amount;
						}
					}
					this.UnpaidAmounts.Add(Math.Max(0f, this.Payment - totalPaymentsInMonth));
					if (totalPaymentsInMonth > this.Payment)
					{
						totalPaymentsInMonth -= this.Payment;
						for (int i = 0; i < this.UnpaidAmounts.Count; i++)
						{
							if ((float)this.UnpaidAmounts[i] > 0f)
							{
								float apply = Math.Min(totalPaymentsInMonth, (float)this.UnpaidAmounts[i]);
								this.UnpaidAmounts[i] = (float)this.UnpaidAmounts[i] - apply;
								totalPaymentsInMonth -= apply;
							}
							if ((double)totalPaymentsInMonth < 0.01)
							{
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00026538 File Offset: 0x00025538
		public override float PastDueAmount(DateTime now)
		{
			float total = 0f;
			foreach (object obj in this.UnpaidAmounts)
			{
				float f = (float)obj;
				total += f;
			}
			return total;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000265AC File Offset: 0x000255AC
		public override int DaysPastDue(DateTime now)
		{
			int i = this.UnpaidAmounts.Count - 1;
			int count = 0;
			while (i >= 0 && (double)((float)this.UnpaidAmounts[i]) > 0.01)
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

		// Token: 0x06000250 RID: 592 RVA: 0x0002661C File Offset: 0x0002561C
		public int OnTimePayments()
		{
			int count = 0;
			int good = 0;
			while (this.UnpaidAmounts.Count - count - 1 >= 0 && count < 36)
			{
				if ((float)this.UnpaidAmounts[this.UnpaidAmounts.Count - count - 1] == 0f)
				{
					good++;
				}
				count++;
			}
			return good;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0002668C File Offset: 0x0002568C
		public int MissedPayments()
		{
			int count = 0;
			int bad = 0;
			while (this.UnpaidAmounts.Count - count - 1 >= 0 && count < 36)
			{
				if ((float)this.UnpaidAmounts[this.UnpaidAmounts.Count - count - 1] > 0f)
				{
					bad++;
				}
				count++;
			}
			return bad;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000252 RID: 594 RVA: 0x000266FC File Offset: 0x000256FC
		public override string AccountTypeFriendlyName
		{
			get
			{
				return A.R.GetString("Loan");
			}
		}

		// Token: 0x040002AC RID: 684
		protected float payment;

		// Token: 0x040002AD RID: 685
		protected int term;

		// Token: 0x040002AE RID: 686
		public DateTime BeginBilling;

		// Token: 0x040002AF RID: 687
		protected float originalBalance;

		// Token: 0x040002B0 RID: 688
		protected DateTime originationDate;

		// Token: 0x040002B1 RID: 689
		protected static Font titleFont = new Font("Arial", 12f, FontStyle.Bold);

		// Token: 0x040002B2 RID: 690
		protected static Font headerFont = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Italic);

		// Token: 0x040002B3 RID: 691
		protected static Font fontB = new Font("Arial", 8f, FontStyle.Bold);

		// Token: 0x040002B4 RID: 692
		protected static Font fontSB = new Font("Arial", 7f, FontStyle.Bold);

		// Token: 0x040002B5 RID: 693
		public int Months = -1;

		// Token: 0x040002B6 RID: 694
		public ArrayList UnpaidAmounts = new ArrayList();
	}
}
