namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmRiskManagement.
	/// </summary>
	// Token: 0x0200003C RID: 60
	public partial class frmHomeOwnersInsurance : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060001C8 RID: 456 RVA: 0x0001C568 File Offset: 0x0001B568
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
		// Token: 0x060001C9 RID: 457 RVA: 0x0001C5A4 File Offset: 0x0001B5A4
		private void InitializeComponent()
		{
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.cboDeductible = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.labPremium = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.labValue = new global::System.Windows.Forms.Label();
			this.labInsuranceRequired = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(216, 232);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(80, 24);
			this.btnHelp.TabIndex = 16;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(120, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(24, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.cboDeductible.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDeductible.Location = new global::System.Drawing.Point(144, 136);
			this.cboDeductible.Name = "cboDeductible";
			this.cboDeductible.Size = new global::System.Drawing.Size(88, 21);
			this.cboDeductible.TabIndex = 17;
			this.cboDeductible.SelectedIndexChanged += new global::System.EventHandler(this.cboDeductible_SelectedIndexChanged);
			this.label4.Location = new global::System.Drawing.Point(48, 184);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(88, 24);
			this.label4.TabIndex = 21;
			this.label4.Text = "Yearly Premium:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labPremium.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPremium.Location = new global::System.Drawing.Point(152, 184);
			this.labPremium.Name = "labPremium";
			this.labPremium.Size = new global::System.Drawing.Size(112, 16);
			this.labPremium.TabIndex = 22;
			this.labPremium.Text = "$0";
			this.label6.Location = new global::System.Drawing.Point(40, 136);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(88, 24);
			this.label6.TabIndex = 23;
			this.label6.Text = "Deductible:";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label7.Location = new global::System.Drawing.Point(32, 88);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(96, 32);
			this.label7.TabIndex = 25;
			this.label7.Text = "Amount of Coverage:";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 100;
			numericUpDown.Increment = new decimal(array);
			this.updAmount.Location = new global::System.Drawing.Point(144, 96);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updAmount;
			array = new int[4];
			array[0] = 1000000;
			numericUpDown2.Maximum = new decimal(array);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(88, 20);
			this.updAmount.TabIndex = 26;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			this.updAmount.ValueChanged += new global::System.EventHandler(this.cboDeductible_SelectedIndexChanged);
			this.label2.Location = new global::System.Drawing.Point(40, 48);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 32);
			this.label2.TabIndex = 29;
			this.label2.Text = "Estimated Market Value:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labValue.Location = new global::System.Drawing.Point(152, 64);
			this.labValue.Name = "labValue";
			this.labValue.Size = new global::System.Drawing.Size(80, 16);
			this.labValue.TabIndex = 30;
			this.labValue.Text = "$0";
			this.labValue.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labInsuranceRequired.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labInsuranceRequired.ForeColor = global::System.Drawing.Color.Gray;
			this.labInsuranceRequired.Location = new global::System.Drawing.Point(8, 16);
			this.labInsuranceRequired.Name = "labInsuranceRequired";
			this.labInsuranceRequired.Size = new global::System.Drawing.Size(304, 24);
			this.labInsuranceRequired.TabIndex = 31;
			this.labInsuranceRequired.Text = "You are required to have insurance on your new condo.";
			this.labInsuranceRequired.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labInsuranceRequired.Visible = false;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(322, 272);
			base.Controls.Add(this.labInsuranceRequired);
			base.Controls.Add(this.labValue);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.labPremium);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.cboDeductible);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmHomeOwnersInsurance";
			base.ShowInTaskbar = false;
			this.Text = "Homeowner's Insurance";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmHomeOwnersInsurance_Closing);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.ComboBox cboDeductible;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Label labPremium;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.Label labInsuranceRequired;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.Label labValue;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040001E7 RID: 487
		private global::System.ComponentModel.Container components = null;
	}
}
