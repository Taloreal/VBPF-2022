using System;
using KMI.Sim;

namespace KMI.Biz.City
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class BuildingType
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000344C File Offset: 0x0000244C
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00003464 File Offset: 0x00002464
		public int Index
		{
			get
			{
				return this.index;
			}
			set
			{
				this.index = value;
				this.Height = S.R.GetImage("Building" + this.index).Height;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00003498 File Offset: 0x00002498
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000034B0 File Offset: 0x000024B0
		public int MaxOccupants
		{
			get
			{
				return this.maxOccupants;
			}
			set
			{
				this.maxOccupants = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000034BC File Offset: 0x000024BC
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000034D4 File Offset: 0x000024D4
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000034E0 File Offset: 0x000024E0
		// (set) Token: 0x06000039 RID: 57 RVA: 0x000034F8 File Offset: 0x000024F8
		public bool CanTakeSign
		{
			get
			{
				return this.canTakeSign;
			}
			set
			{
				this.canTakeSign = value;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003504 File Offset: 0x00002504
		public override bool Equals(object obj)
		{
			return obj != null && this.index == ((BuildingType)obj).index;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003538 File Offset: 0x00002538
		public static bool operator ==(BuildingType obj1, BuildingType obj2)
		{
			bool result;
			if (object.ReferenceEquals(obj1, null))
			{
				result = object.ReferenceEquals(obj2, null);
			}
			else
			{
				result = obj1.Equals(obj2);
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000356C File Offset: 0x0000256C
		public static bool operator !=(BuildingType obj1, BuildingType obj2)
		{
			return !(obj1 == obj2);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003588 File Offset: 0x00002588
		public int CompareTo(object obj)
		{
			return this.index - ((BuildingType)obj).index;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000035AC File Offset: 0x000025AC
		public override int GetHashCode()
		{
			return this.index;
		}

		// Token: 0x04000031 RID: 49
		protected int index;

		// Token: 0x04000032 RID: 50
		protected int maxOccupants;

		// Token: 0x04000033 RID: 51
		protected string name;

		// Token: 0x04000034 RID: 52
		protected bool canTakeSign;

		// Token: 0x04000035 RID: 53
		public int Height;
	}
}
