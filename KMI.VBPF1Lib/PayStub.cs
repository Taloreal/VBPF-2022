using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for PayStub.
	/// </summary>
	// Token: 0x020000B2 RID: 178
	[Serializable]
	public class PayStub : ITaxForm
	{
		// Token: 0x0600054B RID: 1355 RVA: 0x0004D654 File Offset: 0x0004C654
		public PayStub(string payor, string ownerName, string payDescription, DateTime weekEnding, float hours, float grossPay, WorkTask task, float FICAPaidThisYear)
		{
			this.Payor = payor;
			this.PayDescription = payDescription;
			this.WeekEnding = weekEnding;
			this.Hours = hours;
			this.Allowances = task.Allowances;
			this.PayValues.Add("Gross Pay", grossPay);
			this.PayValues.Add("Soc Sec", Math.Min(grossPay * 0.062f, 5840.4f - FICAPaidThisYear));
			this.PayValues.Add("Medicare", grossPay * 0.0145f);
			this.PayValues.Add("Fed WT", this.ComputeFedWithholding(grossPay, task));
			this.PayValues.Add("State WT", this.ComputeStateWithholding(grossPay, task));
			float prelimNetPay = this.GetValue("Gross Pay") - this.GetValue("Soc Sec") - this.GetValue("Medicare") - this.GetValue("Fed WT") - this.GetValue("State WT");
			this.PayValues.Add("401K", Math.Min(prelimNetPay, grossPay * task.R401KPercentWitheld));
			this.OwnerName = ownerName;
			this.Task = task;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0004D7BC File Offset: 0x0004C7BC
		static PayStub()
		{
			PayStub.sfc.Alignment = StringAlignment.Center;
			PayStub.sfr.Alignment = StringAlignment.Far;
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0004D8AC File Offset: 0x0004C8AC
		public float NetPay
		{
			get
			{
				return this.GetValue("Gross Pay") - this.GetValue("Soc Sec") - this.GetValue("Medicare") - this.GetValue("Fed WT") - this.GetValue("State WT") - this.GetValue("401K");
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0004D908 File Offset: 0x0004C908
		public float GetValue(string lineItem)
		{
			return (float)this.PayValues[lineItem];
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0004D92C File Offset: 0x0004C92C
		public void Print(Graphics g)
		{
			int y = 10;
			int xmid = 270;
			int tab = 100;
			int w = 508;
			int h = 308;
			int box1h = 252;
			int margin2 = 260;
			int a = 60;
			int a2 = 100;
			int a3 = 180;
			int a4 = 330;
			int a5 = 420;
			int b = 150;
			int b2 = 260;
			int b3 = 385;
			int marginS = 5;
			g.DrawRectangle(PayStub.pen, 0, 0, w - 1, h - 1);
			g.DrawString(A.R.GetString("Earnings Statement"), PayStub.fontLB, PayStub.brush, (float)xmid, (float)y);
			y += 30;
			g.DrawString(A.R.GetString("Pay Period: {0} to {1}", new object[]
			{
				this.WeekEnding.AddDays(-6.0).ToShortDateString(),
				this.WeekEnding.ToShortDateString()
			}), PayStub.fontS, PayStub.brush, (float)xmid, (float)y);
			y += 5;
			g.DrawString(this.Payor, PayStub.fontB, PayStub.brush, (float)(this.margin + 30), (float)y);
			y += 30;
			g.DrawString(A.R.GetString("Social Security #:"), PayStub.fontS, PayStub.brush, (float)this.margin, (float)y);
			g.DrawString(A.R.GetString("XXX-XX-{0}", new object[]
			{
				this.Task.Owner.ID.ToString().PadLeft(4, '0')
			}), PayStub.fontS, PayStub.brush, (float)(this.margin + tab), (float)y);
			g.DrawString(this.OwnerName, PayStub.fontB, PayStub.brush, (float)xmid, (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Allowances:"), PayStub.fontS, PayStub.brush, (float)this.margin, (float)y);
			g.DrawString(this.Allowances.ToString(), PayStub.fontS, PayStub.brush, (float)(this.margin + tab), (float)y);
			y += 10;
			g.DrawString(A.R.GetString("Rate:"), PayStub.fontS, PayStub.brush, (float)this.margin, (float)y);
			g.DrawString(Utilities.FC(this.Task.HourlyWage, 2, A.I.CurrencyConversion), PayStub.fontS, PayStub.brush, (float)(this.margin + tab), (float)y);
			y += 25;
			g.DrawRectangle(PayStub.pen2, this.margin, y, w - 2 * this.margin, box1h - y - this.margin);
			g.DrawLine(PayStub.pen2, margin2, y, margin2, box1h - this.margin);
			g.DrawLine(PayStub.pen, this.margin, y + 20, w - this.margin, y + 20);
			g.DrawLine(PayStub.pen, this.margin, y + 35, w - this.margin, y + 35);
			y += 4;
			g.DrawString(A.R.GetString("Hours and Earnings"), PayStub.fontB, PayStub.brush, (float)((this.margin + margin2) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Taxes and Deductions"), PayStub.fontB, PayStub.brush, (float)((margin2 + w) / 2), (float)y, PayStub.sfc);
			y += 16;
			g.DrawLine(PayStub.pen, a, y, a, box1h - this.margin);
			g.DrawLine(PayStub.pen, a2, y, a2, box1h - this.margin);
			g.DrawLine(PayStub.pen, a3, y, a3, box1h - this.margin);
			g.DrawLine(PayStub.pen, a4, y, a4, box1h - this.margin);
			g.DrawLine(PayStub.pen, a5, y, a5, box1h - this.margin);
			y += 3;
			g.DrawString(A.R.GetString("Description"), PayStub.fontS, PayStub.brush, (float)((this.margin + a) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Hours"), PayStub.fontS, PayStub.brush, (float)((a + a2) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("This Period"), PayStub.fontS, PayStub.brush, (float)((a2 + a3) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Year-To-Date"), PayStub.fontS, PayStub.brush, (float)((a3 + margin2) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Description"), PayStub.fontS, PayStub.brush, (float)((margin2 + a4) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("This Period"), PayStub.fontS, PayStub.brush, (float)((a4 + a5) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Year-To-Date"), PayStub.fontS, PayStub.brush, (float)((a5 + w - this.margin) / 2), (float)y, PayStub.sfc);
			y += 15;
			g.DrawString(this.PayDescription, PayStub.font, PayStub.brush, (float)(this.margin + marginS - 4), (float)y);
			g.DrawString(this.Hours.ToString(), PayStub.font, PayStub.brush, (float)(a2 - marginS), (float)y, PayStub.sfr);
			g.DrawString(this.GetValue("Gross Pay").ToString("N2"), PayStub.font, PayStub.brush, (float)(a3 - marginS), (float)y, PayStub.sfr);
			g.DrawString(this.Task.GetValueYTD("Gross Pay", this.WeekEnding).ToString("N2"), PayStub.font, PayStub.brush, (float)(margin2 - marginS), (float)y, PayStub.sfr);
			string[] deducts = new string[]
			{
				"Soc Sec",
				"Medicare",
				"Fed WT",
				"State WT",
				"401K"
			};
			foreach (string deduct in deducts)
			{
				g.DrawString(deduct, PayStub.font, PayStub.brush, (float)(a4 - marginS), (float)y, PayStub.sfr);
				g.DrawString(this.GetValue(deduct).ToString("N2"), PayStub.font, PayStub.brush, (float)(a5 - marginS), (float)y, PayStub.sfr);
				g.DrawString(this.Task.GetValueYTD(deduct, this.WeekEnding).ToString("N2"), PayStub.font, PayStub.brush, (float)(w - this.margin - marginS), (float)y, PayStub.sfr);
				y += 12;
			}
			y = box1h;
			g.DrawRectangle(PayStub.pen2, this.margin, y, w - 2 * this.margin, 45);
			g.DrawLine(PayStub.pen, this.margin, y + 18, w - this.margin, y + 18);
			g.DrawLine(PayStub.pen2, b, y, b, y + 45);
			g.DrawLine(PayStub.pen, b2, y, b2, y + 45);
			g.DrawLine(PayStub.pen, b3, y, b3, y + 45);
			y += 4;
			g.DrawString(A.R.GetString("Gross Pay Year-To-Date"), PayStub.fontS, PayStub.brush, (float)((this.margin + b) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Gross Pay This Period"), PayStub.fontS, PayStub.brush, (float)((b + b2) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Total Deductions This Period"), PayStub.fontS, PayStub.brush, (float)((b2 + b3) / 2), (float)y, PayStub.sfc);
			g.DrawString(A.R.GetString("Net Pay This Period"), PayStub.fontS, PayStub.brush, (float)((b3 + w) / 2), (float)y, PayStub.sfc);
			y += 20;
			g.DrawString(Utilities.FC(this.Task.GetValueYTD("Gross Pay", this.WeekEnding), 2, A.I.CurrencyConversion), PayStub.font, PayStub.brush, (float)(b - this.margin), (float)y, PayStub.sfr);
			g.DrawString(Utilities.FC(this.GetValue("Gross Pay"), 2, A.I.CurrencyConversion), PayStub.font, PayStub.brush, (float)(b2 - this.margin), (float)y, PayStub.sfr);
			g.DrawString(Utilities.FC(this.GetValue("Gross Pay") - this.NetPay, 2, A.I.CurrencyConversion), PayStub.font, PayStub.brush, (float)(b3 - this.margin), (float)y, PayStub.sfr);
			g.DrawString(Utilities.FC(this.NetPay, 2, A.I.CurrencyConversion), PayStub.fontB, PayStub.brush, (float)(w - this.margin - this.margin), (float)y, PayStub.sfr);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0004E2A4 File Offset: 0x0004D2A4
		public int Year()
		{
			return this.WeekEnding.Year;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0004E2F8 File Offset: 0x0004D2F8
		public float ComputeFedWithholding(float grossPay, WorkTask t)
		{
			float result;
			if (t.ExemptFromWitholding)
			{
				result = 0f;
			}
			else
			{
				float adjPay = grossPay - 65.38f * (float)t.Allowances - t.AdditionalWitholding;
				result = F1040EZ.ComputeTax(adjPay, new float[]
				{
					51f,
					195f,
					645f,
					1482f,
					3131f,
					6763f
				}, new float[]
				{
					0.1f,
					0.15f,
					0.25f,
					0.28f,
					0.33f,
					0.35f
				}) + t.AdditionalWitholding;
			}
			return result;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0004E368 File Offset: 0x0004D368
		public float ComputeStateWithholding(float grossPay, WorkTask t)
		{
			float result;
			if (t.ExemptFromWitholding)
			{
				result = 0f;
			}
			else
			{
				float adjPay = Math.Max(0f, grossPay - 65.38f * (float)t.Allowances);
				result = 0.05f * adjPay;
			}
			return result;
		}

		// Token: 0x04000638 RID: 1592
		public string Payor;

		// Token: 0x04000639 RID: 1593
		public string PayDescription;

		// Token: 0x0400063A RID: 1594
		public float Hours;

		// Token: 0x0400063B RID: 1595
		public int Allowances;

		// Token: 0x0400063C RID: 1596
		public DateTime WeekEnding;

		// Token: 0x0400063D RID: 1597
		public WorkTask Task;

		// Token: 0x0400063E RID: 1598
		public string OwnerName;

		// Token: 0x0400063F RID: 1599
		public Hashtable PayValues = new Hashtable();

		// Token: 0x04000640 RID: 1600
		protected static Font font = new Font("Arial", 8f);

		// Token: 0x04000641 RID: 1601
		protected static Font fontS = new Font("Arial", 7f);

		// Token: 0x04000642 RID: 1602
		protected static Font fontL = new Font("Arial", 10f);

		// Token: 0x04000643 RID: 1603
		protected static Font fontB = new Font("Arial", 8f, FontStyle.Bold);

		// Token: 0x04000644 RID: 1604
		protected static Font fontSB = new Font("Arial", 7f, FontStyle.Bold);

		// Token: 0x04000645 RID: 1605
		protected static Font fontLB = new Font("Arial", 12f, FontStyle.Bold);

		// Token: 0x04000646 RID: 1606
		protected static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x04000647 RID: 1607
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x04000648 RID: 1608
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x04000649 RID: 1609
		protected static Pen pen = new Pen(PayStub.brush, 1f);

		// Token: 0x0400064A RID: 1610
		protected static Pen pen2 = new Pen(PayStub.brush, 2f);

		// Token: 0x0400064B RID: 1611
		protected int margin = 10;
	}
}
