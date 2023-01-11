namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmMethodOfPay.
	/// </summary>
	// Token: 0x02000058 RID: 88
	public partial class frmMethodOfPay : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600025C RID: 604 RVA: 0x00027160 File Offset: 0x00026160
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
		// Token: 0x0600025D RID: 605 RVA: 0x0002719C File Offset: 0x0002619C
		private void InitializeComponent()
		{
			this.optCheck = new global::System.Windows.Forms.RadioButton();
			this.optDirectDeposit = new global::System.Windows.Forms.RadioButton();
			this.cboAccounts = new global::System.Windows.Forms.ComboBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.optCheck.Checked = true;
			this.optCheck.Location = new global::System.Drawing.Point(40, 24);
			this.optCheck.Name = "optCheck";
			this.optCheck.Size = new global::System.Drawing.Size(144, 16);
			this.optCheck.TabIndex = 0;
			this.optCheck.TabStop = true;
			this.optCheck.Text = "Pay by Check";
			this.optDirectDeposit.Enabled = false;
			this.optDirectDeposit.Location = new global::System.Drawing.Point(40, 52);
			this.optDirectDeposit.Name = "optDirectDeposit";
			this.optDirectDeposit.Size = new global::System.Drawing.Size(144, 20);
			this.optDirectDeposit.TabIndex = 1;
			this.optDirectDeposit.Text = "Direct Deposit";
			this.optDirectDeposit.CheckedChanged += new global::System.EventHandler(this.optDirectDeposit_CheckedChanged);
			this.cboAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccounts.Enabled = false;
			this.cboAccounts.Location = new global::System.Drawing.Point(76, 92);
			this.cboAccounts.Name = "cboAccounts";
			this.cboAccounts.Size = new global::System.Drawing.Size(176, 21);
			this.cboAccounts.TabIndex = 2;
			this.btnOK.Location = new global::System.Drawing.Point(64, 148);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(68, 24);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label1.Location = new global::System.Drawing.Point(76, 76);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(128, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Bank Account:";
			this.btnHelp.Location = new global::System.Drawing.Point(156, 148);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(68, 24);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(292, 190);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.cboAccounts);
			base.Controls.Add(this.optDirectDeposit);
			base.Controls.Add(this.optCheck);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmMethodOfPay";
			base.ShowInTaskbar = false;
			this.Text = "Method Of Pay";
			base.ResumeLayout(false);
		}

		// Token: 0x040002C3 RID: 707
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040002C4 RID: 708
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002C5 RID: 709
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040002C6 RID: 710
		private global::System.Windows.Forms.RadioButton optCheck;

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.RadioButton optDirectDeposit;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.ComboBox cboAccounts;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040002C9 RID: 713
		private global::System.ComponentModel.Container components = null;
	}
}
