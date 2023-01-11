namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmAppProvideCash.
	/// </summary>
	// Token: 0x0200009B RID: 155
	public partial class frmAppProvideCash : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004CF RID: 1231 RVA: 0x00044940 File Offset: 0x00043940
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
		// Token: 0x060004D0 RID: 1232 RVA: 0x0004497C File Offset: 0x0004397C
		private void InitializeComponent()
		{
			this.labDescription = new global::System.Windows.Forms.Label();
			this.labStore = new global::System.Windows.Forms.Label();
			this.updCash = new global::System.Windows.Forms.NumericUpDown();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cboNames = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.updCash).BeginInit();
			base.SuspendLayout();
			this.labDescription.Location = new global::System.Drawing.Point(16, 11);
			this.labDescription.Name = "labDescription";
			this.labDescription.Size = new global::System.Drawing.Size(304, 53);
			this.labDescription.TabIndex = 5;
			this.labDescription.Text = "This feature lets you \"bail out\" a person by providing cash.   This feature can be used by Instructors to keep students involved and encouraged.";
			this.labStore.Location = new global::System.Drawing.Point(16, 72);
			this.labStore.Name = "labStore";
			this.labStore.Size = new global::System.Drawing.Size(184, 16);
			this.labStore.TabIndex = 6;
			this.labStore.Text = "Amount to give:";
			this.labStore.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updCash;
			int[] array = new int[4];
			array[0] = 10000;
			numericUpDown.Increment = new decimal(array);
			this.updCash.Location = new global::System.Drawing.Point(200, 72);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updCash;
			array = new int[4];
			array[0] = 100000000;
			numericUpDown2.Maximum = new decimal(array);
			this.updCash.Minimum = new decimal(new int[]
			{
				100000000,
				0,
				0,
				int.MinValue
			});
			this.updCash.Name = "updCash";
			this.updCash.Size = new global::System.Drawing.Size(88, 20);
			this.updCash.TabIndex = 7;
			this.updCash.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updCash.ThousandsSeparator = true;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(184, 147);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnOk.Location = new global::System.Drawing.Point(64, 147);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(96, 24);
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.label1.Location = new global::System.Drawing.Point(32, 104);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(120, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Person to recieve:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.cboNames.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboNames.Location = new global::System.Drawing.Point(152, 104);
			this.cboNames.Name = "cboNames";
			this.cboNames.Size = new global::System.Drawing.Size(136, 21);
			this.cboNames.TabIndex = 11;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(336, 190);
			base.Controls.Add(this.cboNames);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.labDescription);
			base.Controls.Add(this.labStore);
			base.Controls.Add(this.updCash);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Name = "frmAppProvideCash";
			this.Text = "Provide Cash";
			base.Load += new global::System.EventHandler(this.frmAppProvideCash_Load);
			((global::System.ComponentModel.ISupportInitialize)this.updCash).EndInit();
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005B0 RID: 1456
		private global::System.ComponentModel.Container components = null;

		// Token: 0x040005B1 RID: 1457
		private global::System.Windows.Forms.Label labDescription;

		// Token: 0x040005B2 RID: 1458
		private global::System.Windows.Forms.Label labStore;

		// Token: 0x040005B3 RID: 1459
		private global::System.Windows.Forms.NumericUpDown updCash;

		// Token: 0x040005B4 RID: 1460
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040005B5 RID: 1461
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x040005B6 RID: 1462
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005B7 RID: 1463
		private global::System.Windows.Forms.ComboBox cboNames;
	}
}
