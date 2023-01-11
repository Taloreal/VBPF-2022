namespace KMI.Sim
{
	// Token: 0x02000029 RID: 41
	public partial class frmUpload : global::System.Windows.Forms.Form
	{
		// Token: 0x060001B9 RID: 441 RVA: 0x0000E0A0 File Offset: 0x0000D0A0
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

		// Token: 0x060001BA RID: 442 RVA: 0x0000E0DC File Offset: 0x0000D0DC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.btnUpload = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.labMsg = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtTeamCode = new global::System.Windows.Forms.TextBox();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.label2 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnUpload.Location = new global::System.Drawing.Point(64, 176);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new global::System.Drawing.Size(96, 24);
			this.btnUpload.TabIndex = 3;
			this.btnUpload.Text = "Upload";
			this.btnUpload.Click += new global::System.EventHandler(this.btnUpload_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(208, 176);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.labMsg.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labMsg.Location = new global::System.Drawing.Point(32, 24);
			this.labMsg.Name = "labMsg";
			this.labMsg.Size = new global::System.Drawing.Size(312, 40);
			this.labMsg.TabIndex = 0;
			this.labMsg.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Location = new global::System.Drawing.Point(120, 80);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Team Code:";
			this.txtTeamCode.Location = new global::System.Drawing.Point(120, 96);
			this.txtTeamCode.Name = "txtTeamCode";
			this.txtTeamCode.Size = new global::System.Drawing.Size(120, 20);
			this.txtTeamCode.TabIndex = 2;
			this.txtTeamCode.Text = "";
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Blue;
			this.label2.Location = new global::System.Drawing.Point(256, 120);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(96, 40);
			this.label2.TabIndex = 5;
			this.label2.Text = "Upload Not Working? Click here for alternative method.";
			this.label2.Click += new global::System.EventHandler(this.label2_Click);
			base.AcceptButton = this.btnUpload;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(368, 222);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.txtTeamCode);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.labMsg);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnUpload);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmUpload";
			base.ShowInTaskbar = false;
			this.Text = "Upload Your Score!";
			base.ResumeLayout(false);
		}

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.Button btnUpload;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.Label labMsg;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.TextBox txtTeamCode;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000114 RID: 276
		private global::System.ComponentModel.IContainer components;
	}
}
