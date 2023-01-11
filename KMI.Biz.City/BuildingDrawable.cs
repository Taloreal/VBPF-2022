using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.Biz.City
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class BuildingDrawable : FlexDrawable
	{
		// Token: 0x06000040 RID: 64 RVA: 0x000035CC File Offset: 0x000025CC
		public BuildingDrawable(Point location, string imageName, BuildingType BuildingType, int avenue, int street, int lot, long ownerID, float reach, float rent, string billboardOwnerName) : base(location, imageName)
		{
			base.VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom;
			this.BuildingType = BuildingType;
			this.Avenue = avenue;
			this.Street = street;
			this.Lot = lot;
			this.OwnerID = ownerID;
			this.Reach = reach;
			this.Rent = rent;
			this.BillboardOwnerName = billboardOwnerName;
			if (this.BuildingType == City.BuildingTypes[0])
			{
				if (this.OwnerID > -1L)
				{
					this.clickString = " ";
					base.ToolTipText = S.R.GetString("Click to Enter {0}", new object[]
					{
						S.I.EntityName
					});
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003690 File Offset: 0x00002690
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (this.OwnerID != -1L)
			{
				S.MF.OnCurrentEntityChange(this.OwnerID);
				S.MF.OnViewChange(S.I.Views[1].Name);
			}
		}

		// Token: 0x04000036 RID: 54
		public BuildingType BuildingType;

		// Token: 0x04000037 RID: 55
		public int Avenue;

		// Token: 0x04000038 RID: 56
		public int Street;

		// Token: 0x04000039 RID: 57
		public int Lot;

		// Token: 0x0400003A RID: 58
		public long OwnerID;

		// Token: 0x0400003B RID: 59
		public float Reach;

		// Token: 0x0400003C RID: 60
		public float Rent;

		// Token: 0x0400003D RID: 61
		public string BillboardOwnerName;
	}
}
