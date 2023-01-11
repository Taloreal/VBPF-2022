using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000002 RID: 2
	public partial class frmViewComments : frmDrawnReport
	{
		// Token: 0x06000002 RID: 2 RVA: 0x000022DF File Offset: 0x000012DF
		public frmViewComments()
		{
			this.InitializeComponent();
			frmMainBase.Instance.NewDay += this.NewWeekHandler;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002317 File Offset: 0x00001317
		protected void ReportUpdateHandler(object sender, EventArgs e)
		{
			base.GetData();
			this.printStartIndex = 0;
			this.picReport.Refresh();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002334 File Offset: 0x00001334
		protected override void btnPrint_Click(object sender, EventArgs e)
		{
			this.printStartIndex = 0;
			this.studentName = "";
			frmInputString frmInputString = new frmInputString(S.R.GetString("Student Name"), S.R.GetString("Enter your name to help identify your printout on a shared printer:"), this.studentName);
			frmInputString.ShowDialog(this);
			this.studentName = frmInputString.Response;
			Utilities.PrintWithExceptionHandling("", new PrintPageEventHandler(this.Report_PrintPage));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000023AC File Offset: 0x000013AC
		protected override void Report_PrintPage(object sender, PrintPageEventArgs e)
		{
			this.printArgs = e;
			Utilities.ResetFPU();
			if (this.studentName.Length > 0)
			{
				Font font = new Font("Arial", 10f);
				Brush brush = new SolidBrush(Color.Black);
				e.Graphics.DrawString(S.R.GetString("This report belongs to: {0}", new object[]
				{
					this.studentName
				}), font, brush, 0f, 0f);
				e.Graphics.TranslateTransform(0f, 2f * e.Graphics.MeasureString(this.studentName, font).Height);
			}
			base.DrawReport(e.Graphics);
			this.printArgs = null;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000247C File Offset: 0x0000147C
		protected override void DrawReportVirtual(Graphics g)
		{
			int num = 0;
			bool flag = num >= this.printStartIndex;
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Far;
			int num2 = 0;
			int num3 = 0;
			ArrayList comments = this.input.Comments;
			DateTime dateTime = this.input.StartDate.AddDays((double)(this.index + this.input.FrequencyInDays));
			DateTime dateTime2 = this.input.StartDate.AddDays((double)((this.index + 2) * this.input.FrequencyInDays));
			num2 = 8;
			if (this.input.FrequencyInDays <= 1)
			{
				if (flag)
				{
					g.DrawString(Simulator.Instance.Resource.GetString("Comments for {0}", new object[]
					{
						dateTime.AddDays(-1.0).ToString("MMMM d, yyyy")
					}), new Font("Arial", 10f, FontStyle.Bold), Brushes.Black, new RectangleF((float)num3, (float)num2, (float)(this.picReport.Width - 1), 32f));
				}
			}
			else if (flag)
			{
				g.DrawString(Simulator.Instance.Resource.GetString("Comments for the period {0} - {1}", new object[]
				{
					dateTime.ToString("MMMM d, yyyy"),
					dateTime2.ToString("MMMM d, yyyy")
				}), new Font("Arial", 10f, FontStyle.Bold), Brushes.Black, new RectangleF((float)num3, (float)num2, (float)(this.picReport.Width - 1), 32f));
			}
			num2 = 40;
			Hashtable hashtable = (Hashtable)comments[this.index];
			foreach (object obj in hashtable)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key.ToString();
				if (text.Length > 0)
				{
					num3 = 8;
					if (flag)
					{
						g.DrawString(text, new Font("Arial", 10f, FontStyle.Bold), Brushes.Black, new RectangleF((float)num3, (float)num2, (float)(this.picReport.Width - 1), 32f));
					}
					num2 += 16;
				}
				Hashtable hashtable2 = (Hashtable)dictionaryEntry.Value;
				foreach (object obj2 in hashtable2)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					string text2 = dictionaryEntry2.Key.ToString();
					if (text2.Length > 0)
					{
						num3 = 16;
						if (flag)
						{
							g.DrawString(text2, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, new RectangleF((float)num3, (float)num2, (float)(this.picReport.Width - 1), 32f));
						}
						num2 += 16;
					}
					Hashtable hashtable3 = (Hashtable)dictionaryEntry2.Value;
					ArrayList arrayList = new ArrayList();
					foreach (object obj3 in hashtable3)
					{
						DictionaryEntry dictionaryEntry3 = (DictionaryEntry)obj3;
						arrayList.Add(dictionaryEntry3);
					}
					arrayList.Sort(new frmViewComments.PairComparer());
					foreach (object obj4 in arrayList)
					{
						DictionaryEntry dictionaryEntry4 = (DictionaryEntry)obj4;
						num3 = 32;
						if (flag)
						{
							g.DrawString("(" + dictionaryEntry4.Value + ")", new Font("Arial", 8.25f), Brushes.Black, new RectangleF((float)num3, (float)num2, 40f, 30f), stringFormat);
						}
						num3 = 75;
						SizeF sizeF = g.MeasureString(dictionaryEntry4.Key.ToString(), new Font("Arial", 8.25f), new SizeF((float)(this.picReport.Width - 1 - num3 - 16), (float)(this.picReport.Height - 1)));
						if (flag)
						{
							g.DrawString(dictionaryEntry4.Key.ToString(), new Font("Arial", 8.25f), Brushes.Black, new RectangleF((float)num3, (float)num2, sizeF.Width, sizeF.Height));
						}
						num2 += 5 + (int)sizeF.Height;
						num++;
						bool flag2 = flag;
						flag = (num >= this.printStartIndex);
						if (flag2 != flag)
						{
							num2 = 0;
						}
						if (this.printArgs != null && flag)
						{
							if (num2 >= this.printArgs.PageSettings.Bounds.Height - 200)
							{
								this.printStartIndex = num;
								num2 = 0;
								this.printArgs.HasMorePages = true;
								return;
							}
						}
					}
					num2 += 16;
				}
			}
			this.picReport.Height = num2 + 48;
			if (this.printArgs != null)
			{
				this.printArgs.HasMorePages = false;
				this.printStartIndex = 0;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002AB8 File Offset: 0x00001AB8
		protected override void GetDataVirtual()
		{
			this.input = ((BizStateAdapter)Simulator.Instance.SimStateAdapter).GetComments(frmMainBase.Instance.CurrentEntityID);
			this.index = this.input.Comments.Count - 2;
			this.btnNext.Enabled = false;
			this.btnBack.Enabled = false;
			if (this.input.Comments.Count > 2)
			{
				this.btnBack.Enabled = true;
			}
			this.printStartIndex = 0;
			this.picReport.Refresh();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002B56 File Offset: 0x00001B56
		protected override void frmReport_Closed(object sender, EventArgs e)
		{
			base.frmReport_Closed(sender, e);
			frmMainBase.Instance.NewDay -= this.NewWeekHandler;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002B7A File Offset: 0x00001B7A
		private void frmViewComments_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002B7D File Offset: 0x00001B7D
		protected override void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002B8C File Offset: 0x00001B8C
		private void btnNext_Click(object sender, EventArgs e)
		{
			this.index++;
			this.btnBack.Enabled = false;
			this.btnNext.Enabled = false;
			if (this.index > 1 && this.input.Comments[this.index - 1] != null)
			{
				this.btnBack.Enabled = true;
			}
			if (this.index < this.input.Comments.Count - 2)
			{
				this.btnNext.Enabled = true;
			}
			this.printStartIndex = 0;
			this.picReport.Refresh();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002C3C File Offset: 0x00001C3C
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.index--;
			this.btnBack.Enabled = false;
			this.btnNext.Enabled = false;
			if (this.index > 1 && this.input.Comments[this.index - 1] != null)
			{
				this.btnBack.Enabled = true;
			}
			if (this.index < this.input.Comments.Count - 2)
			{
				this.btnNext.Enabled = true;
			}
			this.printStartIndex = 0;
			this.picReport.Refresh();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002CEB File Offset: 0x00001CEB
		private void picReport_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x04000003 RID: 3
		private CommentLog input;

		// Token: 0x04000004 RID: 4
		private int index = 0;

		// Token: 0x04000005 RID: 5
		private int printStartIndex = 0;

		// Token: 0x04000006 RID: 6
		private PrintPageEventArgs printArgs;

		// Token: 0x02000003 RID: 3
		private class PairComparer : IComparer
		{
			// Token: 0x0600000E RID: 14 RVA: 0x00002CF0 File Offset: 0x00001CF0
			public int Compare(object x, object y)
			{
				return (int)((DictionaryEntry)y).Value - (int)((DictionaryEntry)x).Value;
			}
		}
	}
}
