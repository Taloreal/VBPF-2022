namespace KMI.Sim
{
	// Token: 0x0200001D RID: 29
	public partial class frmAbout : global::System.Windows.Forms.Form
	{
		// Token: 0x0600015C RID: 348 RVA: 0x0000BFC8 File Offset: 0x0000AFC8
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

		// Token: 0x0600015D RID: 349 RVA: 0x0000C004 File Offset: 0x0000B004
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCurrentSimInfo = new global::System.Windows.Forms.Button();
			this.labProductName = new global::System.Windows.Forms.Label();
			this.labVersion = new global::System.Windows.Forms.Label();
			this.labCopyrightInfo = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(112, 176);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(104, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCurrentSimInfo.Location = new global::System.Drawing.Point(232, 168);
			this.btnCurrentSimInfo.Name = "btnCurrentSimInfo";
			this.btnCurrentSimInfo.Size = new global::System.Drawing.Size(64, 32);
			this.btnCurrentSimInfo.TabIndex = 3;
			this.btnCurrentSimInfo.Text = "Current Sim Info";
			this.btnCurrentSimInfo.Click += new global::System.EventHandler(this.btnCurrentSimInfo_Click);
			this.labProductName.Location = new global::System.Drawing.Point(32, 32);
			this.labProductName.Name = "labProductName";
			this.labProductName.Size = new global::System.Drawing.Size(264, 32);
			this.labProductName.TabIndex = 4;
			this.labProductName.Text = "label1";
			this.labProductName.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.labVersion.Location = new global::System.Drawing.Point(32, 72);
			this.labVersion.Name = "labVersion";
			this.labVersion.Size = new global::System.Drawing.Size(264, 16);
			this.labVersion.TabIndex = 5;
			this.labVersion.Text = "label1";
			this.labCopyrightInfo.Location = new global::System.Drawing.Point(32, 104);
			this.labCopyrightInfo.Name = "labCopyrightInfo";
			this.labCopyrightInfo.Size = new global::System.Drawing.Size(264, 48);
			this.labCopyrightInfo.TabIndex = 6;
			this.labCopyrightInfo.Text = "label1";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(322, 216);
			base.Controls.Add(this.labCopyrightInfo);
			base.Controls.Add(this.labVersion);
			base.Controls.Add(this.labProductName);
			base.Controls.Add(this.btnCurrentSimInfo);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "frmAbout";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSplashAbout";
			base.Load += new global::System.EventHandler(this.frmAbout_Load);
			base.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.frmSplashAbout_MouseUp);
			base.ResumeLayout(false);
		}

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Button btnCurrentSimInfo;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Label labProductName;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label labVersion;

		// Token: 0x040000E2 RID: 226
		protected global::System.Windows.Forms.Label labCopyrightInfo;

		// Token: 0x040000E3 RID: 227
		private global::System.ComponentModel.IContainer components;
	}
}
