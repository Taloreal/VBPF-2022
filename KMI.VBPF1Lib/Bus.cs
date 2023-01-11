using System;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Bus.
	/// </summary>
	// Token: 0x0200001F RID: 31
	[Serializable]
	public class Bus : TurboMovableActiveObject
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x0000BC84 File Offset: 0x0000AC84
		public Bus(int avenue, int street, bool onAvenue, int direction)
		{
			base.Location = new PointF((float)avenue, (float)street + (float)(0.6 * (A.ST.Random.NextDouble() - 0.5)));
			base.Destination = this.GetNextDestination();
			this.street = street;
			this.avenue = avenue;
			this.onAvenue = onAvenue;
			this.direction = direction;
			base.Speed = 0.52f;
			S.I.Subscribe(this, Simulator.TimePeriod.Step);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000BD20 File Offset: 0x0000AD20
		public override bool NewStep()
		{
			switch (this.State)
			{
			case Bus.States.AtStop:
				this.counter -= A.ST.SimulatedTimePerStep / 20000;
				if (this.counter <= 0)
				{
					base.Destination = this.GetNextDestination();
					this.State = Bus.States.Enroute;
				}
				break;
			case Bus.States.Enroute:
				if (this.Move())
				{
					this.counter = 2;
					this.State = Bus.States.AtStop;
				}
				break;
			}
			return false;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000BDAC File Offset: 0x0000ADAC
		public PointF GetNextDestination()
		{
			PointF result;
			if (this.onAvenue)
			{
				int nextStreet = this.street + this.direction;
				if (nextStreet < 0 || nextStreet >= City.NUM_STREETS)
				{
					this.direction = -this.direction;
					nextStreet = this.street + this.direction;
				}
				this.street = nextStreet;
				result = new PointF((float)this.avenue, (float)this.street);
			}
			else
			{
				int nextAve = this.avenue + this.direction;
				if (nextAve < 0 || nextAve >= City.NUM_AVENUES)
				{
					this.direction = -this.direction;
					nextAve = this.avenue + this.direction;
				}
				this.avenue = nextAve;
				result = new PointF((float)this.avenue, (float)this.street);
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000BE80 File Offset: 0x0000AE80
		public bool InRegion(int aveRegion, int streetRegion)
		{
			int aveReg = (int)((base.Location.X + 0.7f) / (float)(City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS));
			int streetReg = (int)((base.Location.Y + 0.4f) / (float)(City.NUM_STREETS / City.STREET_VIEWING_REGIONS));
			return aveReg == aveRegion && streetReg == streetRegion;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000BEE4 File Offset: 0x0000AEE4
		public Drawable GetDrawable(int aveRegion, int streetRegion)
		{
			PointF p = City.Transform2(base.Location.X, base.Location.Y, 2f, aveRegion, streetRegion);
			string orient = "SE";
			if (base.DY < 0f)
			{
				orient = "NW";
			}
			p = new PointF(p.X - 5f, p.Y - 13f);
			return new Drawable(p, "Bus" + orient);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000BF74 File Offset: 0x0000AF74
		public static int EstTimeInSteps(int fromAvenue, int fromStreet, int fromLot, int toAvenue, int toStreet, int toLot)
		{
			int time = 0;
			int streets = Math.Abs(fromStreet - toStreet);
			time += (int)((float)streets / 0.26f);
			return time + 2 * streets;
		}

		// Token: 0x04000111 RID: 273
		public const float SpeedOnStreet = 0.13f;

		// Token: 0x04000112 RID: 274
		private const int StopTime = 2;

		// Token: 0x04000113 RID: 275
		private const int StopEvery = 2;

		// Token: 0x04000114 RID: 276
		protected bool onAvenue;

		// Token: 0x04000115 RID: 277
		protected int avenue;

		// Token: 0x04000116 RID: 278
		protected int street;

		// Token: 0x04000117 RID: 279
		protected int direction = 1;

		// Token: 0x04000118 RID: 280
		protected int counter;

		// Token: 0x04000119 RID: 281
		public Bus.States State = Bus.States.AtStop;

		// Token: 0x02000020 RID: 32
		public enum States
		{
			// Token: 0x0400011B RID: 283
			AtStop,
			// Token: 0x0400011C RID: 284
			Enroute
		}
	}
}
