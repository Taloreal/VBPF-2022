using System;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000055 RID: 85
	[Serializable]
	public class CommentDrawable : Drawable
	{
		// Token: 0x0600031D RID: 797 RVA: 0x000187EB File Offset: 0x000177EB
		public CommentDrawable(Point location, string comment) : base(location, null)
		{
			this.comment = comment;
			base.Hittable = false;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00018807 File Offset: 0x00017807
		public override void Draw(Graphics g)
		{
			Utilities.DrawComment(g, this.comment, this.location, S.MF.MainWindowBounds);
		}

		// Token: 0x040001F1 RID: 497
		protected string comment;
	}
}
