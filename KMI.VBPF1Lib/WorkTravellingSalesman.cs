using System;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkCounterFastFood.
	/// </summary>
	// Token: 0x02000024 RID: 36
	[Serializable]
	public class WorkTravellingSalesman : WorkTask
	{
		// Token: 0x0600012F RID: 303 RVA: 0x00012193 File Offset: 0x00011193
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = WorkTravellingSalesman.States.Init;
			this.returning = false;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000121AC File Offset: 0x000111AC
		public override bool Do()
		{
			bool result;
			if (A.ST.Period == this.EndPeriod)
			{
				result = true;
			}
			else
			{
				switch (this.State)
				{
				case WorkTravellingSalesman.States.Init:
					this.Car = base.GetAppEntity().Car;
					if (this.Car == null || this.Car.Broken || this.Car.Gas <= 0f)
					{
						string s;
						if (this.Car == null)
						{
							s = A.R.GetString("you don't have a car");
						}
						else if (this.Car.Broken)
						{
							s = A.R.GetString("your car is broken down");
						}
						else
						{
							s = A.R.GetString("your car is out of gas");
						}
						base.GetAppEntity().Player.SendMessage(A.R.GetString("Because {0}, you are unable to do your job as a {1} and have been marked absent for the day.", new object[]
						{
							s,
							this.Name().ToLower()
						}), "", NotificationColor.Yellow);
						this.DatesAbsent.Add(A.ST.Now);
						return true;
					}
					this.State = WorkTravellingSalesman.States.Wait;
					break;
				case WorkTravellingSalesman.States.Drive:
				{
					float timeStep = (float)(A.ST.SimulatedTimePerStep / 20000);
					this.Mileage += (int)timeStep;
					if (this.Car.NewStep())
					{
						this.State = WorkTravellingSalesman.States.Wait;
						this.count = 20;
					}
					break;
				}
				case WorkTravellingSalesman.States.Wait:
					this.count -= A.ST.SimulatedTimePerStep / 20000;
					if (this.count < 0)
					{
						AppBuilding to;
						if (this.returning)
						{
							to = base.Building;
						}
						else
						{
							to = (AppBuilding)A.ST.City.GetRandomBuilding(this.VisitBuildingIndex);
						}
						this.Car.SendTo(to);
						this.returning = !this.returning;
						this.State = WorkTravellingSalesman.States.Drive;
					}
					break;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x04000122 RID: 290
		public int VisitBuildingIndex = 0;

		// Token: 0x04000123 RID: 291
		public WorkTravellingSalesman.States State;

		// Token: 0x04000124 RID: 292
		protected bool returning = false;

		// Token: 0x04000125 RID: 293
		protected int count = 0;

		// Token: 0x04000126 RID: 294
		public Car Car;

		// Token: 0x04000127 RID: 295
		public int Mileage = 0;

		// Token: 0x02000025 RID: 37
		public enum States
		{
			// Token: 0x04000129 RID: 297
			Init,
			// Token: 0x0400012A RID: 298
			Drive,
			// Token: 0x0400012B RID: 299
			Wait
		}
	}
}
