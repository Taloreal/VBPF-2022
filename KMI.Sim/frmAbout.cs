using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200001D RID: 29
	public partial class frmAbout : Form
	{
		// Token: 0x0600015B RID: 347 RVA: 0x0000BE38 File Offset: 0x0000AE38
		public frmAbout()
		{
			this.InitializeComponent();
			this.btnCurrentSimInfo.Visible = S.MF.DesignerMode;
			this.Text = S.R.GetString("About") + " " + Application.ProductName;
			this.labProductName.Text = S.R.GetString("Product Name") + ": " + Application.ProductName;
			if (S.I.VBC)
			{
				Label label = this.labProductName;
				label.Text += S.R.GetString(" - VBC Edition");
			}
			if (S.I.Demo)
			{
				Label label2 = this.labProductName;
				label2.Text += S.R.GetString(" - Demo Edition");
			}
			this.labVersion.Text = S.R.GetString("Product Version") + ": " + Application.ProductVersion;
			this.labCopyrightInfo.Text = string.Concat(new string[]
			{
				S.R.GetString("Copyright"),
				" ",
				DateTime.Now.Year.ToString(),
				" ",
				Application.CompanyName,
				". ",
				S.R.GetString("All rights reserved worldwide.")
			});
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000C34A File Offset: 0x0000B34A
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000C354 File Offset: 0x0000B354
		private void frmSplashAbout_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.X > 8 && e.X < 32 && e.Y > 8 && e.Y < 32)
			{
				frmPassword frmPassword = new frmPassword("ponkey");
				if (frmPassword.ShowDialog(this) == DialogResult.OK)
				{
					S.MF.DesignerMode = !S.MF.DesignerMode;
					this.btnCurrentSimInfo.Visible = S.MF.DesignerMode;
					S.MF.EnableDisable();
				}
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000C3EC File Offset: 0x0000B3EC
		private void btnCurrentSimInfo_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Sim Guid = " + S.ST.GUID.ToString());
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000C422 File Offset: 0x0000B422
		private void frmAbout_Load(object sender, EventArgs e)
		{
		}
	}
}
