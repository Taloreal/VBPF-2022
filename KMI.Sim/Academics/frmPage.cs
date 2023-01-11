using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KMI.Sim.Academics
{
	// Token: 0x02000033 RID: 51
	public partial class frmPage : Form
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x0001066C File Offset: 0x0000F66C
		public frmPage(Page page)
		{
			try
			{
				this.InitializeComponent();
			}
			catch (COMException ex)
			{
			}
			this.page = page;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000109DC File Offset: 0x0000F9DC
		private void btnQuestions_Click(object sender, EventArgs e)
		{
			frmQuestions frmQuestions = new frmQuestions(frmQuestions.Modes.Quiz, this.page.Questions);
			frmQuestions.ShowDialog(this);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00010A04 File Offset: 0x0000FA04
		private void frmPage_Load(object sender, EventArgs e)
		{
			object obj = new object();
			object obj2 = AcademicGod.PageBankPath + Path.DirectorySeparatorChar + this.page.BodyURL;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00010A38 File Offset: 0x0000FA38
		private void frmPage_Closing(object sender, CancelEventArgs e)
		{
			if (!this.okToClose)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x04000147 RID: 327
		private Page page;

		// Token: 0x04000148 RID: 328
		public bool okToClose = false;
	}
}
