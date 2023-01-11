namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmSnapShot.
	/// </summary>
	// Token: 0x020000B4 RID: 180
	public partial class frmSnapshot : global::System.Windows.Forms.Form
	{
		// Token: 0x06000558 RID: 1368 RVA: 0x0004E5B0 File Offset: 0x0004D5B0
		private void InitializeComponent()
		{
			this.panMain = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panMain.Location = new global::System.Drawing.Point(0, 2);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(232, 33);
			this.panMain.TabIndex = 0;
			this.panMain.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panMain_Paint);
			this.panMain.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.panMain_MouseMove);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(232, 36);
			base.Controls.Add(this.panMain);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmSnapshot";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Snapshot";
			base.Resize += new global::System.EventHandler(this.frmSnapshot_Resize);
			base.Load += new global::System.EventHandler(this.frmSnapshot_Load);
			base.Closed += new global::System.EventHandler(this.frmReport_Closed);
			base.ResumeLayout(false);
		}

		// Token: 0x0400064D RID: 1613
		private global::System.Windows.Forms.Panel panMain;
	}
}
