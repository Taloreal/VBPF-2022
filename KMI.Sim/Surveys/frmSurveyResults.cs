using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000005 RID: 5
	public partial class frmSurveyResults : Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000027BC File Offset: 0x000017BC
		public frmSurveyResults()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000027DC File Offset: 0x000017DC
		public frmSurveyResults(string playerName, string qualifyingQuestionResponse)
		{
			this.InitializeComponent();
			if (Survey.QualifyingQuestionShortName != null)
			{
				this.labQualifyingName.Visible = true;
				this.labQualifyingName.Text = Survey.QualifyingQuestionShortName + ":";
				this.cboQualifier.Visible = true;
				this.cboQualifier.Items.Add("{All}");
				this.cboQualifier.Items.AddRange(Survey.GetSurveyQuestionByName(Survey.QualifyingQuestionShortName).PossibleResponses);
				if (qualifyingQuestionResponse == null)
				{
					this.cboQualifier.SelectedIndex = 0;
				}
				else
				{
					this.cboQualifier.SelectedIndex = this.cboQualifier.FindString(qualifyingQuestionResponse);
				}
			}
			this.surveys = S.SA.getSurveys(playerName);
			this.kmiGraph1.Dock = DockStyle.Fill;
			foreach (object obj in this.surveys)
			{
				Survey survey = (Survey)obj;
				this.cboSurvey.Items.Add(survey.Date.ToShortDateString());
				survey.ClearSegmenters();
			}
			this.cboSurvey.SelectedIndex = this.cboSurvey.Items.Count - 1;
			if (this.surveys.Count == 0)
			{
				this.btnSegment.Enabled = false;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003480 File Offset: 0x00002480
		private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.survey = (Survey)this.surveys[this.cboSurvey.SelectedIndex];
			this.cboQuestion.Items.Clear();
			foreach (object obj in this.survey.SurveyQuestions)
			{
				SurveyQuestion surveyQuestion = (SurveyQuestion)obj;
				this.cboQuestion.Items.Add(surveyQuestion.Question);
			}
			this.cboQuestion.SelectedIndex = 0;
			this.cboQuestion_SelectedIndexChanged(new object(), new EventArgs());
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000354C File Offset: 0x0000254C
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003556 File Offset: 0x00002556
		protected virtual void cboQuestion_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.question = (SurveyQuestion)this.survey.SurveyQuestions[this.cboQuestion.SelectedIndex];
			this.UpdateGraph();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003588 File Offset: 0x00002588
		protected void UpdateGraph()
		{
			this.kmiGraph1.Title = this.question.Question;
			this.kmiGraph1.ShowPercentagesForHistograms = this.ShowPercentagesForHistograms;
			this.kmiGraph1.YAxisTitle = "# of " + Survey.SurveyableObjectName;
			if (this.kmiGraph1.ShowPercentagesForHistograms)
			{
				this.kmiGraph1.YAxisTitle = this.kmiGraph1.YAxisTitle.Replace("#", "%");
			}
			this.kmiGraph1.GraphType = 2;
			this.kmiGraph1.Legend = true;
			object[,] array;
			if (this.question.MultiEntity)
			{
				array = new object[this.survey.EntityNames.Length + 1, this.question.PossibleResponses.Length + 1];
				int i = 0;
				foreach (string text in this.survey.EntityNames)
				{
					array[++i, 0] = text;
				}
				if (this.segmented)
				{
					this.kmiGraph1.YAxisTitle = "# of Custs (in Segment)";
				}
			}
			else if (this.segmented)
			{
				if (Survey.ShowAllSurveyedWhenSegmented)
				{
					array = new object[3, this.question.PossibleResponses.Length + 1];
					array[1, 0] = "All Surveyed";
					array[2, 0] = "In Segment";
					this.kmiGraph1.GraphType = 3;
				}
				else
				{
					array = new object[2, this.question.PossibleResponses.Length + 1];
					array[1, 0] = "In Segment";
				}
			}
			else
			{
				array = new object[2, this.question.PossibleResponses.Length + 1];
				this.kmiGraph1.Legend = false;
			}
			for (int i = 1; i <= this.question.PossibleResponses.Length; i++)
			{
				array[0, i] = this.question.PossibleResponses[i - 1];
			}
			for (int i = 1; i <= array.GetUpperBound(0); i++)
			{
				for (int k = 1; k <= array.GetUpperBound(1); k++)
				{
					array[i, k] = 0;
				}
			}
			foreach (object obj in this.survey.Responses)
			{
				SurveyResponse surveyResponse = (SurveyResponse)obj;
				if (Survey.QualifyingQuestionShortName != null && this.cboQualifier.SelectedIndex > 0)
				{
					int i;
					for (i = 0; i < this.survey.SurveyQuestions.Count; i++)
					{
						if (((SurveyQuestion)this.survey.SurveyQuestions[i]).ShortName == Survey.QualifyingQuestionShortName)
						{
							break;
						}
					}
					int[] array2 = (int[])surveyResponse.Answers[i];
					if (array2[0] != this.cboQualifier.SelectedIndex - 1)
					{
						continue;
					}
				}
				int[] array3 = (int[])surveyResponse.Answers[this.cboQuestion.SelectedIndex];
				if (this.question.MultiEntity)
				{
					for (int k = 1; k <= this.survey.EntityNames.Length; k++)
					{
						int i = array3[k - 1] + 1;
						if (this.segmented)
						{
							if (this.survey.InAllSegments(surveyResponse))
							{
								array[k, i] = (int)array[k, i] + 1;
							}
						}
						else
						{
							array[k, i] = (int)array[k, i] + 1;
						}
					}
				}
				else
				{
					int i = array3[0] + 1;
					if (Survey.ShowAllSurveyedWhenSegmented)
					{
						array[1, i] = (int)array[1, i] + 1;
						if (this.segmented)
						{
							if (this.survey.InAllSegments(surveyResponse))
							{
								array[2, i] = (int)array[2, i] + 1;
							}
						}
					}
					else if (this.survey.InAllSegments(surveyResponse))
					{
						array[1, i] = (int)array[1, i] + 1;
					}
				}
			}
			this.kmiGraph1.Draw(array);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003AA4 File Offset: 0x00002AA4
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.kmiGraph1.PrintGraph();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003AB4 File Offset: 0x00002AB4
		private void btnSegment_Click(object sender, EventArgs e)
		{
			frmSurveySegment frmSurveySegment;
			if (this.SegmenterForm == null)
			{
				frmSurveySegment = new frmSurveySegment();
			}
			else
			{
				frmSurveySegment = this.SegmenterForm;
			}
			frmSurveySegment.Survey = this.survey;
			frmSurveySegment.ShowDialog();
			this.segmented = this.survey.Segmented;
			this.UpdateGraph();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003B0D File Offset: 0x00002B0D
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(frmSurveyResults.HelpTopic);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003B1B File Offset: 0x00002B1B
		private void panMain_Resize(object sender, EventArgs e)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003B20 File Offset: 0x00002B20
		private void cboQualifier_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cboSurvey.SelectedIndex > -1)
			{
				this.UpdateGraph();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00003B4C File Offset: 0x00002B4C
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00003B64 File Offset: 0x00002B64
		public frmSurveySegment SegmenterForm
		{
			get
			{
				return this.segmenterForm;
			}
			set
			{
				this.segmenterForm = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00003B70 File Offset: 0x00002B70
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00003B88 File Offset: 0x00002B88
		public bool ShowPercentagesForHistograms
		{
			get
			{
				return this.showPercentagesForHistograms;
			}
			set
			{
				this.showPercentagesForHistograms = value;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003B92 File Offset: 0x00002B92
		private void frmSurveyResults_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x04000021 RID: 33
		protected bool loaded;

		// Token: 0x04000022 RID: 34
		protected ArrayList surveys;

		// Token: 0x04000023 RID: 35
		protected Survey survey;

		// Token: 0x04000024 RID: 36
		protected SurveyQuestion question;

		// Token: 0x04000025 RID: 37
		protected bool segmented;

		// Token: 0x04000026 RID: 38
		protected frmSurveySegment segmenterForm;

		// Token: 0x04000027 RID: 39
		public static string HelpTopic = "Market Research";

		// Token: 0x04000028 RID: 40
		protected bool showPercentagesForHistograms = true;
	}
}
