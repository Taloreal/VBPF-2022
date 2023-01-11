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
	// Token: 0x0200003C RID: 60
	public partial class frmHomeOwnersInsurance : Form
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x0001C414 File Offset: 0x0001B414
		public frmHomeOwnersInsurance(Offering offering)
		{
			this.InitializeComponent();
			this.input = A.SA.GetHomeOwnersInsurance(offering);
			this.offering = offering;
			this.cboDeductible.Items.Add(250f);
			this.cboDeductible.Items.Add(500f);
			this.cboDeductible.Items.Add(1000f);
			this.cboDeductible.Items.Add(2000f);
			this.labValue.Text = Utilities.FC(this.input.Value, A.I.CurrencyConversion);
			this.updAmount.Minimum = (decimal)this.input.Value / 2m;
			this.updAmount.Value = Math.Max(this.updAmount.Minimum, (decimal)this.input.Policy.Limit);
			this.cboDeductible.SelectedIndex = this.cboDeductible.FindStringExact(this.input.Policy.Deductible.ToString());
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0001CD78 File Offset: 0x0001BD78
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetHomeOwnersInsurance(this.offering, this.input.Policy);
				this.btnCancel.Enabled = true;
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0001CDD8 File Offset: 0x0001BDD8
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Homeowners Insurance"));
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0001CDF0 File Offset: 0x0001BDF0
		private void cboDeductible_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cboDeductible.SelectedIndex != -1)
			{
				if (this.cboDeductible.SelectedIndex == 4)
				{
					this.input.Policy.Deductible = -1f;
				}
				else
				{
					this.input.Policy.Deductible = (float)this.cboDeductible.SelectedItem;
				}
				if (this.updAmount.Value < (decimal)this.input.Policy.Deductible)
				{
					this.updAmount.Value = (decimal)this.input.Policy.Deductible;
				}
				this.input.Policy.Limit = (float)this.updAmount.Value;
				this.input.Policy.MonthlyPremium = 0f;
				if (this.input.Policy.Deductible > 0f)
				{
					this.input.Policy.MonthlyPremium = (float)this.updAmount.Value / 50000f * (10f + 2000f / this.input.Policy.Deductible);
				}
				this.labPremium.Text = Utilities.FC(this.input.Policy.MonthlyPremium * 12f, A.I.CurrencyConversion);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0001CF7C File Offset: 0x0001BF7C
		private void frmHomeOwnersInsurance_Closing(object sender, CancelEventArgs e)
		{
			if (sender is Control && !this.btnCancel.Enabled)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x1700001F RID: 31
		// (set) Token: 0x060001CE RID: 462 RVA: 0x0001CFAC File Offset: 0x0001BFAC
		public bool Cancellable
		{
			set
			{
				if (!value)
				{
					this.btnCancel.Enabled = false;
					this.labInsuranceRequired.Visible = true;
				}
			}
		}

		// Token: 0x040001E8 RID: 488
		private frmHomeOwnersInsurance.Input input;

		// Token: 0x040001E9 RID: 489
		private Offering offering;

		// Token: 0x0200003D RID: 61
		[Serializable]
		public struct Input
		{
			// Token: 0x040001EA RID: 490
			public float Value;

			// Token: 0x040001EB RID: 491
			public InsurancePolicy Policy;
		}
	}
}
