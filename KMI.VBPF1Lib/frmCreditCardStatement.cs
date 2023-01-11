using System;
using System.Collections;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCreditCardStatement.
	/// </summary>
	// Token: 0x02000070 RID: 112
	public partial class frmCreditCardStatement : frmBankStatement
	{
		// Token: 0x060002F1 RID: 753 RVA: 0x00032E69 File Offset: 0x00031E69
		public frmCreditCardStatement()
		{
			this.Text = A.R.GetString("Credit Card Statements");
			this.picStatement.Width = 337;
			this.TransactionsPerPage = 24;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00032EA4 File Offset: 0x00031EA4
		protected override SortedList GetAccounts()
		{
			return A.SA.GetCreditCardAccounts(A.MF.CurrentEntityID);
		}
	}
}
