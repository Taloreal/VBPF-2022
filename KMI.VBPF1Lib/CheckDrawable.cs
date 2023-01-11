using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for MailDrawable.
	/// </summary>
	// Token: 0x0200005C RID: 92
	[Serializable]
	public class CheckDrawable : Drawable
	{
		// Token: 0x0600027A RID: 634 RVA: 0x00028E0C File Offset: 0x00027E0C
		public CheckDrawable(Point location, string image, string clickString) : base(location, image, clickString)
		{
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00028E1C File Offset: 0x00027E1C
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (!A.MF.Disabled(A.MF.mnuActionsMMBanking))
			{
				try
				{
					frmDepositChecks f = new frmDepositChecks();
					f.ShowDialog(A.MF);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}
	}
}
