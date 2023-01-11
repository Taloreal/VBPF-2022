using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000012 RID: 18
	[Serializable]
	public class PlayerMessage
	{
		// Token: 0x060000EF RID: 239 RVA: 0x000080FA File Offset: 0x000070FA
		public PlayerMessage(string to, string message, string from, DateTime date, NotificationColor notificationColor)
		{
			this.to = to;
			this.message = message;
			this.from = from;
			this.date = date;
			this.notificationColor = notificationColor;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x0000812C File Offset: 0x0000712C
		public NotificationColor NotificationColor
		{
			get
			{
				return this.notificationColor;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00008144 File Offset: 0x00007144
		public DateTime Date
		{
			get
			{
				return this.date;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x0000815C File Offset: 0x0000715C
		public string To
		{
			get
			{
				return this.to;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00008174 File Offset: 0x00007174
		public string Message
		{
			get
			{
				return this.message;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000818C File Offset: 0x0000718C
		public string From
		{
			get
			{
				return this.from;
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000081A4 File Offset: 0x000071A4
		public static void Broadcast(string message, string from, NotificationColor notificationColor)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			PlayerMessage playerMessage = new PlayerMessage("All Players", message, from, S.ST.Now, notificationColor);
			S.SA.FirePlayerMessageEvent(playerMessage);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000081F4 File Offset: 0x000071F4
		public static void BroadcastModal(string message, string title, MessageBoxIcon icon)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			ModalMessage modalMessage = new ModalMessage(S.R.GetString("All Players"), message, title, icon);
			S.SA.FireModalMessageEvent(modalMessage);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00008244 File Offset: 0x00007244
		public static void BroadcastAllBut(string playerName, string message, string from, NotificationColor notificationColor)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			foreach (object obj in S.ST.Player.Values)
			{
				Player player = (Player)obj;
				if (!playerName.Equals(player.PlayerName))
				{
					player.SendMessage(message, from, notificationColor);
				}
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000082E8 File Offset: 0x000072E8
		public static void AddTimedMessage(string message, DateTime sendTime, string to, string from, NotificationColor notificationColor)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			PlayerMessage playerMessage = new PlayerMessage(to, message, from, S.ST.Now, notificationColor);
			S.I.Subscribe(new PlayerMessage.TimedMessage(playerMessage), sendTime);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000833C File Offset: 0x0000733C
		public static void AddTimedMessage(string message, DateTime sendTime, string from, NotificationColor notificationColor)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			PlayerMessage playerMessage = new PlayerMessage(null, message, from, S.ST.Now, notificationColor);
			S.I.Subscribe(new PlayerMessage.TimedMessage(playerMessage), sendTime);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000838C File Offset: 0x0000738C
		public static void AddTimedMessage(string message, DateTime sendTime, TimeSpan repeatInterval, string to, string from, NotificationColor notificationColor)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			PlayerMessage playerMessage = new PlayerMessage(to, message, from, S.ST.Now, notificationColor);
			S.I.Subscribe(new PlayerMessage.TimedMessage(playerMessage, repeatInterval), sendTime);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000083E0 File Offset: 0x000073E0
		public static void AddTimedMessage(string message, DateTime sendTime, TimeSpan repeatInterval, string from, NotificationColor notificationColor)
		{
			if (S.I.Client)
			{
				throw new Exception("Can only send messages from server");
			}
			PlayerMessage playerMessage = new PlayerMessage(null, message, from, S.ST.Now, notificationColor);
			S.I.Subscribe(new PlayerMessage.TimedMessage(playerMessage, repeatInterval), sendTime);
		}

		// Token: 0x04000083 RID: 131
		protected NotificationColor notificationColor;

		// Token: 0x04000084 RID: 132
		protected DateTime date;

		// Token: 0x04000085 RID: 133
		protected string to;

		// Token: 0x04000086 RID: 134
		protected string message;

		// Token: 0x04000087 RID: 135
		protected string from;

		// Token: 0x02000014 RID: 20
		protected class TimedMessage : ActiveObject
		{
			// Token: 0x06000105 RID: 261 RVA: 0x00008499 File Offset: 0x00007499
			public TimedMessage(PlayerMessage playerMessage)
			{
				this.playerMessage = playerMessage;
				this.repeatInterval = new TimeSpan(0L);
			}

			// Token: 0x06000106 RID: 262 RVA: 0x000084B8 File Offset: 0x000074B8
			public TimedMessage(PlayerMessage playerMessage, TimeSpan repeatInterval)
			{
				this.playerMessage = playerMessage;
				this.repeatInterval = repeatInterval;
			}

			// Token: 0x06000107 RID: 263 RVA: 0x000084D4 File Offset: 0x000074D4
			public override bool NewStep()
			{
				if (this.playerMessage.To == null)
				{
					PlayerMessage.Broadcast(this.playerMessage.Message, this.playerMessage.From, this.playerMessage.NotificationColor);
				}
				else
				{
					Player player = (Player)S.ST.Player[this.playerMessage.To];
					if (player != null)
					{
						player.SendMessage(this.playerMessage.Message, this.playerMessage.From, this.playerMessage.NotificationColor);
					}
				}
				bool result;
				if (this.repeatInterval > new TimeSpan(0L))
				{
					this.WakeupTime = S.ST.Now + this.repeatInterval;
					result = true;
				}
				else
				{
					S.I.UnSubscribe(this);
					result = false;
				}
				return result;
			}

			// Token: 0x04000089 RID: 137
			protected TimeSpan repeatInterval;

			// Token: 0x0400008A RID: 138
			protected PlayerMessage playerMessage;
		}
	}
}
