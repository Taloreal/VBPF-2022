using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frm401K.
	/// </summary>
	// Token: 0x02000029 RID: 41
	public partial class frm401K : Form
	{
		// Token: 0x0600013B RID: 315 RVA: 0x000125E4 File Offset: 0x000115E4
		public frm401K(long taskID)
		{
			this.InitializeComponent();
			ArrayList funds = A.SA.GetFunds();
			this.input = A.SA.Get401K(A.MF.CurrentEntityID, taskID);
			this.taskID = taskID;
			this.updPercent.Value = (decimal)this.input.PercentWitheld * 100m;
			int i = 0;
			foreach (object obj in funds)
			{
				Fund fund = (Fund)obj;
				AllocationControl c = new AllocationControl();
				c.Top = i * c.Height;
				c.Tag = fund;
				c.updPct.Value = (decimal)this.input.Allocations[i] * 100m;
				c.labFundName.Text = fund.Name;
				if (i % 2 == 1)
				{
					c.BackColor = Color.LightGray;
				}
				this.panFunds.Controls.Add(c);
				i++;
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00012E20 File Offset: 0x00011E20
		private void btnOK_Click(object sender, EventArgs e)
		{
			float[] allocations = new float[this.panFunds.Controls.Count];
			if (this.updPercent.Value > 0m)
			{
				decimal total = 0m;
				int i = 0;
				foreach (object obj in this.panFunds.Controls)
				{
					AllocationControl c = (AllocationControl)obj;
					total += c.updPct.Value;
					allocations[i++] = (float)c.updPct.Value / 100f;
				}
				if (total != 100m)
				{
					string s = "less";
					if (total > 100m)
					{
						s = "more";
					}
					MessageBox.Show(A.R.GetString("Your investment allocation percentages add to {0} than 100%. Please try again.", new object[]
					{
						s
					}), "Try Again");
					return;
				}
			}
			A.SA.Set401K(A.MF.CurrentEntityID, this.taskID, (float)this.updPercent.Value / 100f, allocations);
			base.Close();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00012FA4 File Offset: 0x00011FA4
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00012FB0 File Offset: 0x00011FB0
		private void updPercent_ValueChanged(object sender, EventArgs e)
		{
			this.labMatch.Text = Utilities.FP((float)Math.Min(this.updPercent.Value / 100m, (decimal)this.input.CompanyMatch));
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00013002 File Offset: 0x00012002
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("View Retirement Portfolio"));
		}

		// Token: 0x04000140 RID: 320
		private frm401K.Input input;

		// Token: 0x04000141 RID: 321
		private long taskID;

		// Token: 0x0200002A RID: 42
		[Serializable]
		public struct Input
		{
			// Token: 0x04000142 RID: 322
			public float[] Allocations;

			// Token: 0x04000143 RID: 323
			public float PercentWitheld;

			// Token: 0x04000144 RID: 324
			public float CompanyMatch;
		}
	}
}
