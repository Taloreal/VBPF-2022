using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for AllocationControl.
	/// </summary>
	// Token: 0x0200009C RID: 156
	public class AllocationControl : UserControl
	{
		// Token: 0x060004D3 RID: 1235 RVA: 0x00044ED8 File Offset: 0x00043ED8
		public AllocationControl()
		{
			this.InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004D4 RID: 1236 RVA: 0x00044EF4 File Offset: 0x00043EF4
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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x060004D5 RID: 1237 RVA: 0x00044F30 File Offset: 0x00043F30
		private void InitializeComponent()
		{
			this.updPct = new NumericUpDown();
			this.labFundName = new Label();
			((ISupportInitialize)this.updPct).BeginInit();
			base.SuspendLayout();
			this.updPct.Location = new Point(12, 8);
			this.updPct.Name = "updPct";
			this.updPct.Size = new Size(44, 20);
			this.updPct.TabIndex = 0;
			this.updPct.TextAlign = HorizontalAlignment.Right;
			this.labFundName.Location = new Point(64, 12);
			this.labFundName.Name = "labFundName";
			this.labFundName.Size = new Size(176, 16);
			this.labFundName.TabIndex = 1;
			this.labFundName.Text = "label1";
			base.Controls.Add(this.labFundName);
			base.Controls.Add(this.updPct);
			base.Name = "AllocationControl";
			base.Size = new Size(236, 32);
			((ISupportInitialize)this.updPct).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040005B9 RID: 1465
		public NumericUpDown updPct;

		// Token: 0x040005BA RID: 1466
		public Label labFundName;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005BB RID: 1467
		private Container components = null;
	}
}
