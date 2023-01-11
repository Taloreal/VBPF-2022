using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000076 RID: 118
	public partial class frmLanguage : Form
	{
		// Token: 0x06000441 RID: 1089 RVA: 0x0001E6A8 File Offset: 0x0001D6A8
		public frmLanguage()
		{
			this.InitializeComponent();
			AppSettingsReader appSettingsReader = new AppSettingsReader();
			this.preferredLanguageCode = (string)appSettingsReader.GetValue("PreferredLanguageCode", typeof(string));
			this.languageNames = ((string)appSettingsReader.GetValue("SupportedLanguageNames", typeof(string))).Split(new char[]
			{
				'|'
			});
			this.languageCodes = ((string)appSettingsReader.GetValue("SupportedLanguageCodes", typeof(string))).Split(new char[]
			{
				'|'
			});
			this.lstLanguages.Items.Add("English");
			for (int i = 0; i < this.languageNames.Length; i++)
			{
				this.lstLanguages.Items.Add(this.languageNames[i]);
				if (this.preferredLanguageCode == this.languageCodes[i])
				{
					this.lstLanguages.SelectedIndex = this.lstLanguages.Items.Count - 1;
				}
			}
			if (this.lstLanguages.SelectedIndex == -1)
			{
				this.lstLanguages.SelectedIndex = 0;
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0001E9B4 File Offset: 0x0001D9B4
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0001E9C0 File Offset: 0x0001D9C0
		public int LanguageCount
		{
			get
			{
				int result;
				if (this.languageCodes[0] == "")
				{
					result = 0;
				}
				else
				{
					result = this.languageCodes.Length;
				}
				return result;
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0001E9F8 File Offset: 0x0001D9F8
		private void frmLanguage_Closed(object sender, EventArgs e)
		{
			if (this.lstLanguages.SelectedIndex > 0)
			{
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.languageCodes[this.lstLanguages.SelectedIndex - 1]);
			}
		}

		// Token: 0x040002CA RID: 714
		private string preferredLanguageCode;

		// Token: 0x040002CB RID: 715
		private string[] languageNames;

		// Token: 0x040002CC RID: 716
		private string[] languageCodes;
	}
}
