using System;
using System.Collections;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// The application specific SimState object, this is the object
	/// that gets serialized during a save.
	/// </summary>
	// Token: 0x0200008A RID: 138
	[Serializable]
	public class AppSimState : SimState
	{
		/// <summary>
		/// Constructs a new SimState for the application.
		/// </summary>
		/// <param name="simSettings">The SimSettings object to use
		/// for the application's state.</param>
		/// <param name="multiplayer">Whether or not this state
		/// is for a multiplayer game.</param>
		// Token: 0x0600043B RID: 1083 RVA: 0x0003B127 File Offset: 0x0003A127
		public AppSimState(SimSettings simSettings, bool multiplayer) : base(simSettings, multiplayer)
		{
		}

		/// <summary>
		/// Initializes various aspects of this AppSimState object.
		/// </summary>
		/// <remarks>
		/// This override must call base.Init().
		/// </remarks>
		// Token: 0x0600043C RID: 1084 RVA: 0x0003B168 File Offset: 0x0003A168
		public override void Init()
		{
			base.Init();
			if (A.ST.Multiplayer)
			{
				frmMultiplayerPlayers f = new frmMultiplayerPlayers();
				f.ShowDialog();
				A.SS.ExpectedMultiplayerPlayers = f.NumPlayers;
			}
			this.phase = (float)(A.ST.Random.NextDouble() * 2.0 * 3.141592653589793);
			this.period = (float)A.ST.Random.Next(360, 1080);
			this.amp = (float)(A.ST.Random.NextDouble() * 0.02 + 0.02);
			string[] names = new string[]
			{
				"Select",
				"Vanyard",
				"Finality",
				"Oppenhizer",
				"FMS",
				"Sun",
				"Unity",
				"Watch Tower",
				"Highpoint",
				"Everlast",
				"Mercury",
				"Titan",
				"Oak",
				"SBU"
			};
			for (int i = 0; i < 14; i++)
			{
				this.MutualFunds.Add(new StockFund(names[i] + " US Stock Fund", 2f, (8f + (float)A.ST.Random.NextDouble() * 2f) / 100f / 365f));
				this.MutualFunds.Add(new StockFund(names[i] + " Intl Stock Fund", 3f, (9f + (float)A.ST.Random.NextDouble() * 2f) / 100f / 365f));
				this.MutualFunds.Add(new BondFund(names[i] + " Bond Fund", (3f + (float)A.ST.Random.NextDouble() * 1f) / 100f / 365f));
				this.MutualFunds.Add(new MoneyMarketFund(names[i] + " Money Market Fund", -(float)A.ST.Random.NextDouble() * 0.001f));
			}
			base.SimulatedTimePerStep = 20000;
			this.PurchasableItems = new ArrayList((PurchasableItem[])TableReader.Read(base.GetType().Assembly, typeof(PurchasableItem), "KMI.VBPF1Lib.Data.PurchasableItems.txt"));
			this.PurchasableCars = new ArrayList((PurchasableItem[])TableReader.Read(base.GetType().Assembly, typeof(PurchasableItem), "KMI.VBPF1Lib.Data.PurchasableCars.txt"));
			this.PurchasableFood = new ArrayList((PurchasableItem[])TableReader.Read(base.GetType().Assembly, typeof(PurchasableItem), "KMI.VBPF1Lib.Data.PurchasableFood.txt"));
			this.PurchasableAutoSupplies = new ArrayList((PurchasableItem[])TableReader.Read(base.GetType().Assembly, typeof(PurchasableItem), "KMI.VBPF1Lib.Data.PurchasableAutoSupplies.txt"));
			this.PurchasableBusTokens = new ArrayList((PurchasableItem[])TableReader.Read(base.GetType().Assembly, typeof(PurchasableItem), "KMI.VBPF1Lib.Data.PurchasableBusTokens.txt"));
			this.UpdateCarAndGasData();
			this.City = new AppCity();
			this.God = new God();
			if (A.ST.Multiplayer)
			{
				A.SS.Level = 2;
				A.SS.Level = 3;
				A.SS.LevelManagementOn = false;
			}
			else
			{
				A.SS.Level = 1;
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0003B534 File Offset: 0x0003A534
		public Fund GetFund(string name)
		{
			foreach (object obj in this.MutualFunds)
			{
				Fund fund = (Fund)obj;
				if (fund.Name == name)
				{
					return fund;
				}
			}
			return null;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0003B5B4 File Offset: 0x0003A5B4
		public float PrimeRate()
		{
			return this.PrimeRate(A.ST.Now);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0003B5D8 File Offset: 0x0003A5D8
		public float PrimeRate(DateTime date)
		{
			float days = (float)(date - new DateTime(2005, 1, 1)).Days;
			return (float)Math.Round(0.05 + (double)(this.amp * (float)Math.Sin((double)((this.phase + days) / this.period))), 3);
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x0003B638 File Offset: 0x0003A638
		public float RealEstateIndex
		{
			get
			{
				int day = A.ST.DayCount / 23 * 23;
				DateTime date = new DateTime(base.Year, base.Month, 17);
				return 1.5f * (200f + (float)day * 14f / 365f * this.PrimeRate(A.SS.StartDate) / this.PrimeRate(date));
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0003B6A4 File Offset: 0x0003A6A4
		public int Period
		{
			get
			{
				int period = base.Hour * 2;
				if (base.Now.Minute >= 30)
				{
					period++;
				}
				return period;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0003B6DC File Offset: 0x0003A6DC
		public bool Weekend
		{
			get
			{
				return A.ST.DayOfWeek == DayOfWeek.Saturday || A.ST.DayOfWeek == DayOfWeek.Sunday;
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0003B70C File Offset: 0x0003A70C
		public void AddAIOneTimeEvent()
		{
			Dance d = new Dance();
			d.OneTimeDay = new DateTime(base.Now.Year, base.Now.Month, base.Now.Day).AddDays(21.0);
			d.StartPeriod = 34;
			d.EndPeriod = 44;
			while (d.Building == null)
			{
				AppBuilding b = (AppBuilding)A.ST.City.GetRandomBuilding(1);
				if (b != null && b.Owner == null)
				{
					d.Building = b;
				}
			}
			d.AddAIAttendees(10);
			this.OneTimeEvents.Add(d.Key, d);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0003B7DC File Offset: 0x0003A7DC
		public Task GetOneTimeEventByID(long id)
		{
			foreach (object obj in this.OneTimeEvents.Values)
			{
				Task t = (Task)obj;
				if (t.ID == id)
				{
					return t;
				}
			}
			return null;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0003B85C File Offset: 0x0003A85C
		public void UpdateCarAndGasData()
		{
			if (((PurchasableItem)this.PurchasableAutoSupplies[0]).Price < 30f)
			{
				foreach (object obj in this.PurchasableAutoSupplies)
				{
					PurchasableItem p = (PurchasableItem)obj;
					if (p.Name.StartsWith("Gas"))
					{
						p.Price *= 1.5f;
					}
				}
				int i = 0;
				foreach (object obj2 in this.PurchasableCars)
				{
					PurchasableItem p = (PurchasableItem)obj2;
					PurchasableItem purchasableItem = p;
					purchasableItem.Description += A.R.GetString(" MPG: {0}.", new object[]
					{
						AppConstants.MPGs[i++]
					});
					p.Description = p.Description.Replace(" 100,000 mile bumper to bumper warranty.", "");
				}
			}
		}

		// Token: 0x040004C7 RID: 1223
		protected float phase;

		// Token: 0x040004C8 RID: 1224
		protected float period;

		// Token: 0x040004C9 RID: 1225
		protected float amp;

		// Token: 0x040004CA RID: 1226
		public God God;

		// Token: 0x040004CB RID: 1227
		public AppCity City;

		// Token: 0x040004CC RID: 1228
		public object[] ViewerOptions1;

		// Token: 0x040004CD RID: 1229
		public Surprise[] Surprises;

		// Token: 0x040004CE RID: 1230
		public ArrayList PurchasableItems;

		// Token: 0x040004CF RID: 1231
		public ArrayList PurchasableCars;

		// Token: 0x040004D0 RID: 1232
		public ArrayList PurchasableFood;

		// Token: 0x040004D1 RID: 1233
		public ArrayList PurchasableAutoSupplies;

		// Token: 0x040004D2 RID: 1234
		public ArrayList PurchasableBusTokens;

		// Token: 0x040004D3 RID: 1235
		public float ElectricityCost = 47.5f;

		// Token: 0x040004D4 RID: 1236
		public float InternetCost = 45f;

		// Token: 0x040004D5 RID: 1237
		public ArrayList MutualFunds = new ArrayList();

		// Token: 0x040004D6 RID: 1238
		public SortedList OneTimeEvents = new SortedList();

		// Token: 0x040004D7 RID: 1239
		public int DayCount = 0;
	}
}
