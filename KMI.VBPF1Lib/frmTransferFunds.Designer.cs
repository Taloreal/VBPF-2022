namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmDepositWithdrawCash.
	/// </summary>
	// Token: 0x0200004B RID: 75
	public partial class frmTransferFunds : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000200 RID: 512 RVA: 0x0001ED14 File Offset: 0x0001DD14
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
		// Token: 0x06000201 RID: 513 RVA: 0x0001ED50 File Offset: 0x0001DD50
		private void InitializeComponent()
		{
			this.cboFromAccounts = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cboToAccounts = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.cboFromAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFromAccounts.Location = new global::System.Drawing.Point(40, 40);
			this.cboFromAccounts.Name = "cboFromAccounts";
			this.cboFromAccounts.Size = new global::System.Drawing.Size(216, 21);
			this.cboFromAccounts.TabIndex = 2;
			this.cboFromAccounts.SelectedIndexChanged += new global::System.EventHandler(this.cboFromAccounts_SelectedIndexChanged);
			this.label1.Location = new global::System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(92, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "From Account";
			this.btnHelp.Location = new global::System.Drawing.Point(196, 168);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(68, 24);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(108, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(68, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(20, 168);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(68, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label2.Location = new global::System.Drawing.Point(40, 124);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Amount:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.updAmount.Location = new global::System.Drawing.Point(116, 120);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Minimum = new decimal(array);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(96, 20);
			this.updAmount.TabIndex = 8;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updAmount;
			array = new int[4];
			array[0] = 20;
			numericUpDown2.Value = new decimal(array);
			this.label3.Location = new global::System.Drawing.Point(40, 72);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(92, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "To Account";
			this.cboToAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboToAccounts.Location = new global::System.Drawing.Point(40, 88);
			this.cboToAccounts.Name = "cboToAccounts";
			this.cboToAccounts.Size = new global::System.Drawing.Size(216, 21);
			this.cboToAccounts.TabIndex = 9;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(288, 206);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.cboToAccounts);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.cboFromAccounts);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTransferFunds";
			base.ShowInTaskbar = false;
			this.Text = "Transfer Funds";
			base.Load += new global::System.EventHandler(this.frmDepositWithdrawCash_Load);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000213 RID: 531
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.ComboBox cboFromAccounts;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.ComboBox cboToAccounts;

		// Token: 0x0400021C RID: 540
		public global::System.Windows.Forms.NumericUpDown updAmount;
	}
}
