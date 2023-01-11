using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for CityNavDrawable.
	/// </summary>
	// Token: 0x02000052 RID: 82
	[Serializable]
	public class CityNavDrawable : AlphaDrawable
	{
		// Token: 0x06000239 RID: 569 RVA: 0x00024FF4 File Offset: 0x00023FF4
		public CityNavDrawable(Point location, string imageName, string clickString) : base(location, imageName, clickString, 70)
		{
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00025004 File Offset: 0x00024004
		public override void Drawable_Click(object sender, EventArgs e)
		{
			A.MF.OnViewChange(A.I.Views[0].Name);
		}
	}
}
