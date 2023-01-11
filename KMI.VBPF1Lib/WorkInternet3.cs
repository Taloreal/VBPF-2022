using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// ECO 5/14/09 Added with HRB refresh.
	/// Summary description for WorkInternetSup.
	/// </summary>
	// Token: 0x0200007F RID: 127
	[Serializable]
	public class WorkInternet3 : WorkInvisible
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x0003796C File Offset: 0x0003696C
		public WorkInternet3()
		{
			this.HourlyWage = 51f;
			this.WorkExperienceRequired.Add("Vice President IT|Software Engineer", 2f);
			this.AcademicExperienceRequired.Clear();
			this.AcademicExperienceRequired.Add("Bachelors Degree");
			this.BonusPotential = 0.3f;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000379D0 File Offset: 0x000369D0
		public override string Name()
		{
			return "VP of Engineering";
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000379E8 File Offset: 0x000369E8
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for overseeing multiple software projects and engineers.");
		}
	}
}
