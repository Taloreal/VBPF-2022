using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for TravelTask.
	/// </summary>
	// Token: 0x02000026 RID: 38
	[Serializable]
	public class TravelTask : Task
	{
		// Token: 0x06000132 RID: 306 RVA: 0x000123F0 File Offset: 0x000113F0
		public override Color GetColor()
		{
			return Color.Violet;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00012407 File Offset: 0x00011407
		public virtual int EstTimeInSteps(AppBuilding from, AppBuilding to)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00012410 File Offset: 0x00011410
		public static PointF DoorWayAt(int ave, int street, int lot)
		{
			return new PointF((float)ave - 0.25f * (float)(3 - lot), (float)street);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00012438 File Offset: 0x00011438
		public static TravelTask CreateTravelTask(int modeOfTransportation)
		{
			TravelTask taskNew;
			if (modeOfTransportation == 1)
			{
				taskNew = new TravelByBus();
			}
			else if (modeOfTransportation == 2)
			{
				taskNew = new TravelByCar();
			}
			else
			{
				taskNew = new TravelByFoot();
			}
			return taskNew;
		}

		// Token: 0x0400012C RID: 300
		public AppBuilding To;

		// Token: 0x0400012D RID: 301
		public AppBuilding From;
	}
}
