using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmChangeTask.
	/// </summary>
	// Token: 0x02000078 RID: 120
	public partial class frmChangeTask : Form
	{
		// Token: 0x06000309 RID: 777 RVA: 0x00033A68 File Offset: 0x00032A68
		public frmChangeTask(Task task, bool change, bool weekend)
		{
			this.InitializeComponent();
			this.task = task;
			this.change = change;
			this.task.Weekend = weekend;
			for (int i = 0; i < 48; i++)
			{
				this.cboStart.Items.Add(new DateTime(1, 1, 1).AddHours((double)((float)i / 2f)).ToShortTimeString());
				this.cboEnd.Items.Add(new DateTime(1, 1, 1).AddHours((double)((float)i / 2f)).ToShortTimeString());
			}
			this.cboStart.SelectedIndex = task.StartPeriod;
			this.cboEnd.SelectedIndex = task.EndPeriod;
			this.btnQuit.Visible = change;
			if (task is WorkTask)
			{
				this.panWorkTask.Visible = true;
				this.lnkPayment.Enabled = A.MF.mnuActionsIncomePayment.Enabled;
				this.lnkWitholding.Enabled = A.MF.mnuActionsIncomeWitholding.Enabled;
				this.lnk401K.Enabled = A.MF.mnuActionsIncome401K.Enabled;
				this.lnk401K.Visible = (((WorkTask)task).R401KMatch > -1f);
				this.labMedical.Visible = (((WorkTask)task).HealthInsurance != null);
				this.toolTip = new ToolTip();
				this.toolTip.InitialDelay = 0;
				this.toolTip.SetToolTip(this.labMedical, "This job offers health insurance");
			}
			if (task is WorkTask || task is AttendClass)
			{
				this.cboStart.Enabled = false;
				this.cboEnd.Enabled = false;
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0003458C File Offset: 0x0003358C
		private void btnQuit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(A.R.GetString("Are you sure you want to quit this activity?"), A.R.GetString("Confirm Quit"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (this.task is WorkTask)
				{
					A.SA.DeleteTask(A.MF.CurrentEntityID, this.task.ID, false, true);
				}
				else
				{
					A.SA.DeleteTask(A.MF.CurrentEntityID, this.task.ID);
				}
				((frmDailyRoutine)base.Owner).UpdateForm();
				base.Close();
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0003463C File Offset: 0x0003363C
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.cboStart.SelectedIndex == this.cboEnd.SelectedIndex)
			{
				MessageBox.Show("Tasks must be at least one hour long. Please try again.", "Invalid Entry");
			}
			else
			{
				try
				{
					if (this.change)
					{
						if (this.cboStart.Enabled)
						{
							A.SA.EditTask(A.MF.CurrentEntityID, this.task.ID, this.cboStart.SelectedIndex, this.cboEnd.SelectedIndex);
						}
					}
					else
					{
						this.task.StartPeriod = this.cboStart.SelectedIndex;
						this.task.EndPeriod = this.cboEnd.SelectedIndex;
						A.SA.AddTask(A.MF.CurrentEntityID, this.task);
					}
					((frmDailyRoutine)base.Owner).UpdateForm();
					base.Close();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
					this.cboStart.SelectedIndex = this.task.StartPeriod;
					this.cboEnd.SelectedIndex = this.task.EndPeriod;
				}
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00034788 File Offset: 0x00033788
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00034794 File Offset: 0x00033794
		private void lnkWitholding_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Form f = new frmW4(this.task.ID);
			f.ShowDialog(this);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000347BC File Offset: 0x000337BC
		private void lnkPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Form f = new frmMethodOfPay(this.task.ID);
			f.ShowDialog(this);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000347E4 File Offset: 0x000337E4
		private void lnk401K_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Form f = new frm401K(this.task.ID);
			f.ShowDialog(this);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0003480B File Offset: 0x0003380B
		private void labMedical_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0003480E File Offset: 0x0003380E
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Schedule"));
		}

		// Token: 0x040003EE RID: 1006
		private Task task;

		// Token: 0x040003EF RID: 1007
		private bool change;

		// Token: 0x040003F0 RID: 1008
		private ToolTip toolTip;
	}
}
