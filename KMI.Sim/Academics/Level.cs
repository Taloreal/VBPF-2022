using System;

namespace KMI.Sim.Academics
{
	// Token: 0x02000045 RID: 69
	[Serializable]
	public class Level
	{
		// Token: 0x040001A8 RID: 424
		public Page[] Pages = new Page[0];

		// Token: 0x040001A9 RID: 425
		public string[] Powers = new string[0];

		// Token: 0x040001AA RID: 426
		public float Goal;

		// Token: 0x040001AB RID: 427
		public string LevelIntroMessage = "";
	}
}
