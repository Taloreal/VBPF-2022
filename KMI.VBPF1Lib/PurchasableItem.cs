using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for PurchasableItem.
	/// </summary>
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class PurchasableItem
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0001DF50 File Offset: 0x0001CF50
		// (set) Token: 0x060001EE RID: 494 RVA: 0x0001DF68 File Offset: 0x0001CF68
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0001DF74 File Offset: 0x0001CF74
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0001DF8C File Offset: 0x0001CF8C
		public string FriendlyName
		{
			get
			{
				return this.friendlyName;
			}
			set
			{
				this.friendlyName = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0001DF98 File Offset: 0x0001CF98
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x0001DFB0 File Offset: 0x0001CFB0
		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x0001DFBC File Offset: 0x0001CFBC
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x0001DFE1 File Offset: 0x0001CFE1
		public float Price
		{
			get
			{
				return this.price * (1f - this.saleDiscount);
			}
			set
			{
				this.price = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0001DFEC File Offset: 0x0001CFEC
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x0001E004 File Offset: 0x0001D004
		public string ImageName
		{
			get
			{
				return this.imageName;
			}
			set
			{
				this.imageName = value;
			}
		}

		// Token: 0x0400020C RID: 524
		protected string name;

		// Token: 0x0400020D RID: 525
		protected string friendlyName;

		// Token: 0x0400020E RID: 526
		protected string description;

		// Token: 0x0400020F RID: 527
		protected float price;

		// Token: 0x04000210 RID: 528
		protected string imageName;

		// Token: 0x04000211 RID: 529
		public float saleDiscount;
	}
}
