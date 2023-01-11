namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmChangeTask.
	/// </summary>
	// Token: 0x02000078 RID: 120
	public partial class frmChangeTask : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600030A RID: 778 RVA: 0x00033C64 File Offset: 0x00032C64
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
		// Token: 0x0600030B RID: 779 RVA: 0x00033CA0 File Offset: 0x00032CA0
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resources = new global::System.Resources.ResourceManager(typeof(global::KMI.VBPF1Lib.frmChangeTask));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cboEnd = new global::System.Windows.Forms.ListBox();
			this.cboStart = new global::System.Windows.Forms.ListBox();
			this.btnQuit = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lnkWitholding = new global::System.Windows.Forms.LinkLabel();
			this.lnkPayment = new global::System.Windows.Forms.LinkLabel();
			this.lnk401K = new global::System.Windows.Forms.LinkLabel();
			this.panWorkTask = new global::System.Windows.Forms.Panel();
			this.labMedical = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.panWorkTask.SuspendLayout();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Time:";
			this.label2.Location = new global::System.Drawing.Point(120, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "End Time:";
			this.groupBox1.Controls.Add(this.cboEnd);
			this.groupBox1.Controls.Add(this.cboStart);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(208, 256);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Time";
			this.cboEnd.Location = new global::System.Drawing.Point(120, 32);
			this.cboEnd.Name = "cboEnd";
			this.cboEnd.Size = new global::System.Drawing.Size(72, 212);
			this.cboEnd.TabIndex = 4;
			this.cboStart.Location = new global::System.Drawing.Point(16, 32);
			this.cboStart.Name = "cboStart";
			this.cboStart.Size = new global::System.Drawing.Size(72, 212);
			this.cboStart.TabIndex = 3;
			this.btnQuit.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnQuit.Location = new global::System.Drawing.Point(48, 280);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new global::System.Drawing.Size(136, 24);
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "Stop Doing This Activity";
			this.btnQuit.Click += new global::System.EventHandler(this.btnQuit_Click);
			this.btnOK.Location = new global::System.Drawing.Point(32, 352);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(48, 24);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(96, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(48, 24);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(160, 352);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(48, 24);
			this.btnHelp.TabIndex = 9;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label3.Location = new global::System.Drawing.Point(0, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(48, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Change:";
			this.lnkWitholding.Location = new global::System.Drawing.Point(56, 8);
			this.lnkWitholding.Name = "lnkWitholding";
			this.lnkWitholding.Size = new global::System.Drawing.Size(64, 16);
			this.lnkWitholding.TabIndex = 11;
			this.lnkWitholding.TabStop = true;
			this.lnkWitholding.Text = "Withholding";
			this.lnkWitholding.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWitholding_LinkClicked);
			this.lnkPayment.Location = new global::System.Drawing.Point(120, 8);
			this.lnkPayment.Name = "lnkPayment";
			this.lnkPayment.Size = new global::System.Drawing.Size(56, 16);
			this.lnkPayment.TabIndex = 12;
			this.lnkPayment.TabStop = true;
			this.lnkPayment.Text = "Payment";
			this.lnkPayment.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPayment_LinkClicked);
			this.lnk401K.Location = new global::System.Drawing.Point(176, 8);
			this.lnk401K.Name = "lnk401K";
			this.lnk401K.Size = new global::System.Drawing.Size(32, 16);
			this.lnk401K.TabIndex = 13;
			this.lnk401K.TabStop = true;
			this.lnk401K.Text = "401K";
			this.lnk401K.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk401K_LinkClicked);
			this.panWorkTask.Controls.Add(this.lnkWitholding);
			this.panWorkTask.Controls.Add(this.lnkPayment);
			this.panWorkTask.Controls.Add(this.lnk401K);
			this.panWorkTask.Controls.Add(this.label3);
			this.panWorkTask.Location = new global::System.Drawing.Point(8, 312);
			this.panWorkTask.Name = "panWorkTask";
			this.panWorkTask.Size = new global::System.Drawing.Size(224, 32);
			this.panWorkTask.TabIndex = 14;
			this.panWorkTask.Visible = false;
			this.labMedical.Image = (global::System.Drawing.Image)resources.GetObject("labMedical.Image");
			this.labMedical.Location = new global::System.Drawing.Point(192, 276);
			this.labMedical.Name = "labMedical";
			this.labMedical.Size = new global::System.Drawing.Size(32, 32);
			this.labMedical.TabIndex = 15;
			this.labMedical.Visible = false;
			this.labMedical.Click += new global::System.EventHandler(this.labMedical_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(240, 382);
			base.Controls.Add(this.labMedical);
			base.Controls.Add(this.panWorkTask);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmChangeTask";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change Activity";
			this.groupBox1.ResumeLayout(false);
			this.panWorkTask.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040003DE RID: 990
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003DF RID: 991
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040003E0 RID: 992
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040003E1 RID: 993
		private global::System.Windows.Forms.Button btnQuit;

		// Token: 0x040003E2 RID: 994
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040003E3 RID: 995
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040003E4 RID: 996
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040003E5 RID: 997
		private global::System.Windows.Forms.ListBox cboStart;

		// Token: 0x040003E6 RID: 998
		private global::System.Windows.Forms.ListBox cboEnd;

		// Token: 0x040003E7 RID: 999
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040003E8 RID: 1000
		private global::System.Windows.Forms.Panel panWorkTask;

		// Token: 0x040003E9 RID: 1001
		private global::System.Windows.Forms.LinkLabel lnkWitholding;

		// Token: 0x040003EA RID: 1002
		private global::System.Windows.Forms.LinkLabel lnkPayment;

		// Token: 0x040003EB RID: 1003
		private global::System.Windows.Forms.LinkLabel lnk401K;

		// Token: 0x040003EC RID: 1004
		private global::System.Windows.Forms.Label labMedical;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040003ED RID: 1005
		private global::System.ComponentModel.Container components = null;
	}
}
