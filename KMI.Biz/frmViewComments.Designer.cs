namespace KMI.Biz
{
	// Token: 0x02000002 RID: 2
	public partial class frmViewComments : global::KMI.Sim.frmDrawnReport
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		private void InitializeComponent()
		{
			this.btnBack = new global::System.Windows.Forms.Button();
			this.btnNext = new global::System.Windows.Forms.Button();
			this.pnlBottom.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picReport).BeginInit();
			base.SuspendLayout();
			this.pnlBottom.Controls.Add(this.btnNext);
			this.pnlBottom.Controls.Add(this.btnBack);
			this.pnlBottom.Location = new global::System.Drawing.Point(0, 524);
			this.pnlBottom.Size = new global::System.Drawing.Size(426, 40);
			this.pnlBottom.Controls.SetChildIndex(this.btnBack, 0);
			this.pnlBottom.Controls.SetChildIndex(this.btnNext, 0);
			this.picReport.BackColor = global::System.Drawing.Color.White;
			this.picReport.Location = new global::System.Drawing.Point(0, 0);
			this.picReport.Size = new global::System.Drawing.Size(420, 500);
			this.picReport.Click += new global::System.EventHandler(this.picReport_Click);
			this.btnBack.Location = new global::System.Drawing.Point(88, 8);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new global::System.Drawing.Size(56, 23);
			this.btnBack.TabIndex = 1;
			this.btnBack.Text = "<< Back";
			this.btnBack.Click += new global::System.EventHandler(this.btnBack_Click);
			this.btnNext.Location = new global::System.Drawing.Point(164, 8);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new global::System.Drawing.Size(56, 23);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next >>";
			this.btnNext.Click += new global::System.EventHandler(this.btnNext_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(426, 564);
			base.Name = "frmViewComments";
			this.Text = "Comment Log";
			base.Load += new global::System.EventHandler(this.frmViewComments_Load);
			base.Closed += new global::System.EventHandler(this.frmReport_Closed);
			this.pnlBottom.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.picReport).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private global::System.Windows.Forms.Button btnBack;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Button btnNext;
	}
}
