using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmTransportation.
	/// </summary>
	// Token: 0x02000019 RID: 25
	public partial class frmTransportation : Form
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00009904 File Offset: 0x00008904
		public frmTransportation()
		{
			this.InitializeComponent();
			int index = A.SA.GetTransportation(A.MF.CurrentEntityID);
			if (index > -1)
			{
				((RadioButton)this.panMain.Controls[index]).Checked = true;
				this.btnCancel.Enabled = true;
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000A0B3 File Offset: 0x000090B3
		private void button3_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000A0C0 File Offset: 0x000090C0
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				int index = -1;
				for (int i = 0; i < this.panMain.Controls.Count; i++)
				{
					if (((RadioButton)this.panMain.Controls[i]).Checked)
					{
						index = i;
					}
				}
				if (index == -1)
				{
					MessageBox.Show("You must select a mode of transportation.", "Input Required");
				}
				else
				{
					A.SA.SetTransportation(A.MF.CurrentEntityID, index);
					base.Close();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000A170 File Offset: 0x00009170
		private void frmTransportation_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = !this.btnOK.Enabled;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000A188 File Offset: 0x00009188
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.btnOK.Enabled = true;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000A198 File Offset: 0x00009198
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}
	}
}
