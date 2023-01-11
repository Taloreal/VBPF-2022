using System;
using System.Drawing;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000054 RID: 84
	[Serializable]
	public class RectangleDrawable : Drawable
	{
		// Token: 0x06000318 RID: 792 RVA: 0x000186E7 File Offset: 0x000176E7
		public RectangleDrawable(Point location, Size size, Color color, bool fill) : base(location, null)
		{
			this.fill = fill;
			this.size = size;
			this.color = color;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0001870A File Offset: 0x0001770A
		public RectangleDrawable(Point location, string clickString, Size size, Color color, bool fill) : base(location, null, clickString)
		{
			this.fill = fill;
			this.size = size;
			this.color = color;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00018730 File Offset: 0x00017730
		public override void Draw(Graphics g)
		{
			if (this.fill)
			{
				g.FillRectangle(new SolidBrush(this.color), new Rectangle(this.location, this.size));
			}
			else
			{
				g.DrawRectangle(new Pen(this.color, 1f), new Rectangle(this.location, this.size));
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00018798 File Offset: 0x00017798
		protected override Size Size
		{
			get
			{
				return this.size;
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000187B0 File Offset: 0x000177B0
		public override bool HitTest(int x, int y)
		{
			return this.hittable && new Rectangle(this.location, this.size).Contains(x, y);
		}

		// Token: 0x040001EE RID: 494
		protected bool fill;

		// Token: 0x040001EF RID: 495
		protected Size size;

		// Token: 0x040001F0 RID: 496
		protected Color color;
	}
}
