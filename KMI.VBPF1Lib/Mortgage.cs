using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Mortgage.
	/// </summary>
	// Token: 0x020000A0 RID: 160
	[Serializable]
	public class Mortgage : InstallmentLoan
	{
		// Token: 0x060004E7 RID: 1255 RVA: 0x00046205 File Offset: 0x00045205
		public Mortgage(DateTime date, float amount, float interestRate, int term) : base(date, amount, interestRate, term)
		{
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x00046218 File Offset: 0x00045218
		public float ClosingCosts
		{
			get
			{
				return 2000f + 0.01f * base.OriginalBalance;
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0004623C File Offset: 0x0004523C
		public float PMI(float valueOfCondo)
		{
			float pmi = 0f;
			if ((double)(base.OriginalBalance / Math.Max(1f, valueOfCondo)) > 0.8)
			{
				pmi = base.OriginalBalance * 0.005f / 12f;
			}
			return pmi;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00046290 File Offset: 0x00045290
		public override string ToString()
		{
			return A.R.GetString("{0}-Year Fixed Rate", new object[]
			{
				base.Term / 12
			});
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000462CC File Offset: 0x000452CC
		public int InterestPaid(int year)
		{
			float payments = 0f;
			float interest = 0f;
			for (int i = 1; i <= 12; i++)
			{
				foreach (object obj in base.TransactionsForMonth(year, i))
				{
					Transaction t = (Transaction)obj;
					if (t.Description.StartsWith("Payment"))
					{
						payments += t.Amount;
					}
					if (t.Description.StartsWith("Interest"))
					{
						interest += t.Amount;
					}
				}
			}
			return (int)Math.Min(interest, payments);
		}

		// Token: 0x040005C7 RID: 1479
		public long BuildingID;
	}
}
