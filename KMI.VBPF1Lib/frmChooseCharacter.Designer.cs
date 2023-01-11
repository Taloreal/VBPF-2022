namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmChooseCharacter.
	/// </summary>
	// Token: 0x0200000F RID: 15
	public partial class frmChooseCharacter : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000042 RID: 66 RVA: 0x00005A28 File Offset: 0x00004A28
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x06000043 RID: 67 RVA: 0x00005A64 File Offset: 0x00004A64
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.labName = new global::System.Windows.Forms.TextBox();
			this.panPalettes = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(204, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(112, 28);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label1.Location = new global::System.Drawing.Point(140, 28);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(76, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Full Name:";
			this.labName.Location = new global::System.Drawing.Point(208, 24);
			this.labName.Name = "labName";
			this.labName.Size = new global::System.Drawing.Size(164, 20);
			this.labName.TabIndex = 2;
			this.labName.Text = "";
			this.panPalettes.Location = new global::System.Drawing.Point(4, 64);
			this.panPalettes.Name = "panPalettes";
			this.panPalettes.Size = new global::System.Drawing.Size(512, 224);
			this.panPalettes.TabIndex = 3;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(524, 358);
			base.Controls.Add(this.panPalettes);
			base.Controls.Add(this.labName);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmChooseCharacter";
			base.ShowInTaskbar = false;
			this.Text = "Choose Yourself";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmChooseCharacter_Closing);
			base.Load += new global::System.EventHandler(this.frmChooseCharacter_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.TextBox labName;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Panel panPalettes;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Button btnOK;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000AE RID: 174
		private global::System.ComponentModel.Container components = null;
	}
}
