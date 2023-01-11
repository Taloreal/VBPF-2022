using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x0200000E RID: 14
	[Serializable]
	public class Drawable : IComparable
	{
		// Token: 0x060000BC RID: 188 RVA: 0x000073CC File Offset: 0x000063CC
		public Drawable(Point location, string imageName)
		{
			this.location = location;
			this.imageName = imageName;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000073FE File Offset: 0x000063FE
		public Drawable(Point location, string imageName, string clickString)
		{
			this.location = location;
			this.imageName = imageName;
			this.clickString = clickString;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00007437 File Offset: 0x00006437
		public Drawable(PointF location, string imageName)
		{
			this.location = Point.Round(location);
			this.imageName = imageName;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000746E File Offset: 0x0000646E
		public Drawable(PointF location, string imageName, string clickString)
		{
			this.location = Point.Round(location);
			this.imageName = imageName;
			this.clickString = clickString;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000074AC File Offset: 0x000064AC
		public Point Location
		{
			get
			{
				return this.location;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000074C4 File Offset: 0x000064C4
		public string ClickString
		{
			get
			{
				return this.clickString;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x000074DC File Offset: 0x000064DC
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x000074F4 File Offset: 0x000064F4
		public string ToolTipText
		{
			get
			{
				return this.toolTipText;
			}
			set
			{
				this.toolTipText = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00007500 File Offset: 0x00006500
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00007518 File Offset: 0x00006518
		public bool Hittable
		{
			get
			{
				return this.hittable;
			}
			set
			{
				this.hittable = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00007524 File Offset: 0x00006524
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000753C File Offset: 0x0000653C
		public int Plane
		{
			get
			{
				return this.plane;
			}
			set
			{
				this.plane = value;
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00007546 File Offset: 0x00006546
		public virtual void Draw(Graphics g)
		{
			g.DrawImageUnscaled(S.R.GetImage(this.imageName), this.location);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00007566 File Offset: 0x00006566
		public virtual void DrawSelected(Graphics g)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000756C File Offset: 0x0000656C
		public virtual bool HitTest(int x, int y)
		{
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				Bitmap image = S.R.GetImage(this.imageName);
				result = (x >= this.location.X && x < this.location.X + image.Width && y >= this.location.Y && y < this.location.Y + image.Height && image.GetPixel(x - this.location.X, y - this.location.Y).A != 0);
			}
			return result;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00007618 File Offset: 0x00006618
		public virtual void Drawable_Click(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.location.X + this.Size.Width / 2, this.location.Y);
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000076A8 File Offset: 0x000066A8
		public virtual void Drawable_DoubleClick(object sender, EventArgs e)
		{
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000076AC File Offset: 0x000066AC
		public virtual void Drawable_MouseMove(object sender, MouseEventArgs e)
		{
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				control.Cursor = Cursors.Hand;
			}
			S.MF.ViewToolTip.SetToolTip((Control)sender, this.toolTipText);
			this.DrawSelected(control.CreateGraphics());
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00007718 File Offset: 0x00006718
		protected virtual Size Size
		{
			get
			{
				Size result;
				if (this.imageName != null && this.imageName != "")
				{
					result = S.R.GetImage(this.imageName).Size;
				}
				else
				{
					result = new Size(0, 0);
				}
				return result;
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000776C File Offset: 0x0000676C
		public virtual int CompareTo(object obj)
		{
			Drawable drawable = (Drawable)obj;
			int result;
			if (this.plane == drawable.plane)
			{
				if (drawable.location.Y > this.location.Y)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
			}
			else if (drawable.plane > this.plane)
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x04000070 RID: 112
		protected Point location;

		// Token: 0x04000071 RID: 113
		protected string imageName;

		// Token: 0x04000072 RID: 114
		protected string clickString;

		// Token: 0x04000073 RID: 115
		protected string toolTipText = "";

		// Token: 0x04000074 RID: 116
		protected bool hittable = true;

		// Token: 0x04000075 RID: 117
		public int plane = 0;

		// Token: 0x04000076 RID: 118
		public object Tag;
	}
}
