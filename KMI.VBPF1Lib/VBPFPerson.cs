using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for VBPFPerson.
	/// </summary>
	// Token: 0x020000AE RID: 174
	[Serializable]
	public class VBPFPerson : TurboMovableActiveObject
	{
		// Token: 0x06000536 RID: 1334 RVA: 0x0004C650 File Offset: 0x0004B650
		public VBPFPerson()
		{
			base.Speed = 20f;
			this.ID = A.ST.GetNextID();
			this.PaletteIndex = A.ST.Random.Next(6);
			this.GenderString = "Female";
			if (A.ST.Random.Next(2) == 0)
			{
				this.GenderString = "Male";
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0004C6D4 File Offset: 0x0004B6D4
		public VBPFPerson(Person.GenderType gender, Person.RaceType race, string firstName, string lastName)
		{
			base.Speed = 16f;
			this.ID = A.ST.GetNextID();
			this.PaletteIndex = A.ST.Random.Next(6);
			this.GenderString = "Female";
			if (gender == Person.GenderType.Male)
			{
				this.GenderString = "Male";
			}
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0004C748 File Offset: 0x0004B748
		public ArrayList GetDrawables()
		{
			string clickString = "";
			if (this.Task != null && !this.Drone)
			{
				if (this.Task is AttendClass)
				{
					AttendClass at = (AttendClass)this.Task;
					int daysPerWeek = 5;
					if (at.Weekend)
					{
						daysPerWeek = 2;
					}
					clickString = A.R.GetString("I'm tired of sitting in {0}. I've completed {1} weeks and have {2} weeks to go. Boy will I be glad when I'm done!", new object[]
					{
						at.Course.Name,
						at.daysInCourse / daysPerWeek,
						(at.Course.Days - at.daysInCourse) / daysPerWeek
					});
				}
				if (this.Task is WorkTask)
				{
					WorkTask wt = (WorkTask)this.Task;
					clickString = A.R.GetString("I'm working away here as a {0}. I've got {1} months of experience which should help me advance some day!", new object[]
					{
						wt.Name(),
						(A.ST.Now - wt.StartDate).Days / 30
					});
				}
			}
			ArrayList d = new ArrayList();
			string frame = "";
			string orientation = base.Orientation();
			if (this.Pose.EndsWith("SE") || this.Pose.EndsWith("NE") || this.Pose.EndsWith("SW") || this.Pose.EndsWith("NW"))
			{
				orientation = "";
			}
			if (this.Pose.EndsWith("Walk") || this.Pose.EndsWith("CarryFood"))
			{
				frame = "00" + 2 * A.ST.FrameCounter % 10;
			}
			if (this.Pose.EndsWith("JumpingJacksSW"))
			{
				frame = "00" + A.ST.FrameCounter % 9;
			}
			if (this.Pose.EndsWith("DanceSW") || this.Pose.EndsWith("DanceSE"))
			{
				frame = (((long)(2 * A.ST.FrameCounter) + this.ID) % 27L).ToString().PadLeft(3, '0');
				if (this.GetHashCode() % 2 == 0)
				{
					this.Pose = this.Pose.Replace("SW", "SE");
				}
			}
			if (this.Pose.EndsWith("EatSE"))
			{
				frame = "00" + A.ST.FrameCounter % 10;
			}
			if (this.Pose.EndsWith("TakeOrder"))
			{
				frame = (((WorkCounterFastFood)this.Task).frame % 19).ToString().PadLeft(3, '0');
			}
			if (this.Pose.EndsWith("TypeNW"))
			{
				frame = (A.ST.FrameCounter % 9).ToString().PadLeft(3, '0');
			}
			string imageName = this.GenderString + this.Pose + orientation + frame;
			PaletteDrawable pd = new PaletteDrawable(base.Location, imageName, clickString, this.PaletteIndex);
			pd.VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom;
			pd.HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center;
			if (this.Pose.EndsWith("CarryFood"))
			{
				Point bagRel = (Point)AppConstants.CarryAnchorPoints[imageName];
				PointF bagAbsolute = new PointF(base.Location.X + (float)bagRel.X, base.Location.Y + (float)bagRel.Y - 10f);
				FlexDrawable bag = new FlexDrawable(bagAbsolute, "BagOfFood");
				bag.VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom;
				bag.HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center;
				ArrayList list = new ArrayList();
				list.Add(pd);
				if (orientation.StartsWith("N"))
				{
					list.Insert(0, bag);
				}
				else
				{
					list.Add(bag);
				}
				CompoundDrawable cd = new CompoundDrawable(Point.Round(base.Location), list, "");
				d.Add(cd);
			}
			else
			{
				d.Add(pd);
			}
			return d;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0004CBEC File Offset: 0x0004BBEC
		public override bool NewStep()
		{
			return this.Task != null && this.Task.Do();
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0004CC1C File Offset: 0x0004BC1C
		public bool Drone
		{
			get
			{
				return this.PaletteIndex < 6;
			}
		}

		// Token: 0x04000626 RID: 1574
		public long ID;

		// Token: 0x04000627 RID: 1575
		public Task Task;

		// Token: 0x04000628 RID: 1576
		public string Pose = "Walk";

		// Token: 0x04000629 RID: 1577
		public string GenderString;

		// Token: 0x0400062A RID: 1578
		public int PaletteIndex;
	}
}
