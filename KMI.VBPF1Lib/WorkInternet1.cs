using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// ECO 5/14/09 Added with HRB refresh.
	/// Summary description for WorkInternetSup.
	/// </summary>
	// Token: 0x02000095 RID: 149
	[Serializable]
	public class WorkInternet1 : WorkInvisible
	{
		// Token: 0x060004AE RID: 1198 RVA: 0x000427DD File Offset: 0x000417DD
		public WorkInternet1()
		{
			this.HourlyWage = 8f;
			this.AcademicExperienceRequired.Clear();
			this.AcademicExperienceRequired.Add("Web Design");
			this.BonusPotential = 0.2f;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0004281C File Offset: 0x0004181C
		public override string Name()
		{
			return "Web Designer";
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00042834 File Offset: 0x00041834
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for website programming/design.");
		}
	}
}
