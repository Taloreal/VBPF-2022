using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000053 RID: 83
	public partial class frmMessageBoxWithOptOut : Form
	{
		// Token: 0x06000312 RID: 786 RVA: 0x00018424 File Offset: 0x00017424
		public frmMessageBoxWithOptOut(string title, string message) : this(title, message, true)
		{
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00018432 File Offset: 0x00017432
		public frmMessageBoxWithOptOut(string title, string message, bool optOutEnabled)
		{
			this.InitializeComponent();
			this.Text = title;
			this.labText.Text = message;
			this.chkDontShow.Visible = optOutEnabled;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000186AC File Offset: 0x000176AC
		private void frmMessageBoxWithOptOut_Closed(object sender, EventArgs e)
		{
			if (this.chkDontShow.Checked)
			{
				S.I.DontShowAgain(this.Text);
			}
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000186DD File Offset: 0x000176DD
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
