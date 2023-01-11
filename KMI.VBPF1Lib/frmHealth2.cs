using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmHealth2.
	/// </summary>
	// Token: 0x0200003E RID: 62
	public partial class frmHealth2 : frmDrawnReport
	{
		// Token: 0x060001CF RID: 463 RVA: 0x0001CFDB File Offset: 0x0001BFDB
		public frmHealth2()
		{
			this.InitializeComponent();
			A.MF.NewDay += this.NewDayHandler;
			this.Text = A.R.GetString("Health");
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0001D0D8 File Offset: 0x0001C0D8
		protected override void DrawReportVirtual(Graphics g)
		{
			int i = 0;
			float total = 0f;
			foreach (string name in AppConstants.HealthFactorNames)
			{
				if (i < this.healthFactors.Length)
				{
					float score = this.healthFactors[i];
					this.DrawScore(g, A.R.GetString(name), 35 + i * 20, score);
					total += score;
					i++;
				}
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0001D15C File Offset: 0x0001C15C
		protected void DrawScore(Graphics g, string name, int y, float score)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawString(A.R.GetString("Worst"), frmHealth2.fontB, frmHealth2.brush, 76f, 0f);
			g.DrawString(A.R.GetString("Best"), frmHealth2.fontB, frmHealth2.brush, 220f, 0f);
			Brush b = new SolidBrush(Color.Green);
			if ((double)score < 0.1)
			{
				b = new SolidBrush(Color.Red);
			}
			else if ((double)score < 0.66)
			{
				b = new SolidBrush(Color.Yellow);
			}
			g.DrawString(name, frmHealth2.font, frmHealth2.brush, 0f, (float)y);
			g.FillRectangle(b, 100f, (float)y, 5f + score * 130f, 14f);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0001D24E File Offset: 0x0001C24E
		protected override void GetDataVirtual()
		{
			this.healthFactors = A.SA.GetHealth(A.MF.CurrentEntityID);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0001D26B File Offset: 0x0001C26B
		protected override void frmReport_Closed(object sender, EventArgs e)
		{
			base.frmReport_Closed(sender, e);
			A.MF.NewDay -= this.NewDayHandler;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0001D290 File Offset: 0x0001C290
		protected void NewDayHandler(object sender, EventArgs e)
		{
			if (base.GetData())
			{
				this.picReport.Refresh();
			}
		}

		// Token: 0x040001EC RID: 492
		private static Font font = new Font("Arial", 12f);

		// Token: 0x040001ED RID: 493
		private static Font fontB = new Font("Arial", 12f);

		// Token: 0x040001EE RID: 494
		private static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x040001EF RID: 495
		public float[] healthFactors;
	}
}
