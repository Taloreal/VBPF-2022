using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Travel.
	/// </summary>
	// Token: 0x02000027 RID: 39
	[Serializable]
	public class TravelByCar : TravelTask
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00012490 File Offset: 0x00011490
		public override bool Do()
		{
			switch (this.State)
			{
			case TravelByCar.States.Init:
				this.From.Persons.Remove(this.Owner);
				this.Car.SendTo(this.To);
				this.State = TravelByCar.States.Drive;
				break;
			case TravelByCar.States.Drive:
				if (this.Car.NewStep())
				{
					this.Owner.Pose = "StandSW";
					this.To.Persons.Add(this.Owner);
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

		// Token: 0x06000138 RID: 312 RVA: 0x00012570 File Offset: 0x00011570
		public override string CategoryName()
		{
			return A.R.GetString("Travel by Car");
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00012591 File Offset: 0x00011591
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = TravelByCar.States.Init;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000125A4 File Offset: 0x000115A4
		public override int EstTimeInSteps(AppBuilding from, AppBuilding to)
		{
			return Car.EstTimeInSteps(from.Avenue, from.Street, from.Lot, to.Avenue, to.Street, to.Lot) + 4;
		}

		// Token: 0x0400012E RID: 302
		private TravelByCar.States State = TravelByCar.States.Init;

		// Token: 0x0400012F RID: 303
		public Car Car;

		// Token: 0x02000028 RID: 40
		private enum States
		{
			// Token: 0x04000131 RID: 305
			Init,
			// Token: 0x04000132 RID: 306
			ToDoor,
			// Token: 0x04000133 RID: 307
			Drive
		}
	}
}
