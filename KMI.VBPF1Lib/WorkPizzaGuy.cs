using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkOfficeSup.
	/// </summary>
	// Token: 0x0200008B RID: 139
	[Serializable]
	public class WorkPizzaGuy : WorkTravellingSalesman
	{
		// Token: 0x06000446 RID: 1094 RVA: 0x0003B9BC File Offset: 0x0003A9BC
		public WorkPizzaGuy()
		{
			this.HourlyWage = 8f;
			this.VisitBuildingIndex = 1;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0003B9DC File Offset: 0x0003A9DC
		public override string Name()
		{
			return "Pizza Delivery Person";
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0003B9F4 File Offset: 0x0003A9F4
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for timely delivery of pizzas to customers throughout the city. Maintained own vehicle to perform job functions effectively.");
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0003BA18 File Offset: 0x0003AA18
		public override string Description()
		{
			string d = base.Description();
			d = d.Replace("Hourly Pay", "Hourly Pay w/ Tips");
			return d + Environment.NewLine + "Car: Required, Mileage Reimbursed";
		}
	}
}
