using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.Sim.Queues
{
	// Token: 0x0200004B RID: 75
	public interface ISimQueueObject
	{
		// Token: 0x0600029E RID: 670
		Drawable GetDrawable();

		// Token: 0x0600029F RID: 671
		void ChangeActionState();

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002A0 RID: 672
		// (set) Token: 0x060002A1 RID: 673
		int X { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002A2 RID: 674
		// (set) Token: 0x060002A3 RID: 675
		int Y { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002A4 RID: 676
		// (set) Token: 0x060002A5 RID: 677
		Point Location { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002A6 RID: 678
		// (set) Token: 0x060002A7 RID: 679
		string BaseImageName { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002A8 RID: 680
		// (set) Token: 0x060002A9 RID: 681
		string Orientation { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002AA RID: 682
		// (set) Token: 0x060002AB RID: 683
		string ActionState { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002AC RID: 684
		// (set) Token: 0x060002AD RID: 685
		bool Waiting { get; set; }
	}
}
