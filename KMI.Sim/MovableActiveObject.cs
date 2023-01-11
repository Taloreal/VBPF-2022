using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000024 RID: 36
	[Serializable]
	public class MovableActiveObject : ActiveObject
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0000D588 File Offset: 0x0000C588
		// (set) Token: 0x06000199 RID: 409 RVA: 0x0000D5A0 File Offset: 0x0000C5A0
		public PointF Location
		{
			get
			{
				return this.location;
			}
			set
			{
				this.location = value;
				this.RecalculateDXDY();
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000D5B4 File Offset: 0x0000C5B4
		// (set) Token: 0x0600019B RID: 411 RVA: 0x0000D5CC File Offset: 0x0000C5CC
		public PointF Destination
		{
			get
			{
				return this.destination;
			}
			set
			{
				this.destination = value;
				this.RecalculateDXDY();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000D5E0 File Offset: 0x0000C5E0
		// (set) Token: 0x0600019D RID: 413 RVA: 0x0000D5F8 File Offset: 0x0000C5F8
		public ArrayList Path
		{
			get
			{
				return this.path;
			}
			set
			{
				if (value != null && value.Count > 0)
				{
					this.Destination = (PointF)value[0];
					value.RemoveAt(0);
				}
				else
				{
					this.Destination = this.Location;
				}
				this.path = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600019E RID: 414 RVA: 0x0000D654 File Offset: 0x0000C654
		// (set) Token: 0x0600019F RID: 415 RVA: 0x0000D66C File Offset: 0x0000C66C
		public float Speed
		{
			get
			{
				return this.speed;
			}
			set
			{
				this.speed = value;
				this.RecalculateDXDY();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x0000D680 File Offset: 0x0000C680
		public float DX
		{
			get
			{
				return this.dx;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000D698 File Offset: 0x0000C698
		public float DY
		{
			get
			{
				return this.dy;
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000D6B0 File Offset: 0x0000C6B0
		protected void RecalculateDXDY()
		{
			float num = Utilities.DistanceBetweenIsometric(this.destination, this.location);
			if (num == 0f)
			{
				this.dx = 0f;
				this.dy = 0f;
			}
			else
			{
				this.dx = (this.destination.X - this.location.X) / num * this.speed;
				this.dy = (this.destination.Y - this.location.Y) / num * this.speed;
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000D748 File Offset: 0x0000C748
		public virtual bool Move()
		{
			this.location.X = this.location.X + this.dx;
			this.location.Y = this.location.Y + this.dy;
			bool flag = Math.Sign(this.destination.X - this.location.X) != Math.Sign(this.dx) || Math.Sign(this.destination.Y - this.location.Y) != Math.Sign(this.dy) || (this.dx == 0f && this.dy == 0f);
			if (flag)
			{
				this.location = this.destination;
				if (this.Path != null && this.Path.Count > 0)
				{
					this.Destination = (PointF)this.Path[0];
					this.Path.RemoveAt(0);
					if (this.PathSpeeds != null && this.PathSpeeds.Count > 0)
					{
						this.Speed = (float)this.PathSpeeds[0];
						this.PathSpeeds.RemoveAt(0);
					}
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000D8AC File Offset: 0x0000C8AC
		public float DistanceFrom(PointF pt)
		{
			return (float)Math.Sqrt(Math.Pow((double)(this.location.X - pt.X), 2.0) + Math.Pow((double)(this.location.Y - pt.Y), 2.0));
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000D90C File Offset: 0x0000C90C
		public string Orientation()
		{
			string text = "";
			if (this.dy > 0f)
			{
				text += "S";
			}
			else
			{
				text += "N";
			}
			if (this.dx > 0f)
			{
				text += "E";
			}
			else
			{
				text += "W";
			}
			return text;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000D984 File Offset: 0x0000C984
		public int OrientationIndexWithFlip(ref bool flipX)
		{
			int result;
			if (this.dx < 0f && this.dy < 0f)
			{
				flipX = false;
				result = 0;
			}
			else if (this.dx > 0f && this.dy < 0f)
			{
				flipX = true;
				result = 0;
			}
			else if (this.dx < 0f && this.dy > 0f)
			{
				flipX = false;
				result = 1;
			}
			else if (this.dx > 0f && this.dy > 0f)
			{
				flipX = true;
				result = 1;
			}
			else
			{
				flipX = false;
				result = 1;
			}
			return result;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000DA50 File Offset: 0x0000CA50
		public string Orientation8()
		{
			double num = Math.Atan2((double)(-(double)this.dy), (double)this.dx);
			num *= 57.29577951308232;
			if (num < 0.0)
			{
				num += 360.0;
			}
			string result;
			if ((num >= 345.0 && num < 360.0) || (num >= 0.0 && num < 15.0))
			{
				result = "E";
			}
			else if (num >= 15.0 && num < 67.5)
			{
				result = "NE";
			}
			else if (num >= 67.5 && num < 112.5)
			{
				result = "N";
			}
			else if (num >= 112.5 && num < 165.0)
			{
				result = "NW";
			}
			else if (num >= 165.0 && num < 195.0)
			{
				result = "W";
			}
			else if (num >= 195.0 && num < 248.5)
			{
				result = "SW";
			}
			else if (num >= 248.5 && num < 292.5)
			{
				result = "S";
			}
			else if (num >= 292.5 && num < 345.0)
			{
				result = "SE";
			}
			else
			{
				result = num.ToString() + "Error";
			}
			return result;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000DC30 File Offset: 0x0000CC30
		public int OrientationIndex8()
		{
			double num = Math.Atan2((double)(-(double)this.dy), (double)this.dx);
			num *= 57.29577951308232;
			if (num < 0.0)
			{
				num += 360.0;
			}
			int result;
			if ((num >= 345.0 && num < 360.0) || (num >= 0.0 && num < 15.0))
			{
				result = 2;
			}
			else if (num >= 15.0 && num < 67.5)
			{
				result = 3;
			}
			else if (num >= 67.5 && num < 112.5)
			{
				result = 4;
			}
			else if (num >= 112.5 && num < 165.0)
			{
				result = 5;
			}
			else if (num >= 165.0 && num < 195.0)
			{
				result = 6;
			}
			else if (num >= 195.0 && num < 248.5)
			{
				result = 7;
			}
			else if (num >= 248.5 && num < 292.5)
			{
				result = 0;
			}
			else if (num >= 292.5 && num < 345.0)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x0000DDDC File Offset: 0x0000CDDC
		// (set) Token: 0x060001AA RID: 426 RVA: 0x0000DDF4 File Offset: 0x0000CDF4
		public ArrayList PathSpeeds
		{
			get
			{
				return this.pathSpeeds;
			}
			set
			{
				if (value != null && value.Count > 0)
				{
					this.Speed = (float)value[0];
					value.RemoveAt(0);
				}
				this.pathSpeeds = value;
			}
		}

		// Token: 0x040000F6 RID: 246
		protected PointF location = new PointF(0f, 0f);

		// Token: 0x040000F7 RID: 247
		protected PointF destination = new PointF(0f, 0f);

		// Token: 0x040000F8 RID: 248
		protected ArrayList path;

		// Token: 0x040000F9 RID: 249
		protected float speed = 1f;

		// Token: 0x040000FA RID: 250
		protected float dx = 0f;

		// Token: 0x040000FB RID: 251
		protected float dy = 0f;

		// Token: 0x040000FC RID: 252
		protected ArrayList pathSpeeds;
	}
}
