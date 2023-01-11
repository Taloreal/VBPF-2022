namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmSelectCard.
	/// </summary>
	// Token: 0x02000084 RID: 132
	public partial class frmSelectCard : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600041B RID: 1051 RVA: 0x00037EE0 File Offset: 0x00036EE0
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
		// Token: 0x0600041C RID: 1052 RVA: 0x00037F1C File Offset: 0x00036F1C
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panCards = new global::System.Windows.Forms.Panel();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnHelp);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 226);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(548, 40);
			this.panel1.TabIndex = 0;
			this.btnCancel.Location = new global::System.Drawing.Point(226, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click_1);
			this.btnHelp.Location = new global::System.Drawing.Point(346, 8);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 10;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnOK.Location = new global::System.Drawing.Point(106, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panCards.AutoScroll = true;
			this.panCards.Location = new global::System.Drawing.Point(0, 0);
			this.panCards.Name = "panCards";
			this.panCards.Size = new global::System.Drawing.Size(548, 172);
			this.panCards.TabIndex = 1;
			this.updAmount.DecimalPlaces = 2;
			this.updAmount.Location = new global::System.Drawing.Point(256, 188);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 1000000;
			numericUpDown.Maximum = new decimal(array);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(96, 20);
			this.updAmount.TabIndex = 10;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updAmount;
			array = new int[4];
			array[0] = 20;
			numericUpDown2.Value = new decimal(array);
			this.label2.Location = new global::System.Drawing.Point(156, 192);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(96, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Amount to Pay:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(548, 266);
			base.Controls.Add(this.updAmount);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.panCards);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmSelectCard";
			base.ShowInTaskbar = false;
			this.Text = "Select Card";
			base.Load += new global::System.EventHandler(this.frmSelectCard_Load);
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400048A RID: 1162
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.Panel panCards;

		// Token: 0x0400048C RID: 1164
		public global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x0400048D RID: 1165
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400048E RID: 1166
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400048F RID: 1167
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000490 RID: 1168
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000491 RID: 1169
		private global::System.ComponentModel.Container components = null;
	}
}
