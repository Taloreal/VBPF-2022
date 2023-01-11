using System;
using System.Collections;
using System.Runtime.CompilerServices;
using KMI.Biz;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Used as a "front end" to the application's sim state, this
	/// class provides a way to get a chunk of sim state data all at once.
	/// This is especially useful for avoiding fine-grained accesses to a 
	/// remote sim state.
	/// </summary>
	// Token: 0x02000021 RID: 33
	public class AppStateAdapter : BizStateAdapter
	{
		// Token: 0x060000AD RID: 173 RVA: 0x0000BFB0 File Offset: 0x0000AFB0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetRegisterEntries(long entityID, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return ((CheckingAccount)e.BankAccounts[accountNumber]).RegisterEntries;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000BFEC File Offset: 0x0000AFEC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetRegisterEntries(long entityID, string bankName, long accountNumber, ArrayList entries)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			((CheckingAccount)e.BankAccounts[accountNumber]).RegisterEntries = entries;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000C024 File Offset: 0x0000B024
		[MethodImpl(MethodImplOptions.Synchronized)]
		public BankAccount GetBankAccount(long entityID, string bankName, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return (BankAccount)e.BankAccounts[bankName + accountNumber];
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000C060 File Offset: 0x0000B060
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetBankAccounts(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.BankAccounts;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000C084 File Offset: 0x0000B084
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetInstallmentLoans(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.GetInstallmentLoans();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000C0A8 File Offset: 0x0000B0A8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetPayees(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (!e.Has("Computer"))
			{
				throw new SimApplicationException(A.R.GetString("You need a computer to do online banking. Buy one at the store."));
			}
			if (!e.Internet)
			{
				throw new SimApplicationException(A.R.GetString("You need to subscribe to Internet access to use online banking."));
			}
			if (e.ElectricityOff)
			{
				throw new SimApplicationException(A.R.GetString("Your electricity is turned off. You cannot use your computer to do online banking."));
			}
			return e.Payees;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000C134 File Offset: 0x0000B134
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SchedulePayments(long entityID, long accountNumber, Hashtable payments)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Transaction.TranType tranType = Transaction.TranType.Debit;
			BankAccount fromAccount = (BankAccount)e.BankAccounts[accountNumber];
			foreach (object obj in payments.Keys)
			{
				BankAccount payeeAccount = (BankAccount)obj;
				float amount = (float)payments[payeeAccount];
				if (fromAccount.EndingBalance() < amount)
				{
					throw new SimApplicationException(A.R.GetString("Some online payments were rejected. You do not have enough money in the account."));
				}
				fromAccount.Transactions.Add(new Transaction(amount, tranType, payeeAccount.BankName));
				e.ApplyPaymentToAccount(payeeAccount.AccountNumber, amount);
				e.RemoveBillIfExactMatch(payeeAccount.AccountNumber, amount);
			}
			e.Journal.AddEntry(A.R.GetString("Bill payments made via online banking."));
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000C250 File Offset: 0x0000B250
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetRecurringPayments(long entityID, long accountNumber, ArrayList payments)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			CheckingAccount fromAccount = (CheckingAccount)e.BankAccounts[accountNumber];
			fromAccount.RecurringPayments = payments;
			e.Journal.AddEntry(A.R.GetString("Recurring payments set via online banking."));
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000C2A4 File Offset: 0x0000B2A4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void TransferFunds(long entityID, long fromAccountNumber, long toAccountNumber, float amount)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			BankAccount fromAccount = (BankAccount)e.BankAccounts[fromAccountNumber];
			BankAccount toAccount = (BankAccount)e.BankAccounts[toAccountNumber];
			if (fromAccount.EndingBalance() < amount)
			{
				throw new SimApplicationException("You do not have that much in the account. Please try again.");
			}
			fromAccount.Transactions.Add(new Transaction(amount, Transaction.TranType.Debit, A.R.GetString("Transfer out")));
			toAccount.Transactions.Add(new Transaction(amount, Transaction.TranType.Credit, A.R.GetString("Transfer in")));
			e.Journal.AddEntry(A.R.GetString("Transferred {0} from {1} to {2}.", new object[]
			{
				Utilities.FC(amount, S.I.CurrencyConversion),
				fromAccount.ToString(),
				toAccount.ToString()
			}));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000C39C File Offset: 0x0000B39C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetCreditCardAccounts(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.CreditCardAccounts;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000C3C0 File Offset: 0x0000B3C0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetGoodCreditCardAccounts(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			SortedList i = new SortedList();
			foreach (object obj in e.CreditCardAccounts.Values)
			{
				CreditCardAccount cca = (CreditCardAccount)obj;
				BankAccount.Status status = cca.PastDueStatus(A.ST.Year, A.ST.Month);
				if (status != BankAccount.Status.NewlyCancelled && status != BankAccount.Status.Cancelled)
				{
					i.Add(cca.AccountNumber, cca);
				}
			}
			return i;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000C488 File Offset: 0x0000B488
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Car GetAutoInsurance(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Car == null)
			{
				throw new SimApplicationException(A.R.GetString("You do not need auto insurance because you don't have a car."));
			}
			return (Car)Utilities.DeepCopyBySerialization(e.Car);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000C4DC File Offset: 0x0000B4DC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public InsurancePolicy GetHealthInsurance(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return (InsurancePolicy)Utilities.DeepCopyBySerialization(e.HealthInsurance);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000C50C File Offset: 0x0000B50C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetHealthInsurance(long entityID, InsurancePolicy policy)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.HealthInsurance = policy;
			if (policy.Deductible > -1f)
			{
				e.Journal.AddEntry(A.R.GetString("Purchased health insurance policy for {0} per month.", new object[]
				{
					Utilities.FC(policy.MonthlyPremium, 2, S.I.CurrencyConversion)
				}));
			}
			else
			{
				e.Journal.AddEntry(A.R.GetString("Decided not to carry health insurance."));
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000C59C File Offset: 0x0000B59C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool HasHealthInsuranceThruWork(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			foreach (object obj in e.GetAllTasks())
			{
				Task t = (Task)obj;
				if (t is WorkTask && ((WorkTask)t).HealthInsurance != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000C638 File Offset: 0x0000B638
		[MethodImpl(MethodImplOptions.Synchronized)]
		public InsurancePolicy GetRentersInsurance(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (((DwellingOffer)e.Dwelling.Offerings[0]).Condo && e.RentersInsurance.Deductible == -1f)
			{
				throw new SimApplicationException("You live in a condo. You need homeowner's insurance, not renter's insurance.");
			}
			return (InsurancePolicy)Utilities.DeepCopyBySerialization(e.RentersInsurance);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000C6AC File Offset: 0x0000B6AC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetRentersInsurance(long entityID, InsurancePolicy policy)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.RentersInsurance = policy;
			if (policy.Deductible > -1f)
			{
				e.Journal.AddEntry(A.R.GetString("Purchased renter's insurance policy for {0} per month.", new object[]
				{
					Utilities.FC(policy.MonthlyPremium, 2, S.I.CurrencyConversion)
				}));
			}
			else
			{
				e.Journal.AddEntry(A.R.GetString("Decided not to carry renter's insurance."));
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000C73C File Offset: 0x0000B73C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmHomeOwnersInsurance.Input GetHomeOwnersInsurance(Offering offering)
		{
			frmHomeOwnersInsurance.Input input = default(frmHomeOwnersInsurance.Input);
			Dwelling d = (Dwelling)offering.Building;
			input.Policy = (InsurancePolicy)Utilities.DeepCopyBySerialization(d.Insurance);
			input.Value = (float)d.Rent * A.ST.RealEstateIndex;
			return input;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000C793 File Offset: 0x0000B793
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetHomeOwnersInsurance(Offering offering, InsurancePolicy policy)
		{
			((Dwelling)offering.Building).Insurance = policy;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000C7A8 File Offset: 0x0000B7A8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetAutoInsurance(long entityID, InsurancePolicy policy)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Car != null)
			{
				e.Car.Insurance = policy;
				e.Journal.AddEntry(A.R.GetString("Purchased auto insurance policy for {0} per month.", new object[]
				{
					Utilities.FC(policy.MonthlyPremium, 2, S.I.CurrencyConversion)
				}));
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000C81C File Offset: 0x0000B81C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public float[] GetHealth(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float[] healthFactors = new float[A.SS.HealthFactorsToConsider];
			for (int i = 0; i < A.SS.HealthFactorsToConsider; i++)
			{
				healthFactors[i] = e.HealthFactorAvg(i);
			}
			return healthFactors;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000C870 File Offset: 0x0000B870
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void AddTask(long entityID, Task task)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			DailyRoutine temp = e.GetDailyRoutine(task.Weekend).MakeCopy();
			task.ID = A.ST.GetNextID();
			task.Owner = e.Person;
			task.Building = e.Dwelling;
			e.CheckValiditySynchTravel(e.ModeOfTransportation, temp, task, true);
			e.SetDailyRoutine(task.Weekend, temp);
			if (task is Sleep || task is Eat || task is Relax || task is Exercise)
			{
				e.Journal.AddEntry(A.R.GetString("Decided to {0} from {1} to {2} on {3}s.", new object[]
				{
					task.CategoryName().ToLower(),
					Task.ToTimeString(task.StartPeriod),
					Task.ToTimeString(task.EndPeriod),
					task.WeekendString().ToLower()
				}));
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000C96C File Offset: 0x0000B96C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public AppBuildingDrawable.AddOfferingInfo Enroll(long entityID, long courseID, InstallmentLoan loan, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Course c = (Course)A.ST.City.GetOffering(courseID);
			if (c.Prerequisite != null)
			{
				bool found = false;
				foreach (object obj in e.AcademicTaskHistory.Values)
				{
					AttendClass t = (AttendClass)obj;
					if (t.Course.Name == c.Prerequisite)
					{
						found = true;
					}
				}
				if (!found)
				{
					throw new SimApplicationException(A.R.GetString("We're sorry. You are required to complete the course {0} before taking this course.", new object[]
					{
						c.Prerequisite
					}));
				}
			}
			if (c.Students.Count >= 8)
			{
				throw new SimApplicationException(A.R.GetString("We're sorry. There is no more room left in that course. Please try back in a few months."));
			}
			BankAccount ba = null;
			float balance = c.Cost - loan.OriginalBalance;
			if (accountNumber > -1L)
			{
				ba = (BankAccount)e.BankAccounts[accountNumber];
				if (balance > ba.EndingBalance())
				{
					throw new SimApplicationException("You do not have enough money in that checking account to pay the balance. Choose another account or get a larger loan.");
				}
			}
			this.AddOffering(entityID, courseID, null);
			if (loan.OriginalBalance > 0f)
			{
				loan.Transactions.Add(new Transaction(loan.OriginalBalance, Transaction.TranType.Credit, "Original Balance"));
				e.StudentLoans.Add(loan.AccountNumber, loan);
			}
			if (accountNumber > -1L)
			{
				ba.Transactions.Add(new Transaction(balance, Transaction.TranType.Debit, "Payment for course"));
			}
			return new AppBuildingDrawable.AddOfferingInfo
			{
				IsFirstTravel = (e.ModeOfTransportation < 0)
			};
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000CB88 File Offset: 0x0000BB88
		[MethodImpl(MethodImplOptions.Synchronized)]
		public AppBuildingDrawable.AddOfferingInfo AddOffering(long entityID, long offeringID, JobApplication jobApp)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			AppBuildingDrawable.AddOfferingInfo result = default(AppBuildingDrawable.AddOfferingInfo);
			Offering o = A.ST.City.GetOffering(offeringID);
			if (o.Taken)
			{
				throw new SimApplicationException(A.R.GetString("I'm sorry. That offering has been taken."));
			}
			Type type = o.GetType();
			if (type == typeof(DwellingOffer))
			{
				bool firstTime = e.Dwelling == null;
				this.MoveTo(entityID, o.ID);
				if (firstTime)
				{
					Dwelling newDwelling = (Dwelling)o.Building;
					e.Dwelling.Persons.Add(e.Person);
					e.Person.Location = e.Dwelling.EntryPoint;
					Task t = new Sleep();
					t.StartPeriod = 0;
					t.EndPeriod = 12;
					this.AddTask(e.ID, t);
					Task t2 = new Sleep();
					t2.StartPeriod = 0;
					t2.EndPeriod = 12;
					t2.Weekend = true;
					this.AddTask(e.ID, t2);
					e.Journal.Entries.Clear();
					if (A.SS.AutoPayRentElectric)
					{
						this.SetBankAccount(e.ID, (BankAccount)A.ST.City.GetOfferings(typeof(CheckingAccount))[0], A.SS.InitialCash / 2f, -1L);
						RecurringPayment r = new RecurringPayment();
						r.Amount = (float)newDwelling.Rent;
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
			else
			{
				Task t = o.CreateTask();
				if (o is Job)
				{
					((WorkTask)t).EvaluateApplicant(e, o, jobApp);
				}
				t.Building = o.Building;
				t.Owner = e.Person;
				DailyRoutine temp = e.GetDailyRoutine(t.Weekend).MakeCopy();
				e.CheckValiditySynchTravel(e.ModeOfTransportation, temp, t, true);
				e.SetDailyRoutine(t.Weekend, temp);
				if (t is WorkTask)
				{
					e.WorkTaskHistory.Add(t.ID, t);
					result.TaskID = t.ID;
					o.Taken = true;
				}
				if (t is AttendClass)
				{
					((AttendClass)t).Course = (Course)o;
					((Course)o).Students.Add(t.Owner);
				}
				result.IsFirstTravel = (e.ModeOfTransportation < 0);
			}
			e.Journal.AddEntry(o.JournalEntry());
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000CF54 File Offset: 0x0000BF54
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void MoveTo(long entityID, long offeringID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			DwellingOffer o = (DwellingOffer)A.ST.City.GetOffering(offeringID);
			if (e.Dwelling != null)
			{
				if (e.Dwelling.MonthsLeftOnLease > 0)
				{
					e.AddBill(new Bill("City Property Mgt", "Lease termination penalty", (float)(e.Dwelling.MonthsLeftOnLease * e.Dwelling.Rent), (BankAccount)e.MerchantAccounts["City Property Mgt"]));
				}
				foreach (object obj in e.GetAllTasks())
				{
					Task t = (Task)obj;
					if (t.Building == e.Dwelling)
					{
						t.Building = (Dwelling)o.Building;
					}
				}
				if (e.Dwelling.Persons.Contains(e.Person))
				{
					e.Dwelling.Persons.Remove(e.Person);
					o.Building.Persons.Add(e.Person);
				}
				if (!((DwellingOffer)e.Dwelling.Offerings[0]).Condo)
				{
					ArrayList apts = A.ST.City.GetOfferings(typeof(DwellingOffer));
					foreach (object obj2 in apts)
					{
						DwellingOffer apt = (DwellingOffer)obj2;
						if (apt.Building == e.Dwelling)
						{
							apt.Taken = false;
						}
					}
					e.Dwelling.Owner = null;
				}
				e.CheckValiditySynchTravel(e.ModeOfTransportation, e.GetDailyRoutine(false), null, false);
				e.CheckValiditySynchTravel(e.ModeOfTransportation, e.GetDailyRoutine(true), null, false);
			}
			e.Dwelling = (Dwelling)o.Building;
			e.Dwelling.Owner = e;
			o.Taken = true;
			if (!o.Condo)
			{
				e.Dwelling.MonthsLeftOnLease = 12;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000D1EC File Offset: 0x0000C1EC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void DeleteTask(long entityID, long taskID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Task t = e.GetTaskByID(taskID);
			e.RemoveTask(t);
			e.CheckValiditySynchTravel(e.ModeOfTransportation, e.GetDailyRoutine(t.Weekend), null, false);
			string verb = t.CategoryName();
			if (t is AttendClass)
			{
			}
			e.Journal.AddEntry(A.R.GetString("Decided not to {0} from {1} to {2} on {3}s.", new object[]
			{
				t.CategoryName().ToLower(),
				Task.ToTimeString(t.StartPeriod),
				Task.ToTimeString(t.EndPeriod),
				t.WeekendString().ToLower()
			}));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000D2B0 File Offset: 0x0000C2B0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void DeleteTask(long entityID, long workTaskID, bool fired, bool quit)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.GetTaskByID(workTaskID) is WorkTask)
			{
				WorkTask t = (WorkTask)e.GetTaskByID(workTaskID);
				if (fired)
				{
					e.FiredFrom.Remove(t.Building.ID.ToString() + t.Name());
					e.FiredFrom.Add(t.Building.ID.ToString() + t.Name(), A.ST.Now);
				}
				if (quit)
				{
					e.Quit.Remove(t.Building.ID.ToString() + t.Name());
					e.Quit.Add(t.Building.ID.ToString() + t.Name(), A.ST.Now);
				}
			}
			this.DeleteTask(entityID, workTaskID);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000D3CC File Offset: 0x0000C3CC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void EditTask(long entityID, long taskID, int startPeriod, int endPeriod)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Task t = e.GetTaskByID(taskID);
			int oldStartPeriod = t.StartPeriod;
			int oldEndPeriod = t.EndPeriod;
			t.StartPeriod = startPeriod;
			t.EndPeriod = endPeriod;
			DailyRoutine temp = e.GetDailyRoutine(t.Weekend).MakeCopy();
			try
			{
				e.CheckValiditySynchTravel(e.ModeOfTransportation, temp, t, false);
			}
			catch (SimApplicationException ex)
			{
				t.StartPeriod = oldStartPeriod;
				t.EndPeriod = oldEndPeriod;
				throw ex;
			}
			e.SetDailyRoutine(t.Weekend, temp);
			t.DayLastStarted = -1;
			e.Journal.AddEntry(A.R.GetString("Changed time to {0} to {1} until {2} on {3}s.", new object[]
			{
				t.CategoryName().ToLower(),
				Task.ToTimeString(t.StartPeriod),
				Task.ToTimeString(t.EndPeriod),
				t.WeekendString().ToLower()
			}));
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000D4D0 File Offset: 0x0000C4D0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmPersonalBalanceSheet.Input GetPersonalBalanceSheet(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmPersonalBalanceSheet.Input input = default(frmPersonalBalanceSheet.Input);
			input.now = A.ST.Now;
			input.cash = e.Cash;
			input.bankAccounts = e.BankAccounts;
			input.investmentAccounts = e.InvestmentAccounts;
			input.retirementAccounts = e.RetirementAccounts;
			input.realEstateValue = e.ComputeRealEstateValue();
			input.creditCardAccounts = e.CreditCardAccounts;
			input.merchantAccounts = e.MerchantAccounts;
			input.installmentLoans = this.GetInstallmentLoans(entityID);
			if (e.Car != null && e.Car.LeaseCost == 0f)
			{
				input.carValue = e.Car.ComputeResalePrice(A.ST.Now);
			}
			input.includeOtherLiabilities = A.SS.IncludeOtherLiabilities;
			return (frmPersonalBalanceSheet.Input)Utilities.DeepCopyBySerialization(input);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000D5D4 File Offset: 0x0000C5D4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmSnapshot.Input GetSnapshot(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmSnapshot.Input input = default(frmSnapshot.Input);
			input.food = e.Food.Count;
			input.health = e.Health;
			input.gas = -1f;
			input.busTokens = -1;
			if (e.Car != null)
			{
				input.gas = e.Car.Gas;
				input.carImageName = "Status" + ((PurchasableItem)A.ST.PurchasableCars[e.Car.CarIndex()]).ImageName;
				input.carBroken = e.Car.Broken;
			}
			if (e.ModeOfTransportation == 1)
			{
				input.busTokens = e.BusTokens;
			}
			return input;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000D6B4 File Offset: 0x0000C6B4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetTaxes(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return (ArrayList)e.TaxReturns.Clone();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000D6E4 File Offset: 0x0000C6E4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetTaxes(long entityID, TaxReturn taxReturn)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.TaxReturns.Add(taxReturn);
			e.Journal.AddEntry(A.R.GetString("Filed tax return for {0}.", new object[]
			{
				taxReturn.Year
			}));
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000D73C File Offset: 0x0000C73C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int GetLastYear()
		{
			return A.ST.Year - 1;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000D75C File Offset: 0x0000C75C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int TaxYearDue(long entityID)
		{
			int lastYear = A.ST.Year - 1;
			int result;
			if (lastYear == A.SS.StartDate.Year - 1)
			{
				result = -1;
			}
			else
			{
				AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
				foreach (object obj in e.TaxReturns)
				{
					TaxReturn t = (TaxReturn)obj;
					if (t.Year == lastYear)
					{
						return -1;
					}
				}
				result = lastYear;
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000D820 File Offset: 0x0000C820
		[MethodImpl(MethodImplOptions.Synchronized)]
		public BankAccount GetFedTaxAccount(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return (BankAccount)Utilities.DeepCopyBySerialization(e.MerchantAccounts["IRS"]);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000D858 File Offset: 0x0000C858
		[MethodImpl(MethodImplOptions.Synchronized)]
		public F1040EZ GetNewF1040EZ(long entityID, int year)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			F1040EZ f = new F1040EZ(year);
			f.Lines[0] = e.Name;
			f.Lines[1] = e.ID.ToString().PadLeft(4, '0');
			f.Lines[2] = "123 Any Street";
			f.Lines[3] = "Springfield, USA";
			f.Lines[4] = e.Name;
			f.Lines[5] = A.ST.Now.ToShortDateString();
			return f;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000D8F0 File Offset: 0x0000C8F0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public DailyRoutine[] GetDailyRoutines(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return new DailyRoutine[]
			{
				e.GetDailyRoutine(false),
				e.GetDailyRoutine(true)
			};
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000D92C File Offset: 0x0000C92C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmCreditScore.Input GetCreditScore(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmCreditScore.Input input = default(frmCreditScore.Input);
			ArrayList reasons = new ArrayList();
			input.Score = e.CreditScore(reasons);
			input.Reasons = reasons;
			return input;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000D970 File Offset: 0x0000C970
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetOfferings(int ave, int street, int lot)
		{
			AppBuilding b = (AppBuilding)A.ST.City[ave, street, lot];
			ArrayList result;
			if (b != null)
			{
				result = b.Offerings;
			}
			else
			{
				result = new ArrayList();
			}
			return result;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000D9B0 File Offset: 0x0000C9B0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetOfferings()
		{
			return A.ST.City.GetOfferings();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000D9D4 File Offset: 0x0000C9D4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetBankAccount(long entityID, BankAccount account, float deposit, long transferFrom)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (transferFrom == -1L)
			{
				if ((double)deposit > (double)e.Cash + 0.01)
				{
					throw new SimApplicationException("You do not have that much cash. Reduce your initial deposit level and try again.");
				}
				e.Cash -= deposit;
			}
			else
			{
				if (deposit > ((BankAccount)e.BankAccounts[transferFrom]).EndingBalance())
				{
					throw new SimApplicationException("You do not have that much in the account you are transferring from. Reduce your initial deposit level and try again.");
				}
				((BankAccount)e.BankAccounts[transferFrom]).Transactions.Add(new Transaction(deposit, Transaction.TranType.Debit, A.R.GetString("Transfer")));
			}
			account = (BankAccount)Utilities.DeepCopyBySerialization(account);
			account.GenerateNewAccountNumber();
			account.Transactions.Add(new Transaction(deposit, Transaction.TranType.Credit, A.R.GetString("Initial deposit")));
			account.OwnerName = e.Name;
			e.BankAccounts.Add(account.AccountNumber, account);
			e.Journal.AddEntry(A.R.GetString("Opened new account: {0} with initial deposit of {1}.", new object[]
			{
				account.ToString(),
				Utilities.FC(deposit, S.I.CurrencyConversion)
			}));
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000DB38 File Offset: 0x0000CB38
		[MethodImpl(MethodImplOptions.Synchronized)]
		public CreditCardAccount GetCreditCardOffer(long entityID, CreditCardAccount proto)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.CreditScore() < 0)
			{
				throw new SimApplicationException(A.R.GetString("You were denied a credit card. Your credit score was too low. Try paying your bills in full and on time to raise your credit score above {0}, then reapply.", new object[]
				{
					0
				}));
			}
			foreach (object obj in e.CreditCardAccounts.Values)
			{
				CreditCardAccount cca = (CreditCardAccount)obj;
				if (cca.BankName == proto.BankName)
				{
					throw new SimApplicationException(A.R.GetString("You already have a credit card from that bank."));
				}
			}
			float ficoNormalized = e.CreditScoreNormalized();
			CreditCardAccount account = new CreditCardAccount(proto.CreditLimit * (1f + ficoNormalized), A.ST.PrimeRate() + proto.InterestRate * (2f - ficoNormalized), proto.LatePaymentFee);
			account.BankName = proto.BankName;
			account.GenerateNewAccountNumber();
			account.OwnerName = e.Name;
			return account;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000DC7C File Offset: 0x0000CC7C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetCreditCardAccount(long entityID, BankAccount account)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.CreditCardAccounts.Add(account.AccountNumber, account);
			e.Journal.AddEntry(A.R.GetString("Got new credit card from {0}.", new object[]
			{
				account.BankName
			}));
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000DCDC File Offset: 0x0000CCDC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void CloseAccount(long entityID, BankAccount account)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.CloseAccount(account);
			e.Journal.AddEntry(A.R.GetString("Closed account: {0}.", new object[]
			{
				account.ToString()
			}));
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000DD2C File Offset: 0x0000CD2C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public BankAccount GetDirectDepositAccount(long entityID, long taskID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			foreach (object obj in e.GetAllTasks())
			{
				Task t = (Task)obj;
				if (t.ID == taskID && t is WorkTask)
				{
					return ((WorkTask)t).DirectDepositAccount;
				}
			}
			return null;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000DDD0 File Offset: 0x0000CDD0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetDirectDepositAccount(long entityID, long taskID, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			BankAccount account = null;
			if (accountNumber > -1L)
			{
				account = (BankAccount)e.BankAccounts[accountNumber];
			}
			foreach (object obj in e.GetAllTasks())
			{
				Task t = (Task)obj;
				if (t.ID == taskID && t is WorkTask)
				{
					((WorkTask)t).DirectDepositAccount = account;
				}
			}
			if (account != null)
			{
				e.Journal.AddEntry(A.R.GetString("Set up direct deposit to {0}.", new object[]
				{
					account.ToString()
				}));
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000DEC4 File Offset: 0x0000CEC4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmW4.Input GetAllowances(long entityID, long taskID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmW4.Input input = default(frmW4.Input);
			WorkTask t = (WorkTask)e.GetTaskByID(taskID);
			input.Allowances = t.Allowances;
			input.Additional = t.AdditionalWitholding;
			input.DisabledForCompetition = A.SS.DisableFW4;
			return input;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000DF24 File Offset: 0x0000CF24
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetAllowances(long entityID, long taskID, bool exempt, int allowances, float additional)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			WorkTask t = (WorkTask)e.GetTaskByID(taskID);
			t.ExemptFromWitholding = exempt;
			t.Allowances = allowances;
			t.AdditionalWitholding = additional;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000DF64 File Offset: 0x0000CF64
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void PayByCheck(long entityID, long accountNumber, Bill bill, Check check)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			CheckingAccount ca = (CheckingAccount)e.BankAccounts[accountNumber];
			ca.NextCheckNumber++;
			check.ApplyToAccount = bill.Account;
			e.Bills.Remove(bill.ID);
			ca.ChecksInTheMail.Add(check);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000DFD8 File Offset: 0x0000CFD8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetTransportation(long entityID, int index)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (index == 2 && e.Car == null)
			{
				throw new SimApplicationException(A.R.GetString("You do not own or lease a car. Please choose another form of transportation."));
			}
			e.SetModeOfTransportation(index);
			string[] s = new string[]
			{
				A.R.GetString("walking"),
				A.R.GetString("bus"),
				A.R.GetString("car")
			};
			e.Journal.AddEntry(A.R.GetString("Changed mode of transportation to {0}.", new object[]
			{
				s[index]
			}));
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000E094 File Offset: 0x0000D094
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetShop(long entityID, long buildingID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			AppBuilding b = A.ST.City.BuildingByID(buildingID);
			ArrayList items = (ArrayList)Utilities.DeepCopyBySerialization(A.ST.PurchasableItems);
			ArrayList temp = new ArrayList();
			for (int i = 0; i < items.Count; i++)
			{
				bool alreadyOwn = false;
				PurchasableItem p = (PurchasableItem)items[i];
				foreach (object obj in e.PurchasedItems)
				{
					PurchasableItem p2 = (PurchasableItem)obj;
					if (p2.Name == p.Name)
					{
						alreadyOwn = true;
					}
				}
				if (!alreadyOwn || A.SS.BreakInDate > DateTime.MinValue)
				{
					bool skip = false;
					if (A.SS.LevelManagementOn && !A.SS.OnlineBankingEnabledForOwner && p.Name == "Computer")
					{
						skip = true;
					}
					if (A.SS.LevelManagementOn && A.SS.HealthFactorsToConsider < 5 && p.Name == "DDR")
					{
						skip = true;
					}
					if (!skip)
					{
						p.Price *= b.Prices[i];
						p.saleDiscount = b.SaleDiscounts[i];
						temp.Add(p);
					}
				}
			}
			return temp;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000E26C File Offset: 0x0000D26C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetShopFood(long entityID)
		{
			ArrayList result;
			if (A.SS.HealthFactorsToConsider > 4)
			{
				result = new ArrayList(A.ST.PurchasableFood);
			}
			else
			{
				ArrayList temp = new ArrayList();
				for (int i = 0; i < 3; i++)
				{
					temp.Add(A.ST.PurchasableFood[i]);
				}
				result = temp;
			}
			return result;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000E2D4 File Offset: 0x0000D2D4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetShopBusTokens(long entityID)
		{
			return new ArrayList(A.ST.PurchasableBusTokens);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000E2F8 File Offset: 0x0000D2F8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetShopAutoRepair(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Car == null)
			{
				throw new SimApplicationException(A.R.GetString("In this sim, you can only buy gas or car repairs if you have a car. Purchase or lease a car first."));
			}
			return new ArrayList(A.ST.PurchasableAutoSupplies);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000E34C File Offset: 0x0000D34C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetCarShop(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Car != null)
			{
				throw new SimApplicationException(A.R.GetString("In this sim, you can only have one car at a time. If you would like a different car, please sell your current one, then buy another."));
			}
			return (ArrayList)A.ST.PurchasableCars.Clone();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000E3A0 File Offset: 0x0000D3A0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void PayByCard(long entityID, Bill bill, float amountToPay, long accountNumber, bool credit)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Transaction.TranType tranType;
			BankAccount account;
			if (credit)
			{
				tranType = Transaction.TranType.Credit;
				account = (CreditCardAccount)e.CreditCardAccounts[accountNumber];
				if (account.EndingBalance() + amountToPay > ((CreditCardAccount)account).CreditLimit)
				{
					throw new SimApplicationException(A.R.GetString("Credit card transaction rejected. That charge would exceed your credit limit."));
				}
				if (bill.Account != null && bill.Account.AccountNumber == accountNumber)
				{
					throw new SimApplicationException(A.R.GetString("Sorry. You cannot pay a credit card with the same credit card. Please choose another method of payment."));
				}
			}
			else
			{
				tranType = Transaction.TranType.Debit;
				account = (BankAccount)e.BankAccounts[accountNumber];
				if (account.EndingBalance() < bill.Amount)
				{
					throw new SimApplicationException(A.R.GetString("Debit card transaction rejected. You do not have enough money in the account."));
				}
			}
			account.Transactions.Add(new Transaction(bill.Amount, tranType, bill.From));
			long applyToAccountNumber = -1L;
			if (bill.Account != null)
			{
				applyToAccountNumber = bill.Account.AccountNumber;
			}
			e.ApplyPaymentToAccount(applyToAccountNumber, bill.Amount);
			e.Bills.Remove(bill.ID);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000E4FC File Offset: 0x0000D4FC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void PayByCash(long entityID, Bill bill, float amountToPay)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Cash < amountToPay)
			{
				throw new SimApplicationException(A.R.GetString("You do not have enough cash to pay by cash."));
			}
			if (bill.Account != null)
			{
				throw new SimApplicationException(A.R.GetString("You should not send cash in the mail. Please choose another method of payment."));
			}
			e.Cash -= amountToPay;
			e.Bills.Remove(bill.ID);
			long applyToAccountNumber = -1L;
			if (bill.Account != null)
			{
				applyToAccountNumber = bill.Account.AccountNumber;
			}
			e.ApplyPaymentToAccount(applyToAccountNumber, amountToPay);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000E5A8 File Offset: 0x0000D5A8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Purchase(long entityID, ArrayList shoppingList)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			string journalList = "";
			foreach (object obj in shoppingList)
			{
				string s = (string)obj;
				foreach (object obj2 in A.ST.PurchasableItems)
				{
					PurchasableItem p = (PurchasableItem)obj2;
					if (s == p.Name)
					{
						this.PurgeSimilarItem(p.Name, e.PurchasedItems);
						e.PurchasedItems.Add(p);
						journalList = journalList + p.FriendlyName + ", ";
					}
				}
				for (int i = 0; i < A.ST.PurchasableFood.Count; i++)
				{
					if (s == ((PurchasableItem)A.ST.PurchasableFood[i]).Name)
					{
						if (i < 3)
						{
							e.AddFood(14 * (i + 1));
						}
						else
						{
							e.PartyFood.Add(A.ST.PurchasableFood[i]);
						}
						journalList = journalList + ((PurchasableItem)A.ST.PurchasableFood[i]).FriendlyName + ", ";
					}
				}
				for (int i = 0; i < A.ST.PurchasableBusTokens.Count; i++)
				{
					if (s == ((PurchasableItem)A.ST.PurchasableBusTokens[i]).Name)
					{
						e.BusTokens += 20 + i * 40;
						journalList = journalList + ((PurchasableItem)A.ST.PurchasableBusTokens[i]).FriendlyName + ", ";
					}
				}
				if (e.Car != null)
				{
					for (int i = 0; i < A.ST.PurchasableAutoSupplies.Count; i++)
					{
						if (s == ((PurchasableItem)A.ST.PurchasableAutoSupplies[i]).Name)
						{
							if (i < 3)
							{
								e.Car.Gas += (float)((i + 1) * 10);
							}
							else if (i == 3)
							{
								e.Car.LastTuneup = A.ST.Now;
							}
							else
							{
								e.Car.Broken = false;
								e.Car.LastTuneup = A.ST.Now;
							}
							journalList = journalList + ((PurchasableItem)A.ST.PurchasableAutoSupplies[i]).FriendlyName + ", ";
						}
					}
				}
			}
			e.Journal.AddEntry(A.R.GetString("Purchased {0}.", new object[]
			{
				Utilities.FormatCommaSeries(journalList.ToLower())
			}));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000E964 File Offset: 0x0000D964
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string GetCarPrice(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Car == null)
			{
				throw new SimApplicationException(A.R.GetString("You cannot sell a car because you do not own one."));
			}
			string msg;
			if (e.Car.LeaseCost > 0f)
			{
				msg = A.R.GetString("Your car is leased, so you cannot sell it. If you would like to terminate your lease, you will be charged a penalty of 3 monthly payments. Do you want to terminate the lease?");
			}
			else
			{
				float carValue = e.Car.ComputeResalePrice(A.ST.Now);
				float loan = 0f;
				if (e.Car.Loan != null)
				{
					loan = e.Car.Loan.EndingBalance();
				}
				msg = A.R.GetString("Tommy Taranti will give you {0} for the car. You have a balance of {1} on your loan, ", new object[]
				{
					Utilities.FC(carValue, 2, A.I.CurrencyConversion),
					Utilities.FC(loan, 2, A.I.CurrencyConversion)
				});
				if (carValue - loan < 0f)
				{
					throw new SimApplicationException(A.R.GetString(msg + "so you would still owe {0} on the loan. You must payoff that much of the loan or more before you can sell the car.", new object[]
					{
						Utilities.FC(carValue - loan, 2, A.I.CurrencyConversion)
					}));
				}
				msg += A.R.GetString("so you'll receive a check for {0}. Proceed with the sale?", new object[]
				{
					Utilities.FC(carValue - loan, 2, A.I.CurrencyConversion)
				});
			}
			return msg;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000EAEC File Offset: 0x0000DAEC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SellCar(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Car != null)
			{
				if (e.Car.LeaseCost > 0f)
				{
					e.AddBill(new Bill("Taranti Auto Lease", "Lease termination penalty", e.Car.LeaseCost * 3f, (BankAccount)e.MerchantAccounts["Taranti Auto Lease"]));
				}
				else
				{
					float carValue = e.Car.ComputeResalePrice(A.ST.Now);
					float loan = 0f;
					if (e.Car.Loan != null)
					{
						loan = e.Car.Loan.EndingBalance();
					}
					e.AddCheck(new Check(-1L)
					{
						Amount = carValue - loan,
						Payee = e.Name,
						Date = A.ST.Now,
						Payor = "Taranti Auto & Loan",
						Number = (int)A.ST.GetNextID(),
						Memo = A.R.GetString("Sale of car"),
						Signature = A.R.GetString("Tommy T. Taranti")
					});
				}
				if (e.Car.Loan != null)
				{
					e.CloseAccount(e.Car.Loan);
				}
				A.ST.City.Cars.Remove(e.Car);
				e.Car = null;
				e.Journal.AddEntry(A.R.GetString("Got rid of car."));
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000EC9C File Offset: 0x0000DC9C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string GetCondoPrice(long entityID, Offering offering)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float price = (float)offering.Building.Rent * A.ST.RealEstateIndex;
			float commission = 0.05f * price;
			float loan = 0f;
			Mortgage i = e.GetMortgage(offering.Building);
			if (i != null)
			{
				loan = i.EndingBalance();
			}
			string msg = A.R.GetString("The highest offer for your condo was {0}. You will pay a real estate commission of {1} on the sale. You have a balance of {2} on your mortgage, ", new object[]
			{
				Utilities.FC(price, 2, A.I.CurrencyConversion),
				Utilities.FP(0.05f),
				Utilities.FC(loan, 2, A.I.CurrencyConversion)
			});
			if (price - commission - loan >= 0f)
			{
				return msg + A.R.GetString("so you'll receive a check for {0}. Proceed with the sale?", new object[]
				{
					Utilities.FC(price - commission - loan, 2, A.I.CurrencyConversion)
				});
			}
			throw new SimApplicationException(A.R.GetString(msg + "so you would still owe {0} on the loan. You must payoff that much of the loan or more before you can sell the condo.", new object[]
			{
				Utilities.FC(-(price - commission - loan), 2, A.I.CurrencyConversion)
			}));
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000EDE8 File Offset: 0x0000DDE8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SellCondo(long entityID, Offering offering)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float price = (float)offering.Building.Rent * A.ST.RealEstateIndex;
			float loan = 0f;
			Mortgage i = e.GetMortgage(offering.Building);
			if (i != null)
			{
				loan = i.EndingBalance();
			}
			float commission = price * 0.05f;
			e.AddCheck(new Check(-1L)
			{
				Amount = price - commission - loan,
				Payee = e.Name,
				Date = A.ST.Now,
				Payor = "Ward and June Cleaver",
				Number = (int)A.ST.GetNextID(),
				Memo = A.R.GetString("Sale of condo"),
				Signature = A.R.GetString("Ward Cleaver")
			});
			if (i != null)
			{
				e.CloseAccount(i);
			}
			ArrayList apts = A.ST.City.GetOfferings(typeof(DwellingOffer));
			foreach (object obj in apts)
			{
				DwellingOffer apt = (DwellingOffer)obj;
				if (apt.ID == offering.ID)
				{
					apt.Taken = false;
					apt.Building.Owner = null;
				}
			}
			e.Journal.AddEntry(A.R.GetString("Sold condo for {0}.", new object[]
			{
				Utilities.FC(price, A.I.CurrencyConversion)
			}));
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000EFBC File Offset: 0x0000DFBC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Mortgage[] GetMortgage(long entityID, Offering offering)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float rate = A.ST.PrimeRate() + 0.03f + (1f - e.CreditScoreNormalized()) * 0.08f;
			if (e.CreditScore() < 610)
			{
				rate = 0f;
			}
			float price = (float)offering.Building.Rent * A.ST.RealEstateIndex;
			Mortgage[] mortgages = new Mortgage[2];
			mortgages[0] = new Mortgage(A.ST.Now, price - 0f, rate, 360);
			mortgages[0].BankName = "Century Mortgage";
			mortgages[1] = new Mortgage(A.ST.Now, price - 0f, rate, 180);
			mortgages[1].BankName = "Century Mortgage";
			return mortgages;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000F094 File Offset: 0x0000E094
		[MethodImpl(MethodImplOptions.Synchronized)]
		public InstallmentLoan GetPayForCar(long entityID, float price)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float rate = A.ST.PrimeRate() + 0.03f + (1f - e.CreditScoreNormalized()) * 0.04f;
			if (e.CreditScore() < 510)
			{
				rate = 0f;
			}
			return new InstallmentLoan(A.ST.Now, price - 0.1f, rate, 36);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000F110 File Offset: 0x0000E110
		[MethodImpl(MethodImplOptions.Synchronized)]
		public InstallmentLoan GetStudentLoan(long entityID, Course course)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float rate = A.ST.PrimeRate() + 0.01f + (1f - e.CreditScoreNormalized()) * 0.049999997f;
			if (e.CreditScore() < 0)
			{
				rate = 0f;
			}
			InstallmentLoan loan = new InstallmentLoan(A.ST.Now, course.Cost, rate, 60);
			int daysPerWeek = 5;
			if (course.PrototypeTask.Weekend)
			{
				daysPerWeek = 2;
			}
			loan.BeginBilling = A.ST.Now.AddDays((double)(7 * (course.Days / daysPerWeek)));
			loan.BeginBilling = new DateTime(loan.BeginBilling.Year, loan.BeginBilling.Month, 1);
			loan.BankName = "Quest Student Loans";
			return loan;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000F1F0 File Offset: 0x0000E1F0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void PurchaseCar(long entityID, InstallmentLoan loan, string carName, long downPaymentAccountNumber, float downPayment)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			BankAccount account = (BankAccount)e.BankAccounts[downPaymentAccountNumber];
			if (account.EndingBalance() < downPayment)
			{
				throw new SimApplicationException("You don't have sufficient funds in that account to make the down payment. Please try again.");
			}
			int i = 0;
			foreach (object obj in A.ST.PurchasableCars)
			{
				PurchasableItem pc = (PurchasableItem)obj;
				if (pc.Name == carName)
				{
					e.Car = new Car
					{
						OriginalPrice = pc.Price,
						Purchased = A.ST.Now
					};
					account.Transactions.Add(new Transaction(downPayment, Transaction.TranType.Debit, "Car Downpayment"));
					loan.Transactions.Add(new Transaction(loan.OriginalBalance, Transaction.TranType.Credit, "Original Balance"));
					loan.BankName = "Taranti Auto Loan";
					loan.BeginBilling = A.ST.Now;
					e.Car.Loan = loan;
					break;
				}
				i++;
			}
			A.ST.City.Cars.Add(e.Car);
			e.Car.SetLocation(e.Dwelling);
			A.ST.Reserved.Add(e.Car, i);
			e.Journal.AddEntry(A.R.GetString("Bought a car for {0}.", new object[]
			{
				Utilities.FC(e.Car.OriginalPrice, A.I.CurrencyConversion)
			}));
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000F3E0 File Offset: 0x0000E3E0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LeaseCar(long entityID, float cost, string carName)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			int i = 0;
			foreach (object obj in A.ST.PurchasableCars)
			{
				PurchasableItem pc = (PurchasableItem)obj;
				if (pc.Name == carName)
				{
					e.Car = new Car
					{
						OriginalPrice = pc.Price,
						Purchased = A.ST.Now,
						LeaseCost = cost
					};
					break;
				}
				i++;
			}
			A.ST.City.Cars.Add(e.Car);
			e.Car.SetLocation(e.Dwelling);
			A.ST.Reserved.Add(e.Car, i);
			e.Journal.AddEntry(A.R.GetString("Leased a car for {0} per month.", new object[]
			{
				Utilities.FC(e.Car.LeaseCost, A.I.CurrencyConversion)
			}));
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000F534 File Offset: 0x0000E534
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int GetTransportation(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.ModeOfTransportation;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000F558 File Offset: 0x0000E558
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool HasEntity(string playerName)
		{
			return A.ST.GetPlayersEntities(playerName).Length > 0 || A.ST.GetPlayersRetiredEntities(playerName).Length > 0;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F590 File Offset: 0x0000E590
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetBills(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return (SortedList)Utilities.DeepCopyBySerialization(e.Bills);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000F5C0 File Offset: 0x0000E5C0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetChecks(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.Checks;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000F5E4 File Offset: 0x0000E5E4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void DepositCheck(long entityID, Check check, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			BankAccount account = (BankAccount)e.BankAccounts[accountNumber];
			account.Transactions.Add(new Transaction(check.Amount, Transaction.TranType.Credit, check.Memo));
			e.Checks.Remove(check.ID);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000F64C File Offset: 0x0000E64C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void CashCheck(long entityID, Check check, float fee)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Cash += check.Amount * (1f - fee);
			e.Checks.Remove(check.ID);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000F698 File Offset: 0x0000E698
		[MethodImpl(MethodImplOptions.Synchronized)]
		public float GetCash(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.Cash;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000F6BC File Offset: 0x0000E6BC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetDepositWithdrawCash(long entityID, bool withdraw, float amount, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			BankAccount account = (BankAccount)e.BankAccounts[accountNumber];
			if (withdraw)
			{
				if (account.EndingBalance() < amount)
				{
					throw new SimApplicationException("You do not have that much in the account. Please try again.");
				}
				e.Cash += amount;
				account.Transactions.Add(new Transaction(amount, Transaction.TranType.Debit, "Cash Withdrawal"));
			}
			else
			{
				if (e.Cash < amount)
				{
					throw new SimApplicationException("You do not have enough cash to make that deposit. Please try again.");
				}
				e.Cash -= amount;
				account.Transactions.Add(new Transaction(amount, Transaction.TranType.Credit, "Cash Deposit"));
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000F780 File Offset: 0x0000E780
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmPayStubs.Input GetTaxInfo(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmPayStubs.Input input = default(frmPayStubs.Input);
			input.PayStubs = new ArrayList();
			ArrayList temp = new ArrayList();
			foreach (object obj in e.WorkTaskHistory.Values)
			{
				WorkTask t = (WorkTask)obj;
				temp.AddRange(t.PayStubs);
			}
			foreach (object obj2 in temp)
			{
				PayStub p = (PayStub)obj2;
				int i = 0;
				while (i < input.PayStubs.Count && p.WeekEnding > ((PayStub)input.PayStubs[i]).WeekEnding)
				{
					i++;
				}
				input.PayStubs.Insert(i, p);
			}
			input.FW2s = new ArrayList(e.FW2s.Values);
			input.F1099s = new ArrayList(e.F1099s.Values);
			input.BeginYear = A.SS.StartDate.Year;
			input.EndYear = A.ST.Year;
			return input;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000F930 File Offset: 0x0000E930
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void InternetSubscribe(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Internet)
			{
				throw new SimApplicationException(A.R.GetString("You already have a subscription."));
			}
			e.Internet = true;
			if (!e.Reserved.ContainsKey("WantsInternet"))
			{
				e.Reserved.Add("WantsInternet", "");
			}
			e.Journal.AddEntry(A.R.GetString("Subscribed to Internet access."));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000F9B8 File Offset: 0x0000E9B8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void InternetUnSubscribe(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (!e.Internet)
			{
				throw new SimApplicationException(A.R.GetString("You are already unsubscribed."));
			}
			e.Internet = false;
			e.Reserved.Remove("WantsInternet");
			e.Journal.AddEntry(A.R.GetString("Dropped Internet access."));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000FA24 File Offset: 0x0000EA24
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetFunds()
		{
			return A.ST.MutualFunds;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000FA40 File Offset: 0x0000EA40
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetInvestmentAccounts(long entityID, bool retirement)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			SortedList result;
			if (retirement)
			{
				result = e.RetirementAccounts;
			}
			else
			{
				result = e.InvestmentAccounts;
			}
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000FA78 File Offset: 0x0000EA78
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string GetMovingMessage(long entityID, DwellingOffer offering)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			string result;
			if (e.Dwelling == null)
			{
				result = null;
			}
			else
			{
				string msg = "";
				if (!((DwellingOffer)e.Dwelling.Offerings[0]).Condo && e.Dwelling.MonthsLeftOnLease > 0)
				{
					msg += A.R.GetString("You have {0} months left on your lease and will be billed for all of them upon moving. ", new object[]
					{
						e.Dwelling.MonthsLeftOnLease
					});
				}
				msg += A.R.GetString("Are you sure you want to move?");
				result = msg;
			}
			return result;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000FB34 File Offset: 0x0000EB34
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void BuyFund(long entityID, string fundName, float amount, long accountNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float originalAmount = amount;
			if (accountNumber == -1L)
			{
				if (e.Cash < amount)
				{
					throw new SimApplicationException(A.R.GetString("You do not have enough cash to make this purchase."));
				}
				e.Cash -= amount;
			}
			else
			{
				BankAccount a = (BankAccount)e.BankAccounts[accountNumber];
				if (a.EndingBalance() < amount)
				{
					throw new SimApplicationException(A.R.GetString("You do not have enough money in the account to make this purchase."));
				}
				a.Transactions.Add(new Transaction(amount, Transaction.TranType.Debit, A.R.GetString("Share purchase")));
			}
			Fund fund = A.ST.GetFund(fundName);
			InvestmentAccount account = e.GetInvestmentAccount(fundName, false);
			if (account == null)
			{
				account = new InvestmentAccount(fund);
				account.BankName = A.R.GetString("Fiduciary Investments");
				e.InvestmentAccounts.Add(account.AccountNumber, account);
			}
			amount -= fund.FrontEndLoad * amount;
			account.Transactions.Add(new Transaction(amount / fund.Price, Transaction.TranType.Credit, A.R.GetString("Share Purchase"), A.ST.Now.AddDays(-1.0)));
			account.CostBasis += amount;
			e.Journal.AddEntry(A.R.GetString("Invested {0} in {1}.", new object[]
			{
				Utilities.FC(originalAmount, A.I.CurrencyConversion),
				fund.Name
			}));
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000FD00 File Offset: 0x0000ED00
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SellFund(long entityID, string fundName, float amount, long accountNumber, bool retirement)
		{
			if (amount != 0f)
			{
				AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
				InvestmentAccount account = e.GetInvestmentAccount(fundName, false);
				Fund fund = A.ST.GetFund(fundName);
				if (account == null)
				{
					throw new SimApplicationException("You haven't bought any shares of that fund yet.");
				}
				amount = Math.Min(amount, account.EndingBalance() * fund.Price);
				float shares = amount / fund.Price;
				if (shares == 0f)
				{
					throw new SimApplicationException("You don't own any shares of that fund yet.");
				}
				int shareAge = account.ShareAge();
				float load = 0f;
				if (shareAge < 1825)
				{
					load = fund.BackEndLoad * shares * fund.Price;
					if (load > 0f)
					{
						e.Player.SendMessage(A.R.GetString("You were charged a back end load or redemption fee of {0} for selling shares held less than {1} years.", new object[]
						{
							Utilities.FC(load, 2, A.I.CurrencyConversion),
							5
						}), "", NotificationColor.Yellow);
					}
				}
				float penalty = 0f;
				if (A.ST.Now < new DateTime(2051, 6, 30) && retirement)
				{
					penalty = 0.1f * amount;
				}
				if (accountNumber == -1L)
				{
					e.Cash += amount - load - penalty;
				}
				else
				{
					BankAccount a = (BankAccount)e.BankAccounts[accountNumber];
					a.Transactions.Add(new Transaction(amount - load - penalty, Transaction.TranType.Credit, A.R.GetString("Share redemption")));
				}
				float costPerShare = account.CostBasis / account.EndingBalance();
				float gain = amount - shares * costPerShare;
				account.CostBasis -= amount;
				int year = A.ST.Now.Year;
				Hashtable gains = e.STCapitalGains;
				if (shareAge > 364 && !account.Retirement)
				{
					gains = e.LTCapitalGains;
				}
				if (gains.ContainsKey(year))
				{
					gains[year] = (float)gains[year] + gain;
				}
				else
				{
					gains.Add(year, gain);
				}
				Transaction exactTrans = new Transaction(shares, Transaction.TranType.Debit, A.R.GetString("Share Redemption"));
				if (exactTrans.Amount > account.Value)
				{
					exactTrans.Amount = account.Value;
				}
				account.Transactions.Add(exactTrans);
				e.Journal.AddEntry(A.R.GetString("Sold {0} shares of {1}. Net proceeds were {2}.", new object[]
				{
					shares,
					fund.Name,
					Utilities.FC(amount - load - penalty, A.I.CurrencyConversion)
				}));
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00010028 File Offset: 0x0000F028
		public override void ProvideCash(long entityID, float amount)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Cash += amount;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00010050 File Offset: 0x0000F050
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmResume.Input GetResume(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return new frmResume.Input
			{
				Name = e.Name,
				AcademicTaskHistory = e.AcademicTaskHistory,
				WorkTaskHistory = e.WorkTaskHistory
			};
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000100A0 File Offset: 0x0000F0A0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frm401K.Input Get401K(long entityID, long taskID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frm401K.Input input = default(frm401K.Input);
			WorkTask t = (WorkTask)e.GetTaskByID(taskID);
			input.Allocations = t.R401KAllocations;
			input.CompanyMatch = t.R401KMatch;
			input.PercentWitheld = t.R401KPercentWitheld;
			return input;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000100FC File Offset: 0x0000F0FC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Set401K(long entityID, long taskID, float percentWitheld, float[] allocations)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			WorkTask t = (WorkTask)e.GetTaskByID(taskID);
			t.R401KAllocations = allocations;
			t.R401KPercentWitheld = percentWitheld;
			e.Journal.AddEntry(A.R.GetString("Changed 401K investment allocations."));
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00010150 File Offset: 0x0000F150
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetParty(long entityID, DateTime date, int startPeriod, int endPeriod)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Dance d = new Dance();
			d.OneTimeDay = date;
			DateTime temp = d.Key;
			d.StartPeriod = startPeriod;
			d.EndPeriod = endPeriod;
			d.Building = e.Dwelling;
			d.HostID = e.ID;
			A.ST.OneTimeEvents.Add(d.Key, d);
			e.OneTimeEvents.Add(d.Key, d);
			e.CheckValiditySynchTravel(e.ModeOfTransportation, e.GetDailyRoutine(), null, false);
			e.Journal.AddEntry(A.R.GetString("Decided to have a party from {0} to {1} on {2}.", new object[]
			{
				Task.ToTimeString(d.StartPeriod),
				Task.ToTimeString(d.EndPeriod),
				d.OneTimeDay.ToShortDateString()
			}));
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0001023C File Offset: 0x0000F23C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetAllOneTimeEvents(long entityID)
		{
			return A.ST.OneTimeEvents;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00010258 File Offset: 0x0000F258
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetOneTimeEventsInvitedTo(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			SortedList s = new SortedList();
			foreach (object obj in A.ST.OneTimeEvents.Values)
			{
				OneTimeEvent evnt = (OneTimeEvent)obj;
				if (evnt.rnd < e.PartyHostingScore() || evnt.Building == e.Dwelling)
				{
					s.Add(evnt.Key, evnt);
				}
			}
			return s;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0001031C File Offset: 0x0000F31C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetOneTimeEventsAttending(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.OneTimeEvents;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00010340 File Offset: 0x0000F340
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetOneTimeEvents(long entityID, ArrayList eventIDs)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.OneTimeEvents.Clear();
			foreach (object obj in eventIDs)
			{
				long id = (long)obj;
				OneTimeEvent evnt = (OneTimeEvent)A.ST.GetOneTimeEventByID(id);
				if (evnt != null)
				{
					evnt = (OneTimeEvent)Utilities.DeepCopyBySerialization(evnt);
					e.OneTimeEvents.Add(evnt.Key, evnt);
				}
			}
			e.CheckValiditySynchTravel(e.ModeOfTransportation, e.GetDailyRoutine(), null, false);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00010410 File Offset: 0x0000F410
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmCreditReport.Input GetCreditReport(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmCreditReport.Input input = default(frmCreditReport.Input);
			input.Name = e.Name;
			input.SSN = A.R.GetString("XXX-XX-{0}", new object[]
			{
				e.Person.ID.ToString().PadLeft(4, '0')
			});
			input.Accounts = new ArrayList(e.CreditCardAccounts.Values);
			ArrayList temp = new ArrayList();
			temp.AddRange(e.ClosedCreditCardAccounts.Values);
			temp.AddRange(this.GetInstallmentLoans(e.ID).Values);
			temp.AddRange(e.ClosedInstallmentLoans.Values);
			temp.AddRange(e.MerchantAccounts.Values);
			input.Now = A.ST.Now;
			foreach (object obj in temp)
			{
				BankAccount account = (BankAccount)obj;
				if (account.DateClosed > A.ST.Now.AddMonths(-36))
				{
					input.Accounts.Add(account);
				}
			}
			return input;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0001058C File Offset: 0x0000F58C
		protected void PurgeSimilarItem(string name, ArrayList purchasedItems)
		{
			ArrayList temp = new ArrayList(purchasedItems);
			foreach (object obj in temp)
			{
				PurchasableItem p = (PurchasableItem)obj;
				if (name.StartsWith(p.Name.Substring(0, p.Name.Length - 1)) && !name.StartsWith("Art"))
				{
					purchasedItems.Remove(p);
				}
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001062C File Offset: 0x0000F62C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetMortgage(long entityID, Mortgage loan, long offeringID, long accountNumber, float closingCosts)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (loan.Payment > 3f)
			{
				if ((double)(loan.Payment / Math.Max(1f, e.GrossIncomeLast12Months)) > 0.28)
				{
					throw new SimApplicationException("Your mortgage payment would be more than 28% of gross income. Your mortgage application has been rejected.");
				}
				if ((double)((loan.Payment + e.DebtService) / Math.Max(1f, e.GrossIncomeLast12Months)) > 0.36)
				{
					throw new SimApplicationException("Your mortgage payment plus other debt payments would be more than 36% of gross income. Your mortgage application has been rejected.");
				}
			}
			BankAccount account = (BankAccount)e.BankAccounts[accountNumber];
			if (account.EndingBalance() < closingCosts)
			{
				throw new SimApplicationException("You don't have sufficient funds in that account to cover the cash required at closing. Please try again.");
			}
			account.Transactions.Add(new Transaction(closingCosts, Transaction.TranType.Debit, "Condo Closing"));
			Offering o = A.ST.City.GetOffering(offeringID);
			o.Taken = true;
			o.Building.Owner = e;
			if (loan.OriginalBalance > 1f)
			{
				loan.Transactions.Add(new Transaction(loan.OriginalBalance, Transaction.TranType.Credit, "Original Balance"));
				loan.Building = o.Building;
				e.Mortgages.Add(loan.AccountNumber, loan);
			}
			e.Journal.AddEntry(o.JournalEntry());
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000107A8 File Offset: 0x0000F7A8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public DateTime Now()
		{
			return A.ST.Now;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000107C4 File Offset: 0x0000F7C4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public long AddEntity(string playerName, string entityName, Person.GenderType gender, int paletteIndex)
		{
			AppEntity e = (AppEntity)base.TryAddEntity(playerName, entityName);
			e.Person = new VBPFPerson(gender, Person.RaceType.Hispanic, "", entityName);
			e.Person.PaletteIndex = paletteIndex;
			A.I.Subscribe(e);
			return e.ID;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00010816 File Offset: 0x0000F816
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void DeleteOffering(long ID)
		{
			A.ST.City.DeleteOffering(ID);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0001082C File Offset: 0x0000F82C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool UseAccountant()
		{
			return (A.SS.LevelManagementOn && A.SS.Level > 1) || (!A.SS.LevelManagementOn && A.SS.ViewPortfolioEnabledForOwner) || A.SS.AlwaysUseTaxAccountant;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0001087C File Offset: 0x0000F87C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public TaxReturn GetNewAccountantsReport(long entityID, int year)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			AccountantsReport ar = new AccountantsReport(year);
			ar.PrepareTaxes(year, e, true);
			return ar;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000108AC File Offset: 0x0000F8AC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public override frmScoreboard.Input getScoreboard(bool showAIOwnedEntities)
		{
			frmScoreboard.Input input = base.getScoreboard(showAIOwnedEntities);
			input.ScoreFriendlyName = A.R.GetString("Net Worth");
			ArrayList names = new ArrayList(input.EntityNames);
			ArrayList scores = new ArrayList(input.Scores);
			foreach (object obj in A.ST.RetiredEntity.Values)
			{
				Entity e = (Entity)obj;
				int i = names.IndexOf(e.Name);
				if (i > -1)
				{
					names.RemoveAt(i);
					scores.RemoveAt(i);
				}
			}
			input.EntityNames = (string[])names.ToArray(typeof(string));
			input.Scores = (ArrayList[])scores.ToArray(typeof(ArrayList));
			return input;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000109C8 File Offset: 0x0000F9C8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Bill CreateBill(string from, string description, float amount, BankAccount account)
		{
			return new Bill(from, description, amount, account);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000109E4 File Offset: 0x0000F9E4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public float GetPrimeRate()
		{
			return A.ST.PrimeRate();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00010A00 File Offset: 0x0000FA00
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Hashtable GetNamesAndIds()
		{
			Hashtable h = new Hashtable();
			foreach (object obj in A.ST.Entity.Values)
			{
				Entity e = (Entity)obj;
				h.Add(e.Name, e.ID);
			}
			return h;
		}
	}
}
