namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmRiskManagement.
	/// </summary>
	// Token: 0x0200006B RID: 107
	public partial class frmRentersInsurance : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002C2 RID: 706 RVA: 0x0002D10C File Offset: 0x0002C10C
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
		// Token: 0x060002C3 RID: 707 RVA: 0x0002D148 File Offset: 0x0002C148
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
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(216, 184);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(80, 24);
			this.btnHelp.TabIndex = 16;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(120, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(24, 184);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.cboDeductible.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDeductible.Location = new global::System.Drawing.Point(144, 80);
			this.cboDeductible.Name = "cboDeductible";
			this.cboDeductible.Size = new global::System.Drawing.Size(88, 21);
			this.cboDeductible.TabIndex = 17;
			this.cboDeductible.SelectedIndexChanged += new global::System.EventHandler(this.cboDeductible_SelectedIndexChanged);
			this.label4.Location = new global::System.Drawing.Point(48, 128);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(88, 24);
			this.label4.TabIndex = 21;
			this.label4.Text = "Yearly Premium:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labPremium.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPremium.Location = new global::System.Drawing.Point(152, 128);
			this.labPremium.Name = "labPremium";
			this.labPremium.Size = new global::System.Drawing.Size(112, 16);
			this.labPremium.TabIndex = 22;
			this.labPremium.Text = "$0";
			this.label6.Location = new global::System.Drawing.Point(40, 80);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(88, 24);
			this.label6.TabIndex = 23;
			this.label6.Text = "Deductible:";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label7.Location = new global::System.Drawing.Point(32, 32);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(96, 32);
			this.label7.TabIndex = 25;
			this.label7.Text = "Amount of Coverage:";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 100;
			numericUpDown.Increment = new decimal(array);
			this.updAmount.Location = new global::System.Drawing.Point(144, 40);
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
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(322, 232);
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
			base.Name = "frmRentersInsurance";
			base.ShowInTaskbar = false;
			this.Text = "Renter's Insurance";
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400034F RID: 847
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000350 RID: 848
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000351 RID: 849
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000352 RID: 850
		private global::System.Windows.Forms.ComboBox cboDeductible;

		// Token: 0x04000353 RID: 851
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000354 RID: 852
		private global::System.Windows.Forms.Label labPremium;

		// Token: 0x04000355 RID: 853
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000356 RID: 854
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000357 RID: 855
		private global::System.Windows.Forms.NumericUpDown updAmount;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000358 RID: 856
		private global::System.ComponentModel.Container components = null;
	}
}
