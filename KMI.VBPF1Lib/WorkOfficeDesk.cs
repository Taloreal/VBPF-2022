using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000004 RID: 4
	[Serializable]
	public class WorkOfficeDesk : WorkTask
	{
		// Token: 0x06000017 RID: 23 RVA: 0x000031FF File Offset: 0x000021FF
		public WorkOfficeDesk()
		{
			this.HourlyWage = 11.25f;
			this.AcademicExperienceRequired.Add("Intro to Data Entry");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003230 File Offset: 0x00002230
		public override bool Do()
		{
			switch (this.State)
			{
			case WorkOfficeDesk.States.Init:
				if (!base.Building.Persons.Contains(this.Owner))
				{
					base.Building.Persons.Add(this.Owner);
				}
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Chair" + this.chair).ToPoints();
				this.State = WorkOfficeDesk.States.ToChair;
				break;
			case WorkOfficeDesk.States.ToChair:
				if (this.Owner.Move())
				{
					this.State = WorkOfficeDesk.States.AtChair;
					this.Owner.Pose = "SitNW";
				}
				break;
			case WorkOfficeDesk.States.AtChair:
				if (A.ST.Period == this.EndPeriod)
				{
					this.Owner.Path = base.Building.Map.findPath("Chair" + this.chair, "EntryPoint").ToPoints();
					this.Owner.Pose = "Walk";
					this.State = WorkOfficeDesk.States.FromChair;
				}
				else if (this.typingCounter-- > 0)
				{
					this.Owner.Pose = "SitTypeNW";
				}
				else
				{
					if (A.ST.Random.NextDouble() < (double)((Office)base.Building).Busyness)
					{
						this.typingCounter = 50;
					}
					this.Owner.Pose = "SitNW";
				}
				break;
			case WorkOfficeDesk.States.FromChair:
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				if (this.Owner.Drone)
				{
					DateTime tomorrow = A.ST.Now.AddDays(1.0);
					this.Owner.WakeupTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day).AddHours((double)((float)this.StartPeriod / 2f) - (0.20000000298023224 + 0.10000000149011612 * A.ST.Random.NextDouble()));
					base.Building.Persons.Remove(this.Owner);
					this.State = WorkOfficeDesk.States.Init;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000350B File Offset: 0x0000250B
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = WorkOfficeDesk.States.Init;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000351C File Offset: 0x0000251C
		public override string Name()
		{
			return "Data Entry Specialist";
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003534 File Offset: 0x00002534
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for accurate and timely entry of all data records.");
		}

		// Token: 0x0400001D RID: 29
		public WorkOfficeDesk.States State = WorkOfficeDesk.States.Init;

		// Token: 0x0400001E RID: 30
		public int chair;

		// Token: 0x0400001F RID: 31
		public int typingCounter;

		// Token: 0x02000005 RID: 5
		public enum States
		{
			// Token: 0x04000021 RID: 33
			Init,
			// Token: 0x04000022 RID: 34
			ToChair,
			// Token: 0x04000023 RID: 35
			AtChair,
			// Token: 0x04000024 RID: 36
			FromChair
		}
	}
}
