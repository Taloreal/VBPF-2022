using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;
using KMI.VBPF1Lib.Custom_Controls;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmOnlineBanking.
	/// </summary>
	// Token: 0x0200006C RID: 108
	public partial class frmOnlineBanking : Form
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x0002D90C File Offset: 0x0002C90C
		public frmOnlineBanking()
		{
			this.InitializeComponent();
			frmOnlineBanking.sfr.Alignment = StringAlignment.Far;
			base.Size = new Size(584, 424);
			this.bankAccounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			this.payees = A.SA.GetPayees(A.MF.CurrentEntityID);
			if (this.bankAccounts.Count == 0)
			{
				throw new SimApplicationException(A.R.GetString("You do not have any bank accounts open. You need a bank account to do online banking. To open a bank account, click a bank in the City view."));
			}
			foreach (object obj in this.bankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				if (!this.cboURLs.Items.Contains(ba.BankURL))
				{
					this.cboURLs.Items.Add(ba.BankURL);
				}
			}
			this.cboURLs.SelectedIndex = 0;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0002DA58 File Offset: 0x0002CA58
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0002DA70 File Offset: 0x0002CA70
		protected string URL
		{
			get
			{
				return this.url;
			}
			set
			{
				this.url = value;
				this.labBankName.Text = this.url;
				this.ReturnToHome();
				int i = 0;
				this.panAccounts.Controls.Clear();
				foreach (object obj in this.bankAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj;
					if (ba.BankURL == this.URL)
					{
						LinkLabel j = new LinkLabel();
						j.Size = new Size(j.Width + 10, j.Height);
						j.Text = ba.AccountTypeFriendlyName + " # " + ba.AccountNumber;
						j.Tag = ba.AccountNumber;
						j.Location = new Point(0, i++ * 25);
						j.LinkClicked += this.linkAccountDetails_LinkClicked;
						this.panAccounts.Controls.Add(j);
					}
				}
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0002FC6E File Offset: 0x0002EC6E
		private void cboURLs_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.URL = this.cboURLs.SelectedItem.ToString();
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0002FC88 File Offset: 0x0002EC88
		private void linkAccountDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel i = (LinkLabel)sender;
			BankAccount ba = (BankAccount)this.bankAccounts[(long)i.Tag];
			this.account = ba;
			this.labAccountNumber.Text = ba.AccountNumber.ToString();
			this.labAccountBalance.Text = Utilities.FC(ba.EndingBalance(), 2, A.I.CurrencyConversion);
			this.panHome.Visible = false;
			this.panAccountDetail.Visible = true;
			this.panAccountDetail.Dock = DockStyle.Fill;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0002FD28 File Offset: 0x0002ED28
		private void panTransactions_Paint(object sender, PaintEventArgs e)
		{
			int y = this.margin;
			Graphics g = e.Graphics;
			string[] titles = new string[]
			{
				A.R.GetString("Date"),
				A.R.GetString("Description"),
				A.R.GetString("Debit"),
				A.R.GetString("Credit"),
				A.R.GetString("Balance")
			};
			g.DrawString(titles[0], frmOnlineBanking.fontS, frmOnlineBanking.brush, (float)this.margin, (float)y);
			g.DrawString(titles[1], frmOnlineBanking.fontS, frmOnlineBanking.brush, (float)this.colWidth, (float)y);
			for (int c = 2; c < 5; c++)
			{
				g.DrawString(titles[c], frmOnlineBanking.fontS, frmOnlineBanking.brush, (float)((c + 2) * this.colWidth), (float)y, frmOnlineBanking.sfr);
			}
			y += 20;
			y += this.margin;
			ArrayList transactionRecentFirst = (ArrayList)this.account.Transactions.Clone();
			transactionRecentFirst.Reverse();
			float balance = this.account.EndingBalance();
			foreach (object obj in transactionRecentFirst)
			{
				Transaction t = (Transaction)obj;
				g.DrawString(t.Date.ToString("M/d/yyyy"), frmOnlineBanking.font, frmOnlineBanking.brush, (float)this.margin, (float)y);
				g.DrawString(t.Description, frmOnlineBanking.font, frmOnlineBanking.brush, new RectangleF((float)this.colWidth, (float)y, (float)((int)(2.5f * (float)this.colWidth)), 45f));
				if (t.Type == Transaction.TranType.Debit)
				{
					g.DrawString(t.Amount.ToString("N2"), frmOnlineBanking.font, frmOnlineBanking.brush, (float)(4 * this.colWidth), (float)y, frmOnlineBanking.sfr);
				}
				else
				{
					g.DrawString(t.Amount.ToString("N2"), frmOnlineBanking.font, frmOnlineBanking.brush, (float)(5 * this.colWidth), (float)y, frmOnlineBanking.sfr);
				}
				g.DrawString(balance.ToString("N2"), frmOnlineBanking.font, frmOnlineBanking.brush, (float)(6 * this.colWidth), (float)y, frmOnlineBanking.sfr);
				if (t.Type == Transaction.TranType.Debit)
				{
					balance += t.Amount;
				}
				else
				{
					balance -= t.Amount;
				}
				y += 45;
			}
			this.panTransactions.Height = y + 31;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00030014 File Offset: 0x0002F014
		private void linkPaybills_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.panHome.Visible = false;
			this.panPayBills.Visible = true;
			this.panPayBills.Dock = DockStyle.Fill;
			this.panPayees.Controls.Clear();
			this.cboPayAccount.Items.Clear();
			int y = 5;
			if (this.panPayees.Controls.Count == 0)
			{
				foreach (object obj in this.payees)
				{
					BankAccount payee = (BankAccount)obj;
					Label i = new Label();
					i.AutoSize = true;
					i.Location = new Point(5, y);
					i.Text = payee.BankName;
					if (payee is InstallmentLoan)
					{
						Label label = i;
						label.Text += A.R.GetString(" Acct# {0}", new object[]
						{
							payee.AccountNumber
						});
					}
					TextBox t = new TextBox();
					t.TextAlign = HorizontalAlignment.Right;
					t.Location = new Point(220, y);
					t.Tag = payee;
					this.panPayees.Controls.Add(t);
					this.panPayees.Controls.Add(i);
					y += 35;
				}
				this.panPayees.Height = y;
				this.btnSchedulePayments.Top = this.panPayees.Bottom + 5;
			}
			foreach (object obj2 in this.bankAccounts.Values)
			{
				BankAccount a = (BankAccount)obj2;
				if (a is CheckingAccount)
				{
					this.cboPayAccount.Items.Add(a);
				}
			}
			if (this.cboPayAccount.Items.Count > 0)
			{
				this.cboPayAccount.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show(A.R.GetString("You need a checking account at this bank to pay bills."), A.R.GetString("Pay Bills"));
				this.ReturnToHome();
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000302B8 File Offset: 0x0002F2B8
		private void btnSchedulePayments_Click(object sender, EventArgs e)
		{
			Hashtable payments = new Hashtable();
			foreach (object obj in this.panPayees.Controls)
			{
				Control c = (Control)obj;
				if (c is TextBox && c.Text != "")
				{
					float amount = 0f;
					try
					{
						amount = float.Parse(c.Text);
					}
					catch (Exception ex)
					{
						MessageBox.Show(A.R.GetString("Invalid amount entered for {0}. Please correct.", new object[]
						{
							c.Tag
						}), A.R.GetString("Invalid Entry"));
						return;
					}
					if (amount > 0f)
					{
						payments.Add(c.Tag, amount);
					}
				}
			}
			try
			{
				A.SA.SchedulePayments(A.MF.CurrentEntityID, ((BankAccount)this.cboPayAccount.SelectedItem).AccountNumber, payments);
				MessageBox.Show(A.R.GetString("Your payments have been scheduled."), A.R.GetString("Success"));
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
			this.ReturnToHome();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00030454 File Offset: 0x0002F454
		protected void ReturnToHome()
		{
			this.panPayBills.Visible = false;
			this.panAccountDetail.Visible = false;
			this.panTransfer.Visible = false;
			this.panRecurring.Visible = false;
			this.panHome.Visible = true;
			this.panHome.Dock = DockStyle.Fill;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000304B0 File Offset: 0x0002F4B0
		private void linkBack2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.ReturnToHome();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000304BC File Offset: 0x0002F4BC
		private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cboTo.Items.Clear();
			foreach (object obj in this.bankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				if (ba != this.cboFrom.SelectedItem)
				{
					this.cboTo.Items.Add(ba);
				}
			}
			this.cboTo.SelectedIndex = 0;
			BankAccount account = (BankAccount)this.cboFrom.SelectedItem;
			this.labFromBal.Text = Utilities.FC(account.EndingBalance(), 2, A.I.CurrencyConversion);
			this.updAmount.Maximum = (decimal)account.EndingBalance();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000305B0 File Offset: 0x0002F5B0
		private void linkTransfer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.bankAccounts.Count < 2)
			{
				MessageBox.Show(A.R.GetString("You need at least two accounts open to transfer funds between them."), A.R.GetString("Cannot Transfer"));
			}
			else
			{
				this.panHome.Visible = false;
				this.panTransfer.Visible = true;
				this.panTransfer.Dock = DockStyle.Fill;
				this.cboFrom.Items.Clear();
				foreach (object obj in this.bankAccounts.Values)
				{
					BankAccount ba = (BankAccount)obj;
					this.cboFrom.Items.Add(ba);
				}
				this.cboFrom.SelectedIndex = 0;
				this.updAmount.Value = 0m;
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000306BC File Offset: 0x0002F6BC
		private void btnTransfer_Click(object sender, EventArgs e)
		{
			try
			{
				BankAccount from = (BankAccount)this.cboFrom.SelectedItem;
				BankAccount to = (BankAccount)this.cboTo.SelectedItem;
				A.SA.TransferFunds(A.MF.CurrentEntityID, from.AccountNumber, to.AccountNumber, (float)this.updAmount.Value);
				MessageBox.Show(A.R.GetString("Funds transferred successfully."), A.R.GetString("Transfer Funds"));
				this.ReturnToHome();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0003076C File Offset: 0x0002F76C
		private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
		{
			BankAccount account = (BankAccount)this.cboTo.SelectedItem;
			this.labToBal.Text = Utilities.FC(account.EndingBalance(), 2, A.I.CurrencyConversion);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000307B0 File Offset: 0x0002F7B0
		private void linkRecurring_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.panHome.Visible = false;
			this.panRecurring.Visible = true;
			this.panRecurring.Dock = DockStyle.Fill;
			this.panPayees2.Controls.Clear();
			this.cboPayAccount2.Items.Clear();
			int y = 5;
			foreach (object obj in this.payees)
			{
				BankAccount payee = (BankAccount)obj;
				RecurringPaymentControl rpc = new RecurringPaymentControl();
				rpc.Location = new Point(0, y);
				rpc.PayeeName.Text = payee.BankName;
				if (payee is InstallmentLoan)
				{
					Label payeeName = rpc.PayeeName;
					payeeName.Text += A.R.GetString(" Acct# {0}", new object[]
					{
						payee.AccountNumber
					});
				}
				rpc.PayeeAccountNumber = payee.AccountNumber;
				this.panPayees2.Controls.Add(rpc);
				y += 35;
			}
			this.panPayees2.Height = y;
			this.btnDoneRecurring.Top = this.panPayees2.Bottom + 5;
			foreach (object obj2 in this.bankAccounts.Values)
			{
				BankAccount a = (BankAccount)obj2;
				if (a is CheckingAccount)
				{
					this.cboPayAccount2.Items.Add(a);
				}
			}
			if (this.cboPayAccount2.Items.Count > 0)
			{
				this.cboPayAccount2.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show(A.R.GetString("You need a checking account at this bank to pay bills."), A.R.GetString("Pay Bills"));
				this.ReturnToHome();
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00030A04 File Offset: 0x0002FA04
		private void btnDoneRecurring_Click(object sender, EventArgs e)
		{
			ArrayList payments = new ArrayList();
			foreach (object obj in this.panPayees2.Controls)
			{
				RecurringPaymentControl rpc = (RecurringPaymentControl)obj;
				try
				{
					RecurringPayment p = rpc.RecurringPayment;
					if (p != null)
					{
						payments.Add(p);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(A.R.GetString("Invalid amount entered for {0}. Please correct.", new object[]
					{
						rpc.PayeeName.Text
					}), A.R.GetString("Invalid Entry"));
					return;
				}
			}
			try
			{
				A.SA.SetRecurringPayments(A.MF.CurrentEntityID, ((BankAccount)this.cboPayAccount2.SelectedItem).AccountNumber, payments);
				MessageBox.Show(A.R.GetString("Your recurring payments have been set up."), A.R.GetString("Success"));
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
			this.ReturnToHome();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00030B5C File Offset: 0x0002FB5C
		private void linkLabel3_Click(object sender, EventArgs e)
		{
			this.ReturnToHome();
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00030B68 File Offset: 0x0002FB68
		private void cboPayAccount2_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (object obj in ((CheckingAccount)this.cboPayAccount2.SelectedItem).RecurringPayments)
			{
				RecurringPayment rp = (RecurringPayment)obj;
				foreach (object obj2 in this.panPayees2.Controls)
				{
					RecurringPaymentControl rpc = (RecurringPaymentControl)obj2;
					if (rp.PayeeAccountNumber == rpc.PayeeAccountNumber)
					{
						rpc.RecurringPayment = rp;
					}
				}
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00030C54 File Offset: 0x0002FC54
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0400038D RID: 909
		protected string url = null;

		// Token: 0x0400038E RID: 910
		private SortedList bankAccounts;

		// Token: 0x0400038F RID: 911
		private ArrayList payees;

		// Token: 0x04000390 RID: 912
		private BankAccount account;

		// Token: 0x04000391 RID: 913
		protected static Font font = new Font("Arial", 10f);

		// Token: 0x04000392 RID: 914
		protected static Font fontS = new Font("Arial", 10f, FontStyle.Bold);

		// Token: 0x04000393 RID: 915
		protected static Brush brush = new SolidBrush(Color.Gray);

		// Token: 0x04000394 RID: 916
		protected static StringFormat sfr = new StringFormat();

		// Token: 0x04000395 RID: 917
		protected static StringFormat sfc = new StringFormat();

		// Token: 0x04000396 RID: 918
		protected static Pen pen = new Pen(frmOnlineBanking.brush, 1f);

		// Token: 0x04000397 RID: 919
		protected int margin = 5;

		// Token: 0x04000398 RID: 920
		protected int colWidth = 80;
	}
}
