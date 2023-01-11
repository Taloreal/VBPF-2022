namespace KMI.Biz
{
	// Token: 0x02000004 RID: 4
	public partial class frmAutoGrader : global::KMI.Sim.frmDrawnReport
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002D34 File Offset: 0x00001D34
		private void InitializeComponent()
		{
			((global::System.ComponentModel.ISupportInitialize)this.picReport).BeginInit();
			base.SuspendLayout();
			this.pnlBottom.Location = new global::System.Drawing.Point(0, 480);
			this.pnlBottom.Size = new global::System.Drawing.Size(674, 40);
			this.picReport.BackColor = global::System.Drawing.Color.White;
			this.picReport.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.picReport.Location = new global::System.Drawing.Point(0, 0);
			this.picReport.Size = new global::System.Drawing.Size(674, 520);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(674, 520);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "frmAutoGrader";
			this.Text = "AutoGrader";
			((global::System.ComponentModel.ISupportInitialize)this.picReport).EndInit();
			base.ResumeLayout(false);
		}
	}
}
