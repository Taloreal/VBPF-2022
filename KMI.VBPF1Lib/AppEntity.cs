using System;
using System.Collections;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Entity for this application.
	/// </summary>
	// Token: 0x0200002D RID: 45
	[Serializable]
	public class AppEntity : Entity
	{
		// Token: 0x06000148 RID: 328 RVA: 0x00013314 File Offset: 0x00012314
		public AppEntity(Player player, string name) : base(player, name)
		{
			this.Init();
		}

		/// <summary>
		/// Initializes the app-specific entity. Example accounts set up.
		/// </summary>
		// Token: 0x06000149 RID: 329 RVA: 0x0001350C File Offset: 0x0001250C
		public void Init()
		{
			this.Cash = A.SS.InitialCash;
			for (int i = 0; i < this.HealthFactors.Length; i++)
			{
				this.HealthFactors[i] = new float[AppConstants.HealthFactoryHistoryDays[i]];
				for (int j = 0; j < this.HealthFactors[i].Length; j++)
				{
					this.HealthFactors[i][j] = A.SS.InitialHealth;
				}
			}
			this.LastDanced = A.ST.Now;
			this.MerchantAccounts.Add("NRG Electric", new BankAccount("NRG Electric", base.Name));
			this.MerchantAccounts.Add("City Property Mgt", new BankAccount("City Property Mgt", base.Name));
			this.MerchantAccounts.Add("Internet Connect", new BankAccount("Internet Connect", base.Name));
			this.MerchantAccounts.Add("Taranti Auto Lease", new BankAccount("Taranti Auto Lease", base.Name));
			this.MerchantAccounts.Add("Quest Student Loans", new BankAccount("Quest Student Loans", base.Name));
			this.MerchantAccounts.Add("S&W Insurance", new BankAccount("S&W Insurance", base.Name));
			this.MerchantAccounts.Add("Vincent Medical", new BankAccount("Vincent Medical", base.Name));
			this.MerchantAccounts.Add("IRS", new BankAccount("IRS", base.Name));
			this.MerchantAccounts.Add("Century Mortgage", new BankAccount("Century Mortgage", base.Name));
			this.Surprises = (Surprise[])TableReader.Read(base.GetType().Assembly, typeof(Surprise), "KMI.VBPF1Lib.Data.Surprises.txt");
			this.SetUpReserved();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000136EE File Offset: 0x000126EE
		public void SetUpReserved()
		{
			this.reserved = new Hashtable();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000136FC File Offset: 0x000126FC
		public void NewPeriod()
		{
			if (this.Person.Task is Eat)
			{
				if (this.Food.Count > 0)
				{
					if ((A.ST.Now - this.timeLastAte).Hours > 3)
					{
						this.TodaysHealth[0] += 1f;
						this.timeLastAte = A.ST.Now;
					}
					this.Food.RemoveAt(0);
				}
			}
			if (this.Person.Task != null && this.Person.Task is Sleep)
			{
				if (this.Has("Bed"))
				{
					this.TodaysHealth[1] += 1f;
				}
				else
				{
					this.TodaysHealth[1] += 0.5f;
				}
			}
			if (this.Person.Task is Relax)
			{
				float delta = 0.4f;
				if (this.Has("TV"))
				{
					delta += 0.2f;
				}
				if (this.Has("Couch"))
				{
					delta += 0.4f;
				}
				this.TodaysHealth[3] += delta;
			}
			if (this.Person.Task is Exercise)
			{
				if (this.Has("TreadMill"))
				{
					this.TodaysHealth[2] += 1f;
				}
				else
				{
					this.TodaysHealth[2] += 0.5f;
				}
			}
			else if (this.Person.Task is TravelByFoot)
			{
				this.TodaysHealth[2] += 0.5f;
			}
			if (this.Person.Task is Dance && (this.Dwelling.Persons.Count > 1 || this.Person.Task.Building != this.Dwelling))
			{
				this.LastDanced = A.ST.Now;
			}
			if (this.Person.Task is WorkTask)
			{
				((WorkTask)this.Person.Task).HoursThisWeek += 0.5f;
			}
		}

		/// <summary>
		/// Journal key data for actions journal and scoreboard. Actual data journaled
		/// may vary for applications.
		/// </summary>
		// Token: 0x0600014C RID: 332 RVA: 0x000139C0 File Offset: 0x000129C0
		public override void NewWeek()
		{
			if (A.SS.EndOnLowCreditScore && this.CreditScore() < 500)
			{
				base.Player.SendMessage(A.R.GetString("Your credit score is below {0}. If it falls below {1}, it's sim over for you! Try to improve your credit score.", new object[]
				{
					500,
					400
				}), "", NotificationColor.Red);
			}
			if (base.Player.PlayerType == PlayerType.Human)
			{
				if (AppEntity.scoreAdapter == null)
				{
					AppEntity.scoreAdapter = ScoreAdapter.JoinScoring();
				}
				if (AppEntity.scoreAdapter != null)
				{
					AppEntity.scoreAdapter.SendScore(base.Name, this.CriticalResourceBalance());
				}
			}
			base.Journal.AddNumericData("Net Worth", this.CriticalResourceBalance());
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00013A9E File Offset: 0x00012A9E
		public override void NewHour()
		{
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00013AA4 File Offset: 0x00012AA4
		public override void NewDay()
		{
			if (A.ST.DayOfWeek == DayOfWeek.Saturday || A.ST.DayOfWeek == DayOfWeek.Monday)
			{
				if (this.Person.Task != null)
				{
					this.Person.Task.CleanUp();
					this.Person.Task = null;
				}
			}
			if (A.SS.EndOnLowCreditScore && this.CreditScore() < 400)
			{
				GameOverMessage gomsg = new GameOverMessage(base.Player.PlayerName, A.R.GetString("Your credit score has fallen below {0}. Unfortunately, that's sim over for you! Try again and keep an eye on your credit score!", new object[]
				{
					400
				}));
				this.RetireFromApp(gomsg);
			}
			else if (A.SS.Sickness && this.HealthFactorAvg(0) == 0f)
			{
				GameOverMessage gomsg = new GameOverMessage(base.Player.PlayerName, A.R.GetString("Your nutrition was so bad that you passed away. Unfortunately, that's sim over for you! Try again and remember to eat well."));
				this.RetireFromApp(gomsg);
			}
			else
			{
				if (A.SS.Sickness && this.HealthFactorAvg(0) <= 0.15f)
				{
					base.Player.SendPeriodicMessage(A.R.GetString("Your nutrition is very low. Buy food and eat before you pass away!"), "", NotificationColor.Red, 2f);
				}
				if (A.ST.Day == 1 && A.ST.Month == 1)
				{
					this.PrepareTaxForms();
				}
				if (A.ST.Day == 28)
				{
					ArrayList temp = new ArrayList(this.BankAccounts.Values);
					foreach (object obj in temp)
					{
						BankAccount ba = (BankAccount)obj;
						ba.EndMonth();
						if (ba.EndingBalance() < 0f)
						{
							base.Player.SendMessage(A.R.GetString("The balance in your {0} account at {1} has fallen below zero due to fees or other charges. The account has been closed.", new object[]
							{
								ba.AccountTypeFriendlyName.ToLower(),
								ba.BankName
							}), "", NotificationColor.Red);
							this.CloseAccount(ba);
						}
					}
					foreach (object obj2 in this.CreditCardAccounts.Values)
					{
						BankAccount cca = (BankAccount)obj2;
						cca.EndMonth();
					}
					foreach (object obj3 in A.SA.GetInstallmentLoans(base.ID).Values)
					{
						InstallmentLoan i = (InstallmentLoan)obj3;
						i.EndMonth();
					}
					foreach (object obj4 in this.InvestmentAccounts.Values)
					{
						InvestmentAccount ia = (InvestmentAccount)obj4;
						ia.EndMonth();
					}
					foreach (object obj5 in this.RetirementAccounts.Values)
					{
						InvestmentAccount ia = (InvestmentAccount)obj5;
						ia.EndMonth();
					}
				}
				if (A.ST.Day == 28 && this.Dwelling != null)
				{
					this.BillDunCancel();
				}
				if (A.ST.DayOfWeek == DayOfWeek.Saturday)
				{
					foreach (object obj6 in this.GetAllTasks())
					{
						Task task = (Task)obj6;
						if (task is WorkTask)
						{
							WorkTask workTask = (WorkTask)task;
							float grossPay = workTask.HourlyWage * workTask.HoursThisWeek;
							string payDescription = A.R.GetString("Wages");
							if (workTask is WorkDrugRep)
							{
								payDescription = "Commis-" + Environment.NewLine + "sions";
								grossPay *= (float)(1.0 + A.ST.Random.NextDouble() * 1.3 - 0.625);
							}
							if (workTask.BonusPotential > 0f && A.ST.CurrentWeek % 13 == 12)
							{
								payDescription = payDescription + Environment.NewLine + " + Bonus";
								float bonus = (float)((double)(grossPay * 13f) * A.ST.Random.NextDouble() * (double)workTask.BonusPotential);
								if (bonus > 0f)
								{
									base.Player.SendMessage(A.R.GetString("Congratulations! {0} is doing well, and you got a quarterly bonus of {1}.", new object[]
									{
										workTask.Building.OwnerName,
										Utilities.FC(bonus, A.I.CurrencyConversion)
									}), "", NotificationColor.Green);
								}
								grossPay += bonus;
							}
							PayStub payStub = new PayStub(task.Building.OwnerName, base.Name, payDescription, A.ST.Now, workTask.HoursThisWeek, grossPay, (WorkTask)task, this.FICAPaidThisYear());
							workTask.HoursThisWeek = 0f;
							workTask.PayStubs.Add(payStub);
							if (workTask.DirectDepositAccount != null)
							{
								float netPay = payStub.NetPay;
								if (!A.SS.AutofillCheckRegister)
								{
									netPay = (float)Math.Round((double)netPay, 2);
								}
								workTask.DirectDepositAccount.Transactions.Add(new Transaction(netPay, Transaction.TranType.Credit, "Wages Direct Deposit"));
							}
							else
							{
								this.AddCheck(new Check(-1L)
								{
									Amount = payStub.NetPay,
									Payee = base.Name,
									Date = A.ST.Now,
									Payor = workTask.Building.OwnerName,
									Number = (int)A.ST.GetNextID(),
									Memo = A.R.GetString("Weekly pay"),
									Signature = A.R.GetString("John Q. Controller")
								});
							}
							if (workTask is WorkTravellingSalesman)
							{
								this.AddCheck(new Check(-1L)
								{
									Amount = (float)((WorkTravellingSalesman)workTask).Mileage * 0.005f,
									Payee = base.Name,
									Date = A.ST.Now,
									Payor = workTask.Building.OwnerName,
									Number = (int)A.ST.GetNextID(),
									Memo = A.R.GetString("Mileage Reimb."),
									Signature = A.R.GetString("John Q. Controller")
								});
								((WorkTravellingSalesman)workTask).Mileage = 0;
							}
							float amount = payStub.GetValue("401K");
							if (workTask.R401KMatch > -1f)
							{
								amount += grossPay * Math.Min(workTask.R401KPercentWitheld, workTask.R401KMatch);
							}
							int j = 0;
							foreach (object obj7 in A.ST.MutualFunds)
							{
								Fund f = (Fund)obj7;
								if (workTask.R401KAllocations[j] > 0f)
								{
									InvestmentAccount account = this.GetInvestmentAccount(f.Name, true);
									account.Transactions.Add(new Transaction(amount * workTask.R401KAllocations[j] / f.Price, Transaction.TranType.Credit, "Share Purchase"));
								}
								j++;
							}
							if ((A.ST.Now - workTask.StartDate).Days / 7 % 52 == 51)
							{
								workTask.HourlyWage *= 1.02f;
								workTask.HourlyWage = (float)Math.Round((double)workTask.HourlyWage, 2);
								base.Player.SendMessage(A.R.GetString("Congratulations. It's the anniversary of your hiring as a {0} for {1}. You've been given a {2} raise!", new object[]
								{
									workTask.Name().ToLower(),
									workTask.Building.OwnerName,
									Utilities.FP(0.02f)
								}), "", NotificationColor.Green);
							}
						}
					}
				}
				foreach (object obj8 in this.BankAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj8;
					if (ba is CheckingAccount)
					{
						ArrayList temp = new ArrayList(((CheckingAccount)ba).ChecksInTheMail);
						foreach (object obj9 in temp)
						{
							Check c = (Check)obj9;
							int days = (A.ST.Now - c.Date).Days - 2;
							if (A.ST.Random.NextDouble() < (double)((float)days / 12f))
							{
								((CheckingAccount)ba).ChecksInTheMail.Remove(c);
								if (c.Amount <= ba.EndingBalance())
								{
									string description = A.R.GetString("Chk#{0}: {1}", new object[]
									{
										c.Number,
										c.Payee
									});
									if (description.Length > 22)
									{
										description = description.Substring(0, 22);
									}
									ba.Transactions.Add(new Transaction(c.Amount, Transaction.TranType.Debit, description));
									this.ApplyPaymentToAccount(c.ApplyToAccount.AccountNumber, c.Amount);
								}
								else
								{
									base.Player.SendMessage(A.R.GetString("Your check # {0} to {1} for {2} has bounced! You will be charged a fee of {3}.", new object[]
									{
										c.Number,
										c.Payee,
										Utilities.FC(c.Amount, A.I.CurrencyConversion),
										Utilities.FC(35f, A.I.CurrencyConversion)
									}), "", NotificationColor.Yellow);
									ba.Transactions.Add(new Transaction(35f, Transaction.TranType.Debit, A.R.GetString("Overdraft Fee")));
								}
							}
						}
					}
				}
				for (int j = 0; j < A.SS.HealthFactorsToConsider; j++)
				{
					this.HealthFactors[j][A.ST.DayCount % AppConstants.HealthFactoryHistoryDays[j]] = 0f;
					int day = 0;
					while (this.TodaysHealth[j] > 0f && day < AppConstants.HealthFactorApplyForwardDays[j])
					{
						int k = (day + A.ST.DayCount) % AppConstants.HealthFactoryHistoryDays[j];
						this.HealthFactors[j][k] = Math.Min(1f, this.HealthFactors[j][k] + this.TodaysHealth[j] / AppConstants.HealthFactorNeededPerDay[j]);
						this.TodaysHealth[j] -= AppConstants.HealthFactorNeededPerDay[j];
						day++;
					}
					this.TodaysHealth[j] = 0f;
				}
				if (A.SS.HealthFactorsToConsider < 5)
				{
					this.LastDanced = A.ST.Now;
				}
				this.HealthFactors[4][0] = Utilities.Clamp(1f - (float)(A.ST.Now - this.LastDanced).Days / 100f);
				if (this.ElectricityOff)
				{
					this.Food.Clear();
				}
				if (this.Dwelling != null)
				{
					float health = this.Health;
					if (!A.SS.Sickness)
					{
						this.Sick = false;
					}
					else if ((double)health < 0.1)
					{
						this.Sick = (A.ST.Random.Next(3) == 0);
					}
					else if ((double)health < 0.66)
					{
						this.Sick = (A.ST.Random.NextDouble() < (double)health * 0.1);
					}
					else
					{
						this.Sick = false;
					}
					if (this.Sick)
					{
						base.Player.SendMessage(A.R.GetString("Because of some unhealthy habits, particularly your lack of {0}, you have become sick and cannot leave home for the next 24 hours.", new object[]
						{
							this.WorstHealthFactor().ToLower()
						}), "", NotificationColor.Yellow);
						foreach (object obj10 in this.GetDailyRoutine().Tasks.Values)
						{
							Task t = (Task)obj10;
							if (t is WorkTask || t is AttendClass)
							{
								t.DatesAbsent.Add(A.ST.Now);
							}
						}
					}
				}
				foreach (object obj11 in this.BankAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj11;
					if (ba is CheckingAccount)
					{
						ArrayList temp = (ArrayList)((CheckingAccount)ba).RecurringPayments.Clone();
						foreach (object obj12 in temp)
						{
							RecurringPayment p = (RecurringPayment)obj12;
							if (p.Day == A.ST.Day)
							{
								if (ba.EndingBalance() < p.Amount)
								{
									base.Player.SendMessage(A.R.GetString("Some scheduled recurring payments were rejected. You do not have enough money in the account."), ba.BankName, NotificationColor.Yellow);
									break;
								}
								string payee = p.PayeeName;
								if (payee.IndexOf("Acct#") > -1)
								{
									payee = payee.Substring(0, payee.IndexOf("Acct#") - 1);
								}
								ba.Transactions.Add(new Transaction(p.Amount, Transaction.TranType.Debit, payee));
								this.ApplyPaymentToAccount(p.PayeeAccountNumber, p.Amount);
								this.RemoveBillIfExactMatch(p.PayeeAccountNumber, p.Amount);
							}
						}
					}
				}
				bool msg = false;
				while (this.Food.Count > 0)
				{
					if (((DateTime)this.Food[0] - A.ST.Now).Days <= 28)
					{
						break;
					}
					this.Food.RemoveAt(0);
					msg = true;
				}
				if (msg)
				{
					base.Player.SendMessage(A.R.GetString("Some of your food has expired!"), "", NotificationColor.Yellow);
				}
				if (this.Car != null && this.Car.LeaseCost > 0f && (A.ST.Now - this.Car.Purchased).Days > 730)
				{
					base.Player.SendModalMessage(A.R.GetString("Your car lease has ended. If you want to keep driving, back to Tommy Taranti's to get a new lease."), A.R.GetString("Car Lease Ended"), MessageBoxIcon.None);
					A.ST.City.Cars.Remove(this.Car);
					this.Car = null;
				}
				DateTime yest = A.ST.Now.AddHours(-1.0);
				bool wasWeekend = yest.DayOfWeek == DayOfWeek.Saturday || yest.DayOfWeek == DayOfWeek.Sunday;
				foreach (object obj13 in this.GetDailyRoutine(wasWeekend).Tasks.Values)
				{
					Task t = (Task)obj13;
					if (t is WorkTask || t is AttendClass)
					{
						DateTime taskStart = new DateTime(yest.Year, yest.Month, yest.Day, t.StartPeriod / 2, t.StartPeriod % 2 * 30, 0);
						if (t.ArrivedToday < DateTime.MaxValue && t.ArrivedToday > taskStart.AddMinutes(5.0))
						{
							TimeSpan ts = t.ArrivedToday - taskStart;
							string lateTo = A.R.GetString("work");
							if (t is AttendClass)
							{
								lateTo = A.R.GetString("class");
							}
							base.Player.SendMessage(A.R.GetString("You were {0} minutes late to {1} on {2}. Check your travel schedule. You need to allow more time to travel or use faster transportation.", new object[]
							{
								ts.Minutes,
								lateTo,
								yest.DayOfWeek.ToString()
							}), "", NotificationColor.Yellow);
							t.DatesLate.Add(yest);
						}
					}
				}
				foreach (object obj14 in this.GetDailyRoutine().Tasks.Values)
				{
					Task t = (Task)obj14;
					t.ArrivedToday = DateTime.MaxValue;
				}
				ArrayList temp2 = this.GetAllTasks();
				foreach (object obj15 in temp2)
				{
					Task t = (Task)obj15;
					if (t is WorkTask || t is AttendClass)
					{
						string reason = t.BadAttendance();
						if (reason != null)
						{
							A.SA.DeleteTask(base.ID, t.ID, true, false);
							base.Player.SendMessage(reason, "", NotificationColor.Red);
						}
					}
				}
				if (A.SS.TaxesEnabledForOwner && A.ST.Now.Year > A.SS.StartDate.Year && A.ST.Now.Month == 5 && A.ST.Now.Day == 1)
				{
					this.AuditAndRefundOrBill();
				}
				if (A.SS.DislocatedShoulderDate.ToShortDateString() == A.ST.Now.ToShortDateString())
				{
					base.Player.SendMessage(A.R.GetString("Oh, no! What bad luck! You have suffered from a dislocated shoulder. Fortunately, you were treated successfully at the hospital. A bill from the hospital will be sent to you shortly!"), "", NotificationColor.Red);
					BankAccount hospital = (BankAccount)this.MerchantAccounts["Vincent Medical"];
					this.AddBill(new Bill("Vincent Medical", A.R.GetString("Treatment for shoulder"), 613f, hospital));
				}
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000151F8 File Offset: 0x000141F8
		public void RemoveBillIfExactMatch(long payeeAccountNumber, float amount)
		{
			foreach (object obj in this.Bills.Values)
			{
				Bill bill = (Bill)obj;
				if (bill.Account != null && bill.Account.AccountNumber == payeeAccountNumber && bill.Amount <= amount)
				{
					this.Bills.Remove(bill.ID);
					break;
				}
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001529C File Offset: 0x0001429C
		public override void NewYear()
		{
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000152A0 File Offset: 0x000142A0
		public float HealthFactorAvg(int index)
		{
			float total = 0f;
			foreach (float f in this.HealthFactors[index])
			{
				total += f;
			}
			return total / (float)this.HealthFactors[index].Length;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000152F4 File Offset: 0x000142F4
		public float Health
		{
			get
			{
				float total = 0f;
				for (int i = 0; i < A.SS.HealthFactorsToConsider; i++)
				{
					total += this.HealthFactorAvg(i);
				}
				total /= (float)A.SS.HealthFactorsToConsider;
				float min = float.MaxValue;
				for (int i = 0; i < A.SS.HealthFactorsToConsider; i++)
				{
					min = Math.Min(min, this.HealthFactorAvg(i));
				}
				float result;
				if ((double)min < 0.1)
				{
					result = min;
				}
				else
				{
					result = total;
				}
				return result;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001538C File Offset: 0x0001438C
		public override bool NewStep()
		{
			if (this.Person.Task == null)
			{
				this.Person.Task = this.GetCurrentTaskForOneTimeEvent();
				if (this.Person.Task == null)
				{
					this.Person.Task = this.GetDailyRoutine().GetCurrentTask();
				}
				if (this.Person.Task != null)
				{
					if (this.Sick && (this.Person.Task is WorkTask || this.Person.Task is TravelTask || this.Person.Task is AttendClass || this.Person.Task is Sleep))
					{
						Task t = new BeSick();
						t.StartPeriod = this.Person.Task.StartPeriod;
						t.EndPeriod = this.Person.Task.EndPeriod;
						t.Building = this.Dwelling;
						t.Owner = this.Person;
						this.Person.Task = t;
					}
					AppBuilding currentLoc = A.ST.City.FindInsideBuilding(this);
					if (currentLoc != this.Person.Task.Building)
					{
						if (currentLoc != null)
						{
							currentLoc.Persons.Remove(this.Person);
						}
						this.Person.Task.Building.Persons.Add(this.Person);
						MapV2 map = this.Person.Task.Building.Map;
						if (map != null)
						{
							this.Person.Location = map.getNode("EntryPoint").Location;
						}
					}
					this.Person.Task.ArrivedToday = A.ST.Now;
					if (this.Person.Task is TravelTask)
					{
						this.Person.Task = this.FindActualTravelTask((TravelTask)this.Person.Task);
					}
				}
			}
			if (this.Person.Task == null)
			{
				this.Person.Pose = "StandSW";
			}
			else if (this.Person.Task.Do())
			{
				this.Person.Task.CleanUp();
				this.Person.Task = null;
			}
			return false;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00015634 File Offset: 0x00014634
		public ArrayList GetAllTasks()
		{
			ArrayList temp = new ArrayList(this.dailyRoutineWD.Tasks.Values);
			temp.AddRange(this.dailyRoutineWE.Tasks.Values);
			temp.AddRange(this.OneTimeEventTaskQueue);
			return temp;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00015684 File Offset: 0x00014684
		public DailyRoutine GetDailyRoutine(bool weekend)
		{
			DailyRoutine result;
			if (weekend)
			{
				result = this.dailyRoutineWE;
			}
			else
			{
				result = this.dailyRoutineWD;
			}
			return result;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000156B0 File Offset: 0x000146B0
		public DailyRoutine GetDailyRoutine()
		{
			return this.GetDailyRoutine(A.ST.Weekend);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000156D4 File Offset: 0x000146D4
		public float CreditScoreNormalized()
		{
			return Utilities.Clamp((float)(this.CreditScore(new ArrayList()) - 400) / 450f);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00015704 File Offset: 0x00014704
		public int CreditScore()
		{
			return this.CreditScore(new ArrayList());
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00015724 File Offset: 0x00014724
		public int CreditScore(ArrayList reasons)
		{
			float score = 550f;
			foreach (object obj in this.MerchantAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				if (ba.DaysPastDue(A.ST.Now) > 60)
				{
					score -= 50f;
				}
			}
			ArrayList loans = new ArrayList(A.SA.GetInstallmentLoans(base.ID).Values);
			loans.AddRange(this.ClosedInstallmentLoans.Values);
			float loanScore = 0f;
			foreach (object obj2 in loans)
			{
				InstallmentLoan loan = (InstallmentLoan)obj2;
				if (loan.DateClosed > A.ST.Now.AddMonths(-36))
				{
					loanScore -= (float)(20 * loan.MissedPayments());
					loanScore += (float)(5 * loan.OnTimePayments());
				}
			}
			score += Math.Min(150f, loanScore);
			ArrayList accounts = new ArrayList(this.CreditCardAccounts.Values);
			accounts.AddRange(this.ClosedCreditCardAccounts.Values);
			float ccScore = 0f;
			foreach (object obj3 in accounts)
			{
				CreditCardAccount cca = (CreditCardAccount)obj3;
				if (cca.DateClosed > A.ST.Now.AddMonths(-36))
				{
					ccScore -= (float)(20 * cca.MissedPayments());
					ccScore += (float)(5 * cca.OnTimePayments());
				}
			}
			score += Math.Min(150f, ccScore);
			return (int)score;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00015980 File Offset: 0x00014980
		public Task GetTaskByID(long taskID)
		{
			foreach (object obj in this.GetAllTasks())
			{
				Task t = (Task)obj;
				if (t.ID == taskID)
				{
					return t;
				}
			}
			return null;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000159FC File Offset: 0x000149FC
		public override float CriticalResourceBalance()
		{
			float totalLiquid = this.Cash;
			foreach (object obj in this.BankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				totalLiquid += ba.EndingBalance();
			}
			float totalInvest = 0f;
			foreach (object obj2 in this.InvestmentAccounts.Values)
			{
				InvestmentAccount account = (InvestmentAccount)obj2;
				totalInvest += account.Value;
			}
			foreach (object obj3 in this.RetirementAccounts.Values)
			{
				InvestmentAccount account = (InvestmentAccount)obj3;
				totalInvest += account.Value;
			}
			float totalReal = this.ComputeRealEstateValue();
			if (this.Car != null && this.Car.LeaseCost == 0f)
			{
				totalReal += this.Car.ComputeResalePrice(A.ST.Now);
			}
			float totalCurrent = 0f;
			foreach (object obj4 in this.CreditCardAccounts.Values)
			{
				CreditCardAccount cc = (CreditCardAccount)obj4;
				totalCurrent += cc.EndingBalance();
			}
			if (A.SS.IncludeOtherLiabilities)
			{
				foreach (object obj5 in this.MerchantAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj5;
					if (ba.EndingBalance() > 0f)
					{
						totalCurrent += ba.EndingBalance();
					}
				}
			}
			float totalLongTerm = 0f;
			SortedList loans = this.GetInstallmentLoans();
			foreach (object obj6 in loans.Values)
			{
				InstallmentLoan i = (InstallmentLoan)obj6;
				totalLongTerm += i.EndingBalance();
			}
			return totalLiquid + totalInvest + totalReal - (totalCurrent + totalLongTerm);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00015D14 File Offset: 0x00014D14
		public void AddBill(Bill bill)
		{
			long oldBillID = -1L;
			foreach (object obj in this.Bills.Values)
			{
				Bill b = (Bill)obj;
				if (b.Account.ID == bill.Account.ID)
				{
					oldBillID = b.ID;
				}
			}
			if (oldBillID > -1L)
			{
				this.Bills.Remove(oldBillID);
			}
			this.Bills.Add(bill.ID, bill);
			if (!this.Payees.Contains(bill.Account))
			{
				this.Payees.Add(bill.Account);
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00015E00 File Offset: 0x00014E00
		public void BillDunCancel()
		{
			int year = A.ST.Year;
			int month = A.ST.Month;
			BankAccount rentAccount = (BankAccount)this.MerchantAccounts["City Property Mgt"];
			BankAccount.Status status = rentAccount.PastDueStatus(year, month);
			if (rentAccount.DaysPastDue(A.ST.Now) > 120)
			{
				GameOverMessage gomsg = new GameOverMessage(base.Player.PlayerName, "You have been evicted for not paying your rent bills. It's game over. You can try again though!");
				this.RetireFromApp(gomsg);
			}
			else
			{
				if (status == BankAccount.Status.PastDue || status == BankAccount.Status.Deliquent || status == BankAccount.Status.NewlyCancelled || status == BankAccount.Status.Cancelled)
				{
					base.Player.SendMessage("You haven't been paying your rent or past lease obligations on time. You may be evicted. If you are evicted, it's sim over for you!", "", NotificationColor.Yellow);
				}
				if (!((DwellingOffer)this.Dwelling.Offerings[0]).Condo)
				{
					this.AddBill(new Bill(A.R.GetString("City Property Mgt"), "Monthly Lease", (float)this.Dwelling.Rent, (BankAccount)this.MerchantAccounts["City Property Mgt"]));
				}
				if (this.Dwelling.MonthsLeftOnLease > 0)
				{
					this.Dwelling.MonthsLeftOnLease--;
				}
				if (!this.ElectricityOff)
				{
					this.AddBill(new Bill("NRG Electric", "Kilowatts of Electricity", A.ST.ElectricityCost, (BankAccount)this.MerchantAccounts["NRG Electric"]));
				}
				status = ((BankAccount)this.MerchantAccounts["NRG Electric"]).PastDueStatus(year, month);
				if (status == BankAccount.Status.NewlyCancelled)
				{
					this.ElectricityOff = true;
					base.Player.SendMessage("Your electricity has been turned off, because you didn't pay your bills! You cannot watch TV, access the Internet, and your food will spoil.", "", NotificationColor.Red);
				}
				else if (status == BankAccount.Status.Deliquent)
				{
					base.Player.SendMessage("You have unpaid electricity  bills! If you don't pay them, your credit rating will decline and your electricity may be shut off!", "", NotificationColor.Yellow);
				}
				if (this.Internet)
				{
					this.AddBill(new Bill("Internet Connect", "Hi-speed Internet Access", A.ST.InternetCost, (BankAccount)this.MerchantAccounts["Internet Connect"]));
				}
				status = ((BankAccount)this.MerchantAccounts["Internet Connect"]).PastDueStatus(year, month);
				if (status == BankAccount.Status.NewlyCancelled)
				{
					this.Internet = false;
					base.Player.SendMessage("Your internet access has been turned off, because you didn't pay your bills!", "", NotificationColor.Red);
				}
				else if (status == BankAccount.Status.Deliquent)
				{
					base.Player.SendMessage("You have unpaid internet access bills! If you don't pay them, your credit rating will decline and your internet access will be shut off!", "", NotificationColor.Yellow);
				}
				status = ((BankAccount)this.MerchantAccounts["Taranti Auto Lease"]).PastDueStatus(year, month);
				if (status == BankAccount.Status.NewlyCancelled && this.Car != null)
				{
					base.Player.SendMessage("You have failed to make your car payments. Your car has been repossessed.", "", NotificationColor.Red);
					this.RepossessCar();
				}
				else if (status == BankAccount.Status.Deliquent && this.Car != null)
				{
					base.Player.SendMessage("Your car payments are behind. Make your account current or your car will be repossessed.", "", NotificationColor.Yellow);
				}
				if (this.Car != null && this.Car.Loan != null)
				{
					status = this.Car.Loan.PastDueStatus(year, month);
					if (status == BankAccount.Status.NewlyCancelled)
					{
						base.Player.SendMessage("You have failed to make your car payments. Your car has been repossessed.", "", NotificationColor.Red);
						this.RepossessCar();
					}
					else if (status == BankAccount.Status.Deliquent)
					{
						base.Player.SendMessage("Your car payments are behind. Make your account current or your car will be repossessed.", "", NotificationColor.Yellow);
					}
				}
				if (this.Car != null)
				{
					if (this.Car.LeaseCost > 0f)
					{
						this.AddBill(new Bill("Taranti Auto Lease", "Automobile Lease", this.Car.LeaseCost, (BankAccount)this.MerchantAccounts["Taranti Auto Lease"]));
					}
					if (this.Car.Loan != null)
					{
						this.AddBill(new Bill("Taranti Auto Loan", "", this.Car.Loan.Payment + this.Car.Loan.PastDueAmount(A.ST.Now), this.Car.Loan));
					}
				}
				foreach (object obj in this.CreditCardAccounts.Values)
				{
					CreditCardAccount cca = (CreditCardAccount)obj;
					status = cca.PastDueStatus(year, month);
					if (status == BankAccount.Status.NewlyCancelled)
					{
						base.Player.SendMessage(A.R.GetString("Your credit card from {0} has been frozen due to lack of payments.", new object[]
						{
							cca.BankName
						}), "", NotificationColor.Red);
					}
					else if (status == BankAccount.Status.Deliquent)
					{
						base.Player.SendMessage(A.R.GetString("Your credit card from {0} may soon be frozen due to lack of payments.", new object[]
						{
							cca.BankName
						}), "", NotificationColor.Yellow);
					}
					this.AddBill(new Bill(cca.BankName, "", cca.MinimumPayment(year, month), cca));
				}
				foreach (object obj2 in this.StudentLoans.Values)
				{
					InstallmentLoan loan = (InstallmentLoan)obj2;
					status = loan.PastDueStatus(year, month);
					if (status == BankAccount.Status.NewlyCancelled)
					{
						base.Player.SendMessage(A.R.GetString("Your student loan is now in default."), "", NotificationColor.Red);
					}
					if (A.ST.Now > loan.BeginBilling)
					{
						this.AddBill(new Bill("Quest Student Loans", "", loan.Payment + loan.PastDueAmount(A.ST.Now), loan));
					}
				}
				foreach (object obj3 in this.MerchantAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj3;
					if (ba.EndingBalance() > 0f && !this.AlreadyBilledToday(ba.BankName))
					{
						this.AddBill(new Bill(ba.BankName, "", 0f, ba));
					}
				}
				if (!this.InsuranceOff)
				{
					if (this.Car != null)
					{
						this.AddBill(new Bill("S&W Insurance", "Car Insurance", this.Car.Insurance.MonthlyPremium, (BankAccount)this.MerchantAccounts["S&W Insurance"]));
					}
					if (this.HealthInsurance.Copay > -1f)
					{
						this.AddBill(new Bill("S&W Insurance", "Health Insurance", this.HealthInsurance.MonthlyPremium, (BankAccount)this.MerchantAccounts["S&W Insurance"]));
					}
					if (this.RentersInsurance.Deductible > -1f)
					{
						this.AddBill(new Bill("S&W Insurance", "Renter's Insurance", this.RentersInsurance.MonthlyPremium, (BankAccount)this.MerchantAccounts["S&W Insurance"]));
					}
					float homeowners = 0f;
					foreach (object obj4 in A.ST.City.GetBuildings())
					{
						AppBuilding b = (AppBuilding)obj4;
						if (b.Owner == this && ((DwellingOffer)b.Offerings[0]).Condo)
						{
							homeowners += ((Dwelling)b).Insurance.MonthlyPremium;
						}
					}
					if (homeowners > 0f)
					{
						this.AddBill(new Bill("S&W Insurance", "Homeowner's Insurance", homeowners, (BankAccount)this.MerchantAccounts["S&W Insurance"]));
					}
				}
				status = ((BankAccount)this.MerchantAccounts["S&W Insurance"]).PastDueStatus(year, month);
				if (status == BankAccount.Status.NewlyCancelled)
				{
					this.InsuranceOff = true;
					base.Player.SendMessage("Your insurance coverage has been suspended, because you didn't pay your bills! Losses will not be covered.", "", NotificationColor.Red);
				}
				else if (status == BankAccount.Status.Deliquent)
				{
					base.Player.SendMessage("You have unpaid insurance  bills! If you don't pay them, your credit rating will decline and your insurance coverage may be suspended!", "", NotificationColor.Yellow);
				}
				foreach (object obj5 in this.Mortgages.Values)
				{
					Mortgage loan2 = (Mortgage)obj5;
					status = loan2.PastDueStatus(year, month);
					if (status == BankAccount.Status.NewlyCancelled)
					{
						GameOverMessage gomsg = new GameOverMessage(base.Player.PlayerName, "You have been evicted or foreclosed upon for not paying your mortgage. It's game over. You can try again though!");
						this.RetireFromApp(gomsg);
						break;
					}
					if (status == BankAccount.Status.PastDue || status == BankAccount.Status.Deliquent)
					{
						base.Player.SendMessage("You haven't been paying your mortgage obligations on time. You may be evicted or face foreclosure. If you are evicted or foreclosed upon, it's sim over for you!", "", NotificationColor.Yellow);
					}
					this.AddBill(new Bill("Century Mortgage", "", loan2.Payment + loan2.PastDueAmount(A.ST.Now), loan2));
				}
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0001687C File Offset: 0x0001587C
		public bool AlreadyBilledToday(string name)
		{
			foreach (object obj in this.Bills.Values)
			{
				Bill b = (Bill)obj;
				if (b.From == name && b.Date == A.ST.Now)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00016918 File Offset: 0x00015918
		public void RepossessCar()
		{
			if (this.Car.Loan != null)
			{
				this.Car.Loan.Transactions.Add(new Transaction(this.Car.ComputeResalePrice(A.ST.Now), Transaction.TranType.Debit, "Value of repossessed car"));
				this.CloseAccount(this.Car.Loan);
			}
			A.ST.City.Cars.Remove(this.Car);
			this.Car = null;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000169A4 File Offset: 0x000159A4
		public float YearsExperience(string taskName)
		{
			float total = 0f;
			foreach (object obj in this.WorkTaskHistory.Values)
			{
				WorkTask t = (WorkTask)obj;
				if (t.Name() == taskName || taskName == "worker of any kind")
				{
					if (t.EndDate == DateTime.MinValue)
					{
						total += (float)(A.ST.Now - t.StartDate).Days / 365f;
					}
					else
					{
						total += (float)(t.EndDate - t.StartDate).Days / 365f;
					}
				}
			}
			return total;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00016AAC File Offset: 0x00015AAC
		public void RemoveTask(Task t)
		{
			t.EndDate = A.ST.Now;
			if (t is WorkTask)
			{
				Offering derivedFrom = A.ST.City.FindOfferingForTask(t);
				if (derivedFrom != null)
				{
					derivedFrom.Taken = false;
				}
			}
			this.GetDailyRoutine(t.Weekend).Tasks.Remove(t.StartPeriod);
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00016B20 File Offset: 0x00015B20
		public int ModeOfTransportation
		{
			get
			{
				return this.modeOfTransportation;
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00016B38 File Offset: 0x00015B38
		public void SetModeOfTransportation(int index)
		{
			DailyRoutine temp = this.dailyRoutineWD.MakeCopy();
			this.CheckValiditySynchTravel(index, temp, null, false);
			this.dailyRoutineWD = temp;
			DailyRoutine temp2 = this.dailyRoutineWE.MakeCopy();
			this.CheckValiditySynchTravel(index, temp2, null, false);
			this.dailyRoutineWE = temp2;
			this.modeOfTransportation = index;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00016B8C File Offset: 0x00015B8C
		public bool Has(string itemName)
		{
			foreach (object obj in this.PurchasedItems)
			{
				PurchasableItem i = (PurchasableItem)obj;
				if (i.Name.StartsWith(itemName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00016C0C File Offset: 0x00015C0C
		public int ImageIndexOf(string itemName)
		{
			foreach (object obj in this.PurchasedItems)
			{
				PurchasableItem i = (PurchasableItem)obj;
				if (i.Name.StartsWith(itemName))
				{
					return int.Parse(i.Name.Substring(itemName.Length));
				}
			}
			return -1;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00016CA0 File Offset: 0x00015CA0
		public BankAccount GetAccountByAccountNumber(long accountNumber)
		{
			foreach (object obj in this.MerchantAccounts.Values)
			{
				BankAccount b = (BankAccount)obj;
				if (b.AccountNumber == accountNumber)
				{
					return b;
				}
			}
			BankAccount account = (BankAccount)this.CreditCardAccounts[accountNumber];
			BankAccount result;
			if (account != null)
			{
				result = account;
			}
			else if (this.Car != null && this.Car.Loan != null && this.Car.Loan.AccountNumber == accountNumber)
			{
				result = this.Car.Loan;
			}
			else
			{
				foreach (object obj2 in this.StudentLoans.Values)
				{
					BankAccount b = (BankAccount)obj2;
					if (b.AccountNumber == accountNumber)
					{
						return b;
					}
				}
				foreach (object obj3 in this.Mortgages.Values)
				{
					BankAccount b = (BankAccount)obj3;
					if (b.AccountNumber == accountNumber)
					{
						return b;
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00016E74 File Offset: 0x00015E74
		public void ApplyPaymentToAccount(long accountNumber, float amount)
		{
			BankAccount account = this.GetAccountByAccountNumber(accountNumber);
			if (account != null)
			{
				account.Transactions.Add(new Transaction(amount, Transaction.TranType.Debit, A.R.GetString("Payment-Thank You!")));
				BankAccount.Status status = account.PastDueStatusPassive(A.ST.Year, A.ST.Month);
				if (account == this.MerchantAccounts["NRG Electric"] && status == BankAccount.Status.Current && this.ElectricityOff)
				{
					base.Player.SendMessage("Your electricity has been turned back on!", "", NotificationColor.Green);
					this.ElectricityOff = false;
				}
				if (account == this.MerchantAccounts["Internet Connect"] && status == BankAccount.Status.Current && !this.Internet && base.Reserved.ContainsKey("WantsInternet"))
				{
					base.Player.SendMessage("Your internet access has been turned back on!", "", NotificationColor.Green);
					this.Internet = true;
				}
				if (account == this.MerchantAccounts["S&W Insurance"] && status == BankAccount.Status.Current && this.InsuranceOff)
				{
					base.Player.SendMessage("Your insurance coverage has been reinstated!", "", NotificationColor.Green);
					this.InsuranceOff = false;
				}
				if (account is InstallmentLoan)
				{
					if ((double)account.EndingBalance() <= 0.1)
					{
						base.Player.SendMessage(A.R.GetString("Congratulations! You have paid off your loan from {0}!", new object[]
						{
							account.BankName
						}), "", NotificationColor.Green);
						this.CloseAccount(account);
					}
				}
				if (account is CreditCardAccount)
				{
					if ((status == BankAccount.Status.NewlyCancelled || status == BankAccount.Status.Cancelled) && account.EndingBalance() <= 0f)
					{
						this.CreditCardAccounts.Remove(account);
						this.CloseAccount(account);
					}
				}
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00017064 File Offset: 0x00016064
		public void PrepareTaxForms()
		{
			int year = A.ST.Year - 1;
			DateTime yearEnd = new DateTime(year, 12, 12, 23, 59, 59);
			ArrayList workTasksThisYear = new ArrayList();
			foreach (object obj in this.WorkTaskHistory.Values)
			{
				WorkTask t = (WorkTask)obj;
				foreach (object obj2 in t.PayStubs)
				{
					PayStub ps = (PayStub)obj2;
					if (ps.WeekEnding.Year == year && !workTasksThisYear.Contains(t))
					{
						workTasksThisYear.Add(t);
					}
				}
			}
			foreach (object obj3 in workTasksThisYear)
			{
				WorkTask t = (WorkTask)obj3;
				string key = year.ToString() + "-" + t.Building.ID;
				FW2 w2;
				if (this.FW2s.ContainsKey(key))
				{
					w2 = (FW2)this.FW2s[key];
				}
				else
				{
					w2 = new FW2(year, t.Building.OwnerName, base.Name, this.Person.ID);
					this.FW2s.Add(key, w2);
				}
				w2.Wages += t.GetValueYTD("Gross Pay", yearEnd) - t.GetValueYTD("401K", yearEnd);
				w2.RetirementPlan = (t.GetValueYTD("401K", yearEnd) > 0f);
				w2.SSWages += t.GetValueYTD("Soc Sec", yearEnd) / 0.062f;
				w2.MedicareWages += t.GetValueYTD("Gross Pay", yearEnd);
				w2.FedWT += t.GetValueYTD("Fed WT", yearEnd);
				w2.StateWT += t.GetValueYTD("State WT", yearEnd);
			}
			ArrayList allBankAccounts = new ArrayList(this.BankAccounts.Values);
			allBankAccounts.AddRange(this.ClosedBankAccounts.Values);
			foreach (object obj4 in allBankAccounts)
			{
				BankAccount ba = (BankAccount)obj4;
				if (ba is SavingsAccount)
				{
					string key = year.ToString() + "-" + ba.ID;
					F1099Int f1099;
					if (this.F1099s.ContainsKey(key))
					{
						f1099 = (F1099Int)this.F1099s[key];
					}
					else
					{
						f1099 = new F1099Int(year, ba.BankName, base.Name, this.Person.ID);
						this.F1099s.Add(key, f1099);
					}
					f1099.Interest += ((SavingsAccount)ba).Interest(year);
				}
			}
			if (A.SS.TaxesEnabledForOwner)
			{
				base.Player.SendMessage("Your tax information for last year has arrived. You now have the information needed to prepare your tax return.", "", NotificationColor.Green);
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00017494 File Offset: 0x00016494
		public void AuditAndRefundOrBill()
		{
			TaxReturn t = null;
			int year = A.ST.Now.Year - 1;
			foreach (object obj in this.TaxReturns)
			{
				TaxReturn f = (TaxReturn)obj;
				if (f.Year == year)
				{
					t = f;
				}
			}
			AccountantsReport IRSNumbers;
			if (t is AccountantsReport)
			{
				IRSNumbers = (AccountantsReport)t;
			}
			else
			{
				IRSNumbers = new AccountantsReport(year);
				IRSNumbers.PrepareTaxes(year, this, false);
			}
			BankAccount fedTaxes = (BankAccount)this.MerchantAccounts["IRS"];
			fedTaxes.Transactions.Add(new Transaction((float)IRSNumbers.Tax, Transaction.TranType.Credit, A.R.GetString("Tax due for {0}", new object[]
			{
				year
			})));
			fedTaxes.Transactions.Add(new Transaction((float)IRSNumbers.FedWT, Transaction.TranType.Debit, A.R.GetString("Tax withheld for {0}", new object[]
			{
				year
			})));
			int balance = (int)fedTaxes.EndingBalance();
			int penalty = 0;
			string reasons = "";
			if (t == null)
			{
				penalty += 1000;
				reasons += "failing to file a tax return, ";
			}
			else if (t is F1040EZ)
			{
				float taxReported = (float)t.Values[6];
				float balanceReported;
				if (t.Values[7] > 0)
				{
					balanceReported = (float)(-(float)t.Values[7]);
				}
				else
				{
					balanceReported = (float)t.Values[8];
				}
				if (balanceReported < (float)balance || taxReported < (float)IRSNumbers.Tax)
				{
					penalty += 100;
					reasons += "Form 1040EZ under-reporting tax due, ";
				}
			}
			if (balance + penalty > 0)
			{
				base.Player.SendMessage(A.R.GetString("Uh, oh! Your tax return was audited. You owe {0} in taxes + {1} in penalities for {2}.", new object[]
				{
					Utilities.FC((float)balance, 0, A.I.CurrencyConversion),
					Utilities.FC((float)penalty, 0, A.I.CurrencyConversion),
					Utilities.FormatCommaSeries(reasons)
				}), A.R.GetString("Internal Revenue Service"), NotificationColor.Yellow);
				this.AddBill(new Bill("IRS", A.R.GetString("Penalties"), (float)penalty, fedTaxes));
			}
			if (balance + penalty < 0 && t != null)
			{
				string msg = A.R.GetString("Your tax refund check has arrived!! Your refund was {0}.", new object[]
				{
					Utilities.FC((float)(-(float)balance), 0, A.I.CurrencyConversion)
				});
				if (penalty > 0)
				{
					msg += A.R.GetString("However, you were charged {0} in penalties for {1}.", new object[]
					{
						Utilities.FC((float)penalty, 0, A.I.CurrencyConversion),
						Utilities.FormatCommaSeries(reasons)
					});
				}
				base.Player.SendMessage(msg, A.R.GetString("Internal Revenue Service"), NotificationColor.Green);
				Check c = new Check(-1L);
				c.Amount = (float)(-(float)(balance + penalty));
				c.Payee = base.Name;
				c.Date = A.ST.Now;
				c.Payor = "Internal Revenue Service";
				c.Number = (int)A.ST.GetNextID();
				c.Memo = A.R.GetString("Tax refund {0}", new object[]
				{
					year
				});
				c.Signature = A.R.GetString("Uncle Sam");
				this.AddCheck(c);
				if (penalty > 0)
				{
					fedTaxes.Transactions.Add(new Transaction((float)penalty, Transaction.TranType.Credit, A.R.GetString("Penalties")));
				}
				fedTaxes.Transactions.Add(new Transaction(c.Amount, Transaction.TranType.Credit, A.R.GetString("Tax refund for {0}", new object[]
				{
					year
				})));
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0001791C File Offset: 0x0001691C
		public void CheckValiditySynchTravel(int modeOfTransportation, DailyRoutine routine, Task changedTask, bool addTask)
		{
			ArrayList temp = new ArrayList(routine.Tasks.Values);
			foreach (object obj in temp)
			{
				Task task = (Task)obj;
				if (task is TravelTask)
				{
					routine.Tasks.Remove(task.StartPeriod);
				}
			}
			if (changedTask != null)
			{
				routine.CheckHoursConflict(changedTask);
				if (addTask)
				{
					routine.Tasks.Add(changedTask.StartPeriod, changedTask);
				}
				else
				{
					int keyToRemove = -1;
					foreach (object obj2 in routine.Tasks.Keys)
					{
						int key = (int)obj2;
						if (routine.Tasks[key] == changedTask)
						{
							keyToRemove = key;
						}
					}
					routine.Tasks.Remove(keyToRemove);
					routine.Tasks.Add(changedTask.StartPeriod, changedTask);
				}
			}
			if (routine.Tasks.Count > 1 && modeOfTransportation != -1)
			{
				ArrayList newTravelTasks = new ArrayList();
				foreach (object obj3 in routine.Tasks.Values)
				{
					Task task = (Task)obj3;
					Task priorTask = routine.PriorTask(task);
					AppBuilding prior = priorTask.Building;
					if (task.Building != prior)
					{
						TravelTask taskNew = TravelTask.CreateTravelTask(modeOfTransportation);
						float periodsF = (float)(taskNew.EstTimeInSteps(prior, task.Building) * 20000) / 1800000f;
						int periods = (int)Math.Ceiling((double)periodsF);
						taskNew.StartPeriod = priorTask.EndPeriod;
						taskNew.EndPeriod = (taskNew.StartPeriod + periods) % 48;
						taskNew.From = prior;
						taskNew.To = task.Building;
						taskNew.Building = taskNew.From;
						taskNew.Owner = this.Person;
						newTravelTasks.Add(taskNew);
					}
				}
				foreach (object obj4 in newTravelTasks)
				{
					TravelTask task2 = (TravelTask)obj4;
					routine.Tasks.Add(task2.StartPeriod, task2);
				}
			}
			this.OneTimeEventTaskQueue.Clear();
			foreach (object obj5 in this.OneTimeEvents.Values)
			{
				OneTimeEvent e = (OneTimeEvent)obj5;
				TravelTask travelTo = TravelTask.CreateTravelTask(modeOfTransportation);
				TravelTask travelFrom = TravelTask.CreateTravelTask(modeOfTransportation);
				OneTimeEvent main = (OneTimeEvent)Utilities.DeepCopyBySerialization(e);
				main.ID = A.ST.GetNextID();
				travelTo.Owner = this.Person;
				travelFrom.Owner = this.Person;
				main.Owner = this.Person;
				main.Building = e.Building;
				travelTo.Building = this.Dwelling;
				travelTo.From = this.Dwelling;
				travelTo.To = e.Building;
				travelFrom.Building = e.Building;
				travelFrom.From = e.Building;
				travelFrom.To = this.Dwelling;
				travelTo.OneTimeDay = new DateTime(e.OneTimeDay.Year, e.OneTimeDay.Month, e.OneTimeDay.Day).AddHours((double)((float)e.StartPeriod / 2f)).AddMinutes((double)((float)(-(float)travelTo.EstTimeInSteps(travelTo.From, travelTo.To)) * ((float)A.ST.SimulatedTimePerStep / 60000f)));
				travelTo.StartPeriod = travelTo.OneTimeDay.Hour * 2;
				if (e.StartPeriod < e.EndPeriod)
				{
					travelFrom.OneTimeDay = e.OneTimeDay;
				}
				else
				{
					travelFrom.OneTimeDay = e.OneTimeDay.AddDays(1.0);
				}
				travelFrom.StartPeriod = e.EndPeriod;
				this.OneTimeEventTaskQueue.AddRange(new Task[]
				{
					travelTo,
					main,
					travelFrom
				});
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00017EBC File Offset: 0x00016EBC
		public void AddFood(int meals)
		{
			for (int i = 0; i < meals; i++)
			{
				this.Food.Add(A.ST.Now);
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00017EF8 File Offset: 0x00016EF8
		protected Task FindActualTravelTask(TravelTask originalTask)
		{
			bool sub = false;
			if (originalTask is TravelByCar)
			{
				Car car = this.Car;
				((TravelByCar)originalTask).Car = car;
				if (car == null || car.Gas <= 0f || car.Broken)
				{
					sub = true;
				}
				if (car != null && car.Gas <= 0f)
				{
					base.Player.SendPeriodicMessage("Your car is out of gas. You had to walk. Buy some gas at the gas station.", "", NotificationColor.Yellow, 3f);
				}
				if (car != null && car.Broken)
				{
					base.Player.SendPeriodicMessage("Your car has broken down. You had to walk. Get your car fixed at the gas station.", "", NotificationColor.Yellow, 3f);
				}
			}
			TravelByFoot walk = new TravelByFoot();
			if (originalTask is TravelByBus)
			{
				if (this.BusTokens <= 0)
				{
					base.Player.SendPeriodicMessage("You are out of bus tokens. You had to walk. Buy some tokens at any bus stop.", "", NotificationColor.Yellow, 3f);
					sub = true;
				}
				else if (walk.EstTimeInSteps(originalTask.From, originalTask.To) <= originalTask.EstTimeInSteps(originalTask.From, originalTask.To))
				{
					sub = true;
				}
			}
			Task result;
			if (sub)
			{
				walk.From = originalTask.From;
				walk.To = originalTask.To;
				walk.Building = originalTask.Building;
				walk.Owner = originalTask.Owner;
				result = walk;
			}
			else
			{
				result = originalTask;
			}
			return result;
		}

		/// <summary>
		/// Gets the work or personal healthinsurance policy with lowest copay.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600016D RID: 365 RVA: 0x0001807C File Offset: 0x0001707C
		public InsurancePolicy GetBestHealthInsurance()
		{
			InsurancePolicy policy = this.HealthInsurance;
			foreach (object obj in this.GetAllTasks())
			{
				Task t = (Task)obj;
				if (t is WorkTask)
				{
					WorkTask wt = (WorkTask)t;
					if (wt.HealthInsurance != null && wt.HealthInsurance.Copay > -1f && (wt.HealthInsurance.Copay < policy.Copay || policy.Copay == -1f))
					{
						policy = wt.HealthInsurance;
					}
				}
			}
			return policy;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00018160 File Offset: 0x00017160
		public void AddCheck(Check c)
		{
			this.Checks.Add(c.ID, c);
			base.Player.SendMessage(A.R.GetString("A check has arrived from {0}. It is on your desk. Click it to cash it or deposit it.", new object[]
			{
				c.Payor
			}), "", NotificationColor.Green);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000181B8 File Offset: 0x000171B8
		public string WorstHealthFactor()
		{
			float min = float.MaxValue;
			int index = -1;
			for (int i = 0; i < A.SS.HealthFactorsToConsider; i++)
			{
				if (this.HealthFactorAvg(i) < min)
				{
					index = i;
					min = this.HealthFactorAvg(i);
				}
			}
			return AppConstants.HealthFactorNames[index];
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00018218 File Offset: 0x00017218
		public InvestmentAccount GetInvestmentAccount(string fundName, bool retirement)
		{
			SortedList accounts = this.InvestmentAccounts;
			if (retirement)
			{
				accounts = this.RetirementAccounts;
			}
			InvestmentAccount account = null;
			foreach (object obj in accounts.Values)
			{
				InvestmentAccount a = (InvestmentAccount)obj;
				if (a.Fund.Name == fundName)
				{
					account = a;
				}
			}
			if (account == null)
			{
				account = new InvestmentAccount(A.ST.GetFund(fundName));
				account.Retirement = retirement;
				account.BankName = A.R.GetString("Fiduciary Investments");
				accounts.Add(account.AccountNumber, account);
			}
			return account;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0001830C File Offset: 0x0001730C
		public void SetDailyRoutine(bool weekend, DailyRoutine routine)
		{
			if (weekend)
			{
				this.dailyRoutineWE = routine;
			}
			else
			{
				this.dailyRoutineWD = routine;
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00018334 File Offset: 0x00017334
		public Task GetCurrentTaskForOneTimeEvent()
		{
			Task t = null;
			foreach (object obj in this.OneTimeEventTaskQueue)
			{
				Task a = (Task)obj;
				if (a.DayLastStarted != A.ST.Day && a.OneTimeDay.Day == A.ST.Day && a.OneTimeDay.Month == A.ST.Month && a.OneTimeDay.Year == A.ST.Year)
				{
					if (a.StartPeriod < a.EndPeriod)
					{
						if (a.StartPeriod <= A.ST.Period && A.ST.Period < a.EndPeriod)
						{
							t = a;
						}
					}
					else if (a.StartPeriod <= A.ST.Period || A.ST.Period < a.EndPeriod)
					{
						t = a;
					}
				}
			}
			if (t != null)
			{
				t.DayLastStarted = A.ST.Day;
			}
			return t;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000184B8 File Offset: 0x000174B8
		public float PartyHostingScore()
		{
			int total = 0;
			foreach (object obj in this.PartyAttendance.Keys)
			{
				DateTime d = (DateTime)obj;
				if (d > A.ST.Now.AddDays(-120.0))
				{
					total += (int)this.PartyAttendance[d];
				}
			}
			return (float)total / 120f;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00018574 File Offset: 0x00017574
		public Mortgage GetMortgage(AppBuilding building)
		{
			foreach (object obj in this.Mortgages.Values)
			{
				Mortgage i = (Mortgage)obj;
				if (i.Building == building)
				{
					return i;
				}
			}
			return null;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000185F4 File Offset: 0x000175F4
		public float ComputeRealEstateValue()
		{
			float total = 0f;
			foreach (object obj in A.ST.City.GetBuildings())
			{
				AppBuilding b = (AppBuilding)obj;
				if (b.Owner == this && ((DwellingOffer)b.Offerings[0]).Condo)
				{
					total += (float)b.Rent * A.ST.RealEstateIndex;
				}
			}
			return total;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000176 RID: 374 RVA: 0x000186AC File Offset: 0x000176AC
		public float GrossIncomeLast12Months
		{
			get
			{
				float total = 0f;
				foreach (object obj in this.WorkTaskHistory.Values)
				{
					WorkTask t = (WorkTask)obj;
					foreach (object obj2 in t.PayStubs)
					{
						PayStub ps = (PayStub)obj2;
						if ((A.ST.Now - ps.WeekEnding).Days < 365)
						{
							total += (float)ps.PayValues["Gross Pay"];
						}
					}
				}
				return total;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000177 RID: 375 RVA: 0x000187C8 File Offset: 0x000177C8
		public float DebtService
		{
			get
			{
				float total = 0f;
				foreach (object obj in A.SA.GetInstallmentLoans(base.ID).Values)
				{
					InstallmentLoan i = (InstallmentLoan)obj;
					total += i.Payment;
				}
				return total * 12f;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00018858 File Offset: 0x00017858
		public void CloseAccount(BankAccount a)
		{
			foreach (object obj in this.BankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				if (ba is CheckingAccount)
				{
					foreach (object obj2 in ((CheckingAccount)ba).RecurringPayments)
					{
						RecurringPayment p = (RecurringPayment)obj2;
						if (p.PayeeAccountNumber == a.AccountNumber)
						{
							((CheckingAccount)ba).RecurringPayments.Remove(p);
							this.Payees.Remove(a);
							break;
						}
					}
				}
			}
			a.DateClosed = A.ST.Now;
			if (a is CreditCardAccount)
			{
				this.ClosedCreditCardAccounts.Add(a.AccountNumber, this.CreditCardAccounts[a.AccountNumber]);
				this.CreditCardAccounts.Remove(a.AccountNumber);
			}
			else if (a is InstallmentLoan)
			{
				foreach (object obj3 in this.BankAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj3;
					if (ba is CheckingAccount)
					{
						foreach (object obj4 in ((CheckingAccount)ba).RecurringPayments)
						{
							RecurringPayment p = (RecurringPayment)obj4;
							if (p.PayeeAccountNumber == a.AccountNumber)
							{
								((CheckingAccount)ba).RecurringPayments.Remove(p);
								break;
							}
						}
					}
				}
				if (this.Car != null && this.Car.Loan != null && this.Car.Loan.AccountNumber == a.AccountNumber)
				{
					this.ClosedInstallmentLoans.Add(a.AccountNumber, this.Car.Loan);
					this.Car.Loan = null;
				}
				else if (this.Mortgages.ContainsKey(a.AccountNumber))
				{
					this.ClosedInstallmentLoans.Add(a.AccountNumber, this.Mortgages[a.AccountNumber]);
					this.Mortgages.Remove(a.AccountNumber);
				}
				else
				{
					this.ClosedInstallmentLoans.Add(a.AccountNumber, this.StudentLoans[a.AccountNumber]);
					this.StudentLoans.Remove(a.AccountNumber);
				}
			}
			else if (a != null)
			{
				this.ClosedBankAccounts.Add(a.AccountNumber, this.BankAccounts[a.AccountNumber]);
				this.BankAccounts.Remove(a.AccountNumber);
				this.Cash += a.EndingBalance();
				foreach (object obj5 in this.GetAllTasks())
				{
					Task t = (Task)obj5;
					if (t is WorkTask && ((WorkTask)t).DirectDepositAccount == a)
					{
						((WorkTask)t).DirectDepositAccount = null;
					}
				}
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00018CFC File Offset: 0x00017CFC
		public SortedList GetInstallmentLoans()
		{
			SortedList installmentLoans = (SortedList)this.StudentLoans.Clone();
			foreach (object obj in this.Mortgages.Values)
			{
				InstallmentLoan i = (InstallmentLoan)obj;
				installmentLoans.Add(i.AccountNumber, i);
			}
			if (this.Car != null && this.Car.Loan != null)
			{
				installmentLoans.Add(this.Car.Loan.AccountNumber, this.Car.Loan);
			}
			return installmentLoans;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00018DD4 File Offset: 0x00017DD4
		public void RetireFromApp(GameOverMessage gomsg)
		{
			if (A.ST.Multiplayer)
			{
				foreach (object obj in A.ST.City.GetBuildings())
				{
					AppBuilding b = (AppBuilding)obj;
					if (b.Persons.Contains(this.Person))
					{
						b.Persons.Remove(this.Person);
					}
					if (b.Owner == this)
					{
						b.Owner = null;
					}
				}
				DwellingOffer dwo = (DwellingOffer)this.Dwelling.Offerings[0];
				dwo.Taken = false;
				ArrayList temp = this.GetAllTasks();
				foreach (object obj2 in temp)
				{
					Task t = (Task)obj2;
					this.RemoveTask(t);
				}
				PlayerMessage.Broadcast(A.R.GetString("The player, {0}, has died or been foreclosed upon and is out of the sim.", new object[]
				{
					base.Name
				}), "", NotificationColor.Green);
			}
			base.Retire(gomsg);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00018F5C File Offset: 0x00017F5C
		public float FICAPaidThisYear()
		{
			float total = 0f;
			foreach (object obj in this.WorkTaskHistory.Values)
			{
				WorkTask t = (WorkTask)obj;
				foreach (object obj2 in t.PayStubs)
				{
					PayStub ps = (PayStub)obj2;
					if (ps.Year() == A.ST.Now.Year)
					{
						total += ps.GetValue("Soc Sec");
					}
				}
			}
			return total;
		}

		// Token: 0x0400014D RID: 333
		public float Cash;

		// Token: 0x0400014E RID: 334
		public Hashtable MerchantAccounts = new Hashtable();

		// Token: 0x0400014F RID: 335
		public ArrayList Food = new ArrayList();

		// Token: 0x04000150 RID: 336
		public DateTime timeLastAte = DateTime.MinValue;

		// Token: 0x04000151 RID: 337
		public Surprise[] Surprises;

		// Token: 0x04000152 RID: 338
		private static ScoreAdapter scoreAdapter;

		// Token: 0x04000153 RID: 339
		public bool ElectricityOff = false;

		// Token: 0x04000154 RID: 340
		public bool Internet = false;

		// Token: 0x04000155 RID: 341
		public bool InsuranceOff = false;

		// Token: 0x04000156 RID: 342
		public float[][] HealthFactors = new float[AppConstants.HealthFactorNames.Length][];

		// Token: 0x04000157 RID: 343
		public float[] TodaysHealth = new float[AppConstants.HealthFactorNames.Length];

		// Token: 0x04000158 RID: 344
		public SortedList BankAccounts = new SortedList();

		// Token: 0x04000159 RID: 345
		public SortedList CreditCardAccounts = new SortedList();

		// Token: 0x0400015A RID: 346
		public SortedList StudentLoans = new SortedList();

		// Token: 0x0400015B RID: 347
		public SortedList ClosedBankAccounts = new SortedList();

		// Token: 0x0400015C RID: 348
		public SortedList ClosedCreditCardAccounts = new SortedList();

		// Token: 0x0400015D RID: 349
		public SortedList ClosedInstallmentLoans = new SortedList();

		// Token: 0x0400015E RID: 350
		public InsurancePolicy RentersInsurance = new InsurancePolicy(-1f, false, 0f);

		// Token: 0x0400015F RID: 351
		public InsurancePolicy HealthInsurance = new InsurancePolicy(-1f);

		// Token: 0x04000160 RID: 352
		public VBPFPerson Person;

		// Token: 0x04000161 RID: 353
		public Dwelling Dwelling;

		// Token: 0x04000162 RID: 354
		public SortedList Mortgages = new SortedList();

		// Token: 0x04000163 RID: 355
		public ArrayList Payees = new ArrayList();

		// Token: 0x04000164 RID: 356
		public ArrayList TaxReturns = new ArrayList();

		// Token: 0x04000165 RID: 357
		private DailyRoutine dailyRoutineWD = new DailyRoutine();

		// Token: 0x04000166 RID: 358
		private DailyRoutine dailyRoutineWE = new DailyRoutine();

		// Token: 0x04000167 RID: 359
		public Car Car = null;

		// Token: 0x04000168 RID: 360
		public SortedList AcademicTaskHistory = new SortedList();

		// Token: 0x04000169 RID: 361
		protected int modeOfTransportation = -1;

		// Token: 0x0400016A RID: 362
		public ArrayList PurchasedItems = new ArrayList();

		// Token: 0x0400016B RID: 363
		public bool Sick = false;

		// Token: 0x0400016C RID: 364
		public SortedList Checks = new SortedList();

		// Token: 0x0400016D RID: 365
		public SortedList Bills = new SortedList();

		// Token: 0x0400016E RID: 366
		public SortedList WorkTaskHistory = new SortedList();

		// Token: 0x0400016F RID: 367
		public Hashtable FW2s = new Hashtable();

		// Token: 0x04000170 RID: 368
		public Hashtable F1099s = new Hashtable();

		// Token: 0x04000171 RID: 369
		public Hashtable FiredFrom = new Hashtable();

		// Token: 0x04000172 RID: 370
		public Hashtable Quit = new Hashtable();

		// Token: 0x04000173 RID: 371
		public Hashtable STCapitalGains = new Hashtable();

		// Token: 0x04000174 RID: 372
		public Hashtable LTCapitalGains = new Hashtable();

		// Token: 0x04000175 RID: 373
		public SortedList InvestmentAccounts = new SortedList();

		// Token: 0x04000176 RID: 374
		public SortedList RetirementAccounts = new SortedList();

		// Token: 0x04000177 RID: 375
		public int BusTokens = 0;

		// Token: 0x04000178 RID: 376
		public SortedList OneTimeEvents = new SortedList();

		// Token: 0x04000179 RID: 377
		public ArrayList OneTimeEventTaskQueue = new ArrayList();

		// Token: 0x0400017A RID: 378
		public Hashtable PartyAttendance = new Hashtable();

		// Token: 0x0400017B RID: 379
		public ArrayList PartyFood = new ArrayList();

		// Token: 0x0400017C RID: 380
		public long DDRLockedBy = -1L;

		// Token: 0x0400017D RID: 381
		public DateTime LastDanced;
	}
}
