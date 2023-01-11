using System;
using System.Collections;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for DailyRoutine.
	/// </summary>
	// Token: 0x0200007C RID: 124
	[Serializable]
	public class DailyRoutine
	{
		// Token: 0x0600031F RID: 799 RVA: 0x000353E4 File Offset: 0x000343E4
		public DailyRoutine MakeCopy()
		{
			return new DailyRoutine
			{
				Tasks = (SortedList)this.Tasks.Clone()
			};
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00035414 File Offset: 0x00034414
		public Task GetCurrentTask()
		{
			Task t = null;
			foreach (object obj in this.Tasks.Values)
			{
				Task a = (Task)obj;
				if (a.StartPeriod < a.EndPeriod)
				{
					if (a.StartPeriod <= A.ST.Period && A.ST.Period < a.EndPeriod && a.DayLastStarted != A.ST.Day)
					{
						t = a;
						t.DayLastStarted = A.ST.Day;
					}
				}
				else if (a.StartPeriod <= A.ST.Period && a.DayLastStarted != A.ST.Day)
				{
					t = a;
					t.DayLastStarted = A.ST.Day;
				}
				else if (A.ST.Period < a.EndPeriod && a.DayLastStarted != A.ST.Now.AddDays(-1.0).Day)
				{
					t = a;
					t.DayLastStarted = A.ST.Now.AddDays(-1.0).Day;
				}
			}
			return t;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000355C8 File Offset: 0x000345C8
		public Task PriorTask(Task task)
		{
			int index = this.Tasks.IndexOfValue(task);
			Task t;
			if (index == 0)
			{
				t = (Task)this.Tasks.GetByIndex(this.Tasks.Count - 1);
			}
			else
			{
				t = (Task)this.Tasks.GetByIndex(index - 1);
			}
			return t;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0003562C File Offset: 0x0003462C
		public void CheckHoursConflict(Task task)
		{
			foreach (object obj in this.Tasks.Values)
			{
				Task t = (Task)obj;
				if (t.ID != task.ID)
				{
					for (int i = task.StartPeriod; i < task.StartPeriod + task.Duration; i++)
					{
						for (int j = t.StartPeriod; j < t.StartPeriod + t.Duration; j++)
						{
							if (i % 48 == j % 48)
							{
								throw new SimApplicationException(A.R.GetString("Those hours conflict with other activities in your daily routine. Please adjust other activities to make room."));
							}
						}
					}
				}
			}
			foreach (object obj2 in this.Tasks.Values)
			{
				Task t = (Task)obj2;
				if (task.Building != t.Building && (task.StartPeriod == t.EndPeriod || task.EndPeriod == t.StartPeriod))
				{
					throw new SimApplicationException(A.R.GetString("You must allow at least a half hour between activities at different locations. Please adjust your schedule."));
				}
			}
		}

		// Token: 0x04000404 RID: 1028
		public SortedList Tasks = new SortedList();
	}
}
