using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000042 RID: 66
	[Serializable]
	public class WorkInvisible : WorkTask
	{
		// Token: 0x060001DD RID: 477 RVA: 0x0001D850 File Offset: 0x0001C850
		public override bool Do()
		{
			switch (this.State)
			{
			case WorkInvisible.States.Init:
				if (!base.Building.Persons.Contains(this.Owner))
				{
					base.Building.Persons.Add(this.Owner);
				}
				this.State = WorkInvisible.States.Done;
				break;
			case WorkInvisible.States.Done:
				return A.ST.Period == this.EndPeriod;
			}
			return false;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0001D8D5 File Offset: 0x0001C8D5
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = WorkInvisible.States.Init;
		}

		// Token: 0x040001F8 RID: 504
		public WorkInvisible.States State = WorkInvisible.States.Init;

		// Token: 0x02000043 RID: 67
		public enum States
		{
			// Token: 0x040001FA RID: 506
			Init,
			// Token: 0x040001FB RID: 507
			Done
		}
	}
}
