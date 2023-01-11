namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmDepositWithdrawCash.
	/// </summary>
	// Token: 0x0200000E RID: 14
	public partial class frmCloseAccount : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600003B RID: 59 RVA: 0x000053DC File Offset: 0x000043DC
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
		// Token: 0x0600003C RID: 60 RVA: 0x00005418 File Offset: 0x00004418
		private void InitializeComponent()
		{
			this.cboAccounts = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.cboAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccounts.Location = new global::System.Drawing.Point(40, 36);
			this.cboAccounts.Name = "cboAccounts";
			this.cboAccounts.Size = new global::System.Drawing.Size(216, 21);
			this.cboAccounts.TabIndex = 2;
			this.label1.Location = new global::System.Drawing.Point(40, 20);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(148, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Account to Close:";
			this.btnHelp.Location = new global::System.Drawing.Point(196, 152);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(68, 24);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(108, 152);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(68, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(20, 152);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(68, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label2.Location = new global::System.Drawing.Point(60, 72);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(164, 32);
			this.label2.TabIndex = 7;
			this.label2.Text = "Any remaining funds will be refunded to you in cash. ";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label3.Location = new global::System.Drawing.Point(60, 112);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(160, 32);
			this.label3.TabIndex = 8;
			this.label3.Text = "Only credit cards with zero balances are listed.";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(288, 194);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.cboAccounts);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmCloseAccount";
			base.ShowInTaskbar = false;
			this.Text = "Close Account";
			base.Load += new global::System.EventHandler(this.frmDepositWithdrawCash_Load);
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000A2 RID: 162
		private global::System.ComponentModel.Container components = null;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.ComboBox cboAccounts;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label label2;
	}
}
