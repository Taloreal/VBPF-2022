using System;
using System.Collections;

namespace KMI.Utility
{
	// Token: 0x02000011 RID: 17
	[Serializable]
	public class PerformanceLog
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00006C11 File Offset: 0x00005C11
		public PerformanceLog()
		{
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006C2F File Offset: 0x00005C2F
		public PerformanceLog(int entriesToKeep)
		{
			this.entriesToKeep = entriesToKeep;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00006C54 File Offset: 0x00005C54
		public PerformanceLog(float initialValue)
		{
			for (int i = 0; i < this.entriesToKeep; i++)
			{
				this.AddEntry(initialValue);
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006C9C File Offset: 0x00005C9C
		public PerformanceLog(int entriesToKeep, float initialValue)
		{
			this.entriesToKeep = entriesToKeep;
			for (int i = 0; i < entriesToKeep; i++)
			{
				this.AddEntry(initialValue);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00006CE4 File Offset: 0x00005CE4
		public void AddEntry(float entry)
		{
			this.data.Add(entry);
			if (this.data.Count > this.entriesToKeep)
			{
				this.data.RemoveAt(0);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00006D2B File Offset: 0x00005D2B
		public void AddEntry(int entry)
		{
			this.AddEntry((float)entry);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006D38 File Offset: 0x00005D38
		public float GetAvg()
		{
			float result;
			if (this.IsEmpty)
			{
				result = 0f;
			}
			else
			{
				float num = 0f;
				foreach (object obj in this.data)
				{
					float num2 = (float)obj;
					num += num2;
				}
				result = num / (float)this.data.Count;
			}
			return result;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00006DD0 File Offset: 0x00005DD0
		public bool IsEmpty
		{
			get
			{
				return this.data.Count == 0;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006DF0 File Offset: 0x00005DF0
		public int NumberBelow(float level)
		{
			int num = 0;
			foreach (object obj in this.data)
			{
				float num2 = (float)obj;
				if (num2 < level)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00006E6C File Offset: 0x00005E6C
		public int Count
		{
			get
			{
				return this.data.Count;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00006E8C File Offset: 0x00005E8C
		public int MaxEntries
		{
			get
			{
				return this.entriesToKeep;
			}
		}

		// Token: 0x04000032 RID: 50
		protected ArrayList data = new ArrayList();

		// Token: 0x04000033 RID: 51
		protected int entriesToKeep = 10;
	}
}
