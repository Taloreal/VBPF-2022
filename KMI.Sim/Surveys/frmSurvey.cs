using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x0200007D RID: 125
	public partial class frmSurvey : Form
	{
		// Token: 0x06000467 RID: 1127 RVA: 0x0001FB0C File Offset: 0x0001EB0C
		public frmSurvey()
		{
			this.InitializeComponent();
			if (!Survey.BillForSurveys)
			{
				this.grpBoxCost.Visible = false;
				this.grpBoxNumber.Visible = false;
				base.Width -= this.grpBoxCost.Width;
				this.cmdOK.Left -= this.grpBoxCost.Width / 2;
				this.cmdCancel.Left -= this.grpBoxCost.Width / 2;
				this.cmdHelp.Left -= this.grpBoxCost.Width / 2;
			}
			for (int i = 0; i < Survey.PossibleSurveyQuestions.Length; i++)
			{
				if (i > 0)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Size = this.chkQuestion.Size;
					checkBox.Left = this.chkQuestion.Left;
					checkBox.Top = i * 20 + this.chkQuestion.Top;
					this.panel1.Controls.Add(checkBox);
					checkBox.Text = Survey.PossibleSurveyQuestions[i].Question;
					checkBox.CheckedChanged += this.chkQuestion_CheckedChanged;
				}
				else
				{
					this.chkQuestion.Text = Survey.PossibleSurveyQuestions[i].Question;
				}
			}
			this.labQuestions.Text = "Questions to Ask " + Survey.SurveyableObjectName;
			this.grpBoxNumber.Text = "Number of " + Survey.SurveyableObjectName + " to Survey";
			this.UpdateCosts();
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00020854 File Offset: 0x0001F854
		private void cmdOK_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList arrayList = new ArrayList();
				int num = 0;
				foreach (object obj in this.panel1.Controls)
				{
					CheckBox checkBox = (CheckBox)obj;
					if (checkBox.Checked)
					{
						arrayList.Add(Survey.PossibleSurveyQuestions[num]);
					}
					num++;
				}
				if (arrayList.Count == 0)
				{
					MessageBox.Show("You must ask at least one question in a survey. Please try again.", "No Question Checked");
				}
				else
				{
					Survey survey = S.SA.ConductAndAddSurvey(S.I.ThisPlayerName, S.MF.CurrentEntityID, arrayList, (int)this.updNumToSurvey.Value, this.totalCost);
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00020978 File Offset: 0x0001F978
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00020982 File Offset: 0x0001F982
		private void chkQuestion_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateCosts();
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0002098C File Offset: 0x0001F98C
		private void updNumToSurvey_ValueChanged(object sender, EventArgs e)
		{
			this.UpdateCosts();
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00020998 File Offset: 0x0001F998
		private void UpdateCosts()
		{
			int num = 0;
			foreach (object obj in this.panel1.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				if (checkBox.Checked)
				{
					num++;
				}
			}
			float num2 = Survey.RecruitingCostPerPerson * (float)this.updNumToSurvey.Value;
			float num3 = Survey.ExecutionCostPerQuestionPerPerson * (float)num * (float)this.updNumToSurvey.Value;
			this.totalCost = Survey.BaseCost + num2 + num3;
			this.labBaseCost.Text = Utilities.FC(Survey.BaseCost, S.I.CurrencyConversion);
			this.labRecruitingCosts.Text = Utilities.FC(num2, S.I.CurrencyConversion);
			this.labExecutionCosts.Text = Utilities.FC(num3, S.I.CurrencyConversion);
			this.labTotalCost.Text = Utilities.FC(this.totalCost, S.I.CurrencyConversion);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00020AD8 File Offset: 0x0001FAD8
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(frmSurvey.HelpTopic);
		}

		// Token: 0x04000302 RID: 770
		private float totalCost = 0f;

		// Token: 0x04000303 RID: 771
		public static string HelpTopic = "Market Research";
	}
}
