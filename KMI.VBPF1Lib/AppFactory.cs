using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Resources;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Creates app-specific versions of common inherited objects.
	/// </summary>
	// Token: 0x02000012 RID: 18
	public class AppFactory : SimFactory
	{
		/// <summary>
		/// Creates a SimState.
		/// </summary>
		/// <param name="simSettings">Initialization settings that can be changed in DesignerMode.</param>
		/// <param name="multiplayer">True if multiplayer, false otherwise.</param>
		/// <returns>A new SimState.</returns>
		// Token: 0x0600004E RID: 78 RVA: 0x0000626C File Offset: 0x0000526C
		public override SimState CreateSimState(SimSettings simSettings, bool multiplayer)
		{
			return new AppSimState(simSettings, multiplayer);
		}

		/// <summary>
		/// Creates the table of images to use in the application.
		/// </summary>
		/// <remarks>
		/// When developing all images to be used in the program should
		/// be added in this method.
		/// </remarks>
		/// <returns>A SortedList of all the images used in this application,
		/// keyed by the name for the image created by the programmer.</returns>
		// Token: 0x0600004F RID: 79 RVA: 0x00006288 File Offset: 0x00005288
		public override SortedList CreateImageTable()
		{
			SortedList table = new SortedList();
			Type t = typeof(frmMain);
			table.Add("HRLogo", base.CBmp(t, "Images.HRLogo.png"));
			table.Add("StatusBusTokens", base.CBmp(t, "Images.StatusIconsAndPointers.BusTokens.png"));
			table.Add("StatusGas", base.CBmp(t, "Images.StatusIconsAndPointers.Gas.png"));
			table.Add("StatusFood", base.CBmp(t, "Images.StatusIconsAndPointers.Food.png"));
			table.Add("StatusHealth", base.CBmp(t, "Images.StatusIconsAndPointers.Health.png"));
			table.Add("PointerHome", base.CBmp(t, "Images.StatusIconsAndPointers.Home.png"));
			table.Add("PointerHomeGray", base.CBmp(t, "Images.StatusIconsAndPointers.HomeGray.png"));
			table.Add("PointerSchool", base.CBmp(t, "Images.StatusIconsAndPointers.School.png"));
			table.Add("PointerSchoolGray", base.CBmp(t, "Images.StatusIconsAndPointers.SchoolGray.png"));
			table.Add("PointerWork", base.CBmp(t, "Images.StatusIconsAndPointers.Work.png"));
			table.Add("PointerWorkGray", base.CBmp(t, "Images.StatusIconsAndPointers.WorkGray.png"));
			table.Add("PointerPerson", base.CBmp(t, "Images.StatusIconsAndPointers.Person.png"));
			table.Add("PointerPersonGray", base.CBmp(t, "Images.StatusIconsAndPointers.PersonGray.png"));
			table.Add("PointerCondo", base.CBmp(t, "Images.StatusIconsAndPointers.Condo.png"));
			table.Add("PointerCondoGray", base.CBmp(t, "Images.StatusIconsAndPointers.CondoGray.png"));
			table.Add("City", base.CBmp(t, "Images.CityView.City.png"));
			table.Add("CarNESW", base.CBmp(t, "Images.CityView.CarNESW.gif"));
			table.Add("CarNWSE", base.CBmp(t, "Images.CityView.CarNWSE.gif"));
			for (int i = 0; i < AppConstants.BuildingTypeCount; i++)
			{
				Bitmap bmp = base.CBmp(t, "Images.CityView.Building" + i + ".png");
				table.Add("Building" + i, bmp);
			}
			table.Add("Arrow", base.CBmp(t, "Images.Arrow.png"));
			base.LoadWithCompassPoints(table, t, "Images.CityView.Bus", "png");
			table.Add("Walker", base.CBmp(t, "Images.CityView.Walker.png"));
			for (int i = 0; i < 3; i++)
			{
				table.Add("GasCan" + i, base.CBmp(t, "Images.CityView.GasCan" + i + ".png"));
			}
			table.Add("MotorOil", base.CBmp(t, "Images.CityView.MotorOil.png"));
			table.Add("CarOnLift", base.CBmp(t, "Images.CityView.CarOnLift.png"));
			table.Add("CityNavIcon", base.CBmp(t, "Images.CityNavIcon.png"));
			for (int i = 0; i < 6; i++)
			{
				table.Add("Car" + i, base.CBmp(t, "Images.CityView.Car" + i + ".png"));
				table.Add("StatusCar" + i + "OK", base.CBmp(t, "Images.StatusIconsAndPointers.Car" + i + "OK.png"));
				table.Add("StatusCar" + i + "Broken", base.CBmp(t, "Images.StatusIconsAndPointers.Car" + i + "Broken.png"));
			}
			table.Add("HomeBack", base.CBmp(t, "Images.HomeView.ApartmentFloor2.png"));
			for (int i = 0; i < 3; i++)
			{
				table.Add("Bed" + i, base.CBmp(t, "Images.HomeView.Bed" + i + ".png"));
			}
			for (int i = 0; i < 4; i++)
			{
				table.Add("Couch" + i, base.CBmp(t, "Images.HomeView.Couch" + i + ".png"));
				table.Add("CoffeeTable" + i, base.CBmp(t, "Images.HomeView.CoffeeTable" + i + ".png"));
				table.Add("Chair" + i, base.CBmp(t, "Images.HomeView.Chair" + i + ".png"));
				table.Add("ChairBack" + i, base.CBmp(t, "Images.HomeView.ChairBack" + i + ".png"));
			}
			for (int i = 0; i < 5; i++)
			{
				table.Add("Carpet" + i, base.CBmp(t, "Images.HomeView.Carpet" + i + ".png"));
			}
			table.Add("ApartmentKitchenInteriorWall", base.CBmp(t, "Images.HomeView.ApartmentKitchenInteriorWall.png"));
			table.Add("InteriorWall1", base.CBmp(t, "Images.HomeView.InteriorWall1.png"));
			table.Add("InteriorWall2", base.CBmp(t, "Images.HomeView.InteriorWall2.png"));
			table.Add("Computer", base.CBmp(t, "Images.HomeView.Computer.png"));
			table.Add("KitchenBar3", base.CBmp(t, "Images.HomeView.KitchenBar3.png"));
			table.Add("KitchenBar", base.CBmp(t, "Images.HomeView.KitchenBar.png"));
			table.Add("Lamp2", base.CBmp(t, "Images.HomeView.Lamp2.png"));
			table.Add("Lamp", base.CBmp(t, "Images.HomeView.Lamp.png"));
			for (int i = 0; i < 2; i++)
			{
				table.Add("TVBack" + i, base.CBmp(t, "Images.HomeView.TVBack" + i + ".png"));
				table.Add("TVFront" + i, base.CBmp(t, "Images.HomeView.TVFront" + i + ".png"));
			}
			table.Add("WallCabinet", base.CBmp(t, "Images.HomeView.WallCabinet.png"));
			table.Add("FloorCabinet", base.CBmp(t, "Images.HomeView.FloorCabinet.png"));
			table.Add("TreadMill", base.CBmp(t, "Images.HomeView.TreadMill.png"));
			table.Add("Chair", base.CBmp(t, "Images.HomeView.Chair.png"));
			table.Add("Decor", base.CBmp(t, "Images.HomeView.Decor.png"));
			table.Add("EndTable2", base.CBmp(t, "Images.HomeView.EndTable2.png"));
			table.Add("BuiltInDesk", base.CBmp(t, "Images.HomeView.BuiltInDesk.png"));
			table.Add("Oven", base.CBmp(t, "Images.HomeView.Oven.png"));
			table.Add("Plant", base.CBmp(t, "Images.HomeView.Plant.png"));
			table.Add("WallSconce", base.CBmp(t, "Images.HomeView.WallSconce.png"));
			table.Add("Refrigerator", base.CBmp(t, "Images.HomeView.Refrigerator.png"));
			table.Add("Paper", base.CBmp(t, "Images.HomeView.Paper.png"));
			table.Add("Money", base.CBmp(t, "Images.HomeView.Money.png"));
			table.Add("Check", base.CBmp(t, "Images.HomeView.Check.png"));
			for (int i = 0; i < 3; i++)
			{
				table.Add("BagOfFood" + i, base.CBmp(t, "Images.HomeView.BagOfFood" + i + ".png"));
			}
			for (int i = 0; i < 5; i++)
			{
				table.Add("Platter" + i, base.CBmp(t, "Images.HomeView.Platter" + i + ".png"));
				table.Add("Platter" + i + "Small", base.CBmp(t, "Images.HomeView.Platter" + i + "Small.png"));
			}
			table.Add("PlateOfFood", base.CBmp(t, "Images.HomeView.PlateOfFood.png"));
			table.Add("IceBag", base.CBmp(t, "Images.HomeView.IceBag.png"));
			table.Add("EndTable", base.CBmp(t, "Images.HomeView.EndTableSE.png"));
			table.Add("BusToken", base.CBmp(t, "Images.HomeView.BusToken.png"));
			table.Add("Diploma", base.CBmp(t, "Images.HomeView.Diploma.png"));
			for (int i = 0; i < 3; i++)
			{
				table.Add("BusTokens" + i, base.CBmp(t, "Images.HomeView.BusTokens" + i + ".png"));
			}
			for (int i = 0; i < 5; i++)
			{
				table.Add("DDR" + i, base.CBmp(t, "Images.HomeView.DDR" + i + ".png"));
			}
			for (int i = 0; i < 7; i++)
			{
				table.Add("Art" + i, base.CBmp(t, "Images.HomeView.Art" + i + ".png"));
			}
			for (int i = 0; i < 3; i++)
			{
				table.Add("Stereo" + i, base.CBmp(t, "Images.HomeView.Stereo" + i + ".png"));
			}
			table.Add("WorkBack", base.CBmp(t, "Images.WorkView0.FastFoodFloor.png"));
			table.Add("BagOfFood", base.CBmp(t, "Images.WorkView0.BagOfFood.png"));
			table.Add("CounterFastFood", base.CBmp(t, "Images.WorkView0.CounterFastFood.png"));
			table.Add("FoodContainer1", base.CBmp(t, "Images.WorkView0.FoodContainer1.png"));
			table.Add("FoodContainer0", base.CBmp(t, "Images.WorkView0.FoodContainer0.png"));
			table.Add("FoodWall", base.CBmp(t, "Images.WorkView0.FoodWall.png"));
			table.Add("FoodWallTop", base.CBmp(t, "Images.WorkView0.FoodWallTop.png"));
			table.Add("SodaMachine", base.CBmp(t, "Images.WorkView0.SodaMachine.png"));
			table.Add("TreeFastFood", base.CBmp(t, "Images.WorkView0.TreeFastFood.png"));
			table.Add("RightGlass", base.CBmp(t, "Images.WorkView0.RightGlass.png"));
			table.Add("LeftGlass", base.CBmp(t, "Images.WorkView0.LeftGlass.png"));
			table.Add("Bar", base.CBmp(t, "Images.WorkView0.Bar.png"));
			table.Add("PlantsFrontLeft", base.CBmp(t, "Images.WorkView0.PlantsFrontLeft.png"));
			table.Add("PlantsFrontRight", base.CBmp(t, "Images.WorkView0.PlantsFrontRight.png"));
			table.Add("OfficeBack", base.CBmp(t, "Images.WorkView1.OfficeBack.png"));
			table.Add("SWWall", base.CBmp(t, "Images.WorkView1.SWWall.png"));
			table.Add("SEWall", base.CBmp(t, "Images.WorkView1.SEWall.png"));
			table.Add("OfficeCouch", base.CBmp(t, "Images.WorkView1.OfficeCouch.png"));
			table.Add("OfficeManagerDesk", base.CBmp(t, "Images.WorkView1.OfficeManagerDesk.png"));
			table.Add("OfficeManagerPainting", base.CBmp(t, "Images.WorkView1.OfficeManagerPainting.png"));
			table.Add("OfficeManagerPlant", base.CBmp(t, "Images.WorkView1.OfficeManagerPlant.png"));
			table.Add("OfficePlant", base.CBmp(t, "Images.WorkView1.OfficePlant.png"));
			table.Add("OfficePrinter", base.CBmp(t, "Images.WorkView1.OfficePrinter.png"));
			table.Add("OfficeSupervisorBookshelf", base.CBmp(t, "Images.WorkView1.OfficeSupervisorBookshelf.png"));
			table.Add("OfficeSupervisorDesk", base.CBmp(t, "Images.WorkView1.OfficeSupervisorDesk.png"));
			table.Add("OfficeWorkerDesk", base.CBmp(t, "Images.WorkView1.OfficeWorkerDesk.png"));
			table.Add("OfficeWorkerChair", base.CBmp(t, "Images.WorkView1.OfficeWorkerChair.png"));
			table.Add("ClassBack", base.CBmp(t, "Images.ClassView.SchoolFloor.png"));
			table.Add("TeacherDesk", base.CBmp(t, "Images.ClassView.TeacherDesk.png"));
			table.Add("SchoolChairBack", base.CBmp(t, "Images.ClassView.SchoolChairBack.png"));
			table.Add("SchoolChairBottom", base.CBmp(t, "Images.ClassView.SchoolChairBottom.png"));
			table.Add("Table", base.CBmp(t, "Images.ClassView.Table.png"));
			table.Add("1040EZ", base.CBmp(t, "Images.1040EZ.png"));
			foreach (string gender in new string[]
			{
				"Female",
				"Male"
			})
			{
				for (int i = 0; i < 28; i++)
				{
					string frame = i.ToString();
					frame = frame.PadLeft(4, '0');
					table.Add(gender + "TeacherBoardSW" + frame, base.CBmp(t, string.Concat(new string[]
					{
						"Images.ClassView.",
						gender,
						"TeacherBoardSW",
						frame,
						".png"
					})));
				}
			}
			foreach (string gender in new string[]
			{
				"Female",
				"Male"
			})
			{
				for (int i = 0; i < 19; i++)
				{
					string frame = i.ToString();
					frame = frame.PadLeft(3, '0');
					Bitmap b = new Bitmap(t, string.Concat(new string[]
					{
						"Images.People.",
						gender,
						"FFTakeOrderSW",
						frame,
						".gif"
					}));
					this.PalettizeAndInsert(table, b, gender, "FFTakeOrder", "SW", frame);
				}
				foreach (string orient in new string[]
				{
					"NW",
					"SW"
				})
				{
					for (int i = 0; i < 9; i += 2)
					{
						string frame = i.ToString();
						frame = frame.PadLeft(3, '0');
						Bitmap b = new Bitmap(t, string.Concat(new string[]
						{
							"Images.People.",
							gender,
							"FastFoodWalk",
							orient,
							frame,
							".gif"
						}));
						this.PalettizeFlipAndInsert(table, b, gender, "FFWalk", orient, frame);
					}
					Bitmap b2 = new Bitmap(t, string.Concat(new string[]
					{
						"Images.People.",
						gender,
						"FastFoodStand",
						orient,
						".gif"
					}));
					this.PalettizeFlipAndInsert(table, b2, gender, "FFStand", orient, "");
				}
			}
			foreach (string gender in new string[]
			{
				"Female",
				"Male"
			})
			{
				for (int i = 0; i < 9; i++)
				{
					Bitmap b = new Bitmap(t, string.Concat(new object[]
					{
						"Images.WorkView1.Type.",
						gender,
						"SitTypeNW00",
						i,
						".gif"
					}));
					this.PalettizeAndInsert(table, b, gender, "SitType", "NW", "00" + i.ToString());
				}
			}
			foreach (string variant in new string[]
			{
				"Stand",
				"Sit",
				"Sleep"
			})
			{
				foreach (string gender in new string[]
				{
					"Female",
					"Male"
				})
				{
					foreach (string orient in new string[]
					{
						"NW",
						"SW"
					})
					{
						Bitmap b2 = new Bitmap(t, string.Concat(new string[]
						{
							"Images.People.",
							gender,
							variant,
							orient,
							".gif"
						}));
						this.PalettizeFlipAndInsert(table, b2, gender, variant, orient, "");
					}
				}
			}
			for (int i = 0; i < 18; i++)
			{
				Bitmap b2;
				if (i < 6)
				{
					b2 = new Bitmap(t, "Images.People.Palette" + i + ".gif");
				}
				else if (i < 12)
				{
					b2 = new Bitmap(t, "Images.People.UserPeople.Female" + (i - 6) + ".gif");
				}
				else
				{
					b2 = new Bitmap(t, "Images.People.UserPeople.Male" + (i - 12) + ".gif");
				}
				ColorPalette p = b2.Palette;
				for (int j = 240; j < 256; j++)
				{
					p.Entries[j] = Color.FromArgb(0, p.Entries[j]);
				}
				b2.Palette = p;
				table.Add("Palette" + i, b2);
			}
			foreach (string variant in new string[]
			{
				"Walk",
				"CarryFood",
				"FFCarryFood"
			})
			{
				foreach (string gender in new string[]
				{
					"Female",
					"Male"
				})
				{
					foreach (string orient in new string[]
					{
						"NW",
						"SW"
					})
					{
						for (int i = 0; i < 9; i += 2)
						{
							Bitmap b = new Bitmap(t, string.Concat(new object[]
							{
								"Images.People.",
								gender,
								variant,
								orient,
								"00",
								i,
								".gif"
							}));
							this.PalettizeFlipAndInsert(table, b, gender, variant, orient, "00" + i);
						}
					}
				}
			}
			foreach (string gender in new string[]
			{
				"Female",
				"Male"
			})
			{
				for (int i = 0; i < 9; i++)
				{
					Bitmap b = new Bitmap(t, string.Concat(new object[]
					{
						"Images.People.",
						gender,
						"JumpingJacksSW00",
						i,
						".gif"
					}));
					this.PalettizeAndInsert(table, b, gender, "JumpingJacks", "SW", "00" + i);
				}
			}
			foreach (string gender in new string[]
			{
				"Female",
				"Male"
			})
			{
				for (int i = 0; i < 27; i++)
				{
					Bitmap b = new Bitmap(t, string.Concat(new string[]
					{
						"Images.People.",
						gender,
						"DanceSW",
						i.ToString().PadLeft(3, '0'),
						".gif"
					}));
					this.PalettizeFlipAndInsert(table, b, gender, "Dance", "SW", i.ToString().PadLeft(3, '0'));
				}
			}
			foreach (string gender in new string[]
			{
				"Female",
				"Male"
			})
			{
				for (int i = 0; i < 10; i++)
				{
					Bitmap b = new Bitmap(t, string.Concat(new object[]
					{
						"Images.People.",
						gender,
						"EatSW00",
						i,
						".gif"
					}));
					this.PalettizeFlipAndInsert(table, b, gender, "Eat", "SW", "00" + i);
				}
			}
			AppConstants.CarryAnchorPoints = new Hashtable();
			foreach (string variant in new string[]
			{
				"CarryFood",
				"FFCarryFood"
			})
			{
				foreach (string gender in new string[]
				{
					"Female",
					"Male"
				})
				{
					foreach (string orient in new string[]
					{
						"NW",
						"SW",
						"NE",
						"SE"
					})
					{
						for (int i = 0; i < 9; i += 2)
						{
							string imageName = string.Concat(new object[]
							{
								gender,
								variant,
								orient,
								"00",
								i
							});
							Bitmap b = (Bitmap)table[imageName];
							for (int x = 0; x < b.Width; x++)
							{
								for (int y = 0; y < b.Height; y++)
								{
									Color c = b.GetPixel(x, y);
									if (c.R == 0 && c.G == 0 && c.B == 0)
									{
										AppConstants.CarryAnchorPoints.Add(imageName, new Point(x - b.Width / 2, y - b.Height + 15));
										break;
									}
								}
							}
						}
					}
				}
			}
			table.Add("LogoHSN Bank", base.CBmp(t, "Images.LogosAndCards.LogoHSN.png"));
			table.Add("LogoOlympic Bank", base.CBmp(t, "Images.LogosAndCards.LogoOlympic.png"));
			table.Add("LogoHerald Bank", base.CBmp(t, "Images.LogosAndCards.LogoHerald.png"));
			table.Add("CCardHSN Bank", base.CBmp(t, "Images.LogosAndCards.CCardHSN.png"));
			table.Add("CCardOlympic Bank", base.CBmp(t, "Images.LogosAndCards.CCardOlympic.png"));
			table.Add("CCardHerald Bank", base.CBmp(t, "Images.LogosAndCards.CCardHerald.png"));
			table.Add("DCardHSN Bank", base.CBmp(t, "Images.LogosAndCards.DCardHSN.png"));
			table.Add("DCardOlympic Bank", base.CBmp(t, "Images.LogosAndCards.DCardOlympic.png"));
			table.Add("DCardHerald Bank", base.CBmp(t, "Images.LogosAndCards.DCardHerald.png"));
			table.Add("LogoTaranti Auto Loan", base.CBmp(t, "Images.LogosAndCards.LogoAuto.png"));
			table.Add("LogoTaranti Auto Lease", base.CBmp(t, "Images.LogosAndCards.LogoAuto.png"));
			table.Add("LogoNRG Electric", base.CBmp(t, "Images.LogosAndCards.LogoElectric.png"));
			table.Add("LogoS&W Insurance", base.CBmp(t, "Images.LogosAndCards.LogoInsurance.png"));
			table.Add("LogoInternet Connect", base.CBmp(t, "Images.LogosAndCards.LogoInternet.png"));
			table.Add("LogoVincent Medical", base.CBmp(t, "Images.LogosAndCards.LogoMedical.png"));
			table.Add("LogoCity Property Mgt", base.CBmp(t, "Images.LogosAndCards.LogoProperty.png"));
			table.Add("LogoQuest Student Loans", base.CBmp(t, "Images.LogosAndCards.LogoStudentLoan.png"));
			table.Add("LogoFiduciary Investments", base.CBmp(t, "Images.LogosAndCards.LogoFiduciary.png"));
			table.Add("LogoCentury Mortgage", base.CBmp(t, "Images.LogosAndCards.LogoCentury.png"));
			table.Add("LogoIRS", base.CBmp(t, "Images.LogosAndCards.LogoIRS.jpg"));
			return table;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00007CE0 File Offset: 0x00006CE0
		public void PalettizeFlipAndInsert(SortedList table, Bitmap b, string gender, string pose, string orient, string frame)
		{
			Bitmap bflipped = (Bitmap)b.Clone();
			ColorPalette p = b.Palette;
			for (int i = 240; i < 256; i++)
			{
				p.Entries[i] = Color.FromArgb(0, p.Entries[i]);
			}
			b.Palette = p;
			table.Add(gender + pose + orient + frame, b);
			bflipped.RotateFlip(RotateFlipType.RotateNoneFlipX);
			table.Add(string.Concat(new string[]
			{
				gender,
				pose,
				orient.Substring(0, 1),
				"E",
				frame
			}), bflipped);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00007DA4 File Offset: 0x00006DA4
		public void PalettizeAndInsert(SortedList table, Bitmap b, string gender, string pose, string orient, string frame)
		{
			ColorPalette p = b.Palette;
			for (int i = 240; i < 256; i++)
			{
				p.Entries[i] = Color.FromArgb(0, p.Entries[i]);
			}
			b.Palette = p;
			table.Add(gender + pose + orient + frame, b);
		}

		/// <summary>
		/// Creates the application's Views.  The developper should
		/// explicitly create the Views and return them as a View[]
		/// object in this method.
		/// </summary>
		/// <returns>A View[] object that is the collection of the
		/// application's Views.</returns>
		// Token: 0x06000052 RID: 82 RVA: 0x00007E18 File Offset: 0x00006E18
		public override View[] CreateViews()
		{
			View[] views = new View[2];
			views[0] = new CityView("Outside", S.R.GetImage("City"));
			views[0].ClearDrawSelectedOnMouseMove = true;
			views[1] = new InsideView("Home", S.R.GetImage("HomeBack"));
			return views;
		}

		/// <summary>
		/// Creates the application's Resource handling object.
		/// Note: if app level resource paths are bad, will hang!
		/// </summary>
		/// <returns>The application's Resource handling object.</returns>
		// Token: 0x06000053 RID: 83 RVA: 0x00007E74 File Offset: 0x00006E74
		public override Resource CreateResource()
		{
			ResourceManager rm0 = new ResourceManager("KMI.Sim.Sim", Assembly.GetAssembly(typeof(SimFactory)));
			ResourceManager rm = new ResourceManager("KMI.VBPF1Lib.App", Assembly.GetAssembly(typeof(AppFactory)));
			return new Resource(new ResourceManager[]
			{
				rm0,
				rm
			});
		}

		/// <summary>
		/// Creates and returns a new AppEntity for the given Player
		/// and entity name.
		/// </summary>
		/// <param name="player">The Player to own the Entity.</param>
		/// <param name="entityName">The Entity's name.</param>
		/// <returns>A new AppEntity for the given Player
		/// and entity name.</returns>
		// Token: 0x06000054 RID: 84 RVA: 0x00007ED0 File Offset: 0x00006ED0
		public override Entity CreateEntity(Player player, string entityName)
		{
			return new AppEntity(player, entityName);
		}

		/// <summary>
		/// Creates a new state adapter for the application.
		/// </summary>
		/// <returns>A new state adapter for the application.</returns>
		// Token: 0x06000055 RID: 85 RVA: 0x00007EEC File Offset: 0x00006EEC
		public override SimStateAdapter CreateSimStateAdapter()
		{
			return new AppStateAdapter();
		}

		/// <summary>
		/// Creates the application's SimSettings object.
		/// </summary>
		/// <returns>The application's SimSettings object.</returns>
		// Token: 0x06000056 RID: 86 RVA: 0x00007F04 File Offset: 0x00006F04
		public override SimSettings CreateSimSettings()
		{
			return new AppSimSettings();
		}
	}
}
