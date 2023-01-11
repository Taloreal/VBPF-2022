using System;
using System.Drawing;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class ConsultantReportSection
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000043C0 File Offset: 0x000033C0
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000043D8 File Offset: 0x000033D8
		public string Topic
		{
			get
			{
				return this.topic;
			}
			set
			{
				this.topic = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000043E4 File Offset: 0x000033E4
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000043FC File Offset: 0x000033FC
		public string Finding
		{
			get
			{
				return this.finding;
			}
			set
			{
				this.finding = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004408 File Offset: 0x00003408
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00004420 File Offset: 0x00003420
		public float Grade
		{
			get
			{
				return this.grade;
			}
			set
			{
				this.grade = value;
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000442C File Offset: 0x0000342C
		public int Print(int left, int top, int width, Graphics g, bool grades)
		{
			Font font = new Font("Arial", 12f, FontStyle.Bold);
			Font font2 = new Font("Arial", 11f);
			Font font3 = new Font("Arial", 11f, FontStyle.Bold);
			Brush brush = new SolidBrush(Color.Black);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Trimming = StringTrimming.Word;
			SizeF sizeF = g.MeasureString(this.Topic, font, width, stringFormat);
			g.DrawString(this.Topic, font, brush, new RectangleF((float)left, (float)top, sizeF.Width, sizeF.Height), stringFormat);
			top += (int)sizeF.Height + 10;
			sizeF = g.MeasureString(this.Finding, font2, width - 30, stringFormat);
			g.DrawString(this.Finding, font2, brush, new RectangleF((float)(left + 30), (float)top, sizeF.Width, sizeF.Height), stringFormat);
			top += (int)sizeF.Height + 10;
			if (grades)
			{
				sizeF = g.MeasureString("Grade: " + Utilities.FP(this.Grade), font3, width, stringFormat);
				g.DrawString("Grade: " + Utilities.FP(this.Grade), font3, brush, new RectangleF((float)(left + 30), (float)top, sizeF.Width, sizeF.Height), stringFormat);
				top += (int)sizeF.Height + 20;
			}
			top += 10;
			return top;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000045AC File Offset: 0x000035AC
		public int PrintHeight(int width, Graphics g, bool grades)
		{
			Font font = new Font("Arial", 12f, FontStyle.Bold);
			Font font2 = new Font("Arial", 11f);
			Font font3 = new Font("Arial", 11f, FontStyle.Bold);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Trimming = StringTrimming.Word;
			int num = 0;
			num += (int)g.MeasureString(this.Topic, font, width, stringFormat).Height + 10;
			num += (int)g.MeasureString(this.Finding, font2, width - 30, stringFormat).Height + 10;
			if (grades)
			{
				num += (int)g.MeasureString("Grade: " + Utilities.FP(this.Grade), font3, width, stringFormat).Height + 20;
			}
			return num + 10;
		}

		// Token: 0x04000017 RID: 23
		private const int VSPACE = 10;

		// Token: 0x04000018 RID: 24
		private const int INDENT = 30;

		// Token: 0x04000019 RID: 25
		protected string topic;

		// Token: 0x0400001A RID: 26
		protected string finding;

		// Token: 0x0400001B RID: 27
		protected float grade;
	}
}
