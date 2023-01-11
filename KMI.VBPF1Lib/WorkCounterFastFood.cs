using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkCounterFastFood.
	/// </summary>
	// Token: 0x02000081 RID: 129
	[Serializable]
	public class WorkCounterFastFood : WorkTask
	{
		// Token: 0x06000413 RID: 1043 RVA: 0x00037AD8 File Offset: 0x00036AD8
		public WorkCounterFastFood(int register)
		{
			this.Register = register;
			this.HourlyWage = 7.25f;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00037AFC File Offset: 0x00036AFC
		public override bool Do()
		{
			switch (this.State)
			{
			case WorkCounterFastFood.States.Init:
				this.Owner.Pose = "FFWalk";
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Register" + this.Register).ToPoints();
				this.State = WorkCounterFastFood.States.MoveToRegister;
				break;
			case WorkCounterFastFood.States.MoveToRegister:
				if (this.Owner.Move())
				{
					this.Owner.Pose = "FFStandSW";
					this.State = WorkCounterFastFood.States.WaitForCust;
				}
				break;
			case WorkCounterFastFood.States.WaitForCust:
				if (A.ST.Period == this.EndPeriod)
				{
					this.State = WorkCounterFastFood.States.Exit;
					this.Owner.Pose = "FFWalk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "EntryPoint").ToPoints();
				}
				else if (((FastFoodStore)base.Building).CustomerReadyAtRegister(this.Register))
				{
					this.Owner.Pose = "FFTakeOrder";
					this.State = WorkCounterFastFood.States.TakeOrder;
					this.frame = 0;
				}
				break;
			case WorkCounterFastFood.States.TakeOrder:
				if (++this.frame >= 76 / (A.ST.SimulatedTimePerStep / 20000))
				{
					this.Owner.Pose = "FFStandSW";
					this.State = WorkCounterFastFood.States.WaitForCust;
					((FastFoodStore)base.Building).OrderIn[this.Register] = true;
				}
				break;
			case WorkCounterFastFood.States.Exit:
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				this.Owner.Pose = "StandNW";
				return true;
			}
			return false;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00037D08 File Offset: 0x00036D08
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = WorkCounterFastFood.States.Init;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00037D1C File Offset: 0x00036D1C
		public override string Name()
		{
			return "Cashier";
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00037D34 File Offset: 0x00036D34
		public override string ResumeDescription()
		{
			return A.R.GetString("Responsible for ringing up customer orders and handling customer payments. Maintained high customer service levels.");
		}

		// Token: 0x04000477 RID: 1143
		public int Register;

		// Token: 0x04000478 RID: 1144
		public int frame;

		// Token: 0x04000479 RID: 1145
		private WorkCounterFastFood.States State = WorkCounterFastFood.States.Init;

		// Token: 0x02000082 RID: 130
		private enum States
		{
			// Token: 0x0400047B RID: 1147
			Init,
			// Token: 0x0400047C RID: 1148
			MoveToRegister,
			// Token: 0x0400047D RID: 1149
			WaitForCust,
			// Token: 0x0400047E RID: 1150
			TakeOrder,
			// Token: 0x0400047F RID: 1151
			Exit
		}
	}
}
