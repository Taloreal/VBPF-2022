using System;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for CheckingAccount.
	/// </summary>
	// Token: 0x02000018 RID: 24
	[Serializable]
	public class SavingsAccount : BankAccount
	{
		// Token: 0x06000087 RID: 135 RVA: 0x000097AB File Offset: 0x000087AB
		public SavingsAccount(float maintenanceFee, float interestRate, float minimumBalance)
		{
			this.maintenanceFee = maintenanceFee;
			this.interestRate = interestRate;
			this.minimumBalance = minimumBalance;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000088 RID: 136 RVA: 0x000097CC File Offset: 0x000087CC
		public override string AccountTypeFriendlyName
		{
			get
			{
				return A.R.GetString("Savings");
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000097F0 File Offset: 0x000087F0
		public override string Description()
		{
			return A.R.GetString("Savings account offering {0} APR interest. Monthly fee of {1} waived if minimum daily balance greater than {2}.", new object[]
			{
				Utilities.FP(this.interestRate, 1),
				Utilities.FC(this.maintenanceFee, A.I.CurrencyConversion),
				Utilities.FC(this.minimumBalance, A.I.CurrencyConversion)
			});
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00009858 File Offset: 0x00008858
		public float Interest(int year)
		{
			float total = 0f;
			foreach (object obj in this.Transactions)
			{
				Transaction t = (Transaction)obj;
				if (t.Date.Year == year && t.Description == A.R.GetString("Interest earned"))
				{
					total += t.Amount;
				}
			}
			return total;
		}
	}
}
