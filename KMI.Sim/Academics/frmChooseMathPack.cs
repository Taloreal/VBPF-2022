using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMI.Sim.Academics
{
	// Token: 0x0200005E RID: 94
	public partial class frmChooseMathPack : Form
	{
		// Token: 0x06000378 RID: 888 RVA: 0x00019B20 File Offset: 0x00018B20
		public frmChooseMathPack()
		{
			this.InitializeComponent();
			this.pageBankNames = Directory.GetDirectories(Application.StartupPath + Path.DirectorySeparatorChar + "MathPaks");
			foreach (string text in this.pageBankNames)
			{
				int num = text.LastIndexOf(Path.DirectorySeparatorChar);
				string item = text.Substring(num + 1, text.Length - num - 1);
				this.lstPaks.Items.Add(item);
			}
			if (this.lstPaks.Items.Count == 0)
			{
				MessageBox.Show("No math paks found. Cannot continue.", "Missing Math Paks");
				Application.Exit();
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00019F88 File Offset: 0x00018F88
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.lstPaks.SelectedIndex == -1)
			{
				MessageBox.Show("Please choose a Math Pak", "Input Required");
			}
			else
			{
				AcademicGod.PageBankPath = this.pageBankNames[this.lstPaks.SelectedIndex];
				base.Close();
			}
		}

		// Token: 0x0400023D RID: 573
		private string[] pageBankNames;
	}
}
