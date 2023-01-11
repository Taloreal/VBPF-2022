using System;

namespace KMI.Biz
{
	// Token: 0x02000009 RID: 9
	public class AmountNamePair
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00004399 File Offset: 0x00003399
		public AmountNamePair(float amount, string name)
		{
			this.Amount = amount;
			this.Name = name;
		}

		// Token: 0x04000015 RID: 21
		public float Amount;

		// Token: 0x04000016 RID: 22
		public string Name;
	}
}
