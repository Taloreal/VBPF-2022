using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class WorkHospital3 : WorkInvisible
	{
		// Token: 0x060001DF RID: 479 RVA: 0x0001D8E8 File Offset: 0x0001C8E8
		public WorkHospital3()
		{
			this.HourlyWage = 75f;
			this.AcademicExperienceRequired.Add("Medical Degree");
			this.WorkExperienceRequired.Add("Medical Resident", 3f);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0001D938 File Offset: 0x0001C938
		public override string Name()
		{
			return "Medical Doctor";
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0001D950 File Offset: 0x0001C950
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for all aspects of patient care.");
		}
	}
}
