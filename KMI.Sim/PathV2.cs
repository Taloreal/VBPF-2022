using System;
using System.Collections;
using System.Drawing;

namespace KMI.Sim
{
	// Token: 0x02000047 RID: 71
	[Serializable]
	public class PathV2
	{
		// Token: 0x06000293 RID: 659 RVA: 0x00015254 File Offset: 0x00014254
		public ArrayList ToPoints()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 1; i < this.nodes.Count; i++)
			{
				PointF pointF = ((NodeV2)this.nodes[i]).Location;
				arrayList.Add(pointF);
			}
			return arrayList;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x000152B4 File Offset: 0x000142B4
		public ArrayList ToDistributedPoints()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 1; i < this.nodes.Count; i++)
			{
				PointF pointF = ((NodeV2)this.nodes[i]).DistributedLocation;
				arrayList.Add(pointF);
			}
			return arrayList;
		}

		// Token: 0x040001B3 RID: 435
		public ArrayList nodes = new ArrayList();
	}
}
