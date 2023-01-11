using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCreditScore.
	/// </summary>
	// Token: 0x020000A8 RID: 168
	public partial class frmCreditScore : frmDrawnReport
	{
		// Token: 0x06000508 RID: 1288 RVA: 0x00048C02 File Offset: 0x00047C02
		public frmCreditScore()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00048C1C File Offset: 0x00047C1C
		static frmCreditScore()
		{
			frmCreditScore.ficoPercentiles.Points = new PointF[]
			{
				new PointF(500f, 0.01f),
				new PointF(600f, 0.14f),
				new PointF(723f, 0.5f),
				new PointF(750f, 0.61f),
				new PointF(800f, 0.89f),
				new PointF(850f, 0.99f)
			};
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00048DD0 File Offset: 0x00047DD0
		protected override void GetDataVirtual()
		{
			this.input = A.SA.GetCreditScore(A.MF.CurrentEntityID);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00048DF0 File Offset: 0x00047DF0
		protected override void DrawReportVirtual(Graphics g)
		{
			StringFormat sfc = new StringFormat();
			sfc.Alignment = StringAlignment.Center;
			StringFormat sfr = new StringFormat();
			sfr.Alignment = StringAlignment.Far;
			Font lf = new Font("Arial", 20f);
			Font f = new Font("Arial", 10f, FontStyle.Bold);
			Font sf = new Font("Arial", 8f, FontStyle.Bold);
			Brush rb = new SolidBrush(Color.Red);
			Brush bb = new SolidBrush(Color.Black);
			Brush gb = new SolidBrush(Color.DarkGray);
			Brush ob = new SolidBrush(Color.Orange);
			Pen bp = new Pen(bb, 2f);
			int y = 10;
			g.DrawString(A.R.GetString("Your credit score is {0}", new object[]
			{
				this.input.Score
			}), lf, rb, g.ClipBounds.Width / 2f, (float)y, sfc);
			y += 80;
			int boxWidth = (int)(g.ClipBounds.Width * 0.7f);
			int boxLeft = (int)(g.ClipBounds.Width * 0.15f);
			g.FillRectangle(gb, boxLeft, y, boxWidth, 20);
			g.DrawRectangle(bp, boxLeft, y, boxWidth, 20);
			float xspacing = (float)boxWidth / 6f;
			for (int i = 0; i < 7; i++)
			{
				int x = (int)((float)boxLeft + (float)i * xspacing);
				g.DrawString((350 + i * 100).ToString(), f, bb, (float)x, (float)(y - 20), sfc);
				g.DrawLine(bp, x, y, x, y + 20);
			}
			g.DrawString(A.R.GetString("Lowest"), sf, bb, (float)(boxLeft - 5), (float)(y + 3), sfr);
			g.DrawString(A.R.GetString("Highest"), sf, bb, (float)(boxLeft + boxWidth + 5), (float)(y + 3));
			int scoreX = boxLeft + (this.input.Score - 350) * boxWidth / 600;
			g.FillPolygon(ob, new Point[]
			{
				new Point(scoreX, y + 28),
				new Point(scoreX + 10, y + 38),
				new Point(scoreX - 10, y + 38)
			});
			g.DrawString(A.R.GetString("You Are Here"), sf, ob, (float)scoreX, (float)(y + 40), sfc);
			float percentile = frmCreditScore.ficoPercentiles.Response((float)this.input.Score);
			y += 80;
			g.DrawString(A.R.GetString("Your credit score is higher than {0} of the population", new object[]
			{
				Utilities.FP(percentile)
			}), f, rb, g.ClipBounds.Width / 2f, (float)y, sfc);
			y += 40;
			g.FillRectangle(gb, boxLeft, y, boxWidth, 20);
			g.DrawRectangle(bp, boxLeft, y, boxWidth, 20);
			xspacing = (float)boxWidth / 5f;
			for (int i = 0; i < 6; i++)
			{
				int x = (int)((float)boxLeft + (float)i * xspacing);
				g.DrawString((i * 20).ToString(), f, bb, (float)x, (float)(y - 20), sfc);
				g.DrawLine(bp, x, y, x, y + 20);
			}
			g.DrawString(A.R.GetString("Lowest"), sf, bb, (float)(boxLeft - 5), (float)(y + 3), sfr);
			g.DrawString(A.R.GetString("Highest"), sf, bb, (float)(boxLeft + boxWidth + 5), (float)(y + 3));
			scoreX = boxLeft + (int)(percentile * (float)boxWidth);
			g.FillPolygon(ob, new Point[]
			{
				new Point(scoreX, y + 28),
				new Point(scoreX + 10, y + 38),
				new Point(scoreX - 10, y + 38)
			});
			g.DrawString(A.R.GetString("You Are Here"), sf, ob, (float)scoreX, (float)(y + 40), sfc);
		}

		// Token: 0x04000608 RID: 1544
		private static ResponseCurve ficoPercentiles = new ResponseCurve();

		// Token: 0x04000609 RID: 1545
		private frmCreditScore.Input input;

		// Token: 0x020000A9 RID: 169
		[Serializable]
		public struct Input
		{
			// Token: 0x0400060A RID: 1546
			public int Score;

			// Token: 0x0400060B RID: 1547
			public ArrayList Reasons;
		}
	}
}
