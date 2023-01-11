using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for FundControl.
	/// </summary>
	// Token: 0x02000035 RID: 53
	public class FundControl : UserControl
	{
		// Token: 0x0600019C RID: 412 RVA: 0x0001A973 File Offset: 0x00019973
		public FundControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0001A98C File Offset: 0x0001998C
		public FundControl(InvestmentAccount f, bool retirement)
		{
			this.InitializeComponent();
			this.account = f;
			this.lnkFundName.Text = this.account.Fund.Name;
			this.labShares.Text = this.account.EndingBalance().ToString("N2");
			this.labPrice.Text = this.account.Fund.Price.ToString("C3");
			float change = this.account.Fund.Price - this.account.Fund.Previous;
			if (change > 0f)
			{
				this.labChange.Text = "+" + change.ToString("N2");
				this.labChange.ForeColor = Color.Green;
			}
			else if (change < 0f)
			{
				this.labChange.Text = change.ToString("N2");
				this.labChange.ForeColor = Color.Red;
			}
			else
			{
				this.labChange.Text = "--";
			}
			this.labValue.Text = Utilities.FC(this.account.EndingBalance() * this.account.Fund.Price, 2, A.I.CurrencyConversion);
			this.retirement = retirement;
			this.lnkBuy.Visible = !retirement;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600019E RID: 414 RVA: 0x0001AB28 File Offset: 0x00019B28
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
		// Token: 0x0600019F RID: 415 RVA: 0x0001AB64 File Offset: 0x00019B64
		private void InitializeComponent()
		{
			this.labShares = new Label();
			this.labPrice = new Label();
			this.labChange = new Label();
			this.labValue = new Label();
			this.lnkFundName = new LinkLabel();
			this.lnkBuy = new LinkLabel();
			this.lnkSell = new LinkLabel();
			base.SuspendLayout();
			this.labShares.Location = new Point(128, 8);
			this.labShares.Name = "labShares";
			this.labShares.Size = new Size(40, 24);
			this.labShares.TabIndex = 1;
			this.labShares.Text = "label2";
			this.labShares.TextAlign = ContentAlignment.MiddleRight;
			this.labPrice.Location = new Point(172, 8);
			this.labPrice.Name = "labPrice";
			this.labPrice.Size = new Size(56, 24);
			this.labPrice.TabIndex = 2;
			this.labPrice.Text = "label3";
			this.labPrice.TextAlign = ContentAlignment.MiddleRight;
			this.labChange.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labChange.Location = new Point(228, 8);
			this.labChange.Name = "labChange";
			this.labChange.Size = new Size(36, 24);
			this.labChange.TabIndex = 3;
			this.labChange.Text = "label4";
			this.labChange.TextAlign = ContentAlignment.MiddleRight;
			this.labValue.Location = new Point(272, 8);
			this.labValue.Name = "labValue";
			this.labValue.Size = new Size(64, 24);
			this.labValue.TabIndex = 4;
			this.labValue.Text = "label5";
			this.labValue.TextAlign = ContentAlignment.MiddleRight;
			this.lnkFundName.Location = new Point(4, 4);
			this.lnkFundName.Name = "lnkFundName";
			this.lnkFundName.Size = new Size(120, 32);
			this.lnkFundName.TabIndex = 5;
			this.lnkFundName.TabStop = true;
			this.lnkFundName.Text = "linkLabel1";
			this.lnkFundName.TextAlign = ContentAlignment.MiddleLeft;
			this.lnkFundName.LinkClicked += this.lnkFundName_LinkClicked;
			this.lnkBuy.Location = new Point(344, 8);
			this.lnkBuy.Name = "lnkBuy";
			this.lnkBuy.Size = new Size(26, 24);
			this.lnkBuy.TabIndex = 6;
			this.lnkBuy.TabStop = true;
			this.lnkBuy.Text = "Buy";
			this.lnkBuy.TextAlign = ContentAlignment.MiddleLeft;
			this.lnkBuy.LinkClicked += this.lnkBuy_LinkClicked;
			this.lnkSell.Location = new Point(372, 8);
			this.lnkSell.Name = "lnkSell";
			this.lnkSell.Size = new Size(26, 24);
			this.lnkSell.TabIndex = 7;
			this.lnkSell.TabStop = true;
			this.lnkSell.Text = "Sell";
			this.lnkSell.TextAlign = ContentAlignment.MiddleLeft;
			this.lnkSell.LinkClicked += this.lnkSell_LinkClicked;
			this.BackColor = Color.White;
			base.Controls.Add(this.lnkSell);
			base.Controls.Add(this.lnkBuy);
			base.Controls.Add(this.lnkFundName);
			base.Controls.Add(this.labValue);
			base.Controls.Add(this.labChange);
			base.Controls.Add(this.labPrice);
			base.Controls.Add(this.labShares);
			base.Name = "FundControl";
			base.Size = new Size(404, 40);
			base.ResumeLayout(false);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0001AFDF File Offset: 0x00019FDF
		private void lnkFundName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			A.MF.mnuActionsInvestingResearchFunds_Click(this.lnkFundName.Text, new EventArgs());
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0001B000 File Offset: 0x0001A000
		private void lnkBuy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				frmTrade f = new frmTrade(this.retirement, true, this.account.Fund);
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0001B050 File Offset: 0x0001A050
		private void lnkSell_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				if (!this.retirement || MessageBox.Show("If you are under 59 1/2 years old, you will incur a 10% penalty by withdrawing money from this account. Assume you were born in January 1, 1992. Do you want to continue?", "Confirm Withdrawal", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					frmTrade f = new frmTrade(this.retirement, false, this.account.Fund);
					f.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x040001B7 RID: 439
		private Label labShares;

		// Token: 0x040001B8 RID: 440
		private Label labPrice;

		// Token: 0x040001B9 RID: 441
		private Label labChange;

		// Token: 0x040001BA RID: 442
		private Label labValue;

		// Token: 0x040001BB RID: 443
		private LinkLabel lnkFundName;

		// Token: 0x040001BC RID: 444
		private LinkLabel lnkBuy;

		// Token: 0x040001BD RID: 445
		private LinkLabel lnkSell;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x040001BE RID: 446
		private Container components = null;

		// Token: 0x040001BF RID: 447
		private bool retirement;

		// Token: 0x040001C0 RID: 448
		private InvestmentAccount account;
	}
}
