using System;
using System.Drawing;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for TurboMovableActiveObject.
	/// </summary>
	// Token: 0x0200001E RID: 30
	[Serializable]
	public class TurboMovableActiveObject : MovableActiveObject
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x0000BB0C File Offset: 0x0000AB0C
		public override bool Move()
		{
			float timeStep = (float)(A.ST.SimulatedTimePerStep / 20000);
			this.location.X = this.location.X + this.dx * timeStep;
			this.location.Y = this.location.Y + this.dy * timeStep;
			bool arrivedAtDest = Math.Sign(this.destination.X - this.location.X) != Math.Sign(this.dx) || Math.Sign(this.destination.Y - this.location.Y) != Math.Sign(this.dy) || (this.dx == 0f && this.dy == 0f);
			if (arrivedAtDest)
			{
				this.location = this.destination;
				if (base.Path != null && base.Path.Count > 0)
				{
					base.Destination = (PointF)base.Path[0];
					base.Path.RemoveAt(0);
					if (base.PathSpeeds != null && base.PathSpeeds.Count > 0)
					{
						base.Speed = (float)base.PathSpeeds[0];
						base.PathSpeeds.RemoveAt(0);
					}
					arrivedAtDest = false;
				}
			}
			return arrivedAtDest;
		}
	}
}
