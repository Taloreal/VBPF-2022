using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for AppBuilding.
	/// </summary>
	// Token: 0x0200005A RID: 90
	[Serializable]
	public class AppBuilding : Building
	{
		// Token: 0x06000268 RID: 616 RVA: 0x00027E28 File Offset: 0x00026E28
		public AppBuilding(CityBlock block, int lotIndex, BuildingType type) : base(block, lotIndex, type)
		{
			this.ID = A.ST.GetNextID();
			this.ownerName = Utilities.GetRandomFirstName(A.ST.Random);
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00027E7C File Offset: 0x00026E7C
		public string OwnerName
		{
			get
			{
				return this.ownerName + "'s " + this.Description;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00027EA4 File Offset: 0x00026EA4
		public string Description
		{
			get
			{
				return this.BuildingType.Name;
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00027EC4 File Offset: 0x00026EC4
		public override ArrayList GetDrawables(int aveRegion, int streetRegion)
		{
			ArrayList d = new ArrayList();
			string clickString = "";
			foreach (object obj in this.Offerings)
			{
				Offering a = (Offering)obj;
				if (!a.Taken)
				{
					clickString = clickString + a.Description() + AppBuilding.cr + AppBuilding.cr;
				}
			}
			if (clickString != "")
			{
				clickString = A.R.GetString("Available {0}:", new object[]
				{
					((Offering)this.Offerings[0]).ThingName()
				}) + AppBuilding.cr + AppBuilding.cr + clickString;
			}
			if (this.BuildingType.Index == 6)
			{
				clickString = A.R.GetString("Bus Stop: Buy tokens here!");
			}
			if (this.BuildingType.Index == 8)
			{
				clickString = ((BankAccount)this.Offerings[0]).BankName + " -- " + clickString;
			}
			if (this.BuildingType.Index == 12)
			{
				clickString = A.R.GetString("{0}: Offering furniture, computers, and more!", new object[]
				{
					this.OwnerName
				});
			}
			if (this.BuildingType.Index == 9)
			{
				clickString = A.R.GetString("Taranti Auto & Loan: New and Used Cars for Less!");
			}
			if (this.BuildingType.Index == 11)
			{
				clickString = A.R.GetString("Steiner & Wilson: Insuring Your Happiness");
			}
			if (this.BuildingType.Index == 13)
			{
				clickString = A.R.GetString("Supermarket for all your food needs!");
			}
			if (this.BuildingType.Index == 14)
			{
				clickString = A.R.GetString("InternetConnect for super fast Internet access!");
			}
			if (this.BuildingType.Index == 15)
			{
				clickString = A.R.GetString("Auto Garage: gas, preventive maintenance, repairs and more!");
			}
			if (this.BuildingType.Index == 16)
			{
				clickString = A.R.GetString("Fiduciary Investments: Make Your Money Grow!");
			}
			Point bldgPt = Point.Round(City.Transform2((float)base.Avenue, (float)base.Street, (float)this.lotIndex, aveRegion, streetRegion));
			long ownerID = -1L;
			bool isOwnersDwelling = false;
			if (this.Owner != null)
			{
				ownerID = this.Owner.ID;
				isOwnersDwelling = (((AppEntity)this.Owner).Dwelling == this);
			}
			d.Add(new AppBuildingDrawable(bldgPt, "Building" + this.BuildingType.Index, this.BuildingType, base.Avenue, base.Street, base.Lot, ownerID, (ArrayList)this.Offerings.Clone(), clickString, isOwnersDwelling)
			{
				BuildingID = this.ID
			});
			return d;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00028208 File Offset: 0x00027208
		public virtual ArrayList GetInsideDrawables()
		{
			return new ArrayList();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00028220 File Offset: 0x00027220
		public virtual string GetBackgroundImage()
		{
			return "Not Implemented";
		}

		// Token: 0x040002D6 RID: 726
		public long ID;

		// Token: 0x040002D7 RID: 727
		protected string ownerName;

		// Token: 0x040002D8 RID: 728
		private static string cr = Environment.NewLine;

		// Token: 0x040002D9 RID: 729
		public ArrayList Offerings = new ArrayList();

		// Token: 0x040002DA RID: 730
		public ArrayList Persons = new ArrayList();

		// Token: 0x040002DB RID: 731
		public PointF EntryPoint;

		// Token: 0x040002DC RID: 732
		public MapV2 Map;

		// Token: 0x040002DD RID: 733
		public float[] Prices;

		// Token: 0x040002DE RID: 734
		public float[] SaleDiscounts;
	}
}
