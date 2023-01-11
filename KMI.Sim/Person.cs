using System;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	public class Person : MovableActiveObject
	{
		// Token: 0x060001AB RID: 427 RVA: 0x0000DE3C File Offset: 0x0000CE3C
		public Person()
		{
			Random random = Simulator.Instance.SimState.Random;
			this.gender = (Person.GenderType)random.Next(2);
			this.race = (Person.RaceType)random.Next(3);
			if (this.gender == Person.GenderType.Male)
			{
				this.firstName = Utilities.GetRandomMaleFirstName(random);
			}
			else
			{
				this.firstName = Utilities.GetRandomFemaleFirstName(random);
			}
			this.lastName = Utilities.GetRandomLastName(random);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000DEBD File Offset: 0x0000CEBD
		public Person(Person.GenderType gender, Person.RaceType race, string firstName, string lastName)
		{
			this.gender = gender;
			this.race = race;
			this.firstName = firstName;
			this.lastName = lastName;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000DEEC File Offset: 0x0000CEEC
		public Person.GenderType Gender
		{
			get
			{
				return this.gender;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000DF04 File Offset: 0x0000CF04
		public Person.RaceType Race
		{
			get
			{
				return this.race;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000DF1C File Offset: 0x0000CF1C
		public string FirstName
		{
			get
			{
				return this.firstName;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000DF34 File Offset: 0x0000CF34
		public string LastName
		{
			get
			{
				return this.lastName;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000DF4C File Offset: 0x0000CF4C
		public string FullName
		{
			get
			{
				return this.firstName + " " + this.lastName;
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000DF74 File Offset: 0x0000CF74
		public override bool Move()
		{
			this.footForward = 1 - this.footForward;
			return base.Move();
		}

		// Token: 0x040000FD RID: 253
		protected Person.GenderType gender;

		// Token: 0x040000FE RID: 254
		protected Person.RaceType race;

		// Token: 0x040000FF RID: 255
		protected string firstName;

		// Token: 0x04000100 RID: 256
		protected string lastName;

		// Token: 0x04000101 RID: 257
		protected int footForward = 0;

		// Token: 0x02000026 RID: 38
		public enum GenderType
		{
			// Token: 0x04000103 RID: 259
			Male,
			// Token: 0x04000104 RID: 260
			Female
		}

		// Token: 0x02000027 RID: 39
		public enum RaceType
		{
			// Token: 0x04000106 RID: 262
			Caucasian,
			// Token: 0x04000107 RID: 263
			African,
			// Token: 0x04000108 RID: 264
			Hispanic
		}
	}
}
