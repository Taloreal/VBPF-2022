namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmTaxTable.
	/// </summary>
	// Token: 0x020000A3 RID: 163
	public partial class frmTaxTable : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004F3 RID: 1267 RVA: 0x000472A0 File Offset: 0x000462A0
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
		// Token: 0x060004F4 RID: 1268 RVA: 0x000472DC File Offset: 0x000462DC
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resources = new global::System.Resources.ResourceManager(typeof(global::KMI.VBPF1Lib.frmTaxTable));
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.BackgroundImage = (global::System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			base.ClientSize = new global::System.Drawing.Size(594, 336);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmTaxTable";
			base.ShowInTaskbar = false;
			this.Text = "Tax Table";
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005DF RID: 1503
		private global::System.ComponentModel.Container components = null;
	}
}
