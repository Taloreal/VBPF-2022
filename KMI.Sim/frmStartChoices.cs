using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000009 RID: 9
	public partial class frmStartChoices : Form
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00005C20 File Offset: 0x00004C20
		public frmStartChoices()
		{
			this.InitializeComponent();
			base.Size = this.panel1.Size;
			this.btnProject.Text = "\"New " + S.I.EntityName + "\" Project";
			if (S.I.VBC)
			{
				this.btnProject.Enabled = false;
				this.btnLessons.Enabled = false;
				this.btnMultiplayer.Enabled = false;
			}
			if (S.I.Academic)
			{
				this.btnMultiplayer.Visible = false;
				this.btnLessons.Visible = false;
				this.btnProject.Text = S.R.GetString("New Simulation");
				this.btnProject.Top = this.btnTutorial.Bottom + 32;
				this.btnSavedSims.Top = this.btnProject.Bottom + 32;
				this.btnExit.Top = this.btnSavedSims.Bottom + 32;
				base.Height -= 110;
				this.panel1.Height = base.Height;
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000062EB File Offset: 0x000052EB
		private void btnTutorial_Click(object sender, EventArgs e)
		{
			S.MF.mnuHelpTutorial.PerformClick();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000062FE File Offset: 0x000052FE
		private void btnLessons_Click(object sender, EventArgs e)
		{
			S.MF.mnuFileOpenLesson.PerformClick();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006311 File Offset: 0x00005311
		private void btnProject_Click(object sender, EventArgs e)
		{
			S.MF.mnuFileNew.PerformClick();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006324 File Offset: 0x00005324
		private void btnSavedSims_Click(object sender, EventArgs e)
		{
			S.MF.mnuFileOpenSavedSim.PerformClick();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006338 File Offset: 0x00005338
		private void btnMultiplayer_Click(object sender, EventArgs e)
		{
			frmDualChoiceDialog frmDualChoiceDialog = new frmDualChoiceDialog("Do you want to join an existing multiplayer session or start a new one for others to join?", "Join Existing Session", "Start New Session", true);
			switch (frmDualChoiceDialog.ShowDialog())
			{
			case DialogResult.Yes:
				S.MF.mnuFileMultiplayerJoin.PerformClick();
				break;
			case DialogResult.No:
				S.MF.mnuFileMultiplayerStart.PerformClick();
				break;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000639D File Offset: 0x0000539D
		private void btnExit_Click(object sender, EventArgs e)
		{
			S.MF.mnuFileExit.PerformClick();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000063B0 File Offset: 0x000053B0
		private void frmStartChoices_Closed(object sender, EventArgs e)
		{
		}
	}
}
