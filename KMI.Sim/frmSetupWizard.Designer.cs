namespace KMI.Sim
{
	// Token: 0x0200006E RID: 110
	public partial class frmSetupWizard : global::System.Windows.Forms.Form
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x0001CF50 File Offset: 0x0001BF50
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

		// Token: 0x06000405 RID: 1029 RVA: 0x0001CF8C File Offset: 0x0001BF8C
		private void InitializeComponent()
		{
			this.btnBack = new global::System.Windows.Forms.Button();
			this.btnNext = new global::System.Windows.Forms.Button();
			this.btnFinish = new global::System.Windows.Forms.Button();
			this.picImage = new global::System.Windows.Forms.PictureBox();
			this.btnShow = new global::System.Windows.Forms.Button();
			this.lblStep0 = new global::System.Windows.Forms.Label();
			this.panTitles = new global::System.Windows.Forms.Panel();
			this.labTitle = new global::System.Windows.Forms.Label();
			this.labText = new global::System.Windows.Forms.Label();
			this.panTitles.SuspendLayout();
			base.SuspendLayout();
			this.btnBack.Location = new global::System.Drawing.Point(200, 280);
			this.btnBack.Name = "btnBack";
			this.btnBack.TabIndex = 4;
			this.btnBack.Text = "&Back";
			this.btnBack.Click += new global::System.EventHandler(this.btnBack_Click);
			this.btnNext.Location = new global::System.Drawing.Point(288, 280);
			this.btnNext.Name = "btnNext";
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = "&Next";
			this.btnNext.Click += new global::System.EventHandler(this.btnNext_Click);
			this.btnFinish.Location = new global::System.Drawing.Point(376, 280);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.TabIndex = 6;
			this.btnFinish.Text = "&Finish";
			this.btnFinish.Click += new global::System.EventHandler(this.btnFinish_Click);
			this.picImage.Location = new global::System.Drawing.Point(480, 16);
			this.picImage.Name = "picImage";
			this.picImage.Size = new global::System.Drawing.Size(100, 208);
			this.picImage.TabIndex = 4;
			this.picImage.TabStop = false;
			this.btnShow.Location = new global::System.Drawing.Point(216, 224);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new global::System.Drawing.Size(208, 23);
			this.btnShow.TabIndex = 2;
			this.btnShow.Text = "&Setup";
			this.btnShow.Click += new global::System.EventHandler(this.btnShow_Click);
			this.lblStep0.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblStep0.Location = new global::System.Drawing.Point(8, 16);
			this.lblStep0.Name = "lblStep0";
			this.lblStep0.Size = new global::System.Drawing.Size(152, 23);
			this.lblStep0.TabIndex = 0;
			this.lblStep0.Text = "lblStep";
			this.panTitles.Controls.Add(this.labTitle);
			this.panTitles.Location = new global::System.Drawing.Point(8, 16);
			this.panTitles.Name = "panTitles";
			this.panTitles.Size = new global::System.Drawing.Size(152, 296);
			this.panTitles.TabIndex = 0;
			this.labTitle.Font = new global::System.Drawing.Font("Times New Roman", 15.75f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labTitle.ForeColor = global::System.Drawing.Color.DarkBlue;
			this.labTitle.Location = new global::System.Drawing.Point(8, 40);
			this.labTitle.Name = "labTitle";
			this.labTitle.Size = new global::System.Drawing.Size(136, 32);
			this.labTitle.TabIndex = 0;
			this.labTitle.Text = "Title";
			this.labText.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labText.Location = new global::System.Drawing.Point(192, 24);
			this.labText.Name = "labText";
			this.labText.Size = new global::System.Drawing.Size(256, 184);
			this.labText.TabIndex = 1;
			this.labText.Text = "Text";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(622, 339);
			base.Controls.Add(this.labText);
			base.Controls.Add(this.panTitles);
			base.Controls.Add(this.btnShow);
			base.Controls.Add(this.picImage);
			base.Controls.Add(this.btnFinish);
			base.Controls.Add(this.btnNext);
			base.Controls.Add(this.btnBack);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Name = "SetupWizard";
			base.ShowInTaskbar = false;
			this.Text = "Setup Wizard";
			this.panTitles.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.Button btnBack;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.Button btnNext;

		// Token: 0x040002A5 RID: 677
		private global::System.Windows.Forms.Button btnFinish;

		// Token: 0x040002A6 RID: 678
		private global::System.Windows.Forms.Button btnShow;

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.PictureBox picImage;

		// Token: 0x040002A8 RID: 680
		private global::System.ComponentModel.Container components = null;

		// Token: 0x040002AC RID: 684
		private global::System.Windows.Forms.Label lblStep0;

		// Token: 0x040002AD RID: 685
		private global::System.Windows.Forms.Panel panTitles;

		// Token: 0x040002AE RID: 686
		private global::System.Windows.Forms.Label labTitle;

		// Token: 0x040002B0 RID: 688
		private global::System.Windows.Forms.Label labText;
	}
}
