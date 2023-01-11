using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Relax.
	/// </summary>
	// Token: 0x02000047 RID: 71
	[Serializable]
	public class Relax : Task
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x0001DD30 File Offset: 0x0001CD30
		public override bool Do()
		{
			switch (this.State)
			{
			case Relax.States.Init:
				this.Owner.Pose = "Walk";
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Couch").ToPoints();
				this.State = Relax.States.ToCouch;
				break;
			case Relax.States.ToCouch:
				if (this.Owner.Move())
				{
					PointF couch = base.Building.Map.getNode("Couch").Location;
					if (base.GetAppEntity().Has("Couch"))
					{
						this.Owner.Location = new PointF(couch.X + 12f, couch.Y - 6f);
						this.Owner.Pose = "SitSW";
					}
					else
					{
						this.Owner.Pose = "StandSW";
					}
					this.State = Relax.States.Relax;
				}
				break;
			case Relax.States.Relax:
				if (A.ST.Period == this.EndPeriod)
				{
					this.Owner.Location = base.Building.Map.getNode("Couch").Location;
					this.Owner.Pose = "StandSW";
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0001DEB0 File Offset: 0x0001CEB0
		public override Color GetColor()
		{
			return Color.LightBlue;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0001DEC8 File Offset: 0x0001CEC8
		public override string CategoryName()
		{
			return A.R.GetString("Relax");
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0001DEEC File Offset: 0x0001CEEC
		public override void CleanUp()
		{
			base.CleanUp();
			this.Owner.Location = base.Building.Map.getNode("Couch").Location;
			this.Owner.Pose = "StandSW";
			this.State = Relax.States.Init;
		}

		// Token: 0x04000207 RID: 519
		private Relax.States State = Relax.States.Init;

		// Token: 0x02000048 RID: 72
		private enum States
		{
			// Token: 0x04000209 RID: 521
			Init,
			// Token: 0x0400020A RID: 522
			ToCouch,
			// Token: 0x0400020B RID: 523
			Relax
		}
	}
}
