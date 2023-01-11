using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for MailDrawable.
	/// </summary>
	// Token: 0x02000074 RID: 116
	[Serializable]
	public class RefrigeratorDrawable : Drawable
	{
		// Token: 0x06000300 RID: 768 RVA: 0x000336F0 File Offset: 0x000326F0
		public RefrigeratorDrawable(Point location, string image) : base(location, image)
		{
			this.clickString = " ";
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00033708 File Offset: 0x00032708
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (!A.MF.Disabled(A.MF.mnuActionsCreditShopForFood))
			{
				A.MF.mnuActionsCreditShopForFood.PerformClick();
			}
		}
	}
}
