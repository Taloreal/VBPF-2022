namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmRiskManagement.
	/// </summary>
	// Token: 0x0200007B RID: 123
	public partial class frmHealthInsurance : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000319 RID: 793 RVA: 0x00034D64 File Offset: 0x00033D64
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
		// Token: 0x0600031A RID: 794 RVA: 0x00034DA0 File Offset: 0x00033DA0
		private void InitializeComponent()
		{
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.labPremium = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cboCopay = new global::System.Windows.Forms.ComboBox();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(216, 192);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(80, 24);
			this.btnHelp.TabIndex = 16;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(120, 192);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(24, 192);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label3.Location = new global::System.Drawing.Point(32, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(256, 72);
			this.label3.TabIndex = 20;
			this.label3.Text = "Covers hospital expense, surgical expense, and physician expense as well as major medical expense. Includes prescription drug coverage. ";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Location = new global::System.Drawing.Point(40, 144);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(88, 24);
			this.label4.TabIndex = 21;
			this.label4.Text = "Yearly Premium:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labPremium.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPremium.Location = new global::System.Drawing.Point(144, 144);
			this.labPremium.Name = "labPremium";
			this.labPremium.Size = new global::System.Drawing.Size(112, 16);
			this.labPremium.TabIndex = 22;
			this.labPremium.Text = "$0";
			this.label6.Location = new global::System.Drawing.Point(16, 96);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(136, 32);
			this.label6.TabIndex = 25;
			this.label6.Text = "Copay on Office Visits and Prescription Drugs:";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.cboCopay.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCopay.Location = new global::System.Drawing.Point(168, 104);
			this.cboCopay.Name = "cboCopay";
			this.cboCopay.Size = new global::System.Drawing.Size(88, 21);
			this.cboCopay.TabIndex = 24;
			this.cboCopay.SelectedIndexChanged += new global::System.EventHandler(this.cboCopay_SelectedIndexChanged);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(322, 232);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.cboCopay);
			base.Controls.Add(this.labPremium);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmHealthInsurance";
			base.ShowInTaskbar = false;
			this.Text = "Health Insurance";
			base.ResumeLayout(false);
		}

		// Token: 0x040003FA RID: 1018
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040003FB RID: 1019
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040003FC RID: 1020
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040003FD RID: 1021
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040003FE RID: 1022
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040003FF RID: 1023
		private global::System.Windows.Forms.Label labPremium;

		// Token: 0x04000400 RID: 1024
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000401 RID: 1025
		private global::System.Windows.Forms.ComboBox cboCopay;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000402 RID: 1026
		private global::System.ComponentModel.Container components = null;
	}
}
