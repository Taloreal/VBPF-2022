using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000050 RID: 80
	[Serializable]
	public class Map
	{
		// Token: 0x060002F5 RID: 757 RVA: 0x00017830 File Offset: 0x00016830
		public ArrayList ShortestPath(Place begin, Place end, ref ArrayList speeds, ref float totalTime)
		{
			foreach (object obj in this.places)
			{
				Place place = (Place)obj;
				place.tempDistance = float.MaxValue;
				place.tempIsDead = false;
				place.tempNextLink = null;
				if (place == end)
				{
					place.tempDistance = 0f;
				}
			}
			Place place2 = null;
			foreach (object obj2 in this.places)
			{
				Place place = (Place)obj2;
				float num = float.MaxValue;
				foreach (object obj3 in this.places)
				{
					Place place3 = (Place)obj3;
					if (!place3.tempIsDead && place3.tempDistance < num)
					{
						place2 = place3;
						num = place3.tempDistance;
					}
				}
				foreach (object obj4 in place2.LinkedPlaces)
				{
					Place place4 = (Place)obj4;
					float num2 = place2.tempDistance + Utilities.DistanceBetweenIsometric(place2.Location, place4.Location) / Math.Min(place2.SpeedLimit, place4.SpeedLimit);
					if (place4.UnderConstruction)
					{
						num2 = float.MaxValue;
					}
					if (place4.tempDistance > num2)
					{
						place4.tempDistance = num2;
						place4.tempNextLink = place2;
					}
				}
				place2.tempIsDead = true;
			}
			totalTime = begin.tempDistance;
			ArrayList result;
			if (begin.tempDistance > 1.7014117E+38f)
			{
				result = null;
			}
			else
			{
				ArrayList arrayList = new ArrayList();
				speeds = new ArrayList();
				for (place2 = begin; place2 != null; place2 = place2.tempNextLink)
				{
					arrayList.Add(place2.Location);
					if (place2.tempNextLink != null)
					{
						float num3 = Math.Min(place2.SpeedLimit, place2.tempNextLink.SpeedLimit);
						speeds.Add(num3);
					}
				}
				result = arrayList;
			}
			return result;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00017B54 File Offset: 0x00016B54
		protected static float PathLength(ArrayList points)
		{
			float num = 0f;
			PointF p = PointF.Empty;
			foreach (object obj in points)
			{
				PointF pointF = (PointF)obj;
				if (!p.IsEmpty)
				{
					num += Utilities.DistanceBetweenIsometric(p, pointF);
				}
				p = pointF;
			}
			return num;
		}

		// Token: 0x040001DA RID: 474
		public ArrayList places = new ArrayList();
	}
}
