using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x0200004F RID: 79
	[Serializable]
	public class Survey
	{
		// Token: 0x060002DD RID: 733 RVA: 0x00016EAC File Offset: 0x00015EAC
		public Survey()
		{
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00016ED0 File Offset: 0x00015ED0
		public Survey(long entityID, DateTime date, string[] entityNames, ArrayList surveyQuestions)
		{
			this.entityID = entityID;
			this.date = date;
			this.entityNames = entityNames;
			if (Survey.QualifyingQuestionShortName != null)
			{
				bool flag = false;
				foreach (object obj in surveyQuestions)
				{
					SurveyQuestion surveyQuestion = (SurveyQuestion)obj;
					if (surveyQuestion.ShortName == Survey.QualifyingQuestionShortName)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					surveyQuestions.Add(Survey.GetSurveyQuestionByName(Survey.QualifyingQuestionShortName));
				}
			}
			foreach (object obj2 in surveyQuestions)
			{
				SurveyQuestion surveyQuestion = (SurveyQuestion)obj2;
				surveyQuestion.Parent = this;
			}
			this.surveyQuestions = surveyQuestions;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00016FFC File Offset: 0x00015FFC
		public virtual void Execute(int numToSurvey)
		{
			throw new Exception("Survey.Execute not overridden.");
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0001700C File Offset: 0x0001600C
		public void AddUpdateSegmenter(SurveyQuestion question, bool[] includesAnswer)
		{
			SurveySegmenter surveySegmenter = this.GetSegmenter(question);
			if (surveySegmenter != null)
			{
				surveySegmenter.IncludesAnswer = includesAnswer;
			}
			else
			{
				surveySegmenter = new SurveySegmenter(this.QuestionIndex(question), question, includesAnswer);
				this.segmenters.Add(surveySegmenter);
			}
			if (surveySegmenter.AllChecked)
			{
				this.segmenters.Remove(surveySegmenter);
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0001706C File Offset: 0x0001606C
		public void AddUpdateSegmenter(SurveyQuestion question, bool[] includesAnswer, int entityIndex)
		{
			SurveySegmenter surveySegmenter = this.GetSegmenter(question, entityIndex);
			if (surveySegmenter != null)
			{
				surveySegmenter.IncludesAnswer = includesAnswer;
			}
			else
			{
				surveySegmenter = new SurveySegmenter(this.QuestionIndex(question), question, includesAnswer, entityIndex);
				this.segmenters.Add(surveySegmenter);
			}
			if (surveySegmenter.AllChecked)
			{
				this.segmenters.Remove(surveySegmenter);
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000170D0 File Offset: 0x000160D0
		private int QuestionIndex(SurveyQuestion question)
		{
			for (int i = 0; i < this.surveyQuestions.Count; i++)
			{
				if (this.surveyQuestions[i] == question)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00017117 File Offset: 0x00016117
		public void ClearSegmenters()
		{
			this.segmenters = new ArrayList();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00017128 File Offset: 0x00016128
		public SurveySegmenter GetSegmenter(SurveyQuestion question)
		{
			foreach (object obj in this.segmenters)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)obj;
				if (surveySegmenter.Question == question)
				{
					return surveySegmenter;
				}
			}
			return null;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000171A4 File Offset: 0x000161A4
		public SurveySegmenter GetSegmenter(SurveyQuestion question, int entityIndex)
		{
			foreach (object obj in this.segmenters)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)obj;
				if (surveySegmenter.Question == question && surveySegmenter.EntityIndex == entityIndex)
				{
					return surveySegmenter;
				}
			}
			return null;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0001722C File Offset: 0x0001622C
		public bool InAllSegments(SurveyResponse r)
		{
			foreach (object obj in this.segmenters)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)obj;
				if (surveySegmenter.Excludes(r))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000172A8 File Offset: 0x000162A8
		public long[] DrawSegments(Graphics g, Rectangle box)
		{
			ArrayList segs = (ArrayList)this.segmenters.Clone();
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.responses)
			{
				SurveyResponse value = (SurveyResponse)obj;
				arrayList.Add(value);
			}
			return this.DrawSubSegments(segs, arrayList, false, g, box);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00017340 File Offset: 0x00016340
		private long[] DrawSubSegments(ArrayList segs, ArrayList resps, bool vertical, Graphics g, Rectangle box)
		{
			Rectangle rectangle = box;
			Rectangle rectangle2 = box;
			string text = "";
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			float num;
			if (segs.Count > 0)
			{
				SurveySegmenter surveySegmenter = (SurveySegmenter)segs[0];
				segs.Remove(surveySegmenter);
				text = surveySegmenter.Question.Question;
				if (surveySegmenter.Question.MultiEntity)
				{
					text = text + " - " + this.entityNames[surveySegmenter.EntityIndex];
				}
				int count = resps.Count;
				for (int i = resps.Count - 1; i >= 0; i--)
				{
					if (surveySegmenter.Excludes((SurveyResponse)resps[i]))
					{
						resps.RemoveAt(i);
					}
				}
				num = 1f - (float)resps.Count / (float)count;
			}
			else
			{
				num = 0f;
			}
			if (vertical)
			{
				rectangle.Height = (int)((float)rectangle.Height * num);
				rectangle2.Y = rectangle.Y + rectangle.Height;
				rectangle2.Height -= rectangle.Height;
			}
			else
			{
				rectangle.Width = (int)((float)rectangle.Width * num);
				rectangle2.X = rectangle.X + rectangle.Width;
				rectangle2.Width -= rectangle.Width;
			}
			if (rectangle.Height > 0 && rectangle.Width > 0)
			{
				g.FillRectangle(new SolidBrush(Color.LightGray), rectangle);
				g.DrawRectangle(new Pen(Color.Black, 1f), rectangle);
				g.DrawString(text, new Font("Arial", 8f), new SolidBrush(Color.Black), rectangle, stringFormat);
			}
			if (rectangle2.Height > 0 && rectangle2.Width > 0)
			{
				g.DrawString(resps.Count.ToString() + " left in segment", new Font("Arial", 10f, FontStyle.Bold), new SolidBrush(Color.White), rectangle2, stringFormat);
			}
			long[] result;
			if (segs.Count > 0)
			{
				result = this.DrawSubSegments(segs, resps, !vertical, g, rectangle2);
			}
			else
			{
				long[] array = new long[resps.Count];
				for (int i = 0; i < resps.Count; i++)
				{
					array[i] = ((SurveyResponse)resps[i]).RespondantID;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00017620 File Offset: 0x00016620
		public long EntityID
		{
			get
			{
				return this.entityID;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00017638 File Offset: 0x00016638
		public DateTime Date
		{
			get
			{
				return this.date;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00017650 File Offset: 0x00016650
		public string[] EntityNames
		{
			get
			{
				return this.entityNames;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00017668 File Offset: 0x00016668
		public ArrayList SurveyQuestions
		{
			get
			{
				return this.surveyQuestions;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00017680 File Offset: 0x00016680
		public ArrayList Responses
		{
			get
			{
				return this.responses;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00017698 File Offset: 0x00016698
		public bool Segmented
		{
			get
			{
				return this.segmenters.Count > 0;
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000176B8 File Offset: 0x000166B8
		public int SurveyIndexOfEntity(string name)
		{
			int result = -1;
			for (int i = 0; i < this.EntityNames.Length; i++)
			{
				if (this.EntityNames[i] == name)
				{
					result = i;
				}
			}
			return result;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000176FC File Offset: 0x000166FC
		public static SurveyQuestion GetSurveyQuestionByName(string shortName)
		{
			foreach (SurveyQuestion surveyQuestion in Survey.PossibleSurveyQuestions)
			{
				if (surveyQuestion.ShortName == shortName)
				{
					return surveyQuestion;
				}
			}
			return null;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00017748 File Offset: 0x00016748
		public static void LoadQuestionsFromTable(Type type, string resource)
		{
			Survey.PossibleSurveyQuestions = (SurveyQuestion[])TableReader.Read(type.Assembly, typeof(SurveyQuestion), resource);
			foreach (SurveyQuestion surveyQuestion in Survey.PossibleSurveyQuestions)
			{
				surveyQuestion.PossibleResponses = surveyQuestion.PossibleResponsesConcatenated.Split(new char[]
				{
					'|'
				});
				surveyQuestion.PossibleResponsesConcatenated = null;
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000177BE File Offset: 0x000167BE
		public virtual void BuyMailingListHook()
		{
			throw new NotImplementedException("Survey has ShowBuyMailingList on without implementing BuyMailingListHook.");
		}

		// Token: 0x040001CA RID: 458
		protected long entityID;

		// Token: 0x040001CB RID: 459
		protected DateTime date;

		// Token: 0x040001CC RID: 460
		protected string[] entityNames;

		// Token: 0x040001CD RID: 461
		protected ArrayList surveyQuestions;

		// Token: 0x040001CE RID: 462
		protected ArrayList responses = new ArrayList();

		// Token: 0x040001CF RID: 463
		public static int MaxSurveys = 5;

		// Token: 0x040001D0 RID: 464
		public static float BaseCost = 500f;

		// Token: 0x040001D1 RID: 465
		public static float RecruitingCostPerPerson = 2f;

		// Token: 0x040001D2 RID: 466
		public static float ExecutionCostPerQuestionPerPerson = 0.25f;

		// Token: 0x040001D3 RID: 467
		public static string SurveyableObjectName = "Respondents";

		// Token: 0x040001D4 RID: 468
		public static SurveyQuestion[] PossibleSurveyQuestions;

		// Token: 0x040001D5 RID: 469
		public static string QualifyingQuestionShortName;

		// Token: 0x040001D6 RID: 470
		public static bool BillForSurveys = true;

		// Token: 0x040001D7 RID: 471
		public static bool ShowAllSurveyedWhenSegmented = false;

		// Token: 0x040001D8 RID: 472
		public static bool ShowBuyMailingList = false;

		// Token: 0x040001D9 RID: 473
		protected ArrayList segmenters = new ArrayList();
	}
}
