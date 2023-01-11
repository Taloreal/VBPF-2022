using System;
using System.Collections;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using KMI.Sim.Academics;
using KMI.Sim.Drawables;
using KMI.Sim.Surveys;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000039 RID: 57
	public class SimStateAdapter : MarshalByRefObject
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600021B RID: 539 RVA: 0x000115A9 File Offset: 0x000105A9
		// (remove) Token: 0x0600021C RID: 540 RVA: 0x000115C2 File Offset: 0x000105C2
		public event PlaySoundDelegate PlaySoundEvent;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600021D RID: 541 RVA: 0x000115DB File Offset: 0x000105DB
		// (remove) Token: 0x0600021E RID: 542 RVA: 0x000115F4 File Offset: 0x000105F4
		public event PlayerMessageDelegate PlayerMessageEvent;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600021F RID: 543 RVA: 0x0001160D File Offset: 0x0001060D
		// (remove) Token: 0x06000220 RID: 544 RVA: 0x00011626 File Offset: 0x00010626
		public event ModalMessageDelegate ModalMessageEvent;

		// Token: 0x06000221 RID: 545 RVA: 0x00011640 File Offset: 0x00010640
		public void FirePlaySoundEvent(string fileName, long entityID, string viewName)
		{
			if (S.I.Client)
			{
				throw new Exception("FirePlaySoundEvent called from client.");
			}
			if (this.PlaySoundEvent != null)
			{
				foreach (PlaySoundDelegate playSoundDelegate in this.PlaySoundEvent.GetInvocationList())
				{
					try
					{
						playSoundDelegate.BeginInvoke(fileName, entityID, viewName, new AsyncCallback(this.PlaySoundCallback), playSoundDelegate);
					}
					catch (SocketException)
					{
						this.PlaySoundEvent = (PlaySoundDelegate)Delegate.Remove(this.PlaySoundEvent, playSoundDelegate);
					}
				}
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000116EC File Offset: 0x000106EC
		public void PlaySoundCallback(IAsyncResult ar)
		{
			PlaySoundDelegate playSoundDelegate = (PlaySoundDelegate)ar.AsyncState;
			playSoundDelegate.EndInvoke(ar);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00011710 File Offset: 0x00010710
		public void FirePlayerMessageEvent(PlayerMessage message)
		{
			if (S.I.Client)
			{
				throw new Exception("FirePlayerMessageEvent called from client.");
			}
			if (this.PlayerMessageEvent != null)
			{
				foreach (PlayerMessageDelegate playerMessageDelegate in this.PlayerMessageEvent.GetInvocationList())
				{
					try
					{
						playerMessageDelegate.BeginInvoke(message, new AsyncCallback(this.PlayerMessageCallback), playerMessageDelegate);
					}
					catch (SocketException)
					{
						this.PlayerMessageEvent = (PlayerMessageDelegate)Delegate.Remove(this.PlayerMessageEvent, playerMessageDelegate);
					}
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000117BC File Offset: 0x000107BC
		public void PlayerMessageCallback(IAsyncResult ar)
		{
			PlayerMessageDelegate playerMessageDelegate = (PlayerMessageDelegate)ar.AsyncState;
			playerMessageDelegate.EndInvoke(ar);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000117E0 File Offset: 0x000107E0
		public void FireModalMessageEvent(ModalMessage message)
		{
			if (S.I.Client)
			{
				throw new Exception("FireModalMessageEvent called from client.");
			}
			if (this.ModalMessageEvent != null)
			{
				foreach (ModalMessageDelegate modalMessageDelegate in this.ModalMessageEvent.GetInvocationList())
				{
					try
					{
						modalMessageDelegate.BeginInvoke(message, new AsyncCallback(this.ModalMessageCallback), modalMessageDelegate);
					}
					catch (SocketException)
					{
						this.ModalMessageEvent = (ModalMessageDelegate)Delegate.Remove(this.ModalMessageEvent, modalMessageDelegate);
					}
				}
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0001188C File Offset: 0x0001088C
		public void ModalMessageCallback(IAsyncResult ar)
		{
			ModalMessageDelegate modalMessageDelegate = (ModalMessageDelegate)ar.AsyncState;
			modalMessageDelegate.EndInvoke(ar);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000118BC File Offset: 0x000108BC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool Ping()
		{
			return true;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000118D0 File Offset: 0x000108D0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void ProvideCash(long entityID, float amount)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			entity.GL.Post("Cash", amount, "Paid-in Capital");
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000118FC File Offset: 0x000108FC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual SimStateAdapter.ViewUpdate GetViewUpdate(string viewName, long entityID, params object[] args)
		{
			Entity entity = null;
			if (entityID != -1L || !S.I.SafeViewsForNoEntity.Contains(viewName))
			{
				entity = SimStateAdapter.CheckEntityExists(entityID);
			}
			SimStateAdapter.ViewUpdate viewUpdate = new SimStateAdapter.ViewUpdate();
			viewUpdate.Drawables = S.I.View(viewName).BuildDrawables(entityID, args);
			viewUpdate.Now = S.ST.Now;
			viewUpdate.CurrentWeek = S.ST.CurrentWeek;
			if (entity != null)
			{
				viewUpdate.Cash = entity.CriticalResourceBalance();
			}
			viewUpdate.EntityNames = S.ST.EntityNameTable();
			return viewUpdate;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00011998 File Offset: 0x00010998
		[MethodImpl(MethodImplOptions.Synchronized)]
		public GeneralLedger GetGL(long entityID)
		{
			SimStateAdapter.CheckEntityExists(entityID);
			return ((Entity)this.simState.Entity[entityID]).GL;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000119D4 File Offset: 0x000109D4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmActionsJournal.Input getActionsJournal(long entityID)
		{
			if (entityID != -1L)
			{
				SimStateAdapter.CheckEntityExists(entityID);
			}
			frmActionsJournal.Input result = default(frmActionsJournal.Input);
			result.Journals = new ArrayList();
			if (entityID == -1L)
			{
				foreach (object obj in S.ST.Entity.Values)
				{
					Entity entity = (Entity)obj;
					result.Journals.Add(entity.Journal);
				}
				foreach (object obj2 in S.ST.RetiredEntity.Values)
				{
					Entity entity = (Entity)obj2;
					result.Journals.Add(entity.Journal);
				}
			}
			else
			{
				Entity entity = (Entity)S.ST.Entity[entityID];
				result.Journals.Add(entity.Journal);
			}
			result.StartDate = S.ST.SimSettings.StartDate;
			result.EndDate = S.ST.Now;
			return result;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00011B5C File Offset: 0x00010B5C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int getHumanPlayerCount()
		{
			this.LogMethodCall(new object[0]);
			int num = 0;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player.PlayerType == PlayerType.Human)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00011BF8 File Offset: 0x00010BF8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual frmScoreboard.Input getScoreboard(bool showAIOwnedEntities)
		{
			this.LogMethodCall(new object[0]);
			frmScoreboard.Input result = default(frmScoreboard.Input);
			result.ScoreFriendlyName = Journal.ScoreSeriesName;
			Hashtable hashtable = new Hashtable();
			ArrayList arrayList = new ArrayList(S.ST.Entity.Values);
			foreach (object obj in arrayList)
			{
				Entity entity = (Entity)obj;
				if (showAIOwnedEntities || !entity.AI)
				{
					ArrayList arrayList2 = entity.Journal.NumericDataSeries(Journal.ScoreSeriesName);
					string key = entity.Player.PlayerName;
					if (entity.AI)
					{
						key = entity.Name;
					}
					if (hashtable.ContainsKey(key))
					{
						ArrayList arrayList3 = (ArrayList)hashtable[key];
						for (int i = 0; i < arrayList2.Count; i++)
						{
							if (i < arrayList3.Count)
							{
								arrayList3[i] = (float)arrayList3[i] + (float)arrayList2[i];
							}
							else
							{
								arrayList3.Add(arrayList2[i]);
							}
						}
					}
					else
					{
						hashtable.Add(key, arrayList2.Clone());
					}
				}
			}
			result.EntityNames = new string[hashtable.Count];
			hashtable.Keys.CopyTo(result.EntityNames, 0);
			result.Scores = new ArrayList[hashtable.Count];
			hashtable.Values.CopyTo(result.Scores, 0);
			return result;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00011DF4 File Offset: 0x00010DF4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SimSettings getSimSettings()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.SimSettings;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00011E20 File Offset: 0x00010E20
		[MethodImpl(MethodImplOptions.Synchronized)]
		public byte[] getPdfAssignment()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.SimSettings.PdfAssignment;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00011E50 File Offset: 0x00010E50
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool getMultiplayer()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.Multiplayer;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00011E7C File Offset: 0x00010E7C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool RoleBasedMultiplayer()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.RoleBasedMultiplayer;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00011EA8 File Offset: 0x00010EA8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Player CreateClientPlayer(string playerName, string password)
		{
			if (S.ST.Multiplayer && S.I.UserAdminSettings.PasswordsForMultiplayer && (password.Length < 3 || !S.ST.ValidateMultiplayerTeamPassword(playerName, password)))
			{
				throw new frmJoinMultiplayerSession.BadTeamPasswordException();
			}
			return this.CreatePlayer(playerName, PlayerType.Human);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00011F0C File Offset: 0x00010F0C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Player CreatePlayer(string playerName, PlayerType playerType)
		{
			this.LogMethodCall(new object[]
			{
				playerName,
				playerType
			});
			Player player = null;
			Simulator instance = Simulator.Instance;
			foreach (object obj in this.simState.Player.Values)
			{
				Player player2 = (Player)obj;
				if (player2.PlayerName.ToUpper() == playerName.ToUpper())
				{
					player = player2;
				}
			}
			if (player == null)
			{
				player = S.I.SimFactory.CreatePlayer(playerName, playerType);
				this.simState.Player.Add(playerName, player);
			}
			else if (!this.simState.RoleBasedMultiplayer)
			{
				player.SendMessage(S.R.GetString("Welcome back, {0}.", new object[]
				{
					player.PlayerName
				}), "", NotificationColor.Green);
			}
			return player;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00012048 File Offset: 0x00011048
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string GetEntityPlayer(long entityID)
		{
			this.LogMethodCall(new object[]
			{
				entityID
			});
			string result;
			if (this.simState.Entity.Count == 0)
			{
				result = null;
			}
			else
			{
				SimStateAdapter.CheckEntityExists(entityID);
				Entity entity = (Entity)this.simState.Entity[entityID];
				result = entity.Player.PlayerName;
			}
			return result;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000120C0 File Offset: 0x000110C0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int getCurrentWeek()
		{
			this.LogMethodCall(new object[0]);
			return Simulator.Instance.SimState.CurrentWeek;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000120F0 File Offset: 0x000110F0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Entity TryAddEntity(string playerName, string entityName)
		{
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Name.ToUpper() == entityName.ToUpper())
				{
					throw new SimApplicationException(S.R.GetString("That name is already taken. Please try another."));
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj2;
				if (entity.Name.ToUpper() == entityName.ToUpper())
				{
					throw new SimApplicationException(S.R.GetString("A previously existing {0} had that name. Please try another.", new object[]
					{
						S.I.EntityName.ToLower()
					}));
				}
			}
			Entity entity2 = S.I.SimFactory.CreateEntity((Player)S.ST.Player[playerName], entityName);
			S.ST.Entity.Add(entity2.ID, entity2);
			return entity2;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00012284 File Offset: 0x00011284
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void CloseEntity(long entityID)
		{
			this.LogMethodCall(new object[0]);
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			entity.Retire();
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000122B0 File Offset: 0x000112B0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void ChangeEntityOwner(long entityID, string newOwnerName)
		{
			SimStateAdapter.CheckEntityExists(entityID);
			Entity entity = (Entity)this.simState.Entity[entityID];
			foreach (object obj in this.simState.Player.Values)
			{
				Player player = (Player)obj;
				if (player.PlayerName == newOwnerName)
				{
					entity.Player = player;
					return;
				}
			}
			throw new SimApplicationException("Player name not found.");
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0001236C File Offset: 0x0001136C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual float getHumanScore(string seriesName)
		{
			this.LogMethodCall(new object[]
			{
				seriesName
			});
			float num = 0f;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player.PlayerType == PlayerType.Human)
				{
					num += entity.Journal.NumericDataSeriesLastEntry(seriesName);
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj2;
				if (entity.Player.PlayerType == PlayerType.Human)
				{
					num += entity.Journal.NumericDataSeriesLastEntry(seriesName);
				}
			}
			return num;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000124B0 File Offset: 0x000114B0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int Level()
		{
			return S.SS.Level;
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000124CC File Offset: 0x000114CC
		protected SimState simState
		{
			get
			{
				return Simulator.Instance.SimState;
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000124E8 File Offset: 0x000114E8
		public static Entity CheckEntityExists(long entityID)
		{
			if (S.ST.Entity.Contains(entityID))
			{
				return (Entity)S.ST.Entity[entityID];
			}
			EntityNotFoundException ex = new EntityNotFoundException(S.R.GetString("{0} no longer exists.", new object[]
			{
				S.I.EntityName
			}));
			throw ex;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00012560 File Offset: 0x00011560
		public Guid GetSimulatorID()
		{
			return S.I.GUID;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0001257C File Offset: 0x0001157C
		protected void LogMethodCall(params object[] args)
		{
			if (S.MF.DesignerMode)
			{
				if (!S.I.Client)
				{
					StackFrame stackFrame = new StackFrame(1);
					MethodBase method = stackFrame.GetMethod();
					ParameterInfo[] parameters = method.GetParameters();
					S.MF.SaveMacroAction(new MacroAction(method, args, S.ST.Now));
				}
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000125E0 File Offset: 0x000115E0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList getSurveys(string playerName)
		{
			return ((Player)S.ST.Player[playerName]).Surveys;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0001260C File Offset: 0x0001160C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void RenameEntity(long entityID, string newName)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			entity.Name = newName;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0001262C File Offset: 0x0001162C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public long GetAnEntityIdForPlayer(string playerName)
		{
			Entity[] playersEntities = S.ST.GetPlayersEntities(playerName);
			long result;
			if (playersEntities.Length == 0)
			{
				result = -1L;
			}
			else
			{
				result = playersEntities[0].ID;
			}
			return result;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00012664 File Offset: 0x00011664
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string[] GetOtherOwnedEntities(long entityID)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			ArrayList arrayList = new ArrayList();
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity2 = (Entity)obj;
				if (entity != entity2 && entity.Player == entity2.Player)
				{
					arrayList.Add(entity2.Name);
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00012728 File Offset: 0x00011728
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual Survey ConductAndAddSurvey(string playerName, long entityID, ArrayList questions, int numToSurvey, float cost)
		{
			string[] array = new string[S.ST.Entity.Count];
			int num = 0;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				array[num++] = entity.Name;
			}
			Survey survey = S.I.SimFactory.CreateSurvey(entityID, this.simState.Now, array, questions);
			survey.Execute(numToSurvey);
			ArrayList surveys = ((Player)S.ST.Player[playerName]).Surveys;
			surveys.Add(survey);
			if (surveys.Count > Survey.MaxSurveys)
			{
				surveys.RemoveAt(0);
			}
			if (entityID != -1L && S.ST.Entity.ContainsKey(entityID))
			{
				Entity entity = (Entity)S.ST.Entity[entityID];
				if (Survey.BillForSurveys)
				{
					entity.GL.Post("Surveys", cost, "Cash");
				}
				entity.Journal.AddEntry(S.R.GetString("Conducted survey of {0} {1}.", new object[]
				{
					Utilities.FU(survey.Responses.Count),
					Survey.SurveyableObjectName
				}));
			}
			return survey;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000128E0 File Offset: 0x000118E0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SendMessage(string fromPlayerName, string toPlayerName, string message)
		{
			Player player = (Player)S.ST.Player[toPlayerName];
			player.SendMessage(message, fromPlayerName, NotificationColor.Blue);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00012910 File Offset: 0x00011910
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool IsUniqueEntityName(string name)
		{
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Name == name)
				{
					return false;
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj2;
				if (entity.Name == name)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00012A08 File Offset: 0x00011A08
		[MethodImpl(MethodImplOptions.Synchronized)]
		public AcademicGod GetAcademicGod()
		{
			return S.ST.GetAcademicGod();
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00012A24 File Offset: 0x00011A24
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void SetRunTo(DateTime date)
		{
			S.ST.RunToDate = date;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00012A34 File Offset: 0x00011A34
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmRunTo.Input GetRunTo()
		{
			return new frmRunTo.Input
			{
				runTo = S.ST.RunToDate,
				now = S.ST.Now
			};
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00012A74 File Offset: 0x00011A74
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void SetRunTo(int daysAhead)
		{
			DateTime dateTime = new DateTime(S.ST.Now.Year, S.ST.Now.Month, S.ST.Now.Day);
			S.ST.RunToDate = dateTime.AddDays((double)daysAhead);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00012AD4 File Offset: 0x00011AD4
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x04000159 RID: 345
		public const int SOUND_NOT_ENTITY_SPECIFIC = -1;

		// Token: 0x0200003A RID: 58
		[Serializable]
		public class ViewUpdate
		{
			// Token: 0x0400015D RID: 349
			public Drawable[] Drawables;

			// Token: 0x0400015E RID: 350
			public DateTime Now;

			// Token: 0x0400015F RID: 351
			public int CurrentWeek;

			// Token: 0x04000160 RID: 352
			public Hashtable EntityNames;

			// Token: 0x04000161 RID: 353
			public float Cash;

			// Token: 0x04000162 RID: 354
			public object AppData;
		}
	}
}
