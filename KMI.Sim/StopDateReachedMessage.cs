using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class StopDateReachedMessage : ModalMessage
	{
		// Token: 0x0600029A RID: 666 RVA: 0x00015388 File Offset: 0x00014388
		public StopDateReachedMessage() : base("", null, null, MessageBoxIcon.Hand)
		{
		}
	}
}
