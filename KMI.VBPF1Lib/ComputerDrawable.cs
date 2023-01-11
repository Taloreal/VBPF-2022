using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for MailDrawable.
	/// </summary>
	// Token: 0x0200002B RID: 43
	[Serializable]
	public class ComputerDrawable : Drawable
	{
		// Token: 0x06000142 RID: 322 RVA: 0x0001301A File Offset: 0x0001201A
		public ComputerDrawable(Point location, string image, string clickString) : base(location, image, clickString)
		{
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00013028 File Offset: 0x00012028
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (!A.MF.Disabled(A.MF.mnuActionsMMOnlineBanking))
			{
				try
				{
					frmOnlineBanking f = new frmOnlineBanking();
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
