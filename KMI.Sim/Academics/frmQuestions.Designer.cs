namespace KMI.Sim.Academics
{
	// Token: 0x02000069 RID: 105
	public partial class frmQuestions : global::System.Windows.Forms.Form
	{
		// Token: 0x060003DA RID: 986 RVA: 0x0001C2C4 File Offset: 0x0001B2C4
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

		// Token: 0x060003DB RID: 987 RVA: 0x0001C300 File Offset: 0x0001B300
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnContinue = new global::System.Windows.Forms.Button();
			this.btnSubmit = new global::System.Windows.Forms.Button();
			this.panQuestions = new global::System.Windows.Forms.Panel();
			this.panScore = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.labScore = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panScore.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.btnContinue);
			this.panel1.Controls.Add(this.btnSubmit);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 302);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(480, 40);
			this.panel1.TabIndex = 0;
			this.btnContinue.Enabled = false;
			this.btnContinue.Location = new global::System.Drawing.Point(376, 8);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new global::System.Drawing.Size(88, 24);
			this.btnContinue.TabIndex = 1;
			this.btnContinue.Text = "Continue";
			this.btnContinue.Click += new global::System.EventHandler(this.button1_Click);
			this.btnSubmit.Location = new global::System.Drawing.Point(256, 8);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new global::System.Drawing.Size(88, 24);
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.Click += new global::System.EventHandler(this.btnSubmit_Click);
			this.panQuestions.AutoScroll = true;
			this.panQuestions.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panQuestions.Location = new global::System.Drawing.Point(0, 48);
			this.panQuestions.Name = "panQuestions";
			this.panQuestions.Size = new global::System.Drawing.Size(480, 254);
			this.panQuestions.TabIndex = 1;
			this.panScore.Controls.Add(this.panel3);
			this.panScore.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panScore.Location = new global::System.Drawing.Point(0, 0);
			this.panScore.Name = "panScore";
			this.panScore.Size = new global::System.Drawing.Size(480, 48);
			this.panScore.TabIndex = 2;
			this.panScore.Visible = false;
			this.panel3.Controls.Add(this.labScore);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new global::System.Drawing.Point(352, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(128, 48);
			this.panel3.TabIndex = 0;
			this.labScore.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 24f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labScore.Location = new global::System.Drawing.Point(8, 8);
			this.labScore.Name = "labScore";
			this.labScore.Size = new global::System.Drawing.Size(104, 32);
			this.labScore.TabIndex = 0;
			this.labScore.Text = "100%";
			this.labScore.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(480, 342);
			base.Controls.Add(this.panQuestions);
			base.Controls.Add(this.panScore);
			base.Controls.Add(this.panel1);
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(488, 2000);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(488, 100);
			base.Name = "frmQuestions";
			base.ShowInTaskbar = false;
			this.Text = "Questions";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmQuestions_Closing);
			base.Load += new global::System.EventHandler(this.frmQuestions_Load);
			this.panel1.ResumeLayout(false);
			this.panScore.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.Button btnSubmit;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.Panel panQuestions;

		// Token: 0x04000281 RID: 641
		private global::System.Windows.Forms.Button btnContinue;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.Label labScore;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.Panel panScore;

		// Token: 0x04000285 RID: 645
		private global::System.ComponentModel.Container components = null;
	}
}
