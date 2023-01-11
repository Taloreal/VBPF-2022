using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000040 RID: 64
	[Serializable]
	public class FlexDrawable : Drawable
	{
		// Token: 0x0600026F RID: 623 RVA: 0x00014A8D File Offset: 0x00013A8D
		public FlexDrawable(Point location, string imageName) : base(location, imageName)
		{
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00014ABD File Offset: 0x00013ABD
		public FlexDrawable(Point location, string imageName, string clickString) : base(location, imageName, clickString)
		{
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00014AEE File Offset: 0x00013AEE
		public FlexDrawable(PointF location, string imageName) : base(location, imageName)
		{
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00014B1E File Offset: 0x00013B1E
		public FlexDrawable(PointF location, string imageName, string clickString) : base(location, imageName, clickString)
		{
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00014B50 File Offset: 0x00013B50
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00014B68 File Offset: 0x00013B68
		public bool Flip
		{
			get
			{
				return this.flip;
			}
			set
			{
				this.flip = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00014B74 File Offset: 0x00013B74
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00014B8C File Offset: 0x00013B8C
		public FlexDrawable.HorizontalAlignments HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignment;
			}
			set
			{
				this.horizontalAlignment = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00014B98 File Offset: 0x00013B98
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00014BB0 File Offset: 0x00013BB0
		public FlexDrawable.VerticalAlignments VerticalAlignment
		{
			get
			{
				return this.verticalAlignment;
			}
			set
			{
				this.verticalAlignment = value;
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00014BBC File Offset: 0x00013BBC
		public override void Draw(Graphics g)
		{
			Bitmap image = S.R.GetImage(this.imageName);
			switch (this.verticalAlignment)
			{
			case FlexDrawable.VerticalAlignments.Top:
				this.offsetY = 0;
				break;
			case FlexDrawable.VerticalAlignments.Middle:
				this.offsetY = -image.Height / 2;
				break;
			case FlexDrawable.VerticalAlignments.Bottom:
				this.offsetY = -image.Height;
				break;
			}
			switch (this.horizontalAlignment)
			{
			case FlexDrawable.HorizontalAlignments.Left:
				this.offsetX = 0;
				break;
			case FlexDrawable.HorizontalAlignments.Center:
				this.offsetX = -image.Width / 2;
				break;
			case FlexDrawable.HorizontalAlignments.Right:
				this.offsetX = -image.Width;
				break;
			}
			if (this.flip)
			{
				g.DrawImage(image, this.location.X + this.offsetX + image.Width, this.location.Y + this.offsetY, -image.Width, image.Height);
			}
			else
			{
				g.DrawImage(image, this.location.X + this.offsetX, this.location.Y + this.offsetY, image.Width, image.Height);
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00014CEC File Offset: 0x00013CEC
		public override bool HitTest(int x, int y)
		{
			return this.hittable && base.HitTest(x - this.offsetX, y - this.offsetY);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00014D24 File Offset: 0x00013D24
		public override void Drawable_Click(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.location.X + this.Size.Width / 2 + this.offsetX, this.location.Y + this.offsetY);
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x04000193 RID: 403
		protected bool flip = false;

		// Token: 0x04000194 RID: 404
		protected FlexDrawable.HorizontalAlignments horizontalAlignment = FlexDrawable.HorizontalAlignments.Left;

		// Token: 0x04000195 RID: 405
		protected FlexDrawable.VerticalAlignments verticalAlignment = FlexDrawable.VerticalAlignments.Top;

		// Token: 0x04000196 RID: 406
		protected int offsetX = 0;

		// Token: 0x04000197 RID: 407
		protected int offsetY = 0;

		// Token: 0x02000041 RID: 65
		public enum HorizontalAlignments
		{
			// Token: 0x04000199 RID: 409
			Left,
			// Token: 0x0400019A RID: 410
			Center,
			// Token: 0x0400019B RID: 411
			Right
		}

		// Token: 0x02000042 RID: 66
		public enum VerticalAlignments
		{
			// Token: 0x0400019D RID: 413
			Top,
			// Token: 0x0400019E RID: 414
			Middle,
			// Token: 0x0400019F RID: 415
			Bottom
		}
	}
}
