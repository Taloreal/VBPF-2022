using System;
using System.Collections;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000081 RID: 129
	[Serializable]
	public class Entity : ActiveObject
	{
		// Token: 0x060004FF RID: 1279 RVA: 0x000265B8 File Offset: 0x000255B8
		public Entity(Player player, string name)
		{
			Simulator instance = Simulator.Instance;
			this.player = player;
			this.name = name;
			this.ID = S.ST.GetNextID();
			this.journal = new Journal(name, Journal.JournalNumericDataSeriesNames, (float)Journal.JournalDaysPerPeriod);
			this.complaintBuffer = new ComplaintBuffer(this);
			foreach (string seriesName in this.journal.NumericDataSeriesNames)
			{
				for (int j = 0; j < S.ST.CurrentWeek; j++)
				{
					this.journal.AddNumericData(seriesName, 0f);
				}
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00026670 File Offset: 0x00025670
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x00026688 File Offset: 0x00025688
		public Player Player
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

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x00026694 File Offset: 0x00025694
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x000266AC File Offset: 0x000256AC
		public long ID
		{
			get
			{
				return this.iD;
			}
			set
			{
				this.iD = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x000266B8 File Offset: 0x000256B8
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x000266D0 File Offset: 0x000256D0
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x000266DC File Offset: 0x000256DC
		public Journal Journal
		{
			get
			{
				return this.journal;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x000266F4 File Offset: 0x000256F4
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x0002670C File Offset: 0x0002570C
		public GeneralLedger GL
		{
			get
			{
				return this.gl;
			}
			set
			{
				this.gl = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x00026718 File Offset: 0x00025718
		public bool Retired
		{
			get
			{
				return S.ST.RetiredEntity.ContainsValue(this);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0002673C File Offset: 0x0002573C
		public bool AI
		{
			get
			{
				return this.Player.PlayerType == PlayerType.AI;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0002675C File Offset: 0x0002575C
		public ComplaintBuffer ComplaintBuffer
		{
			get
			{
				return this.complaintBuffer;
			}
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00026774 File Offset: 0x00025774
		public void Retire(ModalMessage message)
		{
			base.Retire();
			S.ST.Entity.Remove(this.ID);
			S.ST.RetiredEntity.Add(this.ID, this);
			this.Player.SendModalMessage(message);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000267D0 File Offset: 0x000257D0
		public override void Retire()
		{
			base.Retire();
			S.ST.Entity.Remove(this.ID);
			S.ST.RetiredEntity.Add(this.ID, this);
			if (this.GL.AccountBalance("Cash") <= 0f)
			{
				if (this.AI)
				{
					PlayerMessage.Broadcast(S.R.GetString("The {0} named {1} has gone out of business!!", new object[]
					{
						S.I.EntityName.ToLower(),
						this.Name
					}), "", NotificationColor.Green);
				}
				else
				{
					PlayerMessage.BroadcastAllBut(this.Player.PlayerName, S.R.GetString("The {0} named {1} has gone out of business!!", new object[]
					{
						S.I.EntityName.ToLower(),
						this.Name
					}), "", NotificationColor.Green);
					if (S.ST.EntityCount(this.Player) > 0)
					{
						this.Player.SendModalMessage(S.R.GetString("Your {0} named {1} has run out of cash and is now out of business. Keep a close eye on your existing businesses! The net worth of the {0} (positive or negative) will be transferred to your remaining {0}(s).", new object[]
						{
							S.I.EntityName.ToLower(),
							this.Name
						}), S.R.GetString("Out of Business"), MessageBoxIcon.Exclamation);
						this.TransferNetWorthUponRetirement();
					}
					else
					{
						this.Player.SendModalMessage(new GameOverMessage(this.Player.PlayerName, S.R.GetString("Your {0} has run out of cash and is now out of business! That's all part of learning. Give it another try!", new object[]
						{
							S.I.EntityName.ToLower()
						})));
					}
				}
			}
			else if (S.ST.EntityCount(this.Player) == 0)
			{
				this.Player.SendModalMessage(new GameOverMessage(this.Player.PlayerName, S.R.GetString("You have closed your only {0}. This simulation is over. Give it another try!", new object[]
				{
					S.I.EntityName.ToLower()
				})));
			}
			else
			{
				this.Player.SendModalMessage(S.R.GetString("The net worth of the {0} (positive or negative) will be transferred to your remaining {0}(s).", new object[]
				{
					S.I.EntityName.ToLower(),
					this.Name
				}), S.R.GetString("Business Closed"), MessageBoxIcon.Exclamation);
				this.TransferNetWorthUponRetirement();
			}
			this.Journal.AddEntry(S.R.GetString("Closed {0} named {1} on {2}.", new string[]
			{
				S.I.EntityName.ToLower(),
				this.Name.ToLower(),
				S.ST.Now.ToLongDateString()
			}));
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00026AB0 File Offset: 0x00025AB0
		protected virtual void TransferNetWorthUponRetirement()
		{
			Entity[] playersEntities = S.ST.GetPlayersEntities(this.Player.PlayerName);
			float num = this.GL.AccountBalance("Cash");
			num -= this.GL.AccountBalance("Liabilities", S.ST.CurrentWeek - 1);
			float amount = num / (float)Math.Max(1, playersEntities.Length);
			foreach (Entity entity in playersEntities)
			{
				entity.GL.Post("Cash", amount, "Paid-in Capital");
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00026B4C File Offset: 0x00025B4C
		public virtual float CriticalResourceBalance()
		{
			return this.GL.AccountBalance("Cash");
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x00026B70 File Offset: 0x00025B70
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

		// Token: 0x0400036F RID: 879
		protected Player player;

		// Token: 0x04000370 RID: 880
		protected long iD;

		// Token: 0x04000371 RID: 881
		protected string name;

		// Token: 0x04000372 RID: 882
		protected Journal journal;

		// Token: 0x04000373 RID: 883
		protected GeneralLedger gl;

		// Token: 0x04000374 RID: 884
		protected ComplaintBuffer complaintBuffer;

		// Token: 0x04000375 RID: 885
		protected Hashtable reserved;
	}
}
