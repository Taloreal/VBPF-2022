using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for RecurringPayment.
	/// </summary>
	// Token: 0x02000075 RID: 117
	[Serializable]
	public class RecurringPayment
	{
		// Token: 0x040003D1 RID: 977
		public long PayeeAccountNumber;

		// Token: 0x040003D2 RID: 978
		public string PayeeName;

		// Token: 0x040003D3 RID: 979
		public float Amount;

		// Token: 0x040003D4 RID: 980
		public int Day;
	}
}
