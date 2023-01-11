using System;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000046 RID: 70
	[Serializable]
	public class SurveyQuestion
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00015120 File Offset: 0x00014120
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00015138 File Offset: 0x00014138
		public string ShortName
		{
			get
			{
				return this.shortName;
			}
			set
			{
				this.shortName = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00015144 File Offset: 0x00014144
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0001515C File Offset: 0x0001415C
		public string Question
		{
			get
			{
				return this.question;
			}
			set
			{
				this.question = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00015168 File Offset: 0x00014168
		// (set) Token: 0x0600028A RID: 650 RVA: 0x000151BF File Offset: 0x000141BF
		public string[] PossibleResponses
		{
			get
			{
				string[] result;
				if (!this.answersAreEntities)
				{
					result = this.possibleResponses;
				}
				else
				{
					string[] array = new string[this.parent.EntityNames.Length + 1];
					array[0] = "None";
					this.parent.EntityNames.CopyTo(array, 1);
					result = array;
				}
				return result;
			}
			set
			{
				this.possibleResponses = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000151CC File Offset: 0x000141CC
		// (set) Token: 0x0600028C RID: 652 RVA: 0x000151E4 File Offset: 0x000141E4
		public bool MultiEntity
		{
			get
			{
				return this.multiEntity;
			}
			set
			{
				this.multiEntity = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000151F0 File Offset: 0x000141F0
		// (set) Token: 0x0600028E RID: 654 RVA: 0x00015208 File Offset: 0x00014208
		public bool AnswersAreEntities
		{
			get
			{
				return this.answersAreEntities;
			}
			set
			{
				this.answersAreEntities = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00015212 File Offset: 0x00014212
		public Survey Parent
		{
			set
			{
				this.parent = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0001521C File Offset: 0x0001421C
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00015234 File Offset: 0x00014234
		public string PossibleResponsesConcatenated
		{
			get
			{
				return this.possibleResponsesConcatenated;
			}
			set
			{
				this.possibleResponsesConcatenated = value;
			}
		}

		// Token: 0x040001AC RID: 428
		protected string shortName;

		// Token: 0x040001AD RID: 429
		protected string question;

		// Token: 0x040001AE RID: 430
		protected string[] possibleResponses;

		// Token: 0x040001AF RID: 431
		protected bool multiEntity;

		// Token: 0x040001B0 RID: 432
		protected bool answersAreEntities;

		// Token: 0x040001B1 RID: 433
		protected Survey parent;

		// Token: 0x040001B2 RID: 434
		protected string possibleResponsesConcatenated;
	}
}
