using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000010 RID: 16
	public partial class frmConsultant : Form
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00007137 File Offset: 0x00006137
		public frmConsultant()
		{
			this.InitializeComponent();
			this.report = ((BizStateAdapter)Simulator.Instance.SimStateAdapter).GetConsultantReport(frmMainBase.Instance.CurrentEntityID);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000771C File Offset: 0x0000671C
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Consultant");
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000772C File Offset: 0x0000672C
		private void frmConsultant_Resize(object sender, EventArgs e)
		{
			this.picReport.Width = this.panReportArea.ClientRectangle.Width - this.picReport.Left - 20;
			this.picReport.Refresh();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00007774 File Offset: 0x00006774
		private void picReport_Paint(object sender, PaintEventArgs e)
		{
			this.picReport.Height = this.report.PrintToScreen(this.picReport.Width, e.Graphics, this.chkFullReport.Checked, false);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000077AB File Offset: 0x000067AB
		private void chkFullReport_Click(object sender, EventArgs e)
		{
			this.picReport.Refresh();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000077BA File Offset: 0x000067BA
		private void chkGrades_Click(object sender, EventArgs e)
		{
			this.picReport.Refresh();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000077C9 File Offset: 0x000067C9
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000077D3 File Offset: 0x000067D3
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.report.PrintToPrinter(this.chkFullReport.Checked, false);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000077EE File Offset: 0x000067EE
		private void frmConsultant_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x04000063 RID: 99
		protected ConsultantReport report;
	}
}
