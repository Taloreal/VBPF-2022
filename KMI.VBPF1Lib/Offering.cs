using System;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Offering.
	/// </summary>
	// Token: 0x02000015 RID: 21
	[Serializable]
	public abstract class Offering
	{
		// Token: 0x0600005C RID: 92 RVA: 0x000080D2 File Offset: 0x000070D2
		public Offering()
		{
			this.ID = A.ST.GetNextID();
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000080F0 File Offset: 0x000070F0
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00008117 File Offset: 0x00007117
		public AppBuilding Building
		{
			get
			{
				return A.ST.City.BuildingByID(this.buildingID);
			}
			set
			{
				this.buildingID = value.ID;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00008128 File Offset: 0x00007128
		public virtual string Description()
		{
			return null;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000813C File Offset: 0x0000713C
		public virtual string ThingName()
		{
			return null;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00008150 File Offset: 0x00007150
		public Task CreateTask()
		{
			Task t = (Task)Utilities.DeepCopyBySerialization(this.PrototypeTask);
			t.ID = A.ST.GetNextID();
			t.StartDate = A.ST.Now;
			return t;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00008194 File Offset: 0x00007194
		public virtual string JournalEntry()
		{
			return "";
		}

		// Token: 0x040000BF RID: 191
		public long ID;

		// Token: 0x040000C0 RID: 192
		protected long buildingID;

		// Token: 0x040000C1 RID: 193
		public Task PrototypeTask;

		// Token: 0x040000C2 RID: 194
		public bool Taken;
	}
}
