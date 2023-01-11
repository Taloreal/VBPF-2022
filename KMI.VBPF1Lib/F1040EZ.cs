using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for F1040EZ.
	/// </summary>
	// Token: 0x0200008F RID: 143
	[Serializable]
	public class F1040EZ : TaxReturn
	{
		// Token: 0x06000491 RID: 1169 RVA: 0x0003F39B File Offset: 0x0003E39B
		public F1040EZ(int year) : base(year)
		{
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0003F3A8 File Offset: 0x0003E3A8
		public static float ComputeTax(float amount, float[] dollarBrackets, float[] marginalRates)
		{
			float tax = 0f;
			for (int i = 0; i < marginalRates.Length; i++)
			{
				float cap = float.MaxValue;
				if (i + 1 < dollarBrackets.Length)
				{
					cap = dollarBrackets[i + 1];
				}
				float addTax = Math.Max(0f, Math.Min(cap - dollarBrackets[i], amount - dollarBrackets[i])) * marginalRates[i];
				tax += addTax;
			}
			return tax;
		}
	}
}
