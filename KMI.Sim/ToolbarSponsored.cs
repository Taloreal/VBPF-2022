using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200004A RID: 74
	public class ToolbarSponsored : ToolBar
	{
		// Token: 0x0600029B RID: 667 RVA: 0x0001539C File Offset: 0x0001439C
		public ToolbarSponsored()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000153B8 File Offset: 0x000143B8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000153F4 File Offset: 0x000143F4
		private void InitializeComponent()
		{
			this.labLogo = new Label();
			base.SuspendLayout();
			this.labLogo.Dock = DockStyle.Right;
			this.labLogo.Location = new Point(110, 0);
			this.labLogo.Name = "labLogo";
			this.labLogo.Size = new Size(40, 150);
			this.labLogo.TabIndex = 0;
			base.Controls.Add(this.labLogo);
			base.Name = "ToolbarSponsored";
			base.ResumeLayout(false);
		}

		// Token: 0x040001B7 RID: 439
		public Label labLogo;

		// Token: 0x040001B8 RID: 440
		private Container components = null;
	}
}
