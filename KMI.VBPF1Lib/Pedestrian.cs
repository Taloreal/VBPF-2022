using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Car.
	/// </summary>
	// Token: 0x0200009F RID: 159
	[Serializable]
	public class Pedestrian : TurboMovableActiveObject
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x00045EAC File Offset: 0x00044EAC
		public override bool NewStep()
		{
			if (base.DX == 0f)
			{
				base.Speed = 0.04f;
				this.count++;
			}
			else
			{
				base.Speed = 0.01f;
			}
			bool done = this.Move();
			if (done)
			{
				A.I.UnSubscribe(this);
				this.count = 0;
			}
			return done;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00045F21 File Offset: 0x00044F21
		public void SetLocation(AppBuilding bldg)
		{
			this.SetLocation(bldg.Avenue, bldg.Street, bldg.Lot);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00045F3D File Offset: 0x00044F3D
		public void SetLocation(int ave, int street, int lot)
		{
			base.Location = TravelTask.DoorWayAt(ave, street, lot);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00045F4F File Offset: 0x00044F4F
		public void SendTo(AppBuilding bldg)
		{
			this.SendTo(bldg.Avenue, bldg.Street, bldg.Lot);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00045F6C File Offset: 0x00044F6C
		public void SendTo(int ave, int street, int lot)
		{
			if ((float)street == base.Location.Y)
			{
				base.Destination = TravelTask.DoorWayAt(ave, street, lot);
			}
			else
			{
				int midAve = ave;
				if ((float)ave > base.Location.X)
				{
					midAve = ave - 1;
				}
				base.Path = new ArrayList(new PointF[]
				{
					new PointF((float)midAve, base.Location.Y),
					new PointF((float)midAve, (float)street),
					TravelTask.DoorWayAt(ave, street, lot)
				});
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00046028 File Offset: 0x00045028
		public bool InRegion(int aveRegion, int streetRegion)
		{
			int aveReg = (int)((base.Location.X + 0.7f) / (float)(City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS));
			int streetReg = (int)((base.Location.Y + 0.4f) / (float)(City.NUM_STREETS / City.STREET_VIEWING_REGIONS));
			return aveReg == aveRegion && streetReg == streetRegion;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0004608C File Offset: 0x0004508C
		public Drawable GetDrawable(int aveRegion, int streetRegion)
		{
			PointF p = City.Transform2(base.Location.X, base.Location.Y, 2f, aveRegion, streetRegion);
			p = new PointF(p.X + 23f, p.Y + 5f);
			return new Drawable(p, "Walker", "Ave:" + base.Location.X.ToString() + " St:" + base.Location.Y.ToString());
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00046130 File Offset: 0x00045130
		public static int EstTimeInSteps(int fromAvenue, int fromStreet, int fromLot, int toAvenue, int toStreet, int toLot)
		{
			int time;
			if (toStreet == fromStreet)
			{
				time = (int)(Math.Abs(TravelTask.DoorWayAt(fromAvenue, fromStreet, fromLot).X - TravelTask.DoorWayAt(toAvenue, toStreet, toLot).X) / 0.01f);
			}
			else
			{
				int midAve = toAvenue;
				if ((float)toAvenue > TravelTask.DoorWayAt(fromAvenue, fromStreet, fromLot).X)
				{
					midAve = toAvenue - 1;
				}
				time = (int)(Math.Abs(TravelTask.DoorWayAt(fromAvenue, fromStreet, fromLot).X - (float)midAve) / 0.01f);
				time += (int)((float)Math.Abs(fromStreet - toStreet) / 0.02f);
				time += (int)(Math.Abs(TravelTask.DoorWayAt(toAvenue, toStreet, toLot).X - (float)midAve) / 0.01f);
			}
			return time;
		}

		// Token: 0x040005C5 RID: 1477
		public const float SpeedOnStreet = 0.01f;

		// Token: 0x040005C6 RID: 1478
		private int count = 0;
	}
}
