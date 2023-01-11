using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;
using KMI.VBPF1Lib.Custom_Controls;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmLicensing.
	/// </summary>
	// Token: 0x0200009A RID: 154
	public partial class frmDepositChecks : Form
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x00043CA4 File Offset: 0x00042CA4
		public frmDepositChecks()
		{
			this.InitializeComponent();
			this.chkCheck = new CheckControl();
			this.chkCheck.Location = new Point(16, 24);
			this.panChecks.Controls.Add(this.chkCheck);
			for (int i = 0; i < 4; i++)
			{
				Label j = new Label();
				j.BorderStyle = BorderStyle.FixedSingle;
				j.BackColor = this.chkCheck.BackColor;
				j.Size = this.chkCheck.Size;
				j.Location = new Point(20 + i * 4, 20 - i * 4);
				this.panChecks.Controls.Add(j);
			}
			this.accounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in this.accounts.Values)
			{
				BankAccount account = (BankAccount)obj;
				this.cboAccounts.Items.Add(account);
				if (account is CheckingAccount)
				{
					this.hasCheckingAccount = true;
				}
			}
			if (this.cboAccounts.Items.Count > 0)
			{
				this.optDeposit.Enabled = true;
				this.cboAccounts.SelectedIndex = 0;
			}
			this.labWarning.Visible = !this.hasCheckingAccount;
			this.RefreshData();
			this.currentIndex = 0;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00044620 File Offset: 0x00043620
		private void SwitchCheck()
		{
			this.chkCheck.Check = this.currentCheck;
			this.btnBack.Enabled = (this.currentIndex > 0);
			this.btnNext.Enabled = (this.currentIndex < this.checks.Count - 1);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00044676 File Offset: 0x00043676
		private void btnNext_Click(object sender, EventArgs e)
		{
			this.currentIndex++;
			this.SwitchCheck();
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0004468E File Offset: 0x0004368E
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.currentIndex--;
			this.SwitchCheck();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000446A8 File Offset: 0x000436A8
		private void btnAccept_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.optCash.Checked)
				{
					float fee = 0f;
					if (!this.hasCheckingAccount)
					{
						fee = 0.1f;
					}
					A.SA.CashCheck(A.MF.CurrentEntityID, this.currentCheck, fee);
				}
				else
				{
					A.SA.DepositCheck(A.MF.CurrentEntityID, this.currentCheck, ((BankAccount)this.cboAccounts.SelectedItem).AccountNumber);
				}
				A.MF.UpdateView();
				this.RefreshData();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00044764 File Offset: 0x00043764
		public Check currentCheck
		{
			get
			{
				return (Check)this.checks.GetByIndex(this.currentIndex);
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0004478C File Offset: 0x0004378C
		protected void RefreshData()
		{
			this.checks = A.SA.GetChecks(A.MF.CurrentEntityID);
			this.currentIndex = Math.Min(this.currentIndex, this.checks.Count - 1);
			this.panChecks.Visible = (this.checks.Count > 0);
			this.btnAccept.Enabled = (this.checks.Count > 0);
			for (int i = 0; i < this.panChecks.Controls.Count; i++)
			{
				this.panChecks.Controls[i].Visible = (i < this.checks.Count);
			}
			if (this.checks.Count > 0)
			{
				this.SwitchCheck();
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00044866 File Offset: 0x00043866
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00044870 File Offset: 0x00043870
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Deposit Funds"));
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00044888 File Offset: 0x00043888
		private void optDeposit_CheckedChanged(object sender, EventArgs e)
		{
			this.cboAccounts.Enabled = this.optDeposit.Checked;
		}

		// Token: 0x040005A5 RID: 1445
		private CheckControl chkCheck;

		// Token: 0x040005AC RID: 1452
		private SortedList checks;

		// Token: 0x040005AD RID: 1453
		private SortedList accounts;

		// Token: 0x040005AE RID: 1454
		private int currentIndex;

		// Token: 0x040005AF RID: 1455
		private bool hasCheckingAccount;
	}
}
