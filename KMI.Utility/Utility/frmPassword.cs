using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x0200000B RID: 11
	public partial class frmPassword : Form
	{
		// Token: 0x06000075 RID: 117 RVA: 0x000059C4 File Offset: 0x000049C4
		public frmPassword(string validPassword)
		{
			this.InitializeComponent();
			this.validPassword = validPassword;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005CC0 File Offset: 0x00004CC0
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.txtPassword.Text.ToUpper() == this.validPassword.ToUpper())
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show(this, "Invalid Password, try again!", "Password");
				base.ActiveControl = this.txtPassword;
				this.txtPassword.SelectAll();
				base.DialogResult = DialogResult.None;
			}
		}

		// Token: 0x04000025 RID: 37
		private string validPassword;
	}
}
