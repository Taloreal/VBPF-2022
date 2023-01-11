using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x0200000E RID: 14
	public partial class frmTransferCash : Form
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000066B4 File Offset: 0x000056B4
		public frmTransferCash()
		{
			this.InitializeComponent();
			this.input = ((BizStateAdapter)S.SA).getTransferCash(S.I.ThisPlayerName);
			foreach (string item in this.input.OwnedEntities)
			{
				this.cboFrom.Items.Add(item);
				this.cboTo.Items.Add(item);
			}
			if (this.input.OwnedEntities.Length > 1)
			{
				this.cboFrom.SelectedIndex = 0;
				this.cboTo.SelectedIndex = Math.Min(1, this.input.OwnedEntities.Length - 1);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006F30 File Offset: 0x00005F30
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00006F3C File Offset: 0x00005F3C
		private void frmTransferCash_Load(object sender, EventArgs e)
		{
			if (this.input.OwnedEntities.Length <= 1)
			{
				MessageBox.Show("You need to own at least two " + S.I.EntityName.ToLower() + "s to transfer cash.", "Transfer Cash");
				base.Close();
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00006F90 File Offset: 0x00005F90
		private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.labCashFrom.Text = Utilities.FC(this.input.CashBalances[this.cboFrom.SelectedIndex], S.I.CurrencyConversion);
			this.updAmount.Maximum = (decimal)this.input.CashBalances[this.cboFrom.SelectedIndex];
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006FF9 File Offset: 0x00005FF9
		private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.labCashTo.Text = Utilities.FC(this.input.CashBalances[this.cboTo.SelectedIndex], S.I.CurrencyConversion);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00007030 File Offset: 0x00006030
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				((BizStateAdapter)S.SA).setTransferCash(S.MF.EntityNameToID(this.cboFrom.SelectedItem.ToString()), S.MF.EntityNameToID(this.cboTo.SelectedItem.ToString()), (float)this.updAmount.Value);
				base.Close();
			}
			catch (EntityNotFoundException ex)
			{
				string @string = S.R.GetString("No longer exists");
				MessageBox.Show(this, ex.Message, @string);
				base.Close();
			}
			catch (SimApplicationException ex2)
			{
				string @string = S.R.GetString("Not enough cash");
				MessageBox.Show(this, ex2.Message, @string);
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2, this);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00007128 File Offset: 0x00006128
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x04000057 RID: 87
		protected frmTransferCash.Input input;

		// Token: 0x0200000F RID: 15
		[Serializable]
		public struct Input
		{
			// Token: 0x04000058 RID: 88
			public string[] OwnedEntities;

			// Token: 0x04000059 RID: 89
			public float[] CashBalances;
		}
	}
}
