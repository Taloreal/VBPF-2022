namespace KMI.Sim
{
	// Token: 0x0200003C RID: 60
	public partial class frmLessonsSimple : global::System.Windows.Forms.Form
	{
		// Token: 0x06000252 RID: 594 RVA: 0x00012E1C File Offset: 0x00011E1C
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

		// Token: 0x06000253 RID: 595 RVA: 0x00012E58 File Offset: 0x00011E58
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.labMultiSimLesson = new global::System.Windows.Forms.Label();
			this.lboSim = new global::System.Windows.Forms.ListBox();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.lboLesson = new global::System.Windows.Forms.ListBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.labMultiSimLesson);
			this.panel2.Controls.Add(this.lboSim);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Controls.Add(this.btnOK);
			this.panel2.Controls.Add(this.lboLesson);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(424, 480);
			this.panel2.TabIndex = 0;
			this.panel2.Click += new global::System.EventHandler(this.btnOK_Click);
			this.labMultiSimLesson.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labMultiSimLesson.Location = new global::System.Drawing.Point(80, 371);
			this.labMultiSimLesson.Name = "labMultiSimLesson";
			this.labMultiSimLesson.Size = new global::System.Drawing.Size(120, 40);
			this.labMultiSimLesson.TabIndex = 5;
			this.labMultiSimLesson.Text = "Choose a Specific Sim:";
			this.labMultiSimLesson.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.labMultiSimLesson.Visible = false;
			this.lboSim.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lboSim.ItemHeight = 16;
			this.lboSim.Location = new global::System.Drawing.Point(200, 371);
			this.lboSim.Name = "lboSim";
			this.lboSim.Size = new global::System.Drawing.Size(64, 52);
			this.lboSim.TabIndex = 4;
			this.lboSim.Visible = false;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(232, 435);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(104, 435);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.lboLesson.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lboLesson.ItemHeight = 16;
			this.lboLesson.Location = new global::System.Drawing.Point(32, 61);
			this.lboLesson.Name = "lboLesson";
			this.lboLesson.Size = new global::System.Drawing.Size(360, 292);
			this.lboLesson.TabIndex = 1;
			this.lboLesson.SelectedIndexChanged += new global::System.EventHandler(this.lboLesson_SelectedIndexChanged);
			this.lboLesson.DoubleClick += new global::System.EventHandler(this.lboLesson_DoubleClick);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 20.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(80, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(264, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose a Lesson:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(424, 480);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmLessonsSimple";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmLessons";
			base.Load += new global::System.EventHandler(this.frmLessonsSimple_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000171 RID: 369
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.ListBox lboLesson;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.ListBox lboSim;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.Label labMultiSimLesson;
	}
}
