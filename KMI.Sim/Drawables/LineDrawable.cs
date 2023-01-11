using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000078 RID: 120
	[Serializable]
	public class LineDrawable : Drawable
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x0001F040 File Offset: 0x0001E040
		public LineDrawable(Point location, Point connector) : base(location, "")
		{
			this.connector = connector;
			this.width = 1f;
			this.color = Color.Black;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0001F075 File Offset: 0x0001E075
		public LineDrawable(Point location, Point connector, string clickString) : base(location, "", clickString)
		{
			this.connector = connector;
			this.width = 1f;
			this.color = Color.Black;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0001F0AC File Offset: 0x0001E0AC
		public override void Draw(Graphics g)
		{
			SmoothingMode smoothingMode = g.SmoothingMode;
			g.SmoothingMode = this.smoothingMode;
			SolidBrush brush = new SolidBrush(this.color);
			g.DrawLine(new Pen(brush, this.width), this.location, this.connector);
			g.SmoothingMode = smoothingMode;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0001F104 File Offset: 0x0001E104
		public override bool HitTest(int x, int y)
		{
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				int num = Math.Min(this.location.X, this.connector.X);
				int num2 = Math.Max(this.location.X, this.connector.X);
				if (x >= num - 1 && x <= num2 + 1)
				{
					float num3 = (float)(this.location.Y - this.connector.Y) / (float)(this.location.X - this.connector.X);
					float num4 = num3 * (float)(x - this.location.X) + (float)this.location.Y;
					if (num4 >= (float)y - 1f && num4 <= (float)y + 1f)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x0001F1F4 File Offset: 0x0001E1F4
		// (set) Token: 0x06000451 RID: 1105 RVA: 0x0001F20C File Offset: 0x0001E20C
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

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x0001F218 File Offset: 0x0001E218
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x0001F230 File Offset: 0x0001E230
		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0001F23A File Offset: 0x0001E23A
		public SmoothingMode SmoothingMode
		{
			set
			{
				this.smoothingMode = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0001F244 File Offset: 0x0001E244
		protected override Size Size
		{
			get
			{
				return new Size(Math.Abs(this.location.X - this.connector.X), Math.Abs(this.location.Y - this.connector.Y));
			}
		}

		// Token: 0x040002D6 RID: 726
		private const int CLICK_THRESHOLD = 1;

		// Token: 0x040002D7 RID: 727
		protected SmoothingMode smoothingMode = SmoothingMode.AntiAlias;

		// Token: 0x040002D8 RID: 728
		protected Point connector;

		// Token: 0x040002D9 RID: 729
		protected Color color;

		// Token: 0x040002DA RID: 730
		protected float width;
	}
}
