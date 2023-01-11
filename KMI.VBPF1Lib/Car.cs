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
	// Token: 0x020000B7 RID: 183
	[Serializable]
	public class Car : TurboMovableActiveObject
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x0004F9A4 File Offset: 0x0004E9A4
		public Car()
		{
			this.LastTuneup = A.ST.Now;
			this.Gas = 20f;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0004FA08 File Offset: 0x0004EA08
		public override bool NewStep()
		{
			float timeStep = (float)(A.ST.SimulatedTimePerStep / 20000);
			this.Gas -= 0.003f * timeStep * 20f / AppConstants.MPGs[this.CarIndex()];
			if (this.Gas < 0f)
			{
				this.Gas = 0f;
			}
			if (base.DX == 0f)
			{
				base.Speed = 0.32f;
			}
			else
			{
				base.Speed = 0.08f;
			}
			bool done = this.Move();
			if (done)
			{
				A.I.UnSubscribe(this);
			}
			return done;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0004FABC File Offset: 0x0004EABC
		public void SetLocation(AppBuilding bldg)
		{
			this.SetLocation(bldg.Avenue, bldg.Street, bldg.Lot);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0004FAD8 File Offset: 0x0004EAD8
		public void SetLocation(int ave, int street, int lot)
		{
			base.Location = TravelTask.DoorWayAt(ave, street, lot);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0004FAEA File Offset: 0x0004EAEA
		public void SendTo(AppBuilding bldg)
		{
			this.SendTo(bldg.Avenue, bldg.Street, bldg.Lot);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0004FB08 File Offset: 0x0004EB08
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
					new PointF((float)ave - 0.25f * (float)(3 - lot), (float)street)
				});
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0004FBD0 File Offset: 0x0004EBD0
		public bool InRegion(int aveRegion, int streetRegion)
		{
			int aveReg = (int)((base.Location.X + 0.7f) / (float)(City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS));
			int streetReg = (int)((base.Location.Y + 0.4f) / (float)(City.NUM_STREETS / City.STREET_VIEWING_REGIONS));
			return aveReg == aveRegion && streetReg == streetRegion;
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0004FC34 File Offset: 0x0004EC34
		public Drawable GetDrawable(int aveRegion, int streetRegion)
		{
			PointF p = City.Transform2(base.Location.X, base.Location.Y, 2f, aveRegion, streetRegion);
			p = new PointF(p.X + 23f, p.Y + 5f);
			string orient;
			if (base.DY != 0f)
			{
				orient = "NWSE";
			}
			else
			{
				orient = "NESW";
			}
			return new Drawable(p, "Car" + orient)
			{
				ToolTipText = A.R.GetString("Gas Remaining: {0} gals.", new object[]
				{
					this.Gas.ToString("N1")
				})
			};
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0004FD00 File Offset: 0x0004ED00
		public float ComputeResalePrice(DateTime now)
		{
			float yearsOwned = (float)(now - this.Purchased).Days;
			return Math.Max(0f, this.OriginalPrice * (1f - yearsOwned / 2920f));
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0004FD48 File Offset: 0x0004ED48
		public static int EstTimeInSteps(int fromAvenue, int fromStreet, int fromLot, int toAvenue, int toStreet, int toLot)
		{
			int time;
			if (toStreet == fromStreet)
			{
				time = (int)(Math.Abs(TravelTask.DoorWayAt(fromAvenue, fromStreet, fromLot).X - TravelTask.DoorWayAt(toAvenue, toStreet, toLot).X) / 0.08f);
			}
			else
			{
				int midAve = toAvenue;
				if ((float)toAvenue > TravelTask.DoorWayAt(fromAvenue, fromStreet, fromLot).X)
				{
					midAve = toAvenue - 1;
				}
				time = (int)(Math.Abs(TravelTask.DoorWayAt(fromAvenue, fromStreet, fromLot).X - (float)midAve) / 0.08f);
				time += (int)((float)Math.Abs(fromStreet - toStreet) / 0.16f);
				time += (int)(Math.Abs(TravelTask.DoorWayAt(toAvenue, toStreet, toLot).X - (float)midAve) / 0.08f);
			}
			return time;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0004FE20 File Offset: 0x0004EE20
		public float LikelihoodOfBreakDown()
		{
			int daysOverdue = (A.ST.Now - this.LastTuneup).Days - 120;
			int daysTotal = (A.ST.Now - this.Purchased).Days;
			float result = (float)daysOverdue / 245f;
			result = Math.Max(result, (float)(daysTotal - 730) / 4380f);
			return result * (50000f / Math.Min(35000f, this.OriginalPrice));
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0004FEAC File Offset: 0x0004EEAC
		public int CarIndex()
		{
			int result;
			if (A.ST.Reserved[this] != null)
			{
				result = (int)A.ST.Reserved[this];
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x0400065B RID: 1627
		public const float SpeedOnStreet = 0.08f;

		// Token: 0x0400065C RID: 1628
		public DateTime Purchased;

		// Token: 0x0400065D RID: 1629
		public float OriginalPrice;

		// Token: 0x0400065E RID: 1630
		public float LeaseCost = 0f;

		// Token: 0x0400065F RID: 1631
		public InstallmentLoan Loan;

		// Token: 0x04000660 RID: 1632
		public float Gas = 0f;

		// Token: 0x04000661 RID: 1633
		public DateTime LastTuneup;

		// Token: 0x04000662 RID: 1634
		public bool Broken = false;

		// Token: 0x04000663 RID: 1635
		public InsurancePolicy Insurance = new InsurancePolicy(250f, false, 1000000f);
	}
}
