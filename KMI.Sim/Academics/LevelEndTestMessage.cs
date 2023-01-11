using System;
using System.Windows.Forms;

namespace KMI.Sim.Academics
{
	// Token: 0x02000020 RID: 32
	[Serializable]
	public class LevelEndTestMessage : ModalMessage
	{
		// Token: 0x0600016C RID: 364 RVA: 0x0000C6EB File Offset: 0x0000B6EB
		public LevelEndTestMessage(string to, string message, int newLevel, Question[] questions, bool lastLevel) : base(to, message, null, MessageBoxIcon.None)
		{
			this.NewLevel = newLevel;
			this.Questions = questions;
			this.LastLevel = lastLevel;
		}

		// Token: 0x040000EA RID: 234
		public int NewLevel;

		// Token: 0x040000EB RID: 235
		public Question[] Questions;

		// Token: 0x040000EC RID: 236
		public bool LastLevel;
	}
}
