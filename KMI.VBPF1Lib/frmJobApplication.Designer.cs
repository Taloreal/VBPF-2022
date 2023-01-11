namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmJobApplication.
	/// </summary>
	// Token: 0x0200004D RID: 77
	public partial class frmJobApplication : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600020F RID: 527 RVA: 0x000200E0 File Offset: 0x0001F0E0
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
		// Token: 0x06000210 RID: 528 RVA: 0x0002011C File Offset: 0x0001F11C
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label14 = new global::System.Windows.Forms.Label();
			this.panWorkMonths = new global::System.Windows.Forms.Panel();
			this.numericUpDown4 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown3 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panWork = new global::System.Windows.Forms.Panel();
			this.comboBox7 = new global::System.Windows.Forms.ComboBox();
			this.comboBox8 = new global::System.Windows.Forms.ComboBox();
			this.comboBox9 = new global::System.Windows.Forms.ComboBox();
			this.comboBox10 = new global::System.Windows.Forms.ComboBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panEducation = new global::System.Windows.Forms.Panel();
			this.comboBox4 = new global::System.Windows.Forms.ComboBox();
			this.comboBox3 = new global::System.Windows.Forms.ComboBox();
			this.comboBox2 = new global::System.Windows.Forms.ComboBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.chkCar = new global::System.Windows.Forms.CheckBox();
			this.txtName = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panWorkMonths.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			this.panWork.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panEducation.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.White;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.chkCar);
			this.panel1.Controls.Add(this.txtName);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new global::System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(376, 412);
			this.panel1.TabIndex = 0;
			this.panel3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label14);
			this.panel3.Controls.Add(this.panWorkMonths);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.panWork);
			this.panel3.Location = new global::System.Drawing.Point(16, 224);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(344, 156);
			this.panel3.TabIndex = 6;
			this.label14.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new global::System.Drawing.Point(8, 4);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(76, 16);
			this.label14.TabIndex = 0;
			this.label14.Text = "Work History";
			this.panWorkMonths.Controls.Add(this.numericUpDown4);
			this.panWorkMonths.Controls.Add(this.numericUpDown3);
			this.panWorkMonths.Controls.Add(this.numericUpDown2);
			this.panWorkMonths.Controls.Add(this.numericUpDown1);
			this.panWorkMonths.Location = new global::System.Drawing.Point(272, 32);
			this.panWorkMonths.Name = "panWorkMonths";
			this.panWorkMonths.Size = new global::System.Drawing.Size(64, 116);
			this.panWorkMonths.TabIndex = 9;
			this.numericUpDown4.Location = new global::System.Drawing.Point(8, 88);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new global::System.Drawing.Size(44, 20);
			this.numericUpDown4.TabIndex = 3;
			this.numericUpDown4.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown3.Location = new global::System.Drawing.Point(8, 60);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new global::System.Drawing.Size(44, 20);
			this.numericUpDown3.TabIndex = 2;
			this.numericUpDown3.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown2.Location = new global::System.Drawing.Point(8, 32);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new global::System.Drawing.Size(44, 20);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown1.Location = new global::System.Drawing.Point(8, 4);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(44, 20);
			this.numericUpDown1.TabIndex = 0;
			this.numericUpDown1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.label9.Location = new global::System.Drawing.Point(276, 0);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(52, 32);
			this.label9.TabIndex = 8;
			this.label9.Text = "Months at Job";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label8.Location = new global::System.Drawing.Point(104, 12);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(68, 16);
			this.label8.TabIndex = 7;
			this.label8.Text = "Job Title";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.panWork.Controls.Add(this.comboBox7);
			this.panWork.Controls.Add(this.comboBox8);
			this.panWork.Controls.Add(this.comboBox9);
			this.panWork.Controls.Add(this.comboBox10);
			this.panWork.Location = new global::System.Drawing.Point(16, 32);
			this.panWork.Name = "panWork";
			this.panWork.Size = new global::System.Drawing.Size(240, 112);
			this.panWork.TabIndex = 6;
			this.comboBox7.Location = new global::System.Drawing.Point(4, 84);
			this.comboBox7.Name = "comboBox7";
			this.comboBox7.Size = new global::System.Drawing.Size(232, 21);
			this.comboBox7.TabIndex = 7;
			this.comboBox8.Location = new global::System.Drawing.Point(4, 60);
			this.comboBox8.Name = "comboBox8";
			this.comboBox8.Size = new global::System.Drawing.Size(232, 21);
			this.comboBox8.TabIndex = 6;
			this.comboBox9.Location = new global::System.Drawing.Point(4, 32);
			this.comboBox9.Name = "comboBox9";
			this.comboBox9.Size = new global::System.Drawing.Size(232, 21);
			this.comboBox9.TabIndex = 5;
			this.comboBox10.Location = new global::System.Drawing.Point(4, 4);
			this.comboBox10.Name = "comboBox10";
			this.comboBox10.Size = new global::System.Drawing.Size(232, 21);
			this.comboBox10.TabIndex = 4;
			this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panEducation);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new global::System.Drawing.Point(16, 68);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(344, 144);
			this.panel2.TabIndex = 5;
			this.panEducation.Controls.Add(this.comboBox4);
			this.panEducation.Controls.Add(this.comboBox3);
			this.panEducation.Controls.Add(this.comboBox2);
			this.panEducation.Controls.Add(this.comboBox1);
			this.panEducation.Location = new global::System.Drawing.Point(64, 4);
			this.panEducation.Name = "panEducation";
			this.panEducation.Size = new global::System.Drawing.Size(276, 132);
			this.panEducation.TabIndex = 6;
			this.comboBox4.Location = new global::System.Drawing.Point(8, 104);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new global::System.Drawing.Size(256, 21);
			this.comboBox4.TabIndex = 7;
			this.comboBox3.Location = new global::System.Drawing.Point(8, 76);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new global::System.Drawing.Size(256, 21);
			this.comboBox3.TabIndex = 6;
			this.comboBox2.Location = new global::System.Drawing.Point(8, 48);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new global::System.Drawing.Size(256, 21);
			this.comboBox2.TabIndex = 5;
			this.comboBox1.Location = new global::System.Drawing.Point(8, 20);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(256, 21);
			this.comboBox1.TabIndex = 4;
			this.label7.Location = new global::System.Drawing.Point(16, 112);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 12);
			this.label7.TabIndex = 4;
			this.label7.Text = "Course 4:";
			this.label6.Location = new global::System.Drawing.Point(16, 84);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(56, 12);
			this.label6.TabIndex = 3;
			this.label6.Text = "Course 3:";
			this.label5.Location = new global::System.Drawing.Point(16, 56);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(56, 12);
			this.label5.TabIndex = 2;
			this.label5.Text = "Course 2:";
			this.label4.Location = new global::System.Drawing.Point(16, 28);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(56, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "Course 1:";
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(4, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(132, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Education";
			this.chkCar.Location = new global::System.Drawing.Point(56, 388);
			this.chkCar.Name = "chkCar";
			this.chkCar.Size = new global::System.Drawing.Size(272, 16);
			this.chkCar.TabIndex = 3;
			this.chkCar.Text = "Check if you have access to an automobile";
			this.txtName.Location = new global::System.Drawing.Point(76, 36);
			this.txtName.Name = "txtName";
			this.txtName.Size = new global::System.Drawing.Size(180, 20);
			this.txtName.TabIndex = 2;
			this.txtName.Text = "";
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f);
			this.label2.Location = new global::System.Drawing.Point(28, 40);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(36, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Name:";
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(112, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(152, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Application for Employment";
			this.btnOK.Location = new global::System.Drawing.Point(44, 444);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(92, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(164, 444);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(92, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(284, 444);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(92, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(400, 482);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmJobApplication";
			base.ShowInTaskbar = false;
			this.Text = "Apply for Job";
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panWorkMonths.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			this.panWork.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panEducation.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.Panel panEducation;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.ComboBox comboBox2;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.ComboBox comboBox3;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.ComboBox comboBox4;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.ComboBox comboBox7;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.ComboBox comboBox8;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.ComboBox comboBox9;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.ComboBox comboBox10;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.NumericUpDown numericUpDown1;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.NumericUpDown numericUpDown2;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.NumericUpDown numericUpDown3;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.NumericUpDown numericUpDown4;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.Panel panWork;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.Panel panWorkMonths;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.CheckBox chkCar;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.TextBox txtName;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400024D RID: 589
		private global::System.ComponentModel.Container components = null;
	}
}
