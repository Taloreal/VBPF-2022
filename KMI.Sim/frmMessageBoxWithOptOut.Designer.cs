namespace KMI.Sim
{
	// Token: 0x02000053 RID: 83
	public partial class frmMessageBoxWithOptOut : global::System.Windows.Forms.Form
	{
		// Token: 0x06000314 RID: 788 RVA: 0x00018470 File Offset: 0x00017470
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

		// Token: 0x06000315 RID: 789 RVA: 0x000184AC File Offset: 0x000174AC
		private void InitializeComponent()
		{
			this.labText = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.chkDontShow = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.labText.Location = new global::System.Drawing.Point(24, 24);
			this.labText.Name = "labText";
			this.labText.Size = new global::System.Drawing.Size(336, 96);
			this.labText.TabIndex = 0;
			this.labText.Text = "#";
			this.btnClose.Location = new global::System.Drawing.Point(304, 128);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(56, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "OK";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.chkDontShow.Location = new global::System.Drawing.Point(32, 128);
			this.chkDontShow.Name = "chkDontShow";
			this.chkDontShow.Size = new global::System.Drawing.Size(192, 16);
			this.chkDontShow.TabIndex = 2;
			this.chkDontShow.Text = "Don't show me this again";
			base.AcceptButton = this.btnClose;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(384, 166);
			base.Controls.Add(this.chkDontShow);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.labText);
			base.Name = "frmMessageBoxWithOptOut";
			base.ShowInTaskbar = false;
			base.Closed += new global::System.EventHandler(this.frmMessageBoxWithOptOut_Closed);
			base.ResumeLayout(false);
		}

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.Label labText;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.CheckBox chkDontShow;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040001ED RID: 493
		private global::System.ComponentModel.Container components = null;
	}
}
