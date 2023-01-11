using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkOfficeMgr.
	/// </summary>
	// Token: 0x02000054 RID: 84
	[Serializable]
	public class WorkOfficeMgr : WorkOfficeDesk
	{
		// Token: 0x0600023E RID: 574 RVA: 0x00025934 File Offset: 0x00024934
		public WorkOfficeMgr()
		{
			this.HourlyWage = 41f;
			this.WorkExperienceRequired.Add("IT Supervisor", 1f);
			this.AcademicExperienceRequired.Clear();
			this.AcademicExperienceRequired.Add("Bachelors Degree");
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00025990 File Offset: 0x00024990
		public override string Name()
		{
			return "Vice President IT";
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000259A8 File Offset: 0x000249A8
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for entire data entry operations including management of IT supervisor.");
		}
	}
}
