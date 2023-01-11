using System;
using System.Collections;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Course.
	/// </summary>
	// Token: 0x0200006A RID: 106
	[Serializable]
	public class Course : Offering
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0002CDA8 File Offset: 0x0002BDA8
		public Course()
		{
			if (A.ST.Random.Next(2) == 0)
			{
				this.TeacherGender = "Female";
			}
			else
			{
				this.TeacherGender = "Male";
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0002CE04 File Offset: 0x0002BE04
		public override string ThingName()
		{
			return A.R.GetString("Courses");
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0002CE28 File Offset: 0x0002BE28
		public override string Description()
		{
			DateTime d = new DateTime(2000, 1, 1);
			string days = A.R.GetString("Mon. - Fri.");
			int weeks = this.Days / 5;
			if (this.PrototypeTask.Weekend)
			{
				days = A.R.GetString("Sat. & Sun.");
				weeks = this.Days / 2;
			}
			string s = A.R.GetString("{0}|Hours: {1} to {2}|Days: {3}|Cost: {4}|Length: {5} weeks", new object[]
			{
				this.Name.ToUpper(),
				d.AddHours((double)((float)this.PrototypeTask.StartPeriod / 2f)).ToShortTimeString(),
				d.AddHours((double)((float)this.PrototypeTask.EndPeriod / 2f)).ToShortTimeString(),
				days,
				Utilities.FC(this.Cost, A.I.CurrencyConversion),
				weeks
			});
			if (this.Prerequisite != null)
			{
				s += A.R.GetString("|Prerequisite: {0}", new object[]
				{
					this.Prerequisite
				});
			}
			return s.Replace("|", Environment.NewLine);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0002CF7C File Offset: 0x0002BF7C
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0002CF94 File Offset: 0x0002BF94
		public override string JournalEntry()
		{
			return A.R.GetString("Enrolled in course, {0}, at a cost of {1}.", new object[]
			{
				this.Name,
				Utilities.FC(this.Cost, A.I.CurrencyConversion)
			});
		}

		// Token: 0x04000348 RID: 840
		public string Prerequisite = null;

		// Token: 0x04000349 RID: 841
		public ArrayList Students = new ArrayList();

		// Token: 0x0400034A RID: 842
		public string TeacherGender;

		// Token: 0x0400034B RID: 843
		public string Name;

		// Token: 0x0400034C RID: 844
		public float Cost;

		// Token: 0x0400034D RID: 845
		public int Days;

		// Token: 0x0400034E RID: 846
		public string ResumeDescription;
	}
}
