using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmMultiplayerPlayers.
	/// </summary>
	// Token: 0x02000077 RID: 119
	public partial class frmMultiplayerPlayers : Form
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0003376F File Offset: 0x0003276F
		public frmMultiplayerPlayers()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00033A42 File Offset: 0x00032A42
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00033A4C File Offset: 0x00032A4C
		private void frmMultiplayerPlayers_Closed(object sender, EventArgs e)
		{
			this.NumPlayers = (int)this.updPlayers.Value;
		}

		// Token: 0x040003DD RID: 989
		public int NumPlayers;
	}
}
