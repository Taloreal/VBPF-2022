using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Biz
{
	// Token: 0x02000003 RID: 3
	public partial class frmInputAmount : Form
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004814 File Offset: 0x00003814
		public frmInputAmount()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004838 File Offset: 0x00003838
		public frmInputAmount(string title, string msg, float min, float max, float defaultValue)
		{
			this.InitializeComponent();
			this.Text = title;
			this.labMsg.Text = msg;
			this.updAmount.Maximum = (decimal)max;
			this.updAmount.Minimum = (decimal)min;
			this.updAmount.Value = (decimal)defaultValue;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004B9B File Offset: 0x00003B9B
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Amount = (float)this.updAmount.Value;
			base.Close();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004BBC File Offset: 0x00003BBC
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x17000001 RID: 1
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00004BC6 File Offset: 0x00003BC6
		public decimal Increment
		{
			set
			{
				this.updAmount.Increment = value;
			}
		}

		// Token: 0x04000009 RID: 9
		public float Amount = 0f;

		// Token: 0x02000004 RID: 4
		[Serializable]
		public struct Input
		{
			// Token: 0x0400000A RID: 10
			public string title;

			// Token: 0x0400000B RID: 11
			public string msg;

			// Token: 0x0400000C RID: 12
			public float min;

			// Token: 0x0400000D RID: 13
			public float max;

			// Token: 0x0400000E RID: 14
			public float defaultValue;
		}
	}
}
