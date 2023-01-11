using System;
using System.Collections;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCreditCardStatement.
	/// </summary>
	// Token: 0x02000031 RID: 49
	public partial class frmLoanStatement : frmBankStatement
	{
		// Token: 0x06000190 RID: 400 RVA: 0x0001A2B5 File Offset: 0x000192B5
		public frmLoanStatement()
		{
			this.Text = A.R.GetString("Loan Statements");
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0001A2D8 File Offset: 0x000192D8
		protected override SortedList GetAccounts()
		{
			return A.SA.GetInstallmentLoans(A.MF.CurrentEntityID);
		}
	}
}
