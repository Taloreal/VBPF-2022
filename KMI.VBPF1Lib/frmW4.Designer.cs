namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmW4.
	/// </summary>
	// Token: 0x020000A1 RID: 161
	public partial class frmW4 : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060004ED RID: 1261 RVA: 0x0004643C File Offset: 0x0004543C
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
		// Token: 0x060004EE RID: 1262 RVA: 0x00046478 File Offset: 0x00045478
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KMI.VBPF1Lib.frmW4));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panMain = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtExempt = new global::System.Windows.Forms.TextBox();
			this.txtAdditional = new global::System.Windows.Forms.TextBox();
			this.txtAllowances = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.labSSN = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.labName = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panMain.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.btnHelp);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 598);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(632, 56);
			this.panel1.TabIndex = 0;
			this.btnHelp.Location = new global::System.Drawing.Point(396, 16);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(80, 24);
			this.btnHelp.TabIndex = 19;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(276, 16);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(156, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 17;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panMain.BackgroundImage = (global::System.Drawing.Image)resources.GetObject("panMain.BackgroundImage");
			this.panMain.Controls.Add(this.label3);
			this.panMain.Controls.Add(this.txtExempt);
			this.panMain.Controls.Add(this.txtAdditional);
			this.panMain.Controls.Add(this.txtAllowances);
			this.panMain.Controls.Add(this.label7);
			this.panMain.Controls.Add(this.label6);
			this.panMain.Controls.Add(this.label5);
			this.panMain.Controls.Add(this.label4);
			this.panMain.Controls.Add(this.labSSN);
			this.panMain.Controls.Add(this.label2);
			this.panMain.Controls.Add(this.label1);
			this.panMain.Controls.Add(this.labName);
			this.panMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panMain.Location = new global::System.Drawing.Point(0, 0);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(632, 598);
			this.panMain.TabIndex = 1;
			this.label3.BackColor = global::System.Drawing.Color.White;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(348, 376);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(8, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "X";
			this.txtExempt.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtExempt.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtExempt.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtExempt.Location = new global::System.Drawing.Point(496, 498);
			this.txtExempt.Name = "txtExempt";
			this.txtExempt.Size = new global::System.Drawing.Size(120, 11);
			this.txtExempt.TabIndex = 10;
			this.txtAdditional.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtAdditional.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtAdditional.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtAdditional.Location = new global::System.Drawing.Point(568, 443);
			this.txtAdditional.Name = "txtAdditional";
			this.txtAdditional.Size = new global::System.Drawing.Size(48, 11);
			this.txtAdditional.TabIndex = 9;
			this.txtAdditional.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.txtAllowances.BackColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtAllowances.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtAllowances.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtAllowances.Location = new global::System.Drawing.Point(568, 430);
			this.txtAllowances.Name = "txtAllowances";
			this.txtAllowances.Size = new global::System.Drawing.Size(48, 11);
			this.txtAllowances.TabIndex = 8;
			this.txtAllowances.Text = "1";
			this.txtAllowances.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.label7.BackColor = global::System.Drawing.Color.White;
			this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(440, 536);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(168, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "tt";
			this.label6.BackColor = global::System.Drawing.Color.White;
			this.label6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(120, 536);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(192, 12);
			this.label6.TabIndex = 6;
			this.label6.Text = "tt";
			this.label5.BackColor = global::System.Drawing.Color.White;
			this.label5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(48, 416);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(192, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "Springfield, USA";
			this.label4.BackColor = global::System.Drawing.Color.White;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(48, 384);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(192, 12);
			this.label4.TabIndex = 4;
			this.label4.Text = "123 Any Street";
			this.labSSN.BackColor = global::System.Drawing.Color.White;
			this.labSSN.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labSSN.Location = new global::System.Drawing.Point(544, 360);
			this.labSSN.Name = "labSSN";
			this.labSSN.Size = new global::System.Drawing.Size(32, 12);
			this.labSSN.TabIndex = 3;
			this.labSSN.Text = "0000";
			this.label2.BackColor = global::System.Drawing.Color.White;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(516, 360);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(20, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "XX";
			this.label1.BackColor = global::System.Drawing.Color.White;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(480, 360);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "XXX";
			this.labName.BackColor = global::System.Drawing.Color.White;
			this.labName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labName.Location = new global::System.Drawing.Point(272, 360);
			this.labName.Name = "labName";
			this.labName.Size = new global::System.Drawing.Size(192, 12);
			this.labName.TabIndex = 0;
			this.labName.Text = "tt";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(632, 654);
			base.Controls.Add(this.panMain);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmW4";
			base.ShowInTaskbar = false;
			this.Text = "Fill Out W4 Tax Form";
			base.Load += new global::System.EventHandler(this.frmW4_Load);
			this.panel1.ResumeLayout(false);
			this.panMain.ResumeLayout(false);
			this.panMain.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040005C8 RID: 1480
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005C9 RID: 1481
		private global::System.Windows.Forms.Panel panMain;

		// Token: 0x040005CA RID: 1482
		private global::System.Windows.Forms.Label labName;

		// Token: 0x040005CB RID: 1483
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005CC RID: 1484
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040005CD RID: 1485
		private global::System.Windows.Forms.Label labSSN;

		// Token: 0x040005CE RID: 1486
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040005CF RID: 1487
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040005D0 RID: 1488
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040005D1 RID: 1489
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040005D2 RID: 1490
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005D3 RID: 1491
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040005D4 RID: 1492
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040005D5 RID: 1493
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040005D6 RID: 1494
		private global::System.Windows.Forms.TextBox txtAllowances;

		// Token: 0x040005D7 RID: 1495
		private global::System.Windows.Forms.TextBox txtAdditional;

		// Token: 0x040005D8 RID: 1496
		private global::System.Windows.Forms.TextBox txtExempt;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040005D9 RID: 1497
		private global::System.ComponentModel.Container components = null;
	}
}
