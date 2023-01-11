using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for CheckRegisterEntry.
	/// </summary>
	// Token: 0x0200002C RID: 44
	[Serializable]
	public class CheckRegisterEntry
	{
		// Token: 0x06000144 RID: 324 RVA: 0x00013088 File Offset: 0x00012088
		public CheckRegisterEntry()
		{
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000130F8 File Offset: 0x000120F8
		public CheckRegisterEntry(Check c)
		{
			this.Number = c.Number.ToString();
			this.Date = c.Date.ToString("M/d/yy");
			this.Payment = c.Amount.ToString("N2");
			this.Description1 = c.Payee;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000131B0 File Offset: 0x000121B0
		public CheckRegisterEntry(string number, string date, string description1, string description2, string payment, string deposit, string balance1, string balance2)
		{
			this.Number = number;
			this.Date = date;
			this.Description1 = description1;
			this.Description2 = description2;
			this.Payment = payment;
			this.Deposit = deposit;
			this.Balance1 = balance1;
			this.Balance2 = balance2;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0001325C File Offset: 0x0001225C
		public bool IsEmpty()
		{
			return this.Number == "" && this.Date == "" && this.Description1 == "" && (this.Description2 == "" || this.Description2 == "^") && this.Payment == "" && this.Deposit == "" && this.Balance1 == "" && this.Balance2 == "";
		}

		// Token: 0x04000145 RID: 325
		public string Number = "";

		// Token: 0x04000146 RID: 326
		public string Date = "";

		// Token: 0x04000147 RID: 327
		public string Description1 = "";

		// Token: 0x04000148 RID: 328
		public string Description2 = "";

		// Token: 0x04000149 RID: 329
		public string Payment = "";

		// Token: 0x0400014A RID: 330
		public string Deposit = "";

		// Token: 0x0400014B RID: 331
		public string Balance1 = "";

		// Token: 0x0400014C RID: 332
		public string Balance2 = "";
	}
}
