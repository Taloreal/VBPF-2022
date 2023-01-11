using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Transaction.
	/// </summary>
	// Token: 0x020000AF RID: 175
	[Serializable]
	public class Transaction
	{
		// Token: 0x0600053B RID: 1339 RVA: 0x0004CC37 File Offset: 0x0004BC37
		public Transaction(float amount, Transaction.TranType type, string description)
		{
			this.Amount = (float)Math.Round((double)amount, 2);
			this.Type = type;
			this.Description = description;
			this.Date = A.ST.Now;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0004CC6F File Offset: 0x0004BC6F
		public Transaction(float amount, Transaction.TranType type, string description, DateTime date)
		{
			this.Amount = (float)Math.Round((double)amount, 2);
			this.Type = type;
			this.Description = description;
			this.Date = date;
		}

		// Token: 0x0400062B RID: 1579
		public float Amount;

		// Token: 0x0400062C RID: 1580
		public Transaction.TranType Type;

		// Token: 0x0400062D RID: 1581
		public string Description;

		// Token: 0x0400062E RID: 1582
		public DateTime Date;

		// Token: 0x020000B0 RID: 176
		public enum TranType
		{
			// Token: 0x04000630 RID: 1584
			Debit,
			// Token: 0x04000631 RID: 1585
			Credit
		}
	}
}
