namespace KMI.Utility
{
	// Token: 0x0200000B RID: 11
	public partial class frmPassword : global::System.Windows.Forms.Form
	{
		// Token: 0x06000076 RID: 118 RVA: 0x000059E4 File Offset: 0x000049E4
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

		// Token: 0x06000077 RID: 119 RVA: 0x00005A20 File Offset: 0x00004A20
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtPassword = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(48, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(176, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.label1.Location = new global::System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Password:";
			this.txtPassword.Location = new global::System.Drawing.Point(96, 40);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new global::System.Drawing.Size(192, 20);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.Text = "";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(322, 160);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPassword";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Password Required";
			base.ResumeLayout(false);
		}

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.TextBox txtPassword;

		// Token: 0x04000024 RID: 36
		private global::System.ComponentModel.Container components = null;
	}
}
