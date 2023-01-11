using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for MailDrawable.
	/// </summary>
	// Token: 0x020000AC RID: 172
	[Serializable]
	public class BillDrawable : Drawable
	{
		// Token: 0x0600051B RID: 1307 RVA: 0x00049F46 File Offset: 0x00048F46
		public BillDrawable(Point location, string image, string clickString) : base(location, image, clickString)
		{
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00049F54 File Offset: 0x00048F54
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (!A.MF.Disabled(A.MF.mnuActionsMMBills))
			{
				A.MF.mnuActionsMMBills.PerformClick();
			}
		}
	}
}
