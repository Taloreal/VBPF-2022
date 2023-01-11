using System;
using System.Collections;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Fund.
	/// </summary>
	// Token: 0x02000037 RID: 55
	[Serializable]
	public class Fund : ActiveObject
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x0001B158 File Offset: 0x0001A158
		public Fund()
		{
			A.I.Subscribe(this, Simulator.TimePeriod.Day);
			this.Fees12B1 = (float)A.ST.Random.Next(5) * 0.0025f;
			this.TotalExpenseRatio = this.Fees12B1 + (float)A.ST.Random.NextDouble() / 100f;
			this.FrontEndLoad = (float)A.ST.Random.Next(4) / 100f;
			this.BackEndLoad = (float)A.ST.Random.Next(4) / 100f;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001B200 File Offset: 0x0001A200
		public float Return(int years)
		{
			float capBegin = (float)this.sharePrice[this.sharePrice.Count - 52 * years];
			float capEnd = this.Price;
			return (float)Math.Pow((double)(capEnd / capBegin), (double)(1f / (float)years)) - 1f;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0001B258 File Offset: 0x0001A258
		public float Price
		{
			get
			{
				return (float)this.sharePrice[this.sharePrice.Count - 1];
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0001B288 File Offset: 0x0001A288
		public DateTime DateLastEntry
		{
			get
			{
				return this.dateLastEntry;
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001B2A0 File Offset: 0x0001A2A0
		public override void NewDay()
		{
			this.dateLastEntry = A.ST.Now;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0001B2B4 File Offset: 0x0001A2B4
		public float PriceOn(DateTime t)
		{
			int daysBack = (this.DateLastEntry - t).Days;
			float result;
			if (daysBack < 1)
			{
				result = this.Price;
			}
			else
			{
				result = (float)this.sharePrice[this.sharePrice.Count - daysBack];
			}
			return result;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0001B30C File Offset: 0x0001A30C
		public float Previous
		{
			get
			{
				return (float)this.sharePrice[this.sharePrice.Count - 2];
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0001B33C File Offset: 0x0001A33C
		public virtual string CategoryName
		{
			get
			{
				return "";
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0001B354 File Offset: 0x0001A354
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0001B36C File Offset: 0x0001A36C
		public virtual float Dividend
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x040001C2 RID: 450
		public ArrayList sharePrice = new ArrayList();

		// Token: 0x040001C3 RID: 451
		public string Name;

		// Token: 0x040001C4 RID: 452
		protected DateTime dateLastEntry;

		// Token: 0x040001C5 RID: 453
		public float TotalExpenseRatio;

		// Token: 0x040001C6 RID: 454
		public float Fees12B1;

		// Token: 0x040001C7 RID: 455
		public float FrontEndLoad;

		// Token: 0x040001C8 RID: 456
		public float BackEndLoad;

		// Token: 0x040001C9 RID: 457
		public float Growth;
	}
}
