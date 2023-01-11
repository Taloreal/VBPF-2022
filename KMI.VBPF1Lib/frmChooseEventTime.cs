using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmChooseEventTime.
	/// </summary>
	// Token: 0x02000059 RID: 89
	public partial class frmChooseEventTime : Form
	{
		// Token: 0x06000261 RID: 609 RVA: 0x00027618 File Offset: 0x00026618
		public frmChooseEventTime()
		{
			this.InitializeComponent();
			for (int i = 0; i < 48; i++)
			{
				this.cboStart.Items.Add(new DateTime(1, 1, 1).AddHours((double)((float)i / 2f)).ToShortTimeString());
				this.cboEnd.Items.Add(new DateTime(1, 1, 1).AddHours((double)((float)i / 2f)).ToShortTimeString());
			}
			this.Cal.TodayDate = A.MF.Now.AddDays(1.0);
			this.Cal.SetDate(this.Cal.TodayDate);
			this.Cal.MinDate = this.Cal.TodayDate;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00027CFD File Offset: 0x00026CFD
		private void groupBox4_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00027D00 File Offset: 0x00026D00
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.cboStart.SelectedIndex == -1 || this.cboEnd.SelectedIndex == -1)
				{
					MessageBox.Show(A.R.GetString("You must selected a starting and ending time. Please try again."), A.R.GetString("Input Required"));
				}
				else if (this.cboStart.SelectedIndex == this.cboEnd.SelectedIndex)
				{
					MessageBox.Show(A.R.GetString("Events must last at least one-half hour. Please try again."), A.R.GetString("Input Required"));
				}
				else
				{
					A.SA.SetParty(A.MF.CurrentEntityID, this.Cal.SelectionStart, this.cboStart.SelectedIndex, this.cboEnd.SelectedIndex);
					base.Close();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00027E04 File Offset: 0x00026E04
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00027E0E File Offset: 0x00026E0E
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Socializing"));
		}
	}
}
