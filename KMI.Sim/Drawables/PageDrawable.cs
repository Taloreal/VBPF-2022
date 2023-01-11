using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x0200000F RID: 15
	[Serializable]
	public class PageDrawable : Drawable
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x000077DD File Offset: 0x000067DD
		public PageDrawable(Point location, string imageName) : base(location, imageName)
		{
			this.location = location;
			this.imageName = imageName;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000780D File Offset: 0x0000680D
		public PageDrawable(Point location, string imageName, string clickString) : base(location, imageName, clickString)
		{
			this.location = location;
			this.imageName = imageName;
			this.clickString = clickString;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00007845 File Offset: 0x00006845
		public PageDrawable(PointF location, string imageName) : base(location, imageName)
		{
			this.location = Point.Round(location);
			this.imageName = imageName;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000787A File Offset: 0x0000687A
		public PageDrawable(PointF location, string imageName, string clickString) : base(location, clickString)
		{
			this.location = Point.Round(location);
			this.imageName = imageName;
			this.clickString = clickString;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000078B8 File Offset: 0x000068B8
		public override void Draw(Graphics g)
		{
			Page page = S.R.GetPage(this.imageName);
			RectangleF destRect;
			if (this.flipX)
			{
				destRect = new RectangleF(new PointF((float)(this.location.X - page.AnchorX + page.CellWidth), (float)(this.location.Y - page.AnchorY)), new SizeF((float)(-(float)page.CellWidth), (float)page.CellHeight));
			}
			else
			{
				destRect = new RectangleF(new PointF((float)(this.location.X - page.AnchorX), (float)(this.location.Y - page.AnchorY)), new SizeF((float)page.CellWidth, (float)page.CellHeight));
			}
			RectangleF srcRect = new RectangleF(new PointF((float)(this.col * page.CellWidth), (float)(this.row * page.CellHeight)), new SizeF((float)page.CellWidth, (float)page.CellHeight));
			g.DrawImage(page.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000079CC File Offset: 0x000069CC
		public override bool HitTest(int x, int y)
		{
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				Page page = S.R.GetPage(this.imageName);
				if (this.flipX)
				{
					result = (x >= this.location.X - page.AnchorX && x < this.location.X - page.AnchorX + page.CellWidth && y >= this.location.Y - page.AnchorY && y < this.location.Y - page.AnchorY + page.CellHeight && page.Bitmap.GetPixel(-(x + 1 - this.location.X + page.AnchorX) + (this.col + 1) * page.CellWidth, y - this.location.Y + page.AnchorY + this.row * page.CellHeight).A != 0);
				}
				else
				{
					result = (x >= this.location.X - page.AnchorX && x < this.location.X - page.AnchorX + page.CellWidth && y >= this.location.Y - page.AnchorY && y < this.location.Y - page.AnchorY + page.CellHeight && page.Bitmap.GetPixel(x - this.location.X + page.AnchorX + this.col * page.CellWidth, y - this.location.Y + page.AnchorY + this.row * page.CellHeight).A != 0);
				}
			}
			return result;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00007BB0 File Offset: 0x00006BB0
		protected override Size Size
		{
			get
			{
				Size result;
				if (this.imageName != null && this.imageName != "")
				{
					Page page = S.R.GetPage(this.imageName);
					result = new Size(page.CellWidth, page.CellHeight);
				}
				else
				{
					result = new Size(0, 0);
				}
				return result;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00007C14 File Offset: 0x00006C14
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00007C2C File Offset: 0x00006C2C
		public int Col
		{
			get
			{
				return this.col;
			}
			set
			{
				this.col = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00007C38 File Offset: 0x00006C38
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00007C50 File Offset: 0x00006C50
		public int Row
		{
			get
			{
				return this.row;
			}
			set
			{
				this.row = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00007C5C File Offset: 0x00006C5C
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00007C74 File Offset: 0x00006C74
		public bool FlipX
		{
			get
			{
				return this.flipX;
			}
			set
			{
				this.flipX = value;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00007C80 File Offset: 0x00006C80
		public override void Drawable_Click(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			Page page = S.R.GetPage(this.imageName);
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.location.X - page.AnchorX + page.CellWidth / 2, this.location.Y - page.AnchorY);
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x04000077 RID: 119
		private int col = 0;

		// Token: 0x04000078 RID: 120
		private int row = 0;

		// Token: 0x04000079 RID: 121
		private bool flipX = false;
	}
}
