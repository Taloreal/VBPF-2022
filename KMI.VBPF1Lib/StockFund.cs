using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for StockIncome.
	/// </summary>
	// Token: 0x02000073 RID: 115
	[Serializable]
	public class StockFund : Fund
	{
		// Token: 0x060002FC RID: 764 RVA: 0x00033534 File Offset: 0x00032534
		public StockFund(string name, float volatility, float growth)
		{
			this.Name = name;
			DateTime t = new DateTime(2005, 1, 1);
			this.Growth = growth;
			this.volatility = volatility;
			while (t < A.ST.Now)
			{
				this.NewDay();
				t = t.AddDays(1.0);
			}
			this.dividendPct = (float)(A.ST.Random.NextDouble() * (double)Math.Max(0f, 0.05f - growth * 365f / 5f));
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060002FD RID: 765 RVA: 0x000335D4 File Offset: 0x000325D4
		public override float Dividend
		{
			get
			{
				return this.dividendPct * base.Price;
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000335F4 File Offset: 0x000325F4
		public override void NewDay()
		{
			base.NewDay();
			float price = 20f;
			if (this.sharePrice.Count > 0)
			{
				price = (float)this.sharePrice[this.sharePrice.Count - 1];
			}
			price *= (float)((double)(1f + this.Growth) + (A.ST.Random.NextDouble() - 0.5) * 0.01 * (double)this.volatility);
			if (price < 1f)
			{
				price = 1f;
			}
			price -= this.TotalExpenseRatio / 365f * price;
			this.sharePrice.Add(price);
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060002FF RID: 767 RVA: 0x000336B8 File Offset: 0x000326B8
		public override string CategoryName
		{
			get
			{
				string result;
				if ((double)this.volatility > 2.5)
				{
					result = "Intl Stocks";
				}
				else
				{
					result = "U.S. Stocks";
				}
				return result;
			}
		}

		// Token: 0x040003CF RID: 975
		protected float volatility;

		// Token: 0x040003D0 RID: 976
		protected float dividendPct;
	}
}
