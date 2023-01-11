using System;
using System.Drawing;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000079 RID: 121
	[Serializable]
	public class ShopFastFood : Task
	{
		// Token: 0x06000314 RID: 788 RVA: 0x00034826 File Offset: 0x00033826
		public ShopFastFood(VBPFPerson owner, FastFoodStore store)
		{
			this.Owner = owner;
			base.Building = store;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00034848 File Offset: 0x00033848
		public string side
		{
			get
			{
				string result;
				if (this.Register == 0)
				{
					result = "left";
				}
				else
				{
					result = "right";
				}
				return result;
			}
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00034878 File Offset: 0x00033878
		public override bool Do()
		{
			FastFoodStore store = (FastFoodStore)base.Building;
			switch (this.State)
			{
			case ShopFastFood.States.Init:
				store.Customers.Add(this.Owner);
				this.Register = store.SmallestOpenLine();
				this.Owner.Location = base.Building.Map.getNode("Enter" + this.side).Location;
				this.Owner.Path = base.Building.Map.findPath("Enter" + this.side, "Cashier" + this.side).ToPoints();
				this.OrderTaken = false;
				this.waitCounter = 0;
				this.State = ShopFastFood.States.ToCounter;
				break;
			case ShopFastFood.States.ToCounter:
				if (this.Move())
				{
					this.State = ShopFastFood.States.AtCounter;
					this.Owner.Pose = "Stand";
				}
				break;
			case ShopFastFood.States.AtCounter:
				if (store.OrderUp[this.Register])
				{
					this.Owner.Pose = "CarryFood";
					store.OrderUp[this.Register] = false;
					this.Owner.Path = base.Building.Map.findPath("Cashier" + this.side, "Exit" + this.side).ToPoints();
					this.State = ShopFastFood.States.FromCounter;
				}
				break;
			case ShopFastFood.States.FromCounter:
				if (this.Move())
				{
					((FastFoodStore)base.Building).Customers.Remove(this.Owner);
					this.State = ShopFastFood.States.Init;
					this.Owner.WakeupTime = this.Owner.WakeupTime.AddDays(1.0);
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00034A74 File Offset: 0x00033A74
		public bool Move()
		{
			if (this.State == ShopFastFood.States.ToCounter)
			{
				this.Owner.Pose = "Walk";
			}
			else
			{
				this.Owner.Pose = "CarryFood";
			}
			foreach (object obj in ((FastFoodStore)base.Building).Customers)
			{
				VBPFPerson c = (VBPFPerson)obj;
				ShopFastFood a = (ShopFastFood)c.Task;
				if (this.Owner.ID > c.ID && this.State == ShopFastFood.States.ToCounter && (a.State == ShopFastFood.States.AtCounter || a.State == ShopFastFood.States.ToCounter))
				{
					PointF nextLoc = new PointF(this.Owner.Location.X + this.Owner.DX, this.Owner.Location.Y + this.Owner.DY);
					if (Utilities.DistanceBetween(nextLoc, c.Location) < 20f)
					{
						this.Owner.Pose = "Stand";
						this.waitCounter++;
						return false;
					}
				}
			}
			return this.Owner.Move();
		}

		// Token: 0x040003F1 RID: 1009
		public ShopFastFood.States State = ShopFastFood.States.Init;

		// Token: 0x040003F2 RID: 1010
		public bool OrderTaken;

		// Token: 0x040003F3 RID: 1011
		public int Register;

		// Token: 0x040003F4 RID: 1012
		public int waitCounter;

		// Token: 0x0200007A RID: 122
		public enum States
		{
			// Token: 0x040003F6 RID: 1014
			Init,
			// Token: 0x040003F7 RID: 1015
			ToCounter,
			// Token: 0x040003F8 RID: 1016
			AtCounter,
			// Token: 0x040003F9 RID: 1017
			FromCounter
		}
	}
}
