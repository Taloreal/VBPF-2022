using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmMessageBoxWithIcon.
	/// </summary>
	// Token: 0x0200006E RID: 110
	public partial class frmMessageBoxWithIcon : Form
	{
		// Token: 0x060002E5 RID: 741 RVA: 0x000324D4 File Offset: 0x000314D4
		public frmMessageBoxWithIcon(string message, Bitmap icon)
		{
			this.InitializeComponent();
			this.Text = Application.ProductName;
			this.labIcon.Image = icon;
			this.labMessage.Text = message;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00032729 File Offset: 0x00031729
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
