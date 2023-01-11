using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000031 RID: 49
	public partial class frmDrawnReport : Form
	{
		// Token: 0x060001DF RID: 479 RVA: 0x0000FDBD File Offset: 0x0000EDBD
		public frmDrawnReport()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000102EC File Offset: 0x0000F2EC
		protected virtual void DrawReportVirtual(Graphics g)
		{
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x000102F0 File Offset: 0x0000F2F0
		protected void DrawReport(Graphics g)
		{
			try
			{
				this.DrawReportVirtual(g);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00010328 File Offset: 0x0000F328
		protected virtual void GetDataVirtual()
		{
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001032C File Offset: 0x0000F32C
		protected bool GetData()
		{
			try
			{
				this.GetDataVirtual();
				return true;
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
			return false;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0001036C File Offset: 0x0000F36C
		protected virtual void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.picReport.Refresh();
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00010398 File Offset: 0x0000F398
		protected virtual void EntityChangedHandler(object sender, EventArgs e)
		{
			if (this.EnablingReference != null && !this.EnablingReference.Enabled)
			{
				base.Close();
			}
			else if (this.GetData())
			{
				this.picReport.Refresh();
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000103E8 File Offset: 0x0000F3E8
		protected virtual void btnPrint_Click(object sender, EventArgs e)
		{
			this.studentName = "";
			frmInputString frmInputString = new frmInputString(S.R.GetString("Student Name"), S.R.GetString("Enter your name to help identify your printout on a shared printer:"), this.studentName);
			frmInputString.ShowDialog(this);
			this.studentName = frmInputString.Response;
			Utilities.PrintWithExceptionHandling("", new PrintPageEventHandler(this.Report_PrintPage));
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00010458 File Offset: 0x0000F458
		protected virtual void Report_PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			if (this.studentName.Length > 0)
			{
				Font font = new Font("Arial", 10f);
				Brush brush = new SolidBrush(Color.Black);
				e.Graphics.DrawString(S.R.GetString("This report belongs to: {0}", new object[]
				{
					this.studentName
				}), font, brush, 0f, 0f);
				e.Graphics.TranslateTransform(0f, 2f * e.Graphics.MeasureString(this.studentName, font).Height);
			}
			this.DrawReport(e.Graphics);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00010518 File Offset: 0x0000F518
		protected virtual void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00010522 File Offset: 0x0000F522
		protected virtual void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00010531 File Offset: 0x0000F531
		protected virtual void picReport_Paint(object sender, PaintEventArgs e)
		{
			this.DrawReport(e.Graphics);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00010544 File Offset: 0x0000F544
		protected virtual void frmReport_Load(object sender, EventArgs e)
		{
			if (this.EnablingReference == null && !base.DesignMode)
			{
				throw new Exception("Enabling reference not set in " + this.Text);
			}
			if (S.MF != null)
			{
				S.MF.NewWeek += this.NewWeekHandler;
				S.MF.EntityChanged += this.EntityChangedHandler;
			}
			if (this.GetData())
			{
				this.picReport.Refresh();
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000105D6 File Offset: 0x0000F5D6
		protected virtual void frmReport_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			S.MF.EntityChanged -= this.EntityChangedHandler;
		}

		// Token: 0x0400013E RID: 318
		public MenuItem EnablingReference;

		// Token: 0x0400013F RID: 319
		protected string studentName;
	}
}
