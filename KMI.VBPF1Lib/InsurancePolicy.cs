using System;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for InsurancePolicy.
	/// </summary>
	// Token: 0x02000065 RID: 101
	[Serializable]
	public class InsurancePolicy
	{
		// Token: 0x06000293 RID: 659 RVA: 0x00029717 File Offset: 0x00028717
		public InsurancePolicy(float deductible, bool acv, float limit)
		{
			this.Deductible = deductible;
			this.ACV = acv;
			this.Limit = limit;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00029742 File Offset: 0x00028742
		public InsurancePolicy(float copay)
		{
			this.Copay = copay;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00029760 File Offset: 0x00028760
		public string PayOut(float replacementCost, float actualCashValue, GeneralLedger gl)
		{
			string msg = "";
			float payout;
			if (this.ACV)
			{
				float deductible = Math.Min(actualCashValue, this.Deductible);
				payout = actualCashValue - this.Deductible;
				msg += A.R.GetString("You have an actual cash value policy. The actual cash value of the property was {0}. Therefore, after subtracting your deductible, insurance will pay {1} .", new object[]
				{
					Utilities.FC(actualCashValue, A.I.CurrencyConversion),
					Utilities.FC(payout, A.I.CurrencyConversion)
				});
			}
			else
			{
				float deductible = Math.Min(replacementCost, this.Deductible);
				payout = replacementCost - this.Deductible;
				msg += A.R.GetString("You have a replacement cost policy. Therefore, after subtracting your deductible, insurance will pay {0}. ", new object[]
				{
					Utilities.FC(payout, A.I.CurrencyConversion)
				});
			}
			if (payout > this.Limit)
			{
				payout = this.Limit;
				msg += A.R.GetString("However, the coverage limit on your policy is {0}, so the insurance payout will only be {0}.", new object[]
				{
					Utilities.FC(payout, A.I.CurrencyConversion)
				});
			}
			float loss = replacementCost - payout;
			gl.Post("Loss from Fire", loss, "Cash");
			return msg;
		}

		// Token: 0x04000302 RID: 770
		public float Deductible;

		// Token: 0x04000303 RID: 771
		public bool ACV;

		// Token: 0x04000304 RID: 772
		public float Limit;

		// Token: 0x04000305 RID: 773
		public float MonthlyPremium;

		// Token: 0x04000306 RID: 774
		public float Copay = -1f;
	}
}
