namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmCheckbook.
	/// </summary>
	// Token: 0x02000051 RID: 81
	public partial class frmCheckbook : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600022D RID: 557 RVA: 0x00023CEC File Offset: 0x00022CEC
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
		// Token: 0x0600022E RID: 558 RVA: 0x00023D28 File Offset: 0x00022D28
		private void InitializeComponent()
		{
			this.panRegister = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label21 = new global::System.Windows.Forms.Label();
			this.cboAccount = new global::System.Windows.Forms.ComboBox();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnSendCheck = new global::System.Windows.Forms.Button();
			this.label9 = new global::System.Windows.Forms.Label();
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panRegister.AutoScroll = true;
			this.panRegister.Location = new global::System.Drawing.Point(0, 40);
			this.panRegister.Name = "panRegister";
			this.panRegister.Size = new global::System.Drawing.Size(632, 160);
			this.panRegister.TabIndex = 0;
			this.label1.BackColor = global::System.Drawing.Color.White;
			this.label1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(48, 32);
			this.label1.TabIndex = 2;
			this.label1.Text = "NUMBER";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.BackColor = global::System.Drawing.Color.White;
			this.label2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(48, 8);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(40, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "DATE";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.BackColor = global::System.Drawing.Color.White;
			this.label3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(96, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(168, 32);
			this.label3.TabIndex = 4;
			this.label3.Text = "DESCRIPTION OF TRANSACTION";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.BackColor = global::System.Drawing.Color.White;
			this.label4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(272, 8);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(88, 32);
			this.label4.TabIndex = 5;
			this.label4.Text = "PAYMENT/DEBIT (-)";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label5.BackColor = global::System.Drawing.Color.White;
			this.label5.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(360, 8);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(24, 32);
			this.label5.TabIndex = 6;
			this.label5.Text = "T";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label6.BackColor = global::System.Drawing.Color.White;
			this.label6.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(384, 8);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(40, 32);
			this.label6.TabIndex = 7;
			this.label6.Text = "FEE       (-)";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label7.BackColor = global::System.Drawing.Color.White;
			this.label7.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(432, 8);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(88, 32);
			this.label7.TabIndex = 8;
			this.label7.Text = "DEPOSIT/CREDIT (+)";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label8.BackColor = global::System.Drawing.Color.White;
			this.label8.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Font = new global::System.Drawing.Font("Arial", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(528, 8);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(88, 32);
			this.label8.TabIndex = 9;
			this.label8.Text = "BALANCE";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel1.BackColor = global::System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.cboAccount);
			this.panel1.Controls.Add(this.btnHelp);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnSendCheck);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 398);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(632, 40);
			this.panel1.TabIndex = 10;
			this.label21.Location = new global::System.Drawing.Point(16, 12);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(48, 16);
			this.label21.TabIndex = 4;
			this.label21.Text = "Account:";
			this.label21.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.cboAccount.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccount.Location = new global::System.Drawing.Point(64, 8);
			this.cboAccount.Name = "cboAccount";
			this.cboAccount.Size = new global::System.Drawing.Size(176, 21);
			this.cboAccount.TabIndex = 3;
			this.cboAccount.SelectedIndexChanged += new global::System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.btnHelp.Location = new global::System.Drawing.Point(544, 7);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(72, 24);
			this.btnHelp.TabIndex = 2;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnClose.Location = new global::System.Drawing.Point(464, 7);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnSendCheck.Enabled = false;
			this.btnSendCheck.Location = new global::System.Drawing.Point(264, 8);
			this.btnSendCheck.Name = "btnSendCheck";
			this.btnSendCheck.Size = new global::System.Drawing.Size(88, 24);
			this.btnSendCheck.TabIndex = 0;
			this.btnSendCheck.Text = "Send Check";
			this.btnSendCheck.Click += new global::System.EventHandler(this.btnSendCheck_Click);
			this.label9.BackColor = global::System.Drawing.Color.Black;
			this.label9.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label9.Location = new global::System.Drawing.Point(0, 200);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(632, 3);
			this.label9.TabIndex = 11;
			this.btnPrint.Location = new global::System.Drawing.Point(384, 8);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(72, 24);
			this.btnPrint.TabIndex = 5;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.btnPrint_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(632, 438);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panRegister);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmCheckbook";
			base.ShowInTaskbar = false;
			this.Text = "Checkbook";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmCheckbook_Closing);
			base.Load += new global::System.EventHandler(this.frmCheckbook_Load);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.Panel panRegister;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400028B RID: 651
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400028D RID: 653
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.Button btnSendCheck;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.Label label21;

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.ComboBox cboAccount;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.Button btnPrint;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000294 RID: 660
		private global::System.ComponentModel.Container components = null;
	}
}
