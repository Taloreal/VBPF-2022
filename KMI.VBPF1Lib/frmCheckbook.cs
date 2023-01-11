using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;
using KMI.VBPF1Lib.Custom_Controls;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCheckbook.
	/// </summary>
	// Token: 0x02000051 RID: 81
	public partial class frmCheckbook : Form
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00023B30 File Offset: 0x00022B30
		public frmCheckbook()
		{
			this.InitializeComponent();
			this.chkCheck = new CheckControl();
			this.chkCheck.Location = new Point(40, 200);
			this.chkCheck.Visible = false;
			base.Controls.Add(this.chkCheck);
			this.autofill = ((AppSimSettings)A.SA.getSimSettings()).AutofillCheckRegister;
			SortedList bankAccounts = A.SA.GetBankAccounts(A.MF.CurrentEntityID);
			foreach (object obj in bankAccounts.Values)
			{
				BankAccount ba = (BankAccount)obj;
				if (ba is CheckingAccount)
				{
					this.cboAccount.Items.Add(ba);
				}
			}
			if (this.cboAccount.Items.Count > 0)
			{
				this.cboAccount.SelectedIndex = 0;
				return;
			}
			throw new SimApplicationException(A.R.GetString("You must open a checking account before you can pay by check or view the check register. In the City View, click on a bank to open an account."));
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00023C78 File Offset: 0x00022C78
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00023C90 File Offset: 0x00022C90
		protected CheckingAccount Account
		{
			get
			{
				return this.account;
			}
			set
			{
				this.account = value;
				this.chkCheck.labCheckNumber.Text = this.account.NextCheckNumber.ToString();
				this.chkCheck.labCheckNumberBottom.Text = this.chkCheck.labCheckNumber.Text;
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000248F6 File Offset: 0x000238F6
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00024900 File Offset: 0x00023900
		private void btnSendCheck_Click(object sender, EventArgs e)
		{
			Check c = new Check(this.Account.AccountNumber);
			if (this.autofill || this.RegisterEntry(this.chkCheck.labCheckNumber.Text) || MessageBox.Show("You have not recorded this check number in your check register. You may lose track of checks you've written. Do you want to continue without writing in your check register?", "No Register Entry", MessageBoxButtons.YesNo) != DialogResult.No)
			{
				try
				{
					c.Amount = float.Parse(this.chkCheck.txtAmount.Text);
				}
				catch
				{
					MessageBox.Show(A.R.GetString("We couldn't understand the amount. Please try again."), A.R.GetString("Check Writing Error"));
					this.chkCheck.txtAmount.SelectAll();
					this.chkCheck.txtAmount.Focus();
					return;
				}
				c.Number = this.Account.NextCheckNumber;
				c.Payee = this.chkCheck.labPayee.Text;
				A.SA.PayByCheck(A.MF.CurrentEntityID, this.Account.AccountNumber, this.currentBill, c);
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00024A3C File Offset: 0x00023A3C
		public void FillIn(Bill bill)
		{
			this.currentBill = bill;
			this.chkCheck.Visible = true;
			this.chkCheck.Bill = bill;
			this.chkCheck.labPayor.Text = this.Account.OwnerName;
			this.chkCheck.labSignature.Text = this.Account.OwnerName;
			this.chkCheck.labCheckNumber.Text = this.Account.NextCheckNumber.ToString();
			this.chkCheck.labCheckNumberBottom.Text = this.Account.NextCheckNumber.ToString();
			this.chkCheck.labBankName.Text = this.Account.BankName;
			this.chkCheck.labAccountNumber.Text = this.Account.AccountNumber.ToString();
			this.btnSendCheck.Enabled = true;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00024B38 File Offset: 0x00023B38
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Account = (CheckingAccount)this.cboAccount.SelectedItem;
			ArrayList entries;
			if (this.autofill)
			{
				entries = this.Account.BuildRegisterFromTransactions();
			}
			else
			{
				entries = this.Account.RegisterEntries;
			}
			this.panRegister.Controls.Clear();
			for (int i = 0; i < entries.Count + 20; i++)
			{
				RegisterLine j = new RegisterLine();
				j.Top = i * 32;
				this.panRegister.Controls.Add(j);
				if (i < entries.Count)
				{
					j.FillInFields((CheckRegisterEntry)entries[i]);
				}
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00024BF7 File Offset: 0x00023BF7
		private void frmCheckbook_Load(object sender, EventArgs e)
		{
			this.chkCheck.txtAmount.Focus();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00024C0C File Offset: 0x00023C0C
		private void frmCheckbook_Closing(object sender, CancelEventArgs e)
		{
			try
			{
				ArrayList entries = new ArrayList();
				foreach (object obj in this.panRegister.Controls)
				{
					RegisterLine r = (RegisterLine)obj;
					CheckRegisterEntry entry = r.CreateCheckRegisterEntry();
					if (!entry.IsEmpty())
					{
						entries.Add(entry);
					}
				}
				if (!this.autofill)
				{
					A.SA.SetRegisterEntries(A.MF.CurrentEntityID, "test", this.Account.AccountNumber, entries);
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00024CEC File Offset: 0x00023CEC
		protected bool RegisterEntry(string checkNumber)
		{
			foreach (object obj in this.panRegister.Controls)
			{
				RegisterLine r = (RegisterLine)obj;
				if (r.txtNumber.Text == checkNumber)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00024D74 File Offset: 0x00023D74
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Check Register"));
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00024D8C File Offset: 0x00023D8C
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.studentName = "";
			frmInputString form = new frmInputString(S.R.GetString("Student Name"), S.R.GetString("Enter your name to help identify your printout on a shared printer:"), this.studentName);
			form.ShowDialog(this);
			this.studentName = form.Response;
			Utilities.PrintWithExceptionHandling(this.Text, new PrintPageEventHandler(this.PrintPage));
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00024DFC File Offset: 0x00023DFC
		protected void PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			SolidBrush b = new SolidBrush(Color.Black);
			Pen pen = new Pen(b, 1f);
			StringFormat sfc = new StringFormat();
			sfc.Alignment = StringAlignment.Center;
			sfc.LineAlignment = StringAlignment.Center;
			int y = 10;
			if (this.studentName.Length > 0)
			{
				e.Graphics.DrawString(A.R.GetString("This report belongs to: {0}", new object[]
				{
					this.studentName
				}), this.Font, b, 0f, (float)y);
			}
			y = 41;
			int i = 0;
			foreach (object obj in base.Controls)
			{
				Control c = (Control)obj;
				if (c is Label && c.Text != "")
				{
					Rectangle r = new Rectangle(c.Left, y, c.Width - 1, c.Height);
					e.Graphics.DrawRectangle(pen, r);
					e.Graphics.DrawString(c.Text, c.Font, b, r, sfc);
					i++;
				}
			}
			y += 31;
			foreach (object obj2 in this.panRegister.Controls)
			{
				RegisterLine r2 = (RegisterLine)obj2;
				r2.Print(e.Graphics, y);
				y += 31;
			}
		}

		// Token: 0x04000295 RID: 661
		private bool autofill;

		// Token: 0x04000296 RID: 662
		private CheckControl chkCheck;

		// Token: 0x04000297 RID: 663
		private CheckingAccount account;

		// Token: 0x04000298 RID: 664
		protected Bill currentBill;

		// Token: 0x04000299 RID: 665
		private string studentName;
	}
}
