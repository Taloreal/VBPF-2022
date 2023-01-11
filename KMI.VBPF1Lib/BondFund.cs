using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for StockIncome.
	/// </summary>
	// Token: 0x02000092 RID: 146
	[Serializable]
	public class BondFund : Fund
	{
		// Token: 0x060004A4 RID: 1188 RVA: 0x00042258 File Offset: 0x00041258
		public BondFund(string name, float growth)
		{
			this.Name = name;
			DateTime t = new DateTime(2005, 1, 1);
			this.volatility = 0.5f;
			this.Growth = growth;
			while (t < A.ST.Now)
			{
				this.NewDay();
				t = t.AddDays(1.0);
			}
			this.dividendPct = (float)((0.75 + 0.25 * A.ST.Random.NextDouble()) * (double)Math.Max(0f, A.ST.PrimeRate() - growth * 365f / 5f));
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00042314 File Offset: 0x00041314
		public override float Dividend
		{
			get
			{
				return this.dividendPct * base.Price;
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00042334 File Offset: 0x00041334
		public override void NewDay()
		{
			base.NewDay();
			float price = 20f;
			if (this.sharePrice.Count > 0)
			{
				price = (float)this.sharePrice[this.sharePrice.Count - 1];
			}
			price *= (float)((double)(1f + this.Growth) + (A.ST.Random.NextDouble() - 0.5) * 0.01 * (double)this.volatility);
			price *= 1f + 0.2f * (A.ST.PrimeRate(A.ST.Now.AddDays(-1.0)) / A.ST.PrimeRate() - 1f);
			price -= this.TotalExpenseRatio / 365f * price;
			if (price < 1f)
			{
				price = 1f;
			}
			this.sharePrice.Add(price);
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0004243C File Offset: 0x0004143C
		public override string CategoryName
		{
			get
			{
				return "Bonds";
			}
		}

		// Token: 0x04000574 RID: 1396
		protected float volatility;

		// Token: 0x04000575 RID: 1397
		protected float dividendPct;
	}
}
