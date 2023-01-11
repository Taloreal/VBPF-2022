using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000004 RID: 4
	public partial class frmPlayMacro : Form
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000226F File Offset: 0x0000126F
		public frmPlayMacro()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000279F File Offset: 0x0000179F
		private void optSimDates_CheckedChanged(object sender, EventArgs e)
		{
			this.updInterval.Enabled = !this.optSimDates.Checked;
		}
	}
}
