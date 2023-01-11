using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public class CompoundDrawable : Drawable
	{
		// Token: 0x06000410 RID: 1040 RVA: 0x0001D9CE File Offset: 0x0001C9CE
		public CompoundDrawable(Point location, ArrayList drawables, string clickString) : base(location, null, clickString)
		{
			this.drawables = drawables;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0001D9F8 File Offset: 0x0001C9F8
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0001DA2B File Offset: 0x0001CA2B
		public ArrayList Drawables
		{
			get
			{
				if (this.drawables == null)
				{
					this.drawables = new ArrayList();
				}
				return this.drawables;
			}
			set
			{
				this.drawables = value;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001DA38 File Offset: 0x0001CA38
		public override void Draw(Graphics g)
		{
			foreach (object obj in this.drawables)
			{
				Drawable drawable = (Drawable)obj;
				drawable.Draw(g);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0001DAA0 File Offset: 0x0001CAA0
		public override bool HitTest(int x, int y)
		{
			CompoundDrawable.clickedDrawable = null;
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				for (int i = this.drawables.Count - 1; i >= 0; i--)
				{
					if (((Drawable)this.drawables[i]).HitTest(x, y))
					{
						if (this.forwardClick)
						{
							CompoundDrawable.clickedDrawable = (Drawable)this.drawables[i];
						}
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0001DB30 File Offset: 0x0001CB30
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0001DB48 File Offset: 0x0001CB48
		public bool ForwardClick
		{
			get
			{
				return this.forwardClick;
			}
			set
			{
				this.forwardClick = value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0001DB54 File Offset: 0x0001CB54
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0001DB87 File Offset: 0x0001CB87
		public Point ClickStringLocation
		{
			get
			{
				Point location;
				if (this.clickStringLocation.IsEmpty)
				{
					location = this.location;
				}
				else
				{
					location = this.clickStringLocation;
				}
				return location;
			}
			set
			{
				this.clickStringLocation = value;
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0001DB94 File Offset: 0x0001CB94
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (this.forwardClick && CompoundDrawable.clickedDrawable != null)
			{
				CompoundDrawable.clickedDrawable.Drawable_Click(sender, e);
			}
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.ClickStringLocation.X + this.Size.Width / 2, this.ClickStringLocation.Y);
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001DC50 File Offset: 0x0001CC50
		public override void Drawable_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.forwardClick && CompoundDrawable.clickedDrawable != null)
			{
				CompoundDrawable.clickedDrawable.Drawable_MouseMove(sender, e);
			}
			else
			{
				base.Drawable_MouseMove(sender, e);
			}
		}

		// Token: 0x040002B9 RID: 697
		protected ArrayList drawables;

		// Token: 0x040002BA RID: 698
		private bool forwardClick = false;

		// Token: 0x040002BB RID: 699
		protected Point clickStringLocation = Point.Empty;

		// Token: 0x040002BC RID: 700
		private static Drawable clickedDrawable = null;
	}
}
