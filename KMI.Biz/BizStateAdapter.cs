using System;
using System.Runtime.CompilerServices;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000005 RID: 5
	public class BizStateAdapter : SimStateAdapter
	{
		// Token: 0x06000017 RID: 23 RVA: 0x000033F4 File Offset: 0x000023F4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmVitalSigns.Input getVitalSigns(long entityID)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			frmVitalSigns.Input result = default(frmVitalSigns.Input);
			float num = 0f;
			int num2 = 0;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity2 = (Entity)obj;
				if (entity2.Player == entity.Player)
				{
					num += entity2.Journal.NumericDataSeriesLastEntry("Cumulative Profit");
					num2++;
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity2 = (Entity)obj2;
				if (entity2.Player == entity.Player)
				{
					num += entity2.Journal.NumericDataSeriesLastEntry("Cumulative Profit");
					num2++;
				}
			}
			result.CumProfit = num;
			result.MultipleEntities = (num2 > 1);
			int num3 = Math.Min(S.ST.CurrentWeek, 8);
			result.Profit = new float[num3];
			result.Sales = new float[num3];
			result.Customers = new int[num3];
			int num4 = 0;
			for (int i = S.ST.CurrentWeek - num3; i < S.ST.CurrentWeek; i++)
			{
				result.Profit[num4] = entity.GL.AccountBalance("Profit", i);
				result.Sales[num4] = entity.GL.AccountBalance("Revenue", i);
				result.Customers[num4] = (int)entity.GL.AccountBalance("Customers", i);
				num4++;
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003628 File Offset: 0x00002628
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual frmTransferCash.Input getTransferCash(string playerName)
		{
			base.LogMethodCall(new object[]
			{
				playerName
			});
			frmTransferCash.Input result = default(frmTransferCash.Input);
			Entity[] playersEntities = S.ST.GetPlayersEntities(playerName);
			result.OwnedEntities = new string[playersEntities.Length];
			result.CashBalances = new float[playersEntities.Length];
			for (int i = 0; i < playersEntities.Length; i++)
			{
				result.OwnedEntities[i] = playersEntities[i].Name;
				result.CashBalances[i] = playersEntities[i].GL.AccountBalance("Cash");
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000036C8 File Offset: 0x000026C8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void setTransferCash(long fromEntityID, long toEntityID, float amount)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(fromEntityID);
			Entity entity2 = SimStateAdapter.CheckEntityExists(toEntityID);
			if (amount > entity.GL.AccountBalance("Cash"))
			{
				throw new SimApplicationException(S.R.GetString("The amount you are trying to transfer is greater than the cash now at the store you are transferring from.  The cash balance of that store is {0}. Try transferring much less or that store will run out of cash.", new object[]
				{
					Utilities.FC(entity.GL.AccountBalance("Cash"), S.I.CurrencyConversion)
				}));
			}
			entity.GL.Post("Cash", -amount, "Paid-in Capital");
			entity2.GL.Post("Cash", amount, "Paid-in Capital");
			entity.Journal.AddEntry(string.Concat(new string[]
			{
				"Transferred ",
				Utilities.FC(amount, S.I.CurrencyConversion),
				" from ",
				entity.Name,
				" to ",
				entity2.Name,
				"."
			}));
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000037D8 File Offset: 0x000027D8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void TransferCashFrom(string fromEntity, float amount)
		{
			Entity entityByName = S.ST.GetEntityByName(fromEntity);
			if (entityByName == null)
			{
				throw new SimApplicationException(S.R.GetString("Can't transfer cash from {0}.", new object[]
				{
					fromEntity
				}));
			}
			entityByName.GL.Post("Cash", -amount, "Paid-in Capital");
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003838 File Offset: 0x00002838
		[MethodImpl(MethodImplOptions.Synchronized)]
		public object[,] GetMarketShare()
		{
			base.LogMethodCall(new object[0]);
			SimState st = S.ST;
			object[,] result;
			if (S.ST.Entity.Count == 0)
			{
				result = null;
			}
			else
			{
				int num = Math.Max(0, st.CurrentWeek - GeneralLedger.WeeksOfFinancialHistory);
				float[] array = new float[st.CurrentWeek - num];
				object[,] array2 = new object[st.Entity.Count + 1, st.CurrentWeek - num + 1];
				foreach (object obj in st.Entity.Values)
				{
					Entity entity = (Entity)obj;
					for (int i = num; i < st.CurrentWeek; i++)
					{
						array[i - num] += entity.GL.AccountBalance("Revenue", i);
					}
				}
				int num2 = 0;
				foreach (object obj2 in st.Entity.Values)
				{
					Entity entity = (Entity)obj2;
					num2++;
					for (int i = num; i < st.CurrentWeek; i++)
					{
						if (array[i - num] != 0f)
						{
							array2[num2, i - num + 1] = entity.GL.AccountBalance("Revenue", i) / array[i - num];
						}
						else
						{
							array2[num2, i - num + 1] = 0f;
						}
						array2[0, i - num + 1] = entity.GL.EndingDateOfPeriod(i, GeneralLedger.Frequency.Weekly);
					}
					array2[num2, 0] = entity.Name + " - " + Utilities.FP((float)array2[num2, array2.GetUpperBound(1)]);
				}
				result = array2;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003AA4 File Offset: 0x00002AA4
		public virtual CommentLog GetComments(long entityID)
		{
			throw new NotImplementedException("GetComments not overriden in BizStateAdapter Subclass.");
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003AB1 File Offset: 0x00002AB1
		public virtual ConsultantReport GetConsultantReport(long entityID)
		{
			throw new NotImplementedException("GetConsultantReport not overriden in BizStateAdapter Subclass.");
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003ABE File Offset: 0x00002ABE
		public virtual ConsultantReport[] GetGrades(long entityID)
		{
			throw new NotImplementedException("GetGrades not overriden in BizStateAdapter Subclass.");
		}
	}
}
