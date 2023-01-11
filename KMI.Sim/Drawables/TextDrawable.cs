using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x0200002A RID: 42
	[Serializable]
	public class TextDrawable : Drawable
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x0000E820 File Offset: 0x0000D820
		public TextDrawable(Point location, string text, string fontName, int fontSize, Color color, float skewFactor, string clickString) : base(location, null, clickString)
		{
			this.text = text;
			this.fontName = fontName;
			this.fontSize = fontSize;
			this.color = color;
			this.skewFactor = skewFactor;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000E870 File Offset: 0x0000D870
		public TextDrawable(Point location, string text, string fontName, int fontSize, Color color, float skewFactor) : base(location, null)
		{
			this.text = text;
			this.fontName = fontName;
			this.fontSize = fontSize;
			this.color = color;
			this.skewFactor = skewFactor;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000E8BC File Offset: 0x0000D8BC
		public TextDrawable(Point location, string text, string fontName, int fontSize, Color color, string clickString) : base(location, null, clickString)
		{
			this.text = text;
			this.fontName = fontName;
			this.fontSize = fontSize;
			this.color = color;
			this.skewFactor = 0f;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000E910 File Offset: 0x0000D910
		public TextDrawable(Point location, string text, string fontName, int fontSize, Color color) : base(location, null)
		{
			this.text = text;
			this.fontName = fontName;
			this.fontSize = fontSize;
			this.color = color;
			this.skewFactor = 0f;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000E960 File Offset: 0x0000D960
		public override void Draw(Graphics g)
		{
			SolidBrush brush = new SolidBrush(this.color);
			Font font = new Font(this.fontName, (float)this.fontSize);
			StringFormat stringFormat = new StringFormat();
			if (this.center)
			{
				stringFormat.Alignment = StringAlignment.Center;
			}
			SmoothingMode smoothingMode = g.SmoothingMode;
			g.SmoothingMode = this.smoothingMode;
			if (this.text != null && !(this.text == ""))
			{
				this.size = g.MeasureString(this.text, font);
				Rectangle rect = new Rectangle(this.location.X, this.location.Y, (int)this.size.Width, (int)this.size.Height);
				Matrix transform = new Matrix(rect, new Point[]
				{
					new Point(this.location.X, this.location.Y),
					new Point(this.location.X + (int)this.size.Width, this.location.Y - (int)(this.size.Width * this.skewFactor)),
					new Point(this.location.X, this.location.Y + (int)this.size.Height)
				});
				Matrix transform2 = g.Transform;
				g.Transform = transform;
				g.DrawString(this.text, font, brush, this.location, stringFormat);
				g.Transform = transform2;
				g.SmoothingMode = smoothingMode;
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000EB28 File Offset: 0x0000DB28
		public override bool HitTest(int x, int y)
		{
			return this.hittable && x >= this.location.X && (float)x <= (float)this.location.X + this.size.Width && (float)y >= (float)this.location.Y - (float)(x - this.location.X) * this.skewFactor && (float)y <= (float)this.location.Y + this.size.Height - (float)(x - this.location.X) * this.skewFactor;
		}

		// Token: 0x17000078 RID: 120
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000EBF2 File Offset: 0x0000DBF2
		public SmoothingMode SmoothingMode
		{
			set
			{
				this.smoothingMode = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000EBFC File Offset: 0x0000DBFC
		protected override Size Size
		{
			get
			{
				return Size.Round(this.size);
			}
		}

		// Token: 0x1700007A RID: 122
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x0000EC19 File Offset: 0x0000DC19
		public bool Center
		{
			set
			{
				this.center = value;
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000EC24 File Offset: 0x0000DC24
		public override void Drawable_Click(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.location.X + this.Size.Width / 2, this.location.Y - (int)((float)(this.Size.Width / 2) / this.skewFactor));
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x04000116 RID: 278
		protected string text;

		// Token: 0x04000117 RID: 279
		protected string fontName;

		// Token: 0x04000118 RID: 280
		protected int fontSize;

		// Token: 0x04000119 RID: 281
		protected Color color;

		// Token: 0x0400011A RID: 282
		protected float skewFactor;

		// Token: 0x0400011B RID: 283
		protected SizeF size;

		// Token: 0x0400011C RID: 284
		protected SmoothingMode smoothingMode = SmoothingMode.AntiAlias;

		// Token: 0x0400011D RID: 285
		protected bool center = false;
	}
}
