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
	// Token: 0x02000096 RID: 150
	[Serializable]
	public class Office : AppBuilding
	{
		// Token: 0x060004B1 RID: 1201 RVA: 0x00042858 File Offset: 0x00041858
		public Office(CityBlock block, int lotIndex, BuildingType type) : base(block, lotIndex, type)
		{
			this.Map = AppConstants.Work1Map;
			this.EntryPoint = this.Map.getNode("EntryPoint").Location;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000428B8 File Offset: 0x000418B8
		public override ArrayList GetInsideDrawables()
		{
			ArrayList d = new ArrayList();
			ArrayList peopleBack = new ArrayList();
			ArrayList peopleFront = new ArrayList();
			foreach (object obj in this.Persons)
			{
				VBPFPerson p = (VBPFPerson)obj;
				if (p.Location.Y < 0.5f * p.Location.X + 47f)
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
			d.Add(new Drawable(this.Map.getNode("OfficeSupervisorDesk").Location, "OfficeSupervisorDesk"));
			d.Add(new Drawable(this.Map.getNode("OfficeSupervisorBookshelf").Location, "OfficeSupervisorBookshelf"));
			d.Add(new Drawable(this.Map.getNode("SWWall").Location, "SWWall"));
			d.Add(new Drawable(this.Map.getNode("OfficeCouch").Location, "OfficeCouch"));
			d.Add(new Drawable(this.Map.getNode("OfficeManagerDesk").Location, "OfficeManagerDesk"));
			d.Add(new Drawable(this.Map.getNode("OfficeManagerPainting").Location, "OfficeManagerPainting"));
			d.Add(new Drawable(this.Map.getNode("OfficeManagerPlant").Location, "OfficeManagerPlant"));
			for (int i = 4; i < 6; i++)
			{
				PointF pc = this.Map.getNode("Chair" + i).Location;
				d.Add(new Drawable(new PointF(pc.X - 10f, pc.Y - 36f), "OfficeWorkerChair"));
			}
			d.AddRange(peopleBack);
			float[] space = new float[]
			{
				0f,
				134f,
				320f
			};
			PointF seWall = this.Map.getNode("SEWall").Location;
			for (int i = 0; i < 3; i++)
			{
				d.Add(new Drawable(new PointF(seWall.X + space[i], seWall.Y + space[i] / 2f), "SEWall"));
			}
			d.Add(new Drawable(this.Map.getNode("OfficePlant").Location, "OfficePlant"));
			d.Add(new Drawable(this.Map.getNode("OfficePrinter").Location, "OfficePrinter"));
			for (int i = 0; i < 4; i++)
			{
				d.Add(new Drawable(this.Map.getNode("OfficeWorkerDesk" + i).Location, "OfficeWorkerDesk"));
			}
			for (int i = 0; i < 4; i++)
			{
				PointF pc = this.Map.getNode("Chair" + i).Location;
				d.Add(new Drawable(new PointF(pc.X - 10f, pc.Y - 36f), "OfficeWorkerChair"));
			}
			d.AddRange(peopleFront);
			return d;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00042CB0 File Offset: 0x00041CB0
		public override string GetBackgroundImage()
		{
			return "OfficeBack";
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00042CC7 File Offset: 0x00041CC7
		public void StressOutWorkers()
		{
		}

		// Token: 0x0400057E RID: 1406
		public float Busyness = 0.02f * (float)A.ST.Random.NextDouble();
	}
}
