using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Dwelling.
	/// </summary>
	// Token: 0x020000B6 RID: 182
	[Serializable]
	public class Dwelling : AppBuilding
	{
		// Token: 0x06000561 RID: 1377 RVA: 0x0004EC28 File Offset: 0x0004DC28
		public Dwelling(CityBlock block, int lotIndex, BuildingType type) : base(block, lotIndex, type)
		{
			this.Map = AppConstants.HomeMap;
			this.EntryPoint = this.Map.getNode("EntryPoint").Location;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0004EC84 File Offset: 0x0004DC84
		public override string GetBackgroundImage()
		{
			return "HomeBack";
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0004EC9C File Offset: 0x0004DC9C
		public override ArrayList GetInsideDrawables()
		{
			AppEntity e = (AppEntity)this.Owner;
			ArrayList d = new ArrayList();
			ArrayList z0 = new ArrayList();
			ArrayList z = new ArrayList();
			ArrayList z2 = new ArrayList();
			bool livesHere = e != null && e.Dwelling == this;
			bool someoneEating = false;
			foreach (object obj in this.Persons)
			{
				VBPFPerson person = (VBPFPerson)obj;
				if (person.Pose.EndsWith("EatSE"))
				{
					someoneEating = true;
				}
				if (person.Location.Y < -0.5f * (person.Location.X - 135f) + 360f)
				{
					z0.AddRange(person.GetDrawables());
				}
				else if (person.Location.Y < 0.5f * (person.Location.X - 365f) + 242f)
				{
					z.AddRange(person.GetDrawables());
				}
				else
				{
					z2.AddRange(person.GetDrawables());
				}
			}
			z0.Sort();
			z.Sort();
			z2.Sort();
			if (livesHere)
			{
				foreach (object obj2 in e.PurchasedItems)
				{
					PurchasableItem i = (PurchasableItem)obj2;
					if (i.Name.StartsWith("Art"))
					{
						d.Add(new Drawable(this.Map.getNode(i.Name).Location, i.ImageName));
					}
				}
				if (e.Has("DDR"))
				{
					int frame = 0;
					if (e.DDRLockedBy > -1L)
					{
						frame = A.ST.Random.Next(5);
					}
					d.Add(new FlexDrawable(this.Map.getNode("DDR").Location, "DDR" + frame)
					{
						VerticalAlignment = FlexDrawable.VerticalAlignments.Middle,
						HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center
					});
				}
				if (e.Has("Carpet"))
				{
					d.Add(new Drawable(this.Map.getNode("Carpet").Location, "Carpet" + e.ImageIndexOf("Carpet")));
				}
				PointF endTable = this.Map.getNode("EndTable").Location;
				d.Add(new Drawable(endTable, "EndTable"));
				int tokensPerPile = 25;
				for (int j = 0; j < Math.Min(2 * tokensPerPile, e.BusTokens / 2); j++)
				{
					int pile = j / tokensPerPile;
					d.Add(new Drawable(Point.Round(new PointF(endTable.X + 97f + (float)(pile * 10), endTable.Y - (float)(j % tokensPerPile * 2) + 3f + (float)(pile * 5))), "BusToken")
					{
						ToolTipText = A.R.GetString("{0} Bus Tokens", new object[]
						{
							e.BusTokens
						})
					});
				}
				int platterSpacing = Math.Min(20, 80 / Math.Max(1, e.PartyFood.Count));
				PointF p = this.Map.getNode("Platter0").Location;
				int k = 0;
				ArrayList platters = new ArrayList();
				foreach (object obj3 in e.PartyFood)
				{
					PurchasableItem platter = (PurchasableItem)obj3;
					d.Add(new Drawable(new PointF(p.X - (float)(k * platterSpacing), p.Y + (float)(k++ * platterSpacing / 2)), platter.ImageName + "Small")
					{
						ToolTipText = platter.FriendlyName
					});
				}
			}
			d.Add(new Drawable(this.Map.getNode("Chair4").Location, "Chair"));
			d.Add(new Drawable(this.Map.getNode("Chair4b").Location, "Chair"));
			d.Add(new Drawable(this.Map.getNode("KitchenBar3").Location, "KitchenBar3"));
			d.AddRange(z0);
			d.Add(new Drawable(this.Map.getNode("ApartmentKitchenInteriorWall").Location, "ApartmentKitchenInteriorWall"));
			Point kitchenBar = this.Map.getNode("KitchenBar").Location;
			d.Add(new Drawable(kitchenBar, "KitchenBar"));
			if (someoneEating)
			{
				d.Add(new Drawable(new Point(kitchenBar.X + 54, kitchenBar.Y + 8), "PlateOfFood"));
			}
			d.Add(new Drawable(this.Map.getNode("WallCabinet").Location, "WallCabinet"));
			Drawable fridge = new RefrigeratorDrawable(this.Map.getNode("Refrigerator").Location, "Refrigerator");
			if (e != null)
			{
				fridge.ToolTipText = A.R.GetString("Food for {0} meals.", new object[]
				{
					((AppEntity)this.Owner).Food.Count
				});
			}
			d.Add(fridge);
			d.Add(new Drawable(this.Map.getNode("Oven").Location, "Oven"));
			d.Add(new Drawable(this.Map.getNode("InteriorWall2").Location, "InteriorWall2"));
			d.Add(new Drawable(this.Map.getNode("BuiltInDesk").Location, "BuiltInDesk"));
			if (livesHere)
			{
				if (e.Has("Bed"))
				{
					d.Add(new Drawable(this.Map.getNode("Bed1").Location, "Bed" + e.ImageIndexOf("Bed")));
					d.Add(new Drawable(this.Map.getNode("Lamp").Location, "Lamp"));
				}
				if (e.Has("TreadMill"))
				{
					d.Add(new Drawable(this.Map.getNode("TreadMill").Location, "TreadMill"));
				}
				if (e.Has("Couch"))
				{
					d.Add(new Drawable(this.Map.getNode("Couch1").Location, "Couch" + e.ImageIndexOf("Couch")));
					d.Add(new Drawable(this.Map.getNode("Chair3").Location, "Chair" + e.ImageIndexOf("Couch")));
					d.Add(new Drawable(this.Map.getNode("Chair3Back").Location, "ChairBack" + e.ImageIndexOf("Couch")));
					d.Add(new Drawable(this.Map.getNode("CofeeTable").Location, "CoffeeTable" + e.ImageIndexOf("Couch")));
				}
				if (e.Has("TV"))
				{
					d.Add(new Drawable(this.Map.getNode("TVBack").Location, "TVBack" + e.ImageIndexOf("TV")));
				}
				PointF desk = this.Map.getNode("BuiltInDesk").Location;
				int billsPerPile = 25;
				float cash = ((AppEntity)this.Owner).Cash;
				if (cash > 0.01f)
				{
					int j = 0;
					while ((float)j < Math.Min((float)(4 * billsPerPile), cash / 20f))
					{
						int pile = j / billsPerPile;
						d.Add(new CashDrawable(Point.Round(new PointF(desk.X + 16f + (float)(pile * 6), desk.Y - (float)(j % billsPerPile * 2) + 41f - (float)(pile * 3))), "Money", " ", cash)
						{
							ToolTipText = Utilities.FC(cash, 2, A.I.CurrencyConversion)
						});
						j++;
					}
				}
				for (int j = 0; j < ((AppEntity)this.Owner).Bills.Count; j++)
				{
					d.Add(new BillDrawable(Point.Round(new PointF(desk.X + 74f, desk.Y - (float)(j * 2) + 12f)), "Paper", " "));
				}
				for (int j = 0; j < ((AppEntity)this.Owner).Checks.Count; j++)
				{
					d.Add(new CheckDrawable(Point.Round(new PointF(desk.X + 96f, desk.Y - (float)(j * 2) + 11f)), "Check", " "));
				}
				if (e.Has("Computer"))
				{
					d.Add(new ComputerDrawable(Point.Round(new PointF(desk.X + 45f, desk.Y + 5f)), "Computer", " "));
				}
			}
			d.AddRange(z);
			d.Add(new Drawable(this.Map.getNode("InteriorWall1").Location, "InteriorWall1"));
			if (livesHere)
			{
				if (e.Has("Stereo"))
				{
					d.Add(new Drawable(this.Map.getNode("Stereo").Location, "Stereo" + e.ImageIndexOf("Stereo")));
				}
				if (e != null)
				{
					for (int j = 0; j < Math.Min(8, e.AcademicTaskHistory.Count); j++)
					{
						PointF p2 = this.Map.getNode("Diploma").Location;
						int space = 28;
						d.Add(new Drawable(new PointF(p2.X + (float)(j % 4 * space), p2.Y + (float)(j % 4 * space / 2) + (float)(j / 4 * 28)), "Diploma")
						{
							ToolTipText = A.R.GetString("Diploma for {0}", new object[]
							{
								((AttendClass)e.AcademicTaskHistory.GetByIndex(j)).Course.Name
							})
						});
					}
				}
			}
			d.AddRange(z2);
			if (livesHere && e.Person.Task is BeSick)
			{
				PointF bed = this.Map.getNode("Bed").Location;
				d.Add(new Drawable(new PointF(bed.X + 84f, bed.Y - 22f), "IceBag"));
			}
			return d;
		}

		// Token: 0x04000659 RID: 1625
		public int MonthsLeftOnLease;

		// Token: 0x0400065A RID: 1626
		public InsurancePolicy Insurance = new InsurancePolicy(250f, false, 0f);
	}
}
