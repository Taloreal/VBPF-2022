using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPersonalBalanceSheet.
	/// </summary>
	// Token: 0x020000A4 RID: 164
	public partial class frmPersonalBalanceSheet : frmDrawnReport
	{
		// Token: 0x060004F5 RID: 1269 RVA: 0x0004735E File Offset: 0x0004635E
		public frmPersonalBalanceSheet()
		{
			this.InitializeComponent();
			A.MF.NewDay += this.NewDayHandler;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0004742C File Offset: 0x0004642C
		protected override void DrawReportVirtual(Graphics g)
		{
			frmPersonalBalanceSheet.sfc.Alignment = StringAlignment.Center;
			frmPersonalBalanceSheet.sfr.Alignment = StringAlignment.Far;
			int w = this.picReport.Width;
			int i = 10;
			int xentry = 300;
			int xtotal = 370;
			int y = 5;
			g.DrawString(A.R.GetString("Personal Balance Sheet as of {0}", new object[]
			{
				this.input.now.ToShortDateString()
			}), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, (float)(w / 2), (float)y, frmPersonalBalanceSheet.sfc);
			y += 35;
			g.DrawString(A.R.GetString("Assets"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, (float)(i * 14), (float)y);
			y += 25;
			g.DrawString(A.R.GetString("Liquid Assets"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			y += 25;
			float totalLiquid = 0f;
			g.DrawString(A.R.GetString("Cash"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
			g.DrawString(Utilities.FC(this.input.cash, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			totalLiquid += this.input.cash;
			foreach (object obj in this.input.bankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				g.DrawString(ba.ToString(), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
				g.DrawString(Utilities.FC(ba.EndingBalance(), A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
				y += 25;
				totalLiquid += ba.EndingBalance();
			}
			g.DrawLine(frmPersonalBalanceSheet.p, xentry - 50, y - 10, xentry, y - 10);
			g.DrawString(A.R.GetString("Total liquid assets"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)(2 * i), (float)y);
			g.DrawString(Utilities.FC(totalLiquid, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Investment Assets"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			y += 25;
			float totalInvest = 0f;
			foreach (object obj2 in this.input.investmentAccounts.Values)
			{
				InvestmentAccount account = (InvestmentAccount)obj2;
				g.DrawString(account.Fund.Name, frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
				g.DrawString(Utilities.FC(account.Value, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
				totalInvest += account.Value;
				y += 25;
			}
			g.DrawLine(frmPersonalBalanceSheet.p, xentry - 50, y - 10, xentry, y - 10);
			g.DrawString(A.R.GetString("Total investment assets"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)(2 * i), (float)y);
			g.DrawString(Utilities.FC(totalInvest, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Retirement Assets"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			y += 25;
			float totalRetire = 0f;
			foreach (object obj3 in this.input.retirementAccounts.Values)
			{
				InvestmentAccount account = (InvestmentAccount)obj3;
				g.DrawString(account.Fund.Name, frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
				g.DrawString(Utilities.FC(account.Value, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
				totalRetire += account.Value;
				y += 25;
			}
			g.DrawLine(frmPersonalBalanceSheet.p, xentry - 50, y - 10, xentry, y - 10);
			g.DrawString(A.R.GetString("Total retirement assets"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)(2 * i), (float)y);
			g.DrawString(Utilities.FC(totalRetire, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			float totalReal = 0f;
			g.DrawString(A.R.GetString("Real Property"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			y += 25;
			if (this.input.carValue > 0f)
			{
				g.DrawString(A.R.GetString("Car"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
				g.DrawString(Utilities.FC(this.input.carValue, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
				y += 25;
			}
			g.DrawString(A.R.GetString("Real Estate"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
			g.DrawString(Utilities.FC(this.input.realEstateValue, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawLine(frmPersonalBalanceSheet.p, xentry - 50, y - 10, xentry, y - 10);
			g.DrawString(A.R.GetString("Total real property"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)(2 * i), (float)y);
			totalReal = this.input.carValue + this.input.realEstateValue;
			g.DrawString(Utilities.FC(totalReal, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Total Assets"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			g.DrawString(Utilities.FC(totalLiquid + totalInvest + totalRetire + totalReal, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawLine(frmPersonalBalanceSheet.p, xtotal - 50, y - 10, xtotal, y - 10);
			g.DrawLine(frmPersonalBalanceSheet.p, xtotal - 50, y - 7, xtotal, y - 7);
			y += 10;
			g.DrawString(A.R.GetString("Liabilities"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, (float)(i * 14), (float)y);
			y += 25;
			g.DrawString(A.R.GetString("Current Liabilities"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			y += 25;
			float totalCurrent = 0f;
			float totalCC = 0f;
			foreach (object obj4 in this.input.creditCardAccounts.Values)
			{
				CreditCardAccount cc = (CreditCardAccount)obj4;
				totalCC += cc.EndingBalance();
			}
			g.DrawString(A.R.GetString("Credit Card Balances"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
			g.DrawString(Utilities.FC(totalCC, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
			totalCurrent += totalCC;
			y += 25;
			if (this.input.includeOtherLiabilities)
			{
				float totalOC = 0f;
				foreach (object obj5 in this.input.merchantAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj5;
					if (ba.EndingBalance() > 0f)
					{
						totalOC += ba.EndingBalance();
					}
				}
				g.DrawString(A.R.GetString("Other Liabilities"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
				g.DrawString(Utilities.FC(totalOC, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
				totalCurrent += totalOC;
				y += 25;
			}
			g.DrawLine(frmPersonalBalanceSheet.p, xentry - 50, y - 10, xentry, y - 10);
			g.DrawString(A.R.GetString("Total current liabilities"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)(2 * i), (float)y);
			g.DrawString(Utilities.FC(totalCurrent, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Long-term Liabilities"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			y += 25;
			float totalLongTerm = 0f;
			foreach (object obj6 in this.input.installmentLoans.Values)
			{
				InstallmentLoan j = (InstallmentLoan)obj6;
				g.DrawString(j.BankName, frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)i, (float)y);
				g.DrawString(Utilities.FC(j.EndingBalance(), A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xentry, (float)y, frmPersonalBalanceSheet.sfr);
				totalLongTerm += j.EndingBalance();
				y += 25;
			}
			g.DrawLine(frmPersonalBalanceSheet.p, xentry - 50, y - 10, xentry, y - 10);
			g.DrawString(A.R.GetString("Total long-term liabilities"), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)(2 * i), (float)y);
			g.DrawString(Utilities.FC(totalLongTerm, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawString(A.R.GetString("Total Liabilities"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			g.DrawString(Utilities.FC(totalCurrent + totalLongTerm, A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawLine(frmPersonalBalanceSheet.p, xtotal - 50, y - 10, xtotal, y - 10);
			g.DrawLine(frmPersonalBalanceSheet.p, xtotal - 50, y - 7, xtotal, y - 7);
			y += 10;
			g.DrawString(A.R.GetString("Net Worth"), frmPersonalBalanceSheet.fb, frmPersonalBalanceSheet.b, 0f, (float)y);
			g.DrawString(Utilities.FC(totalLiquid + totalInvest + totalRetire + totalReal - (totalCurrent + totalLongTerm), A.I.CurrencyConversion), frmPersonalBalanceSheet.fs, frmPersonalBalanceSheet.b, (float)xtotal, (float)y, frmPersonalBalanceSheet.sfr);
			y += 25;
			g.DrawLine(frmPersonalBalanceSheet.p, xtotal - 50, y - 10, xtotal, y - 10);
			g.DrawLine(frmPersonalBalanceSheet.p, xtotal - 50, y - 7, xtotal, y - 7);
			y += 10;
			this.picReport.Height = y + 50;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00048174 File Offset: 0x00047174
		protected override void GetDataVirtual()
		{
			this.input = A.SA.GetPersonalBalanceSheet(A.MF.CurrentEntityID);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00048191 File Offset: 0x00047191
		protected override void frmReport_Closed(object sender, EventArgs e)
		{
			base.frmReport_Closed(sender, e);
			A.MF.NewDay -= this.NewDayHandler;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000481B4 File Offset: 0x000471B4
		protected void NewDayHandler(object sender, EventArgs e)
		{
			if (base.GetData())
			{
				this.picReport.Refresh();
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005E0 RID: 1504
		private Container components = null;

		// Token: 0x040005E1 RID: 1505
		private static Brush b = new SolidBrush(Color.Black);

		// Token: 0x040005E2 RID: 1506
		private static Font f = new Font("Arial", 9f);

		// Token: 0x040005E3 RID: 1507
		private static Font fs = new Font("Arial", 8f);

		// Token: 0x040005E4 RID: 1508
		private static Font fb = new Font("Arial", 9f, FontStyle.Bold);

		// Token: 0x040005E5 RID: 1509
		private static StringFormat sfc = new StringFormat();

		// Token: 0x040005E6 RID: 1510
		private static StringFormat sfr = new StringFormat();

		// Token: 0x040005E7 RID: 1511
		private static Pen p = new Pen(frmPersonalBalanceSheet.b, 1f);

		// Token: 0x040005E8 RID: 1512
		protected frmPersonalBalanceSheet.Input input;

		// Token: 0x020000A5 RID: 165
		[Serializable]
		public struct Input
		{
			// Token: 0x040005E9 RID: 1513
			public DateTime now;

			// Token: 0x040005EA RID: 1514
			public float cash;

			// Token: 0x040005EB RID: 1515
			public SortedList bankAccounts;

			// Token: 0x040005EC RID: 1516
			public SortedList investmentAccounts;

			// Token: 0x040005ED RID: 1517
			public SortedList retirementAccounts;

			// Token: 0x040005EE RID: 1518
			public float realEstateValue;

			// Token: 0x040005EF RID: 1519
			public SortedList creditCardAccounts;

			// Token: 0x040005F0 RID: 1520
			public Hashtable merchantAccounts;

			// Token: 0x040005F1 RID: 1521
			public SortedList installmentLoans;

			// Token: 0x040005F2 RID: 1522
			public float carValue;

			// Token: 0x040005F3 RID: 1523
			public bool includeOtherLiabilities;
		}
	}
}
