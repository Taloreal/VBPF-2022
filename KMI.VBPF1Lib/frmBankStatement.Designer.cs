namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmBankStatement.
	/// </summary>
	// Token: 0x02000030 RID: 48
	public partial class frmBankStatement : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000183 RID: 387 RVA: 0x000197D8 File Offset: 0x000187D8
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
		// Token: 0x06000184 RID: 388 RVA: 0x00019814 File Offset: 0x00018814
		private void InitializeComponent()
		{
			this.btnPrint = new global::System.Windows.Forms.Button();
			this.picStatement = new global::System.Windows.Forms.PictureBox();
			this.btnPageNext = new global::System.Windows.Forms.Button();
			this.btnPageBack = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnMonthBack = new global::System.Windows.Forms.Button();
			this.btnMonthNext = new global::System.Windows.Forms.Button();
			this.lstAccount = new global::System.Windows.Forms.ListBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labNoAccounts = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.btnPrint.Location = new global::System.Drawing.Point(384, 384);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new global::System.Drawing.Size(72, 24);
			this.btnPrint.TabIndex = 1;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new global::System.EventHandler(this.button1_Click);
			this.picStatement.BackColor = global::System.Drawing.Color.White;
			this.picStatement.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.picStatement.Location = new global::System.Drawing.Point(0, 0);
			this.picStatement.Name = "picStatement";
			this.picStatement.Size = new global::System.Drawing.Size(360, 464);
			this.picStatement.TabIndex = 2;
			this.picStatement.TabStop = false;
			this.picStatement.Visible = false;
			this.picStatement.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picStatement_Paint);
			this.btnPageNext.Location = new global::System.Drawing.Point(424, 320);
			this.btnPageNext.Name = "btnPageNext";
			this.btnPageNext.Size = new global::System.Drawing.Size(32, 24);
			this.btnPageNext.TabIndex = 3;
			this.btnPageNext.Text = ">>";
			this.btnPageNext.Click += new global::System.EventHandler(this.btnPageNext_Click);
			this.btnPageBack.Location = new global::System.Drawing.Point(384, 320);
			this.btnPageBack.Name = "btnPageBack";
			this.btnPageBack.Size = new global::System.Drawing.Size(32, 24);
			this.btnPageBack.TabIndex = 4;
			this.btnPageBack.Text = "<<";
			this.btnPageBack.Click += new global::System.EventHandler(this.btnPageBack_Click);
			this.label1.Location = new global::System.Drawing.Point(384, 296);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Page:";
			this.label2.Location = new global::System.Drawing.Point(384, 200);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Month:";
			this.btnMonthBack.Location = new global::System.Drawing.Point(384, 224);
			this.btnMonthBack.Name = "btnMonthBack";
			this.btnMonthBack.Size = new global::System.Drawing.Size(32, 24);
			this.btnMonthBack.TabIndex = 7;
			this.btnMonthBack.Text = "<<";
			this.btnMonthBack.Click += new global::System.EventHandler(this.btnMonthBack_Click);
			this.btnMonthNext.Location = new global::System.Drawing.Point(424, 224);
			this.btnMonthNext.Name = "btnMonthNext";
			this.btnMonthNext.Size = new global::System.Drawing.Size(32, 24);
			this.btnMonthNext.TabIndex = 6;
			this.btnMonthNext.Text = ">>";
			this.btnMonthNext.Click += new global::System.EventHandler(this.btnMonthForward_Click);
			this.lstAccount.HorizontalScrollbar = true;
			this.lstAccount.Location = new global::System.Drawing.Point(376, 40);
			this.lstAccount.Name = "lstAccount";
			this.lstAccount.Size = new global::System.Drawing.Size(88, 121);
			this.lstAccount.TabIndex = 9;
			this.lstAccount.SelectedIndexChanged += new global::System.EventHandler(this.lstAccount_SelectedIndexChanged);
			this.label3.Location = new global::System.Drawing.Point(376, 24);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(88, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Account:";
			this.labNoAccounts.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labNoAccounts.Location = new global::System.Drawing.Point(80, 192);
			this.labNoAccounts.Name = "labNoAccounts";
			this.labNoAccounts.Size = new global::System.Drawing.Size(200, 32);
			this.labNoAccounts.TabIndex = 11;
			this.labNoAccounts.Text = "No Accounts Open";
			this.btnHelp.Location = new global::System.Drawing.Point(384, 424);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(72, 24);
			this.btnHelp.TabIndex = 12;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(482, 464);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lstAccount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnMonthBack);
			base.Controls.Add(this.btnMonthNext);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnPageBack);
			base.Controls.Add(this.btnPageNext);
			base.Controls.Add(this.picStatement);
			base.Controls.Add(this.btnPrint);
			base.Controls.Add(this.labNoAccounts);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmBankStatement";
			base.ShowInTaskbar = false;
			this.Text = "Bank Statements";
			base.ResumeLayout(false);
		}

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.Button btnPrint;

		// Token: 0x0400018D RID: 397
		protected global::System.Windows.Forms.PictureBox picStatement;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.Button btnPageNext;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.Button btnPageBack;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.Button btnMonthBack;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.ListBox lstAccount;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.Button btnMonthNext;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.Label labNoAccounts;

		// Token: 0x04000197 RID: 407
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000198 RID: 408
		private global::System.ComponentModel.Container components = null;
	}
}
