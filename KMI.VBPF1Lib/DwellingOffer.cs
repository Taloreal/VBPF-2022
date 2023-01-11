using System;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for DwellingOffer.
	/// </summary>
	// Token: 0x02000034 RID: 52
	[Serializable]
	public class DwellingOffer : Offering
	{
		// Token: 0x06000199 RID: 409 RVA: 0x0001A820 File Offset: 0x00019820
		public override string ThingName()
		{
			return A.R.GetString("Housing");
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0001A844 File Offset: 0x00019844
		public override string Description()
		{
			string @string;
			if (this.Condo)
			{
				@string = A.R.GetString("One bedroom condo for sale! Priced to move at {0}.", new object[]
				{
					Utilities.FC((float)base.Building.Rent * A.ST.RealEstateIndex, A.I.CurrencyConversion)
				});
			}
			else
			{
				@string = A.R.GetString("One bedroom apartment. {0}/month. One year lease. Month-to-month after one year.", new object[]
				{
					Utilities.FC((float)base.Building.Rent, A.I.CurrencyConversion)
				});
			}
			return @string;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0001A8DC File Offset: 0x000198DC
		public override string JournalEntry()
		{
			string @string;
			if (this.Condo)
			{
				@string = A.R.GetString("Bought condo for {0}.", new object[]
				{
					Utilities.FC((float)base.Building.Rent * A.ST.RealEstateIndex, A.I.CurrencyConversion)
				});
			}
			else
			{
				@string = A.R.GetString("Leased apartment for {0} per month.", new object[]
				{
					Utilities.FC((float)base.Building.Rent, A.I.CurrencyConversion)
				});
			}
			return @string;
		}

		// Token: 0x040001B6 RID: 438
		public bool Condo = false;
	}
}
