using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Exercise.
	/// </summary>
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class Exercise : Task
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0000B6CC File Offset: 0x0000A6CC
		public override bool Do()
		{
			switch (this.State)
			{
			case Exercise.States.Init:
				this.Owner.Pose = "Walk";
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "TreadMillWalk").ToPoints();
				this.State = Exercise.States.ToTreadMill;
				break;
			case Exercise.States.ToTreadMill:
				if (this.Owner.Move())
				{
					if (!base.GetAppEntity().Has("TreadMill"))
					{
						PointF spot = base.Building.Map.getNode("TreadMillWalk").Location;
						this.Owner.Location = new PointF(spot.X, spot.Y + 24f);
						this.Owner.Pose = "JumpingJacksSW";
					}
					this.State = Exercise.States.Exercise;
				}
				break;
			case Exercise.States.Exercise:
				if (A.ST.Period == this.EndPeriod)
				{
					this.Owner.Location = base.Building.Map.getNode("TreadMillWalk").Location;
					this.Owner.Pose = "StandSW";
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000B830 File Offset: 0x0000A830
		public override Color GetColor()
		{
			return Color.Orange;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000B848 File Offset: 0x0000A848
		public override string CategoryName()
		{
			return A.R.GetString("Exercise");
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000B869 File Offset: 0x0000A869
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = Exercise.States.Init;
		}

		// Token: 0x04000108 RID: 264
		private Exercise.States State = Exercise.States.Init;

		// Token: 0x0200001C RID: 28
		private enum States
		{
			// Token: 0x0400010A RID: 266
			Init,
			// Token: 0x0400010B RID: 267
			ToTreadMill,
			// Token: 0x0400010C RID: 268
			Exercise
		}
	}
}
