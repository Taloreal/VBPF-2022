using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200002F RID: 47
	public partial class frmRunTo : Form
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x0000F514 File Offset: 0x0000E514
		public frmRunTo()
		{
			this.InitializeComponent();
			this.input = S.SA.GetRunTo();
			this.cal1.TodayDate = this.input.now;
			this.cal1.MinDate = this.input.now.AddDays(1.0);
			if (this.input.runTo < DateTime.MaxValue)
			{
				if (this.input.runTo < this.cal1.MinDate)
				{
					this.cal1.SelectionStart = this.cal1.MinDate;
				}
				else
				{
					this.cal1.SelectionStart = this.input.runTo;
				}
				this.radTo.Checked = true;
			}
			else
			{
				this.cal1.SelectionStart = this.input.now.AddDays(1.0);
			}
			this.cboUnits.SelectedIndex = 1;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000FCD0 File Offset: 0x0000ECD0
		private void btnOk_Click(object sender, EventArgs e)
		{
			if (this.radTo.Checked)
			{
				S.SA.SetRunTo(this.cal1.SelectionStart);
			}
			else if (this.radFor.Checked)
			{
				int num = (int)this.updPeriods.Value;
				if (this.cboUnits.SelectedIndex == 1)
				{
					num *= 7;
				}
				S.SA.SetRunTo(num);
			}
			else
			{
				if (!this.radCancel.Checked)
				{
					return;
				}
				S.SA.SetRunTo(DateTime.MaxValue);
			}
			base.Close();
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000FD85 File Offset: 0x0000ED85
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000FD8F File Offset: 0x0000ED8F
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Run to");
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000FD9D File Offset: 0x0000ED9D
		private void updPeriods_MouseDown(object sender, MouseEventArgs e)
		{
			this.radFor.Checked = true;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000FDAD File Offset: 0x0000EDAD
		private void cal1_MouseDown(object sender, MouseEventArgs e)
		{
			this.radTo.Checked = true;
		}

		// Token: 0x04000133 RID: 307
		private frmRunTo.Input input;

		// Token: 0x02000030 RID: 48
		[Serializable]
		public struct Input
		{
			// Token: 0x04000134 RID: 308
			public DateTime runTo;

			// Token: 0x04000135 RID: 309
			public DateTime now;
		}
	}
}
