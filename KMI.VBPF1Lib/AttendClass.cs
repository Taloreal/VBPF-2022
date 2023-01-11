using System;
using System.Drawing;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FastFoodCustomer.
	/// </summary>
	// Token: 0x02000010 RID: 16
	[Serializable]
	public class AttendClass : Task
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00005ED0 File Offset: 0x00004ED0
		public override bool Do()
		{
			switch (this.State)
			{
			case AttendClass.States.Init:
				if (!base.Building.Persons.Contains(this.Owner))
				{
					base.Building.Persons.Add(this.Owner);
				}
				this.chair = this.Course.Students.IndexOf(this.Owner);
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				this.Owner.Path = base.Building.Map.findPath(this.Owner.Location, "Chair" + this.chair).ToPoints();
				this.State = AttendClass.States.ToChair;
				break;
			case AttendClass.States.ToChair:
				if (this.Owner.Move())
				{
					this.State = AttendClass.States.AtChair;
					this.Owner.Pose = "SitNE";
				}
				break;
			case AttendClass.States.AtChair:
				if (A.ST.Period == this.EndPeriod)
				{
					this.Owner.Path = base.Building.Map.findPath("Chair" + this.chair, "EntryPoint").ToPoints();
					this.Owner.Pose = "Walk";
					this.State = AttendClass.States.FromChair;
					this.daysInCourse++;
				}
				break;
			case AttendClass.States.FromChair:
				this.Owner.Location = base.Building.Map.getNode("EntryPoint").Location;
				if (this.Owner.Drone)
				{
					DateTime tomorrow = A.ST.Now.AddDays(1.0);
					this.Owner.WakeupTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day).AddHours((double)((float)this.StartPeriod / 2f) - (0.20000000298023224 + 0.10000000149011612 * A.ST.Random.NextDouble()));
					base.Building.Persons.Remove(this.Owner);
					this.State = AttendClass.States.Init;
				}
				else if (this.daysInCourse >= this.Course.Days)
				{
					this.Course.Students.Remove(this.Owner);
					AppEntity e = base.GetAppEntity();
					A.SA.DeleteTask(e.ID, this.ID);
					e.AcademicTaskHistory.Add(this.ID, this);
					e.Player.SendMessage(A.R.GetString("Congratulations! You completed your course: {0}. A diploma will now appear on your wall.", new object[]
					{
						this.Course.Name
					}), "", NotificationColor.Green);
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00006214 File Offset: 0x00005214
		public override string CategoryName()
		{
			return A.R.GetString("Education");
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00006235 File Offset: 0x00005235
		public override void CleanUp()
		{
			base.CleanUp();
			this.State = AttendClass.States.Init;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00006248 File Offset: 0x00005248
		public override Color GetColor()
		{
			return Color.LightCoral;
		}

		// Token: 0x040000B1 RID: 177
		public AttendClass.States State = AttendClass.States.Init;

		// Token: 0x040000B2 RID: 178
		public int daysInCourse = 0;

		// Token: 0x040000B3 RID: 179
		public Course Course;

		// Token: 0x040000B4 RID: 180
		private int chair;

		// Token: 0x02000011 RID: 17
		public enum States
		{
			// Token: 0x040000B6 RID: 182
			Init,
			// Token: 0x040000B7 RID: 183
			ToChair,
			// Token: 0x040000B8 RID: 184
			AtChair,
			// Token: 0x040000B9 RID: 185
			FromChair
		}
	}
}
