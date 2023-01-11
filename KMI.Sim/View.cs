using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim.Drawables;

namespace KMI.Sim
{
	// Token: 0x02000058 RID: 88
	public abstract class View
	{
		// Token: 0x06000324 RID: 804 RVA: 0x00018B84 File Offset: 0x00017B84
		public View(string name, Bitmap background)
		{
			this.name = name;
			this.background = background;
			this.size = background.Size;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00018BB7 File Offset: 0x00017BB7
		public View(string name, Size size)
		{
			this.name = name;
			this.size = size;
			this.background = null;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000326 RID: 806 RVA: 0x00018BE8 File Offset: 0x00017BE8
		public Size Size
		{
			get
			{
				return this.size;
			}
		}

		// Token: 0x06000327 RID: 807
		public abstract Drawable[] BuildDrawables(long entityID, params object[] args);

		// Token: 0x06000328 RID: 808 RVA: 0x00018C00 File Offset: 0x00017C00
		public void Draw(Graphics g)
		{
			if (this.background != null)
			{
				g.DrawImageUnscaled(this.background, 0, 0);
			}
			foreach (Drawable drawable in this.drawables)
			{
				drawable.Draw(g);
			}
			if (View.currentHit != null)
			{
				View.currentHit.DrawSelected(g);
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00018C6C File Offset: 0x00017C6C
		public Drawable HitTest(int x, int y)
		{
			if (this.drawables != null)
			{
				for (int i = this.drawables.Length - 1; i >= 0; i--)
				{
					if (this.drawables[i].HitTest(x, y))
					{
						return this.drawables[i];
					}
				}
			}
			return null;
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00018CCC File Offset: 0x00017CCC
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00018CE4 File Offset: 0x00017CE4
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00018CFC File Offset: 0x00017CFC
		public Drawable[] Drawables
		{
			get
			{
				return this.drawables;
			}
			set
			{
				this.drawables = value;
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00018D06 File Offset: 0x00017D06
		protected internal void UpdateCurrentHit(MouseEventArgs e)
		{
			View.currentHit = this.HitTest(e.X, e.Y);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00018D20 File Offset: 0x00017D20
		public static void ClearCurrentHit()
		{
			View.currentHit = null;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00018D2C File Offset: 0x00017D2C
		public virtual void View_Click(object sender, EventArgs e)
		{
			if (View.currentHit != null)
			{
				View.currentHit.Drawable_Click(sender, e);
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00018D54 File Offset: 0x00017D54
		public virtual void View_DoubleClick(object sender, EventArgs e)
		{
			if (View.currentHit != null)
			{
				View.currentHit.Drawable_DoubleClick(sender, e);
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00018D7C File Offset: 0x00017D7C
		public virtual void View_MouseMove(object sender, MouseEventArgs e)
		{
			if (!S.I.SimTimeRunning && this.ClearDrawSelectedOnMouseMove)
			{
				S.MF.picMain.Refresh();
			}
			Control control = (Control)sender;
			control.Cursor = Cursors.Default;
			if (View.currentHit != null)
			{
				View.currentHit.Drawable_MouseMove(sender, e);
			}
			else
			{
				S.MF.ViewToolTip.SetToolTip(control, "");
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00018DFA File Offset: 0x00017DFA
		public virtual void View_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00018DFD File Offset: 0x00017DFD
		public virtual void View_MouseUp(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00018E00 File Offset: 0x00017E00
		// (set) Token: 0x06000335 RID: 821 RVA: 0x00018E18 File Offset: 0x00017E18
		public bool ClearDrawSelectedOnMouseMove
		{
			get
			{
				return this.clearDrawSelectedOnMouseMove;
			}
			set
			{
				this.clearDrawSelectedOnMouseMove = value;
			}
		}

		// Token: 0x040001FC RID: 508
		protected string name;

		// Token: 0x040001FD RID: 509
		protected Bitmap background;

		// Token: 0x040001FE RID: 510
		protected Drawable[] drawables;

		// Token: 0x040001FF RID: 511
		protected int skewFactor = 2;

		// Token: 0x04000200 RID: 512
		public object[] ViewerOptions;

		// Token: 0x04000201 RID: 513
		protected Size size;

		// Token: 0x04000202 RID: 514
		protected static Drawable currentHit;

		// Token: 0x04000203 RID: 515
		protected bool clearDrawSelectedOnMouseMove = false;
	}
}
