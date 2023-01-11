using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmSnapShot.
	/// </summary>
	// Token: 0x020000B4 RID: 180
	public partial class frmSnapshot : Form
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x0004E4EC File Offset: 0x0004D4EC
		public frmSnapshot()
		{
			this.InitializeComponent();
			A.MF.NewDay += this.NewDayHandler;
			A.MF.EntityChanged += this.EntityChangedHandler;
			this.toolTip = new ToolTip();
			this.toolTip.InitialDelay = 0;
			this.GetData();
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0004E564 File Offset: 0x0004D564
		protected bool GetData()
		{
			bool result;
			try
			{
				this.input = A.SA.GetSnapshot(A.MF.CurrentEntityID);
				result = true;
			}
			catch (EntityNotFoundException ex)
			{
				base.Close();
				result = false;
			}
			return result;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0004E6EE File Offset: 0x0004D6EE
		protected void frmReport_Closed(object sender, EventArgs e)
		{
			A.MF.NewDay -= this.NewDayHandler;
			A.MF.EntityChanged -= this.EntityChangedHandler;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0004E720 File Offset: 0x0004D720
		protected void NewDayHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.panMain.Refresh();
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0004E74C File Offset: 0x0004D74C
		protected void DrawStatusIcon(Graphics g, string image, float val, string toolTip, ref ArrayList toolTips)
		{
			this.statusToolTips.Add(toolTip);
			int x = 230 - this.statusToolTips.Count * 46;
			int y = 0;
			g.DrawImageUnscaled(A.R.GetImage(image), x, y);
			Color c = Color.FromArgb(103, 182, 103);
			if ((double)val < 0.1)
			{
				c = Color.FromArgb(207, 111, 111);
			}
			else if ((double)val < 0.66)
			{
				c = Color.FromArgb(195, 177, 107);
			}
			Brush b = new SolidBrush(c);
			int h = (int)Utilities.Clamp(19f * val, 1f, 19f);
			g.FillRectangle(b, x + 11, y + 7 + 18 - h, 7, h);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0004E82C File Offset: 0x0004D82C
		private void panMain_MouseMove(object sender, MouseEventArgs e)
		{
			int icon = (this.panMain.Width - e.X) / 46;
			if (icon >= 0 && icon < this.statusToolTips.Count)
			{
				this.toolTip.SetToolTip(this.panMain, (string)this.statusToolTips[icon]);
			}
			else
			{
				this.toolTip.SetToolTip(this.panMain, "");
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0004E8A8 File Offset: 0x0004D8A8
		private void panMain_Paint(object sender, PaintEventArgs e)
		{
			this.statusToolTips = new ArrayList();
			if (frmSnapshot.buffer == null)
			{
				frmSnapshot.buffer = new Bitmap(230, this.panMain.Height, e.Graphics);
				frmSnapshot.g = Graphics.FromImage(frmSnapshot.buffer);
			}
			frmSnapshot.g.Clear(this.BackColor);
			if (this.input.gas > -1f)
			{
				string s = "OK";
				if (this.input.carBroken)
				{
					s = "Broken";
				}
				this.DrawStatusIcon(frmSnapshot.g, this.input.carImageName + s, -1f, A.R.GetString("Car: {0}", new object[]
				{
					s
				}), ref this.statusToolTips);
				this.DrawStatusIcon(frmSnapshot.g, "StatusGas", this.input.gas / 60f, A.R.GetString("Gas: {0} gals", new object[]
				{
					this.input.gas.ToString("N1")
				}), ref this.statusToolTips);
			}
			if (this.input.busTokens > -1)
			{
				this.DrawStatusIcon(frmSnapshot.g, "StatusBusTokens", (float)this.input.busTokens / 60f, A.R.GetString("Bus Tokens: {0}", new object[]
				{
					this.input.busTokens
				}), ref this.statusToolTips);
			}
			this.DrawStatusIcon(frmSnapshot.g, "StatusFood", (float)this.input.food / 60f, A.R.GetString("Food: {0} meals", new object[]
			{
				this.input.food
			}), ref this.statusToolTips);
			this.DrawStatusIcon(frmSnapshot.g, "StatusHealth", this.input.health, A.R.GetString("Health: {0}", new object[]
			{
				Utilities.FP(this.input.health)
			}), ref this.statusToolTips);
			int xShift = 46 * (5 - this.statusToolTips.Count);
			base.Width = 238 - xShift;
			this.panMain.Left = -xShift;
			e.Graphics.DrawImageUnscaled(frmSnapshot.buffer, 0, 0);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0004EB30 File Offset: 0x0004DB30
		protected virtual void EntityChangedHandler(object sender, EventArgs e)
		{
			if (this.EnablingReference != null && !this.EnablingReference.Enabled)
			{
				base.Close();
			}
			else if (this.GetData())
			{
				this.panMain.Refresh();
			}
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0004EB80 File Offset: 0x0004DB80
		private void frmSnapshot_Load(object sender, EventArgs e)
		{
			base.Location = new Point(A.MF.Bounds.Right - base.Width - 6, A.MF.Bounds.Bottom - base.Height - 20);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0004EBD4 File Offset: 0x0004DBD4
		private void frmSnapshot_Resize(object sender, EventArgs e)
		{
			base.Location = new Point(A.MF.Bounds.Right - base.Width - 6, A.MF.Bounds.Bottom - base.Height - 20);
		}

		// Token: 0x0400064C RID: 1612
		private ToolTip toolTip;

		// Token: 0x0400064E RID: 1614
		private frmSnapshot.Input input;

		// Token: 0x0400064F RID: 1615
		public MenuItem EnablingReference;

		// Token: 0x04000650 RID: 1616
		private ArrayList statusToolTips = new ArrayList();

		// Token: 0x04000651 RID: 1617
		private static Bitmap buffer;

		// Token: 0x04000652 RID: 1618
		private static Graphics g;

		// Token: 0x020000B5 RID: 181
		[Serializable]
		public struct Input
		{
			// Token: 0x04000653 RID: 1619
			public int food;

			// Token: 0x04000654 RID: 1620
			public float health;

			// Token: 0x04000655 RID: 1621
			public int busTokens;

			// Token: 0x04000656 RID: 1622
			public float gas;

			// Token: 0x04000657 RID: 1623
			public string carImageName;

			// Token: 0x04000658 RID: 1624
			public bool carBroken;
		}
	}
}
