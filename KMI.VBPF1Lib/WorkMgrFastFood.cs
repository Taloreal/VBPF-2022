using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkMgrFastFood.
	/// </summary>
	// Token: 0x02000093 RID: 147
	[Serializable]
	public class WorkMgrFastFood : WorkTask
	{
		// Token: 0x060004A8 RID: 1192 RVA: 0x00042454 File Offset: 0x00041454
		public WorkMgrFastFood(int register)
		{
			this.Register = register;
			this.WorkExperienceRequired.Add("Cashier", 1f);
			this.AcademicExperienceRequired.Add("Food Service Mgt I");
			this.HourlyWage = 9.5f;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000424B0 File Offset: 0x000414B0
		public override bool Do()
		{
			switch (this.State)
			{
			case WorkMgrFastFood.States.Init:
				this.Owner.Pose = "FFWalk";
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Serve" + this.Register).ToPoints();
				this.State = WorkMgrFastFood.States.MoveToServe;
				break;
			case WorkMgrFastFood.States.MoveToServe:
				if (this.Owner.Move())
				{
					if (this.Owner.Pose == "FFCarryFood")
					{
						((FastFoodStore)base.Building).OrderUp[this.Register] = true;
					}
					this.Owner.Pose = "FFStandSW";
					this.State = WorkMgrFastFood.States.WaitForOrder;
				}
				break;
			case WorkMgrFastFood.States.WaitForOrder:
				if (A.ST.Period == this.EndPeriod)
				{
					this.State = WorkMgrFastFood.States.Exit;
					this.Owner.Pose = "FFWalk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "EntryPoint").ToPoints();
				}
				else if (((FastFoodStore)base.Building).OrderIn[this.Register])
				{
					((FastFoodStore)base.Building).OrderIn[this.Register] = false;
					this.Owner.Pose = "FFWalk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "ServeBack" + this.Register).ToPoints();
					this.State = WorkMgrFastFood.States.GetOrder;
				}
				break;
			case WorkMgrFastFood.States.GetOrder:
				if (this.Owner.Move())
				{
					this.Owner.Pose = "FFCarryFood";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Serve" + this.Register).ToPoints();
					this.State = WorkMgrFastFood.States.MoveToServe;
					((FastFoodStore)base.Building).TakeItem(this.Register);
				}
				break;
			case WorkMgrFastFood.States.Exit:
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				this.Owner.Pose = "StandNW";
				return true;
			}
			return false;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00042770 File Offset: 0x00041770
		public override string CategoryName()
		{
			return A.R.GetString("Work");
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00042791 File Offset: 0x00041791
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = WorkMgrFastFood.States.Init;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x000427A4 File Offset: 0x000417A4
		public override string Name()
		{
			return "Shift Manager";
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x000427BC File Offset: 0x000417BC
		public override string ResumeDescription()
		{
			return A.R.GetString("Supervised counter personnel ensuring consistently high customer satisfaction levels.");
		}

		// Token: 0x04000576 RID: 1398
		public int Register;

		// Token: 0x04000577 RID: 1399
		private WorkMgrFastFood.States State = WorkMgrFastFood.States.Init;

		// Token: 0x02000094 RID: 148
		private enum States
		{
			// Token: 0x04000579 RID: 1401
			Init,
			// Token: 0x0400057A RID: 1402
			MoveToServe,
			// Token: 0x0400057B RID: 1403
			WaitForOrder,
			// Token: 0x0400057C RID: 1404
			GetOrder,
			// Token: 0x0400057D RID: 1405
			Exit
		}
	}
}
