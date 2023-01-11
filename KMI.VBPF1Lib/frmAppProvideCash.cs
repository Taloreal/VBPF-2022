using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmAppProvideCash.
	/// </summary>
	// Token: 0x0200009B RID: 155
	public partial class frmAppProvideCash : Form
	{
		// Token: 0x060004CE RID: 1230 RVA: 0x000448A4 File Offset: 0x000438A4
		public frmAppProvideCash()
		{
			this.InitializeComponent();
			this.NamesAndIds = A.SA.GetNamesAndIds();
			foreach (object obj in this.NamesAndIds.Keys)
			{
				string name = (string)obj;
				this.cboNames.Items.Add(name);
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00044E08 File Offset: 0x00043E08
		private void frmAppProvideCash_Load(object sender, EventArgs e)
		{
			if (this.cboNames.Items.Count > 0)
			{
				this.cboNames.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("There aren't any people in this sim yet. Rent an apartment to create a person.", "Provide Cash");
				base.Close();
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00044E58 File Offset: 0x00043E58
		private void btnOk_Click(object sender, EventArgs e)
		{
			long entityID = (long)this.NamesAndIds[this.cboNames.SelectedItem.ToString()];
			try
			{
				A.SA.ProvideCash(entityID, (float)this.updCash.Value);
				A.MF.UpdateView();
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x040005B8 RID: 1464
		private Hashtable NamesAndIds;
	}
}
