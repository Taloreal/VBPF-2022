namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmTrade.
	/// </summary>
	// Token: 0x0200004C RID: 76
	public partial class frmTrade : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000208 RID: 520 RVA: 0x0001F644 File Offset: 0x0001E644
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
		// Token: 0x06000209 RID: 521 RVA: 0x0001F680 File Offset: 0x0001E680
		private void InitializeComponent()
		{
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cboFund = new global::System.Windows.Forms.ComboBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.cboSource = new global::System.Windows.Forms.ComboBox();
			this.labSource = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Increment = new decimal(array);
			this.updAmount.Location = new global::System.Drawing.Point(136, 64);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updAmount;
			array = new int[4];
			array[0] = 1000000;
			numericUpDown2.Maximum = new decimal(array);
			this.updAmount.Name = "updAmount";
			this.updAmount.TabIndex = 9;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.label4.Location = new global::System.Drawing.Point(96, 24);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(40, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Fund:";
			this.label5.Location = new global::System.Drawing.Point(56, 64);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(80, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "Dollar Amount:";
			this.cboFund.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFund.Location = new global::System.Drawing.Point(136, 24);
			this.cboFund.Name = "cboFund";
			this.cboFund.Size = new global::System.Drawing.Size(120, 21);
			this.cboFund.TabIndex = 17;
			this.btnOK.Location = new global::System.Drawing.Point(24, 160);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 19;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(136, 160);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.button2_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(248, 160);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 21;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.cboSource.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSource.Location = new global::System.Drawing.Point(136, 104);
			this.cboSource.Name = "cboSource";
			this.cboSource.Size = new global::System.Drawing.Size(120, 21);
			this.cboSource.TabIndex = 22;
			this.labSource.Location = new global::System.Drawing.Point(8, 104);
			this.labSource.Name = "labSource";
			this.labSource.Size = new global::System.Drawing.Size(120, 24);
			this.labSource.TabIndex = 23;
			this.labSource.Text = "Withdraw money from:";
			this.labSource.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(368, 206);
			base.Controls.Add(this.labSource);
			base.Controls.Add(this.cboSource);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.cboFund);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.updAmount);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTrade";
			base.ShowInTaskbar = false;
			this.Text = "Trade";
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.ComboBox cboFund;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.ComboBox cboSource;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.Label labSource;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000226 RID: 550
		private global::System.ComponentModel.Container components = null;
	}
}
