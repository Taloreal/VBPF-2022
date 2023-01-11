namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmRiskManagement.
	/// </summary>
	// Token: 0x020000AA RID: 170
	public partial class frmAutoInsurance : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600050F RID: 1295 RVA: 0x000493C4 File Offset: 0x000483C4
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
		// Token: 0x06000510 RID: 1296 RVA: 0x00049400 File Offset: 0x00048400
		private void InitializeComponent()
		{
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.cboDeductible = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.labPremium = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.labValue = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(224, 232);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(80, 24);
			this.btnHelp.TabIndex = 16;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(128, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(32, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.cboDeductible.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDeductible.Location = new global::System.Drawing.Point(144, 72);
			this.cboDeductible.Name = "cboDeductible";
			this.cboDeductible.Size = new global::System.Drawing.Size(88, 21);
			this.cboDeductible.TabIndex = 17;
			this.cboDeductible.SelectedIndexChanged += new global::System.EventHandler(this.cboDeductible_SelectedIndexChanged);
			this.label2.Location = new global::System.Drawing.Point(48, 120);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(80, 40);
			this.label2.TabIndex = 19;
			this.label2.Text = "Mandatory Liability Coverage:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label3.Location = new global::System.Drawing.Point(152, 128);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(144, 32);
			this.label3.TabIndex = 20;
			this.label3.Text = "$100,000 Bodily Injury";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
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
			this.label6.Location = new global::System.Drawing.Point(64, 64);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(64, 32);
			this.label6.TabIndex = 23;
			this.label6.Text = "Collision Deductible:";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labValue.Location = new global::System.Drawing.Point(144, 32);
			this.labValue.Name = "labValue";
			this.labValue.Size = new global::System.Drawing.Size(112, 16);
			this.labValue.TabIndex = 26;
			this.label7.Location = new global::System.Drawing.Point(32, 32);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(96, 16);
			this.label7.TabIndex = 25;
			this.label7.Text = "Estimated Value:";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(330, 280);
			base.Controls.Add(this.labValue);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.labPremium);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.cboDeductible);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmAutoInsurance";
			base.ShowInTaskbar = false;
			this.Text = "Auto Insurance";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmAutoInsurance_Closing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400060C RID: 1548
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400060D RID: 1549
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400060E RID: 1550
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400060F RID: 1551
		private global::System.Windows.Forms.ComboBox cboDeductible;

		// Token: 0x04000610 RID: 1552
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000611 RID: 1553
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000612 RID: 1554
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000613 RID: 1555
		private global::System.Windows.Forms.Label labPremium;

		// Token: 0x04000614 RID: 1556
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000615 RID: 1557
		private global::System.Windows.Forms.Label labValue;

		// Token: 0x04000616 RID: 1558
		private global::System.Windows.Forms.Label label7;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000617 RID: 1559
		private global::System.ComponentModel.Container components = null;
	}
}
