using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Exercise.
	/// </summary>
	// Token: 0x0200003F RID: 63
	[Serializable]
	public class Dance : OneTimeEvent
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x0001D2F2 File Offset: 0x0001C2F2
		public Dance()
		{
			this.rnd = (float)A.ST.Random.NextDouble();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0001D31C File Offset: 0x0001C31C
		public override bool Do()
		{
			AppEntity host = (AppEntity)A.ST.Entity[this.HostID];
			bool result;
			if (A.ST.Period == this.EndPeriod)
			{
				this.CleanUp();
				if (this.Owner.Drone)
				{
					base.Building.Persons.Remove(this.Owner);
					this.Owner.Retire();
					result = false;
				}
				else
				{
					this.Owner.Pose = "StandSW";
					this.Owner.Location = base.Building.Map.getNode("Dance").Location;
					result = true;
				}
			}
			else
			{
				switch (this.State)
				{
				case Dance.States.Init:
					if (!base.Building.Persons.Contains(this.Owner))
					{
						base.Building.Persons.Add(this.Owner);
					}
					this.Owner.Pose = "Walk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Dance").ToPoints();
					if (host != null)
					{
						if (host.PartyAttendance.Contains(base.Key))
						{
							host.PartyAttendance[base.Key] = (int)host.PartyAttendance[base.Key] + 1;
						}
						else
						{
							host.PartyAttendance.Add(base.Key, 1);
						}
					}
					this.State = Dance.States.ToDance;
					break;
				case Dance.States.ToDance:
					if (this.Owner.Move())
					{
						PointF danceBase = base.Building.Map.getNode("Dance").Location;
						float SWoffset = (float)(A.ST.Random.Next(80) - 20);
						float NWoffset = (float)(A.ST.Random.Next(20) - 10);
						this.Owner.Location = new PointF(danceBase.X - SWoffset - NWoffset, danceBase.Y + SWoffset / 2f - NWoffset / 2f);
						this.Owner.Pose = "DanceSW";
						this.State = Dance.States.Dance;
					}
					break;
				case Dance.States.Dance:
					if (host != null && host.DDRLockedBy == -1L && host.Has("DDR") && A.ST.Random.Next(20) == 0)
					{
						host.DDRLockedBy = this.Owner.ID;
						this.Owner.Pose = "Walk";
						this.Owner.Path = base.Building.Map.findPath("Dance", "DDR").ToPoints();
						this.State = Dance.States.ToDDR;
					}
					break;
				case Dance.States.ToDDR:
					if (this.Owner.Move())
					{
						this.Owner.Pose = "DanceSW";
						this.Owner.Location = new PointF(this.Owner.Location.X, this.Owner.Location.Y + 10f);
						this.State = Dance.States.DDR;
						this.DDRCounter = 30;
					}
					break;
				case Dance.States.DDR:
					if (this.DDRCounter-- < 0)
					{
						this.Owner.Path = base.Building.Map.findPath("DDR", "Dance").ToPoints();
						host.DDRLockedBy = -1L;
						this.Owner.Pose = "Walk";
						this.Owner.Location = new PointF(this.Owner.Location.X, this.Owner.Location.Y - 10f);
						this.State = Dance.States.ToDance;
					}
					break;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0001D798 File Offset: 0x0001C798
		public override string CategoryName()
		{
			return A.R.GetString("Party");
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0001D7BC File Offset: 0x0001C7BC
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = Dance.States.Init;
			AppEntity host = (AppEntity)A.ST.Entity[this.HostID];
			if (host != null)
			{
				host.PartyFood.Clear();
				if (host.DDRLockedBy == this.Owner.ID)
				{
					host.DDRLockedBy = -1L;
				}
			}
		}

		// Token: 0x040001F0 RID: 496
		private Dance.States State = Dance.States.Init;

		// Token: 0x040001F1 RID: 497
		private int DDRCounter;

		// Token: 0x02000040 RID: 64
		private enum States
		{
			// Token: 0x040001F3 RID: 499
			Init,
			// Token: 0x040001F4 RID: 500
			ToDance,
			// Token: 0x040001F5 RID: 501
			Dance,
			// Token: 0x040001F6 RID: 502
			ToDDR,
			// Token: 0x040001F7 RID: 503
			DDR
		}
	}
}
