using System;

namespace KMI.Sim.Academics
{
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class Question
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0001508C File Offset: 0x0001408C
		public bool Correct
		{
			get
			{
				foreach (string text in this.Answers)
				{
					if (string.Compare(text.Trim(), this.Answer.Trim(), true) == 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x040001A5 RID: 421
		public string Text;

		// Token: 0x040001A6 RID: 422
		public string[] Answers;

		// Token: 0x040001A7 RID: 423
		public string Answer = null;
	}
}
