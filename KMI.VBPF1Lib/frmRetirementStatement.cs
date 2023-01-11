using System;
using System.Collections;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmInvestmentStatements.
	/// </summary>
	// Token: 0x02000099 RID: 153
	public partial class frmRetirementStatement : frmBankStatement
	{
		// Token: 0x060004C0 RID: 1216 RVA: 0x00043C58 File Offset: 0x00042C58
		public frmRetirementStatement()
		{
			this.Text = A.R.GetString("Retirement Statements");
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00043C7C File Offset: 0x00042C7C
		protected override SortedList GetAccounts()
		{
			return A.SA.GetInvestmentAccounts(A.MF.CurrentEntityID, true);
		}
	}
}
