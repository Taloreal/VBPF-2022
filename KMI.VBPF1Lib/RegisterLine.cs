using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for RegisterLine.
	/// </summary>
	// Token: 0x02000090 RID: 144
	public class RegisterLine : UserControl
	{
		// Token: 0x06000493 RID: 1171 RVA: 0x0003F418 File Offset: 0x0003E418
		public RegisterLine()
		{
			this.InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000494 RID: 1172 RVA: 0x0003F434 File Offset: 0x0003E434
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
		// Token: 0x06000495 RID: 1173 RVA: 0x0003F470 File Offset: 0x0003E470
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			this.txtNumber = new TextBox();
			this.textBox2 = new TextBox();
			this.panel2 = new Panel();
			this.txtDate = new TextBox();
			this.textBox4 = new TextBox();
			this.panel3 = new Panel();
			this.txtDescription1 = new TextBox();
			this.txtDescription2 = new TextBox();
			this.panel4 = new Panel();
			this.txtPayment = new TextBox();
			this.textBox8 = new TextBox();
			this.panel5 = new Panel();
			this.txtDeposit = new TextBox();
			this.textBox10 = new TextBox();
			this.panel6 = new Panel();
			this.txtBalance1 = new TextBox();
			this.txtBalance2 = new TextBox();
			this.panel7 = new Panel();
			this.txtChecked = new TextBox();
			this.textBox14 = new TextBox();
			this.panel8 = new Panel();
			this.txtFee = new TextBox();
			this.textBox16 = new TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.txtNumber);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(48, 32);
			this.panel1.TabIndex = 0;
			this.txtNumber.AutoSize = false;
			this.txtNumber.BorderStyle = BorderStyle.None;
			this.txtNumber.Dock = DockStyle.Top;
			this.txtNumber.Location = new Point(0, 0);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new Size(46, 16);
			this.txtNumber.TabIndex = 0;
			this.txtNumber.Text = "";
			this.txtNumber.TextAlign = HorizontalAlignment.Right;
			this.txtNumber.WordWrap = false;
			this.textBox2.AutoSize = false;
			this.textBox2.BackColor = SystemColors.Control;
			this.textBox2.BorderStyle = BorderStyle.None;
			this.textBox2.Dock = DockStyle.Bottom;
			this.textBox2.Enabled = false;
			this.textBox2.Location = new Point(0, 14);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new Size(46, 16);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			this.textBox2.WordWrap = false;
			this.panel2.BorderStyle = BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.txtDate);
			this.panel2.Controls.Add(this.textBox4);
			this.panel2.Location = new Point(48, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(40, 32);
			this.panel2.TabIndex = 1;
			this.txtDate.AutoSize = false;
			this.txtDate.BorderStyle = BorderStyle.None;
			this.txtDate.Dock = DockStyle.Top;
			this.txtDate.Location = new Point(0, 0);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new Size(38, 16);
			this.txtDate.TabIndex = 0;
			this.txtDate.Text = "";
			this.txtDate.WordWrap = false;
			this.textBox4.AutoSize = false;
			this.textBox4.BackColor = SystemColors.Control;
			this.textBox4.BorderStyle = BorderStyle.None;
			this.textBox4.Dock = DockStyle.Bottom;
			this.textBox4.Enabled = false;
			this.textBox4.Location = new Point(0, 14);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new Size(38, 16);
			this.textBox4.TabIndex = 1;
			this.textBox4.Text = "";
			this.textBox4.WordWrap = false;
			this.panel3.BorderStyle = BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.txtDescription1);
			this.panel3.Controls.Add(this.txtDescription2);
			this.panel3.Location = new Point(96, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(168, 32);
			this.panel3.TabIndex = 2;
			this.txtDescription1.AutoSize = false;
			this.txtDescription1.BorderStyle = BorderStyle.None;
			this.txtDescription1.Dock = DockStyle.Top;
			this.txtDescription1.Location = new Point(0, 0);
			this.txtDescription1.Name = "txtDescription1";
			this.txtDescription1.Size = new Size(166, 16);
			this.txtDescription1.TabIndex = 0;
			this.txtDescription1.Text = "";
			this.txtDescription1.WordWrap = false;
			this.txtDescription2.AutoSize = false;
			this.txtDescription2.BackColor = SystemColors.Control;
			this.txtDescription2.BorderStyle = BorderStyle.None;
			this.txtDescription2.Dock = DockStyle.Bottom;
			this.txtDescription2.Location = new Point(0, 14);
			this.txtDescription2.Name = "txtDescription2";
			this.txtDescription2.Size = new Size(166, 16);
			this.txtDescription2.TabIndex = 1;
			this.txtDescription2.Text = "";
			this.txtDescription2.WordWrap = false;
			this.panel4.BorderStyle = BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.txtPayment);
			this.panel4.Controls.Add(this.textBox8);
			this.panel4.Location = new Point(272, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(88, 32);
			this.panel4.TabIndex = 3;
			this.txtPayment.AutoSize = false;
			this.txtPayment.BorderStyle = BorderStyle.None;
			this.txtPayment.Dock = DockStyle.Top;
			this.txtPayment.Location = new Point(0, 0);
			this.txtPayment.Name = "txtPayment";
			this.txtPayment.Size = new Size(86, 16);
			this.txtPayment.TabIndex = 0;
			this.txtPayment.Text = "";
			this.txtPayment.TextAlign = HorizontalAlignment.Right;
			this.txtPayment.WordWrap = false;
			this.textBox8.AutoSize = false;
			this.textBox8.BackColor = SystemColors.Control;
			this.textBox8.BorderStyle = BorderStyle.None;
			this.textBox8.Dock = DockStyle.Bottom;
			this.textBox8.Enabled = false;
			this.textBox8.Location = new Point(0, 14);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new Size(86, 16);
			this.textBox8.TabIndex = 1;
			this.textBox8.Text = "";
			this.textBox8.WordWrap = false;
			this.panel5.BorderStyle = BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.txtDeposit);
			this.panel5.Controls.Add(this.textBox10);
			this.panel5.Location = new Point(432, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(88, 32);
			this.panel5.TabIndex = 4;
			this.txtDeposit.AutoSize = false;
			this.txtDeposit.BorderStyle = BorderStyle.None;
			this.txtDeposit.Dock = DockStyle.Top;
			this.txtDeposit.Location = new Point(0, 0);
			this.txtDeposit.Name = "txtDeposit";
			this.txtDeposit.Size = new Size(86, 16);
			this.txtDeposit.TabIndex = 0;
			this.txtDeposit.Text = "";
			this.txtDeposit.TextAlign = HorizontalAlignment.Right;
			this.txtDeposit.WordWrap = false;
			this.textBox10.AutoSize = false;
			this.textBox10.BackColor = SystemColors.Control;
			this.textBox10.BorderStyle = BorderStyle.None;
			this.textBox10.Dock = DockStyle.Bottom;
			this.textBox10.Enabled = false;
			this.textBox10.Location = new Point(0, 14);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new Size(86, 16);
			this.textBox10.TabIndex = 1;
			this.textBox10.Text = "";
			this.textBox10.WordWrap = false;
			this.panel6.BorderStyle = BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.txtBalance1);
			this.panel6.Controls.Add(this.txtBalance2);
			this.panel6.Location = new Point(528, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size(87, 32);
			this.panel6.TabIndex = 5;
			this.txtBalance1.AutoSize = false;
			this.txtBalance1.BorderStyle = BorderStyle.None;
			this.txtBalance1.Dock = DockStyle.Top;
			this.txtBalance1.Location = new Point(0, 0);
			this.txtBalance1.Name = "txtBalance1";
			this.txtBalance1.Size = new Size(85, 16);
			this.txtBalance1.TabIndex = 0;
			this.txtBalance1.Text = "";
			this.txtBalance1.TextAlign = HorizontalAlignment.Right;
			this.txtBalance1.WordWrap = false;
			this.txtBalance2.AutoSize = false;
			this.txtBalance2.BackColor = SystemColors.Control;
			this.txtBalance2.BorderStyle = BorderStyle.None;
			this.txtBalance2.Dock = DockStyle.Bottom;
			this.txtBalance2.Location = new Point(0, 14);
			this.txtBalance2.Name = "txtBalance2";
			this.txtBalance2.Size = new Size(85, 16);
			this.txtBalance2.TabIndex = 1;
			this.txtBalance2.Text = "";
			this.txtBalance2.TextAlign = HorizontalAlignment.Right;
			this.txtBalance2.WordWrap = false;
			this.panel7.BorderStyle = BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.txtChecked);
			this.panel7.Controls.Add(this.textBox14);
			this.panel7.Location = new Point(360, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size(24, 32);
			this.panel7.TabIndex = 6;
			this.txtChecked.AutoSize = false;
			this.txtChecked.BorderStyle = BorderStyle.None;
			this.txtChecked.Dock = DockStyle.Top;
			this.txtChecked.Location = new Point(0, 0);
			this.txtChecked.Name = "txtChecked";
			this.txtChecked.Size = new Size(22, 16);
			this.txtChecked.TabIndex = 0;
			this.txtChecked.Text = "";
			this.txtChecked.TextAlign = HorizontalAlignment.Center;
			this.txtChecked.WordWrap = false;
			this.textBox14.AutoSize = false;
			this.textBox14.BackColor = SystemColors.Control;
			this.textBox14.BorderStyle = BorderStyle.None;
			this.textBox14.Dock = DockStyle.Bottom;
			this.textBox14.Enabled = false;
			this.textBox14.Location = new Point(0, 14);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new Size(22, 16);
			this.textBox14.TabIndex = 1;
			this.textBox14.Text = "";
			this.textBox14.WordWrap = false;
			this.panel8.BorderStyle = BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.txtFee);
			this.panel8.Controls.Add(this.textBox16);
			this.panel8.Location = new Point(384, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new Size(40, 32);
			this.panel8.TabIndex = 7;
			this.txtFee.AutoSize = false;
			this.txtFee.BorderStyle = BorderStyle.None;
			this.txtFee.Dock = DockStyle.Top;
			this.txtFee.Location = new Point(0, 0);
			this.txtFee.MaxLength = 0;
			this.txtFee.Name = "txtFee";
			this.txtFee.Size = new Size(38, 16);
			this.txtFee.TabIndex = 0;
			this.txtFee.Text = "";
			this.txtFee.WordWrap = false;
			this.textBox16.AutoSize = false;
			this.textBox16.BackColor = SystemColors.Control;
			this.textBox16.BorderStyle = BorderStyle.None;
			this.textBox16.Dock = DockStyle.Bottom;
			this.textBox16.Enabled = false;
			this.textBox16.Location = new Point(0, 14);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new Size(38, 16);
			this.textBox16.TabIndex = 1;
			this.textBox16.Text = "";
			this.textBox16.WordWrap = false;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel8);
			base.Controls.Add(this.panel7);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "RegisterLine";
			base.Size = new Size(615, 32);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00040528 File Offset: 0x0003F528
		public void FillInFields(CheckRegisterEntry entry)
		{
			this.txtNumber.Text = entry.Number;
			this.txtDate.Text = entry.Date;
			this.txtDescription1.Text = entry.Description1;
			string[] temp = entry.Description2.Split(new char[]
			{
				'^'
			});
			this.txtDescription2.Text = temp[0];
			if (temp.Length > 1)
			{
				this.txtChecked.Text = temp[1];
			}
			this.txtPayment.Text = entry.Payment;
			this.txtDeposit.Text = entry.Deposit;
			this.txtBalance1.Text = entry.Balance1;
			this.txtBalance2.Text = entry.Balance2;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x000405F8 File Offset: 0x0003F5F8
		public CheckRegisterEntry CreateCheckRegisterEntry()
		{
			return new CheckRegisterEntry
			{
				Number = this.txtNumber.Text,
				Date = this.txtDate.Text,
				Description1 = this.txtDescription1.Text,
				Description2 = this.txtDescription2.Text + "^" + this.txtChecked.Text,
				Payment = this.txtPayment.Text,
				Deposit = this.txtDeposit.Text,
				Balance1 = this.txtBalance1.Text,
				Balance2 = this.txtBalance2.Text
			};
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000406B0 File Offset: 0x0003F6B0
		public void Print(Graphics g, int y)
		{
			Font f = this.Font;
			SolidBrush b = new SolidBrush(Color.Black);
			Pen pen = new Pen(b, 1f);
			SolidBrush bg = new SolidBrush(Color.LightGray);
			StringFormat sfr = new StringFormat();
			sfr.Alignment = StringAlignment.Far;
			foreach (object obj in base.Controls)
			{
				Panel p = (Panel)obj;
				foreach (object obj2 in p.Controls)
				{
					Control c = (Control)obj2;
					if (c is TextBox)
					{
						Rectangle r = new Rectangle(p.Left, y + c.Top, c.Width, c.Height);
						if (c.Top > 0)
						{
							g.FillRectangle(bg, r);
						}
						g.DrawRectangle(pen, r);
						StringFormat sf = new StringFormat();
						if (((TextBox)c).TextAlign == HorizontalAlignment.Right)
						{
							sf = sfr;
						}
						g.DrawString(c.Text, f, b, r, sf);
					}
				}
			}
		}

		// Token: 0x0400053C RID: 1340
		private Panel panel1;

		// Token: 0x0400053D RID: 1341
		private TextBox textBox2;

		// Token: 0x0400053E RID: 1342
		private Panel panel2;

		// Token: 0x0400053F RID: 1343
		private Panel panel3;

		// Token: 0x04000540 RID: 1344
		private Panel panel4;

		// Token: 0x04000541 RID: 1345
		private Panel panel5;

		// Token: 0x04000542 RID: 1346
		private TextBox textBox10;

		// Token: 0x04000543 RID: 1347
		private Panel panel6;

		// Token: 0x04000544 RID: 1348
		private Panel panel7;

		// Token: 0x04000545 RID: 1349
		private TextBox textBox14;

		// Token: 0x04000546 RID: 1350
		private Panel panel8;

		// Token: 0x04000547 RID: 1351
		private TextBox textBox16;

		// Token: 0x04000548 RID: 1352
		public TextBox txtNumber;

		// Token: 0x04000549 RID: 1353
		private TextBox txtDate;

		// Token: 0x0400054A RID: 1354
		private TextBox txtDescription1;

		// Token: 0x0400054B RID: 1355
		private TextBox txtDescription2;

		// Token: 0x0400054C RID: 1356
		private TextBox txtPayment;

		// Token: 0x0400054D RID: 1357
		private TextBox txtDeposit;

		// Token: 0x0400054E RID: 1358
		private TextBox txtBalance1;

		// Token: 0x0400054F RID: 1359
		private TextBox txtBalance2;

		// Token: 0x04000550 RID: 1360
		private TextBox txtChecked;

		// Token: 0x04000551 RID: 1361
		private TextBox txtFee;

		// Token: 0x04000552 RID: 1362
		private TextBox textBox8;

		// Token: 0x04000553 RID: 1363
		private TextBox textBox4;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000554 RID: 1364
		private Container components = null;
	}
}
