using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000035 RID: 53
	[Serializable]
	public class PolygonDrawable : Drawable
	{
		// Token: 0x060001FF RID: 511 RVA: 0x0001126C File Offset: 0x0001026C
		public PolygonDrawable(Point[] points) : base(points[0], "")
		{
			this.points = points;
			this.fill = true;
			this.fillMode = FillMode.Alternate;
			this.lineWidth = 1;
			this.color = Color.Black;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000112C4 File Offset: 0x000102C4
		public PolygonDrawable(Point[] points, string clickString) : base(points[0], "", clickString)
		{
			this.points = points;
			this.fill = true;
			this.fillMode = FillMode.Alternate;
			this.lineWidth = 1;
			this.color = Color.Black;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0001131C File Offset: 0x0001031C
		public override void Draw(Graphics g)
		{
			SmoothingMode smoothingMode = g.SmoothingMode;
			g.SmoothingMode = this.smoothingMode;
			SolidBrush brush = new SolidBrush(this.color);
			if (this.fill)
			{
				g.FillPolygon(brush, this.points, this.fillMode);
			}
			else
			{
				g.DrawPolygon(new Pen(brush, (float)this.lineWidth), this.points);
			}
			g.SmoothingMode = smoothingMode;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00011394 File Offset: 0x00010394
		public override bool HitTest(int x, int y)
		{
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				PointF[] array = new PointF[this.points.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.points[i];
				}
				bool flag = Utilities.PolygonContains(new PointF((float)x, (float)y), array);
				result = flag;
			}
			return result;
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00011410 File Offset: 0x00010410
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00011428 File Offset: 0x00010428
		public Point[] Points
		{
			get
			{
				return this.points;
			}
			set
			{
				this.points = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00011434 File Offset: 0x00010434
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0001144C File Offset: 0x0001044C
		public bool Fill
		{
			get
			{
				return this.fill;
			}
			set
			{
				this.fill = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00011458 File Offset: 0x00010458
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00011470 File Offset: 0x00010470
		public FillMode FillMode
		{
			get
			{
				return this.fillMode;
			}
			set
			{
				this.fillMode = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0001147C File Offset: 0x0001047C
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00011494 File Offset: 0x00010494
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600020B RID: 523 RVA: 0x000114A0 File Offset: 0x000104A0
		// (set) Token: 0x0600020C RID: 524 RVA: 0x000114B8 File Offset: 0x000104B8
		public int LineWidth
		{
			get
			{
				return this.lineWidth;
			}
			set
			{
				this.lineWidth = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (set) Token: 0x0600020D RID: 525 RVA: 0x000114C2 File Offset: 0x000104C2
		public SmoothingMode SmoothingMode
		{
			set
			{
				this.smoothingMode = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600020E RID: 526 RVA: 0x000114CC File Offset: 0x000104CC
		protected override Size Size
		{
			get
			{
				int num = int.MinValue;
				int num2 = int.MinValue;
				int num3 = int.MaxValue;
				int num4 = int.MaxValue;
				foreach (Point point in this.Points)
				{
					if (point.X > num)
					{
						num = point.X;
					}
					if (point.Y > num2)
					{
						num2 = point.Y;
					}
					if (point.X < num3)
					{
						num3 = point.X;
					}
					if (point.Y < num4)
					{
						num4 = point.Y;
					}
				}
				return new Size(num - num3, num2 - num4);
			}
		}

		// Token: 0x04000153 RID: 339
		protected SmoothingMode smoothingMode = SmoothingMode.AntiAlias;

		// Token: 0x04000154 RID: 340
		protected Point[] points;

		// Token: 0x04000155 RID: 341
		protected bool fill;

		// Token: 0x04000156 RID: 342
		protected FillMode fillMode;

		// Token: 0x04000157 RID: 343
		protected int lineWidth;

		// Token: 0x04000158 RID: 344
		protected Color color;
	}
}
