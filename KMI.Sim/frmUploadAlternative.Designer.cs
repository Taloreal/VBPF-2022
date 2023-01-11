namespace KMI.Sim
{
	// Token: 0x0200007B RID: 123
	public partial class frmUploadAlternative : global::System.Windows.Forms.Form
	{
		// Token: 0x0600045C RID: 1116 RVA: 0x0001F620 File Offset: 0x0001E620
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

		// Token: 0x0600045D RID: 1117 RVA: 0x0001F65C File Offset: 0x0001E65C
		private void InitializeComponent()
		{
			this.btnClose = new global::System.Windows.Forms.Button();
			this.txtCipher = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnClose.Location = new global::System.Drawing.Point(264, 192);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(104, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.txtCipher.Location = new global::System.Drawing.Point(16, 16);
			this.txtCipher.Multiline = true;
			this.txtCipher.Name = "txtCipher";
			this.txtCipher.Size = new global::System.Drawing.Size(600, 40);
			this.txtCipher.TabIndex = 1;
			this.txtCipher.Text = "";
			this.label1.Location = new global::System.Drawing.Point(112, 80);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(440, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "1. Open your web browser and go to www.KnowledgeMatters.com/VBCUpload";
			this.label2.Location = new global::System.Drawing.Point(112, 104);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(440, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "2. Copy all the text above and paste it into the box marked Encrypted Score.";
			this.label3.Location = new global::System.Drawing.Point(112, 128);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(440, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "3. Hit the Submit button on that web page.";
			this.label4.Location = new global::System.Drawing.Point(112, 152);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(440, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "4. Check the VBC Rankings page at KnowledgeMatters.com for your score.";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(634, 232);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtCipher);
			base.Controls.Add(this.btnClose);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmUploadAlternative";
			base.ShowInTaskbar = false;
			this.Text = "Alternative Upload";
			base.ResumeLayout(false);
		}

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.TextBox txtCipher;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002E9 RID: 745
		private global::System.ComponentModel.Container components = null;
	}
}
