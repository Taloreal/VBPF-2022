using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x02000012 RID: 18
	public class KMIGraph : UserControl
	{
		// Token: 0x060000AA RID: 170 RVA: 0x00006EA4 File Offset: 0x00005EA4
		public KMIGraph()
		{
			this.InitializeComponent();
			this.SetDefaultFonts();
			this.componentPictureBox.Location = new Point(0, 0);
			this.componentPictureBox.Size = base.Size;
			this.nGraphType = 1;
			this.nLineWidth = 4;
			this.bLegend = true;
			this.bDataPointLabels = true;
			this.printerMargin = 100;
			this.autoScaleY = true;
			this.xAxisLabels = true;
			this.bShowXTicks = true;
			this.bShowYTicks = true;
			this.SF = new StringFormat();
			this.SFC = new StringFormat();
			this.SFC.Alignment = StringAlignment.Center;
			this.SFVC = new StringFormat(StringFormatFlags.DirectionVertical);
			this.SFVC.Alignment = StringAlignment.Center;
			this.SFVL = new StringFormat(StringFormatFlags.DirectionVertical);
			this.SFVL.Alignment = StringAlignment.Near;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00006F90 File Offset: 0x00005F90
		private void InitializeComponent()
		{
			this.componentPictureBox = new PictureBox();
			base.SuspendLayout();
			this.componentPictureBox.Location = new Point(176, 56);
			this.componentPictureBox.Name = "componentPictureBox";
			this.componentPictureBox.TabIndex = 0;
			this.componentPictureBox.TabStop = false;
			this.componentPictureBox.Paint += this.Graph_Paint;
			base.Controls.AddRange(new Control[]
			{
				this.componentPictureBox
			});
			base.Name = "KMIGraph";
			base.Size = new Size(344, 208);
			base.SizeChanged += this.KMIGraph_SizeChanged;
			base.ResumeLayout(false);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00007068 File Offset: 0x00006068
		public void Draw(object[,] d)
		{
			this.data = d;
			if ((this.GraphType == 2 || this.GraphType == 3) && this.ShowPercentagesForHistograms)
			{
				float[] array = new float[this.data.GetUpperBound(0)];
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					array[i - 1] = 0f;
					for (int j = 1; j <= this.data.GetUpperBound(1); j++)
					{
						array[i - 1] += Convert.ToSingle(this.data[i, j]);
					}
				}
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					for (int j = 1; j <= this.data.GetUpperBound(1); j++)
					{
						if (this.GraphType == 3)
						{
							this.data[i, j] = Convert.ToSingle(this.data[i, j]) / Math.Max(1f, array[0]);
						}
						else
						{
							this.data[i, j] = Convert.ToSingle(this.data[i, j]) / Math.Max(1f, array[i - 1]);
						}
					}
				}
			}
			this.componentPictureBox.Refresh();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000071F0 File Offset: 0x000061F0
		protected void BorderArea(RectangleF a, Color c)
		{
			this.GraphicsObject.DrawRectangle(new Pen(c), a.Left, a.Top, a.Width, a.Height);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00007224 File Offset: 0x00006224
		protected void SetDefaultFonts()
		{
			this.titleFont = new Font("Microsoft Sans Serif", 18f);
			this.legendFont = new Font("Microsoft Sans Serif", 9f);
			this.axisTitleFont = new Font("Microsoft Sans Serif", 9f);
			this.axisLabelFont = new Font("Microsoft Sans Serif", 9f);
			this.dataPointLabelFont = new Font("Microsoft Sans Serif", 9f);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000729C File Offset: 0x0000629C
		protected Color LineColor(int i)
		{
			Color result = Color.Blue;
			switch (i % 10)
			{
			case 0:
				result = Color.DarkSalmon;
				break;
			case 1:
				result = Color.Blue;
				break;
			case 2:
				result = Color.DarkGreen;
				break;
			case 3:
				result = Color.Red;
				break;
			case 4:
				result = Color.DarkGoldenrod;
				break;
			case 5:
				result = Color.Magenta;
				break;
			case 6:
				result = Color.Brown;
				break;
			case 7:
				result = Color.DarkOrange;
				break;
			case 8:
				result = Color.Black;
				break;
			case 9:
				result = Color.DarkGray;
				break;
			}
			if (this.nGraphType == 3)
			{
				if (i == 1)
				{
					result = Color.FromArgb(136, 136, 136);
				}
				if (i == 2)
				{
					result = Color.DarkBlue;
				}
			}
			return result;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00007384 File Offset: 0x00006384
		protected string FormatYLabel(object objValue)
		{
			string result;
			if (this.sYLabelFormat == null || this.sYLabelFormat == "")
			{
				if ((this.GraphType == 2 || this.GraphType == 3) && this.ShowPercentagesForHistograms)
				{
					result = string.Format("{0:P0}", objValue);
				}
				else if (this.fYMax < 99f && this.fYMin > -99f)
				{
					result = string.Format("{0:C2}", objValue);
				}
				else
				{
					result = string.Format("{0:C0}", objValue);
				}
			}
			else
			{
				result = string.Format(this.sYLabelFormat, objValue);
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000743C File Offset: 0x0000643C
		protected string FormatXLabel(object objValue)
		{
			string result;
			if (objValue is DateTime)
			{
				if (this.sXLabelFormat == null || this.sXLabelFormat == "")
				{
					result = string.Format("{0:dd MMM yy}", objValue);
				}
				else
				{
					result = string.Format(this.sXLabelFormat, objValue);
				}
			}
			else if (objValue != null)
			{
				result = objValue.ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000074B8 File Offset: 0x000064B8
		protected void SetScale()
		{
			if (this.nGraphType == 1)
			{
				int i = this.data.GetUpperBound(1);
				this.nXSteps = Math.Min(5, i - 1);
				this.fXStep = (float)((i - 2) / this.nXSteps + 1);
				if (1.0 + (double)(this.fXStep * (float)(this.nXSteps - 1)) >= (double)((float)i))
				{
					this.nXSteps--;
				}
				if (1.0 + (double)(this.fXStep * (float)(this.nXSteps - 1)) >= (double)((float)i))
				{
					this.nXSteps--;
				}
			}
			else
			{
				if (this.GraphType == 5)
				{
					this.nXSteps = this.data.GetUpperBound(0);
				}
				else
				{
					this.nXSteps = this.data.GetUpperBound(1);
				}
				this.fXStep = 1f;
			}
			if (this.autoScaleY && this.nGraphType != 6)
			{
				this.fYMax = this.minimumYMax;
				this.fYMin = 0f;
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					for (int j = 1; j <= this.data.GetUpperBound(1); j++)
					{
						if (Convert.ToSingle(this.data[i, j]) > this.fYMax)
						{
							this.fYMax = Convert.ToSingle(this.data[i, j]);
						}
						if (Convert.ToSingle(this.data[i, j]) < this.fYMin)
						{
							this.fYMin = Convert.ToSingle(this.data[i, j]);
						}
					}
				}
			}
			if (this.nGraphType == 6)
			{
				this.fXMax = Convert.ToSingle(this.data[0, 1]);
				this.fYMax = Convert.ToSingle(this.data[1, 1]);
				this.fYMin = Convert.ToSingle(this.data[1, 1]);
				for (int i = 2; i <= this.data.GetUpperBound(1); i++)
				{
					if (Convert.ToSingle(this.data[0, i]) > this.maxXValue)
					{
						this.maxXValue = Convert.ToSingle(this.data[0, i]);
					}
					if (Convert.ToSingle(this.data[1, i]) > this.fYMax)
					{
						this.fYMax = Convert.ToSingle(this.data[1, i]);
					}
					if (Convert.ToSingle(this.data[1, i]) < this.fYMin)
					{
						this.fYMin = Convert.ToSingle(this.data[1, i]);
					}
				}
			}
			if (this.nGraphType != 5)
			{
				if (this.autoScaleY)
				{
					this.fYStep = (float)Math.Pow(10.0, (double)((int)Math.Log((double)(this.fYMax - this.fYMin), 10.0)));
					if ((this.fYMax - this.fYMin) / this.fYStep > 6f)
					{
						this.fYStep *= 2f;
					}
					else
					{
						if ((this.fYMax - this.fYMin) / this.fYStep < 4f)
						{
							this.fYStep /= 2f;
						}
						if ((this.fYMax - this.fYMin) / this.fYStep < 4f)
						{
							this.fYStep /= 2f;
						}
					}
					if ((float)((int)(this.fYMin / this.fYStep)) != this.fYMin / this.fYStep)
					{
						if (this.fYMin >= 0f)
						{
							this.fYMin = (float)((int)(this.fYMin / this.fYStep)) * this.fYStep;
						}
						else
						{
							this.fYMin = (float)((int)(this.fYMin / this.fYStep) - 1) * this.fYStep;
						}
					}
					if ((float)((int)(this.fYMax / this.fYStep)) != this.fYMax / this.fYStep)
					{
						this.fYMax = (float)((int)(this.fYMax / this.fYStep) + 1) * this.fYStep;
					}
					this.nYSteps = (int)((this.fYMax - this.fYMin) / this.fYStep);
				}
				else
				{
					this.fYStep = (this.fYMax - this.fYMin) / (float)this.nYSteps;
				}
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000079C4 File Offset: 0x000069C4
		protected void SetAreas()
		{
			Graphics graphicsObject = this.GraphicsObject;
			this.TitleArea = new RectangleF(0f, 0f, 0f, 0f);
			this.LegendArea = new RectangleF(0f, 0f, 0f, 0f);
			this.XAxisTitleArea = new RectangleF(0f, 0f, 0f, 0f);
			this.YAxisTitleArea = new RectangleF(0f, 0f, 0f, 0f);
			this.XAxisLabelArea = new RectangleF(0f, 0f, 0f, 0f);
			this.YAxisLabelArea = new RectangleF(0f, 0f, 0f, 0f);
			this.XAxisArea = new RectangleF(0f, 0f, 0f, 0f);
			this.YAxisArea = new RectangleF(0f, 0f, 0f, 0f);
			this.PlotArea = new RectangleF(0f, 0f, 0f, 0f);
			if (this.sTitle != null)
			{
				this.TitleArea.Height = 1.8f * graphicsObject.MeasureString(this.Title, this.titleFont).Height;
				this.TitleArea.Width = (float)(this.componentPictureBox.Width - 1);
			}
			else
			{
				this.TitleArea.Height = graphicsObject.MeasureString("X", this.axisLabelFont).Height;
			}
			if (this.bLegend)
			{
				this.LegendArea.Width = this.LongestLegendLabelWidth(graphicsObject) * 1.25f + 2f * graphicsObject.MeasureString("X", this.legendFont).Height + 16f;
				if (this.LegendArea.Width < this.LongestXAxisLabelWidth(graphicsObject) / 2f)
				{
					this.LegendArea.Width = this.LongestXAxisLabelWidth(graphicsObject) / 2f;
				}
				this.LegendArea.Location = new PointF((float)(this.componentPictureBox.Width - 1) - this.LegendArea.Width, this.TitleArea.Height);
			}
			else
			{
				this.LegendArea.Width = this.LongestXAxisLabelWidth(graphicsObject) / 2f;
				this.LegendArea.Location = new PointF((float)(this.componentPictureBox.Width - 1) - this.LegendArea.Width, 0f);
			}
			if (this.sYAxisTitle != null)
			{
				this.YAxisTitleArea.Width = 2f * this.GraphicsObject.MeasureString(this.sYAxisTitle, this.axisTitleFont).Height;
			}
			if (this.sXAxisTitle != null)
			{
				this.XAxisTitleArea.Height = 1.5f * this.GraphicsObject.MeasureString(this.sXAxisTitle, this.axisTitleFont).Height;
			}
			else
			{
				this.XAxisTitleArea.Height = 0.5f * this.GraphicsObject.MeasureString("X", this.axisLabelFont).Height;
			}
			if (this.GraphType != 5)
			{
				this.YAxisLabelArea.Width = 1.1f * Math.Max(this.GraphicsObject.MeasureString(this.FormatYLabel(this.fYMin), this.axisLabelFont).Width, this.GraphicsObject.MeasureString(this.FormatYLabel(this.fYMax), this.axisLabelFont).Width);
			}
			else
			{
				this.YAxisLabelArea.Width = this.LongestLegendLabelWidth(graphicsObject);
			}
			this.YAxisArea.Width = 4f;
			this.XAxisArea.Height = 4f;
			this.YAxisTitleArea.Location = new PointF(0f, this.TitleArea.Height);
			this.YAxisLabelArea.Location = new PointF(this.YAxisTitleArea.Width, this.TitleArea.Height);
			this.YAxisArea.Location = new PointF(this.YAxisLabelArea.Left + this.YAxisLabelArea.Width, this.TitleArea.Height);
			this.PlotArea.Location = new PointF(this.YAxisArea.Left + this.YAxisArea.Width, this.TitleArea.Height);
			this.PlotArea.Width = this.LegendArea.Left - this.PlotArea.Left;
			this.fXScale = this.PlotArea.Width / ((float)this.nXSteps * this.fXStep);
			this.bXAxisLabelDoubleDecker = false;
			float num = 0f;
			for (int i = 1; i <= this.data.GetUpperBound(1); i++)
			{
				float width = graphicsObject.MeasureString(this.FormatXLabel(this.data[0, i]), this.axisLabelFont).Width;
				if (width > num)
				{
					num = width;
				}
				if (width > this.fXScale * this.fXStep)
				{
					this.bXAxisLabelDoubleDecker = true;
				}
			}
			if (this.bXAxisLabelDoubleDecker)
			{
				this.XAxisLabelArea.Height = num + graphicsObject.MeasureString("X", this.axisLabelFont).Width;
			}
			else
			{
				this.XAxisLabelArea.Height = 1.5f * graphicsObject.MeasureString("X", this.axisLabelFont).Height;
			}
			if (!this.xAxisLabels || this.GraphType == 4 || this.GraphType == 5)
			{
				this.XAxisLabelArea.Height = 0f;
			}
			this.XAxisTitleArea.Location = new PointF(this.PlotArea.Left, (float)(this.componentPictureBox.Height - 1) - this.XAxisTitleArea.Height);
			if ((double)this.fYMin >= 0.0)
			{
				this.XAxisLabelArea.Location = new PointF(this.PlotArea.Left, this.XAxisTitleArea.Top - this.XAxisLabelArea.Height);
				this.XAxisArea.Location = new PointF(this.PlotArea.Left, this.XAxisLabelArea.Top - this.XAxisArea.Height);
				this.PlotArea.Height = this.XAxisArea.Top - this.PlotArea.Top;
				this.fYScale = this.PlotArea.Height / (this.fYMax - this.fYMin);
			}
			else
			{
				this.PlotArea.Height = this.XAxisTitleArea.Top - this.PlotArea.Top;
				this.fYScale = this.PlotArea.Height / (this.fYMax - this.fYMin);
				this.XAxisArea.Location = new PointF(this.PlotArea.Left, this.PlotArea.Top + this.fYScale * this.fYMax);
				this.XAxisLabelArea.Location = new PointF(this.PlotArea.Left, this.XAxisArea.Top + this.XAxisArea.Height);
			}
			this.XAxisTitleArea.Width = this.PlotArea.Width;
			this.XAxisLabelArea.Width = this.PlotArea.Width;
			this.XAxisArea.Width = this.PlotArea.Width;
			this.YAxisTitleArea.Height = this.PlotArea.Height;
			this.YAxisLabelArea.Height = this.PlotArea.Height;
			this.YAxisArea.Height = this.PlotArea.Height;
			this.LegendArea.Height = this.XAxisTitleArea.Top - this.LegendArea.Top;
			this.fXScale = this.PlotArea.Width / ((float)this.nXSteps * this.fXStep);
			this.fYScale = this.PlotArea.Height / (this.fYMax - this.fYMin);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000082B0 File Offset: 0x000072B0
		protected void DrawTitle()
		{
			if (this.sTitle != null)
			{
				this.GraphicsObject.DrawString(this.sTitle, this.titleFont, new SolidBrush(Color.Black), this.TitleArea, this.SFC);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000082FC File Offset: 0x000072FC
		protected void DrawLegend()
		{
			float num = this.LegendArea.Height / (float)(this.data.GetUpperBound(0) + 1);
			float size = this.legendFont.Size;
			for (int i = 1; i <= this.data.GetUpperBound(0); i++)
			{
				if (this.bLegend && this.nGraphType != 6)
				{
					if (this.nGraphType == 1)
					{
						this.GraphicsObject.DrawLine(new Pen(this.LineColor(i), (float)(this.nLineWidth + 2)), this.LegendArea.Left + 16f, this.LegendArea.Top + ((float)i - 0.5f) * num + size / 2f, this.LegendArea.Left + 16f + size, this.LegendArea.Top + ((float)i - 0.5f) * num + size / 2f - size);
					}
					else
					{
						this.GraphicsObject.FillRectangle(new SolidBrush(this.LineColor(i)), this.LegendArea.Left + 16f, this.LegendArea.Top + ((float)i - 0.5f) * num + size / 2f - size, size, size);
					}
					string text = this.data[i, 0].ToString();
					SizeF sizeF = this.GraphicsObject.MeasureString(text, this.legendFont);
					this.GraphicsObject.DrawString(text, this.legendFont, new SolidBrush(this.LineColor(i)), this.LegendArea.Left + 16f + size * 2f, this.LegendArea.Top + ((float)i - 0.5f) * num - sizeF.Height / 2f);
				}
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000084E8 File Offset: 0x000074E8
		protected void DrawAxisTitles()
		{
			if (this.sYAxisTitle != null)
			{
				this.GraphicsObject.DrawString(this.sYAxisTitle, this.axisTitleFont, new SolidBrush(Color.Black), this.YAxisTitleArea, this.SFVC);
			}
			if (this.sXAxisTitle != null)
			{
				this.GraphicsObject.DrawString(this.sXAxisTitle, this.axisTitleFont, new SolidBrush(Color.Black), this.XAxisTitleArea, this.SFC);
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00008570 File Offset: 0x00007570
		protected void DrawData()
		{
			float num = this.PlotArea.Width / (float)this.nXSteps;
			float num2 = 6f;
			float num3 = 0f;
			float num4 = 0f;
			switch (this.nGraphType)
			{
			case 1:
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					for (int j = 1; j <= this.data.GetUpperBound(1); j++)
					{
						if (this.data[i, j] != null)
						{
							if (j == 1)
							{
								num3 = this.PlotArea.Left + (float)(j - 1) * this.fXScale;
								num4 = this.PlotArea.Top + (this.fYMax - Convert.ToSingle(this.data[i, j])) * this.fYScale;
							}
							else
							{
								this.GraphicsObject.DrawLine(new Pen(this.LineColor(i), (float)this.nLineWidth), num3, num4, this.PlotArea.Left + (float)(j - 1) * this.fXScale, this.PlotArea.Top + (this.fYMax - Convert.ToSingle(this.data[i, j])) * this.fYScale);
								num3 = this.PlotArea.Left + (float)(j - 1) * this.fXScale;
								num4 = this.PlotArea.Top + (this.fYMax - Convert.ToSingle(this.data[i, j])) * this.fYScale;
							}
						}
					}
				}
				break;
			case 2:
			{
				float num5 = (num - 2f * num2) / (float)this.data.GetUpperBound(0);
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					for (int j = 1; j <= this.data.GetUpperBound(1); j++)
					{
						this.GraphicsObject.FillRectangle(new SolidBrush(this.LineColor(i)), this.PlotArea.Left + (float)(j - 1) * num + num2 + (float)(i - 1) * num5, this.PlotArea.Top + this.PlotArea.Height - Convert.ToSingle(this.data[i, j]) * this.fYScale, num5, Convert.ToSingle(this.data[i, j]) * this.fYScale);
						if (this.bDataPointLabels)
						{
							string text = this.FormatYLabel(this.data[i, j]);
							SizeF sizeF = this.GraphicsObject.MeasureString(text, this.dataPointLabelFont);
							RectangleF layoutRectangle = new RectangleF(this.PlotArea.Left + (float)(j - 1) * num + num2 + (float)(i - 1) * num5, this.PlotArea.Top + this.PlotArea.Height - Convert.ToSingle(this.data[i, j]) * this.fYScale - sizeF.Height, Math.Max(num5, sizeF.Width), sizeF.Height);
							this.GraphicsObject.DrawString(text, this.dataPointLabelFont, new SolidBrush(Color.Black), layoutRectangle, this.SFC);
						}
					}
				}
				break;
			}
			case 3:
				if (this.data.GetUpperBound(0) > 2)
				{
					this.GraphicsObject.DrawString("Histrogram3D cannot graph more than 2 sets of data.", new Font("Microsoft Sans Serif", 14f, FontStyle.Bold), new SolidBrush(Color.Red), this.PlotArea, this.SFC);
				}
				else
				{
					for (int i = 1; i <= this.data.GetUpperBound(0); i++)
					{
						for (int j = 1; j <= this.data.GetUpperBound(1); j++)
						{
							this.GraphicsObject.FillRectangle(new SolidBrush(this.LineColor(i)), this.PlotArea.Left + (float)(j - 1) * num + (float)i * num2, this.PlotArea.Top + this.PlotArea.Height - Convert.ToSingle(this.data[i, j]) * this.fYScale, num - (float)(2 * i) * num2, Convert.ToSingle(this.data[i, j]) * this.fYScale);
						}
					}
					if (this.bDataPointLabels)
					{
						for (int i = 1; i <= this.data.GetUpperBound(0); i++)
						{
							for (int j = 1; j <= this.data.GetUpperBound(1); j++)
							{
								string text = this.FormatYLabel(this.data[i, j]);
								SizeF sizeF = this.GraphicsObject.MeasureString(text, this.dataPointLabelFont);
								RectangleF layoutRectangle = new RectangleF(this.PlotArea.Left + (float)(j - 1) * num + (float)i * num2, this.PlotArea.Top + this.PlotArea.Height - Convert.ToSingle(this.data[i, j]) * this.fYScale - sizeF.Height, Math.Max(sizeF.Width, num - (float)(2 * i) * num2), sizeF.Height);
								this.GraphicsObject.DrawString(text, this.dataPointLabelFont, new SolidBrush(Color.Black), layoutRectangle, this.SFC);
							}
						}
					}
				}
				break;
			case 4:
			{
				num2 = (this.PlotArea.Width - this.PlotArea.Height) / 2f;
				float num6 = 0f;
				float num7 = 0f;
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					num6 += Convert.ToSingle(this.data[i, this.data.GetUpperBound(1)]);
				}
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					float num8 = Convert.ToSingle(this.data[i, this.data.GetUpperBound(1)]) / num6 * 360f;
					this.GraphicsObject.FillPie(new SolidBrush(this.LineColor(i)), this.PlotArea.Left + num2, this.PlotArea.Top, this.PlotArea.Height, this.PlotArea.Height, num7, num8);
					num7 += num8;
				}
				break;
			}
			case 5:
			{
				float num9 = this.PlotArea.Height / (float)this.nXSteps;
				float num10 = num9 - 8f;
				float num11 = this.PlotArea.Width - 1.05f * Math.Max(this.GraphicsObject.MeasureString(this.FormatYLabel(this.fYMin), this.dataPointLabelFont).Width, this.GraphicsObject.MeasureString(this.FormatYLabel(this.fYMax), this.dataPointLabelFont).Width) - 4f;
				for (int i = 1; i <= this.data.GetUpperBound(0); i++)
				{
					float num12 = Convert.ToSingle(this.data[i, this.data.GetUpperBound(1)]);
					float num13 = this.PlotArea.Top + (float)(i - 1) * num9 + 4f;
					float num14 = Math.Abs(num12 / (this.fYMax - this.fYMin) * num11);
					Color color;
					float num15;
					if (num12 >= 0f)
					{
						color = Color.DarkBlue;
						num15 = this.PlotArea.Left - this.fYMin / (this.fYMax - this.fYMin) * num11;
					}
					else
					{
						color = Color.Red;
						num15 = this.PlotArea.Left + (num12 - this.fYMin) / (this.fYMax - this.fYMin) * num11;
					}
					this.GraphicsObject.FillRectangle(new SolidBrush(color), num15, num13, num14, num10);
					if (this.bDataPointLabels)
					{
						string text = this.FormatYLabel(num12);
						SizeF sizeF = this.GraphicsObject.MeasureString(text, this.dataPointLabelFont);
						this.GraphicsObject.DrawString(text, this.dataPointLabelFont, new SolidBrush(Color.Black), num15 + num14 + 4f, num13 + (num10 - sizeF.Height) / 2f);
					}
					string text2 = this.data[i, 0].ToString();
					SizeF sizeF2 = this.GraphicsObject.MeasureString(text2, this.legendFont);
					this.GraphicsObject.DrawString(text2, this.legendFont, new SolidBrush(Color.Black), this.YAxisLabelArea.Left, num13 + (num10 - sizeF2.Height) / 2f);
				}
				break;
			}
			case 6:
				this.FindMaxValues(this.data);
				for (int i = 1; i <= this.data.GetUpperBound(1); i++)
				{
					float num17;
					float num16 = num17 = 2f * (float)this.nLineWidth;
					float num18 = this.PlotArea.Left + Convert.ToSingle(this.data[0, i]) / this.maxXValue * this.PlotArea.Width;
					float num19 = this.PlotArea.Top + this.PlotArea.Height - Convert.ToSingle(this.data[1, i]) / this.maxYValue * this.PlotArea.Height;
					num18 -= num17 / 2f;
					num19 -= num16 / 2f;
					this.GraphicsObject.FillEllipse(new SolidBrush(Color.Yellow), num18, num19, num17, num16);
					this.GraphicsObject.DrawEllipse(new Pen(Color.Black, 1f), num18, num19, num17, num16);
				}
				break;
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00009068 File Offset: 0x00008068
		protected void DrawAxes()
		{
			Pen pen = new Pen(Color.Black, 1f);
			this.GraphicsObject.DrawLine(pen, this.YAxisArea.Left + this.YAxisArea.Width, this.YAxisArea.Top, this.YAxisArea.Left + this.YAxisArea.Width, this.YAxisArea.Top + this.YAxisArea.Height);
			this.GraphicsObject.DrawLine(pen, this.XAxisArea.Left, this.XAxisArea.Top, this.XAxisArea.Left + this.XAxisArea.Width, this.XAxisArea.Top);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00009128 File Offset: 0x00008128
		protected void DrawAxisLabels()
		{
			for (int i = 0; i <= this.nYSteps; i++)
			{
				float num = this.YAxisArea.Top + (float)i * this.fYStep * this.fYScale;
				if (this.bShowYTicks)
				{
					this.GraphicsObject.DrawLine(new Pen(Color.Black), this.YAxisArea.Left, num, this.YAxisArea.Left + this.YAxisArea.Width * 2f, num);
				}
				if (this.GridLinesY)
				{
					this.GraphicsObject.DrawLine(new Pen(Color.Gray), this.PlotArea.Left, num, this.PlotArea.Left + this.PlotArea.Width, num);
				}
				string text = this.FormatYLabel(this.fYMax - (float)i * this.fYStep);
				SizeF sizeF = this.GraphicsObject.MeasureString(text, this.axisLabelFont);
				this.GraphicsObject.DrawString(text, this.axisLabelFont, new SolidBrush(Color.Black), new PointF(this.YAxisLabelArea.Left + this.YAxisLabelArea.Width * 0.95f - sizeF.Width, num - sizeF.Height / 2f));
			}
			for (int i = 1; i <= this.nXSteps + 1; i++)
			{
				float num2 = this.XAxisArea.Left + (float)(i - 1) * this.fXStep * this.fXScale;
				if (this.bShowXTicks)
				{
					this.GraphicsObject.DrawLine(new Pen(Color.Black), num2, this.XAxisArea.Top - this.XAxisArea.Height, num2, this.XAxisArea.Top + this.XAxisArea.Height);
				}
				if (this.bGridLinesX)
				{
					this.GraphicsObject.DrawLine(new Pen(Color.Gray), num2, this.PlotArea.Top, num2, this.PlotArea.Top + this.PlotArea.Height);
				}
				if ((int)(1f + (float)(i - 1) * this.fXStep) <= this.data.GetUpperBound(1) && ((double)this.fYMin >= 0.0 || i > 1) && this.nGraphType != 6)
				{
					string text = this.FormatXLabel(this.data[0, 1 + (i - 1) * (int)this.fXStep]);
					SizeF sizeF = this.GraphicsObject.MeasureString(text, this.axisLabelFont);
					if (this.nGraphType == 1)
					{
						num2 -= sizeF.Width / 2f;
					}
					else if (this.bXAxisLabelDoubleDecker)
					{
						num2 += 0.5f * this.fXStep * this.fXScale - this.GraphicsObject.MeasureString("X", this.axisLabelFont).Height / 2f;
					}
					else
					{
						num2 += 0.5f * this.fXStep * this.fXScale - sizeF.Width / 2f;
					}
					float num = this.XAxisLabelArea.Top + 0.15f * sizeF.Height;
					if (this.bXAxisLabelDoubleDecker)
					{
						this.GraphicsObject.DrawString(text, this.axisLabelFont, new SolidBrush(Color.Black), num2, num, this.SFVL);
					}
					else if ((double)num2 >= 0.0 && num2 + sizeF.Width <= (float)this.componentPictureBox.Width)
					{
						this.GraphicsObject.DrawString(text, this.axisLabelFont, new SolidBrush(Color.Black), num2, num);
					}
				}
				else if (this.nGraphType == 6)
				{
					string text = ((float)(i - 1) / (float)this.nXSteps * this.fXMax).ToString();
					SizeF sizeF = this.GraphicsObject.MeasureString(text, this.axisLabelFont);
					num2 -= sizeF.Width / 2f;
					float num = this.XAxisLabelArea.Top + 0.15f * sizeF.Height;
					if (this.bXAxisLabelDoubleDecker && i % 2 == 0)
					{
						num += 1.15f * this.GraphicsObject.MeasureString("X", this.axisLabelFont).Height;
					}
					this.GraphicsObject.DrawString(text, this.axisLabelFont, new SolidBrush(Color.Black), num2, num);
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00009618 File Offset: 0x00008618
		public void PrintGraph()
		{
			if (this.data == null || (this.GraphType == 1 && this.data.GetUpperBound(1) < 2) || (this.GraphType != 1 && this.data.GetUpperBound(1) < 1))
			{
				string @string = KMIGraph.rm.GetString("No Data");
				string string2 = KMIGraph.rm.GetString("Not enough data to display graph at this time.");
				MessageBox.Show(string2, @string);
			}
			else
			{
				Utilities.PrintWithExceptionHandling(this.Title, new PrintPageEventHandler(this.Graph_PrintPage));
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000096B0 File Offset: 0x000086B0
		public void PrintPreviewGraph()
		{
			if (this.data == null || (this.GraphType == 1 && this.data.GetUpperBound(1) < 2) || (this.GraphType != 1 && this.data.GetUpperBound(1) < 1))
			{
				string @string = KMIGraph.rm.GetString("No Data");
				string string2 = KMIGraph.rm.GetString("Not enough data to display graph at this time.");
				MessageBox.Show(string2, @string);
			}
			else
			{
				PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
				PrintDocument printDocument = new PrintDocument();
				printDocument.DocumentName = this.Title;
				printDocument.PrintPage += this.Graph_PrintPage;
				printPreviewDialog.Document = printDocument;
				printPreviewDialog.ShowDialog();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000976B File Offset: 0x0000876B
		private void KMIGraph_SizeChanged(object sender, EventArgs e)
		{
			this.componentPictureBox.Location = new Point(0, 0);
			this.componentPictureBox.Size = base.Size;
			this.componentPictureBox.Refresh();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000097A0 File Offset: 0x000087A0
		private void Graph_Paint(object sender, PaintEventArgs e)
		{
			if (this.data == null || (this.GraphType == 1 && this.data.GetUpperBound(1) < 2) || (this.GraphType != 1 && this.data.GetUpperBound(1) < 1))
			{
				e.Graphics.DrawString(KMIGraph.rm.GetString("Not enough data to display graph at this time."), this.titleFont, new SolidBrush(Color.DarkGray), base.ClientRectangle);
			}
			else
			{
				try
				{
					this.GraphicsObject = e.Graphics;
					this.RenderToGraphics();
				}
				catch (Exception ex)
				{
					throw new Exception("In KMIGraph.GraphPaint, " + ex.Message);
				}
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000986C File Offset: 0x0000886C
		private void Graph_PrintPage(object sender, PrintPageEventArgs e)
		{
			try
			{
				Utilities.ResetFPU();
				this.GraphicsObject = e.Graphics;
				this.GraphicsObject.SmoothingMode = SmoothingMode.HighQuality;
				float num;
				if (!e.PageSettings.Landscape)
				{
					num = ((float)e.PageSettings.Bounds.Width - 2f * (float)this.printerMargin) / (float)base.Width;
				}
				else
				{
					num = ((float)e.PageSettings.Bounds.Height - 2f * (float)this.printerMargin) / (float)base.Height;
				}
				this.GraphicsObject.ScaleTransform(num, num);
				float dx = ((float)e.PageSettings.Bounds.Width - (float)base.Width * num) / 2f / num;
				float dy = ((float)e.PageSettings.Bounds.Height - (float)base.Height * num) / 2f / num;
				this.GraphicsObject.TranslateTransform(dx, dy);
				this.RenderToGraphics();
			}
			catch (Exception ex)
			{
				throw new Exception("In KMIGraph.PrintPage, " + ex.Message);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000099BC File Offset: 0x000089BC
		protected void RenderToGraphics()
		{
			if (this.nGraphType == 6)
			{
				this.sXAxisTitle = (string)this.data[0, 0];
				this.sYAxisTitle = (string)this.data[1, 0];
			}
			this.SetScale();
			this.SetAreas();
			this.DrawTitle();
			this.DrawLegend();
			if (this.nGraphType != 4 && this.nGraphType != 5)
			{
				this.DrawAxisTitles();
			}
			this.DrawData();
			if (this.nGraphType != 4 && this.nGraphType != 5)
			{
				this.DrawAxes();
				this.DrawAxisLabels();
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00009A7C File Offset: 0x00008A7C
		protected float LongestLegendLabelWidth(Graphics g)
		{
			float num = 0f;
			for (int i = 1; i <= this.data.GetUpperBound(0); i++)
			{
				if (this.data[i, 0] != null && g.MeasureString(this.data[i, 0].ToString(), this.legendFont).Width > num)
				{
					num = g.MeasureString(this.data[i, 0].ToString(), this.legendFont).Width;
				}
			}
			return num;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00009B28 File Offset: 0x00008B28
		protected float LongestXAxisLabelWidth(Graphics g)
		{
			float num = 0f;
			for (int i = 1; i <= this.data.GetUpperBound(1); i++)
			{
				if (this.data[0, i] != null && g.MeasureString(this.data[0, i].ToString(), this.axisLabelFont).Width > num)
				{
					num = g.MeasureString(this.data[0, i].ToString(), this.axisLabelFont).Width;
				}
			}
			return num;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00009BD4 File Offset: 0x00008BD4
		protected void FindMaxValues(object[,] data)
		{
			if (this.nGraphType == 6)
			{
				this.maxXValue = Convert.ToSingle(data[0, 1]);
				this.maxYValue = Convert.ToSingle(data[1, 1]);
				for (int i = 2; i <= data.GetUpperBound(1); i++)
				{
					if (Convert.ToSingle(data[0, i]) > this.maxXValue)
					{
						this.maxXValue = Convert.ToSingle(data[0, i]);
					}
					if (Convert.ToSingle(data[1, i]) > this.maxYValue)
					{
						this.maxYValue = Convert.ToSingle(data[1, i]);
					}
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00009C9C File Offset: 0x00008C9C
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00009CB4 File Offset: 0x00008CB4
		public int GraphType
		{
			get
			{
				return this.nGraphType;
			}
			set
			{
				this.nGraphType = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00009CC0 File Offset: 0x00008CC0
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00009CD8 File Offset: 0x00008CD8
		public bool Legend
		{
			get
			{
				return this.bLegend;
			}
			set
			{
				this.bLegend = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00009CE4 File Offset: 0x00008CE4
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00009CFC File Offset: 0x00008CFC
		public string Title
		{
			get
			{
				return this.sTitle;
			}
			set
			{
				this.sTitle = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00009D08 File Offset: 0x00008D08
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00009D20 File Offset: 0x00008D20
		public string XAxisTitle
		{
			get
			{
				return this.sXAxisTitle;
			}
			set
			{
				this.sXAxisTitle = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00009D2C File Offset: 0x00008D2C
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00009D44 File Offset: 0x00008D44
		public string YAxisTitle
		{
			get
			{
				return this.sYAxisTitle;
			}
			set
			{
				this.sYAxisTitle = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00009D50 File Offset: 0x00008D50
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00009D6D File Offset: 0x00008D6D
		public float TitleFontSize
		{
			get
			{
				return this.titleFont.Size;
			}
			set
			{
				this.titleFont = new Font("Microsoft Sans Serif", value);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00009D84 File Offset: 0x00008D84
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00009DA1 File Offset: 0x00008DA1
		public float LegendFontSize
		{
			get
			{
				return this.legendFont.Size;
			}
			set
			{
				this.legendFont = new Font("Microsoft Sans Serif", value);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00009DB8 File Offset: 0x00008DB8
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00009DD5 File Offset: 0x00008DD5
		public float AxisTitleFontSize
		{
			get
			{
				return this.axisTitleFont.Size;
			}
			set
			{
				this.axisTitleFont = new Font("Microsoft Sans Serif", value);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00009DEC File Offset: 0x00008DEC
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00009E09 File Offset: 0x00008E09
		public float AxisLabelFontSize
		{
			get
			{
				return this.axisLabelFont.Size;
			}
			set
			{
				this.axisLabelFont = new Font("Microsoft Sans Serif", value);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00009E20 File Offset: 0x00008E20
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00009E38 File Offset: 0x00008E38
		public object[,] Data
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00009E44 File Offset: 0x00008E44
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00009E61 File Offset: 0x00008E61
		public float DataPointLabelFontSize
		{
			get
			{
				return this.dataPointLabelFont.Size;
			}
			set
			{
				this.dataPointLabelFont = new Font("Microsoft Sans Serif", value);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00009E78 File Offset: 0x00008E78
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00009E90 File Offset: 0x00008E90
		public string XLabelFormat
		{
			get
			{
				return this.sXLabelFormat;
			}
			set
			{
				this.sXLabelFormat = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00009E9C File Offset: 0x00008E9C
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00009EB4 File Offset: 0x00008EB4
		public string YLabelFormat
		{
			get
			{
				return this.sYLabelFormat;
			}
			set
			{
				this.sYLabelFormat = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00009EC0 File Offset: 0x00008EC0
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00009ED8 File Offset: 0x00008ED8
		public int LineWidth
		{
			get
			{
				return this.nLineWidth;
			}
			set
			{
				this.nLineWidth = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00009EE4 File Offset: 0x00008EE4
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00009EFC File Offset: 0x00008EFC
		public bool GridLinesX
		{
			get
			{
				return this.bGridLinesX;
			}
			set
			{
				this.bGridLinesX = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00009F08 File Offset: 0x00008F08
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00009F20 File Offset: 0x00008F20
		public bool GridLinesY
		{
			get
			{
				return this.bGridLinesY;
			}
			set
			{
				this.bGridLinesY = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00009F2C File Offset: 0x00008F2C
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00009F44 File Offset: 0x00008F44
		public bool DataPointLabels
		{
			get
			{
				return this.bDataPointLabels;
			}
			set
			{
				this.bDataPointLabels = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00009F50 File Offset: 0x00008F50
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00009F68 File Offset: 0x00008F68
		public bool ShowPercentagesForHistograms
		{
			get
			{
				return this.showPercentagesForHistograms;
			}
			set
			{
				this.showPercentagesForHistograms = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00009F74 File Offset: 0x00008F74
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00009F8C File Offset: 0x00008F8C
		public int PrinterMargin
		{
			get
			{
				return this.printerMargin;
			}
			set
			{
				this.printerMargin = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00009F98 File Offset: 0x00008F98
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00009FB0 File Offset: 0x00008FB0
		public float MinimumYMax
		{
			get
			{
				return this.minimumYMax;
			}
			set
			{
				this.minimumYMax = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00009FBC File Offset: 0x00008FBC
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00009FD4 File Offset: 0x00008FD4
		public float YMax
		{
			get
			{
				return this.fYMax;
			}
			set
			{
				this.fYMax = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00009FE0 File Offset: 0x00008FE0
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00009FF8 File Offset: 0x00008FF8
		public float YMin
		{
			get
			{
				return this.fYMin;
			}
			set
			{
				this.fYMin = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000A004 File Offset: 0x00009004
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x0000A01C File Offset: 0x0000901C
		public bool AutoScaleY
		{
			get
			{
				return this.autoScaleY;
			}
			set
			{
				this.autoScaleY = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000A028 File Offset: 0x00009028
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x0000A040 File Offset: 0x00009040
		public bool XAxisLabels
		{
			get
			{
				return this.xAxisLabels;
			}
			set
			{
				this.xAxisLabels = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000A04C File Offset: 0x0000904C
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000A066 File Offset: 0x00009066
		public int YTicks
		{
			get
			{
				return this.nYSteps + 1;
			}
			set
			{
				this.nYSteps = value - 1;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x0000A074 File Offset: 0x00009074
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x0000A08C File Offset: 0x0000908C
		public bool ShowXTicks
		{
			get
			{
				return this.bShowXTicks;
			}
			set
			{
				this.bShowXTicks = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000A098 File Offset: 0x00009098
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x0000A0B0 File Offset: 0x000090B0
		public bool ShowYTicks
		{
			get
			{
				return this.bShowYTicks;
			}
			set
			{
				this.bShowYTicks = value;
			}
		}

		// Token: 0x04000034 RID: 52
		public const int LEGEND_LEFT_MARGIN = 16;

		// Token: 0x04000035 RID: 53
		public const int GRAPH_LINE = 1;

		// Token: 0x04000036 RID: 54
		public const int GRAPH_HISTOGRAM = 2;

		// Token: 0x04000037 RID: 55
		public const int GRAPH_HISTOGRAM3D = 3;

		// Token: 0x04000038 RID: 56
		public const int GRAPH_PIE = 4;

		// Token: 0x04000039 RID: 57
		public const int GRAPH_SCOREBOARD = 5;

		// Token: 0x0400003A RID: 58
		public const int GRAPH_SCATTER = 6;

		// Token: 0x0400003B RID: 59
		protected int nGraphType;

		// Token: 0x0400003C RID: 60
		protected string sTitle;

		// Token: 0x0400003D RID: 61
		protected bool bLegend;

		// Token: 0x0400003E RID: 62
		protected string sXAxisTitle;

		// Token: 0x0400003F RID: 63
		protected string sYAxisTitle;

		// Token: 0x04000040 RID: 64
		protected string sXLabelFormat;

		// Token: 0x04000041 RID: 65
		protected string sYLabelFormat;

		// Token: 0x04000042 RID: 66
		protected int nLineWidth;

		// Token: 0x04000043 RID: 67
		protected bool bGridLinesX;

		// Token: 0x04000044 RID: 68
		protected bool bGridLinesY;

		// Token: 0x04000045 RID: 69
		protected bool bDataPointLabels;

		// Token: 0x04000046 RID: 70
		protected int printerMargin;

		// Token: 0x04000047 RID: 71
		protected bool bShowXTicks;

		// Token: 0x04000048 RID: 72
		protected bool bShowYTicks;

		// Token: 0x04000049 RID: 73
		protected float fYMin;

		// Token: 0x0400004A RID: 74
		protected float fYMax;

		// Token: 0x0400004B RID: 75
		protected float fYStep;

		// Token: 0x0400004C RID: 76
		protected int nYSteps;

		// Token: 0x0400004D RID: 77
		protected float fYScale;

		// Token: 0x0400004E RID: 78
		protected float fXStep;

		// Token: 0x0400004F RID: 79
		protected int nXSteps;

		// Token: 0x04000050 RID: 80
		protected float fXScale;

		// Token: 0x04000051 RID: 81
		protected float fXMax;

		// Token: 0x04000052 RID: 82
		protected float fXMin;

		// Token: 0x04000053 RID: 83
		protected int nXNumLabels;

		// Token: 0x04000054 RID: 84
		protected RectangleF TitleArea;

		// Token: 0x04000055 RID: 85
		protected RectangleF LegendArea;

		// Token: 0x04000056 RID: 86
		protected RectangleF XAxisTitleArea;

		// Token: 0x04000057 RID: 87
		protected RectangleF YAxisTitleArea;

		// Token: 0x04000058 RID: 88
		protected RectangleF XAxisLabelArea;

		// Token: 0x04000059 RID: 89
		protected RectangleF YAxisLabelArea;

		// Token: 0x0400005A RID: 90
		protected RectangleF XAxisArea;

		// Token: 0x0400005B RID: 91
		protected RectangleF YAxisArea;

		// Token: 0x0400005C RID: 92
		protected RectangleF PlotArea;

		// Token: 0x0400005D RID: 93
		protected bool bXAxisLabelDoubleDecker;

		// Token: 0x0400005E RID: 94
		protected Graphics GraphicsObject;

		// Token: 0x0400005F RID: 95
		protected object[,] data;

		// Token: 0x04000060 RID: 96
		protected Font titleFont;

		// Token: 0x04000061 RID: 97
		protected Font legendFont;

		// Token: 0x04000062 RID: 98
		protected Font axisTitleFont;

		// Token: 0x04000063 RID: 99
		protected Font axisLabelFont;

		// Token: 0x04000064 RID: 100
		protected Font dataPointLabelFont;

		// Token: 0x04000065 RID: 101
		protected StringFormat SF;

		// Token: 0x04000066 RID: 102
		protected StringFormat SFC;

		// Token: 0x04000067 RID: 103
		protected StringFormat SFVC;

		// Token: 0x04000068 RID: 104
		protected StringFormat SFVL;

		// Token: 0x04000069 RID: 105
		protected bool autoScaleY;

		// Token: 0x0400006A RID: 106
		protected bool xAxisLabels;

		// Token: 0x0400006B RID: 107
		protected float maxXValue;

		// Token: 0x0400006C RID: 108
		protected float maxYValue;

		// Token: 0x0400006D RID: 109
		protected PictureBox componentPictureBox;

		// Token: 0x0400006E RID: 110
		protected float minimumYMax = 1f;

		// Token: 0x0400006F RID: 111
		protected bool showPercentagesForHistograms;

		// Token: 0x04000070 RID: 112
		private static ResourceManager rm = new ResourceManager("KMI.Utility.Utility", Assembly.GetAssembly(typeof(KMIGraph)));
	}
}
