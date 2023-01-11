using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000052 RID: 82
	public partial class frmProvideCash : Form
	{
		// Token: 0x0600030E RID: 782 RVA: 0x00017F50 File Offset: 0x00016F50
		public frmProvideCash()
		{
			this.InitializeComponent();
			this.labDescription.Text = this.labDescription.Text.Replace("XXX", S.I.EntityName.ToLower());
			this.labStore.Text = this.labStore.Text.Replace("XXX", S.MF.EntityIDToName(S.MF.CurrentEntityID));
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000183BC File Offset: 0x000173BC
		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				S.SA.ProvideCash(S.MF.CurrentEntityID, (float)this.updCash.Value);
				S.MF.UpdateView();
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2, this);
			}
		}
	}
}
