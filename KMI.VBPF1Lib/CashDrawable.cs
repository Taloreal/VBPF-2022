using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for MailDrawable.
	/// </summary>
	// Token: 0x02000036 RID: 54
	[Serializable]
	public class CashDrawable : Drawable
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x0001B0C8 File Offset: 0x0001A0C8
		public CashDrawable(Point location, string image, string clickString, float cash) : base(location, image, clickString)
		{
			this.cash = cash;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0001B0E0 File Offset: 0x0001A0E0
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (!A.MF.Disabled(A.MF.mnuActionsMMBanking))
			{
				try
				{
					new frmDepositWithdrawCash(null, false)
					{
						updAmount = 
						{
							Maximum = (decimal)this.cash
						}
					}.ShowDialog(A.MF);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x040001C1 RID: 449
		protected float cash;
	}
}
