namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frm401K.
	/// </summary>
	// Token: 0x02000029 RID: 41
	public partial class frm401K : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600013C RID: 316 RVA: 0x00012748 File Offset: 0x00011748
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
		// Token: 0x0600013D RID: 317 RVA: 0x00012784 File Offset: 0x00011784
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.updPercent = new global::System.Windows.Forms.NumericUpDown();
			this.labMatch = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.panFunds = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updPercent).BeginInit();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(20, 28);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(144, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Percent of Pay to Withhold:";
			this.label3.Location = new global::System.Drawing.Point(20, 56);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(136, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Company Match:";
			this.groupBox1.Controls.Add(this.updPercent);
			this.groupBox1.Controls.Add(this.labMatch);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new global::System.Drawing.Point(20, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(268, 92);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Contribution Rate";
			this.updPercent.Location = new global::System.Drawing.Point(172, 24);
			this.updPercent.Name = "updPercent";
			this.updPercent.Size = new global::System.Drawing.Size(44, 20);
			this.updPercent.TabIndex = 4;
			this.updPercent.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updPercent.ValueChanged += new global::System.EventHandler(this.updPercent_ValueChanged);
			this.labMatch.Location = new global::System.Drawing.Point(168, 56);
			this.labMatch.Name = "labMatch";
			this.labMatch.Size = new global::System.Drawing.Size(40, 16);
			this.labMatch.TabIndex = 3;
			this.labMatch.Text = "0%";
			this.labMatch.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.btnHelp.Location = new global::System.Drawing.Point(204, 276);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(72, 24);
			this.btnHelp.TabIndex = 25;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(116, 276);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 24;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(28, 276);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 23;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.groupBox2.Controls.Add(this.panFunds);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new global::System.Drawing.Point(20, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(268, 156);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Investment Allocation";
			this.panFunds.AutoScroll = true;
			this.panFunds.Location = new global::System.Drawing.Point(4, 32);
			this.panFunds.Name = "panFunds";
			this.panFunds.Size = new global::System.Drawing.Size(260, 120);
			this.panFunds.TabIndex = 1;
			this.label2.Location = new global::System.Drawing.Point(52, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(144, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Must add to 100 percent.";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(308, 314);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frm401K";
			base.ShowInTaskbar = false;
			this.Text = "401K Retirement Savings Elections";
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updPercent).EndInit();
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.NumericUpDown updPercent;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.Label labMatch;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.Panel panFunds;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400013F RID: 319
		private global::System.ComponentModel.Container components = null;
	}
}
