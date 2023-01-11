namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmLegend.
	/// </summary>
	// Token: 0x02000008 RID: 8
	public partial class frmLegend : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000024 RID: 36 RVA: 0x000037D0 File Offset: 0x000027D0
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
		// Token: 0x06000025 RID: 37 RVA: 0x0000380C File Offset: 0x0000280C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KMI.VBPF1Lib.frmLegend));
			this.panel1 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel1.BackgroundImage = (global::System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(160, 855);
			this.panel1.TabIndex = 0;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(164, 254);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmLegend";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Legend";
			base.ResumeLayout(false);
		}

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Panel panel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000029 RID: 41
		private global::System.ComponentModel.Container components = null;
	}
}
