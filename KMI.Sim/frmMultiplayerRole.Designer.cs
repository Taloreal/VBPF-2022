namespace KMI.Sim
{
	// Token: 0x0200006F RID: 111
	public partial class frmMultiplayerRole : global::System.Windows.Forms.Form
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x0001D734 File Offset: 0x0001C734
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

		// Token: 0x0600040E RID: 1038 RVA: 0x0001D770 File Offset: 0x0001C770
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.lstRoles = new global::System.Windows.Forms.ListBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(224, 56);
			this.label1.TabIndex = 0;
			this.label1.Text = "This multiplayer session requires you to play a specific role. Please choose a role as directed by your instructor.";
			this.lstRoles.Location = new global::System.Drawing.Point(56, 112);
			this.lstRoles.Name = "lstRoles";
			this.lstRoles.Size = new global::System.Drawing.Size(176, 69);
			this.lstRoles.TabIndex = 1;
			this.btnOK.Location = new global::System.Drawing.Point(96, 216);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(292, 264);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.lstRoles);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmMultiplayerRole";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Choose Multiplayer Role";
			base.ResumeLayout(false);
		}

		// Token: 0x040002B4 RID: 692
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002B5 RID: 693
		private global::System.Windows.Forms.ListBox lstRoles;

		// Token: 0x040002B6 RID: 694
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040002B7 RID: 695
		private global::System.ComponentModel.Container components = null;
	}
}
