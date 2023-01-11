namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayBy.
	/// </summary>
	// Token: 0x02000068 RID: 104
	public partial class frmPayBy : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002A8 RID: 680 RVA: 0x0002B908 File Offset: 0x0002A908
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
		// Token: 0x060002A9 RID: 681 RVA: 0x0002B944 File Offset: 0x0002A944
		private void InitializeComponent()
		{
			this.btnCheck = new global::System.Windows.Forms.Button();
			this.btnCreditCard = new global::System.Windows.Forms.Button();
			this.btnDebitCard = new global::System.Windows.Forms.Button();
			this.btnCash = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.btnCheck.Location = new global::System.Drawing.Point(40, 28);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new global::System.Drawing.Size(128, 28);
			this.btnCheck.TabIndex = 0;
			this.btnCheck.Text = "Check";
			this.btnCheck.Click += new global::System.EventHandler(this.button1_Click);
			this.btnCreditCard.Location = new global::System.Drawing.Point(40, 72);
			this.btnCreditCard.Name = "btnCreditCard";
			this.btnCreditCard.Size = new global::System.Drawing.Size(128, 28);
			this.btnCreditCard.TabIndex = 1;
			this.btnCreditCard.Text = "Credit Card";
			this.btnCreditCard.Click += new global::System.EventHandler(this.btnCreditCard_Click);
			this.btnDebitCard.Location = new global::System.Drawing.Point(40, 120);
			this.btnDebitCard.Name = "btnDebitCard";
			this.btnDebitCard.Size = new global::System.Drawing.Size(128, 28);
			this.btnDebitCard.TabIndex = 2;
			this.btnDebitCard.Text = "Debit Card";
			this.btnDebitCard.Click += new global::System.EventHandler(this.btnDebitCard_Click);
			this.btnCash.Location = new global::System.Drawing.Point(40, 164);
			this.btnCash.Name = "btnCash";
			this.btnCash.Size = new global::System.Drawing.Size(128, 28);
			this.btnCash.TabIndex = 3;
			this.btnCash.Text = "Cash";
			this.btnCash.Click += new global::System.EventHandler(this.btnCash_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(136, 220);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(64, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.button5_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(212, 254);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnCash);
			base.Controls.Add(this.btnDebitCard);
			base.Controls.Add(this.btnCreditCard);
			base.Controls.Add(this.btnCheck);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPayBy";
			base.ShowInTaskbar = false;
			this.Text = "Pay By";
			base.ResumeLayout(false);
		}

		// Token: 0x0400032E RID: 814
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400032F RID: 815
		private global::System.Windows.Forms.Button btnCheck;

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.Button btnCreditCard;

		// Token: 0x04000331 RID: 817
		private global::System.Windows.Forms.Button btnDebitCard;

		// Token: 0x04000332 RID: 818
		private global::System.Windows.Forms.Button btnCash;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000333 RID: 819
		private global::System.ComponentModel.Container components = null;
	}
}
