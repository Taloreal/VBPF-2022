using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000055 RID: 85
	[Serializable]
	public class WorkHospital2 : WorkInvisible
	{
		// Token: 0x06000241 RID: 577 RVA: 0x000259C9 File Offset: 0x000249C9
		public WorkHospital2()
		{
			this.HourlyWage = 12.5f;
			this.AcademicExperienceRequired.Add("Medical Degree");
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000259F0 File Offset: 0x000249F0
		public override string Name()
		{
			return "Medical Resident";
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00025A08 File Offset: 0x00024A08
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for patient care under supervision of attending physician.");
		}
	}
}
