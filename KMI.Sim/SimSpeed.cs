using System;

namespace KMI.Sim
{
	// Token: 0x0200007A RID: 122
	[Serializable]
	public class SimSpeed
	{
		// Token: 0x0600045A RID: 1114 RVA: 0x0001F5C6 File Offset: 0x0001E5C6
		public SimSpeed(int stepPeriod, int skipFactor)
		{
			this.StepPeriod = stepPeriod;
			this.SkipFactor = skipFactor;
		}

		// Token: 0x040002E1 RID: 737
		public int StepPeriod;

		// Token: 0x040002E2 RID: 738
		public int SkipFactor;
	}
}
