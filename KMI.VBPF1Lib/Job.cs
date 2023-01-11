using System;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Job.
	/// </summary>
	// Token: 0x02000039 RID: 57
	[Serializable]
	public class Job : Offering
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0001B499 File Offset: 0x0001A499
		public Job()
		{
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0001B4AF File Offset: 0x0001A4AF
		public Job(AppBuilding building, Task task, int startPeriod, int endPeriod)
		{
			base.Building = building;
			this.PrototypeTask = task;
			this.PrototypeTask.StartPeriod = startPeriod;
			this.PrototypeTask.EndPeriod = endPeriod;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0001B4F0 File Offset: 0x0001A4F0
		public override string ThingName()
		{
			return A.R.GetString("Jobs");
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0001B514 File Offset: 0x0001A514
		public override string Description()
		{
			return this.PrototypeTask.Description();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0001B534 File Offset: 0x0001A534
		public override string ToString()
		{
			WorkTask task = (WorkTask)this.PrototypeTask;
			return task.Name();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0001B558 File Offset: 0x0001A558
		public override string JournalEntry()
		{
			return A.R.GetString("Got job as a {0}, paying {1} per week.", new object[]
			{
				this.ToString(),
				Utilities.FC(this.WeeklyPay, 2, A.I.CurrencyConversion)
			});
		}

		// Token: 0x040001CB RID: 459
		public float WeeklyPay = 200f;
	}
}
