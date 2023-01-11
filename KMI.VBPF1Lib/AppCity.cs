using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for AppCity.
	/// </summary>
	// Token: 0x020000AD RID: 173
	[Serializable]
	public class AppCity : City
	{
		// Token: 0x0600051D RID: 1309 RVA: 0x00049F90 File Offset: 0x00048F90
		public AppCity()
		{
			this.downtownAve = A.ST.Random.Next(0, 3);
			this.downtownStreet = A.ST.Random.Next(0, 6);
			int univAve;
			for (univAve = this.downtownAve; univAve == this.downtownAve; univAve = A.ST.Random.Next(0, 3))
			{
			}
			int univStreet = A.ST.Random.Next(0, 5);
			int offices = 7;
			int pizzaPlaces = 4;
			int apartments = 12;
			int pharmas = 2;
			float additionalJobRatio = 1f;
			if (A.ST.Multiplayer)
			{
				additionalJobRatio = 1f + (float)A.SS.ExpectedMultiplayerPlayers / 15f;
			}
			double pctOpen = 0.0;
			if (A.ST.Multiplayer)
			{
				pctOpen /= (double)A.SS.ExpectedMultiplayerPlayers;
			}
			CityBlock[,] blocks = this.blocks;
			int upperBound = blocks.GetUpperBound(0);
			int upperBound2 = blocks.GetUpperBound(1);
			int i;
			for (int l = blocks.GetLowerBound(0); l <= upperBound; l++)
			{
				for (int m = blocks.GetLowerBound(1); m <= upperBound2; m++)
				{
					CityBlock block = blocks[l, m];
					for (i = 0; i < block.NumLots; i++)
					{
						if (!A.ST.Multiplayer)
						{
							pctOpen = (Math.Pow((double)((block.Avenue - this.downtownAve) * 2), 2.0) + Math.Pow((double)(block.Street - this.downtownStreet), 2.0)) / 200.0;
						}
						if (block[i] == null && A.ST.Random.NextDouble() > pctOpen)
						{
							block[i] = new AppBuilding(block, i, City.BuildingTypes[0]);
						}
					}
				}
			}
			for (i = 0; i < City.NUM_STREETS; i++)
			{
				base[this.downtownAve, i, 2] = new AppBuilding(base[this.downtownAve, i], 2, City.BuildingTypes[6]);
			}
			for (int s = univStreet; s < univStreet + 3; s++)
			{
				for (int lot = 0; lot < City.LOTS_PER_BLOCK[0]; lot++)
				{
					base[univAve, s, lot] = new Classroom(base[univAve, s], lot, City.BuildingTypes[5]);
				}
			}
			this.CreateCourses(16, 32, false);
			this.CreateCourses(36, 42, false);
			this.CreateCourses(16, 32, true);
			this.AddCourse(A.R.GetString("Medical Degree"), A.R.GetString("Four-year medical school program."), 119975f, 8320, 16, 32, false, A.R.GetString("Bachelors Degree"));
			i = 0;
			while ((float)i < (float)offices * additionalJobRatio)
			{
				AppBuilding bdg = this.GetRandomBuilding(this.downtownAve, this.downtownStreet, true, 2.5f, 30);
				base[bdg.Avenue, bdg.Street, bdg.Lot] = new Office(bdg.Block, bdg.Lot, City.BuildingTypes[3]);
				i++;
			}
			i = 0;
			while ((float)i < 2f * additionalJobRatio)
			{
				this.AddOffice(16, 32, true, false, false);
				this.AddOffice(16, 32, false, true, false);
				this.AddOffice(16, 32, false, false, true);
				i++;
			}
			this.AddOffice(36, 42, true, false, false);
			this.AddOffice(36, 42, true, false, false);
			this.AddOffice(36, 42, false, true, false);
			int startups = 4;
			i = 0;
			while ((float)i < (float)startups * additionalJobRatio)
			{
				AppBuilding bdg = this.GetRandomBuilding(this.downtownAve, this.downtownStreet, true, 2.5f, 30);
				base[bdg.Avenue, bdg.Street, bdg.Lot] = new AppBuilding(bdg.Block, bdg.Lot, City.BuildingTypes[18]);
				i++;
			}
			i = 0;
			while ((float)i < 2f * additionalJobRatio)
			{
				this.AddJobInvisible(16, 32, 18, new WorkInternet1(), false);
				this.AddJobInvisible(36, 42, 18, new WorkInternet1(), false);
				this.AddJobInvisible(16, 32, 18, new WorkInternet2(), false);
				this.AddJobInvisible(16, 32, 18, new WorkInternet3(), false);
				i++;
			}
			int hospitals = 3;
			i = 0;
			while ((float)i < (float)hospitals * additionalJobRatio)
			{
				AppBuilding bdg = this.GetRandomBuilding(this.downtownAve, this.downtownStreet, true, 2.5f, 30);
				base[bdg.Avenue, bdg.Street, bdg.Lot] = new AppBuilding(bdg.Block, bdg.Lot, City.BuildingTypes[19]);
				i++;
			}
			i = 0;
			while ((float)i < 1f * additionalJobRatio)
			{
				this.AddJobInvisible(16, 32, 19, new WorkHospital1(), false);
				this.AddJobInvisible(30, 46, 19, new WorkHospital1(), false);
				this.AddJobInvisible(16, 32, 19, new WorkHospital1(), true);
				this.AddJobInvisible(30, 46, 19, new WorkHospital1(), true);
				i++;
			}
			i = 0;
			while ((float)i < 2f * additionalJobRatio)
			{
				this.AddJobInvisible(16, 44, 19, new WorkHospital2(), false);
				this.AddJobInvisible(16, 32, 19, new WorkHospital3(), false);
				i++;
			}
			i = 0;
			while ((float)i < (float)pizzaPlaces * additionalJobRatio)
			{
				AppBuilding bdg = (AppBuilding)base.GetRandomBuilding(0);
				bdg.BuildingType = City.BuildingTypes[4];
				Job j = new Job();
				j.Building = bdg;
				j.PrototypeTask = new WorkPizzaGuy();
				j.PrototypeTask.StartPeriod = 16;
				j.PrototypeTask.EndPeriod = 32;
				j.PrototypeTask.Weekend = (i % 2 == 0);
				bdg.Offerings.Add(j);
				j = new Job();
				j.Building = bdg;
				j.PrototypeTask = new WorkPizzaGuy();
				j.PrototypeTask.StartPeriod = 38;
				j.PrototypeTask.EndPeriod = 44;
				j.PrototypeTask.Weekend = (i % 2 == 0);
				bdg.Offerings.Add(j);
				i++;
			}
			i = 0;
			while ((float)i < (float)pharmas * additionalJobRatio)
			{
				AppBuilding bdg = (AppBuilding)base.GetRandomBuilding(0);
				bdg.BuildingType = City.BuildingTypes[17];
				Job j = new Job();
				j.Building = bdg;
				j.PrototypeTask = new WorkDrugRep();
				j.PrototypeTask.StartPeriod = 16;
				j.PrototypeTask.EndPeriod = 32;
				bdg.Offerings.Add(j);
				i++;
			}
			for (i = 0; i < 2; i++)
			{
				this.AddFastFood(16, 32, true, false, false);
				this.AddFastFood(36, 42, true, false, false);
				this.AddFastFood(16, 32, false, true, false);
				this.AddFastFood(16, 32, false, false, true);
			}
			this.AddFastFood(36, 42, false, true, false);
			int additionalApts = 0;
			if (A.ST.Multiplayer)
			{
				additionalApts = Math.Max(0, A.SS.ExpectedMultiplayerPlayers - 2);
			}
			for (i = 0; i < apartments + additionalApts; i++)
			{
				AppBuilding bdg = this.GetRandomBuilding(this.downtownAve, this.downtownStreet, false, 4f, 30);
				if (i < 1)
				{
					bdg = this.GetRandomBuilding(this.downtownAve, this.downtownStreet, true, 2f, 30);
				}
				bdg = new Dwelling(bdg.Block, bdg.Lot, City.BuildingTypes[1]);
				base[bdg.Avenue, bdg.Street, bdg.Lot] = bdg;
				Offering o = new DwellingOffer();
				float d = this.Distance(this.downtownAve, this.downtownStreet, bdg.Avenue, bdg.Street);
				bdg.Rent = (int)Math.Max(200f, 1200f * (1f - d / 7f));
				o.Building = bdg;
				bdg.Offerings.Add(o);
			}
			for (i = 0; i < 3; i++)
			{
				AppBuilding b = (AppBuilding)base.GetRandomBuilding(0);
				b.BuildingType = City.BuildingTypes[12];
				b.Prices = new float[A.ST.PurchasableItems.Count];
				for (int k = 0; k < b.Prices.Length; k++)
				{
					b.Prices[k] = (float)(A.ST.Random.NextDouble() * 0.2 + 0.9);
				}
				b.SaleDiscounts = new float[A.ST.PurchasableItems.Count];
			}
			base.GetRandomBuilding(0).BuildingType = City.BuildingTypes[9];
			base.GetRandomBuilding(0).BuildingType = City.BuildingTypes[11];
			base.GetRandomBuilding(0).BuildingType = City.BuildingTypes[13];
			base.GetRandomBuilding(0).BuildingType = City.BuildingTypes[14];
			base.GetRandomBuilding(0).BuildingType = City.BuildingTypes[15];
			base.GetRandomBuilding(0).BuildingType = City.BuildingTypes[16];
			this.CreateBanks();
			blocks = this.blocks;
			upperBound = blocks.GetUpperBound(0);
			upperBound2 = blocks.GetUpperBound(1);
			for (int l = blocks.GetLowerBound(0); l <= upperBound; l++)
			{
				for (int m = blocks.GetLowerBound(1); m <= upperBound2; m++)
				{
					CityBlock block = blocks[l, m];
					for (i = 0; i < block.NumLots; i++)
					{
						if (block[i] != null)
						{
							this.buildingByIDcache.Add(((AppBuilding)block[i]).ID, block[i]);
						}
					}
				}
			}
			Bus bus = new Bus(this.downtownAve, 0, true, 1);
			this.Buses.Add(bus);
			bus = new Bus(this.downtownAve, 2, true, -1);
			this.Buses.Add(bus);
			bus = new Bus(this.downtownAve, 3, true, 1);
			this.Buses.Add(bus);
			bus = new Bus(this.downtownAve, 4, true, -1);
			this.Buses.Add(bus);
			bus = new Bus(this.downtownAve, 5, true, 1);
			this.Buses.Add(bus);
			bus = new Bus(this.downtownAve, 7, true, -1);
			this.Buses.Add(bus);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0004AB9C File Offset: 0x00049B9C
		public void AddJobInvisible(int startPeriod, int endPeriod, int buildingTypeIndex, WorkTask prototypeTask, bool weekend)
		{
			int i = 0;
			int MaxTries = 50;
			while (i++ < MaxTries)
			{
				AppBuilding b = (AppBuilding)base.GetRandomBuilding(buildingTypeIndex);
				if (b != null && b.Offerings.Count < (i + 10) / 10)
				{
					Job j = new Job();
					j.Building = b;
					j.PrototypeTask = prototypeTask;
					j.PrototypeTask.StartPeriod = startPeriod;
					j.PrototypeTask.EndPeriod = endPeriod;
					j.PrototypeTask.Weekend = weekend;
					b.Offerings.Add(j);
					break;
				}
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0004AC40 File Offset: 0x00049C40
		public void CreateCourses(int startPeriod, int endPeriod, bool weekend)
		{
			this.AddCourse(A.R.GetString("Food Service Mgt I"), A.R.GetString("Topics included food preparation techniques, food safety procedures, and supervision techniques."), 975f, 520, startPeriod, endPeriod, weekend, null);
			this.AddCourse(A.R.GetString("Intro to Data Entry"), A.R.GetString("Course covering data entry formats and tools as well as data security procedures."), 2975f, 1040, startPeriod, endPeriod, weekend, null);
			this.AddCourse(A.R.GetString("IT Management"), A.R.GetString("Studied personnel supervision, planning and control, and It budgeting."), 4975f, 2080, startPeriod, endPeriod, weekend, null);
			this.AddCourse(A.R.GetString("Associates Degree"), A.R.GetString("Full associates degree program covering multiple disciplines."), 9975f, 4160, startPeriod, endPeriod, weekend, null);
			this.AddCourse(A.R.GetString("Bachelors Degree"), A.R.GetString("Four-year multidisciplinary educational program."), 29975f, 8320, startPeriod, endPeriod, weekend, null);
			this.AddCourse(A.R.GetString("Web Design"), A.R.GetString("Course providing general instruction in website design."), 2975f, 1040, startPeriod, endPeriod, weekend, null);
			this.AddCourse(A.R.GetString("Nursing Degree"), A.R.GetString("Two-year nursing program."), 13475f, 4160, startPeriod, endPeriod, weekend, null);
		}

		/// <summary>
		/// Finds a random building within the distance from the street and avenue intersection.
		/// If hasn't found one in n tries, returns another one.
		/// </summary>
		/// <param name="avenue"></param>
		/// <param name="street"></param>
		/// <param name="distance"></param>
		/// <param name="tries"></param>
		/// <returns></returns>
		// Token: 0x06000520 RID: 1312 RVA: 0x0004ADB4 File Offset: 0x00049DB4
		public AppBuilding GetRandomBuilding(int avenue, int street, bool closeTo, float distance, int tries)
		{
			while (tries-- > 0)
			{
				AppBuilding b = (AppBuilding)base.GetRandomBuilding(0);
				float d = this.Distance(b.Avenue, b.Street, avenue, street);
				if ((closeTo && d < distance) || (!closeTo && d > distance))
				{
					return b;
				}
			}
			return (AppBuilding)base.GetRandomBuilding(0);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0004AE2C File Offset: 0x00049E2C
		public float Distance(int ave1, int street1, int ave2, int street2)
		{
			return (float)Math.Pow(Math.Pow((double)(2 * (ave1 - ave2)), 2.0) + Math.Pow((double)(street1 - street2), 2.0), 0.5);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0004AE78 File Offset: 0x00049E78
		public void AddFastFood(int startPeriod, int endPeriod, bool cashierOpening, bool shiftOpening, bool mgrOpening)
		{
			Building bdg = this.GetRandomBuilding(this.downtownAve, this.downtownStreet, true, 3.1f, 30);
			int busyness = 2;
			FastFoodStore ffs = new FastFoodStore(bdg.Block, bdg.Lot, City.BuildingTypes[2], busyness);
			bdg = ffs;
			base[bdg.Avenue, bdg.Street, bdg.Lot] = bdg;
			ffs.AddGenericWorker(new WorkCounterFastFood(0));
			ffs.AddGenericWorker(new WorkMgrFastFood(0));
			for (int i = 0; i < 2; i++)
			{
				WorkTask t = null;
				if (shiftOpening)
				{
					ffs.AddGenericWorker(new WorkCounterFastFood(1));
					t = new WorkMgrFastFood(1);
				}
				else if (cashierOpening)
				{
					ffs.AddGenericWorker(new WorkMgrFastFood(1));
					t = new WorkCounterFastFood(1);
				}
				else if (mgrOpening)
				{
					ffs.AddGenericWorker(new WorkCounterFastFood(1));
					t = new WorkStoreMgrFastFood(1);
				}
				t.Weekend = (i == 1);
				if (A.SS.HealthInsuranceForFastFoodJobs)
				{
					t.HealthInsurance = new InsurancePolicy(25f);
				}
				ffs.Offerings.Add(new Job(ffs, t, startPeriod, endPeriod));
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0004AFC0 File Offset: 0x00049FC0
		public void AddOffice(int startPeriod, int endPeriod, bool deskOpening, bool supervisorOpening, bool mgrOpening)
		{
			int i = 0;
			int MaxTries = 50;
			while (i++ < MaxTries)
			{
				AppBuilding b = (AppBuilding)base.GetRandomBuilding(3);
				if (b != null && b.Offerings.Count < (i + 10) / 10)
				{
					Job j = new Job();
					j.Building = b;
					j.PrototypeTask = new WorkOfficeDesk();
					j.PrototypeTask.StartPeriod = startPeriod;
					j.PrototypeTask.EndPeriod = endPeriod;
					((WorkOfficeDesk)j.PrototypeTask).chair = 3;
					int fillDesks = 3;
					if (deskOpening)
					{
						b.Offerings.Add(j);
					}
					else
					{
						fillDesks = 4;
					}
					for (int d = 0; d < fillDesks; d++)
					{
						VBPFPerson p = this.AddGenericPerson(j, b);
						((WorkOfficeDesk)p.Task).chair = d;
					}
					j = new Job();
					j.Building = b;
					j.PrototypeTask = new WorkOfficeSup();
					j.PrototypeTask.StartPeriod = startPeriod;
					j.PrototypeTask.EndPeriod = endPeriod;
					((WorkOfficeSup)j.PrototypeTask).chair = 4;
					if (supervisorOpening)
					{
						b.Offerings.Add(j);
					}
					else
					{
						VBPFPerson p = this.AddGenericPerson(j, b);
					}
					j = new Job();
					j.Building = b;
					j.PrototypeTask = new WorkOfficeMgr();
					j.PrototypeTask.StartPeriod = startPeriod;
					j.PrototypeTask.EndPeriod = endPeriod;
					((WorkOfficeMgr)j.PrototypeTask).chair = 5;
					if (mgrOpening)
					{
						b.Offerings.Add(j);
					}
					else
					{
						VBPFPerson p = this.AddGenericPerson(j, b);
					}
					break;
				}
			}
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0004B190 File Offset: 0x0004A190
		public void AddCourse(string name, string resumeDescription, float cost, int hours, int startPeriod, int endPeriod, bool weekend, string prerequisite)
		{
			int maxTries = 150;
			int tries = 0;
			AppBuilding b = null;
			while ((b == null || b.Offerings.Count > 1) && tries++ < maxTries)
			{
				b = (AppBuilding)base.GetRandomBuilding(5);
			}
			int hoursPerDay = (endPeriod - startPeriod) / 2;
			if (b != null)
			{
				Course c = new Course();
				c.Building = b;
				c.PrototypeTask = new AttendClass();
				c.PrototypeTask.StartPeriod = startPeriod;
				c.PrototypeTask.EndPeriod = endPeriod;
				c.Name = name;
				c.ResumeDescription = resumeDescription;
				c.Cost = cost;
				c.Days = Math.Min(hours / hoursPerDay, 1560);
				if (weekend)
				{
					c.Days = Math.Min(c.Days, 624);
				}
				c.PrototypeTask.Weekend = weekend;
				c.Prerequisite = prerequisite;
				b.Offerings.Add(c);
				int genericStudents = 6;
				if (A.ST.Multiplayer)
				{
					genericStudents -= 2;
				}
				for (int i = 0; i < genericStudents; i++)
				{
					VBPFPerson p = this.AddGenericPerson(c, b);
					((AttendClass)p.Task).Course = c;
					c.Students.Add(p);
				}
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0004B300 File Offset: 0x0004A300
		protected VBPFPerson AddGenericPerson(Offering o, AppBuilding b)
		{
			VBPFPerson p = new VBPFPerson();
			Task task = o.CreateTask();
			task.Building = b;
			task.Owner = p;
			p.Task = task;
			A.I.Subscribe(p, A.ST.Now.AddHours((double)((float)task.StartPeriod / 2f) - (0.20000000298023224 + 0.10000000149011612 * A.ST.Random.NextDouble())));
			return p;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0004B388 File Offset: 0x0004A388
		protected void CreateBanks()
		{
			int i = 0;
			float[] checking = this.GenerateSpreadRandoms(3, 0.25f, 50, A.ST.Random);
			float[] savings = this.GenerateSpreadRandoms(3, 0.25f, 50, A.ST.Random);
			float[] cc = this.GenerateSpreadRandoms(3, 0.25f, 50, A.ST.Random);
			foreach (string name in new string[]
			{
				"HSN Bank",
				"Herald Bank",
				"Olympic Bank"
			})
			{
				AppBuilding bdg = (AppBuilding)base.GetRandomBuilding(0);
				bdg.BuildingType = City.BuildingTypes[8];
				BankAccount o = new CheckingAccount(Utilities.RoundUpToPowerOfTen(50f * checking[i], 1), Utilities.RoundUpToPowerOfTen(1000f * checking[i], 2));
				o.Building = bdg;
				o.BankName = A.R.GetString(name);
				bdg.Offerings.Add(o);
				o = new SavingsAccount(Utilities.RoundUpToPowerOfTen(50f * savings[i], 1), (float)Math.Round(0.025 * (double)(1f - savings[i]) + 0.005, 3), Utilities.RoundUpToPowerOfTen(750f * savings[i], 2));
				o.Building = bdg;
				o.BankName = A.R.GetString(name);
				bdg.Offerings.Add(o);
				o = new CreditCardAccount(Utilities.RoundUpToPowerOfTen(4000f * cc[i], 1), (float)Math.Round(0.02 + 0.12 * (double)(1f - cc[i]), 3), Utilities.RoundUpToPowerOfTen(20f + 80f * cc[i], 1));
				o.Building = bdg;
				o.BankName = A.R.GetString(name);
				bdg.Offerings.Add(o);
				i++;
			}
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0004B598 File Offset: 0x0004A598
		protected float[] GenerateSpreadRandoms(int numValues, float targetSeparation, int maxTries, Random random)
		{
			float[] result = new float[numValues];
			float f = 0f;
			for (int i = 0; i < numValues; i++)
			{
				for (int tries = 0; tries < maxTries; tries++)
				{
					bool bad = false;
					f = (float)random.NextDouble();
					for (int j = 0; j < i; j++)
					{
						if (Math.Abs(f - result[j]) < targetSeparation)
						{
							bad = true;
							break;
						}
					}
					if (!bad)
					{
						break;
					}
				}
				result[i] = f;
			}
			return result;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0004B630 File Offset: 0x0004A630
		public AppBuilding BuildingByID(long ID)
		{
			return (AppBuilding)this.buildingByIDcache[ID];
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0004B658 File Offset: 0x0004A658
		public ArrayList GetOfferings(Type type)
		{
			ArrayList i = new ArrayList();
			CityBlock[,] blocks = this.blocks;
			int upperBound = blocks.GetUpperBound(0);
			int upperBound2 = blocks.GetUpperBound(1);
			for (int k = blocks.GetLowerBound(0); k <= upperBound; k++)
			{
				for (int l = blocks.GetLowerBound(1); l <= upperBound2; l++)
				{
					CityBlock block = blocks[k, l];
					for (int j = 0; j < block.NumLots; j++)
					{
						if (block[j] != null)
						{
							AppBuilding bldg = (AppBuilding)block[j];
							foreach (object obj in bldg.Offerings)
							{
								Offering o = (Offering)obj;
								if (o.GetType() == type)
								{
									i.Add(o);
								}
							}
						}
					}
				}
			}
			return i;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0004B7A0 File Offset: 0x0004A7A0
		public ArrayList GetOfferings()
		{
			ArrayList i = new ArrayList();
			CityBlock[,] blocks = this.blocks;
			int upperBound = blocks.GetUpperBound(0);
			int upperBound2 = blocks.GetUpperBound(1);
			for (int k = blocks.GetLowerBound(0); k <= upperBound; k++)
			{
				for (int l = blocks.GetLowerBound(1); l <= upperBound2; l++)
				{
					CityBlock block = blocks[k, l];
					for (int j = 0; j < block.NumLots; j++)
					{
						if (block[j] != null)
						{
							AppBuilding bldg = (AppBuilding)block[j];
							foreach (object obj in bldg.Offerings)
							{
								Offering o = (Offering)obj;
								i.Add(o);
							}
						}
					}
				}
			}
			return i;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0004B8D0 File Offset: 0x0004A8D0
		public ArrayList GetBuildings()
		{
			ArrayList i = new ArrayList();
			CityBlock[,] blocks = this.blocks;
			int upperBound = blocks.GetUpperBound(0);
			int upperBound2 = blocks.GetUpperBound(1);
			for (int k = blocks.GetLowerBound(0); k <= upperBound; k++)
			{
				for (int l = blocks.GetLowerBound(1); l <= upperBound2; l++)
				{
					CityBlock block = blocks[k, l];
					for (int j = 0; j < block.NumLots; j++)
					{
						if (block[j] != null)
						{
							i.Add(block[j]);
						}
					}
				}
			}
			return i;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0004B98C File Offset: 0x0004A98C
		public Offering GetOffering(long ID)
		{
			ArrayList offerings = this.GetOfferings();
			foreach (object obj in offerings)
			{
				Offering o = (Offering)obj;
				if (o.ID == ID)
				{
					return o;
				}
			}
			return null;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0004BA10 File Offset: 0x0004AA10
		public Bus BusAt(int street, int direction)
		{
			foreach (object obj in this.Buses)
			{
				Bus bus = (Bus)obj;
				if (bus.Location.Y == (float)street && Math.Sign(bus.DY) == direction)
				{
					return bus;
				}
			}
			return null;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0004BAAC File Offset: 0x0004AAAC
		public AppBuilding FindInsideBuilding(AppEntity e)
		{
			AppBuilding inside = null;
			if (e.Dwelling != null && e.Dwelling.Persons.Contains(e.Person))
			{
				inside = e.Dwelling;
			}
			else
			{
				foreach (object obj in e.GetAllTasks())
				{
					Task t = (Task)obj;
					if (t.Building != null && t.Building.Persons.Contains(e.Person))
					{
						inside = t.Building;
						break;
					}
				}
				if (inside == null)
				{
					foreach (object obj2 in this.GetBuildings())
					{
						AppBuilding b = (AppBuilding)obj2;
						if (b.Persons.Count > 0 && b.Persons.Contains(e.Person))
						{
							inside = b;
							break;
						}
					}
				}
			}
			return inside;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0004BC1C File Offset: 0x0004AC1C
		public Offering FindOfferingForTask(Task t)
		{
			ArrayList offerings = this.GetOfferings();
			foreach (object obj in offerings)
			{
				Offering o = (Offering)obj;
				Task t2 = o.PrototypeTask;
				if (t2 != null && t.Building == o.Building && t.GetType() == t2.GetType() && t.StartPeriod == t2.StartPeriod && t.EndPeriod == t2.EndPeriod)
				{
					return o;
				}
			}
			return null;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0004BCE0 File Offset: 0x0004ACE0
		public float LikelihoodOfCrime(Building bldg)
		{
			float minDistance = float.MaxValue;
			ArrayList bldgs = this.GetBuildings();
			foreach (object obj in bldgs)
			{
				Building b = (Building)obj;
				if (b.BuildingType.Index == 10)
				{
					PointF p = City.Transform((float)b.Avenue, (float)b.Street, (float)b.Lot);
					PointF p2 = City.Transform((float)bldg.Avenue, (float)bldg.Street, (float)bldg.Lot);
					minDistance = Math.Min(minDistance, Utilities.DistanceBetweenIsometric(p, p2));
				}
			}
			float result;
			if (minDistance > 500f)
			{
				result = 0f;
			}
			else
			{
				result = (1f - minDistance / 500f) * 0.01f;
			}
			return result;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0004BDE4 File Offset: 0x0004ADE4
		public void SetupCondoOfferings()
		{
			ArrayList dwellings = new ArrayList();
			foreach (object obj in this.GetBuildings())
			{
				AppBuilding b = (AppBuilding)obj;
				if (b is Dwelling && !((Offering)b.Offerings[0]).Taken)
				{
					dwellings.Add(b);
				}
			}
			Utilities.Shuffle(dwellings, A.ST.Random);
			for (int i = 0; i < Math.Max(6, dwellings.Count / 3); i++)
			{
				AppBuilding b = (AppBuilding)dwellings[i];
				b.Offerings.Clear();
				DwellingOffer o = new DwellingOffer();
				o.Condo = true;
				o.Building = b;
				b.Offerings.Add(o);
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0004BEFC File Offset: 0x0004AEFC
		public void AddHealthInsurance(float likelihoodPerBuilding)
		{
			ArrayList buildings = this.GetBuildings();
			foreach (object obj in buildings)
			{
				AppBuilding b = (AppBuilding)obj;
				if (b.Offerings.Count > 0 && b.Offerings[0] is Job && A.ST.Random.NextDouble() < (double)likelihoodPerBuilding)
				{
					bool AllOpen = true;
					foreach (object obj2 in b.Offerings)
					{
						Offering o = (Offering)obj2;
						if (o.Taken)
						{
							AllOpen = false;
						}
					}
					float copay = (new float[]
					{
						10f,
						25f,
						50f
					})[A.ST.Random.Next(3)];
					if (AllOpen)
					{
						foreach (object obj3 in b.Offerings)
						{
							Offering o = (Offering)obj3;
							((WorkTask)o.PrototypeTask).HealthInsurance = new InsurancePolicy(copay);
						}
						foreach (object obj4 in A.ST.Player.Values)
						{
							Player p = (Player)obj4;
							p.SendPeriodicMessage(A.R.GetString("Some jobs in the city have added health insurance coverage."), "", NotificationColor.Green, 5f);
						}
					}
				}
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0004C16C File Offset: 0x0004B16C
		public void Add401Ks(float likelihoodPerBuilding)
		{
			ArrayList buildings = this.GetBuildings();
			foreach (object obj in buildings)
			{
				AppBuilding b = (AppBuilding)obj;
				if (b.Offerings.Count > 0 && b.Offerings[0] is Job && A.ST.Random.NextDouble() < (double)likelihoodPerBuilding)
				{
					bool AllOpen = true;
					foreach (object obj2 in b.Offerings)
					{
						Offering o = (Offering)obj2;
						if (o.Taken)
						{
							AllOpen = false;
						}
					}
					float match = (float)(1 + A.ST.Random.Next(3)) * 0.01f;
					if (AllOpen)
					{
						foreach (object obj3 in b.Offerings)
						{
							Offering o = (Offering)obj3;
							((WorkTask)o.PrototypeTask).R401KMatch = match;
						}
						foreach (object obj4 in A.ST.Player.Values)
						{
							Player p = (Player)obj4;
							p.SendPeriodicMessage(A.R.GetString("Some jobs in the city have added 401K retirement plans."), "", NotificationColor.Green, 5f);
						}
					}
				}
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0004C3D0 File Offset: 0x0004B3D0
		public void RaiseSomeWages(float likelihoodPerJob)
		{
			ArrayList offerings = this.GetOfferings(typeof(Job));
			foreach (object obj in offerings)
			{
				Offering o = (Offering)obj;
				if (!o.Taken && A.ST.Random.NextDouble() < (double)likelihoodPerJob)
				{
					((WorkTask)o.PrototypeTask).HourlyWage *= 1.15f;
					foreach (object obj2 in A.ST.Player.Values)
					{
						Player p = (Player)obj2;
						p.SendPeriodicMessage(A.R.GetString("The rate of pay has increased for some jobs in the city."), "", NotificationColor.Green, 5f);
					}
				}
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0004C510 File Offset: 0x0004B510
		public void DeleteOffering(long ID)
		{
			CityBlock[,] blocks = this.blocks;
			int upperBound = blocks.GetUpperBound(0);
			int upperBound2 = blocks.GetUpperBound(1);
			for (int j = blocks.GetLowerBound(0); j <= upperBound; j++)
			{
				for (int k = blocks.GetLowerBound(1); k <= upperBound2; k++)
				{
					CityBlock block = blocks[j, k];
					for (int i = 0; i < block.NumLots; i++)
					{
						if (block[i] != null)
						{
							AppBuilding bldg = (AppBuilding)block[i];
							foreach (object obj in bldg.Offerings)
							{
								Offering o = (Offering)obj;
								if (o.ID == ID)
								{
									bldg.Offerings.Remove(o);
									return;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400061F RID: 1567
		protected Hashtable buildingByIDcache = new Hashtable();

		// Token: 0x04000620 RID: 1568
		public ArrayList Cars = new ArrayList();

		// Token: 0x04000621 RID: 1569
		public ArrayList Buses = new ArrayList();

		// Token: 0x04000622 RID: 1570
		public ArrayList Pedestrians = new ArrayList();

		// Token: 0x04000623 RID: 1571
		public int downtownAve;

		// Token: 0x04000624 RID: 1572
		public int downtownStreet;

		// Token: 0x04000625 RID: 1573
		public static int[] BuildingHeights;
	}
}
