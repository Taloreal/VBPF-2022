using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class GameOverMessage : ModalMessage
	{
		// Token: 0x06000148 RID: 328 RVA: 0x0000A870 File Offset: 0x00009870
		public GameOverMessage(string to, string message) : base(to, message, S.R.GetString("Game Over"), MessageBoxIcon.Hand)
		{
		}
	}
}
