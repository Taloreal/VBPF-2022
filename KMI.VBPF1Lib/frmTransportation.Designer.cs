namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmTransportation.
	/// </summary>
	// Token: 0x02000019 RID: 25
	public partial class frmTransportation : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600008C RID: 140 RVA: 0x00009974 File Offset: 0x00008974
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
		// Token: 0x0600008D RID: 141 RVA: 0x000099B0 File Offset: 0x000089B0
		private void InitializeComponent()
		{
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.radioButton1 = new global::System.Windows.Forms.RadioButton();
			this.grpMain = new global::System.Windows.Forms.GroupBox();
			this.panMain = new global::System.Windows.Forms.Panel();
			this.radioButton2 = new global::System.Windows.Forms.RadioButton();
			this.radioButton3 = new global::System.Windows.Forms.RadioButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.grpMain.SuspendLayout();
			this.panMain.SuspendLayout();
			base.SuspendLayout();
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new global::System.Drawing.Point(152, 244);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(70, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.button3_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(244, 244);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(68, 24);
			this.btnHelp.TabIndex = 10;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnOK.Enabled = false;
			this.btnOK.Location = new global::System.Drawing.Point(64, 244);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(68, 24);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.radioButton1.Location = new global::System.Drawing.Point(8, 4);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new global::System.Drawing.Size(48, 28);
			this.radioButton1.TabIndex = 14;
			this.radioButton1.Text = "Foot";
			this.radioButton1.CheckedChanged += new global::System.EventHandler(this.radioButton1_CheckedChanged);
			this.grpMain.Controls.Add(this.panMain);
			this.grpMain.Controls.Add(this.label3);
			this.grpMain.Controls.Add(this.label2);
			this.grpMain.Controls.Add(this.label1);
			this.grpMain.Location = new global::System.Drawing.Point(16, 16);
			this.grpMain.Name = "grpMain";
			this.grpMain.Size = new global::System.Drawing.Size(348, 208);
			this.grpMain.TabIndex = 13;
			this.grpMain.TabStop = false;
			this.grpMain.Text = "Travel By";
			this.panMain.Controls.Add(this.radioButton1);
			this.panMain.Controls.Add(this.radioButton2);
			this.panMain.Controls.Add(this.radioButton3);
			this.panMain.Location = new global::System.Drawing.Point(24, 16);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(64, 164);
			this.panMain.TabIndex = 18;
			this.radioButton2.Location = new global::System.Drawing.Point(8, 60);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new global::System.Drawing.Size(48, 28);
			this.radioButton2.TabIndex = 13;
			this.radioButton2.Text = "Bus";
			this.radioButton2.CheckedChanged += new global::System.EventHandler(this.radioButton1_CheckedChanged);
			this.radioButton3.Location = new global::System.Drawing.Point(8, 116);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new global::System.Drawing.Size(48, 28);
			this.radioButton3.TabIndex = 12;
			this.radioButton3.Text = "Car";
			this.radioButton3.CheckedChanged += new global::System.EventHandler(this.radioButton1_CheckedChanged);
			this.label3.Location = new global::System.Drawing.Point(92, 124);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(236, 52);
			this.label3.TabIndex = 17;
			this.label3.Text = "You must lease or buy a car. Other expenses include insurance, gas, and repairs. If your car is out of gas or broken down, you will automatically walk instead.";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new global::System.Drawing.Point(92, 68);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(236, 44);
			this.label2.TabIndex = 16;
			this.label2.Text = "Bus tokens are $1 per ride and can be purchased at any bus stop. If walking is faster, you will automatically walk instead.";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new global::System.Drawing.Point(92, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(236, 36);
			this.label1.TabIndex = 15;
			this.label1.Text = "This option is free.";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(380, 282);
			base.Controls.Add(this.grpMain);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTransportation";
			base.ShowInTaskbar = false;
			this.Text = "Transportation";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmTransportation_Closing);
			this.grpMain.ResumeLayout(false);
			this.panMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.RadioButton radioButton1;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.RadioButton radioButton2;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.RadioButton radioButton3;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.GroupBox grpMain;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.Panel panMain;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000E6 RID: 230
		private global::System.ComponentModel.Container components = null;
	}
}
