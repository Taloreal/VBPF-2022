using System;
using System.Collections;
using System.Reflection;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for AppConstants.
	/// </summary>
	// Token: 0x0200000A RID: 10
	public class AppConstants
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000040BC File Offset: 0x000030BC
		static AppConstants()
		{
			Assembly a = typeof(AppConstants).Assembly;
			AppConstants.HomeMap = new MapV2();
			AppConstants.HomeMap.load(a, "KMI.VBPF1Lib.Data.HomeMap.xml");
			AppConstants.Work0Map = new MapV2();
			AppConstants.Work0Map.load(a, "KMI.VBPF1Lib.Data.Work0Map.xml");
			AppConstants.Work1Map = new MapV2();
			AppConstants.Work1Map.load(a, "KMI.VBPF1Lib.Data.Work1Map.xml");
			AppConstants.ClassMap = new MapV2();
			AppConstants.ClassMap.load(a, "KMI.VBPF1Lib.Data.ClassMap.xml");
			AppConstants.HealthFactorNames = new string[]
			{
				"Nutrition",
				"Sleep",
				"Exercise",
				"Relaxation",
				"Social Life"
			};
			AppConstants.HealthFactoryHistoryDays = new int[]
			{
				14,
				7,
				7,
				7,
				1
			};
			AppConstants.HealthFactorNeededPerDay = new float[]
			{
				2f,
				16f,
				2f,
				2f,
				0f
			};
			AppConstants.HealthFactorApplyForwardDays = new int[]
			{
				1,
				2,
				2,
				1,
				1
			};
		}

		// Token: 0x04000036 RID: 54
		public const int MinDaysCheckInMail = 2;

		// Token: 0x04000037 RID: 55
		public const int MaxDaysCheckInMail = 14;

		// Token: 0x04000038 RID: 56
		public const int MaxAbsencesPerMonth = 4;

		// Token: 0x04000039 RID: 57
		public const int MaxLatesPerMonth = 4;

		// Token: 0x0400003A RID: 58
		public const int BadCheckFee = 35;

		// Token: 0x0400003B RID: 59
		public const float MaxRent = 1200f;

		// Token: 0x0400003C RID: 60
		public const float MinRent = 200f;

		// Token: 0x0400003D RID: 61
		public const float CreditCardLoRate = 0.04f;

		// Token: 0x0400003E RID: 62
		public const float CreditCardHiRate = 0.08f;

		// Token: 0x0400003F RID: 63
		public const float MinCarDownPayment = 0.1f;

		// Token: 0x04000040 RID: 64
		public const float CarLoanLoRate = 0.03f;

		// Token: 0x04000041 RID: 65
		public const float CarLoanHiRate = 0.07f;

		// Token: 0x04000042 RID: 66
		public const int CarLoanTerm = 36;

		// Token: 0x04000043 RID: 67
		public const float MinMortgageDownPayment = 0f;

		// Token: 0x04000044 RID: 68
		public const float MortgageLoRate = 0.03f;

		// Token: 0x04000045 RID: 69
		public const float MortgageHiRate = 0.11f;

		// Token: 0x04000046 RID: 70
		public const int ClosingCosts = 4100;

		// Token: 0x04000047 RID: 71
		public const float StudentLoanLoRate = 0.01f;

		// Token: 0x04000048 RID: 72
		public const float StudentLoanHiRate = 0.06f;

		// Token: 0x04000049 RID: 73
		public const int StudentLoanTerm = 60;

		// Token: 0x0400004A RID: 74
		public const float MinCreditCardPayment = 0.01f;

		// Token: 0x0400004B RID: 75
		public const int MinCreditScoreCreditCard = 0;

		// Token: 0x0400004C RID: 76
		public const int MinCreditScoreStudentLoan = 0;

		// Token: 0x0400004D RID: 77
		public const int MinCreditScoreCarLoan = 510;

		// Token: 0x0400004E RID: 78
		public const int MinCreditScoreMortgage = 610;

		// Token: 0x0400004F RID: 79
		public const int FoodExpiresAfterWeeks = 4;

		// Token: 0x04000050 RID: 80
		public const int MinDaysTillBreakdown = 120;

		// Token: 0x04000051 RID: 81
		public const int MaxDaysTillBreakdown = 365;

		// Token: 0x04000052 RID: 82
		public const int CreditScoreWarn = 500;

		// Token: 0x04000053 RID: 83
		public const int CreditScoreEnd = 400;

		// Token: 0x04000054 RID: 84
		public const int DaysToRehireIfFired = 180;

		// Token: 0x04000055 RID: 85
		public const int DaysToRehireIfQuit = 90;

		// Token: 0x04000056 RID: 86
		public const int BackEndLoadYears = 5;

		// Token: 0x04000057 RID: 87
		public const float RealEstateCommission = 0.05f;

		// Token: 0x04000058 RID: 88
		public const int CreditHistoryMonths = 36;

		// Token: 0x04000059 RID: 89
		public const int MaxStudents = 8;

		// Token: 0x0400005A RID: 90
		public const int DefaultSimulatedTimePerStep = 20000;

		// Token: 0x0400005B RID: 91
		public const int MaxCustomers = 20;

		// Token: 0x0400005C RID: 92
		public const int DeptStores = 3;

		// Token: 0x0400005D RID: 93
		public const float ReimbursementPerStep = 0.005f;

		// Token: 0x0400005E RID: 94
		public const string PaymentDescription = "Payment-Thank You!";

		// Token: 0x0400005F RID: 95
		public const string FinanceChargeDescription = "Finance Charges";

		// Token: 0x04000060 RID: 96
		public const int PeriodsPerDay = 48;

		// Token: 0x04000061 RID: 97
		public const int BillingDay = 28;

		// Token: 0x04000062 RID: 98
		public const int Frames = 9;

		// Token: 0x04000063 RID: 99
		public const int TeacherFrames = 28;

		// Token: 0x04000064 RID: 100
		public const int IrateFrames = 30;

		// Token: 0x04000065 RID: 101
		public const int TakeOrderFrames = 19;

		// Token: 0x04000066 RID: 102
		public const int JumpingJackFrames = 9;

		// Token: 0x04000067 RID: 103
		public const int DanceFrames = 27;

		// Token: 0x04000068 RID: 104
		public const int EatFrames = 10;

		// Token: 0x04000069 RID: 105
		public const int TypeFrames = 9;

		// Token: 0x0400006A RID: 106
		public const int HairBegin = 192;

		// Token: 0x0400006B RID: 107
		public const int HairEnd = 239;

		// Token: 0x0400006C RID: 108
		public const int SkinBegin = 0;

		// Token: 0x0400006D RID: 109
		public const int SkinEnd = 47;

		// Token: 0x0400006E RID: 110
		public const int ShirtBegin = 96;

		// Token: 0x0400006F RID: 111
		public const int ShirtEnd = 143;

		// Token: 0x04000070 RID: 112
		public const int PantsBegin = 48;

		// Token: 0x04000071 RID: 113
		public const int PantsEnd = 95;

		// Token: 0x04000072 RID: 114
		public const int ShoesBegin = 144;

		// Token: 0x04000073 RID: 115
		public const int ShoesEnd = 191;

		// Token: 0x04000074 RID: 116
		public const int Palettes = 18;

		// Token: 0x04000075 RID: 117
		public const int GenericPalettes = 6;

		// Token: 0x04000076 RID: 118
		public const float MaxFICAPerYear = 5840.4f;

		// Token: 0x04000077 RID: 119
		public static string[] HealthFactorNames;

		// Token: 0x04000078 RID: 120
		public static int[] HealthFactoryHistoryDays;

		// Token: 0x04000079 RID: 121
		public static int[] HealthFactorApplyForwardDays;

		// Token: 0x0400007A RID: 122
		public static float[] HealthFactorNeededPerDay;

		// Token: 0x0400007B RID: 123
		public static string[] FundCategories = new string[]
		{
			"U.S. Stocks",
			"Intl Stocks",
			"Bonds",
			"Money Markets"
		};

		// Token: 0x0400007C RID: 124
		public static MapV2 HomeMap;

		// Token: 0x0400007D RID: 125
		public static MapV2 ClassMap;

		// Token: 0x0400007E RID: 126
		public static MapV2 Work0Map;

		// Token: 0x0400007F RID: 127
		public static MapV2 Work1Map;

		// Token: 0x04000080 RID: 128
		public static Hashtable CarryAnchorPoints;

		// Token: 0x04000081 RID: 129
		public static int BuildingTypeCount = 20;

		// Token: 0x04000082 RID: 130
		public static float[] MPGs = new float[]
		{
			25f,
			29f,
			21f,
			16f,
			11f,
			15f
		};

		// Token: 0x0200000B RID: 11
		public enum HealthFactors
		{
			// Token: 0x04000084 RID: 132
			Eat,
			// Token: 0x04000085 RID: 133
			Sleep,
			// Token: 0x04000086 RID: 134
			Exercise,
			// Token: 0x04000087 RID: 135
			Relaxation,
			// Token: 0x04000088 RID: 136
			SocialLife
		}
	}
}
