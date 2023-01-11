namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCreditScore.
	/// </summary>
	// Token: 0x020000A8 RID: 168
	public partial class frmCreditScore : global::KMI.Sim.frmDrawnReport
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600050A RID: 1290 RVA: 0x00048CEC File Offset: 0x00047CEC
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
		// Token: 0x0600050B RID: 1291 RVA: 0x00048D28 File Offset: 0x00047D28
		private void InitializeComponent()
		{
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new global::System.Drawing.Size(482, 40);
			this.picReport.Name = "picReport";
			this.picReport.Size = new global::System.Drawing.Size(448, 280);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(482, 344);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmCreditScore";
			this.Text = "Credit Score";
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000607 RID: 1543
		private global::System.ComponentModel.Container components = null;
	}
}
