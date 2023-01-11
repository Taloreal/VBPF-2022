using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000068 RID: 104
	public partial class frmSurveySegment : Form
	{
		// Token: 0x060003CB RID: 971 RVA: 0x0001B2FC File Offset: 0x0001A2FC
		public frmSurveySegment()
		{
			this.InitializeComponent();
			this.btnBuyMailingList.Visible = Survey.ShowBuyMailingList;
			this.labTotal.Text = "Total " + Survey.SurveyableObjectName + " in Survey";
		}

		// Token: 0x170000E3 RID: 227
		// (set) Token: 0x060003CE RID: 974 RVA: 0x0001BC58 File Offset: 0x0001AC58
		public Survey Survey
		{
			set
			{
				this.survey = value;
				this.survey = this.survey;
				this.cboQuestion.Items.Clear();
				foreach (object obj in this.survey.SurveyQuestions)
				{
					SurveyQuestion surveyQuestion = (SurveyQuestion)obj;
					if (surveyQuestion.ShortName != "live" && surveyQuestion.ShortName != "work" && surveyQuestion.ShortName != "lastmovie")
					{
						this.cboQuestion.Items.Add(surveyQuestion.Question);
					}
				}
				this.cboQuestion.SelectedIndex = 0;
				foreach (string item in this.survey.EntityNames)
				{
					this.cboEntity.Items.Add(item);
				}
				if (this.survey.EntityNames.Length > 0)
				{
					this.cboEntity.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001BDA8 File Offset: 0x0001ADA8
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.btnApply.PerformClick();
			base.Close();
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001BDBE File Offset: 0x0001ADBE
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001BDC8 File Offset: 0x0001ADC8
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.survey.ClearSegmenters();
			this.picCanvas.Refresh();
			this.cboQuestion_SelectedIndexChanged(new object(), new EventArgs());
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001BDF4 File Offset: 0x0001ADF4
		private void btnApply_Click(object sender, EventArgs e)
		{
			int num = 0;
			bool[] array = new bool[this.question.PossibleResponses.Length];
			foreach (object obj in this.panel1.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				array[num] = checkBox.Checked;
				num++;
			}
			if (this.question.MultiEntity)
			{
				this.survey.AddUpdateSegmenter(this.question, array, this.cboEntity.SelectedIndex);
			}
			else
			{
				this.survey.AddUpdateSegmenter(this.question, array);
			}
			this.picCanvas.Refresh();
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0001BED8 File Offset: 0x0001AED8
		private void picCanvas_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.Clear(this.picCanvas.BackColor);
			this.currentSegmentIDs = this.survey.DrawSegments(graphics, this.picCanvas.ClientRectangle);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0001BF1C File Offset: 0x0001AF1C
		private void cboQuestion_SelectedIndexChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.survey.SurveyQuestions.Count; i++)
			{
				this.question = (SurveyQuestion)this.survey.SurveyQuestions[i];
				if (this.question.Question == (string)this.cboQuestion.Items[this.cboQuestion.SelectedIndex])
				{
					break;
				}
			}
			this.cboEntity.Visible = this.question.MultiEntity;
			this.labEntity.Visible = this.question.MultiEntity;
			this.panel1.BorderStyle = BorderStyle.None;
			for (int i = this.panel1.Controls.Count - 1; i > 0; i--)
			{
				this.panel1.Controls.RemoveAt(i);
			}
			for (int i = 0; i < this.question.PossibleResponses.Length; i++)
			{
				SurveySegmenter segmenter;
				if (this.question.MultiEntity)
				{
					segmenter = this.survey.GetSegmenter(this.question, this.cboEntity.SelectedIndex);
				}
				else
				{
					segmenter = this.survey.GetSegmenter(this.question);
				}
				if (i > 0)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Size = this.chkAnswer.Size;
					checkBox.Left = this.chkAnswer.Left;
					checkBox.Top = i * 20 + this.chkAnswer.Top;
					this.panel1.Controls.Add(checkBox);
					checkBox.Text = this.question.PossibleResponses[i];
					if (segmenter != null)
					{
						checkBox.Checked = segmenter.IncludesAnswer[i];
					}
					else
					{
						checkBox.Checked = true;
					}
				}
				else
				{
					this.chkAnswer.Text = this.question.PossibleResponses[i];
					if (segmenter != null)
					{
						this.chkAnswer.Checked = segmenter.IncludesAnswer[i];
					}
					else
					{
						this.chkAnswer.Checked = true;
					}
				}
			}
			if (this.question.PossibleResponses.Length > 8)
			{
				this.panel1.BorderStyle = BorderStyle.Fixed3D;
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0001C185 File Offset: 0x0001B185
		private void cboEntity_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cboQuestion_SelectedIndexChanged(new object(), new EventArgs());
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001C199 File Offset: 0x0001B199
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(frmSurveySegment.HelpTopic);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001C1A7 File Offset: 0x0001B1A7
		private void btnBuyMailingList_Click(object sender, EventArgs e)
		{
			this.survey.BuyMailingListHook();
		}

		// Token: 0x0400027A RID: 634
		protected SurveyQuestion question;

		// Token: 0x0400027B RID: 635
		protected long[] currentSegmentIDs;

		// Token: 0x0400027C RID: 636
		protected Survey survey;

		// Token: 0x0400027D RID: 637
		public static string HelpTopic = "Market Research Example";
	}
}
