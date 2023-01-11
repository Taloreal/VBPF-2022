using System;
using System.Collections;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for CheckingAccount.
	/// </summary>
	// Token: 0x0200009D RID: 157
	[Serializable]
	public class CheckingAccount : BankAccount
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x00045070 File Offset: 0x00044070
		public CheckingAccount(float maintenanceFee, float minimumBalance)
		{
			this.maintenanceFee = maintenanceFee;
			this.minimumBalance = minimumBalance;
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x000450C8 File Offset: 0x000440C8
		public override string AccountTypeFriendlyName
		{
			get
			{
				return A.R.GetString("Checking");
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x000450EC File Offset: 0x000440EC
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00045104 File Offset: 0x00044104
		public int NextCheckNumber
		{
			get
			{
				return this.nextCheckNumber;
			}
			set
			{
				this.nextCheckNumber = value;
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00045110 File Offset: 0x00044110
		public override string Description()
		{
			return A.R.GetString("Checking account offering free checking. Monthly fee of {0} waived if minimum daily balance greater than {1}.", new object[]
			{
				Utilities.FC(this.maintenanceFee, A.I.CurrencyConversion),
				Utilities.FC(this.minimumBalance, A.I.CurrencyConversion)
			});
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0004516C File Offset: 0x0004416C
		public ArrayList BuildRegisterFromTransactions()
		{
			ArrayList list = new ArrayList();
			ArrayList trans = new ArrayList(this.Transactions);
			foreach (object obj in this.ChecksInTheMail)
			{
				Check c = (Check)obj;
				int i = 0;
				while (i < trans.Count && c.Date > ((Transaction)trans[i]).Date)
				{
					i++;
				}
				trans.Insert(i, new Transaction(c.Amount, Transaction.TranType.Debit, A.R.GetString("Check # {0} to {1}", new object[]
				{
					c.Number,
					c.Payee
				})));
			}
			int count = Math.Min(trans.Count, 40);
			float bal = 0f;
			if (trans.Count > 40)
			{
				bal = base.BalanceThru((Transaction)trans[trans.Count - 41]);
			}
			for (int j = trans.Count - count; j < trans.Count; j++)
			{
				Transaction t = (Transaction)trans[j];
				CheckRegisterEntry r = new CheckRegisterEntry("", t.Date.ToString("M/d/yy"), t.Description, "", "", "", "", "");
				float amount;
				if (t.Type == Transaction.TranType.Debit)
				{
					r.Payment = t.Amount.ToString("N2");
					r.Balance1 = "-" + r.Payment;
					amount = -t.Amount;
				}
				else
				{
					r.Deposit = t.Amount.ToString("N2");
					r.Balance1 = "+" + r.Deposit;
					amount = t.Amount;
				}
				if (j > 0 || trans.Count <= 40)
				{
					bal += amount;
				}
				r.Balance2 = bal.ToString("N2");
				if (t.Description.StartsWith("Check #"))
				{
					r.Number = t.Description.Split(new char[]
					{
						' '
					})[2];
					r.Description1 = t.Description.Substring(t.Description.IndexOf(" to ") + 4);
				}
				list.Add(r);
			}
			return list;
		}

		// Token: 0x040005BC RID: 1468
		public ArrayList RegisterEntries = new ArrayList();

		// Token: 0x040005BD RID: 1469
		public ArrayList Checks = new ArrayList();

		// Token: 0x040005BE RID: 1470
		protected int nextCheckNumber = 100;

		// Token: 0x040005BF RID: 1471
		public ArrayList RecurringPayments = new ArrayList();

		// Token: 0x040005C0 RID: 1472
		public ArrayList ChecksInTheMail = new ArrayList();
	}
}
