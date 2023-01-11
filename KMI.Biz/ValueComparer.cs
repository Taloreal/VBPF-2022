using System;
using System.Collections;

namespace KMI.Biz
{
	// Token: 0x02000008 RID: 8
	public class ValueComparer : IComparer
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00004340 File Offset: 0x00003340
		public int Compare(object x, object y)
		{
			int result;
			if (((AmountNamePair)x).Amount < ((AmountNamePair)y).Amount)
			{
				result = 1;
			}
			else if (((AmountNamePair)x).Amount > ((AmountNamePair)y).Amount)
			{
				result = -1;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
