using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for TravelTask.
	/// </summary>
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class WorkTask : Task
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002520 File Offset: 0x00001520
		public WorkTask()
		{
			this.R401KAllocations = new float[A.ST.MutualFunds.Count];
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000025BC File Offset: 0x000015BC
		public virtual void EvaluateApplicant(AppEntity e, Offering o, JobApplication jobApp)
		{
			object date = e.FiredFrom[o.Building.ID + this.Name()];
			if (date != null && (A.ST.Now - (DateTime)date).Days < 180)
			{
				throw new SimApplicationException(A.R.GetString("You were recently fired from that job. You must wait at least {0} days before you can be rehired.", new object[]
				{
					180
				}));
			}
			date = e.Quit[o.Building.ID + this.Name()];
			if (date != null && (A.ST.Now - (DateTime)date).Days < 90)
			{
				throw new SimApplicationException(A.R.GetString("You recently quit that job. You must wait at least {0} days before you can be rehired.", new object[]
				{
					90
				}));
			}
			if (jobApp.Name.ToUpper() != e.Name.ToUpper())
			{
				throw new SimApplicationException(A.R.GetString("You got your name wrong on the application. Your application has been rejected."));
			}
			if (this is WorkTravellingSalesman)
			{
				if (e.Car == null && jobApp.Car)
				{
					throw new SimApplicationException(A.R.GetString("A check of motor vehicle registrations shows you don't have a car. Your application has been rejected for lying."));
				}
				if (!jobApp.Car)
				{
					throw new SimApplicationException(A.R.GetString("This job requires a car and your application indicates you don't have one. Your application has been rejected."));
				}
			}
			foreach (object obj in jobApp.ReportedClassNames)
			{
				string reportedClass = (string)obj;
				bool found = false;
				foreach (object obj2 in e.AcademicTaskHistory.Values)
				{
					AttendClass t = (AttendClass)obj2;
					if (t.Course.Name == reportedClass)
					{
						found = true;
					}
				}
				if (!found)
				{
					throw new SimApplicationException(A.R.GetString("You reported completing the class: {0}. But reference checking revealed you did not. Your application has been rejected for lying.", new object[]
					{
						reportedClass
					}));
				}
			}
			if (jobApp.ReportedClassNames.Contains("Bachelors Degree"))
			{
				jobApp.ReportedClassNames.Add("Associates Degree");
			}
			int monthsAnyJob = 0;
			foreach (object obj3 in jobApp.ReportedJobNamesAndMonths.Keys)
			{
				string reportedJob = (string)obj3;
				int reportedMonths = (int)jobApp.ReportedJobNamesAndMonths[reportedJob];
				int haveMonths = (int)Math.Floor((double)(e.YearsExperience(reportedJob) * 12f));
				monthsAnyJob += reportedMonths;
				if (reportedMonths > haveMonths)
				{
					throw new SimApplicationException(A.R.GetString("You reported {0} months of experience as a {1}. But reference checking revealed you have {2} months experience at that job. Your application has been rejected for lying.", new object[]
					{
						reportedMonths,
						reportedJob,
						haveMonths.ToString("N0")
					}));
				}
			}
			jobApp.ReportedJobNamesAndMonths.Add("worker of any kind", monthsAnyJob);
			foreach (object obj4 in this.AcademicExperienceRequired)
			{
				string s = (string)obj4;
				bool found = false;
				string[] classOptions = s.Split(new char[]
				{
					'|'
				});
				foreach (string classOption in classOptions)
				{
					foreach (object obj5 in jobApp.ReportedClassNames)
					{
						string className = (string)obj5;
						if (className.IndexOf(classOption) > -1)
						{
							found = true;
						}
					}
				}
				if (!found)
				{
					throw new SimApplicationException(A.R.GetString("You did not get the job, because your application showed that you did not have enough education. This job requires the course: {0}.", new object[]
					{
						A.R.GetString(s.Replace("|", " or "))
					}));
				}
			}
			foreach (object obj6 in this.WorkExperienceRequired.Keys)
			{
				string t2 = (string)obj6;
				float yearsRequired = (float)this.WorkExperienceRequired[t2];
				int monthsReported = 0;
				string[] workOptions = t2.Split(new char[]
				{
					'|'
				});
				foreach (string workOption in workOptions)
				{
					if (jobApp.ReportedJobNamesAndMonths.ContainsKey(workOption))
					{
						monthsReported += (int)jobApp.ReportedJobNamesAndMonths[workOption];
					}
				}
				if (yearsRequired * 12f > (float)monthsReported)
				{
					throw new SimApplicationException(A.R.GetString("You did not get the job, because you did not have enough experience. This job requires {0} months of experience as a {1}, and your application lists only {2} months of experience.", new object[]
					{
						(yearsRequired * 12f).ToString("N0"),
						t2.Replace("|", " or "),
						monthsReported
					}));
				}
			}
			if (e.CreditScore() < this.CreditScoreRequired)
			{
				throw new SimApplicationException(A.R.GetString("You did not get the job, because your credit score was below {0}.", new object[]
				{
					e.CreditScore()
				}));
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002CDC File Offset: 0x00001CDC
		public ArrayList PayStubsYTD(DateTime date)
		{
			ArrayList temp = new ArrayList();
			foreach (object obj in this.PayStubs)
			{
				PayStub payStub = (PayStub)obj;
				if (payStub.WeekEnding.Year == date.Year && payStub.WeekEnding <= date)
				{
					temp.Add(payStub);
				}
			}
			return temp;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002D80 File Offset: 0x00001D80
		public float GetValueYTD(string lineItem, DateTime date)
		{
			float total = 0f;
			foreach (object obj in this.PayStubsYTD(date))
			{
				PayStub ps = (PayStub)obj;
				total += ps.GetValue(lineItem);
			}
			return total;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002DFC File Offset: 0x00001DFC
		public override Color GetColor()
		{
			return Color.Green;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002E14 File Offset: 0x00001E14
		public override string Description()
		{
			DateTime d = new DateTime(2000, 1, 1);
			string experienceRequired = "";
			foreach (object obj in this.WorkExperienceRequired.Keys)
			{
				string t = (string)obj;
				float years = (float)this.WorkExperienceRequired[t];
				experienceRequired += A.R.GetString("{0} year(s) as a {1}, ", new object[]
				{
					years,
					t
				});
			}
			if (experienceRequired == "")
			{
				experienceRequired = "None";
			}
			else
			{
				experienceRequired = Utilities.FormatCommaSeries(experienceRequired);
			}
			experienceRequired = experienceRequired.Replace("|", A.R.GetString(" or "));
			string coursesRequired = "";
			foreach (object obj2 in this.AcademicExperienceRequired)
			{
				string t = (string)obj2;
				coursesRequired += A.R.GetString("{0}, ", new object[]
				{
					t
				});
			}
			if (coursesRequired == "")
			{
				coursesRequired = "None";
			}
			else
			{
				coursesRequired = Utilities.FormatCommaSeries(coursesRequired);
			}
			coursesRequired = coursesRequired.Replace("|", A.R.GetString(" or "));
			string benefits = "";
			if (this.HealthInsurance != null)
			{
				benefits += A.R.GetString("Healthcare Insurance");
			}
			if (this.R401KMatch > -1f)
			{
				if (benefits.Length > 0)
				{
					benefits += "; ";
				}
				benefits += A.R.GetString("401K Plan with {0} company match", new object[]
				{
					Utilities.FP(this.R401KMatch)
				});
			}
			if (benefits == "")
			{
				benefits = A.R.GetString("None");
			}
			string days = A.R.GetString("Mon. - Fri.");
			if (this.Weekend)
			{
				days = A.R.GetString("Sat. & Sun.");
			}
			string s = A.R.GetString("{0}|Hours: {1} to {2}|Days: {3}|Hourly Pay: {4}|Experience Req'd: {5}|Courses Req'd: {6}|Benefits: {7}", new object[]
			{
				this.Name().ToUpper(),
				Task.ToTimeString(this.StartPeriod),
				Task.ToTimeString(this.EndPeriod),
				days,
				Utilities.FC(this.HourlyWage, 2, A.I.CurrencyConversion),
				experienceRequired,
				coursesRequired,
				benefits
			});
			if (this.BonusPotential > 0f)
			{
				s = s.Replace("|Experience", A.R.GetString("|Qtly Bonus: up to {0}|Experience", new object[]
				{
					Utilities.FP(this.BonusPotential)
				}));
			}
			return s.Replace("|", Environment.NewLine);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000031AC File Offset: 0x000021AC
		public virtual string Name()
		{
			return "Work Task";
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000031C4 File Offset: 0x000021C4
		public override string CategoryName()
		{
			return A.R.GetString("Work");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000031E8 File Offset: 0x000021E8
		public virtual string ResumeDescription()
		{
			return "Description of task";
		}

		// Token: 0x0400000E RID: 14
		public BankAccount DirectDepositAccount = null;

		// Token: 0x0400000F RID: 15
		public int CreditScoreRequired = 0;

		// Token: 0x04000010 RID: 16
		public Hashtable WorkExperienceRequired = new Hashtable();

		// Token: 0x04000011 RID: 17
		public ArrayList AcademicExperienceRequired = new ArrayList();

		// Token: 0x04000012 RID: 18
		public ArrayList PayStubs = new ArrayList();

		// Token: 0x04000013 RID: 19
		public float HoursThisWeek;

		// Token: 0x04000014 RID: 20
		public int Allowances = 1;

		// Token: 0x04000015 RID: 21
		public float AdditionalWitholding = 0f;

		// Token: 0x04000016 RID: 22
		public bool ExemptFromWitholding = false;

		// Token: 0x04000017 RID: 23
		public float HourlyWage = 7.5f;

		// Token: 0x04000018 RID: 24
		public InsurancePolicy HealthInsurance;

		// Token: 0x04000019 RID: 25
		public float R401KMatch = -1f;

		// Token: 0x0400001A RID: 26
		public float[] R401KAllocations;

		// Token: 0x0400001B RID: 27
		public float R401KPercentWitheld;

		// Token: 0x0400001C RID: 28
		public float BonusPotential = 0f;
	}
}
