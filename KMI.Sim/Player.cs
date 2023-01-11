using System;
using System.Collections;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000073 RID: 115
	[Serializable]
	public class Player
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x0001E1BD File Offset: 0x0001D1BD
		public Player(string playerName, PlayerType playerType)
		{
			this.playerName = playerName;
			this.playerType = playerType;
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0001E1E4 File Offset: 0x0001D1E4
		public string PlayerName
		{
			get
			{
				return this.playerName;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x0001E1FC File Offset: 0x0001D1FC
		public PlayerType PlayerType
		{
			get
			{
				return this.playerType;
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0001E214 File Offset: 0x0001D214
		public void SendMessage(string message, string from, NotificationColor notificationColor)
		{
			if (!S.I.BlockMessage(message))
			{
				if (this.playerType != PlayerType.AI || S.MF.DesignerMode)
				{
					S.SA.FirePlayerMessageEvent(new PlayerMessage(this.PlayerName, message, from, S.ST.Now, notificationColor));
				}
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0001E278 File Offset: 0x0001D278
		public void SendPeriodicMessage(string message, string from, NotificationColor notificationColor, float daysBetweenMessages)
		{
			string key = message + this.PlayerName + from;
			if (S.I.PeriodicMessageTable.ContainsKey(key))
			{
				DateTime d = (DateTime)S.I.PeriodicMessageTable[key];
				if ((S.ST.Now - d).TotalSeconds / 86400.0 < (double)daysBetweenMessages)
				{
					return;
				}
				S.I.PeriodicMessageTable[key] = S.ST.Now;
			}
			else
			{
				S.I.PeriodicMessageTable.Add(key, S.ST.Now);
			}
			this.SendMessage(message, from, notificationColor);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0001E340 File Offset: 0x0001D340
		public void SendModalMessage(string message, string title, MessageBoxIcon icon)
		{
			if (this.playerType != PlayerType.AI)
			{
				S.SA.FireModalMessageEvent(new ModalMessage(this.PlayerName, message, title, icon));
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0001E378 File Offset: 0x0001D378
		public void SendModalMessage(ModalMessage modalMessage)
		{
			if (this.playerType != PlayerType.AI)
			{
				S.SA.FireModalMessageEvent(modalMessage);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0001E3A4 File Offset: 0x0001D3A4
		public ArrayList Surveys
		{
			get
			{
				return this.surveys;
			}
		}

		// Token: 0x040002C0 RID: 704
		protected string playerName;

		// Token: 0x040002C1 RID: 705
		protected PlayerType playerType;

		// Token: 0x040002C2 RID: 706
		protected ArrayList surveys = new ArrayList();
	}
}
