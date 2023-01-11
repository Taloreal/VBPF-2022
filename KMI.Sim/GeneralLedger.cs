using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	public class GeneralLedger
	{
		// Token: 0x06000108 RID: 264 RVA: 0x000085BE File Offset: 0x000075BE
		public GeneralLedger(string[] productNames)
		{
			this.productNames = productNames;
			GeneralLedger.sfr.Alignment = StringAlignment.Far;
			this.simStartDate = S.SS.StartDate;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00008600 File Offset: 0x00007600
		public string[] ProductNames
		{
			get
			{
				return this.productNames;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00008618 File Offset: 0x00007618
		public void AddAccount(string name, GeneralLedger.AccountType type)
		{
			if (type != GeneralLedger.AccountType.Product && type != GeneralLedger.AccountType.OtherProduct)
			{
				this.accounts.Add(new GeneralLedger.Account(name, type));
			}
			else
			{
				this.accounts.Add(new GeneralLedger.Account(name + " - Total", type));
				this.accounts.Add(new GeneralLedger.Account(name + " - Total (units)", type));
				foreach (string str in this.productNames)
				{
					new GeneralLedger.Account(name + " - " + str, type, this.GetAccount(name + " - Total"));
					new GeneralLedger.Account(name + " - " + str + " (units)", type, this.GetAccount(name + " - Total (units)"));
				}
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000086FC File Offset: 0x000076FC
		public void AddAccount(string name, GeneralLedger.AccountType type, string parentName)
		{
			if (type != GeneralLedger.AccountType.Product && type != GeneralLedger.AccountType.OtherProduct)
			{
				new GeneralLedger.Account(name, type, this.GetAccount(parentName));
				return;
			}
			throw new Exception("Sub accounts are automatically added for accounts of type Product. Do not add them explicitly.");
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000873C File Offset: 0x0000773C
		protected GeneralLedger.Account GetAccount(string name)
		{
			foreach (object obj in this.accounts)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				if (account.GetAccount(name) != null)
				{
					return account.GetAccount(name);
				}
			}
			throw new Exception("Account " + name + " does not exist.");
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000087D0 File Offset: 0x000077D0
		public float AccountBalance(string name, int period, GeneralLedger.Frequency freq)
		{
			GeneralLedger.Account account = this.GetAccount(name);
			float result;
			if (freq != GeneralLedger.Frequency.Weekly)
			{
				int num = (period + 1) * GeneralLedger.WeeksPerPeriod[(int)freq] - 1;
				if (account.Type == GeneralLedger.AccountType.Liability || account.Type == GeneralLedger.AccountType.Asset)
				{
					result = this.AccountBalance(name, num, GeneralLedger.Frequency.Weekly);
				}
				else
				{
					float num2 = 0f;
					for (int i = num - GeneralLedger.WeeksPerPeriod[(int)freq] + 1; i <= num; i++)
					{
						num2 += this.AccountBalance(name, i, GeneralLedger.Frequency.Weekly);
					}
					result = num2;
				}
			}
			else
			{
				this.CheckForNewWeek(period);
				if (account.Type == GeneralLedger.AccountType.GrossMargin)
				{
					result = this.AccountBalance("Revenue", period, freq) - this.AccountBalance("COGS", period, freq);
				}
				else if (account.Type == GeneralLedger.AccountType.Profit)
				{
					float num3 = 0f;
					foreach (object obj in this.accounts)
					{
						GeneralLedger.Account account2 = (GeneralLedger.Account)obj;
						if (account2.Parent == null && account2.Type == GeneralLedger.AccountType.Expense)
						{
							num3 += account2.GetBalance(this.FinancialWeekIndex(period));
						}
					}
					result = this.AccountBalance("Gross Margin", period, freq) - num3;
				}
				else if (account.Type == GeneralLedger.AccountType.Product)
				{
					result = account.GetBalance(this.ProductWeekIndex(period));
				}
				else
				{
					result = account.GetBalance(this.FinancialWeekIndex(period));
				}
			}
			return result;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000089A4 File Offset: 0x000079A4
		public float AccountBalance(string name, int period)
		{
			return this.AccountBalance(name, period, GeneralLedger.Frequency.Weekly);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000089C0 File Offset: 0x000079C0
		public float AccountBalance(string name)
		{
			return this.AccountBalance(name, S.ST.CurrentWeek, GeneralLedger.Frequency.Weekly);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000089E4 File Offset: 0x000079E4
		protected int FinancialWeekIndex(int week)
		{
			return week % GeneralLedger.WeeksOfFinancialHistory;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00008A00 File Offset: 0x00007A00
		protected int ProductWeekIndex(int week)
		{
			return week % GeneralLedger.WeeksOfProductHistory;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00008A1C File Offset: 0x00007A1C
		protected void CheckForNewWeek(int week)
		{
			if (GeneralLedger.AutomaticallyRollForwardStockAccounts)
			{
				if (this.myCurrentWeek < week)
				{
					for (int i = this.myCurrentWeek + 1; i <= week; i++)
					{
						this.CarryForwardOrClearBalances(i);
					}
					this.myCurrentWeek = week;
				}
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00008A73 File Offset: 0x00007A73
		public void Post(string debitAccountName, float amount, string creditAccountName, int week)
		{
			this.CheckForNewWeek(week);
			this.GetAccount(debitAccountName).Debit(this.FinancialWeekIndex(week), amount);
			this.GetAccount(creditAccountName).Credit(this.FinancialWeekIndex(week), amount);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00008AAB File Offset: 0x00007AAB
		public void Post(string debitAccountName, float amount, string creditAccountName)
		{
			this.Post(debitAccountName, amount, creditAccountName, Simulator.Instance.SimState.CurrentWeek);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00008AC8 File Offset: 0x00007AC8
		public void Post(string debitAccountName, float amount, string creditAccountName, string productName, int units, string[] productDebitAccountNames, string[] productCreditAccountNames, int week)
		{
			this.CheckForNewWeek(week);
			this.Post(debitAccountName, amount, creditAccountName, this.FinancialWeekIndex(week));
			foreach (string str in productDebitAccountNames)
			{
				this.GetAccount(str + " - " + productName).Debit(this.ProductWeekIndex(week), amount);
				this.GetAccount(str + " - " + productName + " (units)").Debit(this.ProductWeekIndex(week), (float)units);
			}
			foreach (string str in productCreditAccountNames)
			{
				this.GetAccount(str + " - " + productName).Credit(this.ProductWeekIndex(week), amount);
				this.GetAccount(str + " - " + productName + " (units)").Credit(this.ProductWeekIndex(week), (float)units);
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00008BC0 File Offset: 0x00007BC0
		public void Post(string debitAccountName, float amount, string creditAccountName, string productName, int units, string[] productDebitAccountNames, string[] productCreditAccountNames)
		{
			this.Post(debitAccountName, amount, creditAccountName, productName, units, productDebitAccountNames, productCreditAccountNames, Simulator.Instance.SimState.CurrentWeek);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00008BEF File Offset: 0x00007BEF
		public void PostNonFinancial(string debitAccountName, float amount)
		{
			this.PostNonFinancial(debitAccountName, amount, Simulator.Instance.SimState.CurrentWeek);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00008C0C File Offset: 0x00007C0C
		public void PostNonFinancial(string debitAccountName, float amount, int week)
		{
			GeneralLedger.Account account = this.GetAccount(debitAccountName);
			if (account.Type != GeneralLedger.AccountType.Other && account.Type != GeneralLedger.AccountType.OtherProduct)
			{
				throw new Exception("Double entry accounting violation.");
			}
			this.CheckForNewWeek(week);
			account.Debit(this.FinancialWeekIndex(week), amount);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00008C5F File Offset: 0x00007C5F
		public void PostNonFinancial(string debitAccountName, float amount, string productName)
		{
			this.PostNonFinancial(debitAccountName, amount, productName, Simulator.Instance.SimState.CurrentWeek);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00008C7B File Offset: 0x00007C7B
		public void PostNonFinancial(string debitAccountName, float amount, string productName, int week)
		{
			this.PostNonFinancial(debitAccountName + " - " + productName, amount, week);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00008C94 File Offset: 0x00007C94
		public DateTime EndingDateOfPeriod(int period, GeneralLedger.Frequency freq)
		{
			int num = (period + 1) * GeneralLedger.WeeksPerPeriod[(int)freq] - 1;
			return this.simStartDate.AddDays((double)(num * 7));
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00008CC4 File Offset: 0x00007CC4
		protected void InsertIntoGraphDataAccountBalances(GeneralLedger.Account account, object[,] data, ref int line, bool percentages, int currentPeriod, int beginPeriod)
		{
			line++;
			data[line, 0] = S.R.GetString(account.Name);
			for (int i = beginPeriod; i < currentPeriod; i++)
			{
				if (!percentages)
				{
					float num = this.AccountBalance(account.Name, i, GeneralLedger.Frequency.Weekly);
					data[line, i - beginPeriod + 1] = num;
				}
				else
				{
					float val;
					if (account.Type == GeneralLedger.AccountType.Liability || account.Type == GeneralLedger.AccountType.Asset)
					{
						val = this.AccountBalance("Assets", i, GeneralLedger.Frequency.Weekly);
					}
					else
					{
						val = this.AccountBalance("Revenue", i, GeneralLedger.Frequency.Weekly);
					}
					float num = this.AccountBalance(account.Name, i, GeneralLedger.Frequency.Weekly) / Math.Max(1f, val);
					data[line, i - beginPeriod + 1] = num;
				}
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00008DA8 File Offset: 0x00007DA8
		public void PrintToFile(ArrayList accountList, string title, int currentPeriod)
		{
			MessageBox.Show("Your data will be exported to a tab-delimited text file which can be opened with Excel.", "Export Format");
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Tab Delimited Text Files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFileDialog.DefaultExt = ".txt";
			if (Simulator.Instance.UserAdminSettings.DefaultDirectory != null)
			{
				saveFileDialog.InitialDirectory = Simulator.Instance.UserAdminSettings.DefaultDirectory;
			}
			while (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = null;
				try
				{
					streamWriter = new StreamWriter(saveFileDialog.FileName);
					streamWriter.Write(this.AccountsAsText(accountList, title, currentPeriod));
					break;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not export to file. File may be read-only or in use by another application.\r\n\r\nError details: " + ex.Message, "Could Not Export");
				}
				finally
				{
					if (streamWriter != null)
					{
						streamWriter.Close();
					}
				}
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00008E98 File Offset: 0x00007E98
		protected string AccountsAsText(ArrayList accountList, string title, int currentPeriod)
		{
			this.printLine = 0;
			int num = GeneralLedger.WeeksOfFinancialHistory;
			if (accountList.Count > 0 && ((GeneralLedger.Account)accountList[0]).Type == GeneralLedger.AccountType.Product)
			{
				num = GeneralLedger.WeeksOfProductHistory;
			}
			int num2 = Math.Max(0, currentPeriod - (num - 1));
			string text = title + "\r\n\r\n";
			text += "\t";
			for (int i = num2; i < currentPeriod; i++)
			{
				text = text + string.Format("{0:dd MMM yy}", this.EndingDateOfPeriod(i, GeneralLedger.Frequency.Weekly)) + "\t";
			}
			foreach (object obj in accountList)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				if (!GeneralLedger.SupressAllZeroLines || account.Level <= 0 || !account.IsAllZero())
				{
					text += "\r\n";
					text += "".PadRight(account.Level * 4);
					text = text + account.Name + "\t";
					for (int i = num2; i < currentPeriod; i++)
					{
						text = text + string.Format("{0:###,###,##0}", this.AccountBalance(account.Name, i, GeneralLedger.Frequency.Weekly)) + "\t";
					}
				}
			}
			return text;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00009040 File Offset: 0x00008040
		public void Graph(ArrayList accountList, string title, bool units, bool percentages, int currentPeriod, KMIGraph graph)
		{
			Simulator instance = Simulator.Instance;
			object[,] array = new object[0, 0];
			graph.GraphType = 1;
			graph.Title = title;
			graph.XAxisTitle = "Week Ending";
			graph.YAxisTitle = null;
			graph.YLabelFormat = null;
			int num = GeneralLedger.WeeksOfFinancialHistory;
			if (accountList.Count > 0 && ((GeneralLedger.Account)accountList[0]).Type == GeneralLedger.AccountType.Product)
			{
				num = GeneralLedger.WeeksOfProductHistory;
			}
			int num2 = Math.Max(0, currentPeriod - (num - 1));
			if (percentages)
			{
				if (accountList.Count > 0)
				{
					if (((GeneralLedger.Account)accountList[0]).Type == GeneralLedger.AccountType.Asset || ((GeneralLedger.Account)accountList[0]).Type == GeneralLedger.AccountType.Liability)
					{
						graph.YAxisTitle = "% of Assets";
					}
					else
					{
						graph.YAxisTitle = "% of Revenue";
					}
				}
				graph.YLabelFormat = "{0:##0%}";
			}
			int num3 = 0;
			array = new object[accountList.Count + 1, currentPeriod - num2 + 1];
			foreach (object obj in accountList)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				this.InsertIntoGraphDataAccountBalances(account, array, ref num3, percentages, currentPeriod, num2);
			}
			if (units)
			{
				graph.YLabelFormat = "{0:###,###,##0}";
			}
			for (int i = num2; i < currentPeriod; i++)
			{
				array[0, i - num2 + 1] = this.EndingDateOfPeriod(i, GeneralLedger.Frequency.Weekly);
			}
			graph.Draw(array);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000921C File Offset: 0x0000821C
		public int MaxPrintingColumns(int overallWidth, ArrayList accountList, Graphics g)
		{
			int num = (int)g.MeasureString(this.LongestAccountName(accountList) + "XX", GeneralLedger.accountFont).Width;
			int num2 = (int)g.MeasureString("X99,999,999", GeneralLedger.accountFont).Width;
			return (overallWidth - num - 20) / num2;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00009278 File Offset: 0x00008278
		public int MaxPrintingRows(int overallHeight, Graphics g)
		{
			int num = (int)g.MeasureString("XX", GeneralLedger.titleFont).Height;
			int num2 = (int)g.MeasureString("XX", GeneralLedger.dateFont).Height;
			int num3 = (int)g.MeasureString("XX", GeneralLedger.accountFont).Height;
			return (overallHeight - num3 - 40) / num3;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000092E4 File Offset: 0x000082E4
		public ArrayList ProductAccountBaseNames
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object obj in this.accounts)
				{
					GeneralLedger.Account account = (GeneralLedger.Account)obj;
					if (account.Type == GeneralLedger.AccountType.Product && account.Name.EndsWith(" - Total"))
					{
						arrayList.Add(account.Name.Substring(0, account.Name.Length - " - Total".Length));
					}
				}
				return arrayList;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000093A8 File Offset: 0x000083A8
		protected string LongestAccountName(ArrayList accountList)
		{
			string text = "";
			foreach (object obj in accountList)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				if (account.Name.Length > text.Length)
				{
					text = account.Name;
				}
			}
			return text;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000943C File Offset: 0x0000843C
		public void ConsolidateWith(GeneralLedger GL)
		{
			int currentWeek = S.ST.CurrentWeek;
			foreach (object obj in this.accounts)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				if (account.SubAccounts.Count == 0)
				{
					for (int i = Math.Max(0, currentWeek - GeneralLedger.WeeksOfFinancialHistory); i < currentWeek; i++)
					{
						float num = GL.AccountBalance(account.Name, i, GeneralLedger.Frequency.Weekly);
						if (account.Type == GeneralLedger.AccountType.Liability | account.Type == GeneralLedger.AccountType.Revenue)
						{
							num = -num;
						}
						account.Debit(i, num);
					}
				}
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00009524 File Offset: 0x00008524
		public GeneralLedger Clone()
		{
			return (GeneralLedger)Utilities.DeepCopyBySerialization(this);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00009544 File Offset: 0x00008544
		private string FrequencyName(GeneralLedger.Frequency freq)
		{
			string @string;
			switch (freq)
			{
			case GeneralLedger.Frequency.Weekly:
				@string = Simulator.Instance.Resource.GetString("Weekly");
				break;
			case GeneralLedger.Frequency.Quarterly:
				@string = Simulator.Instance.Resource.GetString("Quarterly");
				break;
			case GeneralLedger.Frequency.Annually:
				@string = Simulator.Instance.Resource.GetString("Annual");
				break;
			default:
				throw new Exception("Bad frequency passed into Frequency name");
			}
			return @string;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000095BC File Offset: 0x000085BC
		public float RowHeight(Graphics g)
		{
			return g.MeasureString("X", GeneralLedger.accountFont).Height;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000095E8 File Offset: 0x000085E8
		protected virtual void PrintAccountBalance(GeneralLedger.Account account, int beginPeriod, int endPeriod, GeneralLedger.Frequency freq, bool percentages, int firstColWidth, Graphics g)
		{
			float height = g.MeasureString("X", GeneralLedger.accountFont).Height;
			int num = (int)g.MeasureString("X99,999,999", GeneralLedger.accountFont).Width;
			Font font;
			if (account.Level == 0)
			{
				font = GeneralLedger.accountFont;
			}
			else
			{
				font = GeneralLedger.subAccountFont;
			}
			g.DrawString(S.R.GetString(account.Name), font, GeneralLedger.brush, (float)(10 + account.Level * 10), 40f + (float)this.printLine * height);
			for (int i = beginPeriod; i <= endPeriod; i++)
			{
				if (!percentages)
				{
					float num2 = this.AccountBalance(account.Name, i, freq);
					g.DrawString(string.Format("{0:###,###,##0}", num2), font, GeneralLedger.brush, (float)(10 + firstColWidth + (i - beginPeriod + 1) * num), 40f + (float)this.printLine * height, GeneralLedger.sfr);
				}
				else
				{
					float val;
					if (account.Type == GeneralLedger.AccountType.Liability || account.Type == GeneralLedger.AccountType.Asset)
					{
						val = this.AccountBalance("Assets", i, freq);
					}
					else
					{
						val = this.AccountBalance("Revenue", i, freq);
					}
					float num2 = this.AccountBalance(account.Name, i, freq) / Math.Max(1f, val);
					g.DrawString(string.Format("{0:##0%}", num2), font, GeneralLedger.brush, (float)(10 + firstColWidth + (i - beginPeriod + 1) * num), 40f + (float)this.printLine * height, GeneralLedger.sfr);
				}
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000097B0 File Offset: 0x000087B0
		public ArrayList AccountList(string statement, bool detail)
		{
			ArrayList arrayList = new ArrayList();
			if (statement == Simulator.Instance.Resource.GetString("Income Statement"))
			{
				foreach (object obj in this.accounts)
				{
					GeneralLedger.Account account = (GeneralLedger.Account)obj;
					if (account.Type == GeneralLedger.AccountType.Revenue)
					{
						arrayList.Add(account);
						if (detail)
						{
							arrayList.AddRange(account.AllSubAccounts);
						}
						else if (GeneralLedger.FirstLevelSubaccountsWhenUndetailed)
						{
							arrayList.AddRange(account.SubAccounts);
						}
					}
				}
				if (GeneralLedger.DisplayCOGS)
				{
					foreach (object obj2 in this.accounts)
					{
						GeneralLedger.Account account = (GeneralLedger.Account)obj2;
						if (account.Type == GeneralLedger.AccountType.COGS)
						{
							arrayList.Add(account);
							if (detail)
							{
								arrayList.AddRange(account.AllSubAccounts);
							}
							else if (GeneralLedger.FirstLevelSubaccountsWhenUndetailed)
							{
								arrayList.AddRange(account.SubAccounts);
							}
						}
					}
				}
				if (GeneralLedger.DisplayGrossMargin)
				{
					arrayList.Add(this.GetAccount("Gross Margin"));
				}
				foreach (object obj3 in this.accounts)
				{
					GeneralLedger.Account account = (GeneralLedger.Account)obj3;
					if (account.Type == GeneralLedger.AccountType.Expense)
					{
						arrayList.Add(account);
						if (detail)
						{
							arrayList.AddRange(account.AllSubAccounts);
						}
						else if (GeneralLedger.FirstLevelSubaccountsWhenUndetailed)
						{
							arrayList.AddRange(account.SubAccounts);
						}
					}
				}
				arrayList.Add(this.GetAccount("Profit"));
			}
			else
			{
				if (!(statement == Simulator.Instance.Resource.GetString("Balance Sheet")))
				{
					throw new Exception("Statement name incorrect.");
				}
				GeneralLedger.Account account = this.GetAccount("Assets");
				arrayList.Add(account);
				if (detail)
				{
					arrayList.AddRange(account.AllSubAccounts);
				}
				else if (GeneralLedger.FirstLevelSubaccountsWhenUndetailed)
				{
					arrayList.AddRange(account.SubAccounts);
				}
				account = this.GetAccount("Liabilities Plus Equity");
				arrayList.Add(account);
				if (detail)
				{
					arrayList.AddRange(account.AllSubAccounts);
				}
				else if (GeneralLedger.FirstLevelSubaccountsWhenUndetailed)
				{
					arrayList.AddRange(account.SubAccounts);
				}
			}
			return arrayList;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00009AD4 File Offset: 0x00008AD4
		public ArrayList AccountListForGraphing(string statement)
		{
			ArrayList arrayList = new ArrayList();
			if (statement == Simulator.Instance.Resource.GetString("Income Statement"))
			{
				arrayList.Add(this.GetAccount("Revenue"));
				if (GeneralLedger.DisplayGrossMargin)
				{
					arrayList.Add(this.GetAccount("Gross Margin"));
				}
				arrayList.Add(this.GetAccount("Profit"));
			}
			else
			{
				if (!(statement == Simulator.Instance.Resource.GetString("Balance Sheet")))
				{
					throw new Exception("Statement name incorrect.");
				}
				arrayList.Add(this.GetAccount("Assets"));
				arrayList.Add(this.GetAccount("Liabilities"));
				arrayList.Add(this.GetAccount("Equity"));
			}
			return arrayList;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00009BC0 File Offset: 0x00008BC0
		protected virtual void PrintAccountList(ArrayList accountList, string title, int beginRow, int endRow, int beginPeriod, int endPeriod, GeneralLedger.Frequency freq, bool percentages, Graphics g)
		{
			g.Clear(Color.White);
			this.printLine = 0;
			int num = (int)g.MeasureString(this.LongestAccountName(accountList) + "X", GeneralLedger.accountFont).Width;
			int num2 = (int)g.MeasureString("X99,999,999", GeneralLedger.accountFont).Width;
			g.DrawString(title, GeneralLedger.titleFont, GeneralLedger.brush, 10f, 10f);
			for (int i = beginPeriod; i <= endPeriod; i++)
			{
				g.DrawString(string.Format("{0:dd MMM yy}", this.EndingDateOfPeriod(i, freq)), GeneralLedger.dateFont, GeneralLedger.brush, (float)(10 + num + (i - beginPeriod + 1) * num2), 40f, GeneralLedger.sfr);
			}
			this.printLine++;
			for (int j = beginRow; j <= endRow; j++)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)accountList[j];
				if (!GeneralLedger.SupressAllZeroLines || account.Level <= 0 || !account.IsAllZero())
				{
					this.PrintAccountBalance(account, beginPeriod, endPeriod, freq, percentages, num, g);
					this.printLine++;
				}
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00009D1C File Offset: 0x00008D1C
		public ArrayList AccountList(ArrayList productDataSeriesNames, ArrayList productNames, bool units)
		{
			ArrayList arrayList = new ArrayList();
			string str = "";
			if (units)
			{
				str = " (units)";
			}
			foreach (object obj in productDataSeriesNames)
			{
				string str2 = (string)obj;
				foreach (object obj2 in productNames)
				{
					string str3 = (string)obj2;
					arrayList.Add(this.GetAccount(str2 + " - " + str3 + str));
				}
			}
			return arrayList;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00009E10 File Offset: 0x00008E10
		protected void CarryForwardOrClearBalances(int wk)
		{
			float amount = this.AccountBalance("Profit", wk - 1, GeneralLedger.Frequency.Weekly);
			foreach (object obj in this.AllAccounts())
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				if (account.SubAccounts.Count == 0)
				{
					if (account.Type == GeneralLedger.AccountType.Product)
					{
						account.Clear(this.ProductWeekIndex(wk));
					}
					else
					{
						account.Clear(this.FinancialWeekIndex(wk));
					}
					if (account.Type == GeneralLedger.AccountType.Liability)
					{
						if (account.Name == "Retained Earnings")
						{
							account.Credit(this.FinancialWeekIndex(wk - 1), amount);
						}
						account.Credit(this.FinancialWeekIndex(wk), account.GetBalance(this.FinancialWeekIndex(wk - 1)));
					}
					else if (account.Type == GeneralLedger.AccountType.Asset)
					{
						account.Debit(this.FinancialWeekIndex(wk), account.GetBalance(this.FinancialWeekIndex(wk - 1)));
					}
					else if (account.Type == GeneralLedger.AccountType.Product && account.Name.StartsWith("Inventory"))
					{
						account.Debit(this.ProductWeekIndex(wk), account.GetBalance(this.ProductWeekIndex(wk - 1)));
					}
				}
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00009FA4 File Offset: 0x00008FA4
		public void PrintToScreen(ArrayList accountList, string title, int beginRow, int endRow, int beginPeriod, int endPeriod, GeneralLedger.Frequency freq, bool percentages, Graphics g)
		{
			this.PrintAccountList(accountList, title, beginRow, endRow, beginPeriod, endPeriod, freq, percentages, g);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00009FC8 File Offset: 0x00008FC8
		public void PrintToPrinter(ArrayList accountList, string title, GeneralLedger.Frequency freq, bool percentages)
		{
			this.printAccountList = accountList;
			this.printFrequency = freq;
			this.printPercentages = percentages;
			this.printTitle = title;
			this.printRow = 0;
			int num = this.myCurrentWeek / GeneralLedger.WeeksPerPeriod[(int)this.printFrequency];
			this.printPeriodsLeft = Math.Min(this.myCurrentWeek, GeneralLedger.WeeksOfFinancialHistory - 1) / GeneralLedger.WeeksPerPeriod[(int)this.printFrequency];
			if (accountList.Count > 0 && ((GeneralLedger.Account)accountList[0]).Type == GeneralLedger.AccountType.Product)
			{
				this.printPeriodsLeft = Math.Min(this.myCurrentWeek, GeneralLedger.WeeksOfProductHistory - 1) / GeneralLedger.WeeksPerPeriod[(int)this.printFrequency];
			}
			this.printPeriod = num - this.printPeriodsLeft;
			Utilities.PrintWithExceptionHandling("", new PrintPageEventHandler(this.GL_PrintPage));
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000A0A4 File Offset: 0x000090A4
		private void GL_PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			Graphics graphics = e.Graphics;
			int num = this.MaxPrintingColumns(e.MarginBounds.Width, this.printAccountList, graphics);
			int num2 = Math.Min(this.printPeriod + num - 1, this.printPeriod + this.printPeriodsLeft - 1);
			int num3 = this.MaxPrintingRows(e.MarginBounds.Height, graphics);
			int count = this.printAccountList.Count;
			int num4 = Math.Min(this.printRow + num3 - 1, count - 1);
			this.PrintAccountList(this.printAccountList, this.printTitle, this.printRow, num4, this.printPeriod, num2, this.printFrequency, this.printPercentages, graphics);
			if (num2 < this.printPeriod + this.printPeriodsLeft - 1)
			{
				this.printPeriod += num;
				this.printPeriodsLeft -= num;
				e.HasMorePages = true;
			}
			else if (num4 < count - 1)
			{
				this.printPeriod = 0;
				this.printRow = num4 + 1;
				e.HasMorePages = true;
			}
			else
			{
				e.HasMorePages = false;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A1E0 File Offset: 0x000091E0
		protected ArrayList AllAccounts()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.accounts)
			{
				GeneralLedger.Account account = (GeneralLedger.Account)obj;
				arrayList.Add(account);
				foreach (object obj2 in account.AllSubAccounts)
				{
					GeneralLedger.Account value = (GeneralLedger.Account)obj2;
					arrayList.Add(value);
				}
			}
			return arrayList;
		}

		// Token: 0x04000090 RID: 144
		protected const string TAB = "\t";

		// Token: 0x04000091 RID: 145
		protected const string LINEFEED = "\r\n";

		// Token: 0x04000092 RID: 146
		protected const int SubAccount_Indent = 10;

		// Token: 0x04000093 RID: 147
		protected const int Left_Margin = 10;

		// Token: 0x04000094 RID: 148
		public const int Top_Margin = 40;

		// Token: 0x04000095 RID: 149
		public static int WeeksOfFinancialHistory = 208;

		// Token: 0x04000096 RID: 150
		public static int WeeksOfProductHistory = 52;

		// Token: 0x04000097 RID: 151
		public static bool FirstLevelSubaccountsWhenUndetailed = true;

		// Token: 0x04000098 RID: 152
		public static bool DisplayGrossMargin = true;

		// Token: 0x04000099 RID: 153
		public static bool DisplayCOGS = true;

		// Token: 0x0400009A RID: 154
		public static bool AutomaticallyRollForwardStockAccounts = true;

		// Token: 0x0400009B RID: 155
		protected string[] productNames;

		// Token: 0x0400009C RID: 156
		protected int myCurrentWeek = 0;

		// Token: 0x0400009D RID: 157
		protected ArrayList accounts = new ArrayList();

		// Token: 0x0400009E RID: 158
		protected static Font titleFont = new Font(new FontFamily("Arial"), 12f, FontStyle.Bold);

		// Token: 0x0400009F RID: 159
		protected static Font accountFont = new Font(new FontFamily("Arial"), 10f, FontStyle.Bold);

		// Token: 0x040000A0 RID: 160
		protected static Font subAccountFont = new Font(new FontFamily("Arial"), 10f);

		// Token: 0x040000A1 RID: 161
		protected static Font dateFont = new Font(new FontFamily("Arial"), 10f, FontStyle.Bold);

		// Token: 0x040000A2 RID: 162
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x040000A3 RID: 163
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x040000A4 RID: 164
		public static int[] WeeksPerPeriod = new int[]
		{
			1,
			13,
			52
		};

		// Token: 0x040000A5 RID: 165
		protected int printLine;

		// Token: 0x040000A6 RID: 166
		protected int printPeriod;

		// Token: 0x040000A7 RID: 167
		protected ArrayList printAccountList;

		// Token: 0x040000A8 RID: 168
		protected bool printPercentages;

		// Token: 0x040000A9 RID: 169
		protected GeneralLedger.Frequency printFrequency;

		// Token: 0x040000AA RID: 170
		protected string printTitle;

		// Token: 0x040000AB RID: 171
		protected int printRow;

		// Token: 0x040000AC RID: 172
		[NonSerialized]
		protected int printPeriodsLeft;

		// Token: 0x040000AD RID: 173
		public static bool SupressAllZeroLines = false;

		// Token: 0x040000AE RID: 174
		private DateTime simStartDate;

		// Token: 0x02000017 RID: 23
		public enum AccountType
		{
			// Token: 0x040000B0 RID: 176
			Revenue,
			// Token: 0x040000B1 RID: 177
			Expense,
			// Token: 0x040000B2 RID: 178
			COGS,
			// Token: 0x040000B3 RID: 179
			Asset,
			// Token: 0x040000B4 RID: 180
			Liability,
			// Token: 0x040000B5 RID: 181
			GrossMargin,
			// Token: 0x040000B6 RID: 182
			Profit,
			// Token: 0x040000B7 RID: 183
			Product,
			// Token: 0x040000B8 RID: 184
			Other,
			// Token: 0x040000B9 RID: 185
			OtherProduct
		}

		// Token: 0x02000018 RID: 24
		public enum Frequency
		{
			// Token: 0x040000BB RID: 187
			Weekly,
			// Token: 0x040000BC RID: 188
			Quarterly,
			// Token: 0x040000BD RID: 189
			Annually
		}

		// Token: 0x02000019 RID: 25
		[Serializable]
		public class Account
		{
			// Token: 0x06000133 RID: 307 RVA: 0x0000A3A0 File Offset: 0x000093A0
			public Account(string name, GeneralLedger.AccountType type)
			{
				this.name = name;
				this.type = type;
				if (type != GeneralLedger.AccountType.Product)
				{
					this.balance = new float[GeneralLedger.WeeksOfFinancialHistory];
				}
				else
				{
					this.balance = new float[GeneralLedger.WeeksOfProductHistory];
				}
			}

			// Token: 0x06000134 RID: 308 RVA: 0x0000A400 File Offset: 0x00009400
			public Account(string name, GeneralLedger.AccountType type, GeneralLedger.Account parent)
			{
				this.name = name;
				this.type = type;
				this.parent = parent;
				parent.SubAccounts.Add(this);
				if (type != GeneralLedger.AccountType.Product)
				{
					this.balance = new float[GeneralLedger.WeeksOfFinancialHistory];
				}
				else
				{
					this.balance = new float[GeneralLedger.WeeksOfProductHistory];
				}
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x06000135 RID: 309 RVA: 0x0000A474 File Offset: 0x00009474
			public string Name
			{
				get
				{
					return this.name;
				}
			}

			// Token: 0x06000136 RID: 310 RVA: 0x0000A48C File Offset: 0x0000948C
			public void RenameSpecialForVBR3(string newName)
			{
				this.name = newName;
			}

			// Token: 0x06000137 RID: 311 RVA: 0x0000A498 File Offset: 0x00009498
			public float GetBalance(int weekIndex)
			{
				float num = 0f;
				float result;
				if (this.SubAccounts.Count == 0)
				{
					result = this.balance[weekIndex];
				}
				else
				{
					foreach (object obj in this.SubAccounts)
					{
						GeneralLedger.Account account = (GeneralLedger.Account)obj;
						num += account.GetBalance(weekIndex);
					}
					result = num;
				}
				return result;
			}

			// Token: 0x06000138 RID: 312 RVA: 0x0000A538 File Offset: 0x00009538
			public void Debit(int weekIndex, float amount)
			{
				if (this.SubAccounts.Count != 0)
				{
					throw new Exception("Attempt to set aggregate account balance not allowed.");
				}
				if (this.Type == GeneralLedger.AccountType.Liability | this.Type == GeneralLedger.AccountType.Revenue)
				{
					this.balance[weekIndex] -= amount;
				}
				else
				{
					this.balance[weekIndex] += amount;
				}
			}

			// Token: 0x06000139 RID: 313 RVA: 0x0000A5B8 File Offset: 0x000095B8
			public void Credit(int weekIndex, float amount)
			{
				this.Debit(weekIndex, -amount);
			}

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x0600013A RID: 314 RVA: 0x0000A5C8 File Offset: 0x000095C8
			// (set) Token: 0x0600013B RID: 315 RVA: 0x0000A5E0 File Offset: 0x000095E0
			public GeneralLedger.Account Parent
			{
				get
				{
					return this.parent;
				}
				set
				{
					this.parent = value;
				}
			}

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x0600013C RID: 316 RVA: 0x0000A5EC File Offset: 0x000095EC
			public ArrayList SubAccounts
			{
				get
				{
					return this.subAccounts;
				}
			}

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x0600013D RID: 317 RVA: 0x0000A604 File Offset: 0x00009604
			public ArrayList AllSubAccounts
			{
				get
				{
					ArrayList arrayList = new ArrayList();
					foreach (object obj in this.subAccounts)
					{
						GeneralLedger.Account account = (GeneralLedger.Account)obj;
						arrayList.Add(account);
						arrayList.AddRange(account.AllSubAccounts);
					}
					return arrayList;
				}
			}

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600013E RID: 318 RVA: 0x0000A68C File Offset: 0x0000968C
			public GeneralLedger.AccountType Type
			{
				get
				{
					return this.type;
				}
			}

			// Token: 0x1700005D RID: 93
			// (get) Token: 0x0600013F RID: 319 RVA: 0x0000A6A4 File Offset: 0x000096A4
			public int Level
			{
				get
				{
					GeneralLedger.Account account = this;
					int num = 0;
					while (account.Parent != null)
					{
						account = account.Parent;
						num++;
					}
					return num;
				}
			}

			// Token: 0x06000140 RID: 320 RVA: 0x0000A6DC File Offset: 0x000096DC
			public GeneralLedger.Account GetAccount(string name)
			{
				GeneralLedger.Account result;
				if (this.name == name)
				{
					result = this;
				}
				else
				{
					if (this.SubAccounts.Count > 0)
					{
						foreach (object obj in this.SubAccounts)
						{
							GeneralLedger.Account account = (GeneralLedger.Account)obj;
							if (account.GetAccount(name) != null)
							{
								return account.GetAccount(name);
							}
						}
					}
					result = null;
				}
				return result;
			}

			// Token: 0x06000141 RID: 321 RVA: 0x0000A790 File Offset: 0x00009790
			public void Clear(int week)
			{
				this.balance[week] = 0f;
			}

			// Token: 0x06000142 RID: 322 RVA: 0x0000A7A0 File Offset: 0x000097A0
			public bool IsAllZero()
			{
				foreach (float num in this.balance)
				{
					if (num != 0f)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x040000BE RID: 190
			protected string name;

			// Token: 0x040000BF RID: 191
			protected float[] balance;

			// Token: 0x040000C0 RID: 192
			protected GeneralLedger.Account parent;

			// Token: 0x040000C1 RID: 193
			protected ArrayList subAccounts = new ArrayList();

			// Token: 0x040000C2 RID: 194
			protected GeneralLedger.AccountType type;
		}
	}
}
