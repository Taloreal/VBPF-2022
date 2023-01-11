using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.Sim.Queues
{
	// Token: 0x0200004C RID: 76
	[Serializable]
	public class SimQueueObject : ISimQueueObject
	{
		// Token: 0x060002AE RID: 686 RVA: 0x00015494 File Offset: 0x00014494
		public SimQueueObject(string baseImageName)
		{
			this.location = new Point(int.MinValue, int.MinValue);
			this.baseImageName = baseImageName;
			this.orientation = "";
			this.actionState = "";
			this.waiting = true;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000154E4 File Offset: 0x000144E4
		public virtual Drawable GetDrawable()
		{
			return new Drawable(this.location, this.baseImageName + this.orientation + this.actionState);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00015518 File Offset: 0x00014518
		public virtual void ChangeActionState()
		{
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0001551C File Offset: 0x0001451C
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00015539 File Offset: 0x00014539
		public int X
		{
			get
			{
				return this.location.X;
			}
			set
			{
				this.location.X = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x0001554C File Offset: 0x0001454C
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x00015569 File Offset: 0x00014569
		public int Y
		{
			get
			{
				return this.location.Y;
			}
			set
			{
				this.location.Y = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x0001557C File Offset: 0x0001457C
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x00015594 File Offset: 0x00014594
		public Point Location
		{
			get
			{
				return this.location;
			}
			set
			{
				this.location = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x000155A0 File Offset: 0x000145A0
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x000155B8 File Offset: 0x000145B8
		public string BaseImageName
		{
			get
			{
				return this.baseImageName;
			}
			set
			{
				this.baseImageName = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x000155C4 File Offset: 0x000145C4
		// (set) Token: 0x060002BA RID: 698 RVA: 0x000155DC File Offset: 0x000145DC
		public string Orientation
		{
			get
			{
				return this.orientation;
			}
			set
			{
				this.orientation = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000155E8 File Offset: 0x000145E8
		// (set) Token: 0x060002BC RID: 700 RVA: 0x00015600 File Offset: 0x00014600
		public string ActionState
		{
			get
			{
				return this.actionState;
			}
			set
			{
				this.actionState = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002BD RID: 701 RVA: 0x0001560C File Offset: 0x0001460C
		// (set) Token: 0x060002BE RID: 702 RVA: 0x00015624 File Offset: 0x00014624
		public bool Waiting
		{
			get
			{
				return this.waiting;
			}
			set
			{
				this.waiting = value;
			}
		}

		// Token: 0x040001B9 RID: 441
		protected Point location;

		// Token: 0x040001BA RID: 442
		protected string baseImageName;

		// Token: 0x040001BB RID: 443
		protected string orientation;

		// Token: 0x040001BC RID: 444
		protected string actionState;

		// Token: 0x040001BD RID: 445
		protected bool waiting;
	}
}
