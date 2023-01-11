namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmMessageBoxWithIcon.
	/// </summary>
	// Token: 0x0200006E RID: 110
	public partial class frmMessageBoxWithIcon : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002E6 RID: 742 RVA: 0x00032514 File Offset: 0x00031514
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
		// Token: 0x060002E7 RID: 743 RVA: 0x00032550 File Offset: 0x00031550
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.labIcon = new global::System.Windows.Forms.Label();
			this.labMessage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(148, 124);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(112, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.labIcon.Location = new global::System.Drawing.Point(20, 12);
			this.labIcon.Name = "labIcon";
			this.labIcon.Size = new global::System.Drawing.Size(108, 92);
			this.labIcon.TabIndex = 1;
			this.labMessage.Location = new global::System.Drawing.Point(144, 12);
			this.labMessage.Name = "labMessage";
			this.labMessage.Size = new global::System.Drawing.Size(248, 88);
			this.labMessage.TabIndex = 2;
			this.labMessage.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(412, 158);
			base.Controls.Add(this.labMessage);
			base.Controls.Add(this.labIcon);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmMessageBoxWithIcon";
			base.ShowInTaskbar = false;
			this.Text = "frmMessageBoxWithIcon";
			base.ResumeLayout(false);
		}

		// Token: 0x040003BF RID: 959
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040003C0 RID: 960
		private global::System.Windows.Forms.Label labIcon;

		// Token: 0x040003C1 RID: 961
		private global::System.Windows.Forms.Label labMessage;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040003C2 RID: 962
		private global::System.ComponentModel.Container components = null;
	}
}
