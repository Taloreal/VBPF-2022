using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public class Place
	{
		// Token: 0x060003F4 RID: 1012 RVA: 0x0001CC12 File Offset: 0x0001BC12
		public Place()
		{
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001CC3E File Offset: 0x0001BC3E
		public Place(PointF location)
		{
			this.Location = location;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0001CC74 File Offset: 0x0001BC74
		public void Link(Place otherPlace)
		{
			if (!this.LinkedPlaces.Contains(otherPlace))
			{
				this.LinkedPlaces.Add(otherPlace);
				otherPlace.Link(this);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x0001CCAC File Offset: 0x0001BCAC
		public bool UnderConstruction
		{
			get
			{
				return S.ST.Now < this.EndConstruction;
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0001CCD4 File Offset: 0x0001BCD4
		public override bool Equals(object obj)
		{
			Place place = (Place)obj;
			return Utilities.DistanceBetween(this.Location, place.Location) < 3f;
		}

		// Token: 0x04000296 RID: 662
		public PointF Location;

		// Token: 0x04000297 RID: 663
		public ArrayList LinkedPlaces = new ArrayList();

		// Token: 0x04000298 RID: 664
		public bool tempIsDead;

		// Token: 0x04000299 RID: 665
		public float tempDistance;

		// Token: 0x0400029A RID: 666
		public Place tempNextLink;

		// Token: 0x0400029B RID: 667
		public float SpeedLimit = Place.DefaultSpeedLimit;

		// Token: 0x0400029C RID: 668
		public static float DefaultSpeedLimit = 0.18f;

		// Token: 0x0400029D RID: 669
		public DateTime EndConstruction = Place.NoConstruction;

		// Token: 0x0400029E RID: 670
		public static DateTime NoConstruction = DateTime.MinValue;

		// Token: 0x0200006D RID: 109
		[Serializable]
		public class PlaceLoader
		{
			// Token: 0x170000EE RID: 238
			// (get) Token: 0x060003FA RID: 1018 RVA: 0x0001CD1C File Offset: 0x0001BD1C
			// (set) Token: 0x060003FB RID: 1019 RVA: 0x0001CD34 File Offset: 0x0001BD34
			public int X
			{
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060003FC RID: 1020 RVA: 0x0001CD40 File Offset: 0x0001BD40
			// (set) Token: 0x060003FD RID: 1021 RVA: 0x0001CD58 File Offset: 0x0001BD58
			public int Y
			{
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x060003FE RID: 1022 RVA: 0x0001CD64 File Offset: 0x0001BD64
			// (set) Token: 0x060003FF RID: 1023 RVA: 0x0001CD7C File Offset: 0x0001BD7C
			public string Links
			{
				get
				{
					return this.links;
				}
				set
				{
					this.links = value;
				}
			}

			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x06000400 RID: 1024 RVA: 0x0001CD88 File Offset: 0x0001BD88
			// (set) Token: 0x06000401 RID: 1025 RVA: 0x0001CDA0 File Offset: 0x0001BDA0
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

			// Token: 0x0400029F RID: 671
			protected int x;

			// Token: 0x040002A0 RID: 672
			protected int y;

			// Token: 0x040002A1 RID: 673
			protected string links;

			// Token: 0x040002A2 RID: 674
			protected string name;
		}
	}
}
