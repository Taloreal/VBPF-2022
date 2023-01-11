namespace KMI.Sim
{
	// Token: 0x0200001C RID: 28
	public partial class frmEditSimSettings : global::System.Windows.Forms.Form
	{
		// Token: 0x0600014A RID: 330 RVA: 0x0000A90C File Offset: 0x0000990C
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

		// Token: 0x0600014B RID: 331 RVA: 0x0000A948 File Offset: 0x00009948
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.btnDisableAllActions = new global::System.Windows.Forms.Button();
			this.btnDeleteAssignment = new global::System.Windows.Forms.Button();
			this.btnLoadAssignment = new global::System.Windows.Forms.Button();
			this.btnReset = new global::System.Windows.Forms.Button();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.txtValue = new global::System.Windows.Forms.TextBox();
			this.txtName = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtCountryCode = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 286);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(576, 104);
			this.panel1.TabIndex = 0;
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.txtCountryCode);
			this.panel5.Controls.Add(this.btnDisableAllActions);
			this.panel5.Controls.Add(this.btnDeleteAssignment);
			this.panel5.Controls.Add(this.btnLoadAssignment);
			this.panel5.Controls.Add(this.btnReset);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(400, 104);
			this.panel5.TabIndex = 1;
			this.btnDisableAllActions.Location = new global::System.Drawing.Point(208, 72);
			this.btnDisableAllActions.Name = "btnDisableAllActions";
			this.btnDisableAllActions.Size = new global::System.Drawing.Size(168, 24);
			this.btnDisableAllActions.TabIndex = 3;
			this.btnDisableAllActions.Text = "Disable All Actions";
			this.btnDisableAllActions.Click += new global::System.EventHandler(this.btnDisableAllActions_Click);
			this.btnDeleteAssignment.Location = new global::System.Drawing.Point(16, 40);
			this.btnDeleteAssignment.Name = "btnDeleteAssignment";
			this.btnDeleteAssignment.Size = new global::System.Drawing.Size(168, 24);
			this.btnDeleteAssignment.TabIndex = 1;
			this.btnDeleteAssignment.Text = "Delete Assignment";
			this.btnDeleteAssignment.Click += new global::System.EventHandler(this.btnDeleteAssignment_Click);
			this.btnLoadAssignment.Location = new global::System.Drawing.Point(16, 8);
			this.btnLoadAssignment.Name = "btnLoadAssignment";
			this.btnLoadAssignment.Size = new global::System.Drawing.Size(168, 24);
			this.btnLoadAssignment.TabIndex = 0;
			this.btnLoadAssignment.Text = "Load Assignment from File";
			this.btnLoadAssignment.Click += new global::System.EventHandler(this.btnLoadAssignment_Click);
			this.btnReset.Location = new global::System.Drawing.Point(16, 72);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new global::System.Drawing.Size(168, 24);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Reset to Defaults";
			this.btnReset.Click += new global::System.EventHandler(this.btnReset_Click);
			this.panel4.Controls.Add(this.btnCancel);
			this.panel4.Controls.Add(this.btnHelp);
			this.panel4.Controls.Add(this.btnOK);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new global::System.Drawing.Point(448, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(128, 104);
			this.panel4.TabIndex = 1;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(16, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(16, 72);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 2;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnOK.Location = new global::System.Drawing.Point(16, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.DockPadding.Bottom = 10;
			this.panel2.DockPadding.Left = 10;
			this.panel2.DockPadding.Right = 10;
			this.panel2.DockPadding.Top = 30;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(576, 286);
			this.panel2.TabIndex = 0;
			this.panel3.AutoScroll = true;
			this.panel3.BackColor = global::System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.txtValue);
			this.panel3.Controls.Add(this.txtName);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(10, 30);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(556, 246);
			this.panel3.TabIndex = 3;
			this.panel3.Resize += new global::System.EventHandler(this.panel3_Resize);
			this.txtValue.AutoSize = false;
			this.txtValue.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtValue.Location = new global::System.Drawing.Point(231, 0);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new global::System.Drawing.Size(150, 20);
			this.txtValue.TabIndex = 1;
			this.txtValue.Text = "textBox2";
			this.txtValue.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
			this.txtValue.Enter += new global::System.EventHandler(this.txtValue_Enter);
			this.txtName.AutoSize = false;
			this.txtName.BackColor = global::System.Drawing.Color.White;
			this.txtName.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new global::System.Drawing.Point(0, 0);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new global::System.Drawing.Size(232, 20);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "textBox1";
			this.label1.Location = new global::System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(120, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Setting";
			this.label2.Location = new global::System.Drawing.Point(240, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(120, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Value";
			this.txtCountryCode.Location = new global::System.Drawing.Point(288, 8);
			this.txtCountryCode.Name = "txtCountryCode";
			this.txtCountryCode.Size = new global::System.Drawing.Size(56, 20);
			this.txtCountryCode.TabIndex = 4;
			this.txtCountryCode.Text = "";
			this.label3.Location = new global::System.Drawing.Point(208, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(80, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "Country Code:";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(576, 390);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			this.MinimumSize = new global::System.Drawing.Size(456, 300);
			base.Name = "frmEditSimSettings";
			base.ShowInTaskbar = false;
			this.Text = "Customize Your Simulation";
			base.Load += new global::System.EventHandler(this.frmEditSimSettings_Load);
			this.panel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.TextBox txtName;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.TextBox txtValue;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Button btnReset;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Button btnLoadAssignment;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Button btnDeleteAssignment;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Button btnDisableAllActions;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.TextBox txtCountryCode;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000D9 RID: 217
		private global::System.ComponentModel.Container components = null;
	}
}
