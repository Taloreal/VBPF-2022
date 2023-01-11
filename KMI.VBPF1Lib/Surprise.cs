using System;
using System.Collections;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Surprise.
	/// </summary>
	// Token: 0x020000B1 RID: 177
	[Serializable]
	public class Surprise
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0004CCB8 File Offset: 0x0004BCB8
		// (set) Token: 0x0600053F RID: 1343 RVA: 0x0004CCD0 File Offset: 0x0004BCD0
		public string KeyName
		{
			get
			{
				return this.keyName;
			}
			set
			{
				this.keyName = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x0004CCDC File Offset: 0x0004BCDC
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x0004CCF4 File Offset: 0x0004BCF4
		public int Level
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

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0004CD00 File Offset: 0x0004BD00
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0004CD18 File Offset: 0x0004BD18
		public float NetWorth
		{
			get
			{
				return this.netWorth;
			}
			set
			{
				this.netWorth = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x0004CD24 File Offset: 0x0004BD24
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x0004CD3C File Offset: 0x0004BD3C
		public float LikelihoodPerDay
		{
			get
			{
				return this.likelihoodPerDay;
			}
			set
			{
				this.likelihoodPerDay = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0004CD48 File Offset: 0x0004BD48
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x0004CD60 File Offset: 0x0004BD60
		public float MinSpacing
		{
			get
			{
				return this.minSpacing;
			}
			set
			{
				this.minSpacing = value;
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0004CD6C File Offset: 0x0004BD6C
		public void CheckFireSurprise(AppEntity e)
		{
			if (A.SS.Level >= this.Level && A.SS.Surprises.IndexOf(this.KeyName) > -1 && e.CriticalResourceBalance() > this.NetWorth && (float)(A.ST.Now - this.LastFired).Days > this.MinSpacing && A.ST.Random.NextDouble() < (double)this.LikelihoodPerDay)
			{
				this.FireSurprise(e);
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0004CE28 File Offset: 0x0004BE28
		public void FireSurprise(AppEntity e)
		{
			string text = this.KeyName;
			if (text != null)
			{
				if (!(text == "Health"))
				{
					if (!(text == "Car Accident"))
					{
						if (!(text == "Car Breakdown"))
						{
							if (!(text == "Robbery"))
							{
								if (!(text == "Layoff"))
								{
									goto IL_720;
								}
								foreach (object obj in e.GetAllTasks())
								{
									Task t = (Task)obj;
									if (t is WorkTask)
									{
										if (!this.LastOfItsKind((WorkTask)t))
										{
											e.Player.SendMessage(A.R.GetString("Tough luck. Your employer, {0}, has eliminated your position as a {1}. You have been laid off!", new object[]
											{
												t.Building.OwnerName,
												((WorkTask)t).Name()
											}), "", NotificationColor.Red);
											A.SA.DeleteTask(e.ID, t.ID);
											A.ST.City.FindOfferingForTask(t).Taken = true;
											this.LastFired = A.ST.Now;
											break;
										}
									}
								}
							}
							else
							{
								float loss = e.Cash;
								foreach (object obj2 in e.PurchasedItems)
								{
									PurchasableItem p = (PurchasableItem)obj2;
									loss += p.Price;
								}
								if (loss > 0f)
								{
									e.Player.SendMessage(A.R.GetString("Bad news! Your residence was broken into and everything was taken. If you have insurance, you will receive a check for the cost of items stolen (up to your coverage limit) less your deductible."), "", NotificationColor.Red);
									e.PurchasedItems.Clear();
									e.Cash = 0f;
									InsurancePolicy policy;
									if (((DwellingOffer)e.Dwelling.Offerings[0]).Condo)
									{
										policy = e.Dwelling.Insurance;
									}
									else
									{
										policy = e.RentersInsurance;
									}
									if (policy.Deductible > -1f && policy.Limit > 0f)
									{
										if (e.InsuranceOff)
										{
											e.Player.SendMessage("The insurance company did not pay out because your policy was suspended due to lack of payment.", "", NotificationColor.Red);
										}
										else
										{
											Check c = new Check(-1L);
											c.Amount = Math.Max(Math.Min(loss, policy.Limit) - policy.Deductible, 0f);
											c.Payee = e.Name;
											c.Date = A.ST.Now;
											c.Payor = "S&&W Insurance";
											c.Number = (int)A.ST.GetNextID();
											c.Memo = A.R.GetString("Loss from Theft");
											c.Signature = A.R.GetString("Samuel S. Steiner");
											if (c.Amount > 0f)
											{
												e.AddCheck(c);
											}
										}
									}
									this.LastFired = A.ST.Now;
								}
							}
						}
						else if (e.Car != null)
						{
							e.Player.SendPeriodicMessage(A.R.GetString("Getting a lube for your car every four months or so will help prevent costly breakdowns."), "", NotificationColor.Yellow, 365f);
							if (!e.Car.Broken && e.Car.LeaseCost == 0f && A.ST.Random.NextDouble() < (double)e.Car.LikelihoodOfBreakDown())
							{
								e.Player.SendMessage(A.R.GetString("Oh no! Your car has broken down because you failed to maintain it properly or it's getting old. You can't use it until you get it repaired at the auto garage."), "", NotificationColor.Yellow);
								e.Car.Broken = true;
								this.LastFired = A.ST.Now;
							}
						}
					}
					else if (e.Car != null && !e.Car.Broken)
					{
						e.Player.SendMessage(A.R.GetString("Uh, oh! You've been in a car accident and your transmission is ruined. You can't drive it until you get it repaired. If you have insurance, you will receive a check for the repair cost less your deductible."), "", NotificationColor.Red);
						e.Car.Broken = true;
						if (e.Car.Insurance.Deductible > -1f)
						{
							if (e.InsuranceOff)
							{
								e.Player.SendMessage("The insurance company did not pay out because your policy was suspended due to lack of payment.", "", NotificationColor.Red);
							}
							else
							{
								e.AddCheck(new Check(-1L)
								{
									Amount = ((PurchasableItem)A.ST.PurchasableAutoSupplies[4]).Price - e.Car.Insurance.Deductible,
									Payee = e.Name,
									Date = A.ST.Now,
									Payor = "S&&W Insurance",
									Number = (int)A.ST.GetNextID(),
									Memo = A.R.GetString("Car repairs"),
									Signature = A.R.GetString("Samuel S. Steiner")
								});
							}
						}
						this.LastFired = A.ST.Now;
					}
				}
				else
				{
					int i = A.ST.Random.Next(4);
					string injury = A.R.GetString("staph infection|dislocated shoulder|torn ligament|ruptured appendix").Split(new char[]
					{
						'|'
					})[i];
					string injuryShort = injury.Split(new char[]
					{
						' '
					})[1];
					float cost = (new float[]
					{
						313f,
						617f,
						1326f,
						4276f
					})[i];
					e.Player.SendMessage(A.R.GetString("Oh, no! What bad luck! You have suffered from a {0}. Fortunately, you were treated successfully at the hospital. A bill from the hospital will be sent to you shortly!", new object[]
					{
						injury
					}), "", NotificationColor.Red);
					BankAccount hospital = (BankAccount)e.MerchantAccounts["Vincent Medical"];
					e.AddBill(new Bill("Vincent Medical", A.R.GetString("Treatment for {0}", new object[]
					{
						injuryShort
					}), cost, hospital));
					InsurancePolicy policy = e.GetBestHealthInsurance();
					if (policy == e.HealthInsurance && e.InsuranceOff)
					{
						e.Player.SendMessage("The insurance company did not pay out because your policy was suspended due to lack of payment.", "", NotificationColor.Red);
					}
					else if (policy.Copay > -1f)
					{
						hospital.Transactions.Add(new Transaction(cost - policy.Copay, Transaction.TranType.Debit, "Insurance payment"));
					}
					this.LastFired = A.ST.Now;
				}
				return;
			}
			IL_720:
			throw new Exception("Bad key name in surprises.");
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0004D57C File Offset: 0x0004C57C
		protected bool LastOfItsKind(WorkTask t)
		{
			Offering o = A.ST.City.FindOfferingForTask(t);
			ArrayList temp = A.ST.City.GetOfferings(o.GetType());
			foreach (object obj in temp)
			{
				Offering o2 = (Offering)obj;
				if (o != o2 && o2.PrototypeTask.StartPeriod == o.PrototypeTask.StartPeriod && o2.PrototypeTask.GetType() == o.PrototypeTask.GetType() && !o2.Taken)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000632 RID: 1586
		protected string keyName;

		// Token: 0x04000633 RID: 1587
		protected int level;

		// Token: 0x04000634 RID: 1588
		protected float netWorth;

		// Token: 0x04000635 RID: 1589
		protected float likelihoodPerDay;

		// Token: 0x04000636 RID: 1590
		protected float minSpacing;

		// Token: 0x04000637 RID: 1591
		protected DateTime LastFired = DateTime.MinValue;
	}
}
