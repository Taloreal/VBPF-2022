using System;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// A collection of fields and properpties that alter simulation
	/// settings for the application.  These properties can be
	/// altered during runtime via reflectiona and a hidden screen that
	/// exposes these properties and their values. 
	/// </summary>
	// Token: 0x0200007E RID: 126
	[Serializable]
	public class AppSimSettings : SimSettings
	{
		/// <summary>
		/// Default Constructor.
		/// </summary>
		// Token: 0x06000330 RID: 816 RVA: 0x00036420 File Offset: 0x00035420
		public AppSimSettings()
		{
			base.StartDate = new DateTime(2010, 1, 2, 23, 59, 59);
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00036774 File Offset: 0x00035774
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0003678C File Offset: 0x0003578C
		public float InflationRate
		{
			get
			{
				return this.inflationRate;
			}
			set
			{
				this.inflationRate = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00036798 File Offset: 0x00035798
		// (set) Token: 0x06000334 RID: 820 RVA: 0x000367B0 File Offset: 0x000357B0
		public bool AutoPayRentElectric
		{
			get
			{
				return this.autoPayRentElectric;
			}
			set
			{
				this.autoPayRentElectric = value;
				if (value)
				{
					AppEntity e = (AppEntity)A.ST.Entity[A.MF.CurrentEntityID];
					if (e != null && ((CheckingAccount)e.BankAccounts.GetByIndex(0)).RecurringPayments.Count == 0)
					{
						((CheckingAccount)e.BankAccounts.GetByIndex(0)).RecurringPayments.Clear();
						RecurringPayment r = new RecurringPayment();
						r.Amount = (float)e.Dwelling.Rent;
						r.Day = 2;
						r.PayeeAccountNumber = ((BankAccount)e.MerchantAccounts["City Property Mgt"]).AccountNumber;
						r.PayeeName = ((BankAccount)e.MerchantAccounts["City Property Mgt"]).BankName;
						((CheckingAccount)e.BankAccounts.GetByIndex(0)).RecurringPayments.Add(r);
						r = new RecurringPayment();
						r.Amount = A.ST.ElectricityCost;
						r.Day = 2;
						r.PayeeAccountNumber = ((BankAccount)e.MerchantAccounts["NRG Electric"]).AccountNumber;
						r.PayeeName = ((BankAccount)e.MerchantAccounts["NRG Electric"]).BankName;
						((CheckingAccount)e.BankAccounts.GetByIndex(0)).RecurringPayments.Add(r);
					}
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00036938 File Offset: 0x00035938
		// (set) Token: 0x06000336 RID: 822 RVA: 0x00036950 File Offset: 0x00035950
		public float InitialCash
		{
			get
			{
				return this.initialCash;
			}
			set
			{
				this.initialCash = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0003695C File Offset: 0x0003595C
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00036974 File Offset: 0x00035974
		public float InitialHealth
		{
			get
			{
				return this.initialHealth;
			}
			set
			{
				this.initialHealth = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00036980 File Offset: 0x00035980
		// (set) Token: 0x0600033A RID: 826 RVA: 0x00036998 File Offset: 0x00035998
		public int HealthFactorsToConsider
		{
			get
			{
				return this.healthFactorsToConsider;
			}
			set
			{
				this.healthFactorsToConsider = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600033B RID: 827 RVA: 0x000369A4 File Offset: 0x000359A4
		// (set) Token: 0x0600033C RID: 828 RVA: 0x000369BC File Offset: 0x000359BC
		public bool Sickness
		{
			get
			{
				return this.sickness;
			}
			set
			{
				this.sickness = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600033D RID: 829 RVA: 0x000369C8 File Offset: 0x000359C8
		// (set) Token: 0x0600033E RID: 830 RVA: 0x000369E0 File Offset: 0x000359E0
		public bool FireForAbsencesLateness
		{
			get
			{
				return this.fireForAbsencesLateness;
			}
			set
			{
				this.fireForAbsencesLateness = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600033F RID: 831 RVA: 0x000369EC File Offset: 0x000359EC
		// (set) Token: 0x06000340 RID: 832 RVA: 0x00036A04 File Offset: 0x00035A04
		public string Surprises
		{
			get
			{
				return this.surprises;
			}
			set
			{
				this.surprises = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000341 RID: 833 RVA: 0x00036A10 File Offset: 0x00035A10
		// (set) Token: 0x06000342 RID: 834 RVA: 0x00036A28 File Offset: 0x00035A28
		public bool CloseSomeBusinesses
		{
			get
			{
				return this.closeSomeBusinesses;
			}
			set
			{
				this.closeSomeBusinesses = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00036A34 File Offset: 0x00035A34
		// (set) Token: 0x06000344 RID: 836 RVA: 0x00036A4C File Offset: 0x00035A4C
		public bool EndOnLowCreditScore
		{
			get
			{
				return this.endOnLowCreditScore;
			}
			set
			{
				this.endOnLowCreditScore = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00036A58 File Offset: 0x00035A58
		// (set) Token: 0x06000346 RID: 838 RVA: 0x00036A70 File Offset: 0x00035A70
		public bool AutofillCheckRegister
		{
			get
			{
				return this.autofillCheckRegister;
			}
			set
			{
				this.autofillCheckRegister = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00036A7C File Offset: 0x00035A7C
		// (set) Token: 0x06000348 RID: 840 RVA: 0x00036A94 File Offset: 0x00035A94
		public bool AIParties
		{
			get
			{
				return this.aIParties;
			}
			set
			{
				this.aIParties = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00036AA0 File Offset: 0x00035AA0
		// (set) Token: 0x0600034A RID: 842 RVA: 0x00036AB8 File Offset: 0x00035AB8
		public bool HealthInsuranceForFastFoodJobs
		{
			get
			{
				return this.healthInsuranceForFastFoodJobs;
			}
			set
			{
				this.healthInsuranceForFastFoodJobs = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00036AC4 File Offset: 0x00035AC4
		// (set) Token: 0x0600034C RID: 844 RVA: 0x00036ADC File Offset: 0x00035ADC
		public bool ScheduleReadOnly
		{
			get
			{
				return this.scheduleReadOnly;
			}
			set
			{
				this.scheduleReadOnly = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00036AE8 File Offset: 0x00035AE8
		// (set) Token: 0x0600034E RID: 846 RVA: 0x00036B00 File Offset: 0x00035B00
		public DateTime DislocatedShoulderDate
		{
			get
			{
				return this.dislocatedShoulderDate;
			}
			set
			{
				this.dislocatedShoulderDate = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00036B0C File Offset: 0x00035B0C
		// (set) Token: 0x06000350 RID: 848 RVA: 0x00036B24 File Offset: 0x00035B24
		public DateTime BreakInDate
		{
			get
			{
				return this.breakInDate;
			}
			set
			{
				this.breakInDate = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00036B30 File Offset: 0x00035B30
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00036B48 File Offset: 0x00035B48
		public bool Sales
		{
			get
			{
				return this.sales;
			}
			set
			{
				this.sales = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00036B54 File Offset: 0x00035B54
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00036B6C File Offset: 0x00035B6C
		public bool IncludeOtherLiabilities
		{
			get
			{
				return this.includeOtherLiabilities;
			}
			set
			{
				this.includeOtherLiabilities = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00036B78 File Offset: 0x00035B78
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00036B90 File Offset: 0x00035B90
		public bool DisableFW4
		{
			get
			{
				return this.disableFW4;
			}
			set
			{
				this.disableFW4 = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00036B9C File Offset: 0x00035B9C
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00036BB4 File Offset: 0x00035BB4
		public bool AlwaysUseTaxAccountant
		{
			get
			{
				return this.alwaysUseTaxAccountant;
			}
			set
			{
				this.alwaysUseTaxAccountant = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00036BC0 File Offset: 0x00035BC0
		// (set) Token: 0x0600035A RID: 858 RVA: 0x00036BD8 File Offset: 0x00035BD8
		public bool ApartmentsForRentEnabledForOwner
		{
			get
			{
				return this.apartmentsForRentEnabledForOwner;
			}
			set
			{
				this.apartmentsForRentEnabledForOwner = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00036BE4 File Offset: 0x00035BE4
		// (set) Token: 0x0600035C RID: 860 RVA: 0x00036BFC File Offset: 0x00035BFC
		public bool ApartmentsForRentEnabledForNonOwner
		{
			get
			{
				return this.apartmentsForRentEnabledForNonOwner;
			}
			set
			{
				this.apartmentsForRentEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00036C08 File Offset: 0x00035C08
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00036C20 File Offset: 0x00035C20
		public bool TransportationEnabledForOwner
		{
			get
			{
				return this.transportationEnabledForOwner;
			}
			set
			{
				this.transportationEnabledForOwner = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00036C2C File Offset: 0x00035C2C
		// (set) Token: 0x06000360 RID: 864 RVA: 0x00036C44 File Offset: 0x00035C44
		public bool TransportationEnabledForNonOwner
		{
			get
			{
				return this.transportationEnabledForNonOwner;
			}
			set
			{
				this.transportationEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00036C50 File Offset: 0x00035C50
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00036C68 File Offset: 0x00035C68
		public bool ScheduleEnabledForOwner
		{
			get
			{
				return this.scheduleEnabledForOwner;
			}
			set
			{
				this.scheduleEnabledForOwner = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00036C74 File Offset: 0x00035C74
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00036C8C File Offset: 0x00035C8C
		public bool ScheduleEnabledForNonOwner
		{
			get
			{
				return this.scheduleEnabledForNonOwner;
			}
			set
			{
				this.scheduleEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00036C98 File Offset: 0x00035C98
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00036CB0 File Offset: 0x00035CB0
		public bool CondosForSaleEnabledForOwner
		{
			get
			{
				return this.condosForSaleEnabledForOwner;
			}
			set
			{
				this.condosForSaleEnabledForOwner = value;
				if (value)
				{
					A.ST.City.SetupCondoOfferings();
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00036CE0 File Offset: 0x00035CE0
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00036CF8 File Offset: 0x00035CF8
		public bool CondosForSaleEnabledForNonOwner
		{
			get
			{
				return this.condosForSaleEnabledForNonOwner;
			}
			set
			{
				this.condosForSaleEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00036D04 File Offset: 0x00035D04
		// (set) Token: 0x0600036A RID: 874 RVA: 0x00036D1C File Offset: 0x00035D1C
		public bool WorkEnabledForOwner
		{
			get
			{
				return this.workEnabledForOwner;
			}
			set
			{
				this.workEnabledForOwner = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00036D28 File Offset: 0x00035D28
		// (set) Token: 0x0600036C RID: 876 RVA: 0x00036D40 File Offset: 0x00035D40
		public bool WorkEnabledForNonOwner
		{
			get
			{
				return this.workEnabledForNonOwner;
			}
			set
			{
				this.workEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00036D4C File Offset: 0x00035D4C
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00036D64 File Offset: 0x00035D64
		public bool EducationEnabledForOwner
		{
			get
			{
				return this.educationEnabledForOwner;
			}
			set
			{
				this.educationEnabledForOwner = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600036F RID: 879 RVA: 0x00036D70 File Offset: 0x00035D70
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00036D88 File Offset: 0x00035D88
		public bool EducationEnabledForNonOwner
		{
			get
			{
				return this.educationEnabledForNonOwner;
			}
			set
			{
				this.educationEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000371 RID: 881 RVA: 0x00036D94 File Offset: 0x00035D94
		// (set) Token: 0x06000372 RID: 882 RVA: 0x00036DAC File Offset: 0x00035DAC
		public bool TaxesEnabledForOwner
		{
			get
			{
				return this.taxesEnabledForOwner;
			}
			set
			{
				this.taxesEnabledForOwner = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00036DB8 File Offset: 0x00035DB8
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00036DD0 File Offset: 0x00035DD0
		public bool TaxesEnabledForNonOwner
		{
			get
			{
				return this.taxesEnabledForNonOwner;
			}
			set
			{
				this.taxesEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00036DDC File Offset: 0x00035DDC
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00036DF4 File Offset: 0x00035DF4
		public bool ChangeWitholdingEnabledForOwner
		{
			get
			{
				return this.changeWitholdingEnabledForOwner;
			}
			set
			{
				this.changeWitholdingEnabledForOwner = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00036E00 File Offset: 0x00035E00
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00036E18 File Offset: 0x00035E18
		public bool ChangeWitholdingEnabledForNonOwner
		{
			get
			{
				return this.changeWitholdingEnabledForNonOwner;
			}
			set
			{
				this.changeWitholdingEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00036E24 File Offset: 0x00035E24
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00036E3C File Offset: 0x00035E3C
		public bool ChangeMethodOfPaymentEnabledForOwner
		{
			get
			{
				return this.changeMethodOfPaymentEnabledForOwner;
			}
			set
			{
				this.changeMethodOfPaymentEnabledForOwner = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00036E48 File Offset: 0x00035E48
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00036E60 File Offset: 0x00035E60
		public bool ChangeMethodOfPaymentEnabledForNonOwner
		{
			get
			{
				return this.changeMethodOfPaymentEnabledForNonOwner;
			}
			set
			{
				this.changeMethodOfPaymentEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600037D RID: 893 RVA: 0x00036E6C File Offset: 0x00035E6C
		// (set) Token: 0x0600037E RID: 894 RVA: 0x00036E84 File Offset: 0x00035E84
		public bool ChangeRetirementContributionEnabledForOwner
		{
			get
			{
				return this.changeRetirementContributionEnabledForOwner;
			}
			set
			{
				this.changeRetirementContributionEnabledForOwner = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00036E90 File Offset: 0x00035E90
		// (set) Token: 0x06000380 RID: 896 RVA: 0x00036EA8 File Offset: 0x00035EA8
		public bool ChangeRetirementContributionEnabledForNonOwner
		{
			get
			{
				return this.changeRetirementContributionEnabledForNonOwner;
			}
			set
			{
				this.changeRetirementContributionEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00036EB4 File Offset: 0x00035EB4
		// (set) Token: 0x06000382 RID: 898 RVA: 0x00036ECC File Offset: 0x00035ECC
		public bool PayBillsEnabledForOwner
		{
			get
			{
				return this.payBillsEnabledForOwner;
			}
			set
			{
				this.payBillsEnabledForOwner = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00036ED8 File Offset: 0x00035ED8
		// (set) Token: 0x06000384 RID: 900 RVA: 0x00036EF0 File Offset: 0x00035EF0
		public bool PayBillsEnabledForNonOwner
		{
			get
			{
				return this.payBillsEnabledForNonOwner;
			}
			set
			{
				this.payBillsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00036EFC File Offset: 0x00035EFC
		// (set) Token: 0x06000386 RID: 902 RVA: 0x00036F14 File Offset: 0x00035F14
		public bool BankingEnabledForOwner
		{
			get
			{
				return this.bankingEnabledForOwner;
			}
			set
			{
				this.bankingEnabledForOwner = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00036F20 File Offset: 0x00035F20
		// (set) Token: 0x06000388 RID: 904 RVA: 0x00036F38 File Offset: 0x00035F38
		public bool BankingEnabledForNonOwner
		{
			get
			{
				return this.bankingEnabledForNonOwner;
			}
			set
			{
				this.bankingEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00036F44 File Offset: 0x00035F44
		// (set) Token: 0x0600038A RID: 906 RVA: 0x00036F5C File Offset: 0x00035F5C
		public bool OnlineBankingEnabledForOwner
		{
			get
			{
				return this.onlineBankingEnabledForOwner;
			}
			set
			{
				this.onlineBankingEnabledForOwner = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00036F68 File Offset: 0x00035F68
		// (set) Token: 0x0600038C RID: 908 RVA: 0x00036F80 File Offset: 0x00035F80
		public bool OnlineBankingEnabledForNonOwner
		{
			get
			{
				return this.onlineBankingEnabledForNonOwner;
			}
			set
			{
				this.onlineBankingEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00036F8C File Offset: 0x00035F8C
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00036FA4 File Offset: 0x00035FA4
		public bool CreditCardsEnabledForOwner
		{
			get
			{
				return this.creditCardsEnabledForOwner;
			}
			set
			{
				this.creditCardsEnabledForOwner = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00036FB0 File Offset: 0x00035FB0
		// (set) Token: 0x06000390 RID: 912 RVA: 0x00036FC8 File Offset: 0x00035FC8
		public bool CreditCardsEnabledForNonOwner
		{
			get
			{
				return this.creditCardsEnabledForNonOwner;
			}
			set
			{
				this.creditCardsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00036FD4 File Offset: 0x00035FD4
		// (set) Token: 0x06000392 RID: 914 RVA: 0x00036FEC File Offset: 0x00035FEC
		public bool ShopForFoodEnabledForOwner
		{
			get
			{
				return this.shopForFoodEnabledForOwner;
			}
			set
			{
				this.shopForFoodEnabledForOwner = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00036FF8 File Offset: 0x00035FF8
		// (set) Token: 0x06000394 RID: 916 RVA: 0x00037010 File Offset: 0x00036010
		public bool ShopForFoodEnabledForNonOwner
		{
			get
			{
				return this.shopForFoodEnabledForNonOwner;
			}
			set
			{
				this.shopForFoodEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0003701C File Offset: 0x0003601C
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00037034 File Offset: 0x00036034
		public bool ShopForGoodsEnabledForOwner
		{
			get
			{
				return this.shopForGoodsEnabledForOwner;
			}
			set
			{
				this.shopForGoodsEnabledForOwner = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00037040 File Offset: 0x00036040
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00037058 File Offset: 0x00036058
		public bool ShopForGoodsEnabledForNonOwner
		{
			get
			{
				return this.shopForGoodsEnabledForNonOwner;
			}
			set
			{
				this.shopForGoodsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00037064 File Offset: 0x00036064
		// (set) Token: 0x0600039A RID: 922 RVA: 0x0003707C File Offset: 0x0003607C
		public bool ShopForCarEnabledForOwner
		{
			get
			{
				return this.shopForCarEnabledForOwner;
			}
			set
			{
				this.shopForCarEnabledForOwner = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00037088 File Offset: 0x00036088
		// (set) Token: 0x0600039C RID: 924 RVA: 0x000370A0 File Offset: 0x000360A0
		public bool ShopForCarEnabledForNonOwner
		{
			get
			{
				return this.shopForCarEnabledForNonOwner;
			}
			set
			{
				this.shopForCarEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600039D RID: 925 RVA: 0x000370AC File Offset: 0x000360AC
		// (set) Token: 0x0600039E RID: 926 RVA: 0x000370C4 File Offset: 0x000360C4
		public bool SellCarEnabledForOwner
		{
			get
			{
				return this.sellCarEnabledForOwner;
			}
			set
			{
				this.sellCarEnabledForOwner = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600039F RID: 927 RVA: 0x000370D0 File Offset: 0x000360D0
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x000370E8 File Offset: 0x000360E8
		public bool SellCarEnabledForNonOwner
		{
			get
			{
				return this.sellCarEnabledForNonOwner;
			}
			set
			{
				this.sellCarEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x000370F4 File Offset: 0x000360F4
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x0003710C File Offset: 0x0003610C
		public bool ShopForGasRepairsEnabledForOwner
		{
			get
			{
				return this.shopForGasRepairsEnabledForOwner;
			}
			set
			{
				this.shopForGasRepairsEnabledForOwner = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00037118 File Offset: 0x00036118
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00037130 File Offset: 0x00036130
		public bool ShopForGasRepairsEnabledForNonOwner
		{
			get
			{
				return this.shopForGasRepairsEnabledForNonOwner;
			}
			set
			{
				this.shopForGasRepairsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0003713C File Offset: 0x0003613C
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00037154 File Offset: 0x00036154
		public bool BuyBusTokensEnabledForOwner
		{
			get
			{
				return this.buyBusTokensEnabledForOwner;
			}
			set
			{
				this.buyBusTokensEnabledForOwner = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00037160 File Offset: 0x00036160
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00037178 File Offset: 0x00036178
		public bool BuyBusTokensEnabledForNonOwner
		{
			get
			{
				return this.buyBusTokensEnabledForNonOwner;
			}
			set
			{
				this.buyBusTokensEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00037184 File Offset: 0x00036184
		// (set) Token: 0x060003AA RID: 938 RVA: 0x0003719C File Offset: 0x0003619C
		public bool InternetAccessEnabledForOwner
		{
			get
			{
				return this.internetAccessEnabledForOwner;
			}
			set
			{
				this.internetAccessEnabledForOwner = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003AB RID: 939 RVA: 0x000371A8 File Offset: 0x000361A8
		// (set) Token: 0x060003AC RID: 940 RVA: 0x000371C0 File Offset: 0x000361C0
		public bool InternetAccessEnabledForNonOwner
		{
			get
			{
				return this.internetAccessEnabledForNonOwner;
			}
			set
			{
				this.internetAccessEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003AD RID: 941 RVA: 0x000371CC File Offset: 0x000361CC
		// (set) Token: 0x060003AE RID: 942 RVA: 0x000371E4 File Offset: 0x000361E4
		public bool HealthcareEnabledForOwner
		{
			get
			{
				return this.healthcareEnabledForOwner;
			}
			set
			{
				this.healthcareEnabledForOwner = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000371F0 File Offset: 0x000361F0
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x00037208 File Offset: 0x00036208
		public bool HealthcareEnabledForNonOwner
		{
			get
			{
				return this.healthcareEnabledForNonOwner;
			}
			set
			{
				this.healthcareEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x00037214 File Offset: 0x00036214
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x0003722C File Offset: 0x0003622C
		public bool RentersEnabledForOwner
		{
			get
			{
				return this.rentersEnabledForOwner;
			}
			set
			{
				this.rentersEnabledForOwner = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x00037238 File Offset: 0x00036238
		// (set) Token: 0x060003B4 RID: 948 RVA: 0x00037250 File Offset: 0x00036250
		public bool RentersEnabledForNonOwner
		{
			get
			{
				return this.rentersEnabledForNonOwner;
			}
			set
			{
				this.rentersEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0003725C File Offset: 0x0003625C
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x00037274 File Offset: 0x00036274
		public bool HomeownersEnabledForOwner
		{
			get
			{
				return this.homeownersEnabledForOwner;
			}
			set
			{
				this.homeownersEnabledForOwner = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00037280 File Offset: 0x00036280
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x00037298 File Offset: 0x00036298
		public bool HomeownersEnabledForNonOwner
		{
			get
			{
				return this.homeownersEnabledForNonOwner;
			}
			set
			{
				this.homeownersEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x000372A4 File Offset: 0x000362A4
		// (set) Token: 0x060003BA RID: 954 RVA: 0x000372BC File Offset: 0x000362BC
		public bool AutomobileEnabledForOwner
		{
			get
			{
				return this.automobileEnabledForOwner;
			}
			set
			{
				this.automobileEnabledForOwner = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060003BB RID: 955 RVA: 0x000372C8 File Offset: 0x000362C8
		// (set) Token: 0x060003BC RID: 956 RVA: 0x000372E0 File Offset: 0x000362E0
		public bool AutomobileEnabledForNonOwner
		{
			get
			{
				return this.automobileEnabledForNonOwner;
			}
			set
			{
				this.automobileEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060003BD RID: 957 RVA: 0x000372EC File Offset: 0x000362EC
		// (set) Token: 0x060003BE RID: 958 RVA: 0x00037304 File Offset: 0x00036304
		public bool ResearchFundsEnabledForOwner
		{
			get
			{
				return this.researchFundsEnabledForOwner;
			}
			set
			{
				this.researchFundsEnabledForOwner = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060003BF RID: 959 RVA: 0x00037310 File Offset: 0x00036310
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x00037328 File Offset: 0x00036328
		public bool ResearchFundsEnabledForNonOwner
		{
			get
			{
				return this.researchFundsEnabledForNonOwner;
			}
			set
			{
				this.researchFundsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00037334 File Offset: 0x00036334
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x0003734C File Offset: 0x0003634C
		public bool ViewPortfolioEnabledForOwner
		{
			get
			{
				return this.viewPortfolioEnabledForOwner;
			}
			set
			{
				this.viewPortfolioEnabledForOwner = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00037358 File Offset: 0x00036358
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x00037370 File Offset: 0x00036370
		public bool ViewPortfolioEnabledForNonOwner
		{
			get
			{
				return this.viewPortfolioEnabledForNonOwner;
			}
			set
			{
				this.viewPortfolioEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0003737C File Offset: 0x0003637C
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x00037394 File Offset: 0x00036394
		public bool ViewRetirementPortfolioEnabledForOwner
		{
			get
			{
				return this.viewRetirementPortfolioEnabledForOwner;
			}
			set
			{
				this.viewRetirementPortfolioEnabledForOwner = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x000373A0 File Offset: 0x000363A0
		// (set) Token: 0x060003C8 RID: 968 RVA: 0x000373B8 File Offset: 0x000363B8
		public bool ViewRetirementPortfolioEnabledForNonOwner
		{
			get
			{
				return this.viewRetirementPortfolioEnabledForNonOwner;
			}
			set
			{
				this.viewRetirementPortfolioEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000373C4 File Offset: 0x000363C4
		// (set) Token: 0x060003CA RID: 970 RVA: 0x000373DC File Offset: 0x000363DC
		public bool SnapshotEnabledForOwner
		{
			get
			{
				return this.snapshotEnabledForOwner;
			}
			set
			{
				this.snapshotEnabledForOwner = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003CB RID: 971 RVA: 0x000373E8 File Offset: 0x000363E8
		// (set) Token: 0x060003CC RID: 972 RVA: 0x00037400 File Offset: 0x00036400
		public bool SnapshotEnabledForNonOwner
		{
			get
			{
				return this.snapshotEnabledForNonOwner;
			}
			set
			{
				this.snapshotEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060003CD RID: 973 RVA: 0x0003740C File Offset: 0x0003640C
		// (set) Token: 0x060003CE RID: 974 RVA: 0x00037424 File Offset: 0x00036424
		public bool WealthEnabledForOwner
		{
			get
			{
				return this.wealthEnabledForOwner;
			}
			set
			{
				this.wealthEnabledForOwner = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00037430 File Offset: 0x00036430
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00037448 File Offset: 0x00036448
		public bool WealthEnabledForNonOwner
		{
			get
			{
				return this.wealthEnabledForNonOwner;
			}
			set
			{
				this.wealthEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x00037454 File Offset: 0x00036454
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x0003746C File Offset: 0x0003646C
		public bool HealthEnabledForOwner
		{
			get
			{
				return this.healthEnabledForOwner;
			}
			set
			{
				this.healthEnabledForOwner = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x00037478 File Offset: 0x00036478
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x00037490 File Offset: 0x00036490
		public bool HealthEnabledForNonOwner
		{
			get
			{
				return this.healthEnabledForNonOwner;
			}
			set
			{
				this.healthEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0003749C File Offset: 0x0003649C
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x000374B4 File Offset: 0x000364B4
		public bool ResumeEnabledForOwner
		{
			get
			{
				return this.resumeEnabledForOwner;
			}
			set
			{
				this.resumeEnabledForOwner = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x000374C0 File Offset: 0x000364C0
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x000374D8 File Offset: 0x000364D8
		public bool ResumeEnabledForNonOwner
		{
			get
			{
				return this.resumeEnabledForNonOwner;
			}
			set
			{
				this.resumeEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x000374E4 File Offset: 0x000364E4
		// (set) Token: 0x060003DA RID: 986 RVA: 0x000374FC File Offset: 0x000364FC
		public bool CreditScoreEnabledForOwner
		{
			get
			{
				return this.creditScoreEnabledForOwner;
			}
			set
			{
				this.creditScoreEnabledForOwner = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00037508 File Offset: 0x00036508
		// (set) Token: 0x060003DC RID: 988 RVA: 0x00037520 File Offset: 0x00036520
		public bool CreditScoreEnabledForNonOwner
		{
			get
			{
				return this.creditScoreEnabledForNonOwner;
			}
			set
			{
				this.creditScoreEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060003DD RID: 989 RVA: 0x0003752C File Offset: 0x0003652C
		// (set) Token: 0x060003DE RID: 990 RVA: 0x00037544 File Offset: 0x00036544
		public bool CreditReportEnabledForOwner
		{
			get
			{
				return this.creditReportEnabledForOwner;
			}
			set
			{
				this.creditReportEnabledForOwner = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003DF RID: 991 RVA: 0x00037550 File Offset: 0x00036550
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x00037568 File Offset: 0x00036568
		public bool CreditReportEnabledForNonOwner
		{
			get
			{
				return this.creditReportEnabledForNonOwner;
			}
			set
			{
				this.creditReportEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x00037574 File Offset: 0x00036574
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x0003758C File Offset: 0x0003658C
		public bool BankStatementsEnabledForOwner
		{
			get
			{
				return this.bankStatementsEnabledForOwner;
			}
			set
			{
				this.bankStatementsEnabledForOwner = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x00037598 File Offset: 0x00036598
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x000375B0 File Offset: 0x000365B0
		public bool BankStatementsEnabledForNonOwner
		{
			get
			{
				return this.bankStatementsEnabledForNonOwner;
			}
			set
			{
				this.bankStatementsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x000375BC File Offset: 0x000365BC
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x000375D4 File Offset: 0x000365D4
		public bool CreditCardStatementsEnabledForOwner
		{
			get
			{
				return this.creditCardStatementsEnabledForOwner;
			}
			set
			{
				this.creditCardStatementsEnabledForOwner = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x000375E0 File Offset: 0x000365E0
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x000375F8 File Offset: 0x000365F8
		public bool CreditCardStatementsEnabledForNonOwner
		{
			get
			{
				return this.creditCardStatementsEnabledForNonOwner;
			}
			set
			{
				this.creditCardStatementsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00037604 File Offset: 0x00036604
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x0003761C File Offset: 0x0003661C
		public bool LoanStatementsEnabledForOwner
		{
			get
			{
				return this.loanStatementsEnabledForOwner;
			}
			set
			{
				this.loanStatementsEnabledForOwner = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x00037628 File Offset: 0x00036628
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x00037640 File Offset: 0x00036640
		public bool LoanStatementsEnabledForNonOwner
		{
			get
			{
				return this.loanStatementsEnabledForNonOwner;
			}
			set
			{
				this.loanStatementsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x0003764C File Offset: 0x0003664C
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x00037664 File Offset: 0x00036664
		public bool InvestmentStatementsEnabledForOwner
		{
			get
			{
				return this.investmentStatementsEnabledForOwner;
			}
			set
			{
				this.investmentStatementsEnabledForOwner = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00037670 File Offset: 0x00036670
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x00037688 File Offset: 0x00036688
		public bool InvestmentStatementsEnabledForNonOwner
		{
			get
			{
				return this.investmentStatementsEnabledForNonOwner;
			}
			set
			{
				this.investmentStatementsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00037694 File Offset: 0x00036694
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x000376AC File Offset: 0x000366AC
		public bool RetirementStatementsEnabledForOwner
		{
			get
			{
				return this.retirementStatementsEnabledForOwner;
			}
			set
			{
				this.retirementStatementsEnabledForOwner = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x000376B8 File Offset: 0x000366B8
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x000376D0 File Offset: 0x000366D0
		public bool RetirementStatementsEnabledForNonOwner
		{
			get
			{
				return this.retirementStatementsEnabledForNonOwner;
			}
			set
			{
				this.retirementStatementsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x000376DC File Offset: 0x000366DC
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x000376F4 File Offset: 0x000366F4
		public bool CheckRegisterEnabledForOwner
		{
			get
			{
				return this.checkRegisterEnabledForOwner;
			}
			set
			{
				this.checkRegisterEnabledForOwner = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00037700 File Offset: 0x00036700
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00037718 File Offset: 0x00036718
		public bool CheckRegisterEnabledForNonOwner
		{
			get
			{
				return this.checkRegisterEnabledForNonOwner;
			}
			set
			{
				this.checkRegisterEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00037724 File Offset: 0x00036724
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x0003773C File Offset: 0x0003673C
		public bool PayTaxRecordsEnabledForOwner
		{
			get
			{
				return this.payTaxRecordsEnabledForOwner;
			}
			set
			{
				this.payTaxRecordsEnabledForOwner = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00037748 File Offset: 0x00036748
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00037760 File Offset: 0x00036760
		public bool PayTaxRecordsEnabledForNonOwner
		{
			get
			{
				return this.payTaxRecordsEnabledForNonOwner;
			}
			set
			{
				this.payTaxRecordsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0003776C File Offset: 0x0003676C
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00037784 File Offset: 0x00036784
		public bool PastTaxReturnsEnabledForOwner
		{
			get
			{
				return this.pastTaxReturnsEnabledForOwner;
			}
			set
			{
				this.pastTaxReturnsEnabledForOwner = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x00037790 File Offset: 0x00036790
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x000377A8 File Offset: 0x000367A8
		public bool PastTaxReturnsEnabledForNonOwner
		{
			get
			{
				return this.pastTaxReturnsEnabledForNonOwner;
			}
			set
			{
				this.pastTaxReturnsEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x000377B4 File Offset: 0x000367B4
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x000377CC File Offset: 0x000367CC
		public bool ActionsJournalEnabledForOwner
		{
			get
			{
				return this.actionsJournalEnabledForOwner;
			}
			set
			{
				this.actionsJournalEnabledForOwner = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x000377D8 File Offset: 0x000367D8
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x000377F0 File Offset: 0x000367F0
		public bool ActionsJournalEnabledForNonOwner
		{
			get
			{
				return this.actionsJournalEnabledForNonOwner;
			}
			set
			{
				this.actionsJournalEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x000377FC File Offset: 0x000367FC
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00037814 File Offset: 0x00036814
		public int ExpectedMultiplayerPlayers
		{
			get
			{
				return this.expectedMultiplayerPlayers;
			}
			set
			{
				this.expectedMultiplayerPlayers = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x00037820 File Offset: 0x00036820
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x00037838 File Offset: 0x00036838
		public override int Level
		{
			get
			{
				return base.Level;
			}
			set
			{
				base.Level = value;
				if (value == 2)
				{
					A.ST.City.AddHealthInsurance(0.2f);
					A.ST.City.Add401Ks(0.2f);
					this.HealthFactorsToConsider = 5;
					this.ResearchFundsEnabledForOwner = true;
					this.ViewPortfolioEnabledForOwner = true;
					this.ViewRetirementPortfolioEnabledForOwner = true;
					this.OnlineBankingEnabledForOwner = true;
					this.InternetAccessEnabledForOwner = true;
					this.HealthcareEnabledForOwner = true;
				}
				if (value == 3)
				{
					this.CondosForSaleEnabledForOwner = true;
					this.HomeownersEnabledForOwner = true;
				}
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x000378DC File Offset: 0x000368DC
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x000378F4 File Offset: 0x000368F4
		public bool TurboSpeed
		{
			get
			{
				return this.turboSpeed;
			}
			set
			{
				this.turboSpeed = value;
				if (!value)
				{
					A.ST.SimulatedTimePerStep = 20000;
				}
				else
				{
					A.ST.SimulatedTimePerStep = 900000;
				}
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00037930 File Offset: 0x00036930
		public override bool AllowInstructorToEdit(string propertyName)
		{
			return propertyName == A.R.GetString("AutofillCheckRegister") || base.AllowInstructorToEdit(propertyName);
		}

		// Token: 0x04000408 RID: 1032
		protected bool sickness = true;

		// Token: 0x04000409 RID: 1033
		protected bool fireForAbsencesLateness = true;

		// Token: 0x0400040A RID: 1034
		protected bool healthAccidents = true;

		// Token: 0x0400040B RID: 1035
		protected bool carAccidents = true;

		// Token: 0x0400040C RID: 1036
		protected bool robberies = false;

		// Token: 0x0400040D RID: 1037
		protected bool closeSomeBusinesses = false;

		// Token: 0x0400040E RID: 1038
		protected bool autoPayRentElectric = false;

		// Token: 0x0400040F RID: 1039
		protected bool endOnLowCreditScore = true;

		// Token: 0x04000410 RID: 1040
		protected bool autofillCheckRegister = true;

		// Token: 0x04000411 RID: 1041
		protected bool aIParties = true;

		// Token: 0x04000412 RID: 1042
		protected bool healthInsuranceForFastFoodJobs = false;

		// Token: 0x04000413 RID: 1043
		protected bool scheduleReadOnly = false;

		// Token: 0x04000414 RID: 1044
		protected DateTime dislocatedShoulderDate = DateTime.MinValue;

		// Token: 0x04000415 RID: 1045
		protected bool sales = true;

		// Token: 0x04000416 RID: 1046
		protected bool turboSpeed = false;

		// Token: 0x04000417 RID: 1047
		protected DateTime breakInDate = DateTime.MinValue;

		// Token: 0x04000418 RID: 1048
		protected float inflationRate = 0.03f;

		// Token: 0x04000419 RID: 1049
		public float initialCash = 5000f;

		// Token: 0x0400041A RID: 1050
		public float initialHealth = 0.8f;

		// Token: 0x0400041B RID: 1051
		public int healthFactorsToConsider = 4;

		// Token: 0x0400041C RID: 1052
		protected string surprises = "Health|Car Accident|Car Breakdown|Robbery|Layoff";

		// Token: 0x0400041D RID: 1053
		protected bool includeOtherLiabilities = false;

		// Token: 0x0400041E RID: 1054
		protected bool disableFW4 = false;

		// Token: 0x0400041F RID: 1055
		protected bool alwaysUseTaxAccountant = false;

		// Token: 0x04000420 RID: 1056
		protected bool apartmentsForRentEnabledForOwner = true;

		// Token: 0x04000421 RID: 1057
		protected bool apartmentsForRentEnabledForNonOwner = false;

		// Token: 0x04000422 RID: 1058
		protected bool transportationEnabledForOwner = true;

		// Token: 0x04000423 RID: 1059
		protected bool transportationEnabledForNonOwner = false;

		// Token: 0x04000424 RID: 1060
		protected bool scheduleEnabledForOwner = true;

		// Token: 0x04000425 RID: 1061
		protected bool scheduleEnabledForNonOwner = false;

		// Token: 0x04000426 RID: 1062
		protected bool condosForSaleEnabledForOwner = false;

		// Token: 0x04000427 RID: 1063
		protected bool condosForSaleEnabledForNonOwner = false;

		// Token: 0x04000428 RID: 1064
		protected bool workEnabledForOwner = true;

		// Token: 0x04000429 RID: 1065
		protected bool workEnabledForNonOwner = false;

		// Token: 0x0400042A RID: 1066
		protected bool educationEnabledForOwner = true;

		// Token: 0x0400042B RID: 1067
		protected bool educationEnabledForNonOwner = false;

		// Token: 0x0400042C RID: 1068
		protected bool taxesEnabledForOwner = true;

		// Token: 0x0400042D RID: 1069
		protected bool taxesEnabledForNonOwner = false;

		// Token: 0x0400042E RID: 1070
		protected bool changeWitholdingEnabledForOwner = true;

		// Token: 0x0400042F RID: 1071
		protected bool changeWitholdingEnabledForNonOwner = false;

		// Token: 0x04000430 RID: 1072
		protected bool changeMethodOfPaymentEnabledForOwner = true;

		// Token: 0x04000431 RID: 1073
		protected bool changeMethodOfPaymentEnabledForNonOwner = false;

		// Token: 0x04000432 RID: 1074
		protected bool changeRetirementContributionEnabledForOwner = true;

		// Token: 0x04000433 RID: 1075
		protected bool changeRetirementContributionEnabledForNonOwner = false;

		// Token: 0x04000434 RID: 1076
		protected bool payBillsEnabledForOwner = true;

		// Token: 0x04000435 RID: 1077
		protected bool payBillsEnabledForNonOwner = false;

		// Token: 0x04000436 RID: 1078
		protected bool bankingEnabledForOwner = true;

		// Token: 0x04000437 RID: 1079
		protected bool bankingEnabledForNonOwner = false;

		// Token: 0x04000438 RID: 1080
		protected bool onlineBankingEnabledForOwner = false;

		// Token: 0x04000439 RID: 1081
		protected bool onlineBankingEnabledForNonOwner = false;

		// Token: 0x0400043A RID: 1082
		protected bool creditCardsEnabledForOwner = true;

		// Token: 0x0400043B RID: 1083
		protected bool creditCardsEnabledForNonOwner = false;

		// Token: 0x0400043C RID: 1084
		protected bool shopForFoodEnabledForOwner = true;

		// Token: 0x0400043D RID: 1085
		protected bool shopForFoodEnabledForNonOwner = false;

		// Token: 0x0400043E RID: 1086
		protected bool shopForGoodsEnabledForOwner = true;

		// Token: 0x0400043F RID: 1087
		protected bool shopForGoodsEnabledForNonOwner = false;

		// Token: 0x04000440 RID: 1088
		protected bool shopForCarEnabledForOwner = true;

		// Token: 0x04000441 RID: 1089
		protected bool shopForCarEnabledForNonOwner = false;

		// Token: 0x04000442 RID: 1090
		protected bool sellCarEnabledForOwner = true;

		// Token: 0x04000443 RID: 1091
		protected bool sellCarEnabledForNonOwner = false;

		// Token: 0x04000444 RID: 1092
		protected bool shopForGasRepairsEnabledForOwner = true;

		// Token: 0x04000445 RID: 1093
		protected bool shopForGasRepairsEnabledForNonOwner = false;

		// Token: 0x04000446 RID: 1094
		protected bool buyBusTokensEnabledForOwner = true;

		// Token: 0x04000447 RID: 1095
		protected bool buyBusTokensEnabledForNonOwner = false;

		// Token: 0x04000448 RID: 1096
		protected bool internetAccessEnabledForOwner = false;

		// Token: 0x04000449 RID: 1097
		protected bool internetAccessEnabledForNonOwner = false;

		// Token: 0x0400044A RID: 1098
		protected bool healthcareEnabledForOwner = false;

		// Token: 0x0400044B RID: 1099
		protected bool healthcareEnabledForNonOwner = false;

		// Token: 0x0400044C RID: 1100
		protected bool rentersEnabledForOwner = true;

		// Token: 0x0400044D RID: 1101
		protected bool rentersEnabledForNonOwner = false;

		// Token: 0x0400044E RID: 1102
		protected bool homeownersEnabledForOwner = false;

		// Token: 0x0400044F RID: 1103
		protected bool homeownersEnabledForNonOwner = false;

		// Token: 0x04000450 RID: 1104
		protected bool automobileEnabledForOwner = true;

		// Token: 0x04000451 RID: 1105
		protected bool automobileEnabledForNonOwner = false;

		// Token: 0x04000452 RID: 1106
		protected bool researchFundsEnabledForOwner = false;

		// Token: 0x04000453 RID: 1107
		protected bool researchFundsEnabledForNonOwner = false;

		// Token: 0x04000454 RID: 1108
		protected bool viewPortfolioEnabledForOwner = false;

		// Token: 0x04000455 RID: 1109
		protected bool viewPortfolioEnabledForNonOwner = false;

		// Token: 0x04000456 RID: 1110
		protected bool viewRetirementPortfolioEnabledForOwner = false;

		// Token: 0x04000457 RID: 1111
		protected bool viewRetirementPortfolioEnabledForNonOwner = false;

		// Token: 0x04000458 RID: 1112
		protected bool snapshotEnabledForOwner = true;

		// Token: 0x04000459 RID: 1113
		protected bool snapshotEnabledForNonOwner = false;

		// Token: 0x0400045A RID: 1114
		protected bool wealthEnabledForOwner = true;

		// Token: 0x0400045B RID: 1115
		protected bool wealthEnabledForNonOwner = false;

		// Token: 0x0400045C RID: 1116
		protected bool healthEnabledForOwner = true;

		// Token: 0x0400045D RID: 1117
		protected bool healthEnabledForNonOwner = false;

		// Token: 0x0400045E RID: 1118
		protected bool resumeEnabledForOwner = true;

		// Token: 0x0400045F RID: 1119
		protected bool resumeEnabledForNonOwner = false;

		// Token: 0x04000460 RID: 1120
		protected bool creditScoreEnabledForOwner = true;

		// Token: 0x04000461 RID: 1121
		protected bool creditScoreEnabledForNonOwner = false;

		// Token: 0x04000462 RID: 1122
		protected bool creditReportEnabledForOwner = true;

		// Token: 0x04000463 RID: 1123
		protected bool creditReportEnabledForNonOwner = false;

		// Token: 0x04000464 RID: 1124
		protected bool bankStatementsEnabledForOwner = true;

		// Token: 0x04000465 RID: 1125
		protected bool bankStatementsEnabledForNonOwner = false;

		// Token: 0x04000466 RID: 1126
		protected bool creditCardStatementsEnabledForOwner = true;

		// Token: 0x04000467 RID: 1127
		protected bool creditCardStatementsEnabledForNonOwner = false;

		// Token: 0x04000468 RID: 1128
		protected bool loanStatementsEnabledForOwner = true;

		// Token: 0x04000469 RID: 1129
		protected bool loanStatementsEnabledForNonOwner = false;

		// Token: 0x0400046A RID: 1130
		protected bool investmentStatementsEnabledForOwner = true;

		// Token: 0x0400046B RID: 1131
		protected bool investmentStatementsEnabledForNonOwner = false;

		// Token: 0x0400046C RID: 1132
		protected bool retirementStatementsEnabledForOwner = true;

		// Token: 0x0400046D RID: 1133
		protected bool retirementStatementsEnabledForNonOwner = false;

		// Token: 0x0400046E RID: 1134
		protected bool checkRegisterEnabledForOwner = true;

		// Token: 0x0400046F RID: 1135
		protected bool checkRegisterEnabledForNonOwner = false;

		// Token: 0x04000470 RID: 1136
		protected bool payTaxRecordsEnabledForOwner = true;

		// Token: 0x04000471 RID: 1137
		protected bool payTaxRecordsEnabledForNonOwner = false;

		// Token: 0x04000472 RID: 1138
		protected bool pastTaxReturnsEnabledForOwner = true;

		// Token: 0x04000473 RID: 1139
		protected bool pastTaxReturnsEnabledForNonOwner = false;

		// Token: 0x04000474 RID: 1140
		protected bool actionsJournalEnabledForOwner = true;

		// Token: 0x04000475 RID: 1141
		protected bool actionsJournalEnabledForNonOwner = false;

		// Token: 0x04000476 RID: 1142
		protected int expectedMultiplayerPlayers = 10;
	}
}
