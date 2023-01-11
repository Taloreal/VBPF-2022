using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;

namespace KMI.Biz.City
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class Building : ActiveObject
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00003156 File Offset: 0x00002156
		public Building(CityBlock block, int lotIndex, BuildingType type)
		{
			this.block = block;
			this.lotIndex = lotIndex;
			this.BuildingType = type;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00003184 File Offset: 0x00002184
		// (set) Token: 0x06000026 RID: 38 RVA: 0x0000319C File Offset: 0x0000219C
		public ArrayList Occupants
		{
			get
			{
				return this.occupants;
			}
			set
			{
				this.occupants = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000031A8 File Offset: 0x000021A8
		public CityBlock Block
		{
			get
			{
				return this.block;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000031C0 File Offset: 0x000021C0
		public int Avenue
		{
			get
			{
				return this.block.Avenue;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000031E0 File Offset: 0x000021E0
		public int Street
		{
			get
			{
				return this.block.Street;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00003200 File Offset: 0x00002200
		public int Lot
		{
			get
			{
				return this.lotIndex;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003218 File Offset: 0x00002218
		public virtual ArrayList GetDrawables(int centerAvenue, int centerStreet)
		{
			ArrayList arrayList = new ArrayList();
			Point location = Point.Round(City.Transform2((float)this.Avenue, (float)this.Street, (float)this.lotIndex, centerAvenue, centerStreet));
			long ownerID = -1L;
			if (this.Owner != null)
			{
				ownerID = this.Owner.ID;
			}
			string billboardOwnerName = null;
			if (this.BillboardOwner != null)
			{
				billboardOwnerName = this.BillboardOwner.Name;
			}
			arrayList.Add(new BuildingDrawable(location, "Building" + this.BuildingType.Index, this.BuildingType, this.Avenue, this.Street, this.Lot, ownerID, (float)this.Reach, (float)this.Rent, billboardOwnerName));
			return arrayList;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000032E0 File Offset: 0x000022E0
		public virtual ArrayList GetDrawablesWholeCity()
		{
			ArrayList arrayList = new ArrayList();
			Point location = Point.Round(City.TransformWholeCity((float)this.Avenue, (float)this.Street, (float)this.lotIndex));
			long ownerID = -1L;
			if (this.Owner != null)
			{
				ownerID = this.Owner.ID;
			}
			string billboardOwnerName = null;
			if (this.BillboardOwner != null)
			{
				billboardOwnerName = this.BillboardOwner.Name;
			}
			arrayList.Add(new BuildingDrawable(location, "BuildingSmall" + this.BuildingType.Index, this.BuildingType, this.Avenue, this.Street, this.Lot, ownerID, (float)this.Reach, (float)this.Rent, billboardOwnerName));
			return arrayList;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000033A8 File Offset: 0x000023A8
		public int OnAvenue
		{
			get
			{
				int result;
				if (this.Lot == 0 && this.Avenue != 0)
				{
					result = this.Avenue - 1;
				}
				else if (this.Lot == this.block.NumLots - 1)
				{
					result = this.Avenue;
				}
				else
				{
					result = -1;
				}
				return result;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00003404 File Offset: 0x00002404
		// (set) Token: 0x0600002F RID: 47 RVA: 0x0000341C File Offset: 0x0000241C
		public int Reach
		{
			get
			{
				return this.reach;
			}
			set
			{
				this.reach = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00003428 File Offset: 0x00002428
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00003440 File Offset: 0x00002440
		public int Rent
		{
			get
			{
				return this.rent;
			}
			set
			{
				this.rent = value;
			}
		}

		// Token: 0x04000029 RID: 41
		protected ArrayList occupants = new ArrayList();

		// Token: 0x0400002A RID: 42
		protected CityBlock block;

		// Token: 0x0400002B RID: 43
		protected int lotIndex;

		// Token: 0x0400002C RID: 44
		public BuildingType BuildingType;

		// Token: 0x0400002D RID: 45
		protected int reach;

		// Token: 0x0400002E RID: 46
		protected int rent;

		// Token: 0x0400002F RID: 47
		public Entity Owner;

		// Token: 0x04000030 RID: 48
		public Entity BillboardOwner;
	}
}
