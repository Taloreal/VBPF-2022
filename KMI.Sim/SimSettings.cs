using System;

namespace KMI.Sim
{
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class SimSettings
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0001A03C File Offset: 0x0001903C
		// (set) Token: 0x0600037E RID: 894 RVA: 0x0001A054 File Offset: 0x00019054
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}
			set
			{
				this.startDate = value;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0001A060 File Offset: 0x00019060
		// (set) Token: 0x06000380 RID: 896 RVA: 0x0001A078 File Offset: 0x00019078
		public DateTime StopDate
		{
			get
			{
				return this.stopDate;
			}
			set
			{
				this.stopDate = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0001A084 File Offset: 0x00019084
		// (set) Token: 0x06000382 RID: 898 RVA: 0x0001A09C File Offset: 0x0001909C
		public int RandomSeed
		{
			get
			{
				return this.randomSeed;
			}
			set
			{
				this.randomSeed = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0001A0A8 File Offset: 0x000190A8
		// (set) Token: 0x06000384 RID: 900 RVA: 0x0001A0C0 File Offset: 0x000190C0
		public byte[] PdfAssignment
		{
			get
			{
				return this.pdfAssignment;
			}
			set
			{
				this.pdfAssignment = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0001A0CC File Offset: 0x000190CC
		// (set) Token: 0x06000386 RID: 902 RVA: 0x0001A0E4 File Offset: 0x000190E4
		public bool Seasonality
		{
			get
			{
				return this.seasonality;
			}
			set
			{
				this.seasonality = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0001A0F0 File Offset: 0x000190F0
		// (set) Token: 0x06000388 RID: 904 RVA: 0x0001A108 File Offset: 0x00019108
		public bool LevelManagementOn
		{
			get
			{
				return this.levelManagementOn;
			}
			set
			{
				this.levelManagementOn = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000389 RID: 905 RVA: 0x0001A114 File Offset: 0x00019114
		// (set) Token: 0x0600038A RID: 906 RVA: 0x0001A12C File Offset: 0x0001912C
		public virtual int Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0001A138 File Offset: 0x00019138
		// (set) Token: 0x0600038C RID: 908 RVA: 0x0001A150 File Offset: 0x00019150
		public int StudentOrg
		{
			get
			{
				return this.studentOrg;
			}
			set
			{
				this.studentOrg = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0001A15C File Offset: 0x0001915C
		// (set) Token: 0x0600038E RID: 910 RVA: 0x0001A174 File Offset: 0x00019174
		public string BlockMessagesContaining
		{
			get
			{
				return this.blockMessagesContaining;
			}
			set
			{
				this.blockMessagesContaining = value;
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0001A180 File Offset: 0x00019180
		public virtual bool AllowInstructorToEdit(string propertyName)
		{
			return false;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0001A194 File Offset: 0x00019194
		// (set) Token: 0x06000391 RID: 913 RVA: 0x0001A1AC File Offset: 0x000191AC
		public bool ReservedBool1
		{
			get
			{
				return this.reservedBool1;
			}
			set
			{
				this.reservedBool1 = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0001A1B8 File Offset: 0x000191B8
		// (set) Token: 0x06000393 RID: 915 RVA: 0x0001A1D0 File Offset: 0x000191D0
		public bool ReservedBool2
		{
			get
			{
				return this.reservedBool2;
			}
			set
			{
				this.reservedBool2 = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000394 RID: 916 RVA: 0x0001A1DC File Offset: 0x000191DC
		// (set) Token: 0x06000395 RID: 917 RVA: 0x0001A1F4 File Offset: 0x000191F4
		public bool ReservedBool3
		{
			get
			{
				return this.reservedBool3;
			}
			set
			{
				this.reservedBool3 = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000396 RID: 918 RVA: 0x0001A200 File Offset: 0x00019200
		// (set) Token: 0x06000397 RID: 919 RVA: 0x0001A218 File Offset: 0x00019218
		public float ReservedFloat1
		{
			get
			{
				return this.reservedFloat1;
			}
			set
			{
				this.reservedFloat1 = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0001A224 File Offset: 0x00019224
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0001A23C File Offset: 0x0001923C
		public float ReservedFloat2
		{
			get
			{
				return this.reservedFloat2;
			}
			set
			{
				this.reservedFloat2 = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600039A RID: 922 RVA: 0x0001A248 File Offset: 0x00019248
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0001A260 File Offset: 0x00019260
		public float ReservedFloat3
		{
			get
			{
				return this.reservedFloat3;
			}
			set
			{
				this.reservedFloat3 = value;
			}
		}

		// Token: 0x0400023E RID: 574
		protected DateTime startDate = new DateTime(2008, 1, 5, 23, 59, 59);

		// Token: 0x0400023F RID: 575
		protected DateTime stopDate;

		// Token: 0x04000240 RID: 576
		protected int randomSeed = -1;

		// Token: 0x04000241 RID: 577
		protected byte[] pdfAssignment;

		// Token: 0x04000242 RID: 578
		protected bool seasonality = true;

		// Token: 0x04000243 RID: 579
		protected bool levelManagementOn = true;

		// Token: 0x04000244 RID: 580
		protected int level = 0;

		// Token: 0x04000245 RID: 581
		protected int studentOrg = 0;

		// Token: 0x04000246 RID: 582
		protected string blockMessagesContaining = "";

		// Token: 0x04000247 RID: 583
		protected bool reservedBool1;

		// Token: 0x04000248 RID: 584
		protected bool reservedBool2;

		// Token: 0x04000249 RID: 585
		protected bool reservedBool3;

		// Token: 0x0400024A RID: 586
		protected float reservedFloat1;

		// Token: 0x0400024B RID: 587
		protected float reservedFloat2;

		// Token: 0x0400024C RID: 588
		protected float reservedFloat3;
	}
}
