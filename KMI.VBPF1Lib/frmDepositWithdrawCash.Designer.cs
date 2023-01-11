namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmDepositWithdrawCash.
	/// </summary>
	// Token: 0x0200006F RID: 111
	public partial class frmDepositWithdrawCash : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002EA RID: 746 RVA: 0x00032828 File Offset: 0x00031828
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
		// Token: 0x060002EB RID: 747 RVA: 0x00032864 File Offset: 0x00031864
		private void InitializeComponent()
		{
			this.cboAccounts = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.cboAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccounts.Location = new global::System.Drawing.Point(40, 44);
			this.cboAccounts.Name = "cboAccounts";
			this.cboAccounts.Size = new global::System.Drawing.Size(216, 21);
			this.cboAccounts.TabIndex = 2;
			this.cboAccounts.SelectedIndexChanged += new global::System.EventHandler(this.cboAccounts_SelectedIndexChanged);
			this.label1.Location = new global::System.Drawing.Point(40, 28);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(92, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Account";
			this.btnHelp.Location = new global::System.Drawing.Point(196, 132);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(68, 24);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(108, 132);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(68, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(20, 132);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(68, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label2.Location = new global::System.Drawing.Point(40, 84);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Amount:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 20;
			numericUpDown.Increment = new decimal(array);
			this.updAmount.Location = new global::System.Drawing.Point(116, 80);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(96, 20);
			this.updAmount.TabIndex = 8;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updAmount;
			array = new int[4];
			array[0] = 20;
			numericUpDown2.Value = new decimal(array);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(288, 174);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.cboAccounts);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmDepositWithdrawCash";
			base.ShowInTaskbar = false;
			this.Text = "#";
			base.Load += new global::System.EventHandler(this.frmDepositWithdrawCash_Load);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040003C3 RID: 963
		private global::System.ComponentModel.Container components = null;

		// Token: 0x040003C4 RID: 964
		private global::System.Windows.Forms.ComboBox cboAccounts;

		// Token: 0x040003C5 RID: 965
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003C6 RID: 966
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040003C7 RID: 967
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040003C8 RID: 968
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040003C9 RID: 969
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040003CA RID: 970
		public global::System.Windows.Forms.NumericUpDown updAmount;
	}
}
