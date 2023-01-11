using System;

namespace KMI.Sim.Academics
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class Page
	{
		// Token: 0x040001F2 RID: 498
		public string Name;

		// Token: 0x040001F3 RID: 499
		public string Power;

		// Token: 0x040001F4 RID: 500
		public string BodyURL;

		// Token: 0x040001F5 RID: 501
		public float MinScore = float.MinValue;

		// Token: 0x040001F6 RID: 502
		public Question[] Questions;
	}
}
