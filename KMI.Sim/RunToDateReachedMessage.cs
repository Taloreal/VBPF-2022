using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000082 RID: 130
	[Serializable]
	public class RunToDateReachedMessage : ModalMessage
	{
		// Token: 0x06000511 RID: 1297 RVA: 0x00026BA3 File Offset: 0x00025BA3
		public RunToDateReachedMessage() : base("", null, null, MessageBoxIcon.Hand)
		{
		}
	}
}
