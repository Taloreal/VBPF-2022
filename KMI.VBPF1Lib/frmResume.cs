using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmResume.
	/// </summary>
	// Token: 0x0200002E RID: 46
	public partial class frmResume : frmDrawnReport
	{
		// Token: 0x0600017D RID: 381 RVA: 0x0001915D File Offset: 0x0001815D
		public frmResume()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00019177 File Offset: 0x00018177
		protected override void GetDataVirtual()
		{
			this.input = A.SA.GetResume(A.MF.CurrentEntityID);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00019194 File Offset: 0x00018194
		protected override void DrawReportVirtual(Graphics g)
		{
			frmResume.sfc.Alignment = StringAlignment.Center;
			frmResume.sfr.Alignment = StringAlignment.Far;
			int y = this.margin;
			g.DrawString(this.input.Name, frmResume.fontLLB, frmResume.brush, g.ClipBounds.Width / 2f, (float)y, frmResume.sfc);
			y += 35;
			g.DrawString(A.R.GetString("EDUCATION"), frmResume.fontLB, frmResume.brush, (float)this.margin, (float)y);
			y += 35;
			for (int i = this.input.AcademicTaskHistory.Count - 1; i >= 0; i--)
			{
				AttendClass t = (AttendClass)this.input.AcademicTaskHistory.GetByIndex(i);
				g.DrawString(t.Course.Name, frmResume.fontB, frmResume.brush, (float)this.margin, (float)y);
				string end = t.EndDate.ToString("MMM yyyy");
				g.DrawString(A.R.GetString("{0}-{1}", new object[]
				{
					t.StartDate.ToString("MMM yyyy"),
					end
				}), frmResume.fontB, frmResume.brush, g.ClipBounds.Width - (float)this.margin, (float)y, frmResume.sfr);
				y += 20;
				g.DrawString(t.Course.ResumeDescription, frmResume.font, frmResume.brush, new RectangleF((float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 1000f));
				y += (int)g.MeasureString(t.Course.ResumeDescription, frmResume.font, (int)g.ClipBounds.Width - 2 * this.margin).Height;
				y += 25;
			}
			y += 35;
			g.DrawString(A.R.GetString("EXPERIENCE"), frmResume.fontLB, frmResume.brush, (float)this.margin, (float)y);
			y += 30;
			for (int i = this.input.WorkTaskHistory.Count - 1; i >= 0; i--)
			{
				WorkTask t2 = (WorkTask)this.input.WorkTaskHistory.GetByIndex(i);
				g.DrawString(t2.Name(), frmResume.fontB, frmResume.brush, (float)this.margin, (float)y);
				string end = t2.EndDate.ToString("MMM yyyy");
				if (t2.EndDate == DateTime.MinValue)
				{
					end = A.R.GetString("Present");
				}
				g.DrawString(A.R.GetString("{0}-{1}", new object[]
				{
					t2.StartDate.ToString("MMM yyyy"),
					end
				}), frmResume.fontB, frmResume.brush, g.ClipBounds.Width - (float)this.margin, (float)y, frmResume.sfr);
				y += 20;
				g.DrawString(t2.ResumeDescription(), frmResume.font, frmResume.brush, new RectangleF((float)this.margin, (float)y, g.ClipBounds.Width - (float)(2 * this.margin), 1000f));
				y += (int)g.MeasureString(t2.ResumeDescription(), frmResume.font, (int)g.ClipBounds.Width - 2 * this.margin).Height;
				y += 25;
			}
			if (y > this.picReport.Height)
			{
				this.picReport.Height = y + 25;
			}
		}

		// Token: 0x0400017E RID: 382
		private frmResume.Input input;

		// Token: 0x0400017F RID: 383
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x04000180 RID: 384
		protected static Font fontB = new Font("Arial", 9f, FontStyle.Bold);

		// Token: 0x04000181 RID: 385
		protected static Font fontLB = new Font("Arial", 10f, FontStyle.Bold);

		// Token: 0x04000182 RID: 386
		protected static Font fontLLB = new Font("Arial", 12f, FontStyle.Bold);

		// Token: 0x04000183 RID: 387
		protected static Font bankNameFont = new Font("Times New Roman", 16f, FontStyle.Italic);

		// Token: 0x04000184 RID: 388
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x04000185 RID: 389
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x04000186 RID: 390
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x04000187 RID: 391
		protected static Pen pen = new Pen(frmResume.brush, 1f);

		// Token: 0x04000188 RID: 392
		protected int margin = 16;

		// Token: 0x0200002F RID: 47
		[Serializable]
		public struct Input
		{
			// Token: 0x04000189 RID: 393
			public string Name;

			// Token: 0x0400018A RID: 394
			public SortedList WorkTaskHistory;

			// Token: 0x0400018B RID: 395
			public SortedList AcademicTaskHistory;
		}
	}
}
