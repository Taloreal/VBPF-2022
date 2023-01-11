using System;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for WorkMgrFastFood.
	/// </summary>
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class WorkStoreMgrFastFood : WorkTask
	{
		// Token: 0x06000281 RID: 641 RVA: 0x00028F28 File Offset: 0x00027F28
		public WorkStoreMgrFastFood(int register)
		{
			this.Register = register;
			this.WorkExperienceRequired.Add("Shift Manager", 2f);
			this.HourlyWage = 22.5f;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00028F68 File Offset: 0x00027F68
		public override bool Do()
		{
			switch (this.State)
			{
			case WorkStoreMgrFastFood.States.Init:
				this.Owner.Pose = "FFWalk";
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Serve" + this.Register).ToPoints();
				this.State = WorkStoreMgrFastFood.States.MoveToServe;
				break;
			case WorkStoreMgrFastFood.States.MoveToServe:
				if (this.Owner.Move())
				{
					if (this.Owner.Pose == "FFCarryFood")
					{
						((FastFoodStore)base.Building).OrderUp[this.Register] = true;
					}
					this.Owner.Pose = "FFStandSW";
					this.State = WorkStoreMgrFastFood.States.WaitForOrder;
				}
				break;
			case WorkStoreMgrFastFood.States.WaitForOrder:
				if (A.ST.Period == this.EndPeriod)
				{
					this.State = WorkStoreMgrFastFood.States.Exit;
					this.Owner.Pose = "FFWalk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "EntryPoint").ToPoints();
				}
				else if (((FastFoodStore)base.Building).OrderIn[this.Register])
				{
					((FastFoodStore)base.Building).OrderIn[this.Register] = false;
					this.Owner.Pose = "FFWalk";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "ServeBack" + this.Register).ToPoints();
					this.State = WorkStoreMgrFastFood.States.GetOrder;
				}
				break;
			case WorkStoreMgrFastFood.States.GetOrder:
				if (this.Owner.Move())
				{
					this.Owner.Pose = "FFCarryFood";
					this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Serve" + this.Register).ToPoints();
					this.State = WorkStoreMgrFastFood.States.MoveToServe;
					((FastFoodStore)base.Building).TakeItem(this.Register);
				}
				break;
			case WorkStoreMgrFastFood.States.Exit:
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				this.Owner.Pose = "StandNW";
				return true;
			}
			return false;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00029228 File Offset: 0x00028228
		public override string CategoryName()
		{
			return A.R.GetString("Work");
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00029249 File Offset: 0x00028249
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = WorkStoreMgrFastFood.States.Init;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0002925C File Offset: 0x0002825C
		public override string Name()
		{
			return "Store Manager";
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00029274 File Offset: 0x00028274
		public override string ResumeDescription()
		{
			return A.R.GetString("Managed all facets of fast food restaurant operation.");
		}

		// Token: 0x040002F3 RID: 755
		public int Register;

		// Token: 0x040002F4 RID: 756
		private WorkStoreMgrFastFood.States State = WorkStoreMgrFastFood.States.Init;

		// Token: 0x02000060 RID: 96
		private enum States
		{
			// Token: 0x040002F6 RID: 758
			Init,
			// Token: 0x040002F7 RID: 759
			MoveToServe,
			// Token: 0x040002F8 RID: 760
			WaitForOrder,
			// Token: 0x040002F9 RID: 761
			GetOrder,
			// Token: 0x040002FA RID: 762
			Exit
		}
	}
}
