using System;
using System.Reflection;

namespace KMI.Sim
{
	// Token: 0x02000048 RID: 72
	[Serializable]
	public class MacroAction
	{
		// Token: 0x06000295 RID: 661 RVA: 0x00015314 File Offset: 0x00014314
		public MacroAction()
		{
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0001531F File Offset: 0x0001431F
		public MacroAction(MethodBase method, object[] argumentValues, DateTime timestamp)
		{
			this.method = method;
			this.argumentValues = argumentValues;
			this.timestamp = timestamp;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00015340 File Offset: 0x00014340
		public MethodBase Method
		{
			get
			{
				return this.method;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00015358 File Offset: 0x00014358
		public object[] ArgumentValues
		{
			get
			{
				return this.argumentValues;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00015370 File Offset: 0x00014370
		public DateTime Timestamp
		{
			get
			{
				return this.timestamp;
			}
		}

		// Token: 0x040001B4 RID: 436
		protected MethodBase method;

		// Token: 0x040001B5 RID: 437
		protected object[] argumentValues;

		// Token: 0x040001B6 RID: 438
		protected DateTime timestamp;
	}
}
