using System;
using System.Drawing;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Sleep.
	/// </summary>
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class Sleep : Task
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00007F30 File Offset: 0x00006F30
		public override bool Do()
		{
			switch (this.State)
			{
			case Sleep.States.Init:
			{
				this.Owner.Pose = "Walk";
				PathV2 p = base.Building.Map.findPath(this.Owner.Location, "Bed");
				this.Owner.Path = p.ToPoints();
				this.State = Sleep.States.ToBed;
				break;
			}
			case Sleep.States.ToBed:
				if (this.Owner.Move())
				{
					PointF bed = base.Building.Map.getNode("Bed").Location;
					this.Owner.Location = new PointF(bed.X + 62f, bed.Y + 52f);
					this.Owner.Pose = "SleepSW";
					this.State = Sleep.States.Sleep;
				}
				break;
			case Sleep.States.Sleep:
				if (A.ST.Period == this.EndPeriod)
				{
					this.Owner.Location = base.Building.Map.getNode("Bed").Location;
					this.Owner.Pose = "StandSW";
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00008088 File Offset: 0x00007088
		public override Color GetColor()
		{
			return Color.Blue;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000080A0 File Offset: 0x000070A0
		public override string CategoryName()
		{
			return A.R.GetString("Sleep");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000080C1 File Offset: 0x000070C1
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = Sleep.States.Init;
		}

		// Token: 0x040000BA RID: 186
		private Sleep.States State = Sleep.States.Init;

		// Token: 0x02000014 RID: 20
		private enum States
		{
			// Token: 0x040000BC RID: 188
			Init,
			// Token: 0x040000BD RID: 189
			ToBed,
			// Token: 0x040000BE RID: 190
			Sleep
		}
	}
}
