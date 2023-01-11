using System;
using System.Drawing;

namespace KMI.Sim.Queues
{
	// Token: 0x02000011 RID: 17
	[Serializable]
	public class ProcessingSimQueueSegment : SimQueueSegment
	{
		// Token: 0x060000DF RID: 223 RVA: 0x00007D32 File Offset: 0x00006D32
		public ProcessingSimQueueSegment()
		{
			this.processPoint = this.endPoint;
			this.processingSteps = 0;
			this.countVarianceMin = 0;
			this.countVarianceMax = 1;
			this.processCount = 0;
			this.processOnReverse = false;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00007D6C File Offset: 0x00006D6C
		public override void MoveQueueObjects()
		{
			if (this.reverse)
			{
				if (this.processOnReverse)
				{
					for (int i = 0; i < this.queueObjects.Count; i++)
					{
						ISimQueueObject simQueueObject = (ISimQueueObject)this.queueObjects[i];
						if (simQueueObject.Location.Equals(this.processPoint))
						{
							simQueueObject.Waiting = true;
							this.processCount += S.ST.Random.Next(this.countVarianceMin, this.countVarianceMax);
							if (this.processCount >= this.processingSteps)
							{
								base.MoveQueueObjectBackward(simQueueObject, i);
								if (!simQueueObject.Waiting)
								{
									this.processCount = 0;
								}
							}
						}
						else
						{
							base.MoveQueueObjectBackward(simQueueObject, i);
						}
					}
				}
				else
				{
					for (int i = 0; i < this.queueObjects.Count; i++)
					{
						base.MoveQueueObjectBackward(base[i], i);
					}
				}
			}
			else
			{
				for (int i = this.queueObjects.Count - 1; i >= 0; i--)
				{
					ISimQueueObject simQueueObject = (ISimQueueObject)this.queueObjects[i];
					if (simQueueObject.Location.Equals(this.processPoint))
					{
						simQueueObject.Waiting = true;
						this.processCount += S.ST.Random.Next(this.countVarianceMin, this.countVarianceMax);
						if (this.processCount >= this.processingSteps)
						{
							base.MoveQueueObjectForward(simQueueObject, i);
							if (!simQueueObject.Waiting)
							{
								this.processCount = 0;
							}
						}
					}
					else
					{
						base.MoveQueueObjectForward(simQueueObject, i);
					}
				}
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00007F6C File Offset: 0x00006F6C
		public override bool CanRemoveFromEnd()
		{
			bool flag = base.CanRemoveFromEnd();
			bool result;
			if (this.endPoint.Equals(this.processPoint))
			{
				result = (flag && this.processCount >= this.processingSteps);
			}
			else
			{
				result = flag;
			}
			return result;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00007FC8 File Offset: 0x00006FC8
		public override bool CanRemoveFromStart()
		{
			bool flag = base.CanRemoveFromStart();
			bool result;
			if (this.startPoint.Equals(this.processPoint))
			{
				result = (flag && this.processCount >= this.processingSteps);
			}
			else
			{
				result = flag;
			}
			return result;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00008024 File Offset: 0x00007024
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000803C File Offset: 0x0000703C
		public Point ProcessPoint
		{
			get
			{
				return this.processPoint;
			}
			set
			{
				this.processPoint = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00008048 File Offset: 0x00007048
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00008060 File Offset: 0x00007060
		public int ProcessingSteps
		{
			get
			{
				return this.processingSteps;
			}
			set
			{
				this.processingSteps = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000806C File Offset: 0x0000706C
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00008084 File Offset: 0x00007084
		public int ProcessCount
		{
			get
			{
				return this.processCount;
			}
			set
			{
				this.processCount = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00008090 File Offset: 0x00007090
		// (set) Token: 0x060000EA RID: 234 RVA: 0x000080A8 File Offset: 0x000070A8
		public int CountVarianceMin
		{
			get
			{
				return this.countVarianceMin;
			}
			set
			{
				this.countVarianceMin = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000080B4 File Offset: 0x000070B4
		// (set) Token: 0x060000EC RID: 236 RVA: 0x000080CC File Offset: 0x000070CC
		public int CountVarianceMax
		{
			get
			{
				return this.countVarianceMax;
			}
			set
			{
				this.countVarianceMax = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000ED RID: 237 RVA: 0x000080D8 File Offset: 0x000070D8
		// (set) Token: 0x060000EE RID: 238 RVA: 0x000080F0 File Offset: 0x000070F0
		public bool ProcessOnReverse
		{
			get
			{
				return this.processOnReverse;
			}
			set
			{
				this.processOnReverse = value;
			}
		}

		// Token: 0x0400007D RID: 125
		protected Point processPoint;

		// Token: 0x0400007E RID: 126
		protected int processingSteps;

		// Token: 0x0400007F RID: 127
		protected int processCount;

		// Token: 0x04000080 RID: 128
		protected int countVarianceMin;

		// Token: 0x04000081 RID: 129
		protected int countVarianceMax;

		// Token: 0x04000082 RID: 130
		protected bool processOnReverse;
	}
}
