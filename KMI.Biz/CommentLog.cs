using System;
using System.Collections;
using KMI.Sim;

namespace KMI.Biz
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class CommentLog : ActiveObject
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00004690 File Offset: 0x00003690
		public CommentLog(int frequencyInDays, int daysToKeep)
		{
			this.frequencyInDays = frequencyInDays;
			this.dayCounter = frequencyInDays;
			this.daysToKeep = daysToKeep;
			this.cache.Add(new Hashtable());
			this.startDate = Simulator.Instance.SimState.Now;
			Simulator.Instance.Subscribe(this, Simulator.TimePeriod.Day);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004708 File Offset: 0x00003708
		public void Comment(string category, string subCategory, string comment)
		{
			if (!S.I.BlockMessage(comment))
			{
				Hashtable hashtable = (Hashtable)this.cache[this.cache.Count - 1];
				Hashtable hashtable2;
				if (hashtable.Contains(category))
				{
					hashtable2 = (Hashtable)hashtable[category];
				}
				else
				{
					hashtable2 = new Hashtable();
					hashtable.Add(category, hashtable2);
				}
				Hashtable hashtable3;
				if (hashtable2.Contains(subCategory))
				{
					hashtable3 = (Hashtable)hashtable2[subCategory];
				}
				else
				{
					hashtable3 = new Hashtable();
					hashtable2.Add(subCategory, hashtable3);
				}
				if (hashtable3.Contains(comment))
				{
					hashtable3[comment] = (int)hashtable3[comment] + 1;
				}
				else
				{
					hashtable3.Add(comment, 1);
				}
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000047E8 File Offset: 0x000037E8
		public ArrayList Comments
		{
			get
			{
				return this.cache;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00004800 File Offset: 0x00003800
		public int DaysToKeep
		{
			get
			{
				return this.daysToKeep;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00004818 File Offset: 0x00003818
		public int FrequencyInDays
		{
			get
			{
				return this.frequencyInDays;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004830 File Offset: 0x00003830
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004848 File Offset: 0x00003848
		public override void NewDay()
		{
			if (this.dayCounter >= this.frequencyInDays)
			{
				this.dayCounter = 0;
				if (this.cache.Count > this.daysToKeep)
				{
					this.cache[this.cache.Count - this.daysToKeep - 1] = null;
				}
				this.cache.Add(new Hashtable());
			}
			this.dayCounter++;
		}

		// Token: 0x0400001C RID: 28
		private ArrayList cache = new ArrayList();

		// Token: 0x0400001D RID: 29
		private int frequencyInDays = 0;

		// Token: 0x0400001E RID: 30
		private int dayCounter = 0;

		// Token: 0x0400001F RID: 31
		private DateTime startDate;

		// Token: 0x04000020 RID: 32
		private int daysToKeep;

		// Token: 0x0200000C RID: 12
		public struct Input
		{
			// Token: 0x04000021 RID: 33
			public CommentLog log;

			// Token: 0x04000022 RID: 34
			public int frequencyInDays;
		}
	}
}
