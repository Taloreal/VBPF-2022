using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Check.
	/// </summary>
	// Token: 0x0200005D RID: 93
	[Serializable]
	public class Check
	{
		// Token: 0x0600027C RID: 636 RVA: 0x00028E7C File Offset: 0x00027E7C
		public Check(long accountNumber)
		{
			this.Date = A.ST.Now;
			this.ID = A.ST.GetNextID();
			this.AccountNumber = accountNumber;
		}

		// Token: 0x040002E6 RID: 742
		public string Payee;

		// Token: 0x040002E7 RID: 743
		public float Amount;

		// Token: 0x040002E8 RID: 744
		public DateTime Date;

		// Token: 0x040002E9 RID: 745
		public string Memo;

		// Token: 0x040002EA RID: 746
		protected bool cleared;

		// Token: 0x040002EB RID: 747
		public string Payor;

		// Token: 0x040002EC RID: 748
		public int Number;

		// Token: 0x040002ED RID: 749
		public long ID;

		// Token: 0x040002EE RID: 750
		public BankAccount ApplyToAccount;

		// Token: 0x040002EF RID: 751
		public long AccountNumber;

		// Token: 0x040002F0 RID: 752
		public string Signature;
	}
}
