using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for TaxReturn.
	/// </summary>
	// Token: 0x02000083 RID: 131
	[Serializable]
	public class TaxReturn
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x00037D55 File Offset: 0x00036D55
		public TaxReturn(int year)
		{
			this.Year = year;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00037D84 File Offset: 0x00036D84
		public override string ToString()
		{
			return this.Year.ToString();
		}

		// Token: 0x04000480 RID: 1152
		public int Year;

		// Token: 0x04000481 RID: 1153
		public string FirstNameAndInitial;

		// Token: 0x04000482 RID: 1154
		public string LastName;

		// Token: 0x04000483 RID: 1155
		public string SSN;

		// Token: 0x04000484 RID: 1156
		public string HomeAddress;

		// Token: 0x04000485 RID: 1157
		public string HomeCityStateZip;

		// Token: 0x04000486 RID: 1158
		public DateTime FilingDate;

		// Token: 0x04000487 RID: 1159
		public string Occupation;

		// Token: 0x04000488 RID: 1160
		public string[] Lines = new string[30];

		// Token: 0x04000489 RID: 1161
		public int[] Values = new int[30];
	}
}
