using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200006E RID: 110
	public partial class frmSetupWizard : Form
	{
		// Token: 0x06000403 RID: 1027 RVA: 0x0001CDB4 File Offset: 0x0001BDB4
		public frmSetupWizard(Type[] forms, object[] args, string[] titles, string[] text)
		{
			this.InitializeComponent();
			this.stepIndex = -1;
			this.currentType = null;
			this.formsToShow = forms;
			this.stepArgs = args;
			this.stepTitles = titles;
			this.stepText = text;
			this.stepArgTypes = new object[this.stepArgs.Length];
			int num = 0;
			foreach (object[] array2 in this.stepArgs)
			{
				ArrayList arrayList = new ArrayList();
				for (int j = 0; j < array2.Length; j++)
				{
					arrayList.Add(array2[j].GetType());
				}
				this.stepArgTypes[num++] = arrayList.ToArray(typeof(Type));
			}
			this.panTitles.Controls.Clear();
			for (int j = 0; j < this.stepTitles.Length; j++)
			{
				Label label = new Label();
				label.ForeColor = this.labTitle.ForeColor;
				label.Font = this.labTitle.Font;
				label.Location = new Point(this.labTitle.Left, this.labTitle.Top + j * 45);
				label.Size = this.labTitle.Size;
				label.Text = this.stepTitles[j];
				this.panTitles.Controls.Add(label);
			}
			this.UpdateWizard();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001D4D4 File Offset: 0x0001C4D4
		protected void UpdateWizard()
		{
			this.labText.Text = this.stepText[this.stepIndex + 1].Replace("\\n", "\n");
			if (this.stepIndex > -1 && this.stepIndex < this.panTitles.Controls.Count)
			{
				this.btnShow.Visible = true;
				this.btnShow.Text = "&Setup " + this.stepTitles[this.stepIndex];
			}
			else
			{
				this.btnShow.Visible = false;
			}
			this.btnBack.Enabled = (this.stepIndex > -1);
			this.btnNext.Enabled = (this.stepIndex < this.panTitles.Controls.Count);
			for (int i = 0; i < this.panTitles.Controls.Count; i++)
			{
				this.panTitles.Controls[i].ForeColor = Color.DarkBlue;
				if (i == this.stepIndex)
				{
					this.panTitles.Controls[i].ForeColor = Color.Yellow;
				}
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0001D620 File Offset: 0x0001C620
		private void btnShow_Click(object sender, EventArgs e)
		{
			ConstructorInfo constructor = this.formsToShow[this.stepIndex].GetConstructor((Type[])this.stepArgTypes[this.stepIndex]);
			object obj = constructor.Invoke((object[])this.stepArgs[this.stepIndex]);
			if (((Form)obj).ShowDialog() != DialogResult.Cancel)
			{
				this.stepIndex++;
				this.UpdateWizard();
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001D695 File Offset: 0x0001C695
		private void btnQuit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0001D69F File Offset: 0x0001C69F
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.stepIndex--;
			this.UpdateWizard();
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0001D6B7 File Offset: 0x0001C6B7
		private void btnNext_Click(object sender, EventArgs e)
		{
			this.stepIndex++;
			this.UpdateWizard();
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001D6CF File Offset: 0x0001C6CF
		private void btnFinish_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040002A9 RID: 681
		protected int stepIndex;

		// Token: 0x040002AA RID: 682
		protected Type currentType;

		// Token: 0x040002AB RID: 683
		protected Type[] formsToShow;

		// Token: 0x040002AF RID: 687
		protected string[] stepTitles;

		// Token: 0x040002B1 RID: 689
		protected string[] stepText;

		// Token: 0x040002B2 RID: 690
		protected object[] stepArgs;

		// Token: 0x040002B3 RID: 691
		protected object[] stepArgTypes;
	}
}
