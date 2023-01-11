using System;
using System.Collections;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000067 RID: 103
	[Serializable]
	public class SurveyResponse
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x0001B29F File Offset: 0x0001A29F
		public SurveyResponse(long respondantID)
		{
			this.respondantID = respondantID;
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0001B2BC File Offset: 0x0001A2BC
		public ArrayList Answers
		{
			get
			{
				return this.answers;
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0001B2D4 File Offset: 0x0001A2D4
		public void AddAnswer(int[] answer)
		{
			this.answers.Add(answer);
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0001B2E4 File Offset: 0x0001A2E4
		public long RespondantID
		{
			get
			{
				return this.respondantID;
			}
		}

		// Token: 0x04000268 RID: 616
		protected ArrayList answers = new ArrayList();

		// Token: 0x04000269 RID: 617
		protected long respondantID;
	}
}
