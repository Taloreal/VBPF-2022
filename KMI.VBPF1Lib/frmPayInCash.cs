using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayInCash.
	/// </summary>
	// Token: 0x0200003B RID: 59
	public partial class frmPayInCash : Form
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x0001BE64 File Offset: 0x0001AE64
		public frmPayInCash()
		{
			this.InitializeComponent();
			this.labCash.Text = Utilities.FC(A.SA.GetCash(A.MF.CurrentEntityID), A.I.CurrencyConversion);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0001C3EF File Offset: 0x0001B3EF
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0001C3F9 File Offset: 0x0001B3F9
		private void btnOK_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0001C3FC File Offset: 0x0001B3FC
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Pay Bills"));
		}
	}
}
