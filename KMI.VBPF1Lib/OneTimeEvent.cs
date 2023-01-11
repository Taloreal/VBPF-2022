using System;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Exercise.
	/// </summary>
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class OneTimeEvent : Task
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00003618 File Offset: 0x00002618
		public override string ToString()
		{
			DateTime d = this.OneTimeDay;
			return A.R.GetString("{0} on {1} from {2} to {3}", new object[]
			{
				this.CategoryName(),
				d.ToShortDateString(),
				Task.ToTimeString(this.StartPeriod),
				Task.ToTimeString(this.EndPeriod)
			});
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00003678 File Offset: 0x00002678
		public DateTime Key
		{
			get
			{
				if (this.key == DateTime.MinValue)
				{
					this.key = new DateTime(this.OneTimeDay.Year, this.OneTimeDay.Month, this.OneTimeDay.Day).AddMinutes(A.ST.Random.NextDouble());
				}
				return this.key;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000036EC File Offset: 0x000026EC
		public void AddAIAttendees(int number)
		{
			for (int i = 0; i < number; i++)
			{
				VBPFPerson p = new VBPFPerson();
				p.Task = (Task)Utilities.DeepCopyBySerialization(this);
				p.Task.ID = A.ST.GetNextID();
				p.Task.Owner = p;
				p.Location = p.Task.Building.Map.getNode("EntryPoint").Location;
				DateTime wakeupTime = this.OneTimeDay.AddHours((double)((float)this.StartPeriod / 2f) + (A.ST.Random.NextDouble() - 0.5));
				A.I.Subscribe(p, wakeupTime);
			}
		}

		// Token: 0x04000025 RID: 37
		protected DateTime key = DateTime.MinValue;

		// Token: 0x04000026 RID: 38
		public long HostID = -1L;

		// Token: 0x04000027 RID: 39
		public float rnd = 1f;
	}
}
