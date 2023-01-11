namespace KMI.Utility
{
	// Token: 0x02000010 RID: 16
	public partial class frmInputString : global::System.Windows.Forms.Form
	{
		// Token: 0x06000099 RID: 153 RVA: 0x0000683C File Offset: 0x0000583C
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

		// Token: 0x0600009A RID: 154 RVA: 0x00006878 File Offset: 0x00005878
		private void InitializeComponent()
		{
			this.labText = new global::System.Windows.Forms.Label();
			this.txtResponse = new global::System.Windows.Forms.TextBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labText.Location = new global::System.Drawing.Point(16, 16);
			this.labText.Name = "labText";
			this.labText.Size = new global::System.Drawing.Size(288, 72);
			this.labText.TabIndex = 0;
			this.labText.Text = "label1";
			this.labText.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.txtResponse.Location = new global::System.Drawing.Point(16, 96);
			this.txtResponse.Name = "txtResponse";
			this.txtResponse.Size = new global::System.Drawing.Size(288, 20);
			this.txtResponse.TabIndex = 1;
			this.txtResponse.Text = "";
			this.txtResponse.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtResponse_Validating);
			this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new global::System.Drawing.Point(328, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(56, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnCancel.CausesValidation = false;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(328, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(400, 134);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.txtResponse);
			base.Controls.Add(this.labText);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmInputString";
			base.ShowInTaskbar = false;
			this.Text = "#";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.txtResponse_Validating);
			base.ResumeLayout(false);
		}

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Label labText;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.TextBox txtResponse;

		// Token: 0x04000030 RID: 48
		private global::System.ComponentModel.Container components = null;
	}
}
