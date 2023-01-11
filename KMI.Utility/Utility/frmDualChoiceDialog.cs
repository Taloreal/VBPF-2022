using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x02000009 RID: 9
	public partial class frmDualChoiceDialog : Form
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00005404 File Offset: 0x00004404
		public frmDualChoiceDialog(string caption, string button1Text, string button2Text, bool allowCancel)
		{
			this.InitializeComponent();
			this.label1.Text = caption;
			this.btnChoice0.Text = button1Text;
			this.btnChoice1.Text = button2Text;
			this.btnCancel.Visible = allowCancel;
		}
	}
}
