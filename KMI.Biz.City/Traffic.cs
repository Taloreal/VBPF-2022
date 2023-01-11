using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.City
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class Traffic
	{
		// Token: 0x06000042 RID: 66 RVA: 0x000036DC File Offset: 0x000026DC
		public Traffic(bool isAvenue, CityBlock block)
		{
			this.startPos = S.ST.Random.Next(1000);
			if (!isAvenue)
			{
				this.beginLane1 = new PointF(78f, -6f);
				float num = (float)block.NumLots * City.LOT_SPACING;
				this.endLane1 = new PointF(this.beginLane1.X + num, this.beginLane1.Y - num / 2f);
				this.beginLane2 = new PointF(this.endLane1.X - 10f, this.endLane1.Y - 5f);
				this.endLane2 = new PointF(this.beginLane1.X - 10f, this.beginLane1.Y - 5f);
			}
			else
			{
				this.beginLane1 = new PointF(53f, -11f);
				this.endLane1 = new PointF(this.beginLane1.X - City.LOT_SPACING, this.beginLane1.Y - City.LOT_SPACING / 2f);
				this.beginLane2 = new PointF(this.endLane1.X - 10f, this.endLane1.Y + 5f);
				this.endLane2 = new PointF(this.beginLane1.X - 10f, this.beginLane1.Y + 5f);
			}
			if (!isAvenue)
			{
				this.beginLane1W = new PointF(26f, -2f);
				float num = (float)block.NumLots * City.LOT_SPACING;
				this.endLane1W = new PointF(this.beginLane1W.X + num / 3f, this.beginLane1W.Y - num / 3f / 2f);
				this.beginLane2W = new PointF(this.endLane1W.X - 3f, this.endLane1W.Y - 2f);
				this.endLane2W = new PointF(this.beginLane1W.X - 3f, this.beginLane1W.Y - 2f);
			}
			else
			{
				this.beginLane1W = new PointF(17f, -4f);
				this.endLane1W = new PointF(this.beginLane1W.X - City.LOT_SPACING / 3f, this.beginLane1W.Y - City.LOT_SPACING / 3f / 2f);
				this.beginLane2W = new PointF(this.endLane1W.X - 3f, this.endLane1W.Y + 2f);
				this.endLane2W = new PointF(this.beginLane1W.X - 3f, this.beginLane1W.Y + 2f);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000039E8 File Offset: 0x000029E8
		public void IncrementDensity(int hour, int personType, float amount)
		{
			this.density[hour, personType] += amount;
			if (this.density[hour, personType] < 0f)
			{
				this.density[hour, personType] = 0f;
			}
			if (this.density[hour, personType] > 1f)
			{
				this.density[hour, personType] = 1f;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003A6C File Offset: 0x00002A6C
		public float GetDensity(int hour, int personType)
		{
			return this.density[hour, personType];
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003A8C File Offset: 0x00002A8C
		public float GetDensity(int hour)
		{
			float num = 0f;
			for (int i = 0; i <= this.density.GetUpperBound(1); i++)
			{
				num += this.density[hour, i];
			}
			return num;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003AD4 File Offset: 0x00002AD4
		public float GetDensity()
		{
			float num = 0f;
			for (int i = 0; i <= this.density.GetUpperBound(0); i++)
			{
				num += this.GetDensity(i);
			}
			return num;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003B18 File Offset: 0x00002B18
		public ArrayList GetDrawables(CityBlock block, int centerAvenue, int centerStreet)
		{
			PointF p = City.Transform2((float)block.Avenue, (float)block.Street, (float)block.NumLots, centerAvenue, centerStreet);
			ArrayList arrayList = new ArrayList();
			float num = this.GetDensity(S.ST.Hour);
			ArrayList result;
			if (num < 0.001f)
			{
				result = arrayList;
			}
			else
			{
				float num2 = 4f / num;
				arrayList.Add(new TrafficDrawable(Utilities.AddPointFs(p, this.beginLane1), Utilities.AddPointFs(p, this.endLane1), (float)(S.ST.FrameCounter + this.startPos) % num2, num2, true));
				arrayList.Add(new TrafficDrawable(Utilities.AddPointFs(p, this.beginLane2), Utilities.AddPointFs(p, this.endLane2), (float)(S.ST.FrameCounter + this.startPos) % num2, num2, true));
				result = arrayList;
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003BF8 File Offset: 0x00002BF8
		public ArrayList GetDrawablesWholeCity(CityBlock block)
		{
			PointF p = City.TransformWholeCity((float)block.Avenue, (float)block.Street, (float)block.NumLots);
			ArrayList arrayList = new ArrayList();
			float num = this.GetDensity(S.ST.Hour);
			ArrayList result;
			if (num < 0.001f)
			{
				result = arrayList;
			}
			else
			{
				float num2 = 1.3333334f / num;
				arrayList.Add(new TrafficDrawable(Utilities.AddPointFs(p, this.beginLane1W), Utilities.AddPointFs(p, this.endLane1W), (float)(S.ST.FrameCounter + this.startPos) % num2, num2, false));
				arrayList.Add(new TrafficDrawable(Utilities.AddPointFs(p, this.beginLane2W), Utilities.AddPointFs(p, this.endLane2W), (float)(S.ST.FrameCounter + this.startPos) % num2, num2, false));
				result = arrayList;
			}
			return result;
		}

		// Token: 0x0400003E RID: 62
		protected float[,] density = new float[24, 3];

		// Token: 0x0400003F RID: 63
		protected int startPos;

		// Token: 0x04000040 RID: 64
		protected PointF beginLane1;

		// Token: 0x04000041 RID: 65
		protected PointF endLane1;

		// Token: 0x04000042 RID: 66
		protected PointF beginLane2;

		// Token: 0x04000043 RID: 67
		protected PointF endLane2;

		// Token: 0x04000044 RID: 68
		protected PointF beginLane1W;

		// Token: 0x04000045 RID: 69
		protected PointF endLane1W;

		// Token: 0x04000046 RID: 70
		protected PointF beginLane2W;

		// Token: 0x04000047 RID: 71
		protected PointF endLane2W;
	}
}
