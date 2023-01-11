namespace KMI.Sim
{
	// Token: 0x02000076 RID: 118
	public partial class frmLanguage : global::System.Windows.Forms.Form
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x0001E7F8 File Offset: 0x0001D7F8
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

		// Token: 0x06000443 RID: 1091 RVA: 0x0001E834 File Offset: 0x0001D834
		private void InitializeComponent()
		{
			this.lstLanguages = new global::System.Windows.Forms.ListBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lstLanguages.Location = new global::System.Drawing.Point(40, 16);
			this.lstLanguages.Name = "lstLanguages";
			this.lstLanguages.Size = new global::System.Drawing.Size(208, 69);
			this.lstLanguages.TabIndex = 0;
			this.btnOK.Location = new global::System.Drawing.Point(96, 104);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(282, 144);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.lstLanguages);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmLanguage";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Language";
			base.Closed += new global::System.EventHandler(this.frmLanguage_Closed);
			base.ResumeLayout(false);
		}

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.ListBox lstLanguages;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040002C9 RID: 713
		private global::System.ComponentModel.Container components = null;
	}
}
