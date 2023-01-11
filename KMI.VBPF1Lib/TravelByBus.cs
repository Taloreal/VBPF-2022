using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Travel.
	/// </summary>
	// Token: 0x02000045 RID: 69
	[Serializable]
	public class TravelByBus : TravelTask
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x0001D990 File Offset: 0x0001C990
		public override bool Do()
		{
			switch (this.State)
			{
			case TravelByBus.States.Init:
				this.Pedestrian.SetLocation(this.From);
				base.GetAppEntity().BusTokens--;
				this.From.Persons.Remove(this.Owner);
				A.ST.City.Pedestrians.Add(this.Pedestrian);
				this.Pedestrian.SendTo(A.ST.City.downtownAve, this.From.Street, 3);
				this.State = TravelByBus.States.ToBus;
				break;
			case TravelByBus.States.WaitForBus:
				this.Bus = A.ST.City.BusAt(this.From.Street, Math.Sign(this.To.Street - this.From.Street));
				if (this.Bus != null)
				{
					A.ST.City.Pedestrians.Remove(this.Pedestrian);
					this.State = TravelByBus.States.OnBus;
				}
				break;
			case TravelByBus.States.ToBus:
				if (this.Pedestrian.NewStep())
				{
					this.State = TravelByBus.States.WaitForBus;
				}
				break;
			case TravelByBus.States.OnBus:
				this.Pedestrian.Location = this.Bus.Location;
				if (this.Bus.Location.Y == (float)this.To.Street)
				{
					A.ST.City.Pedestrians.Add(this.Pedestrian);
					this.Pedestrian.Location = this.Bus.Location;
					this.Pedestrian.SendTo(this.To);
					this.State = TravelByBus.States.FromBus;
				}
				break;
			case TravelByBus.States.FromBus:
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

		// Token: 0x060001E4 RID: 484 RVA: 0x0001DC14 File Offset: 0x0001CC14
		public override string CategoryName()
		{
			return A.R.GetString("Travel by Bus");
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001DC35 File Offset: 0x0001CC35
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = TravelByBus.States.Init;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0001DC48 File Offset: 0x0001CC48
		public override int EstTimeInSteps(AppBuilding from, AppBuilding to)
		{
			int time = Pedestrian.EstTimeInSteps(from.Avenue, from.Street, from.Lot, A.ST.City.downtownAve, from.Street, 3);
			time += Bus.EstTimeInSteps(A.ST.City.downtownAve, from.Street, 3, A.ST.City.downtownAve, to.Street, 3);
			time += Pedestrian.EstTimeInSteps(A.ST.City.downtownAve, to.Street, 3, to.Avenue, to.Street, to.Lot);
			time += 600000 / A.ST.SimulatedTimePerStep;
			int altTime = new TravelByFoot().EstTimeInSteps(from, to);
			int result;
			if (altTime < time)
			{
				result = altTime;
			}
			else
			{
				result = time;
			}
			return result;
		}

		// Token: 0x040001FC RID: 508
		private TravelByBus.States State = TravelByBus.States.Init;

		// Token: 0x040001FD RID: 509
		public Pedestrian Pedestrian = new Pedestrian();

		// Token: 0x040001FE RID: 510
		public Bus Bus;

		// Token: 0x040001FF RID: 511
		public AppBuilding BusStop;

		// Token: 0x02000046 RID: 70
		private enum States
		{
			// Token: 0x04000201 RID: 513
			Init,
			// Token: 0x04000202 RID: 514
			ToDoor,
			// Token: 0x04000203 RID: 515
			WaitForBus,
			// Token: 0x04000204 RID: 516
			ToBus,
			// Token: 0x04000205 RID: 517
			OnBus,
			// Token: 0x04000206 RID: 518
			FromBus
		}
	}
}
