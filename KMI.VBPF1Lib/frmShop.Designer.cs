namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmShop.
	/// </summary>
	// Token: 0x02000098 RID: 152
	public partial class frmShop : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004BA RID: 1210 RVA: 0x00043638 File Offset: 0x00042638
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
		// Token: 0x060004BB RID: 1211 RVA: 0x00043674 File Offset: 0x00042674
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panListings = new global::System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.btnHelp);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.btnOK);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new global::System.Drawing.Point(0, 334);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(520, 60);
			this.panel2.TabIndex = 1;
			this.btnHelp.Location = new global::System.Drawing.Point(356, 20);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 2;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.button2.Location = new global::System.Drawing.Point(212, 20);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(96, 24);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.btnOK.Location = new global::System.Drawing.Point(28, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(116, 44);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Checkout && Pay";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panListings.AutoScroll = true;
			this.panListings.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panListings.Location = new global::System.Drawing.Point(0, 0);
			this.panListings.Name = "panListings";
			this.panListings.Size = new global::System.Drawing.Size(520, 334);
			this.panListings.TabIndex = 2;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(520, 394);
			base.Controls.Add(this.panListings);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmShop";
			base.ShowInTaskbar = false;
			this.Text = "Shop";
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000595 RID: 1429
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000596 RID: 1430
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000597 RID: 1431
		private global::System.Windows.Forms.Panel panListings;

		// Token: 0x04000598 RID: 1432
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000599 RID: 1433
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400059A RID: 1434
		private global::System.ComponentModel.Container components = null;
	}
}
