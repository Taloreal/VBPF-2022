using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// An example View for an application.
	/// </summary>
	// Token: 0x02000089 RID: 137
	public class CityView : View
	{
		/// <summary>
		/// Contructs a new instance of this View with the given name
		/// and background image.
		/// </summary>
		/// <param name="name">The name for this View as it is to
		/// appear in the application.</param>
		/// <param name="background">The background image to use
		/// for this View in the application.</param>
		// Token: 0x06000437 RID: 1079 RVA: 0x0003A7BC File Offset: 0x000397BC
		public CityView(string name, Bitmap background) : base(name, background)
		{
			this.ViewerOptions = new object[]
			{
				0,
				0,
				PointF.Empty,
				""
			};
			City.NUM_AVENUES = 4;
			City.NUM_STREETS = 8;
			City.ORIGIN = new PointF(368f, 108f);
			City.STREET_SPACING = 49f;
			City.BLOCK_HEIGHTS = new float[12];
			City.LOTS_PER_BLOCK = new int[12];
			City.LOT_SPACING = 24f;
			City.AVENUE_SPACING = new float[12];
			for (int i = 0; i < 12; i++)
			{
				City.LOTS_PER_BLOCK[i] = 3;
				City.AVENUE_SPACING[i] = 98f;
			}
			City.AVENUE_VIEWING_REGIONS = 1;
			City.STREET_VIEWING_REGIONS = 1;
			City.AVENUE_REGION_OFFSET = 392;
			City.STREET_REGION_OFFSET = 392;
		}

		/// <summary>
		/// Creates and returns a collection of Drawable objects to
		/// be drawn to this View.
		/// </summary>
		/// <returns>A collection of Drawable objects to
		/// be drawn to this View.</returns>
		// Token: 0x06000438 RID: 1080 RVA: 0x0003A8A8 File Offset: 0x000398A8
		public override Drawable[] BuildDrawables(long entityID, params object[] args)
		{
			ArrayList d = new ArrayList();
			int aveRegion = (int)args[0];
			int streetRegion = (int)args[1];
			PointF p = (PointF)args[2];
			string playerName = (string)args[3];
			d.AddRange(A.ST.City.GetDrawables(aveRegion, streetRegion));
			foreach (object obj in A.ST.City.Buses)
			{
				Bus bus = (Bus)obj;
				if (bus.InRegion(aveRegion, streetRegion))
				{
					d.Add(bus.GetDrawable(aveRegion, streetRegion));
				}
			}
			foreach (object obj2 in A.ST.City.Cars)
			{
				Car car = (Car)obj2;
				if (car.InRegion(aveRegion, streetRegion))
				{
					d.Add(car.GetDrawable(aveRegion, streetRegion));
				}
			}
			foreach (object obj3 in A.ST.City.Pedestrians)
			{
				Pedestrian pedestrian = (Pedestrian)obj3;
				if (pedestrian.InRegion(aveRegion, streetRegion))
				{
					d.Add(pedestrian.GetDrawable(aveRegion, streetRegion));
				}
			}
			d.Sort();
			foreach (object obj4 in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj4;
				Color pointerColor = CityView.PointerGray;
				string suffix = "Gray";
				if (e.ID == entityID && A.SA.HasEntity(playerName))
				{
					pointerColor = CityView.PointerBlue;
					suffix = "";
				}
				if (e.Dwelling != null)
				{
					PointF p2 = Point.Empty;
					Point p3 = Point.Empty;
					int bdgHeight = 0;
					if (e.Person.Task is TravelByFoot)
					{
						p2 = ((TravelByFoot)e.Person.Task).Pedestrian.Location;
					}
					else if (e.Person.Task is TravelByCar)
					{
						p2 = ((TravelByCar)e.Person.Task).Car.Location;
					}
					else if (e.Person.Task is TravelByBus)
					{
						p2 = ((TravelByBus)e.Person.Task).Pedestrian.Location;
					}
					else if (e.Person.Task is WorkPizzaGuy)
					{
						Car car = ((WorkPizzaGuy)e.Person.Task).Car;
						if (car != null)
						{
							p2 = car.Location;
						}
						else
						{
							p2 = new PointF((float)e.Person.Task.Building.Avenue, (float)e.Person.Task.Building.Street);
						}
					}
					else
					{
						AppBuilding inside = A.ST.City.FindInsideBuilding(e);
						if (inside != null)
						{
							p3 = Point.Round(City.Transform2((float)inside.Avenue, (float)inside.Street, (float)inside.Lot, 0, 0));
							bdgHeight = inside.BuildingType.Height;
						}
					}
					if (!p2.IsEmpty)
					{
						p3 = Point.Round(City.Transform2(p2.X, p2.Y, 2f, 0, 0));
					}
					LineDrawable ld = new LineDrawable(new Point(p3.X + 24, p3.Y - bdgHeight), new Point(p3.X + 24, p3.Y - 105));
					ld.Color = CityView.PointerBlack;
					LineDrawable ld2 = new LineDrawable(new Point(p3.X + 25, p3.Y - bdgHeight), new Point(p3.X + 25, p3.Y - 105));
					ld2.Color = pointerColor;
					LineDrawable ld3 = new LineDrawable(new Point(p3.X + 26, p3.Y - bdgHeight), new Point(p3.X + 26, p3.Y - 105));
					ld3.Color = CityView.PointerBlack;
					Drawable rd = new Drawable(new Point(p3.X + 20, p3.Y - 116), "PointerPerson" + suffix);
					d.Add(ld);
					d.Add(ld2);
					d.Add(ld3);
					d.Add(rd);
				}
				if (e.Dwelling != null)
				{
					d.Add(this.PointOutBuilding(e.Dwelling, "PointerHome" + suffix));
				}
				foreach (object obj5 in e.GetAllTasks())
				{
					Task t = (Task)obj5;
					if (t is WorkTask)
					{
						d.Add(this.PointOutBuilding(t.Building, "PointerWork" + suffix));
					}
					else if (t is AttendClass)
					{
						d.Add(this.PointOutBuilding(t.Building, "PointerSchool" + suffix));
					}
				}
				if (A.SS.CondosForSaleEnabledForOwner)
				{
					foreach (object obj6 in A.ST.City.GetBuildings())
					{
						AppBuilding b = (AppBuilding)obj6;
						if (b.Owner == e && ((DwellingOffer)b.Offerings[0]).Condo)
						{
							d.Add(this.PointOutBuilding(b, "PointerCondo" + suffix));
						}
					}
				}
			}
			return (Drawable[])d.ToArray(typeof(Drawable));
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0003B05C File Offset: 0x0003A05C
		private Drawable PointOutBuilding(Building b, string imageName)
		{
			Point p3 = Point.Round(City.Transform2((float)b.Avenue, (float)b.Street, (float)b.Lot, 0, 0));
			int bdgHeight = b.BuildingType.Height;
			if (bdgHeight == 96)
			{
				bdgHeight = 75;
			}
			return new Drawable(new Point(p3.X + 16, p3.Y - bdgHeight - 26), imageName);
		}

		// Token: 0x040004C4 RID: 1220
		private static Color PointerBlue = Color.FromArgb(153, 200, 241, 254);

		// Token: 0x040004C5 RID: 1221
		private static Color PointerGray = Color.FromArgb(153, 227, 227, 227);

		// Token: 0x040004C6 RID: 1222
		private static Color PointerBlack = Color.FromArgb(153, 0, 0, 0);
	}
}
