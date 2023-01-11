namespace KMI.Sim.Surveys
{
	// Token: 0x0200007D RID: 125
	public partial class frmSurvey : global::System.Windows.Forms.Form
	{
		// Token: 0x06000468 RID: 1128 RVA: 0x0001FCDC File Offset: 0x0001ECDC
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

		// Token: 0x06000469 RID: 1129 RVA: 0x0001FD18 File Offset: 0x0001ED18
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.chkQuestion = new global::System.Windows.Forms.CheckBox();
			this.grpBoxNumber = new global::System.Windows.Forms.GroupBox();
			this.updNumToSurvey = new global::System.Windows.Forms.NumericUpDown();
			this.label7 = new global::System.Windows.Forms.Label();
			this.grpBoxCost = new global::System.Windows.Forms.GroupBox();
			this.labTotalCost = new global::System.Windows.Forms.Label();
			this.labExecutionCosts = new global::System.Windows.Forms.Label();
			this.labRecruitingCosts = new global::System.Windows.Forms.Label();
			this.labBaseCost = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cmdOK = new global::System.Windows.Forms.Button();
			this.cmdCancel = new global::System.Windows.Forms.Button();
			this.cmdHelp = new global::System.Windows.Forms.Button();
			this.labQuestions = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.grpBoxNumber.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updNumToSurvey).BeginInit();
			this.grpBoxCost.SuspendLayout();
			base.SuspendLayout();
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.chkQuestion);
			this.panel1.Location = new global::System.Drawing.Point(16, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(384, 288);
			this.panel1.TabIndex = 1;
			this.chkQuestion.Location = new global::System.Drawing.Point(16, 16);
			this.chkQuestion.Name = "chkQuestion";
			this.chkQuestion.Size = new global::System.Drawing.Size(352, 16);
			this.chkQuestion.TabIndex = 0;
			this.chkQuestion.Text = "Question 1";
			this.chkQuestion.CheckedChanged += new global::System.EventHandler(this.chkQuestion_CheckedChanged);
			this.grpBoxNumber.Controls.Add(this.updNumToSurvey);
			this.grpBoxNumber.Controls.Add(this.label7);
			this.grpBoxNumber.Location = new global::System.Drawing.Point(408, 40);
			this.grpBoxNumber.Name = "grpBoxNumber";
			this.grpBoxNumber.Size = new global::System.Drawing.Size(208, 88);
			this.grpBoxNumber.TabIndex = 2;
			this.grpBoxNumber.TabStop = false;
			this.grpBoxNumber.Text = "Number of XXX to Survey";
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updNumToSurvey;
			int[] array = new int[4];
			array[0] = 25;
			numericUpDown.Increment = new decimal(array);
			this.updNumToSurvey.Location = new global::System.Drawing.Point(128, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updNumToSurvey;
			array = new int[4];
			array[0] = 10000;
			numericUpDown2.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.updNumToSurvey;
			array = new int[4];
			array[0] = 1;
			numericUpDown3.Minimum = new decimal(array);
			this.updNumToSurvey.Name = "updNumToSurvey";
			this.updNumToSurvey.Size = new global::System.Drawing.Size(64, 20);
			this.updNumToSurvey.TabIndex = 1;
			this.updNumToSurvey.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.updNumToSurvey;
			array = new int[4];
			array[0] = 100;
			numericUpDown4.Value = new decimal(array);
			this.updNumToSurvey.ValueChanged += new global::System.EventHandler(this.updNumToSurvey_ValueChanged);
			this.label7.Location = new global::System.Drawing.Point(16, 40);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(96, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "Total Number";
			this.grpBoxCost.Controls.Add(this.labTotalCost);
			this.grpBoxCost.Controls.Add(this.labExecutionCosts);
			this.grpBoxCost.Controls.Add(this.labRecruitingCosts);
			this.grpBoxCost.Controls.Add(this.labBaseCost);
			this.grpBoxCost.Controls.Add(this.label5);
			this.grpBoxCost.Controls.Add(this.label4);
			this.grpBoxCost.Controls.Add(this.label3);
			this.grpBoxCost.Controls.Add(this.label2);
			this.grpBoxCost.Controls.Add(this.label1);
			this.grpBoxCost.Location = new global::System.Drawing.Point(408, 152);
			this.grpBoxCost.Name = "grpBoxCost";
			this.grpBoxCost.Size = new global::System.Drawing.Size(208, 120);
			this.grpBoxCost.TabIndex = 3;
			this.grpBoxCost.TabStop = false;
			this.grpBoxCost.Text = "Estimated Cost";
			this.labTotalCost.Location = new global::System.Drawing.Point(120, 96);
			this.labTotalCost.Name = "labTotalCost";
			this.labTotalCost.Size = new global::System.Drawing.Size(72, 16);
			this.labTotalCost.TabIndex = 8;
			this.labTotalCost.Text = "XX";
			this.labTotalCost.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labExecutionCosts.Location = new global::System.Drawing.Point(120, 72);
			this.labExecutionCosts.Name = "labExecutionCosts";
			this.labExecutionCosts.Size = new global::System.Drawing.Size(72, 16);
			this.labExecutionCosts.TabIndex = 5;
			this.labExecutionCosts.Text = "XX";
			this.labExecutionCosts.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labRecruitingCosts.Location = new global::System.Drawing.Point(120, 48);
			this.labRecruitingCosts.Name = "labRecruitingCosts";
			this.labRecruitingCosts.Size = new global::System.Drawing.Size(72, 16);
			this.labRecruitingCosts.TabIndex = 3;
			this.labRecruitingCosts.Text = "XX";
			this.labRecruitingCosts.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labBaseCost.Location = new global::System.Drawing.Point(120, 24);
			this.labBaseCost.Name = "labBaseCost";
			this.labBaseCost.Size = new global::System.Drawing.Size(72, 16);
			this.labBaseCost.TabIndex = 1;
			this.labBaseCost.Text = "XX";
			this.labBaseCost.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label5.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new global::System.Drawing.Point(8, 88);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(184, 1);
			this.label5.TabIndex = 6;
			this.label4.Location = new global::System.Drawing.Point(8, 96);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(120, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "   Total Cost";
			this.label3.Location = new global::System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(120, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "+ Execution Costs";
			this.label2.Location = new global::System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(120, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "+ Recruiting Costs";
			this.label1.Location = new global::System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "   Base Cost";
			this.cmdOK.Location = new global::System.Drawing.Point(176, 360);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new global::System.Drawing.Size(96, 24);
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new global::System.EventHandler(this.cmdOK_Click);
			this.cmdCancel.Location = new global::System.Drawing.Point(296, 360);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new global::System.Drawing.Size(96, 24);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new global::System.EventHandler(this.cmdCancel_Click);
			this.cmdHelp.Location = new global::System.Drawing.Point(416, 360);
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.Size = new global::System.Drawing.Size(96, 24);
			this.cmdHelp.TabIndex = 6;
			this.cmdHelp.Text = "Help";
			this.cmdHelp.Click += new global::System.EventHandler(this.cmdHelp_Click);
			this.labQuestions.Location = new global::System.Drawing.Point(24, 24);
			this.labQuestions.Name = "labQuestions";
			this.labQuestions.Size = new global::System.Drawing.Size(224, 16);
			this.labQuestions.TabIndex = 0;
			this.labQuestions.Text = "Questions to Ask XXX";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(632, 398);
			base.Controls.Add(this.labQuestions);
			base.Controls.Add(this.cmdHelp);
			base.Controls.Add(this.cmdCancel);
			base.Controls.Add(this.cmdOK);
			base.Controls.Add(this.grpBoxCost);
			base.Controls.Add(this.grpBoxNumber);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmSurvey";
			base.ShowInTaskbar = false;
			this.Text = "New Survey";
			this.panel1.ResumeLayout(false);
			this.grpBoxNumber.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updNumToSurvey).EndInit();
			this.grpBoxCost.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.Button cmdOK;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.Button cmdCancel;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.Button cmdHelp;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.Label labBaseCost;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.Label labRecruitingCosts;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.Label labExecutionCosts;

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.Label labTotalCost;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.CheckBox chkQuestion;

		// Token: 0x040002FD RID: 765
		public global::System.Windows.Forms.NumericUpDown updNumToSurvey;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.Label labQuestions;

		// Token: 0x040002FF RID: 767
		private global::System.Windows.Forms.GroupBox grpBoxNumber;

		// Token: 0x04000300 RID: 768
		private global::System.Windows.Forms.GroupBox grpBoxCost;

		// Token: 0x04000301 RID: 769
		private global::System.ComponentModel.Container components = null;
	}
}
