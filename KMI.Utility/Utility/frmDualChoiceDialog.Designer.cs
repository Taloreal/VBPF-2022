namespace KMI.Utility
{
	// Token: 0x02000009 RID: 9
	public partial class frmDualChoiceDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00005460 File Offset: 0x00004460
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

		// Token: 0x0600006E RID: 110 RVA: 0x0000549C File Offset: 0x0000449C
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnChoice0 = new global::System.Windows.Forms.Button();
			this.btnChoice1 = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(336, 80);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnChoice0.DialogResult = global::System.Windows.Forms.DialogResult.Yes;
			this.btnChoice0.Location = new global::System.Drawing.Point(32, 112);
			this.btnChoice0.Name = "btnChoice0";
			this.btnChoice0.Size = new global::System.Drawing.Size(144, 40);
			this.btnChoice0.TabIndex = 1;
			this.btnChoice0.Text = "#";
			this.btnChoice1.DialogResult = global::System.Windows.Forms.DialogResult.No;
			this.btnChoice1.Location = new global::System.Drawing.Point(200, 112);
			this.btnChoice1.Name = "btnChoice1";
			this.btnChoice1.Size = new global::System.Drawing.Size(144, 40);
			this.btnChoice1.TabIndex = 2;
			this.btnChoice1.Text = "#";
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(136, 176);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(104, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			base.AcceptButton = this.btnChoice0;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(386, 208);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnChoice1);
			base.Controls.Add(this.btnChoice0);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmDualChoiceDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please choose:";
			base.ResumeLayout(false);
		}

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button btnChoice0;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button btnChoice1;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400001D RID: 29
		private global::System.ComponentModel.Container components = null;
	}
}
