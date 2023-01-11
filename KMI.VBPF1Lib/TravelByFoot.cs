using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Travel.
	/// </summary>
	// Token: 0x02000062 RID: 98
	[Serializable]
	public class TravelByFoot : TravelTask
	{
		// Token: 0x0600028B RID: 651 RVA: 0x00029314 File Offset: 0x00028314
		public override bool Do()
		{
			switch (this.State)
			{
			case TravelByFoot.States.Init:
				this.Pedestrian.SetLocation(this.From);
				this.From.Persons.Remove(this.Owner);
				A.ST.City.Pedestrians.Add(this.Pedestrian);
				this.Pedestrian.SendTo(this.To);
				this.State = TravelByFoot.States.Drive;
				break;
			case TravelByFoot.States.Drive:
				if (this.Pedestrian.NewStep())
				{
					this.Owner.Pose = "StandSW";
					this.To.Persons.Add(this.Owner);
					A.ST.City.Pedestrians.Remove(this.Pedestrian);
					if (this.To.Map != null)
					{
						this.Owner.Location = this.To.Map.getNode("EntryPoint").Location;
					}
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00029444 File Offset: 0x00028444
		public override string CategoryName()
		{
			return A.R.GetString("Travel by Foot");
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00029465 File Offset: 0x00028465
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = TravelByFoot.States.Init;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00029478 File Offset: 0x00028478
		public override int EstTimeInSteps(AppBuilding from, AppBuilding to)
		{
			return Pedestrian.EstTimeInSteps(from.Avenue, from.Street, from.Lot, to.Avenue, to.Street, to.Lot) + 4;
		}

		// Token: 0x040002FB RID: 763
		private TravelByFoot.States State = TravelByFoot.States.Init;

		// Token: 0x040002FC RID: 764
		public Pedestrian Pedestrian = new Pedestrian();

		// Token: 0x02000063 RID: 99
		private enum States
		{
			// Token: 0x040002FE RID: 766
			Init,
			// Token: 0x040002FF RID: 767
			ToDoor,
			// Token: 0x04000300 RID: 768
			Drive
		}
	}
}
