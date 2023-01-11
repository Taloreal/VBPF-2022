using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Task.
	/// </summary>
	// Token: 0x02000002 RID: 2
	[Serializable]
	public class Task
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public Task()
		{
			if (!S.I.Client)
			{
				this.ID = A.ST.GetNextID();
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x000020C4 File Offset: 0x000010C4
		// (set) Token: 0x06000003 RID: 3 RVA: 0x000020EB File Offset: 0x000010EB
		public AppBuilding Building
		{
			get
			{
				return A.ST.City.BuildingByID(this.buildingID);
			}
			set
			{
				this.buildingID = value.ID;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020FC File Offset: 0x000010FC
		public virtual bool Do()
		{
			return true;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002110 File Offset: 0x00001110
		public int Duration
		{
			get
			{
				int result;
				if (this.StartPeriod <= this.EndPeriod)
				{
					result = this.EndPeriod - this.StartPeriod;
				}
				else
				{
					result = this.EndPeriod + 48 - this.StartPeriod;
				}
				return result;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002154 File Offset: 0x00001154
		public virtual Color GetColor()
		{
			return Color.White;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000216C File Offset: 0x0000116C
		public virtual string CategoryName()
		{
			return null;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002180 File Offset: 0x00001180
		public virtual string Description()
		{
			return null;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002193 File Offset: 0x00001193
		public virtual void CleanUp()
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002198 File Offset: 0x00001198
		public string BadAttendance()
		{
			if (A.SS.FireForAbsencesLateness)
			{
				int absentCount = 0;
				foreach (object obj in this.DatesAbsent)
				{
					DateTime date = (DateTime)obj;
					if ((A.ST.Now - date).Days < 30)
					{
						absentCount++;
					}
				}
				if (absentCount > 4)
				{
					string s = A.R.GetString("been fired from your job");
					if (this is AttendClass)
					{
						s = A.R.GetString("flunked out of your class");
					}
					return A.R.GetString("You have {0} because you were absent more than {1} times in the last month.", new object[]
					{
						s,
						4
					});
				}
				if (absentCount > 2)
				{
					this.GetAppEntity().Player.SendPeriodicMessage(A.R.GetString("You have been absent a lot recently. You may be fired or flunk out soon!"), "", NotificationColor.Yellow, 30f);
				}
				int lateCount = 0;
				foreach (object obj2 in this.DatesLate)
				{
					DateTime date = (DateTime)obj2;
					if ((A.ST.Now - date).Days < 30)
					{
						lateCount++;
					}
				}
				if (lateCount > 4)
				{
					string s = A.R.GetString("been fired from your job");
					if (this is AttendClass)
					{
						s = A.R.GetString("flunked out of your class");
					}
					return A.R.GetString("You have {0} because you were late more than {1} times in the last month.", new object[]
					{
						s,
						4
					});
				}
				if (lateCount > 2)
				{
					this.GetAppEntity().Player.SendPeriodicMessage(A.R.GetString("You have been late a lot recently. You may be fired or flunk out soon!"), "", NotificationColor.Yellow, 30f);
				}
			}
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002420 File Offset: 0x00001420
		public AppEntity GetAppEntity()
		{
			foreach (object obj in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj;
				if (e.Person == this.Owner)
				{
					return e;
				}
			}
			return null;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000024A8 File Offset: 0x000014A8
		public string WeekendString()
		{
			string @string;
			if (this.Weekend)
			{
				@string = A.R.GetString("Weekend");
			}
			else
			{
				@string = A.R.GetString("Weekday");
			}
			return @string;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000024E8 File Offset: 0x000014E8
		public static string ToTimeString(int period)
		{
			return new DateTime(2000, 1, 1).AddHours((double)((float)period / 2f)).ToShortTimeString();
		}

		// Token: 0x04000001 RID: 1
		protected long buildingID;

		// Token: 0x04000002 RID: 2
		public VBPFPerson Owner;

		// Token: 0x04000003 RID: 3
		public int StartPeriod;

		// Token: 0x04000004 RID: 4
		public int EndPeriod;

		// Token: 0x04000005 RID: 5
		public long ID;

		// Token: 0x04000006 RID: 6
		public bool Weekend;

		// Token: 0x04000007 RID: 7
		public DateTime OneTimeDay = DateTime.MinValue;

		// Token: 0x04000008 RID: 8
		public int DayLastStarted = -1;

		// Token: 0x04000009 RID: 9
		public ArrayList DatesAbsent = new ArrayList();

		// Token: 0x0400000A RID: 10
		public ArrayList DatesLate = new ArrayList();

		// Token: 0x0400000B RID: 11
		public DateTime StartDate;

		// Token: 0x0400000C RID: 12
		public DateTime EndDate = DateTime.MinValue;

		// Token: 0x0400000D RID: 13
		public DateTime ArrivedToday = DateTime.MinValue;
	}
}
