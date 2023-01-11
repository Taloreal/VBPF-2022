using System;

namespace KMI.Sim
{
	// Token: 0x0200006B RID: 107
	[Serializable]
	public class UserAdminSettings
	{
		// Token: 0x060003E0 RID: 992 RVA: 0x0001C9FC File Offset: 0x0001B9FC
		public UserAdminSettings()
		{
			this.defaultDirectory = null;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0001CA4C File Offset: 0x0001BA4C
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x0001CA64 File Offset: 0x0001BA64
		public string DefaultDirectory
		{
			get
			{
				return this.defaultDirectory;
			}
			set
			{
				this.defaultDirectory = value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x0001CA70 File Offset: 0x0001BA70
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x0001CA88 File Offset: 0x0001BA88
		public string ProxyAddress
		{
			get
			{
				return this.proxyAddress;
			}
			set
			{
				this.proxyAddress = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0001CA94 File Offset: 0x0001BA94
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x0001CAAC File Offset: 0x0001BAAC
		public string ProxyBypassList
		{
			get
			{
				return this.proxyBypassList;
			}
			set
			{
				this.proxyBypassList = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x0001CAB8 File Offset: 0x0001BAB8
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0001CAD0 File Offset: 0x0001BAD0
		public int P
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0001CADC File Offset: 0x0001BADC
		public string GetP()
		{
			int num = this.p;
			if (num <= 23)
			{
				switch (num)
				{
				case 7:
					return "JackRabbit";
				case 8:
				case 10:
					break;
				case 9:
					return "SuperStore";
				case 11:
					return "LearnFast";
				default:
					if (num == 23)
					{
						return "CustomerIsKing";
					}
					break;
				}
			}
			else
			{
				if (num == 39)
				{
					return "LuckyLearners";
				}
				if (num == 47)
				{
					return "CoolSchool";
				}
			}
			return "XGHYMZ";
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0001CB60 File Offset: 0x0001BB60
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x0001CB78 File Offset: 0x0001BB78
		public bool NoSound
		{
			get
			{
				return this.noSound;
			}
			set
			{
				this.noSound = value;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0001CB84 File Offset: 0x0001BB84
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x0001CB9C File Offset: 0x0001BB9C
		public int MultiplayerBasePort
		{
			get
			{
				return this.multiplayerBasePort;
			}
			set
			{
				this.multiplayerBasePort = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0001CBA8 File Offset: 0x0001BBA8
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x0001CBC0 File Offset: 0x0001BBC0
		public int MultiplayerPortCount
		{
			get
			{
				return this.multiplayerPortCount;
			}
			set
			{
				this.multiplayerPortCount = value;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0001CBCC File Offset: 0x0001BBCC
		// (set) Token: 0x060003F1 RID: 1009 RVA: 0x0001CBE4 File Offset: 0x0001BBE4
		public int ClientDrawStepPeriod
		{
			get
			{
				return this.clientDrawStepPeriod;
			}
			set
			{
				this.clientDrawStepPeriod = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0001CBF0 File Offset: 0x0001BBF0
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x0001CC08 File Offset: 0x0001BC08
		public bool PasswordsForMultiplayer
		{
			get
			{
				return this.passwordsForMultiplayer;
			}
			set
			{
				this.passwordsForMultiplayer = value;
			}
		}

		// Token: 0x0400028C RID: 652
		protected bool noSound = false;

		// Token: 0x0400028D RID: 653
		protected int multiplayerBasePort = 20172;

		// Token: 0x0400028E RID: 654
		protected int multiplayerPortCount = 10;

		// Token: 0x0400028F RID: 655
		protected int clientDrawStepPeriod = 50;

		// Token: 0x04000290 RID: 656
		protected bool passwordsForMultiplayer = false;

		// Token: 0x04000291 RID: 657
		protected string language;

		// Token: 0x04000292 RID: 658
		protected string defaultDirectory;

		// Token: 0x04000293 RID: 659
		protected string proxyAddress;

		// Token: 0x04000294 RID: 660
		protected string proxyBypassList;

		// Token: 0x04000295 RID: 661
		protected int p = 11;
	}
}
