namespace KMI.Sim
{
	// Token: 0x02000009 RID: 9
	public partial class frmStartChoices : global::System.Windows.Forms.Form
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00005D70 File Offset: 0x00004D70
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

		// Token: 0x0600009A RID: 154 RVA: 0x00005DAC File Offset: 0x00004DAC
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnExit = new global::System.Windows.Forms.Button();
			this.btnSavedSims = new global::System.Windows.Forms.Button();
			this.btnMultiplayer = new global::System.Windows.Forms.Button();
			this.btnProject = new global::System.Windows.Forms.Button();
			this.btnLessons = new global::System.Windows.Forms.Button();
			this.btnTutorial = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnExit);
			this.panel1.Controls.Add(this.btnSavedSims);
			this.panel1.Controls.Add(this.btnMultiplayer);
			this.panel1.Controls.Add(this.btnProject);
			this.panel1.Controls.Add(this.btnLessons);
			this.panel1.Controls.Add(this.btnTutorial);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(280, 424);
			this.panel1.TabIndex = 0;
			this.btnExit.Location = new global::System.Drawing.Point(32, 376);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new global::System.Drawing.Size(216, 24);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new global::System.EventHandler(this.btnExit_Click);
			this.btnSavedSims.Location = new global::System.Drawing.Point(32, 304);
			this.btnSavedSims.Name = "btnSavedSims";
			this.btnSavedSims.Size = new global::System.Drawing.Size(216, 40);
			this.btnSavedSims.TabIndex = 5;
			this.btnSavedSims.Text = "Open a Saved Sim";
			this.btnSavedSims.Click += new global::System.EventHandler(this.btnSavedSims_Click);
			this.btnMultiplayer.Location = new global::System.Drawing.Point(32, 224);
			this.btnMultiplayer.Name = "btnMultiplayer";
			this.btnMultiplayer.Size = new global::System.Drawing.Size(216, 40);
			this.btnMultiplayer.TabIndex = 4;
			this.btnMultiplayer.Text = "Compete using Multiplayer";
			this.btnMultiplayer.Click += new global::System.EventHandler(this.btnMultiplayer_Click);
			this.btnProject.Location = new global::System.Drawing.Point(32, 168);
			this.btnProject.Name = "btnProject";
			this.btnProject.Size = new global::System.Drawing.Size(216, 40);
			this.btnProject.TabIndex = 3;
			this.btnProject.Text = "#";
			this.btnProject.Click += new global::System.EventHandler(this.btnProject_Click);
			this.btnLessons.Location = new global::System.Drawing.Point(31, 112);
			this.btnLessons.Name = "btnLessons";
			this.btnLessons.Size = new global::System.Drawing.Size(216, 40);
			this.btnLessons.TabIndex = 2;
			this.btnLessons.Text = "Find a Lesson";
			this.btnLessons.Click += new global::System.EventHandler(this.btnLessons_Click);
			this.btnTutorial.Location = new global::System.Drawing.Point(32, 56);
			this.btnTutorial.Name = "btnTutorial";
			this.btnTutorial.Size = new global::System.Drawing.Size(216, 24);
			this.btnTutorial.TabIndex = 1;
			this.btnTutorial.Text = "Tutorial";
			this.btnTutorial.Click += new global::System.EventHandler(this.btnTutorial_Click);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 20.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(48, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(176, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose one:";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(344, 432);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmStartChoices";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmStartChoices";
			base.Closed += new global::System.EventHandler(this.frmStartChoices_Closed);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.Button btnTutorial;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Button btnLessons;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Button btnProject;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Button btnMultiplayer;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Button btnSavedSims;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Button btnExit;

		// Token: 0x0400005C RID: 92
		private global::System.ComponentModel.Container components = null;
	}
}
