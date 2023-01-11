namespace KMI.Sim.Academics
{
	// Token: 0x0200005E RID: 94
	public partial class frmChooseMathPack : global::System.Windows.Forms.Form
	{
		// Token: 0x06000379 RID: 889 RVA: 0x00019BF8 File Offset: 0x00018BF8
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

		// Token: 0x0600037A RID: 890 RVA: 0x00019C34 File Offset: 0x00018C34
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.lstPaks = new global::System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lstPaks);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(292, 332);
			this.panel1.TabIndex = 0;
			this.btnOK.Location = new global::System.Drawing.Point(96, 288);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(104, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 21.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(40, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(208, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select a Topic:";
			this.label2.Location = new global::System.Drawing.Point(32, 80);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(128, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Installed Math Paks:";
			this.lstPaks.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lstPaks.ItemHeight = 16;
			this.lstPaks.Location = new global::System.Drawing.Point(32, 96);
			this.lstPaks.Name = "lstPaks";
			this.lstPaks.Size = new global::System.Drawing.Size(216, 164);
			this.lstPaks.TabIndex = 3;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(292, 332);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmChooseMathPack";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmChooseMathPack";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.ListBox lstPaks;

		// Token: 0x0400023C RID: 572
		private global::System.ComponentModel.Container components = null;
	}
}
