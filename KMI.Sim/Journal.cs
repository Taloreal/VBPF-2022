using System;
using System.Collections;

namespace KMI.Sim
{
	// Token: 0x02000051 RID: 81
	[Serializable]
	public class Journal
	{
		// Token: 0x060002F7 RID: 759 RVA: 0x00017BE4 File Offset: 0x00016BE4
		public Journal(string entityName, string[] numericDataSeriesNames, float daysPerPeriod)
		{
			this.entityName = entityName;
			this.numericDataSeriesNames = numericDataSeriesNames;
			for (int i = 0; i < numericDataSeriesNames.Length; i++)
			{
				this.numericDataSeries.Add(numericDataSeriesNames[i], new ArrayList());
			}
			this.daysPerPeriod = daysPerPeriod;
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00017C50 File Offset: 0x00016C50
		public string EntityName
		{
			get
			{
				return this.entityName;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00017C68 File Offset: 0x00016C68
		public string[] NumericDataSeriesNames
		{
			get
			{
				return this.numericDataSeriesNames;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00017C80 File Offset: 0x00016C80
		public ArrayList Entries
		{
			get
			{
				return this.entries;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00017C98 File Offset: 0x00016C98
		public float DaysPerPeriod
		{
			get
			{
				return this.daysPerPeriod;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00017CB0 File Offset: 0x00016CB0
		public int DataSeriesCount
		{
			get
			{
				return this.numericDataSeries.Count;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00017CD0 File Offset: 0x00016CD0
		public int Periods
		{
			get
			{
				return (this.numericDataSeries[this.numericDataSeriesNames[0]] as ArrayList).Count;
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00017D00 File Offset: 0x00016D00
		public void AddEntry(DateTime timeStamp, string description, FlagsAttribute flags)
		{
			if (!S.MF.DesignerMode)
			{
				JournalEntry journalEntry = new JournalEntry(timeStamp, this.entityName, description, flags);
				for (int i = this.entries.Count - 1; i >= -1; i--)
				{
					if (i == -1)
					{
						this.entries.Insert(0, journalEntry);
						break;
					}
					if (journalEntry.TimeStamp >= ((JournalEntry)this.entries[i]).TimeStamp)
					{
						this.entries.Insert(i + 1, journalEntry);
						break;
					}
				}
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00017DAB File Offset: 0x00016DAB
		public void AddEntry(string description, FlagsAttribute flags)
		{
			this.AddEntry(Simulator.Instance.SimState.Now, description, flags);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00017DC6 File Offset: 0x00016DC6
		public void AddEntry(DateTime timeStamp, string description)
		{
			this.AddEntry(timeStamp, description, new FlagsAttribute());
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00017DD7 File Offset: 0x00016DD7
		public void AddEntry(string description)
		{
			this.AddEntry(Simulator.Instance.SimState.Now, description, new FlagsAttribute());
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00017DF6 File Offset: 0x00016DF6
		public void AddNumericData(string seriesName, float amount)
		{
			((ArrayList)this.numericDataSeries[seriesName]).Add(amount);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00017E18 File Offset: 0x00016E18
		public ArrayList NumericDataSeries(string seriesName)
		{
			return (ArrayList)this.numericDataSeries[seriesName];
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00017E3C File Offset: 0x00016E3C
		public float NumericDataSeriesLastEntry(string seriesName)
		{
			ArrayList arrayList = (ArrayList)this.numericDataSeries[seriesName];
			float result;
			if (arrayList.Count == 0)
			{
				result = 0f;
			}
			else
			{
				result = (float)arrayList[arrayList.Count - 1];
			}
			return result;
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00017E8C File Offset: 0x00016E8C
		// (set) Token: 0x06000306 RID: 774 RVA: 0x00017EA3 File Offset: 0x00016EA3
		public static string ScoreSeriesName
		{
			get
			{
				return Journal.scoreSeriesName;
			}
			set
			{
				Journal.scoreSeriesName = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00017EAC File Offset: 0x00016EAC
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00017EC3 File Offset: 0x00016EC3
		public static string[] JournalNumericDataSeriesNames
		{
			get
			{
				return Journal.journalNumericDataSeriesNames;
			}
			set
			{
				Journal.journalNumericDataSeriesNames = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00017ECC File Offset: 0x00016ECC
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00017EE3 File Offset: 0x00016EE3
		public static string JournalSeriesName
		{
			get
			{
				return Journal.journalSeriesName;
			}
			set
			{
				Journal.journalSeriesName = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00017EEC File Offset: 0x00016EEC
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00017F03 File Offset: 0x00016F03
		public static int JournalDaysPerPeriod
		{
			get
			{
				return Journal.journalDaysPerPeriod;
			}
			set
			{
				Journal.journalDaysPerPeriod = value;
			}
		}

		// Token: 0x040001DB RID: 475
		protected Hashtable numericDataSeries = new Hashtable();

		// Token: 0x040001DC RID: 476
		protected string entityName;

		// Token: 0x040001DD RID: 477
		protected string[] numericDataSeriesNames;

		// Token: 0x040001DE RID: 478
		protected ArrayList entries = new ArrayList();

		// Token: 0x040001DF RID: 479
		protected float daysPerPeriod;

		// Token: 0x040001E0 RID: 480
		protected static string scoreSeriesName = "Cumulative Profit";

		// Token: 0x040001E1 RID: 481
		protected static string[] journalNumericDataSeriesNames = new string[]
		{
			"Profit",
			"Cumulative Profit"
		};

		// Token: 0x040001E2 RID: 482
		protected static string journalSeriesName = "Profit";

		// Token: 0x040001E3 RID: 483
		protected static int journalDaysPerPeriod = 7;
	}
}
