using System;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000064 RID: 100
	public class ClientEventHandlers : MarshalByRefObject
	{
		// Token: 0x060003B9 RID: 953 RVA: 0x0001B0F8 File Offset: 0x0001A0F8
		private ClientEventHandlers()
		{
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0001B110 File Offset: 0x0001A110
		public void PlaySoundHandler(string fileName, long entityID, string viewName)
		{
			if (S.MF.SoundOn && (S.MF.CurrentEntityID == entityID || entityID == -1L) && S.MF.CurrentViewName == viewName)
			{
				Sound.PlaySoundFromFile(fileName);
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0001B160 File Offset: 0x0001A160
		public void PlayerMessageHandler(PlayerMessage message)
		{
			if ((message.To == S.I.ThisPlayerName && (S.I.MultiplayerRole == null || S.I.MultiplayerRole.ReceivesMessages)) || message.To == S.R.GetString("All Players") || S.I.Host || S.MF.DesignerMode)
			{
				S.MF.Invoke(new ClientEventHandlers.AddPlayerMessageDelegate(S.MF.AddPlayerMessage), new object[]
				{
					message
				});
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001B208 File Offset: 0x0001A208
		public void ModalMessageHandler(ModalMessage message)
		{
			if (message.To == S.I.ThisPlayerName || message.To == S.R.GetString("All Players"))
			{
				if (!S.MF.OptOutModalMessageHook(message))
				{
					S.MF.Invoke(new ClientEventHandlers.AddModalMessageDelegate(S.MF.ShowModalMessage), new object[]
					{
						message
					});
				}
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0001B28C File Offset: 0x0001A28C
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x04000267 RID: 615
		public static ClientEventHandlers Instance = new ClientEventHandlers();

		// Token: 0x02000065 RID: 101
		// (Invoke) Token: 0x060003C0 RID: 960
		private delegate void AddPlayerMessageDelegate(PlayerMessage message);

		// Token: 0x02000066 RID: 102
		// (Invoke) Token: 0x060003C4 RID: 964
		private delegate void AddModalMessageDelegate(ModalMessage message);
	}
}
