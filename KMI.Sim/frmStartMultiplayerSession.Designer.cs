namespace KMI.Sim
{
	// Token: 0x0200002E RID: 46
	public partial class frmStartMultiplayerSession : global::System.Windows.Forms.Form
	{
		// Token: 0x060001D1 RID: 465 RVA: 0x0000EE6C File Offset: 0x0000DE6C
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

		// Token: 0x060001D2 RID: 466 RVA: 0x0000EEA8 File Offset: 0x0000DEA8
		private void InitializeComponent()
		{
			this.cmdOK = new global::System.Windows.Forms.Button();
			this.cmdCancel = new global::System.Windows.Forms.Button();
			this.cmdHelp = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtSessionName = new global::System.Windows.Forms.TextBox();
			this.chkRequireRoles = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.cmdOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cmdOK.Location = new global::System.Drawing.Point(40, 184);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new global::System.Drawing.Size(64, 24);
			this.cmdOK.TabIndex = 2;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new global::System.EventHandler(this.cmdOK_Click);
			this.cmdCancel.CausesValidation = false;
			this.cmdCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new global::System.Drawing.Point(120, 184);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new global::System.Drawing.Size(56, 24);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new global::System.EventHandler(this.cmdCancel_Click);
			this.cmdHelp.CausesValidation = false;
			this.cmdHelp.Location = new global::System.Drawing.Point(192, 184);
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.Size = new global::System.Drawing.Size(56, 24);
			this.cmdHelp.TabIndex = 4;
			this.cmdHelp.Text = "Help";
			this.cmdHelp.Click += new global::System.EventHandler(this.cmdHelp_Click);
			this.label2.Location = new global::System.Drawing.Point(56, 72);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(136, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Enter Session Name:";
			this.txtSessionName.Location = new global::System.Drawing.Point(56, 88);
			this.txtSessionName.Name = "txtSessionName";
			this.txtSessionName.Size = new global::System.Drawing.Size(168, 20);
			this.txtSessionName.TabIndex = 1;
			this.txtSessionName.Text = "";
			this.txtSessionName.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtSessionName_Validating);
			this.chkRequireRoles.Location = new global::System.Drawing.Point(72, 128);
			this.chkRequireRoles.Name = "chkRequireRoles";
			this.chkRequireRoles.Size = new global::System.Drawing.Size(152, 16);
			this.chkRequireRoles.TabIndex = 5;
			this.chkRequireRoles.Text = "Require Roles";
			base.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.cmdCancel;
			base.ClientSize = new global::System.Drawing.Size(292, 230);
			base.Controls.Add(this.chkRequireRoles);
			base.Controls.Add(this.txtSessionName);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.cmdHelp);
			base.Controls.Add(this.cmdCancel);
			base.Controls.Add(this.cmdOK);
			base.Name = "frmStartMultiplayerSession";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Multiplayer Session";
			base.ResumeLayout(false);
		}

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Button cmdOK;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Button cmdCancel;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Button cmdHelp;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.TextBox txtSessionName;

		// Token: 0x04000125 RID: 293
		public global::System.Windows.Forms.CheckBox chkRequireRoles;

		// Token: 0x04000126 RID: 294
		private global::System.ComponentModel.Container components = null;
	}
}
