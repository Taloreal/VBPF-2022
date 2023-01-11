using System;
using System.Windows.Forms;

namespace KMI.Sim.Academics
{
	// Token: 0x0200002C RID: 44
	[Serializable]
	public class ShowPageMessage : ModalMessage
	{
		// Token: 0x060001CF RID: 463 RVA: 0x0000EE24 File Offset: 0x0000DE24
		public ShowPageMessage(string to, Page page) : base(to, null, null, MessageBoxIcon.None)
		{
			this.Page = page;
		}

		// Token: 0x0400011F RID: 287
		public Page Page;
	}
}
