using System;

namespace KMI.Sim.Surveys
{
	// Token: 0x0200007C RID: 124
	[Serializable]
	public class SurveySegmenter
	{
		// Token: 0x0600045F RID: 1119 RVA: 0x0001F9D4 File Offset: 0x0001E9D4
		public SurveySegmenter(int questionIndex, SurveyQuestion question, bool[] includesAnswer)
		{
			this.questionIndex = questionIndex;
			this.question = question;
			this.includesAnswer = includesAnswer;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0001F9F4 File Offset: 0x0001E9F4
		public SurveySegmenter(int questionIndex, SurveyQuestion question, bool[] includesAnswer, int entityIndex)
		{
			this.questionIndex = questionIndex;
			this.question = question;
			this.includesAnswer = includesAnswer;
			this.entityIndex = entityIndex;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0001FA1C File Offset: 0x0001EA1C
		public bool Excludes(SurveyResponse r)
		{
			int[] array = (int[])r.Answers[this.questionIndex];
			int num;
			if (this.question.MultiEntity)
			{
				num = array[this.entityIndex];
			}
			else
			{
				num = array[0];
			}
			return !this.includesAnswer[num];
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x0001FA78 File Offset: 0x0001EA78
		public bool AllChecked
		{
			get
			{
				bool[] array = this.includesAnswer;
				for (int i = 0; i < array.Length; i++)
				{
					if (!array[i])
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x0001FAB8 File Offset: 0x0001EAB8
		public SurveyQuestion Question
		{
			get
			{
				return this.question;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0001FAD0 File Offset: 0x0001EAD0
		public int EntityIndex
		{
			get
			{
				return this.entityIndex;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0001FAE8 File Offset: 0x0001EAE8
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0001FB00 File Offset: 0x0001EB00
		public bool[] IncludesAnswer
		{
			get
			{
				return this.includesAnswer;
			}
			set
			{
				this.includesAnswer = value;
			}
		}

		// Token: 0x040002EA RID: 746
		protected int questionIndex;

		// Token: 0x040002EB RID: 747
		protected SurveyQuestion question;

		// Token: 0x040002EC RID: 748
		protected int entityIndex;

		// Token: 0x040002ED RID: 749
		protected bool[] includesAnswer;
	}
}
