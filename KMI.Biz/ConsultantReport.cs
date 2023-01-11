using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class ConsultantReport
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00003ACC File Offset: 0x00002ACC
		public ConsultantReport(Entity e)
		{
			this.reportTitle = "Report on " + e.Name;
			this.EntityName = e.Name;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003B1A File Offset: 0x00002B1A
		public void AddSection(ConsultantReportSection crs)
		{
			this.sections.Add(crs);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003B2C File Offset: 0x00002B2C
		public void Finish(string[] sectionOrdering)
		{
			ArrayList arrayList = new ArrayList();
			foreach (string b in sectionOrdering)
			{
				foreach (object obj in this.sections)
				{
					ConsultantReportSection consultantReportSection = (ConsultantReportSection)obj;
					if (consultantReportSection.Topic == b)
					{
						arrayList.Add(consultantReportSection);
					}
				}
			}
			this.sections = arrayList;
			this.AddOverallGradeSection();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003BE8 File Offset: 0x00002BE8
		public int PrintToScreen(int width, Graphics g, bool full, bool grades)
		{
			int num = 0;
			num = this.PrintHeader(0, num, width, g);
			string lead;
			if (full)
			{
				lead = "I reviewed many different aspects of your business. Here are my results and advice in each area. ";
				num = this.PrintLead(0, num, width, g, lead);
				foreach (object obj in this.sections)
				{
					ConsultantReportSection consultantReportSection = (ConsultantReportSection)obj;
					if (consultantReportSection != this.sections[this.sections.Count - 1] || grades)
					{
						num = consultantReportSection.Print(0, num, width, g, grades);
					}
				}
			}
			else
			{
				ConsultantReportSection[] array = (ConsultantReportSection[])this.sections.ToArray(typeof(ConsultantReportSection));
				Array.Sort(array, new ConsultantReport.GradeComparer());
				this.worstSection = array[0];
				if ((double)this.worstSection.Grade > 0.9)
				{
					lead = "Overall, your business looks in excellent condition. If I had to suggest improvement in any area, it would be this one.";
				}
				else
				{
					lead = "After looking over your business, here is the area I feel needs the most improvement. ";
				}
				num = this.PrintLead(0, num, width, g, lead);
				num = this.worstSection.Print(0, num, width, g, grades);
			}
			this.printLead = lead;
			return num;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003D44 File Offset: 0x00002D44
		public void PrintToPrinter(bool full, bool grades)
		{
			PrintDialog printDialog = new PrintDialog();
			PrintDocument printDocument = new PrintDocument();
			printDocument.PrintPage += this.Report_PrintPage;
			printDialog.Document = printDocument;
			printDialog.AllowPrintToFile = false;
			if (printDialog.ShowDialog() == DialogResult.OK)
			{
				printDocument.PrinterSettings = printDialog.PrinterSettings;
				if (full)
				{
					this.printSection = 0;
				}
				else
				{
					this.printSection = this.sections.IndexOf(this.worstSection);
				}
				this.printPage = 1;
				this.printFull = full;
				this.printGrades = grades;
				printDocument.Print();
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003DE4 File Offset: 0x00002DE4
		private void Report_PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			Graphics graphics = e.Graphics;
			RectangleF rectangleF = new RectangleF((float)e.MarginBounds.Left, (float)e.MarginBounds.Top, (float)e.MarginBounds.Width, (float)e.MarginBounds.Height);
			if (this.printPage == 1)
			{
				int num = this.PrintHeader((int)rectangleF.X, (int)rectangleF.Top, (int)rectangleF.Width, graphics);
				num = this.PrintLead((int)rectangleF.X, num, (int)rectangleF.Width, graphics, this.printLead);
				rectangleF.Height -= (float)num - rectangleF.Top;
				rectangleF.Y = (float)num;
			}
			while (this.printSection < this.sections.Count)
			{
				if (this.printSection < this.sections.Count - 1 || this.printGrades)
				{
					ConsultantReportSection consultantReportSection = (ConsultantReportSection)this.sections[this.printSection];
					int num2 = consultantReportSection.PrintHeight((int)rectangleF.Width, graphics, this.printGrades);
					if ((float)num2 >= rectangleF.Height)
					{
						break;
					}
					consultantReportSection.Print((int)rectangleF.X, (int)rectangleF.Y, (int)rectangleF.Width, graphics, this.printGrades);
					rectangleF.Y += (float)num2;
					rectangleF.Height -= (float)num2;
				}
				if (this.printFull)
				{
					this.printSection++;
				}
				else
				{
					this.printSection = int.MaxValue;
				}
			}
			this.printPage++;
			e.HasMorePages = (this.printSection < this.sections.Count);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003FF4 File Offset: 0x00002FF4
		protected int PrintHeader(int left, int top, int width, Graphics g)
		{
			Font font = new Font("Arial", 14f, FontStyle.Bold);
			Font font2 = new Font("Arial", 13f, FontStyle.Bold);
			Brush brush = new SolidBrush(Color.Black);
			SizeF sizeF = g.MeasureString("Virtual Consulting, LLC", font, width);
			g.DrawString("Virtual Consulting, LLC", font, brush, new RectangleF((float)(left + width) - sizeF.Width, (float)top, (float)width, 1000f));
			g.DrawLine(new Pen(brush, 3f), new PointF((float)left, (float)top + sizeF.Height / 2f), new PointF((float)(left + width) - sizeF.Width - 10f, (float)top + sizeF.Height / 2f));
			int num = top + ((int)sizeF.Height + 10);
			string text = "Subject: " + this.reportTitle + "\r\nDate: " + this.Date.ToLongDateString();
			sizeF = g.MeasureString(text, font2, width);
			g.DrawString(text, font2, brush, new RectangleF((float)left, (float)num, (float)width, 1000f));
			num += (int)sizeF.Height + 10;
			g.DrawLine(new Pen(brush, 1f), new PointF((float)left, (float)num), new PointF((float)left + sizeF.Width, (float)num));
			return num + 20;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000415C File Offset: 0x0000315C
		protected int PrintLead(int left, int top, int width, Graphics g, string lead)
		{
			Font font = new Font("Arial", 11f);
			Brush brush = new SolidBrush(Color.Black);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Trimming = StringTrimming.Word;
			g.DrawString(lead, font, brush, new RectangleF((float)left, (float)top, (float)width, 1000f), stringFormat);
			return top + (int)g.MeasureString(lead, font, width, stringFormat).Height + 10;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000041D0 File Offset: 0x000031D0
		public string RenderTextAsHTML()
		{
			return "";
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000041E8 File Offset: 0x000031E8
		public string RenderGradesAsHTML()
		{
			return "";
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00004200 File Offset: 0x00003200
		public ArrayList Sections
		{
			get
			{
				return this.sections;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004218 File Offset: 0x00003218
		protected void AddOverallGradeSection()
		{
			float num = 0f;
			foreach (object obj in this.sections)
			{
				ConsultantReportSection consultantReportSection = (ConsultantReportSection)obj;
				num += consultantReportSection.Grade;
			}
			ConsultantReportSection consultantReportSection2 = new ConsultantReportSection();
			consultantReportSection2.Topic = "Overall Grade";
			consultantReportSection2.Finding = "Your overall grade based on all the elements I analyzed is shown below.";
			num = (consultantReportSection2.Grade = num / (float)this.sections.Count);
			this.sections.Add(consultantReportSection2);
		}

		// Token: 0x0400000B RID: 11
		public DateTime Date;

		// Token: 0x0400000C RID: 12
		public string EntityName;

		// Token: 0x0400000D RID: 13
		private int printSection;

		// Token: 0x0400000E RID: 14
		private int printPage;

		// Token: 0x0400000F RID: 15
		private bool printFull;

		// Token: 0x04000010 RID: 16
		private bool printGrades;

		// Token: 0x04000011 RID: 17
		protected string printLead;

		// Token: 0x04000012 RID: 18
		protected ArrayList sections = new ArrayList();

		// Token: 0x04000013 RID: 19
		protected string reportTitle = "";

		// Token: 0x04000014 RID: 20
		protected ConsultantReportSection worstSection;

		// Token: 0x02000007 RID: 7
		protected class GradeComparer : IComparer
		{
			// Token: 0x0600002C RID: 44 RVA: 0x000042DC File Offset: 0x000032DC
			public int Compare(object x, object y)
			{
				int result;
				if (((ConsultantReportSection)x).Grade < ((ConsultantReportSection)y).Grade)
				{
					result = -1;
				}
				else if (((ConsultantReportSection)x).Grade > ((ConsultantReportSection)y).Grade)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}
	}
}
