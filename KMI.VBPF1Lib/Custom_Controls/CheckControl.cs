using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib.Custom_Controls
{
	/// <summary>
	/// Summary description for CheckControl.
	/// </summary>
	// Token: 0x02000091 RID: 145
	public class CheckControl : UserControl
	{
		// Token: 0x06000499 RID: 1177 RVA: 0x00040874 File Offset: 0x0003F874
		public CheckControl()
		{
			this.InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600049A RID: 1178 RVA: 0x00040890 File Offset: 0x0003F890
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x0600049B RID: 1179 RVA: 0x000408CC File Offset: 0x0003F8CC
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			this.txtAmount = new TextBox();
			this.labCheckNumber = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.labCheckNumberBottom = new Label();
			this.labBankName = new Label();
			this.labAccountNumber = new Label();
			this.labelBankNumber = new Label();
			this.label22 = new Label();
			this.label24 = new Label();
			this.label30 = new Label();
			this.label31 = new Label();
			this.label32 = new Label();
			this.label33 = new Label();
			this.label34 = new Label();
			this.label35 = new Label();
			this.label37 = new Label();
			this.labPayor = new Label();
			this.labSignature = new Label();
			this.labAmountWords = new Label();
			this.labPayee = new Label();
			this.labYear = new Label();
			this.labMonthDay = new Label();
			this.txtMemo = new TextBox();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.txtAmount);
			this.panel1.Controls.Add(this.labCheckNumber);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.labCheckNumberBottom);
			this.panel1.Controls.Add(this.labBankName);
			this.panel1.Controls.Add(this.labAccountNumber);
			this.panel1.Controls.Add(this.labelBankNumber);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.label24);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Controls.Add(this.label31);
			this.panel1.Controls.Add(this.label32);
			this.panel1.Controls.Add(this.label33);
			this.panel1.Controls.Add(this.label34);
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.label37);
			this.panel1.Controls.Add(this.labPayor);
			this.panel1.Controls.Add(this.labSignature);
			this.panel1.Controls.Add(this.labAmountWords);
			this.panel1.Controls.Add(this.labPayee);
			this.panel1.Controls.Add(this.labYear);
			this.panel1.Controls.Add(this.labMonthDay);
			this.panel1.Controls.Add(this.txtMemo);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(556, 200);
			this.panel1.TabIndex = 0;
			this.txtAmount.BackColor = Color.LightCyan;
			this.txtAmount.BorderStyle = BorderStyle.None;
			this.txtAmount.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtAmount.ForeColor = SystemColors.ControlText;
			this.txtAmount.Location = new Point(420, 68);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new Size(120, 13);
			this.txtAmount.TabIndex = 81;
			this.txtAmount.Text = "";
			this.txtAmount.TextAlign = HorizontalAlignment.Center;
			this.txtAmount.TextChanged += this.txtAmount_TextChanged;
			this.labCheckNumber.BackColor = Color.LightCyan;
			this.labCheckNumber.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labCheckNumber.Location = new Point(456, 8);
			this.labCheckNumber.Name = "labCheckNumber";
			this.labCheckNumber.Size = new Size(80, 16);
			this.labCheckNumber.TabIndex = 77;
			this.labCheckNumber.Text = "108";
			this.labCheckNumber.TextAlign = ContentAlignment.TopRight;
			this.label2.BackColor = Color.LightCyan;
			this.label2.BorderStyle = BorderStyle.FixedSingle;
			this.label2.Location = new Point(48, 164);
			this.label2.Name = "label2";
			this.label2.Size = new Size(146, 1);
			this.label2.TabIndex = 76;
			this.label2.Text = "label2";
			this.label3.BackColor = Color.LightCyan;
			this.label3.Location = new Point(484, 100);
			this.label3.Name = "label3";
			this.label3.Size = new Size(64, 16);
			this.label3.TabIndex = 75;
			this.label3.Text = "DOLLARS";
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.LightCyan;
			this.label4.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(88, 132);
			this.label4.Name = "label4";
			this.label4.Size = new Size(72, 14);
			this.label4.TabIndex = 74;
			this.label4.Text = "Springfield, USA";
			this.label5.BackColor = Color.LightCyan;
			this.label5.BorderStyle = BorderStyle.FixedSingle;
			this.label5.Location = new Point(452, 48);
			this.label5.Name = "label5";
			this.label5.Size = new Size(26, 1);
			this.label5.TabIndex = 73;
			this.label5.Text = "label5";
			this.label6.BackColor = Color.LightCyan;
			this.label6.BorderStyle = BorderStyle.FixedSingle;
			this.label6.Location = new Point(8, 112);
			this.label6.Name = "label6";
			this.label6.Size = new Size(456, 1);
			this.label6.TabIndex = 72;
			this.label6.Text = "label6";
			this.labCheckNumberBottom.BackColor = Color.LightCyan;
			this.labCheckNumberBottom.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labCheckNumberBottom.Location = new Point(232, 176);
			this.labCheckNumberBottom.Name = "labCheckNumberBottom";
			this.labCheckNumberBottom.Size = new Size(44, 16);
			this.labCheckNumberBottom.TabIndex = 71;
			this.labCheckNumberBottom.Text = "108";
			this.labBankName.AutoSize = true;
			this.labBankName.BackColor = Color.LightCyan;
			this.labBankName.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labBankName.Location = new Point(88, 120);
			this.labBankName.Name = "labBankName";
			this.labBankName.Size = new Size(61, 14);
			this.labBankName.TabIndex = 70;
			this.labBankName.Text = "Olympic Bank";
			this.labAccountNumber.BackColor = Color.LightCyan;
			this.labAccountNumber.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labAccountNumber.Location = new Point(120, 176);
			this.labAccountNumber.Name = "labAccountNumber";
			this.labAccountNumber.Size = new Size(102, 16);
			this.labAccountNumber.TabIndex = 69;
			this.labAccountNumber.Text = "1505 303079";
			this.labelBankNumber.BackColor = Color.LightCyan;
			this.labelBankNumber.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labelBankNumber.Location = new Point(8, 176);
			this.labelBankNumber.Name = "labelBankNumber";
			this.labelBankNumber.Size = new Size(102, 16);
			this.labelBankNumber.TabIndex = 68;
			this.labelBankNumber.Text = "123456789";
			this.label22.AutoSize = true;
			this.label22.BackColor = Color.LightCyan;
			this.label22.Location = new Point(8, 148);
			this.label22.Name = "label22";
			this.label22.Size = new Size(39, 16);
			this.label22.TabIndex = 67;
			this.label22.Text = "MEMO";
			this.label24.BackColor = Color.LightCyan;
			this.label24.Location = new Point(428, 32);
			this.label24.Name = "label24";
			this.label24.Size = new Size(24, 16);
			this.label24.TabIndex = 66;
			this.label24.Text = "20";
			this.label30.BackColor = Color.LightCyan;
			this.label30.BorderStyle = BorderStyle.FixedSingle;
			this.label30.Location = new Point(308, 48);
			this.label30.Name = "label30";
			this.label30.Size = new Size(116, 1);
			this.label30.TabIndex = 65;
			this.label30.Text = "label30";
			this.label31.BackColor = Color.LightCyan;
			this.label31.BorderStyle = BorderStyle.FixedSingle;
			this.label31.Location = new Point(420, 88);
			this.label31.Name = "label31";
			this.label31.Size = new Size(116, 1);
			this.label31.TabIndex = 64;
			this.label31.Text = "label31";
			this.label32.BackColor = Color.LightCyan;
			this.label32.BorderStyle = BorderStyle.FixedSingle;
			this.label32.Location = new Point(356, 168);
			this.label32.Name = "label32";
			this.label32.Size = new Size(180, 1);
			this.label32.TabIndex = 63;
			this.label32.Text = "label32";
			this.label33.BackColor = Color.LightCyan;
			this.label33.Location = new Point(404, 72);
			this.label33.Name = "label33";
			this.label33.Size = new Size(16, 16);
			this.label33.TabIndex = 62;
			this.label33.Text = "$";
			this.label34.BackColor = Color.LightCyan;
			this.label34.BorderStyle = BorderStyle.FixedSingle;
			this.label34.Location = new Point(88, 88);
			this.label34.Name = "label34";
			this.label34.Size = new Size(300, 1);
			this.label34.TabIndex = 61;
			this.label34.Text = "label34";
			this.label35.BackColor = Color.LightCyan;
			this.label35.Location = new Point(8, 64);
			this.label35.Name = "label35";
			this.label35.Size = new Size(80, 24);
			this.label35.TabIndex = 59;
			this.label35.Text = "PAY TO THE ORDER OF";
			this.label37.AutoSize = true;
			this.label37.BackColor = Color.LightCyan;
			this.label37.Location = new Point(8, 28);
			this.label37.Name = "label37";
			this.label37.Size = new Size(109, 16);
			this.label37.TabIndex = 57;
			this.label37.Text = "SPRINGFIELD, USA";
			this.labPayor.AutoSize = true;
			this.labPayor.BackColor = Color.LightCyan;
			this.labPayor.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labPayor.Location = new Point(8, 8);
			this.labPayor.Name = "labPayor";
			this.labPayor.Size = new Size(87, 17);
			this.labPayor.TabIndex = 56;
			this.labPayor.Text = "JOHN Q. DOE";
			this.labSignature.Font = new Font("Monotype Corsiva", 12f, FontStyle.Italic, GraphicsUnit.Point, 0);
			this.labSignature.ForeColor = Color.FromArgb(0, 0, 192);
			this.labSignature.Location = new Point(364, 152);
			this.labSignature.Name = "labSignature";
			this.labSignature.Size = new Size(164, 20);
			this.labSignature.TabIndex = 89;
			this.labSignature.Text = "label11";
			this.labAmountWords.Location = new Point(16, 96);
			this.labAmountWords.Name = "labAmountWords";
			this.labAmountWords.Size = new Size(440, 20);
			this.labAmountWords.TabIndex = 88;
			this.labAmountWords.Text = "label10";
			this.labPayee.Location = new Point(88, 72);
			this.labPayee.Name = "labPayee";
			this.labPayee.Size = new Size(292, 20);
			this.labPayee.TabIndex = 87;
			this.labPayee.Text = "label9";
			this.labYear.Font = new Font("Verdana", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			this.labYear.ForeColor = Color.Gray;
			this.labYear.Location = new Point(452, 32);
			this.labYear.Name = "labYear";
			this.labYear.Size = new Size(28, 20);
			this.labYear.TabIndex = 86;
			this.labYear.Text = "08";
			this.labMonthDay.Location = new Point(312, 32);
			this.labMonthDay.Name = "labMonthDay";
			this.labMonthDay.Size = new Size(108, 20);
			this.labMonthDay.TabIndex = 85;
			this.labMonthDay.Text = "label1";
			this.txtMemo.BackColor = Color.LightCyan;
			this.txtMemo.BorderStyle = BorderStyle.None;
			this.txtMemo.Location = new Point(52, 148);
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new Size(192, 13);
			this.txtMemo.TabIndex = 82;
			this.txtMemo.Text = "";
			this.BackColor = Color.LightCyan;
			base.Controls.Add(this.panel1);
			base.Name = "CheckControl";
			base.Size = new Size(556, 200);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x170000A8 RID: 168
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x00041AD8 File Offset: 0x00040AD8
		public Check Check
		{
			set
			{
				this.check = value;
				this.txtAmount.Text = this.check.Amount.ToString("N2");
				this.labAmountWords.Text = this.NumeralsToWords(this.check.Amount);
				this.txtAmount.Enabled = false;
				this.txtMemo.Text = this.check.Memo;
				this.txtMemo.Enabled = false;
				this.labPayee.Text = this.check.Payee;
				this.labMonthDay.Text = this.check.Date.ToString("M");
				this.labYear.Text = this.check.Date.ToString("yy");
				this.labPayor.Text = this.check.Payor;
				this.labSignature.Text = this.check.Signature;
				this.labCheckNumber.Text = this.check.Number.ToString();
				this.labCheckNumberBottom.Text = this.check.Number.ToString();
				this.SetFonts(this.labYear.Font, this.labYear.ForeColor);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x00041C38 File Offset: 0x00040C38
		public Bill Bill
		{
			set
			{
				this.bill = value;
				this.txtAmount.Text = this.bill.Amount.ToString("N2");
				if (this.bill.Account != null && !(this.bill.Account is InstallmentLoan) && !(this.bill.Account is CreditCardAccount))
				{
					this.txtAmount.Text = this.bill.Account.EndingBalance().ToString("N2");
				}
				this.labPayee.Text = this.bill.From;
				this.labMonthDay.Text = this.bill.Date.ToString("M");
				this.labYear.Text = this.bill.Date.ToString("yy");
				this.labAmountWords.Text = this.NumeralsToWords(this.bill.Amount);
				this.SetFonts(this.labSignature.Font, this.labSignature.ForeColor);
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00041D64 File Offset: 0x00040D64
		protected void SetFonts(Font font, Color color)
		{
			this.txtAmount.Font = font;
			this.labPayee.Font = font;
			this.labMonthDay.Font = font;
			this.labYear.Font = font;
			this.labAmountWords.Font = font;
			this.txtMemo.Font = new Font(font.FontFamily, 8f, font.Style);
			this.txtAmount.ForeColor = color;
			this.txtMemo.ForeColor = color;
			this.labPayee.ForeColor = color;
			this.labMonthDay.ForeColor = color;
			this.labYear.ForeColor = color;
			this.labAmountWords.ForeColor = color;
			this.labSignature.ForeColor = color;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00041E30 File Offset: 0x00040E30
		protected string NumeralsToWords(float x)
		{
			int i = (int)Math.Floor((double)x);
			int millions = i / 1000000;
			int thousands = i % 1000000 / 1000;
			int ones = i % 1000;
			int pennies = (int)Math.Round((double)((x - (float)i) * 100f));
			string s = "";
			string text;
			if (millions > 0)
			{
				text = s;
				s = string.Concat(new string[]
				{
					text,
					this.NumeralsToWordsHelper(millions),
					" ",
					A.R.GetString("million"),
					" "
				});
			}
			if (thousands > 0)
			{
				text = s;
				s = string.Concat(new string[]
				{
					text,
					this.NumeralsToWordsHelper(thousands),
					" ",
					A.R.GetString("thousand"),
					" "
				});
			}
			s = s + this.NumeralsToWordsHelper(ones) + " ";
			text = s;
			s = string.Concat(new string[]
			{
				text,
				A.R.GetString("and"),
				" ",
				pennies.ToString(),
				"/100"
			});
			if (s.Length > 1)
			{
				s = s.Substring(0, 1).ToUpper() + s.Substring(1);
			}
			return s;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00041FC8 File Offset: 0x00040FC8
		protected string NumeralsToWordsHelper(int i)
		{
			int hundreds = i / 100;
			int tens = i % 100 / 10;
			int ones = i % 10;
			string[] onesWords = new string[]
			{
				"",
				"one",
				"two",
				"three",
				"four",
				"five",
				"six",
				"seven",
				"eight",
				"nine"
			};
			string[] tensWords = new string[]
			{
				"",
				"ten",
				"twenty",
				"thirty",
				"forty",
				"fifty",
				"sixty",
				"seventy",
				"eighty",
				"ninety"
			};
			string[] teenWords = new string[]
			{
				"eleven",
				"twelve",
				"thirteen",
				"fourteen",
				"fifteen",
				"sixteen",
				"seventeen",
				"eighteen",
				"nineteen"
			};
			string s = "";
			if (hundreds > 0)
			{
				string text = s;
				s = string.Concat(new string[]
				{
					text,
					onesWords[hundreds],
					" ",
					A.R.GetString("hundred"),
					" "
				});
			}
			if (i % 100 >= 11 && i % 100 <= 19)
			{
				s = s + teenWords[i % 100 - 11] + " ";
			}
			else
			{
				if (tens > 0)
				{
					s = s + tensWords[tens] + " ";
				}
				if (ones > 0)
				{
					s = s + onesWords[ones] + " ";
				}
			}
			return s;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000421EC File Offset: 0x000411EC
		private void txtAmount_TextChanged(object sender, EventArgs e)
		{
			try
			{
				float f = float.Parse(this.txtAmount.Text);
				this.labAmountWords.Text = this.NumeralsToWords(f);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x170000AA RID: 170
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x00042238 File Offset: 0x00041238
		public string BankName
		{
			set
			{
				this.labBankName.Text = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x00042248 File Offset: 0x00041248
		public string Payor
		{
			set
			{
				this.labPayor.Text = value;
			}
		}

		// Token: 0x04000555 RID: 1365
		private Panel panel1;

		// Token: 0x04000556 RID: 1366
		public Label label2;

		// Token: 0x04000557 RID: 1367
		public Label label3;

		// Token: 0x04000558 RID: 1368
		public Label label4;

		// Token: 0x04000559 RID: 1369
		public Label label5;

		// Token: 0x0400055A RID: 1370
		public Label label6;

		// Token: 0x0400055B RID: 1371
		public Label label22;

		// Token: 0x0400055C RID: 1372
		public Label label24;

		// Token: 0x0400055D RID: 1373
		public Label label30;

		// Token: 0x0400055E RID: 1374
		public Label label31;

		// Token: 0x0400055F RID: 1375
		public Label label32;

		// Token: 0x04000560 RID: 1376
		public Label label33;

		// Token: 0x04000561 RID: 1377
		public Label label34;

		// Token: 0x04000562 RID: 1378
		public Label label35;

		// Token: 0x04000563 RID: 1379
		public Label label37;

		// Token: 0x04000564 RID: 1380
		public Label labCheckNumber;

		// Token: 0x04000565 RID: 1381
		public TextBox txtAmount;

		// Token: 0x04000566 RID: 1382
		public TextBox txtMemo;

		// Token: 0x04000567 RID: 1383
		public Label labAccountNumber;

		// Token: 0x04000568 RID: 1384
		public Label labelBankNumber;

		// Token: 0x04000569 RID: 1385
		public Label labCheckNumberBottom;

		// Token: 0x0400056A RID: 1386
		public Label labBankName;

		// Token: 0x0400056B RID: 1387
		private Label labMonthDay;

		// Token: 0x0400056C RID: 1388
		private Label labYear;

		// Token: 0x0400056D RID: 1389
		public Label labPayee;

		// Token: 0x0400056E RID: 1390
		private Label labAmountWords;

		// Token: 0x0400056F RID: 1391
		public Label labSignature;

		// Token: 0x04000570 RID: 1392
		public Label labPayor;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000571 RID: 1393
		private Container components = null;

		// Token: 0x04000572 RID: 1394
		private Check check;

		// Token: 0x04000573 RID: 1395
		private Bill bill;
	}
}
