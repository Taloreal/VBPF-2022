using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkOfficeSup.
	/// </summary>
	// Token: 0x02000080 RID: 128
	[Serializable]
	public class WorkDrugRep : WorkTravellingSalesman
	{
		// Token: 0x0600040F RID: 1039 RVA: 0x00037A0C File Offset: 0x00036A0C
		public WorkDrugRep()
		{
			this.HourlyWage = 30f;
			this.VisitBuildingIndex = 1;
			this.WorkExperienceRequired.Add("worker of any kind", 2f);
			this.AcademicExperienceRequired.Add("Associates Degree");
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00037A60 File Offset: 0x00036A60
		public override string Name()
		{
			return "Pharmaceutical Salesperson";
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00037A78 File Offset: 0x00036A78
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for presentation of new drugs to prescribing physicians.");
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00037A9C File Offset: 0x00036A9C
		public override string Description()
		{
			string d = base.Description();
			d = d.Replace("Hourly Pay: $30.00", "Commissions: $300-$1300/wk");
			return d + Environment.NewLine + "Car: Required, Mileage Reimbursed";
		}
	}
}
