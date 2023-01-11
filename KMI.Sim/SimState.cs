using System;
using System.Collections;
using KMI.Sim.Academics;

namespace KMI.Sim
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class SimState
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00003BA4 File Offset: 0x00002BA4
		public SimState(SimSettings simSettings, bool multiplayer)
		{
			if (simSettings.RandomSeed == -1)
			{
				this.random = new Random();
			}
			else
			{
				this.random = new Random(simSettings.RandomSeed);
			}
			this.simSettings = simSettings;
			this.multiplayer = multiplayer;
			for (int i = 0; i < this.perTimePeriodCollection.Length; i++)
			{
				this.perTimePeriodCollection[i] = new ArrayList();
			}
			for (int i = 0; i < this.perTimePeriodCollectionUpdated.Length; i++)
			{
				this.perTimePeriodCollectionUpdated[i] = new ArrayList();
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003D04 File Offset: 0x00002D04
		public virtual void Init()
		{
			this.now = this.simSettings.StartDate;
			this.Player.Add("", S.I.SimFactory.CreatePlayer("", PlayerType.Human));
			this.CreateSpeeds();
			this.SpeedIndex = 0;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00003D58 File Offset: 0x00002D58
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00003D70 File Offset: 0x00002D70
		public bool Multiplayer
		{
			get
			{
				return this.multiplayer;
			}
			set
			{
				this.multiplayer = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00003D7C File Offset: 0x00002D7C
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00003D94 File Offset: 0x00002D94
		public bool RoleBasedMultiplayer
		{
			get
			{
				return this.roleBasedMultiplayer;
			}
			set
			{
				this.roleBasedMultiplayer = value;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003DA0 File Offset: 0x00002DA0
		public Entity[] GetOtherPlayersEntities(string playerName)
		{
			ArrayList arrayList = new ArrayList(this.Entity.Values);
			for (int i = arrayList.Count - 1; i >= 0; i--)
			{
				if (((Entity)arrayList[i]).Player.PlayerName == playerName)
				{
					arrayList.RemoveAt(i);
				}
			}
			return (Entity[])arrayList.ToArray(typeof(Entity));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003E20 File Offset: 0x00002E20
		public Entity[] GetPlayersEntities(string playerName)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player.PlayerName.Equals(playerName))
				{
					arrayList.Add(entity);
				}
			}
			return (Entity[])arrayList.ToArray(typeof(Entity));
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003ECC File Offset: 0x00002ECC
		public Entity[] GetPlayersRetiredEntities(string playerName)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player.PlayerName.Equals(playerName))
				{
					arrayList.Add(entity);
				}
			}
			return (Entity[])arrayList.ToArray(typeof(Entity));
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003F78 File Offset: 0x00002F78
		public Entity[] GetOtherEntities(string entityName)
		{
			ArrayList arrayList = new ArrayList(this.Entity.Values);
			for (int i = arrayList.Count - 1; i >= 0; i--)
			{
				if (((Entity)arrayList[i]).Name == entityName)
				{
					arrayList.RemoveAt(i);
				}
			}
			return (Entity[])arrayList.ToArray(typeof(Entity));
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00003FF4 File Offset: 0x00002FF4
		public SimSettings SimSettings
		{
			get
			{
				return this.simSettings;
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000400C File Offset: 0x0000300C
		public void Step()
		{
			int hour = this.Hour;
			int day = this.Day;
			DayOfWeek dayOfWeek = this.DayOfWeek;
			int month = this.Month;
			int year = this.Year;
			this.now = this.now.AddMilliseconds((double)this.simulatedTimePerStep);
			this.newHour = (this.now.Hour != hour);
			this.newDay = (this.now.Day != day);
			this.newWeek = (this.now.DayOfWeek == S.I.FirstDayOfWeek && dayOfWeek != S.I.FirstDayOfWeek);
			this.newMonth = (this.now.Month != month);
			if (this.newWeek)
			{
				this.newYear = (this.currentWeek % 52 == 0);
				this.currentWeek++;
			}
			else
			{
				this.newYear = false;
			}
			if (this.FrameCounter == 2147483647)
			{
				this.FrameCounter = 0;
			}
			else
			{
				this.FrameCounter++;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004138 File Offset: 0x00003138
		public Random Random
		{
			get
			{
				return this.random;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004150 File Offset: 0x00003150
		public float Season()
		{
			float result;
			if (this.SimSettings.Seasonality)
			{
				result = (float)Math.Sin((double)((float)this.Now.Subtract(new DateTime(2004, 1, 31)).Days * 0.017214207f + -1.5707964f));
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000041B8 File Offset: 0x000031B8
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000041D0 File Offset: 0x000031D0
		public int SpeedIndex
		{
			get
			{
				return this.speedIndex;
			}
			set
			{
				this.speedIndex = value;
				this.SetSpeed(this.speeds[this.speedIndex]);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000041F0 File Offset: 0x000031F0
		public SimSpeed[] Speeds
		{
			get
			{
				return this.speeds;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004208 File Offset: 0x00003208
		protected virtual void CreateSpeeds()
		{
			this.speeds = new SimSpeed[]
			{
				new SimSpeed(300, 1),
				new SimSpeed(125, 1),
				new SimSpeed(0, 1),
				new SimSpeed(0, 11),
				new SimSpeed(0, 101)
			};
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000425D File Offset: 0x0000325D
		protected virtual void SetSpeed(SimSpeed speed)
		{
			S.I.SetSimEngineSpeed(speed);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003C RID: 60 RVA: 0x0000426C File Offset: 0x0000326C
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00004284 File Offset: 0x00003284
		public int SimulatedTimePerStep
		{
			get
			{
				return this.simulatedTimePerStep;
			}
			set
			{
				this.simulatedTimePerStep = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004290 File Offset: 0x00003290
		public DateTime Now
		{
			get
			{
				return this.now;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000042A8 File Offset: 0x000032A8
		public int Hour
		{
			get
			{
				return this.now.Hour;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000042C8 File Offset: 0x000032C8
		public DayOfWeek DayOfWeek
		{
			get
			{
				return this.now.DayOfWeek;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000042E8 File Offset: 0x000032E8
		public int Day
		{
			get
			{
				return this.now.Day;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00004308 File Offset: 0x00003308
		public int Month
		{
			get
			{
				return this.now.Month;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00004328 File Offset: 0x00003328
		public int Year
		{
			get
			{
				return this.now.Year;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00004348 File Offset: 0x00003348
		public bool NewHour
		{
			get
			{
				return this.newHour;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004360 File Offset: 0x00003360
		public bool NewDay
		{
			get
			{
				return this.newDay;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00004378 File Offset: 0x00003378
		public bool NewWeek
		{
			get
			{
				return this.newWeek;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004390 File Offset: 0x00003390
		public bool NewMonth
		{
			get
			{
				return this.newMonth;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000043A8 File Offset: 0x000033A8
		public bool NewYear
		{
			get
			{
				return this.newYear;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000043C0 File Offset: 0x000033C0
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000043D8 File Offset: 0x000033D8
		public Hashtable Entity
		{
			get
			{
				return this.entity;
			}
			set
			{
				this.entity = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000043E4 File Offset: 0x000033E4
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000043FC File Offset: 0x000033FC
		public Hashtable RetiredEntity
		{
			get
			{
				return this.retiredEntity;
			}
			set
			{
				this.retiredEntity = value;
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004408 File Offset: 0x00003408
		public int EntityCount(Player player)
		{
			int num = 0;
			foreach (object obj in this.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player == player)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00004490 File Offset: 0x00003490
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000044A8 File Offset: 0x000034A8
		public Hashtable Player
		{
			get
			{
				return this.player;
			}
			set
			{
				this.player = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000044B4 File Offset: 0x000034B4
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000044CC File Offset: 0x000034CC
		public int CurrentWeek
		{
			get
			{
				return this.currentWeek;
			}
			set
			{
				this.currentWeek = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000044D8 File Offset: 0x000034D8
		public Guid GUID
		{
			get
			{
				return this.guid;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000044F0 File Offset: 0x000034F0
		public int AIPlayerCount
		{
			get
			{
				int num = 0;
				foreach (object obj in this.Entity.Values)
				{
					Entity entity = (Entity)obj;
					if (entity.Player.PlayerType == PlayerType.Human)
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000457C File Offset: 0x0000357C
		public Hashtable Reserved
		{
			get
			{
				if (this.reserved == null)
				{
					this.reserved = new Hashtable();
				}
				return this.reserved;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000045B0 File Offset: 0x000035B0
		internal void NewTimePeriod(Simulator.TimePeriod timePeriod)
		{
			while (this.perTimePeriodCollection[(int)timePeriod].Count > 0)
			{
				ActiveObject activeObject = (ActiveObject)this.perTimePeriodCollection[(int)timePeriod][0];
				this.perTimePeriodCollectionUpdated[(int)timePeriod].Add(activeObject);
				this.perTimePeriodCollection[(int)timePeriod].RemoveAt(0);
				switch (timePeriod)
				{
				case Simulator.TimePeriod.Step:
					if (activeObject.NewStep())
					{
						this.UnSubscribeTimedEvent(activeObject, Simulator.TimePeriod.Step);
						this.eventQueue.Add(activeObject, activeObject);
					}
					break;
				case Simulator.TimePeriod.Hour:
					activeObject.NewHour();
					break;
				case Simulator.TimePeriod.Day:
					activeObject.NewDay();
					break;
				case Simulator.TimePeriod.Week:
					activeObject.NewWeek();
					break;
				case Simulator.TimePeriod.Year:
					activeObject.NewYear();
					break;
				default:
					throw new Exception("Unexpected time period.");
				}
			}
			this.perTimePeriodCollection[(int)timePeriod] = (ArrayList)this.perTimePeriodCollectionUpdated[(int)timePeriod].Clone();
			this.perTimePeriodCollectionUpdated[(int)timePeriod].Clear();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000046B0 File Offset: 0x000036B0
		internal void SubscribeTimedEvent(ActiveObject activeObject, Simulator.TimePeriod timePeriod)
		{
			if (!this.perTimePeriodCollection[(int)timePeriod].Contains(activeObject))
			{
				this.perTimePeriodCollection[(int)timePeriod].Add(activeObject);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000046E0 File Offset: 0x000036E0
		internal void SubscribeTimedEvent(ActiveObject activeObject)
		{
			foreach (ArrayList arrayList in this.perTimePeriodCollection)
			{
				if (!arrayList.Contains(activeObject))
				{
					arrayList.Add(activeObject);
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004720 File Offset: 0x00003720
		internal void UnSubscribeTimedEvent(ActiveObject activeObject, Simulator.TimePeriod timePeriod)
		{
			this.perTimePeriodCollection[(int)timePeriod].Remove(activeObject);
			this.perTimePeriodCollectionUpdated[(int)timePeriod].Remove(activeObject);
			if (timePeriod == Simulator.TimePeriod.Step)
			{
				int num = this.eventQueue.IndexOfValue(activeObject);
				if (num > -1)
				{
					this.eventQueue.RemoveAt(num);
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004780 File Offset: 0x00003780
		internal void UnSubscribeTimedEvent(ActiveObject activeObject)
		{
			for (int i = 0; i < this.perTimePeriodCollection.Length; i++)
			{
				this.UnSubscribeTimedEvent(activeObject, (Simulator.TimePeriod)i);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000047B0 File Offset: 0x000037B0
		internal void UpdateEventQueue()
		{
			int count = this.eventQueue.Count;
			DateTime t = Simulator.Instance.SimState.Now;
			for (int i = 0; i < count; i++)
			{
				ActiveObject activeObject = (ActiveObject)this.eventQueue.GetByIndex(0);
				if (activeObject.WakeupTime > t)
				{
					break;
				}
				this.eventQueue.RemoveAt(0);
				this.perTimePeriodCollection[0].Add(activeObject);
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004834 File Offset: 0x00003834
		public long GetNextID()
		{
			return this.nextID += 1L;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004858 File Offset: 0x00003858
		public Hashtable EntityNameTable()
		{
			Hashtable hashtable = new Hashtable();
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				hashtable.Add(entity.ID, entity.Name);
			}
			return hashtable;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000048E8 File Offset: 0x000038E8
		public bool InSleepQueue(ActiveObject activeObject)
		{
			return this.eventQueue.Contains(activeObject);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004908 File Offset: 0x00003908
		public SortedList InspectSleepQueue()
		{
			return this.eventQueue;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004920 File Offset: 0x00003920
		public Entity GetEntityByName(string name)
		{
			foreach (object obj in this.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Name == name)
				{
					return entity;
				}
			}
			return null;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000049A4 File Offset: 0x000039A4
		public bool ValidateMultiplayerTeamPassword(string teamName, string password)
		{
			bool result;
			if (!this.multiplayerTeamPasswords.ContainsKey(teamName.ToUpper()))
			{
				this.multiplayerTeamPasswords.Add(teamName.ToUpper(), password);
				result = true;
			}
			else
			{
				result = (password.ToUpper() == ((string)this.multiplayerTeamPasswords[teamName.ToUpper()]).ToUpper());
			}
			return result;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004A0C File Offset: 0x00003A0C
		public string GetMultiplayerTeamPassword(string teamName)
		{
			return (string)this.multiplayerTeamPasswords[teamName.ToUpper()];
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004A34 File Offset: 0x00003A34
		public AcademicGod GetAcademicGod()
		{
			foreach (ArrayList arrayList in this.perTimePeriodCollection)
			{
				foreach (object obj in arrayList)
				{
					ActiveObject activeObject = (ActiveObject)obj;
					if (activeObject is AcademicGod)
					{
						return (AcademicGod)activeObject;
					}
				}
			}
			return null;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004AE0 File Offset: 0x00003AE0
		public void DumpActiveObjectList()
		{
			Simulator.TimePeriod[] array = new Simulator.TimePeriod[]
			{
				Simulator.TimePeriod.Step,
				Simulator.TimePeriod.Hour,
				Simulator.TimePeriod.Day,
				Simulator.TimePeriod.Week,
				Simulator.TimePeriod.Year
			};
			foreach (Simulator.TimePeriod timePeriod in array)
			{
				ArrayList arrayList = this.perTimePeriodCollection[(int)timePeriod];
				foreach (object obj in arrayList)
				{
					ActiveObject activeObject = (ActiveObject)obj;
					Console.WriteLine(activeObject.ToString() + " " + timePeriod.ToString());
				}
			}
			foreach (object obj2 in this.eventQueue.Values)
			{
				ActiveObject activeObject = (ActiveObject)obj2;
				Console.WriteLine(activeObject.ToString() + " sleeping");
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004C28 File Offset: 0x00003C28
		public void DumpActiveObjectList(Type type)
		{
			Simulator.TimePeriod[] array = new Simulator.TimePeriod[]
			{
				Simulator.TimePeriod.Step,
				Simulator.TimePeriod.Hour,
				Simulator.TimePeriod.Day,
				Simulator.TimePeriod.Week,
				Simulator.TimePeriod.Year
			};
			foreach (Simulator.TimePeriod timePeriod in array)
			{
				ArrayList arrayList = this.perTimePeriodCollection[(int)timePeriod];
				foreach (object obj in arrayList)
				{
					ActiveObject activeObject = (ActiveObject)obj;
					if (activeObject.GetType() == type)
					{
						Console.WriteLine(activeObject.ToString() + " " + timePeriod.ToString());
					}
				}
			}
			foreach (object obj2 in this.eventQueue.Values)
			{
				ActiveObject activeObject = (ActiveObject)obj2;
				if (activeObject.GetType() == type)
				{
					Console.WriteLine(activeObject.ToString() + " sleeping");
				}
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00004D94 File Offset: 0x00003D94
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00004DAC File Offset: 0x00003DAC
		public DateTime RunToDate
		{
			get
			{
				return this.runToDate;
			}
			set
			{
				this.runToDate = value;
			}
		}

		// Token: 0x04000029 RID: 41
		protected bool multiplayer = false;

		// Token: 0x0400002A RID: 42
		protected bool roleBasedMultiplayer = false;

		// Token: 0x0400002B RID: 43
		protected SimSettings simSettings;

		// Token: 0x0400002C RID: 44
		protected Random random;

		// Token: 0x0400002D RID: 45
		protected int speedIndex;

		// Token: 0x0400002E RID: 46
		protected SimSpeed[] speeds;

		// Token: 0x0400002F RID: 47
		private int simulatedTimePerStep = 60000;

		// Token: 0x04000030 RID: 48
		protected DateTime now = default(DateTime);

		// Token: 0x04000031 RID: 49
		private bool newHour;

		// Token: 0x04000032 RID: 50
		private bool newDay;

		// Token: 0x04000033 RID: 51
		private bool newWeek;

		// Token: 0x04000034 RID: 52
		private bool newMonth;

		// Token: 0x04000035 RID: 53
		private bool newYear;

		// Token: 0x04000036 RID: 54
		protected Hashtable entity = new Hashtable();

		// Token: 0x04000037 RID: 55
		protected Hashtable retiredEntity = new Hashtable();

		// Token: 0x04000038 RID: 56
		protected Hashtable player = new Hashtable();

		// Token: 0x04000039 RID: 57
		protected int currentWeek = 0;

		// Token: 0x0400003A RID: 58
		public int FrameCounter = 0;

		// Token: 0x0400003B RID: 59
		protected Guid guid = Guid.NewGuid();

		// Token: 0x0400003C RID: 60
		protected Hashtable reserved;

		// Token: 0x0400003D RID: 61
		internal ArrayList[] perTimePeriodCollection = new ArrayList[5];

		// Token: 0x0400003E RID: 62
		internal ArrayList[] perTimePeriodCollectionUpdated = new ArrayList[5];

		// Token: 0x0400003F RID: 63
		internal string SavedViewName = "";

		// Token: 0x04000040 RID: 64
		internal long SavedEntityID = -1L;

		// Token: 0x04000041 RID: 65
		internal SortedList eventQueue = new SortedList(new SimState.EventQueueComparer());

		// Token: 0x04000042 RID: 66
		protected long nextID = 0L;

		// Token: 0x04000043 RID: 67
		protected Hashtable multiplayerTeamPasswords = new Hashtable();

		// Token: 0x04000044 RID: 68
		public int PowerLevel = 0;

		// Token: 0x04000045 RID: 69
		public int PowerPoints = 0;

		// Token: 0x04000046 RID: 70
		protected DateTime runToDate = DateTime.MaxValue;

		// Token: 0x02000007 RID: 7
		[Serializable]
		internal class EventQueueComparer : IComparer
		{
			// Token: 0x06000067 RID: 103 RVA: 0x00004DB8 File Offset: 0x00003DB8
			public int Compare(object x, object y)
			{
				int result;
				if (((ActiveObject)x).WakeupTime > ((ActiveObject)y).WakeupTime)
				{
					result = 1;
				}
				else
				{
					result = -1;
				}
				return result;
			}
		}
	}
}
