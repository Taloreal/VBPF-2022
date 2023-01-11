using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200003E RID: 62
	public partial class frmActionsJournal : Form
	{
		// Token: 0x0600025C RID: 604 RVA: 0x000136F8 File Offset: 0x000126F8
		public frmActionsJournal(bool showGraph)
		{
			this.InitializeComponent();
			this.panGraph.Visible = showGraph;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00013720 File Offset: 0x00012720
		protected void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00013744 File Offset: 0x00012744
		// (set) Token: 0x0600025F RID: 607 RVA: 0x0001375C File Offset: 0x0001275C
		public MenuItem EnablingReference
		{
			get
			{
				return this.enablingReference;
			}
			set
			{
				this.enablingReference = value;
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00013768 File Offset: 0x00012768
		protected void EntityChangedHandler(object sender, EventArgs e)
		{
			if (!this.enablingReference.Enabled)
			{
				base.Close();
			}
			else if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000137A4 File Offset: 0x000127A4
		protected bool GetData()
		{
			try
			{
				if (!S.I.Client && S.I.Multiplayer)
				{
					this.input = S.SA.getActionsJournal(-1L);
				}
				else
				{
					this.input = S.SA.getActionsJournal(S.MF.CurrentEntityID);
				}
				this.journals = this.input.Journals;
				if (this.journals.Count == 1)
				{
					this.Text = "Actions Journal for " + S.MF.EntityIDToName(S.MF.CurrentEntityID);
				}
				this.startDate = this.input.StartDate;
				this.LoadNumericDataSeriesNames();
				this.mergedEntries = new ArrayList();
				foreach (object obj in this.journals)
				{
					Journal journal = (Journal)obj;
					foreach (object obj2 in journal.Entries)
					{
						JournalEntry journalEntry = (JournalEntry)obj2;
						for (int i = this.mergedEntries.Count - 1; i >= -1; i--)
						{
							if (i == -1)
							{
								this.mergedEntries.Insert(0, journalEntry);
								break;
							}
							if (journalEntry.TimeStamp >= ((JournalEntry)this.mergedEntries[i]).TimeStamp)
							{
								this.mergedEntries.Insert(i + 1, journalEntry);
								break;
							}
						}
					}
				}
				this.useEntries = this.mergedEntries;
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
			return true;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00013A08 File Offset: 0x00012A08
		protected void UpdateForm()
		{
			try
			{
				this.UpdateActions();
				this.UpdateGraph();
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000142B0 File Offset: 0x000132B0
		private void UpdateActions()
		{
			this.txtEntries.Text = "";
			foreach (object obj in this.useEntries)
			{
				JournalEntry journalEntry = (JournalEntry)obj;
				TextBox textBox = this.txtEntries;
				textBox.Text = textBox.Text + string.Format("{0:dd MMM yy}", journalEntry.TimeStamp) + ": ";
				if (this.journals.Count != 1)
				{
					TextBox textBox2 = this.txtEntries;
					textBox2.Text = textBox2.Text + journalEntry.EntityName + " - ";
				}
				TextBox textBox3 = this.txtEntries;
				textBox3.Text = textBox3.Text + journalEntry.Description + "\r\n";
			}
			this.ScrollToEnd();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000143B4 File Offset: 0x000133B4
		protected virtual void LoadNumericDataSeriesNames()
		{
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000143B8 File Offset: 0x000133B8
		protected virtual void UpdateGraph()
		{
			if (this.panGraph.Visible)
			{
				Journal journal = (Journal)this.journals[0];
				if (this.journals.Count == 1)
				{
					this.kmiGraph1.Title = Journal.JournalSeriesName;
					this.kmiGraph1.Legend = false;
				}
				else
				{
					this.kmiGraph1.Title = Journal.ScoreSeriesName;
					this.kmiGraph1.Legend = true;
				}
				this.kmiGraph1.TitleFontSize = 8f;
				this.kmiGraph1.AxisLabelFontSize = 8f;
				this.kmiGraph1.GraphType = 1;
				int num = 0;
				foreach (object obj in this.journals)
				{
					Journal journal2 = (Journal)obj;
					if (journal2.Periods > num)
					{
						num = journal2.Periods;
					}
				}
				object[,] array = new object[this.journals.Count + 1, num + 1];
				for (int i = 0; i < array.GetUpperBound(1); i++)
				{
					array[0, i + 1] = this.startDate.AddDays((double)((float)i * journal.DaysPerPeriod));
				}
				int num2 = 0;
				foreach (object obj2 in this.journals)
				{
					Journal journal2 = (Journal)obj2;
					array[num2 + 1, 0] = journal2.EntityName;
					ArrayList arrayList = journal2.NumericDataSeries(this.kmiGraph1.Title);
					for (int j = 0; j < arrayList.Count; j++)
					{
						array[num2 + 1, j + 1] = arrayList[j];
					}
					num2++;
				}
				this.kmiGraph1.Draw(array);
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0001460C File Offset: 0x0001360C
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00014618 File Offset: 0x00013618
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.studentName = "";
			frmInputString frmInputString = new frmInputString(S.R.GetString("Student Name"), S.R.GetString("Enter your name to help identify your printout on a shared printer:"), this.studentName);
			frmInputString.ShowDialog(this);
			this.studentName = frmInputString.Response;
			this.printEntry = 0;
			this.printPage = 1;
			Utilities.PrintWithExceptionHandling("", new PrintPageEventHandler(this.Journal_PrintPage));
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00014694 File Offset: 0x00013694
		private void Journal_PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			Font font = new Font("Arial", 12f);
			Brush brush = new SolidBrush(Color.Black);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Trimming = StringTrimming.Word;
			StringFormat stringFormat2 = new StringFormat();
			stringFormat2.Alignment = StringAlignment.Center;
			string text = "\r\n";
			string[] array = new string[]
			{
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G"
			};
			Graphics graphics = e.Graphics;
			RectangleF layoutRectangle = new RectangleF((float)e.MarginBounds.Left, (float)e.MarginBounds.Top, (float)e.MarginBounds.Width, (float)e.MarginBounds.Height);
			string text2;
			if (this.printPage == 1)
			{
				text2 = this.Text + S.R.GetString(" -  Submitted by ") + this.studentName;
			}
			else
			{
				text2 = this.Text + " (continued)";
			}
			text2 = text2 + text + text;
			graphics.DrawString(text2, font, brush, (float)e.MarginBounds.Left, layoutRectangle.Top, stringFormat);
			layoutRectangle.Y += graphics.MeasureString(text2, font, (int)layoutRectangle.Width, stringFormat).Height;
			layoutRectangle.Height -= graphics.MeasureString(text2, font, (int)layoutRectangle.Width, stringFormat).Height;
			while (this.printEntry < this.useEntries.Count)
			{
				JournalEntry journalEntry = (JournalEntry)this.useEntries[this.printEntry];
				string text3 = string.Format("{0:dd MMM yy}", journalEntry.TimeStamp) + ": ";
				if (this.journals.Count != 1)
				{
					text3 = text3 + journalEntry.EntityName + " - ";
				}
				text3 = text3 + journalEntry.Description + text;
				SizeF sizeF = graphics.MeasureString(text3, font, (int)layoutRectangle.Width, stringFormat);
				if (sizeF.Height >= layoutRectangle.Height)
				{
					break;
				}
				graphics.DrawString(text3, font, brush, layoutRectangle, stringFormat);
				layoutRectangle.Y += sizeF.Height;
				layoutRectangle.Height -= sizeF.Height;
				this.printEntry++;
			}
			this.printPage++;
			e.HasMorePages = (this.printEntry < this.useEntries.Count);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00014991 File Offset: 0x00013991
		private void frmActionsJournal_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			S.MF.EntityChanged -= this.EntityChangedHandler;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000149C2 File Offset: 0x000139C2
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(S.R.GetString("Actions Journal"));
		}

		// Token: 0x0600026D RID: 621 RVA: 0x000149DC File Offset: 0x000139DC
		private void frmActionsJournal_Load(object sender, EventArgs e)
		{
			if (this.EnablingReference == null)
			{
				throw new Exception("Enabling reference not set in " + this.Text);
			}
			S.MF.NewWeek += this.NewWeekHandler;
			S.MF.EntityChanged += this.EntityChangedHandler;
			if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00014A52 File Offset: 0x00013A52
		protected void ScrollToEnd()
		{
			this.txtEntries.Focus();
			this.txtEntries.Select(Math.Max(0, this.txtEntries.TextLength - 2), 0);
			this.txtEntries.ScrollToCaret();
		}

		// Token: 0x04000187 RID: 391
		protected MenuItem enablingReference;

		// Token: 0x04000188 RID: 392
		protected ArrayList journals;

		// Token: 0x04000189 RID: 393
		protected ArrayList mergedEntries;

		// Token: 0x0400018A RID: 394
		protected ArrayList useEntries;

		// Token: 0x0400018B RID: 395
		protected DateTime startDate;

		// Token: 0x0400018C RID: 396
		private frmActionsJournal.Input input;

		// Token: 0x0400018D RID: 397
		private string studentName;

		// Token: 0x0400018E RID: 398
		private int printEntry;

		// Token: 0x0400018F RID: 399
		private int printPage;

		// Token: 0x0200003F RID: 63
		[Serializable]
		public struct Input
		{
			// Token: 0x04000190 RID: 400
			public ArrayList Journals;

			// Token: 0x04000191 RID: 401
			public DateTime StartDate;

			// Token: 0x04000192 RID: 402
			public DateTime EndDate;
		}
	}
}
