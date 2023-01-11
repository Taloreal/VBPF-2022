namespace KMI.Sim.Surveys
{
	// Token: 0x02000068 RID: 104
	public partial class frmSurveySegment : global::System.Windows.Forms.Form
	{
		// Token: 0x060003CC RID: 972 RVA: 0x0001B354 File Offset: 0x0001A354
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

		// Token: 0x060003CD RID: 973 RVA: 0x0001B390 File Offset: 0x0001A390
		private void InitializeComponent()
		{
			this.picCanvas = new global::System.Windows.Forms.PictureBox();
			this.labTotal = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cboQuestion = new global::System.Windows.Forms.ComboBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnApply = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.labEntity = new global::System.Windows.Forms.Label();
			this.cboEntity = new global::System.Windows.Forms.ComboBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.chkAnswer = new global::System.Windows.Forms.CheckBox();
			this.btnClear = new global::System.Windows.Forms.Button();
			this.btnBuyMailingList = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.picCanvas.BackColor = global::System.Drawing.Color.Blue;
			this.picCanvas.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picCanvas.Location = new global::System.Drawing.Point(24, 32);
			this.picCanvas.Name = "picCanvas";
			this.picCanvas.Size = new global::System.Drawing.Size(272, 260);
			this.picCanvas.TabIndex = 0;
			this.picCanvas.TabStop = false;
			this.picCanvas.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
			this.labTotal.Location = new global::System.Drawing.Point(16, 8);
			this.labTotal.Name = "labTotal";
			this.labTotal.Size = new global::System.Drawing.Size(192, 16);
			this.labTotal.TabIndex = 0;
			this.labTotal.Text = "Total XXX in Survey";
			this.label2.Location = new global::System.Drawing.Point(328, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(216, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Select by answer to question:";
			this.cboQuestion.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboQuestion.Location = new global::System.Drawing.Point(328, 32);
			this.cboQuestion.Name = "cboQuestion";
			this.cboQuestion.Size = new global::System.Drawing.Size(288, 21);
			this.cboQuestion.TabIndex = 2;
			this.cboQuestion.SelectedIndexChanged += new global::System.EventHandler(this.cboQuestion_SelectedIndexChanged);
			this.label3.Location = new global::System.Drawing.Point(328, 96);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(280, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Select only customers who answered:";
			this.btnOK.Location = new global::System.Drawing.Point(96, 344);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnApply.Location = new global::System.Drawing.Point(208, 344);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new global::System.Drawing.Size(96, 24);
			this.btnApply.TabIndex = 9;
			this.btnApply.Text = "Apply";
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(320, 344);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(432, 344);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 11;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.labEntity.Location = new global::System.Drawing.Point(328, 64);
			this.labEntity.Name = "labEntity";
			this.labEntity.Size = new global::System.Drawing.Size(128, 16);
			this.labEntity.TabIndex = 3;
			this.labEntity.Text = "Select by rating for:";
			this.cboEntity.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEntity.Location = new global::System.Drawing.Point(448, 64);
			this.cboEntity.Name = "cboEntity";
			this.cboEntity.Size = new global::System.Drawing.Size(168, 21);
			this.cboEntity.TabIndex = 4;
			this.cboEntity.SelectedIndexChanged += new global::System.EventHandler(this.cboEntity_SelectedIndexChanged);
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.chkAnswer);
			this.panel1.Location = new global::System.Drawing.Point(320, 120);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(304, 168);
			this.panel1.TabIndex = 6;
			this.chkAnswer.Location = new global::System.Drawing.Point(12, 8);
			this.chkAnswer.Name = "chkAnswer";
			this.chkAnswer.Size = new global::System.Drawing.Size(268, 16);
			this.chkAnswer.TabIndex = 0;
			this.btnClear.Location = new global::System.Drawing.Point(168, 296);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(128, 24);
			this.btnClear.TabIndex = 7;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.btnBuyMailingList.Location = new global::System.Drawing.Point(24, 296);
			this.btnBuyMailingList.Name = "btnBuyMailingList";
			this.btnBuyMailingList.Size = new global::System.Drawing.Size(128, 24);
			this.btnBuyMailingList.TabIndex = 12;
			this.btnBuyMailingList.Text = "Buy Mailing List";
			this.btnBuyMailingList.Click += new global::System.EventHandler(this.btnBuyMailingList_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(632, 374);
			base.Controls.Add(this.btnBuyMailingList);
			base.Controls.Add(this.btnClear);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.cboEntity);
			base.Controls.Add(this.labEntity);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnApply);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.cboQuestion);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.labTotal);
			base.Controls.Add(this.picCanvas);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmSurveySegment";
			base.ShowInTaskbar = false;
			this.Text = "Select Segment";
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.ComboBox cboQuestion;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.Button btnApply;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.ComboBox cboEntity;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.PictureBox picCanvas;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.Label labEntity;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.CheckBox chkAnswer;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.Label labTotal;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.Button btnBuyMailingList;

		// Token: 0x04000279 RID: 633
		private global::System.ComponentModel.Container components = null;
	}
}
