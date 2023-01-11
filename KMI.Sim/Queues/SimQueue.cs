using System;
using System.Collections;
using System.Drawing;

namespace KMI.Sim.Queues
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	public class SimQueue
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000CC2C File Offset: 0x0000BC2C
		public SimQueue()
		{
			this.segments = new ArrayList();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000CC44 File Offset: 0x0000BC44
		public virtual ArrayList GetDrawables()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				arrayList.AddRange(simQueueSegment.GetDrawables());
			}
			return arrayList;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000CCC4 File Offset: 0x0000BCC4
		public virtual ArrayList GetQueueObjects()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				arrayList.AddRange(simQueueSegment.QueueObjects);
			}
			return arrayList;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000CD44 File Offset: 0x0000BD44
		public virtual void Clear()
		{
			for (int i = 0; i < this.segments.Count; i++)
			{
				this[i].Clear();
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000CD7C File Offset: 0x0000BD7C
		public virtual void ExecuteStep()
		{
			for (int i = this.segments.Count - 1; i >= 0; i--)
			{
				this[i].MoveQueueObjects();
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000CDB8 File Offset: 0x0000BDB8
		public virtual void AppendSegment(SimQueueSegment segment)
		{
			if (this.SegmentCount == 0)
			{
				this.segments.Add(segment);
			}
			else
			{
				this[this.SegmentCount - 1].Next.Add(segment);
				segment.Previous.Add(this[this.SegmentCount - 1]);
				this.segments.Add(segment);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000CE2C File Offset: 0x0000BE2C
		public virtual void Connect(SimQueue queue)
		{
			if (!this[this.SegmentCount - 1].Next.Contains(queue[0]))
			{
				this[this.SegmentCount - 1].Next.Add(queue[0]);
			}
			if (!queue[0].Previous.Contains(this[this.SegmentCount - 1]))
			{
				queue[0].Previous.Add(this[this.SegmentCount - 1]);
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000CEC4 File Offset: 0x0000BEC4
		public virtual void Disconnect(SimQueue queue)
		{
			if (this[this.SegmentCount - 1].Next.Contains(queue[0]))
			{
				this[this.SegmentCount - 1].Next.Remove(queue[0]);
			}
			if (queue[0].Previous.Contains(this[this.SegmentCount - 1]))
			{
				queue[0].Previous.Remove(this[this.SegmentCount - 1]);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000CF64 File Offset: 0x0000BF64
		public void ReverseAllSegments()
		{
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				simQueueSegment.Reverse = true;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000CFCC File Offset: 0x0000BFCC
		public void UnreverseAllSegments()
		{
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				simQueueSegment.Reverse = false;
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000D034 File Offset: 0x0000C034
		public virtual bool TryAddToStart(ISimQueueObject obj)
		{
			return this.CanAddToStart() && ((SimQueueSegment)this.segments[0]).TryAddToStart(obj);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000D070 File Offset: 0x0000C070
		public virtual bool TryAddToEnd(ISimQueueObject obj)
		{
			return this.CanAddToEnd() && ((SimQueueSegment)this.segments[this.segments.Count - 1]).TryAddToEnd(obj);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000D0B8 File Offset: 0x0000C0B8
		public virtual bool CanAddToStart()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[0]).CanAddToStart();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000D0F4 File Offset: 0x0000C0F4
		public virtual bool CanAddToEnd()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[this.segments.Count - 1]).CanAddToEnd();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000D13C File Offset: 0x0000C13C
		public virtual ISimQueueObject TryRemoveFromEnd()
		{
			ISimQueueObject result;
			if (this.CanRemoveFromEnd())
			{
				result = ((SimQueueSegment)this.segments[this.segments.Count - 1]).TryRemoveFromEnd();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000D184 File Offset: 0x0000C184
		public virtual ISimQueueObject TryRemoveFromStart()
		{
			ISimQueueObject result;
			if (this.CanRemoveFromStart())
			{
				result = ((SimQueueSegment)this.segments[0]).TryRemoveFromStart();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000D1C0 File Offset: 0x0000C1C0
		public virtual bool CanRemoveFromEnd()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[this.segments.Count - 1]).CanRemoveFromEnd();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000D208 File Offset: 0x0000C208
		public virtual bool CanRemoveFromStart()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[0]).CanRemoveFromStart();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000D244 File Offset: 0x0000C244
		public static SimQueue Create(int numSegments, Point[,] segmentPoints, string[][] objectOrientations, int dx, int dy, int objectSeparationX, int objectSeparationY)
		{
			SimQueue simQueue = new SimQueue();
			for (int i = 0; i < numSegments; i++)
			{
				SimQueueSegment segment = new SimQueueSegment();
				simQueue.AppendSegment(segment);
			}
			simQueue.SetDXDY(dx, dy);
			simQueue.SetObjectSeparation(objectSeparationX, objectSeparationY);
			simQueue.SetObjectOrientations(objectOrientations);
			simQueue.SetSegmentPoints(segmentPoints);
			return simQueue;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000D2A4 File Offset: 0x0000C2A4
		public static SimQueue Create(int numSegments, Point[,] segmentPoints, string[] objectOrientation, int dx, int dy, int objectSeparationX, int objectSeparationY)
		{
			SimQueue simQueue = new SimQueue();
			for (int i = 0; i < numSegments; i++)
			{
				SimQueueSegment segment = new SimQueueSegment();
				simQueue.AppendSegment(segment);
			}
			simQueue.SetDXDY(dx, dy);
			simQueue.SetObjectSeparation(objectSeparationX, objectSeparationY);
			simQueue.SetObjectOrientations(objectOrientation);
			simQueue.SetSegmentPoints(segmentPoints);
			return simQueue;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000D304 File Offset: 0x0000C304
		public virtual void SetObjectOrientations(string[][] orientations)
		{
			if (orientations != null && this.segments.Count == orientations.Length)
			{
				for (int i = 0; i < this.segments.Count; i++)
				{
					this[i].ObjectOrientation = orientations[i];
				}
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000D360 File Offset: 0x0000C360
		public virtual void SetObjectOrientations(string[] orientation)
		{
			if (orientation != null)
			{
				for (int i = 0; i < this.segments.Count; i++)
				{
					this[i].ObjectOrientation = orientation;
				}
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000D3A4 File Offset: 0x0000C3A4
		public virtual void SetSegmentPoints(Point[,] points)
		{
			if (points != null)
			{
				for (int i = 0; i < this.SegmentCount; i++)
				{
					this[i].StartPoint = points[i, 0];
					this[i].EndPoint = points[i, 1];
				}
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000D408 File Offset: 0x0000C408
		public virtual void SetDXDY(int dx, int dy)
		{
			for (int i = 0; i < this.SegmentCount; i++)
			{
				this[i].DX = dx;
				this[i].DY = dy;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000D44C File Offset: 0x0000C44C
		public virtual void SetObjectSeparation(int objectSeparationX, int objectSeparationY)
		{
			for (int i = 0; i < this.SegmentCount; i++)
			{
				this[i].ObjectSeparationX = objectSeparationX;
				this[i].ObjectSeparationY = objectSeparationY;
			}
		}

		// Token: 0x17000065 RID: 101
		public SimQueueSegment this[int index]
		{
			get
			{
				return (SimQueueSegment)this.segments[index];
			}
			set
			{
				this.segments[index] = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000D4C4 File Offset: 0x0000C4C4
		public int ObjectCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.segments.Count; i++)
				{
					num += this[i].Count;
				}
				return num;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0000D504 File Offset: 0x0000C504
		public int SegmentCount
		{
			get
			{
				return this.segments.Count;
			}
		}

		// Token: 0x040000F5 RID: 245
		protected ArrayList segments;
	}
}
