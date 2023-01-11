using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace KMI.Utility
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class ResponseCurve
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000510C File Offset: 0x0000410C
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00005124 File Offset: 0x00004124
		public float Variance
		{
			get
			{
				return this.variance;
			}
			set
			{
				this.variance = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00005130 File Offset: 0x00004130
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00005148 File Offset: 0x00004148
		public PointF[] Points
		{
			get
			{
				return this.points;
			}
			set
			{
				this.points = value;
				for (int i = 0; i < this.points.Length; i++)
				{
					for (int j = 0; j < this.points.Length; j++)
					{
						if (i != j && this.points[i].X == this.points[j].X)
						{
							throw new Exception("Duplicate x values in response curve.");
						}
					}
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000051C8 File Offset: 0x000041C8
		public float Response(float input)
		{
			return this.Response(input, null);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000051E4 File Offset: 0x000041E4
		public float Response(float input, Random random)
		{
			float num = float.NegativeInfinity;
			for (int i = 0; i < this.points.Length; i++)
			{
				if (input < this.points[i].X)
				{
					if (i == 0)
					{
						num = this.points[i].Y;
					}
					else
					{
						num = this.points[i - 1].Y + (this.points[i].Y - this.points[i - 1].Y) * (input - this.points[i - 1].X) / (this.points[i].X - this.points[i - 1].X);
					}
					break;
				}
			}
			if (float.IsNegativeInfinity(num))
			{
				num = this.points[this.points.Length - 1].Y;
			}
			float result;
			if (random != null)
			{
				result = (float)((double)num + (random.NextDouble() - 0.5) * (double)this.Variance);
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005320 File Offset: 0x00004320
		public void ReadPointsFromFile(Assembly assembly, string resource)
		{
			Stream manifestResourceStream = assembly.GetManifestResourceStream(resource);
			StreamReader streamReader = new StreamReader(manifestResourceStream);
			ArrayList arrayList = new ArrayList();
			for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
			{
				string[] array = text.Split(new char[]
				{
					' ',
					'\t'
				}, 2);
				PointF pointF = new PointF(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]));
				arrayList.Add(pointF);
			}
			this.points = new PointF[arrayList.Count];
			for (int i = 0; i < this.points.Length; i++)
			{
				this.points[i] = (PointF)arrayList[i];
			}
		}

		// Token: 0x04000010 RID: 16
		protected float variance;

		// Token: 0x04000011 RID: 17
		protected PointF[] points;
	}
}
