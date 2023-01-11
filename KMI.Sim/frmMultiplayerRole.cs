using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200006F RID: 111
	public partial class frmMultiplayerRole : Form
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x0001D6DC File Offset: 0x0001C6DC
		public frmMultiplayerRole()
		{
			this.InitializeComponent();
			foreach (MultiplayerRole multiplayerRole in MultiplayerRole.Roles)
			{
				this.lstRoles.Items.Add(multiplayerRole.RoleName);
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0001D964 File Offset: 0x0001C964
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.lstRoles.SelectedIndex == -1)
			{
				MessageBox.Show(S.R.GetString("You must select a role to play in the sim."), S.R.GetString("Please Retry"));
			}
			else
			{
				this.RoleName = this.lstRoles.SelectedItem.ToString();
				base.Close();
			}
		}

		// Token: 0x040002B8 RID: 696
		public string RoleName;
	}
}
