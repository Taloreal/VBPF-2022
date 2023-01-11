using System;
using System.Collections;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for God.
	/// </summary>
	// Token: 0x0200004A RID: 74
	[Serializable]
	public class God : ActiveObject
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x0001E010 File Offset: 0x0001D010
		public God()
		{
			A.I.Subscribe(this, Simulator.TimePeriod.Week);
			A.I.Subscribe(this, Simulator.TimePeriod.Day);
			A.I.Subscribe(this, Simulator.TimePeriod.Step);
			A.I.Subscribe(this, Simulator.TimePeriod.Year);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0001E064 File Offset: 0x0001D064
		public override bool NewStep()
		{
			int newPeriod = A.ST.Period;
			if (newPeriod != this.currentPeriod)
			{
				foreach (object obj in A.ST.Entity.Values)
				{
					AppEntity e = (AppEntity)obj;
					e.NewPeriod();
				}
			}
			this.currentPeriod = newPeriod;
			return false;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0001E0FC File Offset: 0x0001D0FC
		public override void NewDay()
		{
			A.ST.DayCount++;
			if (A.ST.Day == 28 && A.SS.PayBillsEnabledForOwner)
			{
				PlayerMessage.Broadcast(A.R.GetString("It's near the end of the month. Keep an eye out for new bills on your desk."), "", NotificationColor.Yellow);
			}
			SortedList temp = new SortedList(A.ST.OneTimeEvents);
			foreach (object obj in temp.Values)
			{
				OneTimeEvent evnt = (OneTimeEvent)obj;
				if (A.ST.Now > evnt.OneTimeDay)
				{
					A.ST.OneTimeEvents.Remove(evnt.Key);
					foreach (object obj2 in A.ST.Entity.Values)
					{
						AppEntity e = (AppEntity)obj2;
						e.OneTimeEvents.Remove(evnt.Key);
					}
				}
			}
			foreach (object obj3 in A.ST.OneTimeEvents.Values)
			{
				OneTimeEvent evnt = (OneTimeEvent)obj3;
				if (A.ST.Now.AddDays(1.0) > evnt.OneTimeDay)
				{
					AppEntity e = (AppEntity)A.ST.Entity[evnt.HostID];
					if (e != null)
					{
						float possible = 600f;
						float total = 0f;
						foreach (object obj4 in e.PartyFood)
						{
							PurchasableItem platter = (PurchasableItem)obj4;
							total += platter.Price;
						}
						if (e.Has("DDR"))
						{
							total += 200f;
						}
						if (e.Has("Stereo"))
						{
							total += (float)((e.ImageIndexOf("Stereo") + 1) * 66);
						}
						evnt.AddAIAttendees((int)(Math.Min(1f, total / possible) * 40f));
					}
				}
			}
			if (A.SS.AIParties && A.ST.Random.Next(7) == 0)
			{
				A.ST.AddAIOneTimeEvent();
			}
			foreach (object obj5 in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj5;
				foreach (Surprise s in e.Surprises)
				{
					s.CheckFireSurprise(e);
				}
			}
			foreach (object obj6 in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj6;
				if (A.SS.BreakInDate.ToShortDateString() == A.ST.Now.ToShortDateString())
				{
					e.Surprises[3].FireSurprise(e);
				}
			}
			if (A.SS.LevelManagementOn)
			{
				this.ManageLevels();
			}
			if (A.SS.Level > 1 && A.ST.Day == 1 && A.ST.Month % 12 == 8)
			{
				A.ST.City.AddHealthInsurance(0.1f);
			}
			if (A.SS.Level > 1 && A.ST.Day == 1 && A.ST.Month % 12 == 4)
			{
				A.ST.City.Add401Ks(0.1f);
			}
			if (A.SS.LevelManagementOn && A.ST.Day == 1 && A.ST.Month % 12 == 2)
			{
				A.ST.City.RaiseSomeWages(0.075f);
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0001E6C8 File Offset: 0x0001D6C8
		public override void NewWeek()
		{
			if (A.SS.Sales && A.SS.ShopForGoodsEnabledForOwner)
			{
				ArrayList bdgs = A.ST.City.GetBuildings();
				foreach (object obj in bdgs)
				{
					AppBuilding b = (AppBuilding)obj;
					if (b.BuildingType.Index == 12)
					{
						b.SaleDiscounts = new float[b.SaleDiscounts.Length];
						int saleEvery = 8;
						if (A.ST.Reserved["SaleEvery"] != null)
						{
							saleEvery = (int)A.ST.Reserved["SaleEvery"];
						}
						if (A.ST.Random.Next(saleEvery) == 0)
						{
							bool atLeastOneItemOnSale = false;
							for (int i = 0; i < b.SaleDiscounts.Length; i++)
							{
								if (A.ST.Random.NextDouble() < 0.25)
								{
									b.SaleDiscounts[i] = (float)(A.ST.Random.NextDouble() * 0.4 + 0.1);
									atLeastOneItemOnSale = true;
								}
							}
							if (atLeastOneItemOnSale)
							{
								PlayerMessage.Broadcast(A.R.GetString("{0} is having a sale this week!", new object[]
								{
									b.OwnerName
								}), "", NotificationColor.Green);
							}
						}
					}
				}
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0001E8AC File Offset: 0x0001D8AC
		public override void NewYear()
		{
			if (A.ST.CurrentWeek > 1 && A.SS.InflationRate > 0f)
			{
				this.DoInflation();
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0001E8EC File Offset: 0x0001D8EC
		public void DoInflation()
		{
			PlayerMessage.Broadcast(A.R.GetString("Some prices and rents may have risen due to inflation!"), "", NotificationColor.Yellow);
			ArrayList i = new ArrayList();
			i.AddRange(A.ST.PurchasableAutoSupplies);
			i.AddRange(A.ST.PurchasableBusTokens);
			i.AddRange(A.ST.PurchasableCars);
			i.AddRange(A.ST.PurchasableFood);
			i.AddRange(A.ST.PurchasableItems);
			foreach (object obj in i)
			{
				PurchasableItem p = (PurchasableItem)obj;
				p.Price = this.Inflate(p.Price);
			}
			A.ST.ElectricityCost = this.Inflate(A.ST.ElectricityCost);
			A.ST.InternetCost = this.Inflate(A.ST.InternetCost);
			foreach (object obj2 in A.ST.City.GetOfferings())
			{
				Offering o = (Offering)obj2;
				if (o is DwellingOffer)
				{
					DwellingOffer offer = (DwellingOffer)o;
					if (!offer.Taken || offer.Condo || ((Dwelling)offer.Building).MonthsLeftOnLease <= 0)
					{
						o.Building.Rent = (int)this.Inflate((float)o.Building.Rent);
					}
				}
				if (o is Course)
				{
					((Course)o).Cost = this.Inflate(((Course)o).Cost);
				}
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0001EB08 File Offset: 0x0001DB08
		public float Inflate(float amount)
		{
			return (float)Math.Round((double)(amount * (1f + A.SS.InflationRate)), 2);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0001EB34 File Offset: 0x0001DB34
		protected void ManageLevels()
		{
			AppEntity e = (AppEntity)A.ST.Entity[A.MF.CurrentEntityID];
			if (e != null)
			{
				float netWorth = e.CriticalResourceBalance();
				string nl = Environment.NewLine;
				if (A.SS.Level == 1 && netWorth > 25000f)
				{
					e.Player.SendModalMessage(A.R.GetString("Congratulations! You have reached Level 2. In this level, some of the jobs in the city will add 401K retirement plans and health benefits! You will also be able to use online banking to simplify your life. You now have one additional health factor to consider. You must maintain an active social life by hosting and attending gatherings with your friends! Good luck."), A.R.GetString("Congratulations!"), MessageBoxIcon.Exclamation);
					A.SS.Level = 2;
					A.MF.EnableDisable();
				}
				else if (A.SS.Level == 2 && netWorth > 100000f)
				{
					e.Player.SendModalMessage(A.R.GetString("Congratulations! You have reached Level 3, the final level. In this level your goal is to continue to build your wealth. You can now purchase condominiums (real estate). You can live in these or just purchase them just for investments."), A.R.GetString("Congratulations!"), MessageBoxIcon.Exclamation);
					A.SS.Level = 3;
					A.MF.EnableDisable();
				}
			}
		}

		// Token: 0x04000212 RID: 530
		private int currentPeriod = -1;
	}
}
