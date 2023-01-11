using System;
using System.Drawing;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public class PixelDrawable : Drawable
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x0001AFF4 File Offset: 0x00019FF4
		public PixelDrawable(Point location, Color color) : base(location, "")
		{
			this.color = color;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0001B00C File Offset: 0x0001A00C
		public PixelDrawable(Point location, Color color, string clickString) : base(location, "", clickString)
		{
			this.color = color;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0001B025 File Offset: 0x0001A025
		public override void Draw(Graphics g)
		{
			PixelDrawable.bitmap.SetPixel(0, 0, this.color);
			g.DrawImageUnscaled(PixelDrawable.bitmap, this.location.X, this.location.Y);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001B060 File Offset: 0x0001A060
		public override bool HitTest(int x, int y)
		{
			return this.hittable && (this.location.X <= x + 1 && this.location.X >= x - 1 && this.location.Y <= y + 1) && this.location.Y >= y - 1;
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0001B0C8 File Offset: 0x0001A0C8
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x0001B0E0 File Offset: 0x0001A0E0
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

		// Token: 0x04000264 RID: 612
		private const int CLICK_THRESHOLD = 1;

		// Token: 0x04000265 RID: 613
		protected Color color;

		// Token: 0x04000266 RID: 614
		private static Bitmap bitmap = new Bitmap(1, 1);
	}
}
