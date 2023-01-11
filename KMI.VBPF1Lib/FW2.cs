using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FW2.
	/// </summary>
	// Token: 0x02000097 RID: 151
	[Serializable]
	public class FW2 : ITaxForm
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00042CCA File Offset: 0x00041CCA
		public FW2(int year, string employer, string ownerName, long ownerID)
		{
			this.year = year;
			this.Employer = employer;
			this.OwnerName = ownerName;
			this.OwnerID = ownerID;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00042CF4 File Offset: 0x00041CF4
		static FW2()
		{
			FW2.sfc.Alignment = StringAlignment.Center;
			FW2.sfr.Alignment = StringAlignment.Far;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00042DF8 File Offset: 0x00041DF8
		public int Year()
		{
			return this.year;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00042E10 File Offset: 0x00041E10
		public void Print(Graphics g)
		{
			int w = 508;
			int h = 308;
			int margin = 10;
			int marginS = 1;
			int marginL = 12;
			int a = 110;
			int a2 = 220;
			int a3 = 330;
			int h2 = 25;
			int h3 = 50;
			int h4 = 75;
			int h5 = 100;
			int h6 = 150;
			int h7 = 175;
			int h8 = 200;
			int h9 = 265;
			int h10 = 285;
			int b = 70;
			int b2 = 150;
			int b3 = 250;
			int b4 = 350;
			g.DrawRectangle(FW2.pen, 0, 0, w - 1, h - 1);
			g.DrawLine(FW2.pen, 0, h2, w, h2);
			g.DrawLine(FW2.pen, a2, h3, w, h3);
			g.DrawLine(FW2.pen, a2, h4, w, h4);
			g.DrawLine(FW2.pen, 0, h5, w, h5);
			g.DrawLine(FW2.pen, a2, h6, a3, h6);
			g.DrawLine(FW2.pen, a2, h7, a3, h7);
			g.DrawLine(FW2.pen, 0, h8, w, h8);
			g.DrawLine(FW2.pen, 0, h9, w, h9);
			g.DrawLine(FW2.pen, 0, h10, w, h10);
			g.DrawLine(FW2.pen, a, 0, a, h2);
			g.DrawLine(FW2.pen, a2, 0, a2, h9);
			g.DrawLine(FW2.pen, a3, 0, a3, h8);
			g.DrawLine(FW2.pen, b, h9, b, h);
			g.DrawLine(FW2.pen, b2, h9, b2, h);
			g.DrawLine(FW2.pen, b3, h9, b3, h);
			g.DrawLine(FW2.pen, b4, h9, b4, h);
			g.DrawString("a. Control Number", FW2.fontS, FW2.brush, (float)marginS, (float)marginS);
			g.DrawString("123456789", FW2.fontB, FW2.brush, (float)margin, (float)marginL);
			g.DrawString("d. Emp. Social Sec. No.", FW2.fontS, FW2.brush, (float)(a + marginS), (float)marginS);
			g.DrawString(A.R.GetString("XXX-XX-{0}", new object[]
			{
				this.OwnerID.ToString().PadLeft(4, '0')
			}), FW2.fontB, FW2.brush, (float)(a + margin), (float)marginL);
			g.DrawString("1. Wages,tips, other", FW2.fontS, FW2.brush, (float)(a2 + marginS), (float)marginS);
			g.DrawString(this.Wages.ToString("N2"), FW2.fontB, FW2.brush, (float)(a3 - margin), (float)marginL, FW2.sfr);
			g.DrawString("2. Fed income tax withheld", FW2.fontS, FW2.brush, (float)(a3 + marginS), (float)marginS);
			g.DrawString(this.FedWT.ToString("N2"), FW2.fontB, FW2.brush, (float)(w - margin), (float)marginL, FW2.sfr);
			g.DrawString("3. Social Sec. Wages", FW2.fontS, FW2.brush, (float)(a2 + marginS), (float)(h2 + marginS));
			g.DrawString(this.SSWages.ToString("N2"), FW2.fontB, FW2.brush, (float)(a3 - margin), (float)(h2 + marginL), FW2.sfr);
			g.DrawString("4. Social Sec. tax withheld", FW2.fontS, FW2.brush, (float)(a3 + marginS), (float)(h2 + marginS));
			g.DrawString((this.SSWages * 0.062f).ToString("N2"), FW2.fontB, FW2.brush, (float)(w - margin), (float)(h2 + marginL), FW2.sfr);
			g.DrawString("5. Medicare Wages", FW2.fontS, FW2.brush, (float)(a2 + marginS), (float)(h3 + marginS));
			g.DrawString(this.MedicareWages.ToString("N2"), FW2.fontB, FW2.brush, (float)(a3 - margin), (float)(h3 + marginL), FW2.sfr);
			g.DrawString("6. Medicare tax withheld", FW2.fontS, FW2.brush, (float)(a3 + marginS), (float)(h3 + marginS));
			g.DrawString((this.SSWages * 0.0145f).ToString("N2"), FW2.fontB, FW2.brush, (float)(w - margin), (float)(h3 + marginL), FW2.sfr);
			g.DrawString("13. Retirement plan", FW2.fontS, FW2.brush, (float)(a2 + marginS), (float)(h6 + marginS));
			g.DrawRectangle(FW2.pen, a2 + 23, h6 + 12, margin, margin);
			if (this.RetirementPlan)
			{
				g.DrawString("X", FW2.fontB, FW2.brush, (float)(a2 + 23), (float)(h6 + 12));
			}
			g.DrawString("c. Employer's name", FW2.fontS, FW2.brush, (float)marginS, (float)(h2 + marginS));
			g.DrawString(this.Employer, FW2.fontB, FW2.brush, (float)margin, (float)(h2 + marginL));
			g.DrawString("e. Employee's name", FW2.fontS, FW2.brush, (float)marginS, (float)(h5 + marginS));
			g.DrawString(this.OwnerName, FW2.fontB, FW2.brush, (float)margin, (float)(h5 + marginL));
			g.DrawString(A.R.GetString("This information is being furnished to the Internal Revenue Service. If you are required to file a tax return, a negligence penalty or other sanction may be imposed on you if this income is taxable & you fail to report it."), FW2.fontS, FW2.brush, new Rectangle(marginS, h8 + marginS, a2 - marginS, h9 - h8 - marginS));
			g.DrawString(A.R.GetString("FORM"), FW2.fontB, FW2.brush, (float)(a2 + marginL + 34), (float)(h8 + margin - 4));
			g.DrawString(A.R.GetString("W-2 {0}", new object[]
			{
				this.year
			}), FW2.fontXLB, FW2.brush, (float)(a2 + marginL), (float)(h8 + marginL + 6));
			g.DrawString(A.R.GetString("Wage and Tax"), FW2.fontLB, FW2.brush, (float)((a3 + w) / 2), (float)(h8 + marginL), FW2.sfc);
			g.DrawString(A.R.GetString("Statement"), FW2.fontLB, FW2.brush, (float)((a3 + w) / 2), (float)(h8 + marginL + 16), FW2.sfc);
			g.DrawString(A.R.GetString("Copy C for EMPLOYEE'S RECORDS"), FW2.font, FW2.brush, (float)(a2 + margin), (float)(h8 + marginL + 38));
			g.DrawString("15. State", FW2.fontS, FW2.brush, (float)marginS, (float)(h9 + marginS));
			g.DrawString("XY", FW2.fontB, FW2.brush, (float)marginL, (float)(h10 + marginS));
			g.DrawString("16. State wages, etc.", FW2.fontS, FW2.brush, (float)(b2 + marginS), (float)(h9 + marginS));
			g.DrawString(this.Wages.ToString("N2"), FW2.fontB, FW2.brush, (float)(b2 + marginL), (float)(h10 + marginS));
			g.DrawString("17. State income tax", FW2.fontS, FW2.brush, (float)(b3 + marginS), (float)(h9 + marginS));
			g.DrawString(this.StateWT.ToString("N2"), FW2.fontB, FW2.brush, (float)(b3 + marginL), (float)(h10 + marginS));
		}

		// Token: 0x0400057F RID: 1407
		protected int year;

		// Token: 0x04000580 RID: 1408
		public string Employer;

		// Token: 0x04000581 RID: 1409
		public string OwnerName;

		// Token: 0x04000582 RID: 1410
		public long OwnerID;

		// Token: 0x04000583 RID: 1411
		public float Wages;

		// Token: 0x04000584 RID: 1412
		public float SSWages;

		// Token: 0x04000585 RID: 1413
		public float MedicareWages;

		// Token: 0x04000586 RID: 1414
		public float FedWT;

		// Token: 0x04000587 RID: 1415
		public float StateWT;

		// Token: 0x04000588 RID: 1416
		public bool RetirementPlan;

		// Token: 0x04000589 RID: 1417
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x0400058A RID: 1418
		protected static Font fontS = new Font("Arial", 7f);

		// Token: 0x0400058B RID: 1419
		protected static Font fontL = new Font("Arial", 10f);

		// Token: 0x0400058C RID: 1420
		protected static Font fontB = new Font("Arial", 8f, FontStyle.Bold);

		// Token: 0x0400058D RID: 1421
		protected static Font fontSB = new Font("Arial", 7f, FontStyle.Bold);

		// Token: 0x0400058E RID: 1422
		protected static Font fontLB = new Font("Arial", 12f, FontStyle.Bold);

		// Token: 0x0400058F RID: 1423
		protected static Font fontXLB = new Font("Arial", 16f, FontStyle.Bold);

		// Token: 0x04000590 RID: 1424
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x04000591 RID: 1425
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x04000592 RID: 1426
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x04000593 RID: 1427
		protected static Pen pen = new Pen(FW2.brush, 1f);

		// Token: 0x04000594 RID: 1428
		protected static Pen pen2 = new Pen(FW2.brush, 2f);
	}
}
