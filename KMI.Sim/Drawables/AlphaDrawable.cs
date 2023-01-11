using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace KMI.Sim.Drawables
{
	// Token: 0x0200002B RID: 43
	[Serializable]
	public class AlphaDrawable : Drawable
	{
		// Token: 0x060001CA RID: 458 RVA: 0x0000ECCE File Offset: 0x0000DCCE
		public AlphaDrawable(Point location, string imageName, string clickString, int alpha) : base(location, imageName, clickString)
		{
			this.alpha = (float)alpha / 100f;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000ECEB File Offset: 0x0000DCEB
		public AlphaDrawable(Point location, string imageName, int alpha) : base(location, imageName)
		{
			this.alpha = (float)alpha / 100f;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000ED06 File Offset: 0x0000DD06
		public AlphaDrawable(Point location, string imageName, string clickString, float alpha) : base(location, imageName, clickString)
		{
			this.alpha = alpha;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000ED1C File Offset: 0x0000DD1C
		public AlphaDrawable(Point location, string imageName, float alpha) : base(location, imageName)
		{
			this.alpha = alpha;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000ED30 File Offset: 0x0000DD30
		public override void Draw(Graphics g)
		{
			Bitmap image = S.R.GetImage(this.imageName);
			float[][] array = new float[5][];
			float[][] array2 = array;
			int num = 0;
			float[] array3 = new float[5];
			array3[0] = 1f;
			array2[num] = array3;
			float[][] array4 = array;
			int num2 = 1;
			array3 = new float[5];
			array3[1] = 1f;
			array4[num2] = array3;
			float[][] array5 = array;
			int num3 = 2;
			array3 = new float[5];
			array3[2] = 1f;
			array5[num3] = array3;
			float[][] array6 = array;
			int num4 = 3;
			array3 = new float[5];
			array3[3] = this.alpha;
			array6[num4] = array3;
			array[4] = new float[]
			{
				0f,
				0f,
				0f,
				0f,
				1f
			};
			float[][] newColorMatrix = array;
			ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			g.DrawImage(image, new Rectangle(this.location.X, this.location.Y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
		}

		// Token: 0x0400011E RID: 286
		protected float alpha;
	}
}
