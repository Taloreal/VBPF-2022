using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodStore.
	/// </summary>
	// Token: 0x0200005B RID: 91
	[Serializable]
	public class FastFoodStore : AppBuilding
	{
		// Token: 0x0600026F RID: 623 RVA: 0x00028244 File Offset: 0x00027244
		public FastFoodStore(CityBlock block, int lotIndex, BuildingType type, int busyness) : base(block, lotIndex, type)
		{
			this.Map = AppConstants.Work0Map;
			this.EntryPoint = this.Map.getNode("EntryPoint").Location;
			S.I.Subscribe(this, Simulator.TimePeriod.Step);
			S.I.Subscribe(this, Simulator.TimePeriod.Week);
			for (int i = 0; i < 10 * busyness; i++)
			{
				VBPFPerson p = new VBPFPerson();
				p.Task = new ShopFastFood(p, this);
				DateTime wakeup = A.ST.Now.AddHours((double)Utilities.GetNormalDistribution(12f, 9f, A.ST.Random));
				S.I.Subscribe(p, wakeup);
			}
			this.busyness = (float)busyness;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00028348 File Offset: 0x00027348
		public void AddGenericWorker(Task task)
		{
			VBPFPerson p = new VBPFPerson();
			p.Task = task;
			p.Task.Owner = p;
			p.Task.Building = this;
			p.Task.EndPeriod = -1;
			p.Location = this.Map.getNode("EntryPoint").Location;
			S.I.Subscribe(p, Simulator.TimePeriod.Step);
			this.Persons.Add(p);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000283C4 File Offset: 0x000273C4
		public override bool NewStep()
		{
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j <= this.foodstacks.GetUpperBound(1); j++)
				{
					if (this.foodstacks[i, j] < 1)
					{
						this.foodstacks[i, j] = 5;
					}
				}
			}
			return false;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0002842C File Offset: 0x0002742C
		public override void NewWeek()
		{
			if (A.SS.CloseSomeBusinesses && this.busyness < 2f && A.ST.Random.NextDouble() < 0.01)
			{
				this.Retire();
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0002847E File Offset: 0x0002747E
		public void TakeItem(int register)
		{
			this.foodstacks[register, A.ST.Random.Next(8)]--;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000284AC File Offset: 0x000274AC
		public override string GetBackgroundImage()
		{
			return "WorkBack";
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000284C4 File Offset: 0x000274C4
		public override ArrayList GetInsideDrawables()
		{
			ArrayList d = new ArrayList();
			ArrayList inside = new ArrayList();
			ArrayList outside = new ArrayList();
			foreach (object obj in this.Customers)
			{
				VBPFPerson c = (VBPFPerson)obj;
				if (c.Location.X - c.Location.Y * 2f > -380f)
				{
					inside.AddRange(c.GetDrawables());
				}
				else
				{
					outside.AddRange(c.GetDrawables());
				}
			}
			inside.Sort();
			outside.Sort();
			d.Add(new Drawable(this.Map.getNode("FoodWall0").Location, "FoodWall"));
			d.Add(new Drawable(this.Map.getNode("SodaMachine").Location, "SodaMachine"));
			d.Add(new Drawable(this.Map.getNode("FoodWall1").Location, "FoodWall"));
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j <= this.foodstacks.GetUpperBound(1); j++)
				{
					PointF loc = this.Map.getNode("FoodWall" + i).Location;
					for (int k = 0; k < this.foodstacks[i, j]; k++)
					{
						d.Add(new Drawable(new PointF(loc.X + 6f + (float)(12 * j) + (float)(2 * k), loc.Y + 44f + (float)(6 * j) - (float)(8 * k)), "FoodContainer" + j % 2));
					}
				}
			}
			d.Add(new Drawable(this.Map.getNode("FoodWallTopa").Location, "FoodWallTop"));
			d.Add(new Drawable(this.Map.getNode("FoodWallTopb").Location, "FoodWallTop"));
			d.Add(new Drawable(this.Map.getNode("TreeFastFooda").Location, "TreeFastFood"));
			d.Add(new Drawable(this.Map.getNode("TreeFastFoodb").Location, "TreeFastFood"));
			ArrayList workers = new ArrayList();
			foreach (object obj2 in this.Persons)
			{
				VBPFPerson p = (VBPFPerson)obj2;
				workers.AddRange(p.GetDrawables());
			}
			workers.Sort();
			d.AddRange(workers);
			d.Add(new Drawable(this.Map.getNode("CounterFastFood").Location, "CounterFastFood"));
			d.AddRange(inside);
			d.Add(new Drawable(this.Map.getNode("LeftGlass").Location, "LeftGlass"));
			d.Add(new Drawable(this.Map.getNode("RightGlass").Location, "RightGlass"));
			d.Add(new Drawable(this.Map.getNode("PlantsFrontLeft").Location, "PlantsFrontLeft"));
			d.Add(new Drawable(this.Map.getNode("PlantsFrontRight").Location, "PlantsFrontRight"));
			d.AddRange(outside);
			d.Add(new Drawable(this.Map.getNode("Bar").Location, "Bar"));
			return d;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00028910 File Offset: 0x00027910
		public bool CustomerReadyAtRegister(int register)
		{
			foreach (object obj in this.Customers)
			{
				VBPFPerson p = (VBPFPerson)obj;
				if (p.Task is ShopFastFood)
				{
					ShopFastFood task = (ShopFastFood)p.Task;
					if (task.State == ShopFastFood.States.AtCounter && !task.OrderTaken && task.Register == register)
					{
						task.OrderTaken = true;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000289D8 File Offset: 0x000279D8
		public int SmallestOpenLine()
		{
			bool[] counterManned = new bool[2];
			bool[] counterBacked = new bool[2];
			foreach (object obj in this.Persons)
			{
				VBPFPerson p = (VBPFPerson)obj;
				if (p.Task is WorkCounterFastFood)
				{
					counterManned[((WorkCounterFastFood)p.Task).Register] = true;
				}
				if (p.Task is WorkMgrFastFood)
				{
					counterBacked[((WorkMgrFastFood)p.Task).Register] = true;
				}
			}
			int result;
			if (!counterManned[0] || !counterBacked[0])
			{
				result = 1;
			}
			else if (!counterManned[1] || !counterBacked[1])
			{
				result = 0;
			}
			else
			{
				int[] line = new int[2];
				foreach (object obj2 in this.Customers)
				{
					VBPFPerson p = (VBPFPerson)obj2;
					if (p.Task is ShopFastFood)
					{
						line[((ShopFastFood)p.Task).Register]++;
					}
				}
				if (line[0] < line[1])
				{
					result = 0;
				}
				else
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00028B8C File Offset: 0x00027B8C
		public void StressOutWorkers(int register)
		{
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00028B90 File Offset: 0x00027B90
		public override void Retire()
		{
			base.Retire();
			foreach (object obj in this.Persons)
			{
				VBPFPerson p = (VBPFPerson)obj;
				if (p.Drone)
				{
					p.Retire();
				}
				else if (p.Task is WorkMgrFastFood || p.Task is WorkCounterFastFood)
				{
					p.Task.CleanUp();
				}
			}
			this.Persons.Clear();
			foreach (object obj2 in this.Customers)
			{
				VBPFPerson p = (VBPFPerson)obj2;
				p.Retire();
			}
			this.Customers.Clear();
			this.Closed = true;
			this.Offerings.Clear();
			foreach (object obj3 in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj3;
				ArrayList temp = new ArrayList(e.GetAllTasks());
				foreach (object obj4 in temp)
				{
					Task t = (Task)obj4;
					if (!(t is TravelTask) && t.Building == this)
					{
						A.SA.DeleteTask(e.ID, t.ID);
						e.Player.SendMessage(A.R.GetString("Trouble...You have lost your job as a {0} because the business closed due to lack of revenue.", new object[]
						{
							((WorkTask)t).Name()
						}), "", NotificationColor.Yellow);
					}
				}
			}
		}

		// Token: 0x040002DF RID: 735
		private const int MaxStack = 5;

		// Token: 0x040002E0 RID: 736
		private float busyness;

		// Token: 0x040002E1 RID: 737
		private int[,] foodstacks = new int[2, 8];

		// Token: 0x040002E2 RID: 738
		public bool[] OrderIn = new bool[2];

		// Token: 0x040002E3 RID: 739
		public bool[] OrderUp = new bool[2];

		// Token: 0x040002E4 RID: 740
		public ArrayList Customers = new ArrayList();

		// Token: 0x040002E5 RID: 741
		public bool Closed = false;
	}
}
