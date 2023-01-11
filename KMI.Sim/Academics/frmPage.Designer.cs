namespace KMI.Sim.Academics
{
	// Token: 0x02000033 RID: 51
	public partial class frmPage : global::System.Windows.Forms.Form
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x000106B8 File Offset: 0x0000F6B8
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

		// Token: 0x060001F3 RID: 499 RVA: 0x000106F4 File Offset: 0x0000F6F4
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::KMI.Sim.Academics.frmPage));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnQuestions = new global::System.Windows.Forms.Button();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 494);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(792, 40);
			this.panel1.TabIndex = 1;
			this.panel2.Controls.Add(this.btnQuestions);
			this.panel2.Controls.Add(this.btnPrint);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new global::System.Drawing.Point(464, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(328, 40);
			this.panel2.TabIndex = 2;
			this.btnQuestions.Location = new global::System.Drawing.Point(104, 8);
			this.btnQuestions.Name = "btnQuestions";
			this.btnQuestions.Size = new global::System.Drawing.Size(112, 24);
			this.btnQuestions.TabIndex = 1;
			this.btnQuestions.Text = "Answer Questions";
			this.btnQuestions.Click += new global::System.EventHandler(this.btnQuestions_Click);
			this.btnPrint.Location = new global::System.Drawing.Point(16, 8);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(64, 24);
			this.btnPrint.TabIndex = 0;
			this.btnPrint.Text = "Print";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(792, 534);
			base.Controls.Add(this.panel1);
			this.MinimumSize = new global::System.Drawing.Size(328, 160);
			base.Name = "frmPage";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Concept";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmPage_Closing);
			base.Load += new global::System.EventHandler(this.frmPage_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Button btnQuestions;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000146 RID: 326
		private global::System.ComponentModel.Container components = null;
	}
}
