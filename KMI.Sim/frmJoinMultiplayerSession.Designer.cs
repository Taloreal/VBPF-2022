namespace KMI.Sim
{
	// Token: 0x0200000A RID: 10
	public partial class frmJoinMultiplayerSession : global::System.Windows.Forms.Form
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x00006440 File Offset: 0x00005440
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

		// Token: 0x060000A4 RID: 164 RVA: 0x0000647C File Offset: 0x0000547C
		private void InitializeComponent()
		{
			this.cmdOK = new global::System.Windows.Forms.Button();
			this.cmdCancel = new global::System.Windows.Forms.Button();
			this.cmdHelp = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtTeamName = new global::System.Windows.Forms.TextBox();
			this.txtComputerName = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtSessionName = new global::System.Windows.Forms.TextBox();
			this.labWait = new global::System.Windows.Forms.Label();
			this.panBottom = new global::System.Windows.Forms.Panel();
			this.txtPassword = new global::System.Windows.Forms.TextBox();
			this.labPassword = new global::System.Windows.Forms.Label();
			this.labPasswordHelp = new global::System.Windows.Forms.Label();
			this.panBottom.SuspendLayout();
			base.SuspendLayout();
			this.cmdOK.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cmdOK.Location = new global::System.Drawing.Point(40, 48);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new global::System.Drawing.Size(64, 24);
			this.cmdOK.TabIndex = 6;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new global::System.EventHandler(this.cmdOK_Click);
			this.cmdCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new global::System.Drawing.Point(120, 48);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new global::System.Drawing.Size(56, 24);
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new global::System.EventHandler(this.cmdCancel_Click);
			this.cmdHelp.Location = new global::System.Drawing.Point(192, 48);
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.Size = new global::System.Drawing.Size(56, 24);
			this.cmdHelp.TabIndex = 8;
			this.cmdHelp.Text = "Help";
			this.cmdHelp.Click += new global::System.EventHandler(this.cmdHelp_Click);
			this.label2.Location = new global::System.Drawing.Point(56, 120);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(136, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Enter Team Name:";
			this.txtTeamName.Location = new global::System.Drawing.Point(56, 136);
			this.txtTeamName.MaxLength = 12;
			this.txtTeamName.Name = "txtTeamName";
			this.txtTeamName.Size = new global::System.Drawing.Size(168, 20);
			this.txtTeamName.TabIndex = 5;
			this.txtTeamName.Text = "";
			this.txtTeamName.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtTeamName_Validating);
			this.txtComputerName.Location = new global::System.Drawing.Point(56, 40);
			this.txtComputerName.Name = "txtComputerName";
			this.txtComputerName.Size = new global::System.Drawing.Size(168, 20);
			this.txtComputerName.TabIndex = 1;
			this.txtComputerName.Text = "";
			this.txtComputerName.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtComputerName_Validating);
			this.label3.Location = new global::System.Drawing.Point(56, 24);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(184, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Enter Host Computer Name:";
			this.label1.Location = new global::System.Drawing.Point(56, 72);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(168, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Enter Session Name";
			this.txtSessionName.Location = new global::System.Drawing.Point(56, 88);
			this.txtSessionName.Name = "txtSessionName";
			this.txtSessionName.Size = new global::System.Drawing.Size(168, 20);
			this.txtSessionName.TabIndex = 3;
			this.txtSessionName.Text = "";
			this.txtSessionName.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtSessionName_Validating);
			this.labWait.Location = new global::System.Drawing.Point(16, 0);
			this.labWait.Name = "labWait";
			this.labWait.Size = new global::System.Drawing.Size(256, 40);
			this.labWait.TabIndex = 9;
			this.labWait.Text = "Attempting to find session...  Please wait. This could take a minute or more.";
			this.labWait.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labWait.Visible = false;
			this.panBottom.Controls.Add(this.cmdOK);
			this.panBottom.Controls.Add(this.labWait);
			this.panBottom.Controls.Add(this.cmdHelp);
			this.panBottom.Controls.Add(this.cmdCancel);
			this.panBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panBottom.Location = new global::System.Drawing.Point(0, 182);
			this.panBottom.Name = "panBottom";
			this.panBottom.Size = new global::System.Drawing.Size(292, 80);
			this.panBottom.TabIndex = 10;
			this.txtPassword.Location = new global::System.Drawing.Point(56, 184);
			this.txtPassword.MaxLength = 12;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new global::System.Drawing.Size(128, 20);
			this.txtPassword.TabIndex = 12;
			this.txtPassword.Text = "";
			this.txtPassword.Visible = false;
			this.labPassword.Location = new global::System.Drawing.Point(56, 168);
			this.labPassword.Name = "labPassword";
			this.labPassword.Size = new global::System.Drawing.Size(136, 16);
			this.labPassword.TabIndex = 11;
			this.labPassword.Text = "Enter Team Password:";
			this.labPassword.Visible = false;
			this.labPasswordHelp.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPasswordHelp.ForeColor = global::System.Drawing.Color.Blue;
			this.labPasswordHelp.Location = new global::System.Drawing.Point(192, 184);
			this.labPasswordHelp.Name = "labPasswordHelp";
			this.labPasswordHelp.Size = new global::System.Drawing.Size(40, 24);
			this.labPasswordHelp.TabIndex = 13;
			this.labPasswordHelp.Text = "Explain";
			this.labPasswordHelp.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.labPasswordHelp.Visible = false;
			this.labPasswordHelp.Click += new global::System.EventHandler(this.labPasswordHelp_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(292, 262);
			base.Controls.Add(this.labPasswordHelp);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.labPassword);
			base.Controls.Add(this.panBottom);
			base.Controls.Add(this.txtSessionName);
			base.Controls.Add(this.txtComputerName);
			base.Controls.Add(this.txtTeamName);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Name = "frmJoinMultiplayerSession";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Join Multiplayer Session";
			this.panBottom.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Button cmdOK;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Button cmdCancel;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.Button cmdHelp;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.TextBox txtTeamName;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.TextBox txtComputerName;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.TextBox txtSessionName;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Label labWait;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Panel panBottom;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.TextBox txtPassword;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Label labPassword;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Label labPasswordHelp;

		// Token: 0x0400006B RID: 107
		private global::System.ComponentModel.Container components = null;
	}
}
