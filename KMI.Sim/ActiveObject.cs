using System;

namespace KMI.Sim
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class ActiveObject
	{
		// Token: 0x060000FD RID: 253 RVA: 0x0000843D File Offset: 0x0000743D
		public virtual bool NewStep()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008445 File Offset: 0x00007445
		public virtual void NewHour()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000844D File Offset: 0x0000744D
		public virtual void NewDay()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00008455 File Offset: 0x00007455
		public virtual void NewWeek()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000845D File Offset: 0x0000745D
		public virtual void NewYear()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00008468 File Offset: 0x00007468
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00008480 File Offset: 0x00007480
		public virtual DateTime WakeupTime
		{
			get
			{
				return this.wakeupTime;
			}
			set
			{
				this.wakeupTime = value;
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000848A File Offset: 0x0000748A
		public virtual void Retire()
		{
			S.I.UnSubscribe(this);
		}

		// Token: 0x04000088 RID: 136
		protected DateTime wakeupTime;
	}
}
