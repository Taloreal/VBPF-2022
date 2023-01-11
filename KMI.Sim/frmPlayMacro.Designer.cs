namespace KMI.Sim
{
	// Token: 0x02000004 RID: 4
	public partial class frmPlayMacro : global::System.Windows.Forms.Form
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002288 File Offset: 0x00001288
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

		// Token: 0x06000014 RID: 20 RVA: 0x000022C4 File Offset: 0x000012C4
		private void InitializeComponent()
		{
			this.updInterval = new global::System.Windows.Forms.NumericUpDown();
			this.labMs = new global::System.Windows.Forms.Label();
			this.dlgOpenFile = new global::System.Windows.Forms.OpenFileDialog();
			this.butOK = new global::System.Windows.Forms.Button();
			this.optSimDates = new global::System.Windows.Forms.RadioButton();
			this.optContinuously = new global::System.Windows.Forms.RadioButton();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.butCancel = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.updInterval).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.updInterval.Enabled = false;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updInterval;
			int[] array = new int[4];
			array[0] = 20;
			numericUpDown.Increment = new decimal(array);
			this.updInterval.Location = new global::System.Drawing.Point(56, 72);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updInterval;
			array = new int[4];
			array[0] = 100000;
			numericUpDown2.Maximum = new decimal(array);
			this.updInterval.Name = "updInterval";
			this.updInterval.Size = new global::System.Drawing.Size(64, 20);
			this.updInterval.TabIndex = 4;
			this.updInterval.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.labMs.Enabled = false;
			this.labMs.Location = new global::System.Drawing.Point(128, 72);
			this.labMs.Name = "labMs";
			this.labMs.Size = new global::System.Drawing.Size(56, 23);
			this.labMs.TabIndex = 6;
			this.labMs.Text = "ms/action";
			this.labMs.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.butOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.butOK.Location = new global::System.Drawing.Point(16, 128);
			this.butOK.Name = "butOK";
			this.butOK.Size = new global::System.Drawing.Size(80, 24);
			this.butOK.TabIndex = 7;
			this.butOK.Text = "OK";
			this.optSimDates.Checked = true;
			this.optSimDates.Location = new global::System.Drawing.Point(24, 24);
			this.optSimDates.Name = "optSimDates";
			this.optSimDates.Size = new global::System.Drawing.Size(96, 16);
			this.optSimDates.TabIndex = 8;
			this.optSimDates.TabStop = true;
			this.optSimDates.Text = "At Sim Dates";
			this.optSimDates.CheckedChanged += new global::System.EventHandler(this.optSimDates_CheckedChanged);
			this.optContinuously.Location = new global::System.Drawing.Point(24, 48);
			this.optContinuously.Name = "optContinuously";
			this.optContinuously.Size = new global::System.Drawing.Size(96, 16);
			this.optContinuously.TabIndex = 9;
			this.optContinuously.Text = "Continuously";
			this.groupBox1.Controls.Add(this.optContinuously);
			this.groupBox1.Controls.Add(this.optSimDates);
			this.groupBox1.Controls.Add(this.labMs);
			this.groupBox1.Controls.Add(this.updInterval);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(192, 104);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Play Actions";
			this.butCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new global::System.Drawing.Point(128, 128);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new global::System.Drawing.Size(80, 24);
			this.butCancel.TabIndex = 11;
			this.butCancel.Text = "Cancel";
			base.AcceptButton = this.butOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.butCancel;
			base.ClientSize = new global::System.Drawing.Size(226, 166);
			base.Controls.Add(this.butCancel);
			base.Controls.Add(this.butOK);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPlayMacro";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Macro Play Settings";
			((global::System.ComponentModel.ISupportInitialize)this.updInterval).EndInit();
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label labMs;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.OpenFileDialog dlgOpenFile;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button butOK;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Button butCancel;

		// Token: 0x0400000D RID: 13
		public global::System.Windows.Forms.NumericUpDown updInterval;

		// Token: 0x0400000E RID: 14
		public global::System.Windows.Forms.RadioButton optSimDates;

		// Token: 0x0400000F RID: 15
		public global::System.Windows.Forms.RadioButton optContinuously;

		// Token: 0x04000010 RID: 16
		private global::System.ComponentModel.Container components = null;
	}
}
