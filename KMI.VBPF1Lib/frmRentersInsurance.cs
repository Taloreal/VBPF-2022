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
	// Token: 0x0200006B RID: 107
	public partial class frmRentersInsurance : Form
	{
		// Token: 0x060002C1 RID: 705 RVA: 0x0002CFE0 File Offset: 0x0002BFE0
		public frmRentersInsurance()
		{
			this.InitializeComponent();
			this.policy = A.SA.GetRentersInsurance(A.MF.CurrentEntityID);
			this.cboDeductible.Items.Add(250f);
			this.cboDeductible.Items.Add(500f);
			this.cboDeductible.Items.Add(1000f);
			this.cboDeductible.Items.Add(2000f);
			this.cboDeductible.Items.Add("No Coverage");
			this.updAmount.Value = (decimal)this.policy.Limit;
			if (this.policy.Deductible == -1f)
			{
				this.cboDeductible.SelectedIndex = 4;
			}
			else
			{
				this.cboDeductible.SelectedIndex = this.cboDeductible.FindStringExact(this.policy.Deductible.ToString());
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0002D734 File Offset: 0x0002C734
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				this.cboDeductible_SelectedIndexChanged(new object(), new EventArgs());
				A.SA.SetRentersInsurance(A.MF.CurrentEntityID, this.policy);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0002D798 File Offset: 0x0002C798
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Renters Insurance"));
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0002D7B0 File Offset: 0x0002C7B0
		private void cboDeductible_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cboDeductible.SelectedIndex != -1)
			{
				if (this.cboDeductible.SelectedIndex == 4)
				{
					this.policy.Deductible = -1f;
				}
				else
				{
					this.policy.Deductible = (float)this.cboDeductible.SelectedItem;
				}
				if (this.updAmount.Value < (decimal)this.policy.Deductible)
				{
					this.updAmount.Value = (decimal)this.policy.Deductible;
				}
				this.policy.Limit = (float)this.updAmount.Value;
				this.policy.MonthlyPremium = 0f;
				if (this.policy.Deductible > 0f)
				{
					this.policy.MonthlyPremium = (float)this.updAmount.Value / 5000f * (10f + 2000f / this.policy.Deductible);
				}
				this.labPremium.Text = Utilities.FC(this.policy.MonthlyPremium * 12f, A.I.CurrencyConversion);
			}
		}

		// Token: 0x04000359 RID: 857
		private InsurancePolicy policy;
	}
}
