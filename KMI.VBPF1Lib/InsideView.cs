using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// An example View for an application.
	/// </summary>
	// Token: 0x020000B3 RID: 179
	public class InsideView : View
	{
		/// <summary>
		/// Contructs a new instance of this View with the given name
		/// and background image.
		/// </summary>
		/// <param name="name">The name for this View as it is to
		/// appear in the application.</param>
		/// <param name="background">The background image to use
		/// for this View in the application.</param>
		// Token: 0x06000553 RID: 1363 RVA: 0x0004E3B1 File Offset: 0x0004D3B1
		public InsideView(string name, Bitmap background) : base(name, background)
		{
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0004E3C0 File Offset: 0x0004D3C0
		public override Drawable[] BuildDrawables(long entityID, params object[] args)
		{
			ArrayList d = new ArrayList();
			AppBuilding currentBuilding = (AppBuilding)A.ST.City[(int)args[0], (int)args[1], (int)args[2]];
			string back = currentBuilding.GetBackgroundImage();
			this.background = A.R.GetImage(back);
			d.AddRange(currentBuilding.GetInsideDrawables());
			d.Add(new CityNavDrawable(new Point(10, 50), "CityNavIcon", " "));
			return (Drawable[])d.ToArray(typeof(Drawable));
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0004E460 File Offset: 0x0004D460
		public void SetBackground(int index)
		{
			switch (index)
			{
			case 1:
				this.background = A.R.GetImage("HomeBack");
				break;
			case 2:
				this.background = A.R.GetImage("WorkBack");
				break;
			case 3:
				this.background = A.R.GetImage("OfficeBack");
				break;
			case 5:
				this.background = A.R.GetImage("ClassBack");
				break;
			}
		}
	}
}
