using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for StockIncome.
	/// </summary>
	// Token: 0x02000038 RID: 56
	[Serializable]
	public class MoneyMarketFund : Fund
	{
		// Token: 0x060001AF RID: 431 RVA: 0x0001B384 File Offset: 0x0001A384
		public MoneyMarketFund(string name, float diffToPrime)
		{
			this.Name = name;
			DateTime t = new DateTime(2005, 1, 1);
			while (t < A.ST.Now)
			{
				this.NewDay();
				t = t.AddDays(1.0);
			}
			this.DiffToPrime = diffToPrime;
			this.Fees12B1 = (float)A.ST.Random.Next(2) * 0.0025f;
			this.TotalExpenseRatio = this.Fees12B1 + (float)A.ST.Random.NextDouble() / 100f / 4f;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0001B42D File Offset: 0x0001A42D
		public override void NewDay()
		{
			base.NewDay();
			this.sharePrice.Add(1f);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0001B450 File Offset: 0x0001A450
		public override string CategoryName
		{
			get
			{
				return "Money Markets";
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0001B468 File Offset: 0x0001A468
		public override float Dividend
		{
			get
			{
				return (A.ST.PrimeRate() + this.DiffToPrime - this.TotalExpenseRatio) * base.Price;
			}
		}

		// Token: 0x040001CA RID: 458
		public float DiffToPrime;
	}
}
