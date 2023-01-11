namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayInCash.
	/// </summary>
	// Token: 0x0200003B RID: 59
	public partial class frmPayInCash : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060001C2 RID: 450 RVA: 0x0001BEB8 File Offset: 0x0001AEB8
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
		// Token: 0x060001C3 RID: 451 RVA: 0x0001BEF4 File Offset: 0x0001AEF4
		private void InitializeComponent()
		{
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labCash = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(108, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(208, 184);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(80, 24);
			this.btnHelp.TabIndex = 13;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new global::System.Drawing.Point(12, 184);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(76, 24);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.updAmount.DecimalPlaces = 2;
			this.updAmount.Location = new global::System.Drawing.Point(152, 116);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 1000000;
			numericUpDown.Maximum = new decimal(array);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(96, 20);
			this.updAmount.TabIndex = 16;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updAmount;
			array = new int[4];
			array[0] = 20;
			numericUpDown2.Value = new decimal(array);
			this.label2.Location = new global::System.Drawing.Point(52, 120);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(96, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "Amount to Pay:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(32, 24);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(240, 24);
			this.label3.TabIndex = 18;
			this.label3.Text = "Current Cash Balance:";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labCash.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labCash.Location = new global::System.Drawing.Point(32, 52);
			this.labCash.Name = "labCash";
			this.labCash.Size = new global::System.Drawing.Size(240, 24);
			this.labCash.TabIndex = 19;
			this.labCash.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(300, 226);
			base.Controls.Add(this.labCash);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPayInCash";
			base.ShowInTaskbar = false;
			this.Text = "Pay In Cash";
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040001D5 RID: 469
		public global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.Label labCash;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040001DA RID: 474
		private global::System.ComponentModel.Container components = null;
	}
}
