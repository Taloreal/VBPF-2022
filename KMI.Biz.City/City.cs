using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;

namespace KMI.Biz.City
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class City : ActiveObject
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000021CC File Offset: 0x000011CC
		public City()
		{
			this.blocks = new CityBlock[City.NUM_AVENUES, City.NUM_STREETS];
			for (int i = 0; i < City.NUM_STREETS; i++)
			{
				float num = 0f;
				for (int j = 0; j < City.NUM_AVENUES; j++)
				{
					float x = (float)i * City.BLOCK_WIDTH;
					this.blocks[j, i] = new CityBlock(this, j, i, City.LOTS_PER_BLOCK[j], new SizeF(City.BLOCK_WIDTH, City.BLOCK_HEIGHTS[j]), new PointF(x, num), City.AVENUE_WIDTH, City.STREET_WIDTH);
					num += City.BLOCK_HEIGHTS[j];
				}
			}
			float num2 = 0f;
			for (int k = 0; k < City.NUM_AVENUES; k++)
			{
				num2 += City.BLOCK_HEIGHTS[k];
			}
		}

		// Token: 0x17000001 RID: 1
		public CityBlock this[int avenueIndex, int streetIndex]
		{
			get
			{
				return this.blocks[avenueIndex, streetIndex];
			}
		}

		// Token: 0x17000002 RID: 2
		public Building this[int avenueIndex, int streetIndex, int lotIndex]
		{
			get
			{
				return this.blocks[avenueIndex, streetIndex][lotIndex];
			}
			set
			{
				this.blocks[avenueIndex, streetIndex][lotIndex] = value;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002318 File Offset: 0x00001318
		public ArrayList GetDrawables(int centerAvenue, int centerStreet)
		{
			int num = centerAvenue * City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS;
			int num2 = (centerAvenue + 1) * City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS;
			int num3 = centerStreet * City.NUM_STREETS / City.STREET_VIEWING_REGIONS;
			int num4 = (centerStreet + 1) * City.NUM_STREETS / City.STREET_VIEWING_REGIONS;
			ArrayList arrayList = new ArrayList();
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					arrayList.AddRange(this[i, j].GetDrawables(centerAvenue, centerStreet));
				}
			}
			return arrayList;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023BC File Offset: 0x000013BC
		public bool InViewCenteredOn(int avenue, int street, Point location)
		{
			int num = City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS;
			int num2 = City.NUM_STREETS / City.STREET_VIEWING_REGIONS;
			int num3 = avenue - num / 2;
			int num4 = num3 + num - 1;
			int num5 = street - num2 / 2;
			int num6 = num5 + num2 - 1;
			return location.X >= num3 && location.X <= num4 && (location.Y >= num5 & location.Y <= num6);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002438 File Offset: 0x00001438
		public ArrayList GetDrawablesCenteredOn(int avenue, int street)
		{
			int num = City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS;
			int num2 = City.NUM_STREETS / City.STREET_VIEWING_REGIONS;
			int num3 = avenue - num / 2;
			int num4 = num3 + num - 1;
			int num5 = street - num2 / 2;
			int num6 = num5 + num2 - 1;
			ArrayList arrayList = new ArrayList();
			for (int i = num3; i <= num4; i++)
			{
				for (int j = num5; j <= num6; j++)
				{
					arrayList.AddRange(this[i, j].GetDrawables(avenue, street));
				}
			}
			return arrayList;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000024DC File Offset: 0x000014DC
		public ArrayList GetDrawablesWholeCity()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < City.NUM_AVENUES; i++)
			{
				for (int j = 0; j < City.NUM_STREETS; j++)
				{
					arrayList.AddRange(this[i, j].GetDrawablesWholeCity());
				}
			}
			return arrayList;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000253C File Offset: 0x0000153C
		public static PointF Transform(float avenue, float street, float lotIndex)
		{
			float num = 0f;
			int num2 = 0;
			while ((float)num2 < avenue)
			{
				num += City.AVENUE_SPACING[num2];
				num2++;
			}
			num += lotIndex * City.LOT_SPACING;
			float num3 = street * City.STREET_SPACING;
			return new PointF(City.ORIGIN.X - num + num3, City.ORIGIN.Y + num / 2f + num3 / 2f);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000025B0 File Offset: 0x000015B0
		public static PointF Transform2(float avenue, float street, float lotIndex, int centeringAve, int centeringStreet)
		{
			float num = (float)centeringAve * City.AVENUE_SPACING[0];
			float num2 = (float)centeringStreet * City.STREET_SPACING;
			float num3 = avenue * City.AVENUE_SPACING[0];
			num3 += lotIndex * City.LOT_SPACING;
			float num4 = street * City.STREET_SPACING;
			return new PointF(City.ORIGIN.X - num3 + num4 + num - num2, City.ORIGIN.Y + num3 / 2f + num4 / 2f - num / 2f - num2 / 2f);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002638 File Offset: 0x00001638
		public static bool InverseTransformWholeCity(PointF screenLoc, ref int avenue, ref int street, ref int lot)
		{
			float num = (float)City.AVENUE_VIEWING_REGIONS;
			float x = screenLoc.X;
			float y = screenLoc.Y;
			float num2 = (-num * (x - (float)City.WHOLE_CITY_OFFSET.X - 2f * y + (float)(2 * City.WHOLE_CITY_OFFSET.Y)) - City.ORIGIN.X + 2f * City.ORIGIN.Y + (float)City.AVENUE_INVERSE_ADJUSTMENT) / (2f * City.AVENUE_SPACING[0]);
			float num3 = (num * (x - (float)City.WHOLE_CITY_OFFSET.X + 2f * y - (float)(2 * City.WHOLE_CITY_OFFSET.Y)) - City.ORIGIN.X - 2f * City.ORIGIN.Y + (float)City.STREET_INVERSE_ADJUSTMENT) / (2f * City.STREET_SPACING);
			avenue = (int)Math.Floor((double)num2);
			street = (int)Math.Floor((double)num3);
			lot = (int)Math.Min(Math.Floor((double)((num2 - (float)avenue) * (float)City.LOTS_PER_BLOCK[0])), (double)(City.LOTS_PER_BLOCK[0] - 1));
			return num2 < (float)City.NUM_AVENUES && num3 < (float)City.NUM_STREETS && num2 >= 0f && num3 >= 0f;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002778 File Offset: 0x00001778
		public static void BoundCenteringAveAndStreet(ref int avenue, ref int street)
		{
			int num = City.NUM_AVENUES / City.AVENUE_VIEWING_REGIONS;
			int num2 = City.NUM_STREETS / City.STREET_VIEWING_REGIONS;
			int num3 = avenue - num / 2;
			int num4 = num3 + num - 1;
			if (num3 < 0)
			{
				num4 = num - 1;
				avenue = num / 2;
			}
			if (num4 > City.NUM_AVENUES - 1)
			{
				num3 = City.NUM_AVENUES - num;
				num4 = City.NUM_AVENUES - 1;
				avenue = num3 + num / 2;
			}
			int num5 = street - num2 / 2;
			int num6 = num5 + num2 - 1;
			if (num5 < 0)
			{
				num6 = num2 - 1;
				street = num2 / 2;
			}
			if (num6 > City.NUM_STREETS - 1)
			{
				num5 = City.NUM_STREETS - num2;
				num6 = City.NUM_STREETS - 1;
				street = num5 + num2 / 2;
			}
		}

		// Token: 0x17000003 RID: 3
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000284E File Offset: 0x0000184E
		public int DirectionOfMigration
		{
			set
			{
				this.directionOfMigration = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002858 File Offset: 0x00001858
		public bool Filled
		{
			get
			{
				for (int i = 0; i < City.NUM_AVENUES; i++)
				{
					for (int j = 0; j < City.NUM_STREETS; j++)
					{
						for (int k = 0; k < this[i, j].NumLots; k++)
						{
							if (this[i, j, k] == null)
							{
								return false;
							}
						}
					}
				}
				return true;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000028D0 File Offset: 0x000018D0
		public Building GetRandomBuilding(int buildingTypeIndex)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < City.NUM_AVENUES; i++)
			{
				for (int j = 0; j < City.NUM_STREETS; j++)
				{
					for (int k = 0; k < this[i, j].NumLots; k++)
					{
						if (this[i, j, k] != null && this[i, j, k].BuildingType.Index == buildingTypeIndex)
						{
							arrayList.Add(this[i, j, k]);
						}
					}
				}
			}
			int count = arrayList.Count;
			Building result;
			if (count == 0)
			{
				result = null;
			}
			else
			{
				result = (Building)arrayList[S.ST.Random.Next(count)];
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000029AC File Offset: 0x000019AC
		public void RecomputeReachForBuildings(float scaleFactor)
		{
			for (int i = 0; i < City.NUM_AVENUES; i++)
			{
				for (int j = 0; j < City.NUM_STREETS; j++)
				{
					CityBlock cityBlock = this[i, j];
					for (int k = 0; k < cityBlock.NumLots; k++)
					{
						Building building = cityBlock[k];
						if (building != null)
						{
							float num = 0f;
							if (building.OnAvenue > -1)
							{
								num += this[building.OnAvenue, cityBlock.Street].AvenueTraffic.GetDensity();
							}
							num += cityBlock.StreetTraffic.GetDensity();
							building.Reach = (int)(num * scaleFactor);
						}
					}
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002A8C File Offset: 0x00001A8C
		public void PickVacantBuilding(int buildingTypeIndex, ref int avenue, ref int street, ref int lot)
		{
			ArrayList arrayList = new ArrayList();
			CityBlock[,] array = this.blocks;
			int upperBound = array.GetUpperBound(0);
			int upperBound2 = array.GetUpperBound(1);
			for (int i = array.GetLowerBound(0); i <= upperBound; i++)
			{
				for (int j = array.GetLowerBound(1); j <= upperBound2; j++)
				{
					CityBlock cityBlock = array[i, j];
					for (int k = 0; k < cityBlock.NumLots; k++)
					{
						Building building = cityBlock[k];
						if (building != null)
						{
							if (building != null && building.BuildingType == City.BuildingTypes[buildingTypeIndex] && building.Owner == null)
							{
								arrayList.Add(building);
							}
						}
					}
				}
			}
			if (arrayList.Count > 0)
			{
				Building building2 = (Building)arrayList[S.ST.Random.Next(arrayList.Count)];
				avenue = building2.Block.Avenue;
				street = building2.Block.Street;
				lot = building2.Lot;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002BD8 File Offset: 0x00001BD8
		public static float Distance(CityBlock b1, CityBlock b2)
		{
			return (float)(Math.Abs(b1.Street - b2.Street) + 2 * Math.Abs(b1.Avenue - b2.Avenue));
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002C14 File Offset: 0x00001C14
		public static PointF TransformWholeCity(float ave, float street, float lot)
		{
			float num = ave * City.AVENUE_SPACING[0];
			num += lot * City.LOT_SPACING;
			float num2 = street * City.STREET_SPACING;
			return new PointF((City.ORIGIN.X - num + num2) / (float)City.AVENUE_VIEWING_REGIONS + (float)City.WHOLE_CITY_OFFSET.X, (City.ORIGIN.Y + num / 2f + num2 / 2f) / (float)City.STREET_VIEWING_REGIONS + (float)City.WHOLE_CITY_OFFSET.Y);
		}

		// Token: 0x04000006 RID: 6
		protected CityBlock[,] blocks;

		// Token: 0x04000007 RID: 7
		public static int NUM_STREETS = 8;

		// Token: 0x04000008 RID: 8
		public static int NUM_AVENUES = 3;

		// Token: 0x04000009 RID: 9
		public static int[] LOTS_PER_BLOCK = new int[]
		{
			5,
			4,
			4
		};

		// Token: 0x0400000A RID: 10
		public static float BLOCK_WIDTH = 50.73f;

		// Token: 0x0400000B RID: 11
		public static float[] BLOCK_HEIGHTS = new float[]
		{
			153.17f,
			127.46f,
			127.46f
		};

		// Token: 0x0400000C RID: 12
		public static float STREET_WIDTH = 28.83f;

		// Token: 0x0400000D RID: 13
		public static float AVENUE_WIDTH = 24.6f;

		// Token: 0x0400000E RID: 14
		public static int ZONES = 9;

		// Token: 0x0400000F RID: 15
		public static BuildingType[] BuildingTypes;

		// Token: 0x04000010 RID: 16
		public static int BuildingTypeCount = 6;

		// Token: 0x04000011 RID: 17
		public static float STREET_SPACING = 45.42f;

		// Token: 0x04000012 RID: 18
		public static float LOT_SPACING = 23f;

		// Token: 0x04000013 RID: 19
		public static float[] AVENUE_SPACING = new float[]
		{
			135.17f,
			115.46f,
			115.46f
		};

		// Token: 0x04000014 RID: 20
		public static PointF ORIGIN = new PointF(342f, 69f);

		// Token: 0x04000015 RID: 21
		public static int AVENUE_VIEWING_REGIONS = 1;

		// Token: 0x04000016 RID: 22
		public static int STREET_VIEWING_REGIONS = 1;

		// Token: 0x04000017 RID: 23
		public static int AVENUE_REGION_OFFSET = 363;

		// Token: 0x04000018 RID: 24
		public static int STREET_REGION_OFFSET = 363;

		// Token: 0x04000019 RID: 25
		public static Point WHOLE_CITY_OFFSET = new Point(300, 100);

		// Token: 0x0400001A RID: 26
		public static int AVENUE_INVERSE_ADJUSTMENT = 0;

		// Token: 0x0400001B RID: 27
		public static int STREET_INVERSE_ADJUSTMENT = 0;

		// Token: 0x0400001C RID: 28
		protected int directionOfMigration = -1;

		// Token: 0x0400001D RID: 29
		public string VacantLotImageName;

		// Token: 0x0400001E RID: 30
		public int VacantLotImages;

		// Token: 0x0400001F RID: 31
		public int[,,] VacantLotImageIndices;
	}
}
