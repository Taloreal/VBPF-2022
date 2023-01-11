using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Course.
	/// </summary>
	// Token: 0x02000072 RID: 114
	[Serializable]
	public class Classroom : AppBuilding
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x000330BB File Offset: 0x000320BB
		public Classroom(CityBlock block, int lotIndex, BuildingType type) : base(block, lotIndex, type)
		{
			this.Map = AppConstants.ClassMap;
			this.EntryPoint = this.Map.getNode("EntryPoint").Location;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000330F4 File Offset: 0x000320F4
		public override ArrayList GetInsideDrawables()
		{
			ArrayList d = new ArrayList();
			d.Add(new Drawable(this.Map.getNode("TeacherDesk").Location, "TeacherDesk"));
			ArrayList peopleBack = new ArrayList();
			ArrayList peopleFront = new ArrayList();
			foreach (object obj in this.Persons)
			{
				VBPFPerson p = (VBPFPerson)obj;
				if (p.Location.Y < 0.5f * p.Location.X + 207f && p.Location.Y < -0.5f * p.Location.X + 640f)
				{
					peopleBack.AddRange(p.GetDrawables());
				}
				else
				{
					peopleFront.AddRange(p.GetDrawables());
				}
			}
			peopleBack.Sort();
			peopleFront.Sort();
			d.AddRange(peopleBack);
			for (int i = 0; i < 2; i++)
			{
				Point j = this.Map.getNode("Table" + i).Location;
				d.Add(new FlexDrawable(new Point(j.X + 82, j.Y + 58), "Table")
				{
					HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center,
					VerticalAlignment = FlexDrawable.VerticalAlignments.Middle
				});
			}
			for (int i = 0; i < 4; i++)
			{
				Point p2 = this.Map.getNode("Chair" + i).Location;
				d.Add(new Drawable(new Point(p2.X - 29, p2.Y - 33), "SchoolChairBottom"));
			}
			d.AddRange(peopleBack);
			for (int i = 2; i < 4; i++)
			{
				Point j = this.Map.getNode("Table" + i).Location;
				d.Add(new FlexDrawable(new Point(j.X + 82, j.Y + 58), "Table")
				{
					HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center,
					VerticalAlignment = FlexDrawable.VerticalAlignments.Middle
				});
			}
			for (int i = 4; i < 8; i++)
			{
				Point p2 = this.Map.getNode("Chair" + i).Location;
				d.Add(new Drawable(new Point(p2.X - 29, p2.Y - 33), "SchoolChairBottom"));
			}
			d.AddRange(peopleFront);
			Course c = this.DuringCourse();
			if (c != null)
			{
				string frame = (A.ST.FrameCounter % 28).ToString().PadLeft(4, '0');
				d.Add(new Drawable(this.Map.getNode("Teacher").Location, c.TeacherGender + "TeacherBoardSW" + frame));
			}
			return d;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00033474 File Offset: 0x00032474
		public Course DuringCourse()
		{
			foreach (object obj in this.Offerings)
			{
				Offering o = (Offering)obj;
				if (o.PrototypeTask.StartPeriod <= A.ST.Period && o.PrototypeTask.EndPeriod > A.ST.Period)
				{
					return (Course)o;
				}
			}
			return null;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0003351C File Offset: 0x0003251C
		public override string GetBackgroundImage()
		{
			return "ClassBack";
		}
	}
}
