using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200007B RID: 123
	public partial class frmUploadAlternative : Form
	{
		// Token: 0x0600045B RID: 1115 RVA: 0x0001F5E0 File Offset: 0x0001E5E0
		public frmUploadAlternative(string post)
		{
			this.InitializeComponent();
			string key = "prkdeGRNIK648593648qwcvhufUYTFVC3456748392KJHSDFftyfDFHCtwpolao82935";
			this.txtCipher.Text = Utilities.Encrypt(post, key);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0001F9CA File Offset: 0x0001E9CA
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
