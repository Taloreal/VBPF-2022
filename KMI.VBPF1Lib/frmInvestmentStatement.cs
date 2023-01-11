using System;
using System.Collections;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmInvestmentStatements.
	/// </summary>
	// Token: 0x02000086 RID: 134
	public partial class frmInvestmentStatement : frmBankStatement
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x0003A565 File Offset: 0x00039565
		public frmInvestmentStatement()
		{
			this.Text = A.R.GetString("Investment Statements");
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0003A588 File Offset: 0x00039588
		protected override SortedList GetAccounts()
		{
			return A.SA.GetInvestmentAccounts(A.MF.CurrentEntityID, false);
		}
	}
}
