namespace KMI.Biz
{
	// Token: 0x02000003 RID: 3
	public partial class frmInputAmount : global::System.Windows.Forms.Form
	{
		// Token: 0x06000050 RID: 80 RVA: 0x000048B8 File Offset: 0x000038B8
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

		// Token: 0x06000051 RID: 81 RVA: 0x000048F4 File Offset: 0x000038F4
		private void InitializeComponent()
		{
			this.labMsg = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.btnCancel = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.labMsg.Location = new global::System.Drawing.Point(32, 24);
			this.labMsg.Name = "labMsg";
			this.labMsg.Size = new global::System.Drawing.Size(232, 144);
			this.labMsg.TabIndex = 0;
			this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new global::System.Drawing.Point(32, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.updAmount.Location = new global::System.Drawing.Point(80, 184);
			this.updAmount.Name = "updAmount";
			this.updAmount.TabIndex = 2;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(160, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(292, 266);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.labMsg);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmInputAmount";
			base.ShowInTaskbar = false;
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label labMsg;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000006 RID: 6
		public global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000008 RID: 8
		private global::System.ComponentModel.Container components = null;
	}
}
