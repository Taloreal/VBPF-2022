using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.Biz.City
{
	// Token: 0x02000004 RID: 4
	[Serializable]
	public class CityBlock : ActiveObject
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002DB0 File Offset: 0x00001DB0
		public CityBlock(City city, int avenue, int street, int numLots, SizeF size, PointF location, float avenueWidth, float streetWidth)
		{
			this.City = city;
			this.Avenue = avenue;
			this.Street = street;
			this.numLots = numLots;
			this.location = location;
			this.avenueWidth = 0f;
			this.buildings = new Building[numLots];
			this.streetTraffic = new Traffic(false, this);
			this.avenueTraffic = new Traffic(true, this);
		}

		// Token: 0x17000005 RID: 5
		public Building this[int lotIndex]
		{
			get
			{
				return this.buildings[lotIndex];
			}
			set
			{
				this.buildings[lotIndex] = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002E48 File Offset: 0x00001E48
		public int NumLots
		{
			get
			{
				return this.numLots;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002E60 File Offset: 0x00001E60
		public override void NewWeek()
		{
			for (int i = 0; i < this.NumLots; i++)
			{
				Building building = this[i];
				if (building != null)
				{
					building.NewWeek();
				}
			}
			if (this.avenueWidth > 0f)
			{
				this.avenueWidth -= 1f;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002EC4 File Offset: 0x00001EC4
		public ArrayList GetDrawables(int centerAvenue, int centerStreet)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < this.numLots; i++)
			{
				if (this.buildings[i] != null)
				{
					arrayList.AddRange(this.buildings[i].GetDrawables(centerAvenue, centerStreet));
				}
				else if (this.City.VacantLotImageName != null)
				{
					arrayList.Add(new FlexDrawable(City.Transform2((float)this.Avenue, (float)this.Street, (float)i, centerAvenue, centerStreet), this.City.VacantLotImageName + this.City.VacantLotImageIndices[this.Avenue, this.Street, i])
					{
						VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom
					});
				}
			}
			if (!this.GetConstruction())
			{
				arrayList.AddRange(this.streetTraffic.GetDrawables(this, centerAvenue, centerStreet));
				arrayList.AddRange(this.avenueTraffic.GetDrawables(this, centerAvenue, centerStreet));
			}
			return arrayList;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002FD4 File Offset: 0x00001FD4
		public ArrayList GetDrawablesWholeCity()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < this.numLots; i++)
			{
				if (this.buildings[i] != null)
				{
					arrayList.AddRange(this.buildings[i].GetDrawablesWholeCity());
				}
				else if (this.City.VacantLotImageName != null)
				{
					arrayList.Add(new FlexDrawable(City.TransformWholeCity((float)this.Avenue, (float)this.Street, (float)i), this.City.VacantLotImageName + this.City.VacantLotImageIndices[this.Avenue, this.Street, i] + "Small")
					{
						VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom
					});
				}
			}
			if (!this.GetConstruction())
			{
				arrayList.AddRange(this.streetTraffic.GetDrawablesWholeCity(this));
				arrayList.AddRange(this.avenueTraffic.GetDrawablesWholeCity(this));
			}
			return arrayList;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000030E4 File Offset: 0x000020E4
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000030FC File Offset: 0x000020FC
		public Traffic AvenueTraffic
		{
			get
			{
				return this.avenueTraffic;
			}
			set
			{
				this.avenueTraffic = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00003108 File Offset: 0x00002108
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00003120 File Offset: 0x00002120
		public Traffic StreetTraffic
		{
			get
			{
				return this.streetTraffic;
			}
			set
			{
				this.streetTraffic = value;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000312C File Offset: 0x0000212C
		public bool GetConstruction()
		{
			return this.avenueWidth > 0f;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000314B File Offset: 0x0000214B
		public void SetConstruction(int weeksRemaining)
		{
			this.avenueWidth = (float)weeksRemaining;
		}

		// Token: 0x04000020 RID: 32
		protected int numLots;

		// Token: 0x04000021 RID: 33
		public int Avenue;

		// Token: 0x04000022 RID: 34
		public int Street;

		// Token: 0x04000023 RID: 35
		protected Traffic avenueTraffic;

		// Token: 0x04000024 RID: 36
		protected Traffic streetTraffic;

		// Token: 0x04000025 RID: 37
		protected Building[] buildings;

		// Token: 0x04000026 RID: 38
		protected float avenueWidth;

		// Token: 0x04000027 RID: 39
		protected PointF location;

		// Token: 0x04000028 RID: 40
		protected City City;
	}
}
