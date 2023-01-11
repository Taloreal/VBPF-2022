using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FW2.
	/// </summary>
	// Token: 0x02000033 RID: 51
	[Serializable]
	public class F1099Int : ITaxForm
	{
		// Token: 0x06000194 RID: 404 RVA: 0x0001A2FE File Offset: 0x000192FE
		public F1099Int(int year, string payer, string ownerName, long ownerID)
		{
			this.year = year;
			this.Payer = payer;
			this.OwnerName = ownerName;
			this.OwnerID = ownerID;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0001A328 File Offset: 0x00019328
		static F1099Int()
		{
			F1099Int.sfc.Alignment = StringAlignment.Center;
			F1099Int.sfr.Alignment = StringAlignment.Far;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0001A42C File Offset: 0x0001942C
		public int Year()
		{
			return this.year;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0001A444 File Offset: 0x00019444
		public void Print(Graphics g)
		{
			int w = 508;
			int h = 308;
			int margin = 10;
			int marginS = 1;
			int marginL = 12;
			int a = 110;
			int a2 = 220;
			int a3 = 310;
			int a4 = 395;
			int a5 = 400;
			int h2 = 37;
			int h3 = 74;
			int h4 = 111;
			int h5 = 148;
			int h6 = 197;
			int h7 = 234;
			int h8 = 271;
			g.DrawRectangle(F1099Int.pen, 0, 0, w - 1, h - 1);
			g.DrawLine(F1099Int.pen, a2, h2, a3, h2);
			g.DrawLine(F1099Int.pen, a2, h3, a3, h3);
			g.DrawLine(F1099Int.pen, 0, h4, w, h4);
			g.DrawLine(F1099Int.pen, 0, h5, a5, h5);
			g.DrawLine(F1099Int.pen, 0, h6, a5, h6);
			g.DrawLine(F1099Int.pen, 0, h7, a5, h7);
			g.DrawLine(F1099Int.pen, 0, h8, a2, h8);
			g.DrawLine(F1099Int.pen, a, h4, a, h5);
			g.DrawLine(F1099Int.pen, a2, 0, a2, h);
			g.DrawLine(F1099Int.pen, a3, 0, a3, h4);
			g.DrawLine(F1099Int.pen, a3, h5, a3, h);
			g.DrawLine(F1099Int.pen, a4, 0, a4, h4);
			g.DrawLine(F1099Int.pen, a5, h4, a5, h);
			g.DrawString("PAYER'S name", F1099Int.fontS, F1099Int.brush, (float)marginS, (float)marginS);
			g.DrawString(this.Payer, F1099Int.fontB, F1099Int.brush, (float)margin, (float)marginL);
			g.DrawString("RECIPIENT'S ID number", F1099Int.fontS, F1099Int.brush, (float)(a + marginS), (float)(h4 + marginS));
			g.DrawString(A.R.GetString("XXX-XX-{0}", new object[]
			{
				this.OwnerID.ToString().PadLeft(4, '0')
			}), F1099Int.fontB, F1099Int.brush, (float)(a + margin), (float)(h4 + marginL));
			g.DrawString("1. Interest income", F1099Int.fontS, F1099Int.brush, (float)(a2 + marginS), (float)(h2 + marginS));
			g.DrawString(this.Interest.ToString("N2"), F1099Int.fontB, F1099Int.brush, (float)(a3 - margin), (float)(h2 + marginL), F1099Int.sfr);
			g.DrawString("RECIPIENT'S name", F1099Int.fontS, F1099Int.brush, (float)marginS, (float)(h5 + marginS));
			g.DrawString(this.OwnerName, F1099Int.fontB, F1099Int.brush, (float)margin, (float)(h5 + marginL));
			g.DrawString(A.R.GetString("This is important tax information and is being furnished to the Internal Revenue Service. If you are required to file a return, a negligence penalty or other sanction may be imposed on you if this income is taxable and the IRS determines that it has not be reported."), F1099Int.fontS, F1099Int.brush, new Rectangle(a5 + marginS, h5 + marginL, w - a5 - 4, h - h5 - marginL), F1099Int.sfr);
			g.DrawString(this.year.ToString(), F1099Int.fontXLB, F1099Int.brush, (float)((a3 + a4) / 2), (float)(h2 + marginL), F1099Int.sfc);
			g.DrawString(A.R.GetString("Form 1099-INT"), F1099Int.fontB, F1099Int.brush, (float)((a3 + a4) / 2), (float)(h3 + marginL), F1099Int.sfc);
			g.DrawString(A.R.GetString("Interest" + Environment.NewLine + "Income"), F1099Int.fontLB, F1099Int.brush, (float)((a5 + w) / 2), (float)(h2 + marginL), F1099Int.sfc);
			g.DrawString(A.R.GetString("Copy B" + Environment.NewLine + "For Recipient"), F1099Int.fontB, F1099Int.brush, (float)w, (float)(h4 + marginL), F1099Int.sfr);
		}

		// Token: 0x040001A4 RID: 420
		protected int year;

		// Token: 0x040001A5 RID: 421
		public string Payer;

		// Token: 0x040001A6 RID: 422
		public string OwnerName;

		// Token: 0x040001A7 RID: 423
		public long OwnerID;

		// Token: 0x040001A8 RID: 424
		public float Interest;

		// Token: 0x040001A9 RID: 425
		public float USTreasuryInterest;

		// Token: 0x040001AA RID: 426
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x040001AB RID: 427
		protected static Font fontS = new Font("Arial", 7f);

		// Token: 0x040001AC RID: 428
		protected static Font fontL = new Font("Arial", 10f);

		// Token: 0x040001AD RID: 429
		protected static Font fontB = new Font("Arial", 8f, FontStyle.Bold);

		// Token: 0x040001AE RID: 430
		protected static Font fontSB = new Font("Arial", 7f, FontStyle.Bold);

		// Token: 0x040001AF RID: 431
		protected static Font fontLB = new Font("Arial", 12f, FontStyle.Bold);

		// Token: 0x040001B0 RID: 432
		protected static Font fontXLB = new Font("Arial", 16f, FontStyle.Bold);

		// Token: 0x040001B1 RID: 433
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x040001B2 RID: 434
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x040001B3 RID: 435
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x040001B4 RID: 436
		protected static Pen pen = new Pen(F1099Int.brush, 1f);

		// Token: 0x040001B5 RID: 437
		protected static Pen pen2 = new Pen(F1099Int.brush, 2f);
	}
}
