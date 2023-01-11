using System;
using System.Collections;
using System.Drawing;

namespace KMI.Sim.Queues
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class SimQueueSegment
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00004DFC File Offset: 0x00003DFC
		public SimQueueSegment()
		{
			this.queueObjects = new ArrayList();
			this.next = new ArrayList();
			this.previous = new ArrayList();
			this.objectSeparationX = 0;
			this.objectSeparationY = 0;
			this.reverse = false;
			this.objectOrientation = new string[]
			{
				"",
				""
			};
			this.forwardBackupPoint = new Point(int.MinValue, int.MinValue);
			this.reverseBackupPoint = new Point(int.MinValue, int.MinValue);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004E90 File Offset: 0x00003E90
		public virtual ArrayList GetDrawables()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.queueObjects)
			{
				ISimQueueObject simQueueObject = (ISimQueueObject)obj;
				arrayList.Add(simQueueObject.GetDrawable());
			}
			return arrayList;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004F10 File Offset: 0x00003F10
		public virtual void Clear()
		{
			this.queueObjects.Clear();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004F1F File Offset: 0x00003F1F
		public virtual void RemoveAt(int index)
		{
			this.queueObjects.RemoveAt(index);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004F30 File Offset: 0x00003F30
		public virtual void MoveQueueObjects()
		{
			if (this.reverse)
			{
				for (int i = 0; i < this.queueObjects.Count; i++)
				{
					this.MoveQueueObjectBackward(this[i], i);
				}
			}
			else
			{
				for (int i = this.queueObjects.Count - 1; i >= 0; i--)
				{
					this.MoveQueueObjectForward(this[i], i);
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004FAC File Offset: 0x00003FAC
		protected virtual void MoveQueueObjectForward(ISimQueueObject obj, int indexOfObj)
		{
			if (indexOfObj == this.queueObjects.Count - 1)
			{
				if (obj.Location.Equals(this.endPoint))
				{
					SimQueueSegment nextSegment = this.GetNextSegment();
					if (nextSegment != null)
					{
						if (nextSegment.TryAddToStart(obj))
						{
							this.queueObjects.Remove(obj);
							obj.Waiting = false;
							obj.ChangeActionState();
						}
						else
						{
							obj.Waiting = true;
							obj.ChangeActionState();
						}
					}
					else
					{
						obj.Waiting = true;
						obj.ChangeActionState();
					}
				}
				else
				{
					obj.Waiting = false;
					obj.ChangeActionState();
					this.MoveForwardHelper(obj);
				}
			}
			else
			{
				ISimQueueObject simQueueObject = this[indexOfObj + 1];
				if (this.objectSeparationX == 0 || this.objectSeparationY == 0)
				{
					obj.Waiting = true;
					if (this.objectSeparationX == 0 && this.objectSeparationY == 0)
					{
						obj.Waiting = false;
						this.MoveForwardHelper(obj);
					}
					else if (this.objectSeparationX == 0)
					{
						if (Math.Abs(simQueueObject.Y - obj.Y) > this.objectSeparationY)
						{
							obj.Waiting = false;
							this.MoveForwardHelper(obj);
						}
					}
					else if (this.objectSeparationY == 0)
					{
						if (Math.Abs(simQueueObject.X - obj.X) > this.objectSeparationX)
						{
							obj.Waiting = false;
							this.MoveForwardHelper(obj);
						}
					}
					obj.ChangeActionState();
				}
				else if (Math.Abs(simQueueObject.X - obj.X) > this.objectSeparationX && Math.Abs(simQueueObject.Y - obj.Y) > this.objectSeparationY)
				{
					obj.Waiting = false;
					obj.ChangeActionState();
					this.MoveForwardHelper(obj);
				}
				else
				{
					obj.Waiting = true;
					obj.ChangeActionState();
				}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000051E8 File Offset: 0x000041E8
		private SimQueueSegment GetNextSegment()
		{
			SimQueueSegment result;
			if (this.next.Count == 1)
			{
				result = (SimQueueSegment)this.next[0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005228 File Offset: 0x00004228
		private void MoveForwardHelper(ISimQueueObject obj)
		{
			obj.Waiting = false;
			SimQueueSegment nextSegment = this.GetNextSegment();
			if (obj.Location.Equals(this.forwardBackupPoint))
			{
				if (nextSegment != null && nextSegment.CanAddToStart())
				{
					obj.X += this.GetDX();
					obj.Y += this.GetDY();
				}
			}
			else
			{
				obj.X += this.GetDX();
				obj.Y += this.GetDY();
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000052D8 File Offset: 0x000042D8
		protected virtual void MoveQueueObjectBackward(ISimQueueObject obj, int indexOfObj)
		{
			if (indexOfObj == 0)
			{
				if (obj.Location.Equals(this.startPoint))
				{
					SimQueueSegment previousSegment = this.GetPreviousSegment();
					if (previousSegment != null)
					{
						if (previousSegment.TryAddToEnd(obj))
						{
							this.queueObjects.Remove(obj);
							obj.Waiting = false;
							obj.ChangeActionState();
						}
						else
						{
							obj.Waiting = true;
							obj.ChangeActionState();
						}
					}
					else
					{
						obj.Waiting = true;
						obj.ChangeActionState();
					}
				}
				else
				{
					obj.Waiting = false;
					obj.ChangeActionState();
					this.MoveBackwardHelper(obj);
				}
			}
			else
			{
				ISimQueueObject simQueueObject = this[indexOfObj - 1];
				if (this.objectSeparationX == 0 || this.objectSeparationY == 0)
				{
					obj.Waiting = true;
					if (this.objectSeparationX == 0 && this.objectSeparationY == 0)
					{
						obj.Waiting = false;
						this.MoveBackwardHelper(obj);
					}
					else if (this.objectSeparationX == 0)
					{
						if (Math.Abs(obj.Y - simQueueObject.Y) > this.objectSeparationY)
						{
							obj.Waiting = false;
							this.MoveBackwardHelper(obj);
						}
					}
					else if (this.objectSeparationY == 0)
					{
						if (Math.Abs(obj.X - simQueueObject.X) > this.objectSeparationX)
						{
							obj.Waiting = false;
							this.MoveBackwardHelper(obj);
						}
					}
					obj.ChangeActionState();
				}
				else if (Math.Abs(obj.X - simQueueObject.X) > this.objectSeparationX && Math.Abs(obj.Y - simQueueObject.Y) > this.objectSeparationY)
				{
					obj.Waiting = false;
					obj.ChangeActionState();
					this.MoveBackwardHelper(obj);
				}
				else
				{
					obj.Waiting = true;
					obj.ChangeActionState();
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00005508 File Offset: 0x00004508
		private SimQueueSegment GetPreviousSegment()
		{
			SimQueueSegment result;
			if (this.previous.Count == 1)
			{
				result = (SimQueueSegment)this.previous[0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005548 File Offset: 0x00004548
		private void MoveBackwardHelper(ISimQueueObject obj)
		{
			SimQueueSegment previousSegment = this.GetPreviousSegment();
			if (obj.Location.Equals(this.reverseBackupPoint))
			{
				if (previousSegment != null && previousSegment.CanAddToEnd())
				{
					obj.X -= this.GetDX();
					obj.Y -= this.GetDY();
				}
			}
			else
			{
				obj.X -= this.GetDX();
				obj.Y -= this.GetDY();
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000055F0 File Offset: 0x000045F0
		private int GetDX()
		{
			int num = this.dx;
			if (this.endPoint.X - this.startPoint.X < 0)
			{
				num *= -1;
			}
			return num;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005634 File Offset: 0x00004634
		private int GetDY()
		{
			int num = this.dy;
			if (this.endPoint.Y - this.startPoint.Y < 0)
			{
				num *= -1;
			}
			return num;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005678 File Offset: 0x00004678
		public virtual bool TryAddToStart(ISimQueueObject obj)
		{
			bool result;
			if (this.CanAddToStart())
			{
				this.queueObjects.Insert(0, obj);
				if (!this.reverse)
				{
					obj.Orientation = this.objectOrientation[0];
				}
				else
				{
					obj.Orientation = this.objectOrientation[1];
				}
				obj.Location = this.startPoint;
				obj.ChangeActionState();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000056F0 File Offset: 0x000046F0
		public virtual bool TryAddToEnd(ISimQueueObject obj)
		{
			bool result;
			if (this.CanAddToEnd())
			{
				this.queueObjects.Add(obj);
				if (!this.reverse)
				{
					obj.Orientation = this.objectOrientation[0];
				}
				else
				{
					obj.Orientation = this.objectOrientation[1];
				}
				obj.Location = this.endPoint;
				obj.ChangeActionState();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005768 File Offset: 0x00004768
		public virtual bool CanAddToStart()
		{
			bool result;
			if (this.queueObjects.Count == 0)
			{
				result = true;
			}
			else
			{
				ISimQueueObject simQueueObject = this[0];
				result = (Math.Abs(simQueueObject.X - this.startPoint.X) >= this.objectSeparationX && Math.Abs(simQueueObject.Y - this.startPoint.Y) >= this.objectSeparationY);
			}
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000057E4 File Offset: 0x000047E4
		public virtual bool CanAddToEnd()
		{
			bool result;
			if (this.queueObjects.Count == 0)
			{
				result = true;
			}
			else
			{
				ISimQueueObject simQueueObject = this[this.Count - 1];
				result = (Math.Abs(this.endPoint.X - simQueueObject.X) >= this.objectSeparationX && Math.Abs(this.endPoint.Y - simQueueObject.Y) >= this.objectSeparationY);
			}
			return result;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005864 File Offset: 0x00004864
		public virtual ISimQueueObject TryRemoveFromEnd()
		{
			ISimQueueObject result;
			if (this.CanRemoveFromEnd())
			{
				ISimQueueObject simQueueObject = this[this.Count - 1];
				this.queueObjects.RemoveAt(this.Count - 1);
				simQueueObject.ChangeActionState();
				result = simQueueObject;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000058B4 File Offset: 0x000048B4
		public virtual ISimQueueObject TryRemoveFromStart()
		{
			ISimQueueObject result;
			if (this.CanRemoveFromStart())
			{
				ISimQueueObject simQueueObject = this[0];
				this.queueObjects.RemoveAt(0);
				simQueueObject.ChangeActionState();
				result = simQueueObject;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000058F8 File Offset: 0x000048F8
		public virtual bool CanRemoveFromEnd()
		{
			bool result;
			if (this.queueObjects.Count == 0)
			{
				result = false;
			}
			else
			{
				ISimQueueObject simQueueObject = this[this.Count - 1];
				result = simQueueObject.Location.Equals(this.endPoint);
			}
			return result;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005954 File Offset: 0x00004954
		public virtual bool CanRemoveFromStart()
		{
			bool result;
			if (this.queueObjects.Count == 0)
			{
				result = false;
			}
			else
			{
				ISimQueueObject simQueueObject = this[0];
				result = simQueueObject.Location.Equals(this.startPoint);
			}
			return result;
		}

		// Token: 0x1700002C RID: 44
		public ISimQueueObject this[int index]
		{
			get
			{
				return (ISimQueueObject)this.queueObjects[index];
			}
			set
			{
				this.queueObjects[index] = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000059DC File Offset: 0x000049DC
		public ArrayList QueueObjects
		{
			get
			{
				return this.queueObjects;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000059F4 File Offset: 0x000049F4
		public int Count
		{
			get
			{
				return this.queueObjects.Count;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00005A14 File Offset: 0x00004A14
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00005A2C File Offset: 0x00004A2C
		public string[] ObjectOrientation
		{
			get
			{
				return this.objectOrientation;
			}
			set
			{
				this.objectOrientation = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00005A38 File Offset: 0x00004A38
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00005A50 File Offset: 0x00004A50
		public Point StartPoint
		{
			get
			{
				return this.startPoint;
			}
			set
			{
				this.startPoint = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00005A5C File Offset: 0x00004A5C
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00005A74 File Offset: 0x00004A74
		public Point EndPoint
		{
			get
			{
				return this.endPoint;
			}
			set
			{
				this.endPoint = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00005A80 File Offset: 0x00004A80
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00005A98 File Offset: 0x00004A98
		public Point ForwardBackupPoint
		{
			get
			{
				return this.forwardBackupPoint;
			}
			set
			{
				this.forwardBackupPoint = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00005AA4 File Offset: 0x00004AA4
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00005ABC File Offset: 0x00004ABC
		public Point ReverseBackupPoint
		{
			get
			{
				return this.reverseBackupPoint;
			}
			set
			{
				this.reverseBackupPoint = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00005AC8 File Offset: 0x00004AC8
		// (set) Token: 0x0600008D RID: 141 RVA: 0x00005AE0 File Offset: 0x00004AE0
		public int ObjectSeparationX
		{
			get
			{
				return this.objectSeparationX;
			}
			set
			{
				this.objectSeparationX = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00005AEC File Offset: 0x00004AEC
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00005B04 File Offset: 0x00004B04
		public int ObjectSeparationY
		{
			get
			{
				return this.objectSeparationY;
			}
			set
			{
				this.objectSeparationY = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00005B0E File Offset: 0x00004B0E
		public int DX
		{
			set
			{
				this.dx = Math.Abs(value);
			}
		}

		// Token: 0x17000037 RID: 55
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00005B1D File Offset: 0x00004B1D
		public int DY
		{
			set
			{
				this.dy = Math.Abs(value);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00005B2C File Offset: 0x00004B2C
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00005B44 File Offset: 0x00004B44
		public ArrayList Next
		{
			get
			{
				return this.next;
			}
			set
			{
				this.next = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00005B50 File Offset: 0x00004B50
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00005B68 File Offset: 0x00004B68
		public ArrayList Previous
		{
			get
			{
				return this.previous;
			}
			set
			{
				this.previous = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00005B74 File Offset: 0x00004B74
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00005B8C File Offset: 0x00004B8C
		public bool Reverse
		{
			get
			{
				return this.reverse;
			}
			set
			{
				this.reverse = value;
				string orientation;
				if (!this.reverse)
				{
					orientation = this.objectOrientation[0];
				}
				else
				{
					orientation = this.objectOrientation[1];
				}
				foreach (object obj in this.queueObjects)
				{
					ISimQueueObject simQueueObject = (ISimQueueObject)obj;
					simQueueObject.Orientation = orientation;
				}
			}
		}

		// Token: 0x04000047 RID: 71
		protected ArrayList queueObjects;

		// Token: 0x04000048 RID: 72
		protected string[] objectOrientation;

		// Token: 0x04000049 RID: 73
		protected Point startPoint;

		// Token: 0x0400004A RID: 74
		protected Point endPoint;

		// Token: 0x0400004B RID: 75
		protected Point forwardBackupPoint;

		// Token: 0x0400004C RID: 76
		protected Point reverseBackupPoint;

		// Token: 0x0400004D RID: 77
		protected int objectSeparationX;

		// Token: 0x0400004E RID: 78
		protected int objectSeparationY;

		// Token: 0x0400004F RID: 79
		protected int dx;

		// Token: 0x04000050 RID: 80
		protected int dy;

		// Token: 0x04000051 RID: 81
		protected ArrayList next;

		// Token: 0x04000052 RID: 82
		protected ArrayList previous;

		// Token: 0x04000053 RID: 83
		protected bool reverse;
	}
}
