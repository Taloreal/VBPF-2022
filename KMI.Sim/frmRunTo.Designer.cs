namespace KMI.Sim
{
	// Token: 0x0200002F RID: 47
	public partial class frmRunTo : global::System.Windows.Forms.Form
	{
		// Token: 0x060001D8 RID: 472 RVA: 0x0000F638 File Offset: 0x0000E638
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

		// Token: 0x060001D9 RID: 473 RVA: 0x0000F674 File Offset: 0x0000E674
		private void InitializeComponent()
		{
			this.radTo = new global::System.Windows.Forms.RadioButton();
			this.cal1 = new global::System.Windows.Forms.MonthCalendar();
			this.radFor = new global::System.Windows.Forms.RadioButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.updPeriods = new global::System.Windows.Forms.NumericUpDown();
			this.radCancel = new global::System.Windows.Forms.RadioButton();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.cboUnits = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.updPeriods).BeginInit();
			base.SuspendLayout();
			this.radTo.Location = new global::System.Drawing.Point(32, 24);
			this.radTo.Name = "radTo";
			this.radTo.Size = new global::System.Drawing.Size(96, 24);
			this.radTo.TabIndex = 0;
			this.radTo.Text = "Run to Date:";
			this.cal1.Location = new global::System.Drawing.Point(136, 24);
			this.cal1.MaxSelectionCount = 1;
			this.cal1.Name = "cal1";
			this.cal1.TabIndex = 1;
			this.cal1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cal1_MouseDown);
			this.radFor.Location = new global::System.Drawing.Point(32, 200);
			this.radFor.Name = "radFor";
			this.radFor.Size = new global::System.Drawing.Size(144, 16);
			this.radFor.TabIndex = 2;
			this.radFor.Text = "Run for Period of Time:";
			this.label1.Location = new global::System.Drawing.Point(104, 240);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(48, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "Run for";
			this.updPeriods.Location = new global::System.Drawing.Point(152, 240);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updPeriods;
			int[] array = new int[4];
			array[0] = 10000;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updPeriods;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Minimum = new decimal(array);
			this.updPeriods.Name = "updPeriods";
			this.updPeriods.Size = new global::System.Drawing.Size(64, 20);
			this.updPeriods.TabIndex = 4;
			this.updPeriods.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.updPeriods;
			array = new int[4];
			array[0] = 1;
			numericUpDown3.Value = new decimal(array);
			this.updPeriods.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.updPeriods_MouseDown);
			this.radCancel.Location = new global::System.Drawing.Point(32, 296);
			this.radCancel.Name = "radCancel";
			this.radCancel.Size = new global::System.Drawing.Size(192, 16);
			this.radCancel.TabIndex = 5;
			this.radCancel.Text = "Cancel \"Run to\" -- Run Normally";
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(144, 336);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOk.Location = new global::System.Drawing.Point(24, 336);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(96, 24);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.btnHelp.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnHelp.Location = new global::System.Drawing.Point(264, 336);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.cboUnits.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUnits.Items.AddRange(new object[]
			{
				"Days",
				"Weeks"
			});
			this.cboUnits.Location = new global::System.Drawing.Point(224, 240);
			this.cboUnits.Name = "cboUnits";
			this.cboUnits.Size = new global::System.Drawing.Size(80, 21);
			this.cboUnits.TabIndex = 9;
			this.cboUnits.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.updPeriods_MouseDown);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(386, 384);
			base.Controls.Add(this.cboUnits);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.radCancel);
			base.Controls.Add(this.updPeriods);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radFor);
			base.Controls.Add(this.cal1);
			base.Controls.Add(this.radTo);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmRunTo";
			base.ShowInTaskbar = false;
			this.Text = "Run to...";
			((global::System.ComponentModel.ISupportInitialize)this.updPeriods).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.RadioButton radTo;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.MonthCalendar cal1;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.RadioButton radFor;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.NumericUpDown updPeriods;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.RadioButton radCancel;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.ComboBox cboUnits;

		// Token: 0x04000132 RID: 306
		private global::System.ComponentModel.Container components = null;
	}
}
