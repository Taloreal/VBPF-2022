using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// ECO 5/14/09 Added with HRB refresh.
	/// Summary description for WorkInternetSup.
	/// </summary>
	// Token: 0x0200008C RID: 140
	[Serializable]
	public class WorkInternet2 : WorkInvisible
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x0003BA54 File Offset: 0x0003AA54
		public WorkInternet2()
		{
			this.HourlyWage = 18f;
			this.WorkExperienceRequired.Add("Data Entry Specialist|Web Designer", 2f);
			this.AcademicExperienceRequired.Clear();
			this.AcademicExperienceRequired.Add("Bachelors Degree");
			this.BonusPotential = 0.25f;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0003BAB8 File Offset: 0x0003AAB8
		public override string Name()
		{
			return "Software Engineer";
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0003BAD0 File Offset: 0x0003AAD0
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for a complete software engineering project.");
		}
	}
}
