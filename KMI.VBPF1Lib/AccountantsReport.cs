using System;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for AccountantsReport.
	/// </summary>
	// Token: 0x0200009E RID: 158
	[Serializable]
	public class AccountantsReport : TaxReturn
	{
		// Token: 0x060004DC RID: 1244 RVA: 0x00045464 File Offset: 0x00044464
		public AccountantsReport(int year) : base(year)
		{
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000454A0 File Offset: 0x000444A0
		public void PrepareTaxes(int year, AppEntity e, bool itemizeIfBetter)
		{
			int stdDeduction = 8450;
			float wages = 0f;
			float interest = 0f;
			int stateTaxes = 0;
			string lf = Environment.NewLine;
			this.FedWT = 0;
			this.Report += A.R.GetString(string.Concat(new string[]
			{
				"Tax Professional's Tax Return for {0}",
				lf,
				"Tax Year {1}",
				lf,
				lf
			}), new object[]
			{
				e.Name,
				year
			}).ToUpper();
			foreach (object obj in e.FW2s.Values)
			{
				FW2 f = (FW2)obj;
				if (f.Year() == year)
				{
					wages += f.Wages;
					this.FedWT += (int)Math.Ceiling((double)f.FedWT);
					stateTaxes = (int)f.StateWT;
				}
			}
			this.Report += A.R.GetString("  Wages: {0}" + lf, new object[]
			{
				Utilities.FC(wages, A.I.CurrencyConversion)
			});
			foreach (object obj2 in e.F1099s.Values)
			{
				F1099Int f2 = (F1099Int)obj2;
				if (f2.Year() == year)
				{
					interest += f2.Interest;
				}
			}
			this.Report += A.R.GetString("+ Interest Income: {0}" + lf, new object[]
			{
				Utilities.FC(interest, A.I.CurrencyConversion)
			});
			float dividends = 0f;
			foreach (object obj3 in e.InvestmentAccounts.Values)
			{
				InvestmentAccount ia = (InvestmentAccount)obj3;
				foreach (object obj4 in ia.Transactions)
				{
					Transaction t = (Transaction)obj4;
					if (t.Date.Year == year && t.Description == A.R.GetString("Dividend Purchase"))
					{
						dividends += t.Amount * ia.Fund.PriceOn(t.Date);
					}
				}
			}
			this.Report += A.R.GetString("+ Ordinary Dividends: {0}" + lf, new object[]
			{
				Utilities.FC(dividends, A.I.CurrencyConversion)
			});
			float STCapGains = 0f;
			if (e.STCapitalGains.ContainsKey(year))
			{
				STCapGains = (float)e.STCapitalGains[year];
			}
			this.Report += A.R.GetString("+ Short-term Capital Gains: {0}" + lf, new object[]
			{
				Utilities.FC(STCapGains, A.I.CurrencyConversion)
			});
			int ordinaryIncome = (int)Math.Round(Math.Round((double)wages) + Math.Round((double)interest) + Math.Round((double)dividends) + Math.Round((double)STCapGains));
			this.Report += A.R.GetString("= Total Ordinary Income: {0}" + lf, new object[]
			{
				Utilities.FC((float)ordinaryIncome, A.I.CurrencyConversion)
			});
			int deduction = stdDeduction;
			if (itemizeIfBetter)
			{
				int mortgageInterest = 0;
				foreach (object obj5 in e.Mortgages.Values)
				{
					Mortgage i = (Mortgage)obj5;
					mortgageInterest += i.InterestPaid(year);
				}
				if (mortgageInterest + stateTaxes > stdDeduction)
				{
					deduction = mortgageInterest + stateTaxes;
					this.Report += A.R.GetString("- Itemized Deduction: {0}" + lf, new object[]
					{
						Utilities.FC((float)deduction, A.I.CurrencyConversion)
					});
					if (mortgageInterest > 0)
					{
						this.Report += A.R.GetString("    Mortgage Interest: {0}" + lf, new object[]
						{
							Utilities.FC((float)mortgageInterest, A.I.CurrencyConversion)
						});
					}
					this.Report += A.R.GetString("    State Taxes: {0}" + lf, new object[]
					{
						Utilities.FC((float)stateTaxes, A.I.CurrencyConversion)
					});
				}
			}
			if (deduction == stdDeduction)
			{
				this.Report += A.R.GetString("- Standard Deduction: {0}" + lf, new object[]
				{
					Utilities.FC((float)deduction, A.I.CurrencyConversion)
				});
			}
			int taxableIncome = Math.Max(0, ordinaryIncome - deduction);
			this.Report += A.R.GetString("= Taxable Ordinary Income: {0}" + lf, new object[]
			{
				Utilities.FC((float)taxableIncome, A.I.CurrencyConversion)
			});
			float[] taxBrackets = new float[]
			{
				0f,
				7550f,
				30650f,
				74200f,
				154800f,
				336550f
			};
			this.Tax = (int)Math.Round((double)F1040EZ.ComputeTax((float)taxableIncome, taxBrackets, new float[]
			{
				0.1f,
				0.15f,
				0.25f,
				0.28f,
				0.33f,
				0.35f
			}));
			this.Report += A.R.GetString("  Tax On Ordinary Income: {0}" + lf + lf, new object[]
			{
				Utilities.FC((float)this.Tax, A.I.CurrencyConversion)
			});
			float LTCapGains = 0f;
			if (e.LTCapitalGains.ContainsKey(year))
			{
				LTCapGains = (float)e.LTCapitalGains[year];
			}
			this.Report += A.R.GetString("  Long-term Capital Gains: {0}" + lf, new object[]
			{
				Utilities.FC(LTCapGains, A.I.CurrencyConversion)
			});
			float ltTaxRate = 0.05f;
			if ((float)(taxableIncome + (int)LTCapGains) > taxBrackets[1])
			{
				ltTaxRate = 0.15f;
			}
			int cgTax = (int)(ltTaxRate * (float)((int)LTCapGains));
			this.Report += A.R.GetString("x Capital Gains Tax Rate: {0}" + lf, new object[]
			{
				Utilities.FP(ltTaxRate)
			});
			this.Report += A.R.GetString("= Tax on Long-term Capital Gains: {0}" + lf + lf, new object[]
			{
				Utilities.FC((float)cgTax, A.I.CurrencyConversion)
			});
			this.Tax += cgTax;
			this.Owed = this.Tax - this.FedWT;
			this.Report += A.R.GetString("  Total Tax Liability: {0}" + lf, new object[]
			{
				Utilities.FC((float)this.Tax, A.I.CurrencyConversion)
			});
			this.Report += A.R.GetString("- Total Federal Withholding: {0}" + lf, new object[]
			{
				Utilities.FC((float)this.FedWT, A.I.CurrencyConversion)
			});
			if (this.Owed > 0)
			{
				this.Report += A.R.GetString("= Tax Due: {0}" + lf, new object[]
				{
					Utilities.FC((float)this.Owed, A.I.CurrencyConversion)
				});
				this.Values[8] = this.Owed;
			}
			else
			{
				this.Report += A.R.GetString("= Refund: {0}" + lf, new object[]
				{
					Utilities.FC((float)(-(float)this.Owed), A.I.CurrencyConversion)
				});
				this.Values[7] = -this.Owed;
			}
		}

		// Token: 0x040005C1 RID: 1473
		public int Tax;

		// Token: 0x040005C2 RID: 1474
		public int FedWT;

		// Token: 0x040005C3 RID: 1475
		public int Owed;

		// Token: 0x040005C4 RID: 1476
		public string Report;
	}
}
