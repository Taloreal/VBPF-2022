using System;
using System.Drawing;
using System.Drawing.Imaging;
using KMI.Sim.Drawables;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for PaletteDrawable.
	/// </summary>
	/// Improve: move to engine
	// Token: 0x02000064 RID: 100
	[Serializable]
	public class PaletteDrawable : FlexDrawable
	{
		// Token: 0x0600028F RID: 655 RVA: 0x000294B5 File Offset: 0x000284B5
		public PaletteDrawable(PointF location, string imageName, string clickString, int palIndex) : base(location, imageName, clickString)
		{
			this.paletteIndex = palIndex;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000294CC File Offset: 0x000284CC
		public override void Draw(Graphics g)
		{
			Bitmap image = A.R.GetImage(this.imageName);
			image.Palette = A.R.GetImage("Palette" + this.paletteIndex).Palette;
			switch (this.verticalAlignment)
			{
			case FlexDrawable.VerticalAlignments.Top:
				this.offsetY = 0;
				break;
			case FlexDrawable.VerticalAlignments.Middle:
				this.offsetY = -image.Height / 2;
				break;
			case FlexDrawable.VerticalAlignments.Bottom:
				this.offsetY = -image.Height;
				break;
			}
			switch (this.horizontalAlignment)
			{
			case FlexDrawable.HorizontalAlignments.Left:
				this.offsetX = 0;
				break;
			case FlexDrawable.HorizontalAlignments.Center:
				this.offsetX = -image.Width / 2;
				break;
			case FlexDrawable.HorizontalAlignments.Right:
				this.offsetX = -image.Width;
				break;
			}
			if (this.flip)
			{
				g.DrawImage(image, this.location.X + this.offsetX + image.Width, this.location.Y + this.offsetY, -image.Width, image.Height);
			}
			else
			{
				g.DrawImage(image, this.location.X + this.offsetX, this.location.Y + this.offsetY, image.Width, image.Height);
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00029628 File Offset: 0x00028628
		public static void Ramp(ColorPalette pal, int start, int end, Color light, Color dark)
		{
			for (int i = start; i <= end; i++)
			{
				float pct = (float)(i - start) / (float)(end - start);
				int red = (int)((float)(dark.R - light.R) * pct + (float)light.R);
				int green = (int)((float)(dark.G - light.G) * pct + (float)light.G);
				int blue = (int)((float)(dark.B - light.B) * pct + (float)light.B);
				pal.Entries[i] = Color.FromArgb(red, green, blue);
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000296D0 File Offset: 0x000286D0
		public static void Ramp(ColorPalette pal, int start, int end, Color light, float darkPct)
		{
			Color dark = Color.FromArgb((int)((float)light.R * darkPct), (int)((float)(light.G / 3) * darkPct), (int)((float)(light.B / 3) * darkPct));
			PaletteDrawable.Ramp(pal, start, end, light, dark);
		}

		// Token: 0x04000301 RID: 769
		private int paletteIndex;
	}
}
