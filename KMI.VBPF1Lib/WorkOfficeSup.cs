using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkOfficeSup.
	/// </summary>
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class WorkOfficeSup : WorkOfficeDesk
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00003558 File Offset: 0x00002558
		public WorkOfficeSup()
		{
			this.HourlyWage = 21f;
			this.WorkExperienceRequired.Add("Data Entry Specialist", 1f);
			this.AcademicExperienceRequired.Clear();
			this.AcademicExperienceRequired.Add("IT Management");
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000035B4 File Offset: 0x000025B4
		public override string Name()
		{
			return "IT Supervisor";
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000035CC File Offset: 0x000025CC
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for direct supervision of four data entry specialists.");
		}
	}
}
