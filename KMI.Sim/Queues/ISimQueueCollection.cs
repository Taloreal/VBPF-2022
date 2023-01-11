using System;
using System.Collections;

namespace KMI.Sim.Queues
{
	// Token: 0x02000060 RID: 96
	public interface ISimQueueCollection
	{
		// Token: 0x0600039C RID: 924
		ArrayList GetDrawables();

		// Token: 0x0600039D RID: 925
		void Go();

		// Token: 0x0600039E RID: 926
		void Stop();

		// Token: 0x0600039F RID: 927
		void Clear();

		// Token: 0x060003A0 RID: 928
		bool NewStep();
	}
}
