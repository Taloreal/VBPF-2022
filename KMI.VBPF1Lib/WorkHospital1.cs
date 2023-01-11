using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000061 RID: 97
	[Serializable]
	public class WorkHospital1 : WorkInvisible
	{
		// Token: 0x06000287 RID: 647 RVA: 0x00029295 File Offset: 0x00028295
		public WorkHospital1()
		{
			this.HourlyWage = 25f;
			this.AcademicExperienceRequired.Add("Nursing Degree");
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000292BC File Offset: 0x000282BC
		public override string Name()
		{
			return "Nurse";
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000292D4 File Offset: 0x000282D4
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for assisting physicians in patient care.");
		}
	}
}
