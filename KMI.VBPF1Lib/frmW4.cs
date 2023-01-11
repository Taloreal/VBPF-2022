using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmW4.
	/// </summary>
	// Token: 0x020000A1 RID: 161
	public partial class frmW4 : Form
	{
		// Token: 0x060004EC RID: 1260 RVA: 0x000463B8 File Offset: 0x000453B8
		public frmW4(long taskID)
		{
			this.InitializeComponent();
			this.input = A.SA.GetAllowances(A.MF.CurrentEntityID, taskID);
			this.txtAllowances.Text = this.input.Allowances.ToString();
			this.txtAdditional.Text = this.input.Additional.ToString("N2");
			this.taskID = taskID;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000470B4 File Offset: 0x000460B4
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				int allowances = int.Parse(this.txtAllowances.Text);
				float additional = 0f;
				if (this.txtAdditional.Text != "")
				{
					additional = float.Parse(this.txtAdditional.Text);
				}
				if (additional < 0f)
				{
					MessageBox.Show(A.R.GetString("Amount on Line 6 cannot be less than zero. Please try again."), A.R.GetString("Please Retry"));
				}
				else if (allowances < 0)
				{
					MessageBox.Show(A.R.GetString("Allowances on Line 5 cannot be less than zero. Please try again."), A.R.GetString("Please Retry"));
				}
				else if (allowances > 2)
				{
					MessageBox.Show(A.R.GetString("Allowances on Line 5 should not be more than 2. Please review lines A-H above and try again."), A.R.GetString("Please Retry"));
				}
				else
				{
					A.SA.SetAllowances(A.MF.CurrentEntityID, this.taskID, this.txtExempt.Text.Trim().ToUpper() == "EXEMPT", allowances, additional);
					base.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(A.R.GetString("Incorrect amount. Please try again."), A.R.GetString("Please Retry"));
			}
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00047234 File Offset: 0x00046234
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Getting Paid"));
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0004724C File Offset: 0x0004624C
		private void frmW4_Load(object sender, EventArgs e)
		{
			if (this.input.DisabledForCompetition)
			{
				MessageBox.Show("For this competitive simulation, your allowances will be automatically set for you.", "Form W-4");
				base.Close();
			}
		}

		// Token: 0x040005DA RID: 1498
		private long taskID;

		// Token: 0x040005DB RID: 1499
		private frmW4.Input input;

		// Token: 0x020000A2 RID: 162
		[Serializable]
		public struct Input
		{
			// Token: 0x040005DC RID: 1500
			public int Allowances;

			// Token: 0x040005DD RID: 1501
			public float Additional;

			// Token: 0x040005DE RID: 1502
			public bool DisabledForCompetition;
		}
	}
}
