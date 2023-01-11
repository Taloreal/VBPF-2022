namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmOpenBankAccount.
	/// </summary>
	// Token: 0x02000057 RID: 87
	public partial class frmOpenBankAccount : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000255 RID: 597 RVA: 0x000268F4 File Offset: 0x000258F4
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
		// Token: 0x06000256 RID: 598 RVA: 0x00026930 File Offset: 0x00025930
		private void InitializeComponent()
		{
			this.label2 = new global::System.Windows.Forms.Label();
			this.updInitDeposit = new global::System.Windows.Forms.NumericUpDown();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.optCash = new global::System.Windows.Forms.RadioButton();
			this.optTransfer = new global::System.Windows.Forms.RadioButton();
			this.cboAccounts = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.updInitDeposit).BeginInit();
			base.SuspendLayout();
			this.label2.Location = new global::System.Drawing.Point(40, 20);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(132, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Source of Initial Deposit:";
			this.updInitDeposit.DecimalPlaces = 2;
			this.updInitDeposit.Location = new global::System.Drawing.Point(44, 152);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updInitDeposit;
			int[] array = new int[4];
			array[0] = 1000000;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updInitDeposit;
			array = new int[4];
			array[0] = 10;
			numericUpDown2.Minimum = new decimal(array);
			this.updInitDeposit.Name = "updInitDeposit";
			this.updInitDeposit.Size = new global::System.Drawing.Size(116, 20);
			this.updInitDeposit.TabIndex = 2;
			this.updInitDeposit.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.updInitDeposit;
			array = new int[4];
			array[0] = 100;
			numericUpDown3.Value = new decimal(array);
			this.btnOK.Location = new global::System.Drawing.Point(24, 192);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(60, 24);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(104, 192);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(60, 24);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(184, 192);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(60, 24);
			this.btnHelp.TabIndex = 9;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label1.Location = new global::System.Drawing.Point(44, 132);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(132, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Amount of Initial Deposit:";
			this.optCash.Checked = true;
			this.optCash.Location = new global::System.Drawing.Point(56, 36);
			this.optCash.Name = "optCash";
			this.optCash.TabIndex = 11;
			this.optCash.TabStop = true;
			this.optCash.Text = "Cash";
			this.optTransfer.Enabled = false;
			this.optTransfer.Location = new global::System.Drawing.Point(56, 64);
			this.optTransfer.Name = "optTransfer";
			this.optTransfer.Size = new global::System.Drawing.Size(176, 16);
			this.optTransfer.TabIndex = 12;
			this.optTransfer.Text = "Other Account at this Bank:";
			this.optTransfer.CheckedChanged += new global::System.EventHandler(this.optTransfer_CheckedChanged);
			this.cboAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccounts.Enabled = false;
			this.cboAccounts.Location = new global::System.Drawing.Point(80, 88);
			this.cboAccounts.Name = "cboAccounts";
			this.cboAccounts.Size = new global::System.Drawing.Size(152, 21);
			this.cboAccounts.TabIndex = 13;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(268, 234);
			base.Controls.Add(this.cboAccounts);
			base.Controls.Add(this.optTransfer);
			base.Controls.Add(this.optCash);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.updInitDeposit);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmOpenBankAccount";
			base.ShowInTaskbar = false;
			this.Text = "Open New Bank Account";
			((global::System.ComponentModel.ISupportInitialize)this.updInitDeposit).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040002B7 RID: 695
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002B8 RID: 696
		private global::System.Windows.Forms.NumericUpDown updInitDeposit;

		// Token: 0x040002B9 RID: 697
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040002BA RID: 698
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040002BB RID: 699
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.RadioButton optCash;

		// Token: 0x040002BD RID: 701
		private global::System.Windows.Forms.RadioButton optTransfer;

		// Token: 0x040002BE RID: 702
		private global::System.Windows.Forms.ComboBox cboAccounts;

		// Token: 0x040002BF RID: 703
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040002C0 RID: 704
		private global::System.ComponentModel.Container components = null;
	}
}
