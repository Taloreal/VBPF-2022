using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000061 RID: 97
	public partial class frmScoreboard : Form
	{
		// Token: 0x060003A1 RID: 929 RVA: 0x0001A26A File Offset: 0x0001926A
		public frmScoreboard()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0001A27C File Offset: 0x0001927C
		protected void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.SetYScale();
				this.UpdateForm();
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0001A2A8 File Offset: 0x000192A8
		protected bool GetData()
		{
			try
			{
				this.input = S.SA.getScoreboard(frmScoreboard.ShowAIOwnedEntities);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
			return true;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0001AADC File Offset: 0x00019ADC
		protected virtual void UpdateForm()
		{
			try
			{
				if (this.input.Scores.Length == 0)
				{
					this.kmiGraph1.Visible = false;
				}
				else
				{
					this.kmiGraph1.Visible = true;
					this.UpdateForm(this.input.Scores[0].Count - 1);
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0001AB5C File Offset: 0x00019B5C
		protected virtual void UpdateForm(int index)
		{
			try
			{
				if (index >= 0)
				{
					object[,] array = new object[this.input.EntityNames.Length + 1, 2];
					for (int i = 0; i < this.input.EntityNames.Length; i++)
					{
						if (index >= this.input.Scores[i].Count)
						{
							return;
						}
						array[i + 1, 0] = this.input.EntityNames[i];
						array[i + 1, 1] = (float)this.input.Scores[i][index];
					}
					this.kmiGraph1.Draw(array);
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0001AC38 File Offset: 0x00019C38
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0001AC44 File Offset: 0x00019C44
		private void frmScoreboard_Resize(object sender, EventArgs e)
		{
			float num = Math.Min((float)base.Size.Width / 264f, (float)base.Size.Height / 280f);
			num = Math.Max(1f, num);
			this.kmiGraph1.TitleFontSize = num * 14f;
			this.kmiGraph1.DataPointLabelFontSize = num * 9f;
			this.kmiGraph1.LegendFontSize = num * 9f;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0001ACC7 File Offset: 0x00019CC7
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.kmiGraph1.Title = this.Text;
			this.kmiGraph1.PrintGraph();
			this.kmiGraph1.Title = "";
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0001ACFC File Offset: 0x00019CFC
		private void btnReplay_Click(object sender, EventArgs e)
		{
			if (this.btnReplay.Text == "Stop")
			{
				this.timer1.Stop();
				this.btnReplay.Text = "Replay";
				this.UpdateForm();
			}
			else
			{
				this.step = 0;
				this.btnReplay.Text = "Stop";
				this.timer1.Start();
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0001AD74 File Offset: 0x00019D74
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.input.Scores.Length == 0)
			{
				this.btnReplay.PerformClick();
			}
			else if (this.step < this.input.Scores[0].Count)
			{
				this.UpdateForm(this.step++);
			}
			else
			{
				this.timer1.Stop();
				this.btnReplay.Text = "Replay";
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0001AE04 File Offset: 0x00019E04
		protected void SetYScale()
		{
			float num = (float)frmScoreboard.DefaultInitialScoreScale;
			float num2 = 0f;
			for (int i = 0; i < this.input.Scores.Length; i++)
			{
				foreach (object obj in this.input.Scores[i])
				{
					float val = (float)obj;
					num = Math.Max(val, num);
					num2 = Math.Min(val, num2);
				}
			}
			this.kmiGraph1.YMax = num;
			this.kmiGraph1.YMin = num2;
			this.kmiGraph1.AutoScaleY = false;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0001AEDC File Offset: 0x00019EDC
		private void frmScoreboard_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			if (frmScoreboard.UpdateDaily)
			{
				S.MF.NewDay -= this.NewWeekHandler;
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0001AF24 File Offset: 0x00019F24
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Scoreboard");
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0001AF34 File Offset: 0x00019F34
		private void frmScoreboard_Load(object sender, EventArgs e)
		{
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.Legend = false;
			this.kmiGraph1.GraphType = 5;
			S.MF.NewWeek += this.NewWeekHandler;
			if (frmScoreboard.UpdateDaily)
			{
				S.MF.NewDay += this.NewWeekHandler;
			}
			if (this.GetData())
			{
				this.Text = "Scoreboard - " + this.input.ScoreFriendlyName;
				this.SetYScale();
				this.UpdateForm();
			}
		}

		// Token: 0x0400024D RID: 589
		protected const int DefaultTitleFontSize = 14;

		// Token: 0x0400024E RID: 590
		protected const int DefaultLegendFontSize = 9;

		// Token: 0x0400024F RID: 591
		protected const int DataPointLabelFontSize = 9;

		// Token: 0x04000250 RID: 592
		protected const int DefaultFormWidth = 264;

		// Token: 0x04000251 RID: 593
		protected const int DefaultFormHeight = 280;

		// Token: 0x0400025C RID: 604
		private frmScoreboard.Input input;

		// Token: 0x0400025D RID: 605
		private int step;

		// Token: 0x0400025E RID: 606
		public static int DefaultInitialScoreScale = 50000;

		// Token: 0x0400025F RID: 607
		public static bool ShowAIOwnedEntities = true;

		// Token: 0x04000260 RID: 608
		public static bool UpdateDaily = false;

		// Token: 0x02000062 RID: 98
		[Serializable]
		public struct Input
		{
			// Token: 0x04000261 RID: 609
			public string[] EntityNames;

			// Token: 0x04000262 RID: 610
			public ArrayList[] Scores;

			// Token: 0x04000263 RID: 611
			public string ScoreFriendlyName;
		}
	}
}
