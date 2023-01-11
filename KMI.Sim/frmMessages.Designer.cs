namespace KMI.Sim
{
	// Token: 0x02000075 RID: 117
	public partial class frmMessages : global::System.Windows.Forms.Form
	{
		// Token: 0x0600043A RID: 1082 RVA: 0x0001E3D8 File Offset: 0x0001D3D8
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

		// Token: 0x0600043B RID: 1083 RVA: 0x0001E414 File Offset: 0x0001D414
		private void InitializeComponent()
		{
			base.AutoScale = false;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			base.ClientSize = new global::System.Drawing.Size(288, 166);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Location = new global::System.Drawing.Point(0, 5000);
			this.MinimumSize = new global::System.Drawing.Size(200, 160);
			base.Name = "frmMessages";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Message Center";
			base.Resize += new global::System.EventHandler(this.frmMessages_Resize);
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmMessages_Closing);
		}

		// Token: 0x040002C4 RID: 708
		private global::System.ComponentModel.IContainer components;
	}
}
