namespace KMI.Biz
{
	// Token: 0x0200000E RID: 14
	public partial class frmTransferCash : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00006788 File Offset: 0x00005788
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

		// Token: 0x0600005F RID: 95 RVA: 0x000067C4 File Offset: 0x000057C4
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cboFrom = new global::System.Windows.Forms.ComboBox();
			this.cboTo = new global::System.Windows.Forms.ComboBox();
			this.labCashFrom = new global::System.Windows.Forms.Label();
			this.labCashTo = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(48, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(160, 136);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(272, 136);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 23);
			this.btnHelp.TabIndex = 12;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label1.Location = new global::System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "From:";
			this.label2.Location = new global::System.Drawing.Point(24, 80);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Available Cash:";
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Increment = new decimal(array);
			this.updAmount.Location = new global::System.Drawing.Point(296, 48);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(96, 20);
			this.updAmount.TabIndex = 5;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.label3.Location = new global::System.Drawing.Point(296, 32);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(88, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Amount:";
			this.label4.Location = new global::System.Drawing.Point(160, 32);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(88, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "To:";
			this.label5.Location = new global::System.Drawing.Point(160, 80);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(88, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Available Cash:";
			this.cboFrom.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFrom.Location = new global::System.Drawing.Point(24, 48);
			this.cboFrom.Name = "cboFrom";
			this.cboFrom.Size = new global::System.Drawing.Size(112, 21);
			this.cboFrom.TabIndex = 3;
			this.cboFrom.SelectedIndexChanged += new global::System.EventHandler(this.cboFrom_SelectedIndexChanged);
			this.cboTo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTo.Location = new global::System.Drawing.Point(160, 48);
			this.cboTo.Name = "cboTo";
			this.cboTo.Size = new global::System.Drawing.Size(112, 21);
			this.cboTo.TabIndex = 4;
			this.cboTo.SelectedIndexChanged += new global::System.EventHandler(this.cboTo_SelectedIndexChanged);
			this.labCashFrom.Location = new global::System.Drawing.Point(24, 96);
			this.labCashFrom.Name = "labCashFrom";
			this.labCashFrom.Size = new global::System.Drawing.Size(120, 16);
			this.labCashFrom.TabIndex = 8;
			this.labCashFrom.Text = "#";
			this.labCashTo.Location = new global::System.Drawing.Point(160, 96);
			this.labCashTo.Name = "labCashTo";
			this.labCashTo.Size = new global::System.Drawing.Size(120, 16);
			this.labCashTo.TabIndex = 9;
			this.labCashTo.Text = "#";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(418, 184);
			base.Controls.Add(this.labCashTo);
			base.Controls.Add(this.labCashFrom);
			base.Controls.Add(this.cboTo);
			base.Controls.Add(this.cboFrom);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTransferCash";
			base.ShowInTaskbar = false;
			this.Text = "Transfer Cash";
			base.Load += new global::System.EventHandler(this.frmTransferCash_Load);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.ComboBox cboFrom;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.ComboBox cboTo;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.Label labCashFrom;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Label labCashTo;

		// Token: 0x04000056 RID: 86
		private global::System.ComponentModel.Container components = null;
	}
}
