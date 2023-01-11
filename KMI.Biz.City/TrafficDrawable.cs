using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.Biz.City
{
	// Token: 0x02000002 RID: 2
	[Serializable]
	public class TrafficDrawable : Drawable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public TrafficDrawable(PointF begin, PointF end, float firstCar, float spacing, bool zoomed) : base(begin, "CarNESW")
		{
			this.begin = begin;
			this.end = end;
			this.firstCar = firstCar;
			this.spacing = spacing;
			this.zoomed = zoomed;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00001088
		public override void Draw(Graphics g)
		{
			float num = (float)(2 * Math.Sign(this.end.X - this.begin.X));
			float num2 = (float)Math.Sign(this.end.Y - this.begin.Y);
			float num3 = this.begin.X + num * this.firstCar;
			float num4 = this.begin.Y + num2 * this.firstCar;
			string str = "Car";
			if (!this.zoomed)
			{
				str += "Small";
			}
			Bitmap image;
			if (Math.Sign(num) != Math.Sign(num2))
			{
				image = S.R.GetImage(str + "NESW");
			}
			else
			{
				image = S.R.GetImage(str + "NWSE");
			}
			while (Math.Sign(this.end.X - num3) == Math.Sign(num) && Math.Sign(this.end.Y - num4) == Math.Sign(num2))
			{
				g.DrawImageUnscaled(image, (int)num3, (int)num4);
				num3 += num * this.spacing;
				num4 += num2 * this.spacing;
			}
		}

		// Token: 0x04000001 RID: 1
		protected PointF begin;

		// Token: 0x04000002 RID: 2
		protected PointF end;

		// Token: 0x04000003 RID: 3
		protected float firstCar;

		// Token: 0x04000004 RID: 4
		protected float spacing;

		// Token: 0x04000005 RID: 5
		protected bool zoomed;
	}
}
