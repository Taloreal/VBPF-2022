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
	// Token: 0x020000AA RID: 170
	public partial class frmAutoInsurance : Form
	{
		// Token: 0x0600050E RID: 1294 RVA: 0x0004926C File Offset: 0x0004826C
		public frmAutoInsurance()
		{
			this.InitializeComponent();
			this.car = A.SA.GetAutoInsurance(A.MF.CurrentEntityID);
			this.cboDeductible.Items.Add(250f);
			this.cboDeductible.Items.Add(500f);
			this.cboDeductible.Items.Add(1000f);
			this.cboDeductible.Items.Add(2000f);
			this.cboDeductible.Items.Add("No Coverage");
			this.carValue = this.car.ComputeResalePrice(A.MF.Now);
			this.labValue.Text = Utilities.FC(this.carValue, A.I.CurrencyConversion);
			if (this.car.Insurance.Deductible == -1f)
			{
				this.cboDeductible.SelectedIndex = 4;
			}
			else
			{
				this.cboDeductible.SelectedIndex = this.cboDeductible.FindStringExact(this.car.Insurance.Deductible.ToString());
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00049A8C File Offset: 0x00048A8C
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetAutoInsurance(A.MF.CurrentEntityID, this.car.Insurance);
				this.btnCancel.Enabled = true;
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00049AF0 File Offset: 0x00048AF0
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00049B00 File Offset: 0x00048B00
		private void frmAutoInsurance_Closing(object sender, CancelEventArgs e)
		{
			if (sender is Control && !this.btnCancel.Enabled)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00049B30 File Offset: 0x00048B30
		private void cboDeductible_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cboDeductible.SelectedIndex == 4)
			{
				this.car.Insurance.Deductible = -1f;
			}
			else
			{
				this.car.Insurance.Deductible = (float)this.cboDeductible.SelectedItem;
			}
			this.car.Insurance.MonthlyPremium = 80f;
			if (this.car.Insurance.Deductible > 0f)
			{
				this.car.Insurance.MonthlyPremium += 20000f / this.car.Insurance.Deductible;
			}
			this.labPremium.Text = Utilities.FC(this.car.Insurance.MonthlyPremium * 12f, A.I.CurrencyConversion);
		}

		// Token: 0x170000B2 RID: 178
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x00049C1C File Offset: 0x00048C1C
		public bool Cancellable
		{
			set
			{
				if (!value)
				{
					this.btnCancel.Enabled = false;
				}
			}
		}

		// Token: 0x04000618 RID: 1560
		private Car car;

		// Token: 0x04000619 RID: 1561
		private float carValue;
	}
}
