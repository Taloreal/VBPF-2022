using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmRiskManagement.
	/// </summary>
	// Token: 0x0200007B RID: 123
	public partial class frmHealthInsurance : Form
	{
		// Token: 0x06000318 RID: 792 RVA: 0x00034C28 File Offset: 0x00033C28
		public frmHealthInsurance()
		{
			this.InitializeComponent();
			this.policy = A.SA.GetHealthInsurance(A.MF.CurrentEntityID);
			if (A.SA.HasHealthInsuranceThruWork(A.MF.CurrentEntityID))
			{
				MessageBox.Show("You already have health insurance through your work. You may not want to purchase additional coverage.", "Health Insurance");
			}
			this.cboCopay.Items.Add(5f);
			this.cboCopay.Items.Add(10f);
			this.cboCopay.Items.Add(25f);
			this.cboCopay.Items.Add(50f);
			this.cboCopay.Items.Add("No Coverage");
			if (this.policy.Copay == -1f)
			{
				this.cboCopay.SelectedIndex = 4;
			}
			else
			{
				this.cboCopay.SelectedIndex = this.cboCopay.FindStringExact(this.policy.Copay.ToString());
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000352A0 File Offset: 0x000342A0
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetHealthInsurance(A.MF.CurrentEntityID, this.policy);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000352F4 File Offset: 0x000342F4
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00035304 File Offset: 0x00034304
		private void cboCopay_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cboCopay.SelectedIndex == 4)
			{
				this.policy.Copay = -1f;
			}
			else
			{
				this.policy.Copay = (float)this.cboCopay.SelectedItem;
			}
			this.policy.MonthlyPremium = 0f;
			if (this.policy.Copay > 0f)
			{
				this.policy.MonthlyPremium = 200f + 500f / this.policy.Copay;
			}
			this.labPremium.Text = Utilities.FC(this.policy.MonthlyPremium * 12f, A.I.CurrencyConversion);
		}

		// Token: 0x04000403 RID: 1027
		private InsurancePolicy policy;
	}
}
