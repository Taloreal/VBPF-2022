using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000029 RID: 41
	public partial class frmUpload : Form
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x0000E024 File Offset: 0x0000D024
		public frmUpload()
		{
			this.InitializeComponent();
			this.score = S.SA.getHumanScore(Journal.ScoreSeriesName);
			this.Cursor = Cursors.WaitCursor;
			this.labMsg.Text = "Checking for Internet connection ...";
			this.btnUpload.Enabled = false;
			this.timer1.Interval = 1000;
			this.timer1.Start();
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000E506 File Offset: 0x0000D506
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000E510 File Offset: 0x0000D510
		private void btnUpload_Click(object sender, EventArgs e)
		{
			if (this.txtTeamCode.Text == "")
			{
				MessageBox.Show("You must enter a team code. Please try again.");
			}
			else
			{
				WebRequest webRequest = WebRequest.Create("http://vbc.knowledgematters.com/cgi-bin/vbccybercgi20.exe");
				string postString = this.GetPostString();
				webRequest.Method = "POST";
				webRequest.ContentType = "application/x-www-form-urlencoded";
				webRequest.ContentLength = (long)postString.Length;
				StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
				streamWriter.Write(postString);
				streamWriter.Close();
				string webPage = Utilities.GetWebPage(webRequest, S.I.UserAdminSettings.ProxyAddress, S.I.UserAdminSettings.ProxyBypassList);
				if (webPage == "")
				{
					MessageBox.Show("Could not upload your score. Please recheck your connection to the Internet and click Upload on the File menu to upload your score.");
					base.Close();
				}
				else
				{
					if (webPage.IndexOf("VBCSuccess") == -1)
					{
						string str = "";
						int num = webPage.IndexOf("VBCFail");
						if (num > -1)
						{
							str = webPage.Substring(num + 7, webPage.Length - (num + 7));
						}
						MessageBox.Show("The upload failed. " + str);
					}
					else
					{
						MessageBox.Show("Your upload succeeded! Go to www.KnowledgeMatters.com to check out your results!");
					}
					base.Close();
				}
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000E668 File Offset: 0x0000D668
		private string GetPostString()
		{
			string text = S.ST.GUID.ToString().ToLower();
			text = text.Substring(text.Length - 12, 12);
			return string.Concat(new object[]
			{
				this.txtTeamCode.Text,
				"|",
				text,
				"|0|",
				this.score,
				"|",
				S.SS.StudentOrg
			});
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000E704 File Offset: 0x0000D704
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.timer1.Stop();
			this.Cursor = Cursors.WaitCursor;
			WebRequest r = WebRequest.Create("http://vbc.knowledgematters.com/vbccommon/vbctestpage.htm");
			string webPage = Utilities.GetWebPage(r, S.I.UserAdminSettings.ProxyAddress, S.I.UserAdminSettings.ProxyBypassList);
			this.Cursor = Cursors.Default;
			if (webPage == "")
			{
				MessageBox.Show("Could not connect to the Internet. Please connect to the Internet or click the blue link to try an alternative upload method.", "No Internet Connection");
			}
			else
			{
				this.btnUpload.Enabled = true;
			}
			this.labMsg.Text = "Your score is " + Utilities.FC(this.score, S.I.CurrencyConversion) + "!";
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000E7CC File Offset: 0x0000D7CC
		private void label2_Click(object sender, EventArgs e)
		{
			if (this.txtTeamCode.Text == "")
			{
				MessageBox.Show("Please enter your Team Code then try again.", Application.ProductName);
			}
			else
			{
				Form form = new frmUploadAlternative(this.GetPostString());
				form.ShowDialog(this);
			}
		}

		// Token: 0x04000115 RID: 277
		private float score;
	}
}
