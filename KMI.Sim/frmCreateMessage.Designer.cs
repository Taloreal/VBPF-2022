namespace KMI.Sim
{
	// Token: 0x02000077 RID: 119
	public partial class frmCreateMessage : global::System.Windows.Forms.Form
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x0001EAC0 File Offset: 0x0001DAC0
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

		// Token: 0x06000449 RID: 1097 RVA: 0x0001EAFC File Offset: 0x0001DAFC
		private void InitializeComponent()
		{
			this.btnSend = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.labFrom = new global::System.Windows.Forms.Label();
			this.labTo = new global::System.Windows.Forms.Label();
			this.txtMemo = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnSend.Location = new global::System.Drawing.Point(56, 224);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new global::System.Drawing.Size(96, 24);
			this.btnSend.TabIndex = 0;
			this.btnSend.Text = "Send";
			this.btnSend.Click += new global::System.EventHandler(this.btnSend_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(184, 224);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.button2_Click);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(40, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "From:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(40, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "To:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labFrom.Location = new global::System.Drawing.Point(64, 16);
			this.labFrom.Name = "labFrom";
			this.labFrom.Size = new global::System.Drawing.Size(160, 16);
			this.labFrom.TabIndex = 4;
			this.labFrom.Text = "labFrom";
			this.labTo.Location = new global::System.Drawing.Point(64, 32);
			this.labTo.Name = "labTo";
			this.labTo.Size = new global::System.Drawing.Size(160, 16);
			this.labTo.TabIndex = 5;
			this.labTo.Text = "labTo";
			this.txtMemo.Location = new global::System.Drawing.Point(64, 48);
			this.txtMemo.Multiline = true;
			this.txtMemo.Name = "txtMemo";
			this.txtMemo.Size = new global::System.Drawing.Size(232, 144);
			this.txtMemo.TabIndex = 6;
			this.txtMemo.Text = "";
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(40, 48);
			this.label3.TabIndex = 7;
			this.label3.Text = "Body of Memo:";
			base.AcceptButton = this.btnSend;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(338, 264);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.txtMemo);
			base.Controls.Add(this.labTo);
			base.Controls.Add(this.labFrom);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnSend);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmCreateMessage";
			base.ShowInTaskbar = false;
			this.Text = "Create Memo";
			base.ResumeLayout(false);
		}

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.Label labFrom;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.Label labTo;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.TextBox txtMemo;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Button btnSend;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040002D5 RID: 725
		private global::System.ComponentModel.Container components = null;
	}
}
