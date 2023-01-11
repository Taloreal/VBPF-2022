namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmLicensing.
	/// </summary>
	// Token: 0x0200009A RID: 154
	public partial class frmDepositChecks : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004C3 RID: 1219 RVA: 0x00043E68 File Offset: 0x00042E68
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
		// Token: 0x060004C4 RID: 1220 RVA: 0x00043EA4 File Offset: 0x00042EA4
		private void InitializeComponent()
		{
			this.btnAccept = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnBack = new global::System.Windows.Forms.Button();
			this.btnNext = new global::System.Windows.Forms.Button();
			this.labNoOffers = new global::System.Windows.Forms.Label();
			this.panChecks = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labWarning = new global::System.Windows.Forms.Label();
			this.cboAccounts = new global::System.Windows.Forms.ComboBox();
			this.optDeposit = new global::System.Windows.Forms.RadioButton();
			this.optCash = new global::System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.btnAccept.Location = new global::System.Drawing.Point(504, 256);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new global::System.Drawing.Size(96, 24);
			this.btnAccept.TabIndex = 0;
			this.btnAccept.Text = "Go";
			this.btnAccept.Click += new global::System.EventHandler(this.btnAccept_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(504, 288);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(504, 320);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnBack.Location = new global::System.Drawing.Point(24, 280);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new global::System.Drawing.Size(48, 24);
			this.btnBack.TabIndex = 4;
			this.btnBack.Text = "<<";
			this.btnBack.Click += new global::System.EventHandler(this.btnBack_Click);
			this.btnNext.Location = new global::System.Drawing.Point(88, 280);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new global::System.Drawing.Size(48, 24);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = ">>";
			this.btnNext.Click += new global::System.EventHandler(this.btnNext_Click);
			this.labNoOffers.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 21.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labNoOffers.ForeColor = global::System.Drawing.Color.Gray;
			this.labNoOffers.Location = new global::System.Drawing.Point(176, 64);
			this.labNoOffers.Name = "labNoOffers";
			this.labNoOffers.Size = new global::System.Drawing.Size(264, 120);
			this.labNoOffers.TabIndex = 7;
			this.labNoOffers.Text = "There are no more checks.";
			this.panChecks.Location = new global::System.Drawing.Point(0, 8);
			this.panChecks.Name = "panChecks";
			this.panChecks.Size = new global::System.Drawing.Size(600, 232);
			this.panChecks.TabIndex = 9;
			this.groupBox1.Controls.Add(this.labWarning);
			this.groupBox1.Controls.Add(this.cboAccounts);
			this.groupBox1.Controls.Add(this.optDeposit);
			this.groupBox1.Controls.Add(this.optCash);
			this.groupBox1.Location = new global::System.Drawing.Point(160, 248);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(320, 96);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cash or Deposit";
			this.labWarning.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labWarning.ForeColor = global::System.Drawing.Color.Red;
			this.labWarning.Location = new global::System.Drawing.Point(112, 18);
			this.labWarning.Name = "labWarning";
			this.labWarning.Size = new global::System.Drawing.Size(200, 24);
			this.labWarning.TabIndex = 4;
			this.labWarning.Text = "Since you do not have a checking account in town, a 10% check cashing fee will be charged.";
			this.cboAccounts.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccounts.Location = new global::System.Drawing.Point(88, 56);
			this.cboAccounts.Name = "cboAccounts";
			this.cboAccounts.Size = new global::System.Drawing.Size(216, 21);
			this.cboAccounts.TabIndex = 1;
			this.optDeposit.Enabled = false;
			this.optDeposit.Location = new global::System.Drawing.Point(16, 56);
			this.optDeposit.Name = "optDeposit";
			this.optDeposit.Size = new global::System.Drawing.Size(80, 16);
			this.optDeposit.TabIndex = 3;
			this.optDeposit.Text = "Deposit to";
			this.optDeposit.CheckedChanged += new global::System.EventHandler(this.optDeposit_CheckedChanged);
			this.optCash.Checked = true;
			this.optCash.Location = new global::System.Drawing.Point(16, 24);
			this.optCash.Name = "optCash";
			this.optCash.Size = new global::System.Drawing.Size(96, 16);
			this.optCash.TabIndex = 2;
			this.optCash.TabStop = true;
			this.optCash.Text = "Cash Check";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(610, 352);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.panChecks);
			base.Controls.Add(this.btnNext);
			base.Controls.Add(this.btnBack);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnAccept);
			base.Controls.Add(this.labNoOffers);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmDepositChecks";
			base.ShowInTaskbar = false;
			this.Text = "Cash or Deposit Checks";
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400059E RID: 1438
		private global::System.Windows.Forms.Panel panChecks;

		// Token: 0x0400059F RID: 1439
		private global::System.Windows.Forms.Button btnBack;

		// Token: 0x040005A0 RID: 1440
		private global::System.Windows.Forms.Button btnNext;

		// Token: 0x040005A1 RID: 1441
		private global::System.Windows.Forms.Label labNoOffers;

		// Token: 0x040005A2 RID: 1442
		private global::System.Windows.Forms.Button btnAccept;

		// Token: 0x040005A3 RID: 1443
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040005A4 RID: 1444
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040005A6 RID: 1446
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040005A7 RID: 1447
		private global::System.Windows.Forms.Label labWarning;

		// Token: 0x040005A8 RID: 1448
		private global::System.Windows.Forms.ComboBox cboAccounts;

		// Token: 0x040005A9 RID: 1449
		private global::System.Windows.Forms.RadioButton optDeposit;

		// Token: 0x040005AA RID: 1450
		private global::System.Windows.Forms.RadioButton optCash;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005AB RID: 1451
		private global::System.ComponentModel.Container components = null;
	}
}
