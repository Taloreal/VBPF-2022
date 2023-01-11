using System;
using System.Drawing;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Exercise.
	/// </summary>
	// Token: 0x02000087 RID: 135
	[Serializable]
	public class Eat : Task
	{
		// Token: 0x06000433 RID: 1075 RVA: 0x0003A5C4 File Offset: 0x000395C4
		public override bool Do()
		{
			bool result;
			if (A.ST.Period == this.EndPeriod)
			{
				this.Owner.Location = base.Building.Map.getNode("Eat").Location;
				this.Owner.Pose = "StandSE";
				result = true;
			}
			else
			{
				switch (this.State)
				{
				case Eat.States.Init:
					this.Owner.Pose = "Walk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Eat").ToPoints();
					this.State = Eat.States.ToEat;
					break;
				case Eat.States.ToEat:
					if (this.Owner.Move())
					{
						PointF spot = base.Building.Map.getNode("Eat").Location;
						this.Owner.Location = new PointF(spot.X - 50f, spot.Y + 5f);
						this.State = Eat.States.Eat;
					}
					break;
				case Eat.States.Eat:
				{
					AppEntity e = base.GetAppEntity();
					if (e.Food.Count > 0)
					{
						this.Owner.Pose = "EatSE";
					}
					else
					{
						this.Owner.Pose = "SitSE";
						e.Player.SendPeriodicMessage(A.R.GetString("You tried to eat, but there's no more food in fridge!"), "", NotificationColor.Yellow, 1f);
					}
					break;
				}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0003A770 File Offset: 0x00039770
		public override Color GetColor()
		{
			return Color.LightGreen;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0003A788 File Offset: 0x00039788
		public override string CategoryName()
		{
			return A.R.GetString("Eat");
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0003A7A9 File Offset: 0x000397A9
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = Eat.States.Init;
		}

		// Token: 0x040004BF RID: 1215
		private Eat.States State = Eat.States.Init;

		// Token: 0x02000088 RID: 136
		private enum States
		{
			// Token: 0x040004C1 RID: 1217
			Init,
			// Token: 0x040004C2 RID: 1218
			ToEat,
			// Token: 0x040004C3 RID: 1219
			Eat
		}
	}
}
