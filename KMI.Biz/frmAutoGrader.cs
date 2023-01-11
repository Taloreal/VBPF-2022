using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000004 RID: 4
	public partial class frmAutoGrader : frmDrawnReport
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002E29 File Offset: 0x00001E29
		public frmAutoGrader()
		{
			this.InitializeComponent();
			this.picReport.Parent.BackColor = Color.White;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002E58 File Offset: 0x00001E58
		protected override void GetDataVirtual()
		{
			this.reports = ((BizStateAdapter)Simulator.Instance.SimStateAdapter).GetGrades(frmMainBase.Instance.CurrentEntityID);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002E80 File Offset: 0x00001E80
		protected override void DrawReportVirtual(Graphics g)
		{
			int num = 1;
			if (this.reports.Length > 1)
			{
				num = this.reports.Length + 1;
			}
			int count = this.reports[0].Sections.Count;
			int num2 = 220;
			int num3 = 90;
			int num4 = 90;
			int num5 = 30;
			Brush brush = new SolidBrush(Color.Black);
			Pen pen = new Pen(brush, 1f);
			Pen pen2 = new Pen(new SolidBrush(Color.DarkGray), 1f);
			Font font = new Font("Arial", 14f);
			Font font2 = new Font("Arial", 10f);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Far;
			for (int i = 0; i < count + 1; i++)
			{
				int num6 = frmAutoGrader.margin + num4 + i * num5;
				g.DrawLine(pen, new Point(frmAutoGrader.margin, num6), new Point(frmAutoGrader.margin + num2 + num * num3, num6));
				if (i < count)
				{
					g.DrawString(((ConsultantReportSection)this.reports[0].Sections[i]).Topic, font, brush, (float)frmAutoGrader.margin, (float)(num6 + 5));
				}
			}
			g.DrawLine(pen, new Point(frmAutoGrader.margin, frmAutoGrader.margin + num4), new Point(frmAutoGrader.margin, frmAutoGrader.margin + num4 + num5 * count));
			for (int j = 0; j < num + 1; j++)
			{
				int num7 = frmAutoGrader.margin + num2 + j * num3;
				g.DrawLine(pen, new Point(num7, frmAutoGrader.margin + num4), new Point(num7, frmAutoGrader.margin + num4 + num5 * count));
				if (j < num)
				{
					g.DrawLine(pen2, new Point(num7 + num3 / 2, frmAutoGrader.margin + num4), new Point(num7 + num3 / 2, frmAutoGrader.margin + num4 + num5 * count));
					string s = "Average";
					if (j < num - 1 || (j == 0 && num == 1))
					{
						s = this.reports[j].EntityName;
					}
					g.TranslateTransform((float)(num7 + num3 / 2), (float)(frmAutoGrader.margin + num4 - 20));
					g.RotateTransform(-58f);
					g.DrawString(s, font, brush, 0f, 0f);
					g.RotateTransform(58f);
					g.TranslateTransform((float)(-(float)(num7 + num3 / 2)), (float)(-(float)(frmAutoGrader.margin + num4 - 20)));
				}
				g.DrawLine(pen, new Point(num7, frmAutoGrader.margin + num4), new Point(num7 + 2 * num3 / 3, frmAutoGrader.margin));
			}
			for (int i = 0; i < count; i++)
			{
				float num8 = 0f;
				int num6 = frmAutoGrader.margin + num4 + i * num5 + 7;
				for (int j = 0; j < num; j++)
				{
					string str = "";
					float num9;
					if (j < num - 1 || (j == 0 && num == 1))
					{
						num9 = ((ConsultantReportSection)this.reports[j].Sections[i]).Grade;
						num8 += num9 / (float)(num - 1);
					}
					else
					{
						num9 = num8;
						if (i == count - 1 && num > 1)
						{
							num9 = Math.Min(1f, num9 + frmAutoGrader.ExtraPointsPerEntity * (float)(num - 2));
							g.DrawString(S.R.GetString("* Includes {0} points for each additional {1} managed.", new object[]
							{
								(int)(frmAutoGrader.ExtraPointsPerEntity * 100f),
								S.I.EntityName.ToLower()
							}), font2, brush, (float)frmAutoGrader.margin, (float)(num6 + 30));
							str = "*";
						}
						if (i == count - 1)
						{
							g.DrawString(frmAutoGrader.Notes, font2, brush, (float)frmAutoGrader.margin, (float)(num6 + 45));
						}
					}
					if (j != 1 || num != 1)
					{
						int num7 = frmAutoGrader.margin + num2 + j * num3 + num3 / 2 - 2;
						g.DrawString(Utilities.FP(num9) + str, font2, brush, (float)num7, (float)num6, stringFormat);
						g.DrawString(this.LetterGrade(num9), font2, brush, (float)(num7 + num3 / 2 - 12), (float)num6, stringFormat);
					}
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003344 File Offset: 0x00002344
		private string LetterGrade(float f)
		{
			string result;
			if ((double)f < 0.6)
			{
				result = "F";
			}
			else if ((double)f < 0.7)
			{
				result = "D";
			}
			else if ((double)f < 0.8)
			{
				result = "C";
			}
			else if ((double)f < 0.9)
			{
				result = "B";
			}
			else
			{
				result = "A";
			}
			return result;
		}

		// Token: 0x04000007 RID: 7
		private ConsultantReport[] reports = null;

		// Token: 0x04000008 RID: 8
		public static float ExtraPointsPerEntity = 0.05f;

		// Token: 0x04000009 RID: 9
		public static string Notes = "Note: Use Actions->Consultant for critique of each topic.";

		// Token: 0x0400000A RID: 10
		public static int margin = 16;
	}
}
