using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000077 RID: 119
	public partial class frmCreateMessage : Form
	{
		// Token: 0x06000447 RID: 1095 RVA: 0x0001EA40 File Offset: 0x0001DA40
		public frmCreateMessage()
		{
			this.InitializeComponent();
			this.labFrom.Text = S.I.MultiplayerRoleName + ", " + S.I.ThisPlayerName;
			this.labTo.Text = S.I.ThisPlayerName + " " + S.R.GetString("Executive Team");
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001F001 File Offset: 0x0001E001
		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0001F00B File Offset: 0x0001E00B
		private void btnSend_Click(object sender, EventArgs e)
		{
			S.SA.SendMessage(this.labFrom.Text, S.I.ThisPlayerName, this.txtMemo.Text);
			base.Close();
		}
	}
}
