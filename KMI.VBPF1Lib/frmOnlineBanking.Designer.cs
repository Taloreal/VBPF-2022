namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmOnlineBanking.
	/// </summary>
	// Token: 0x0200006C RID: 108
	public partial class frmOnlineBanking : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002CA RID: 714 RVA: 0x0002DBC0 File Offset: 0x0002CBC0
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
		// Token: 0x060002CB RID: 715 RVA: 0x0002DBFC File Offset: 0x0002CBFC
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cboURLs = new global::System.Windows.Forms.ComboBox();
			this.panHome = new global::System.Windows.Forms.Panel();
			this.panAccounts = new global::System.Windows.Forms.Panel();
			this.linkRecurring = new global::System.Windows.Forms.LinkLabel();
			this.labBankName = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.linkTransfer = new global::System.Windows.Forms.LinkLabel();
			this.linkPaybills = new global::System.Windows.Forms.LinkLabel();
			this.panAccountDetail = new global::System.Windows.Forms.Panel();
			this.labAccountNumber = new global::System.Windows.Forms.Label();
			this.labAccountBalance = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.panTransactions = new global::System.Windows.Forms.Panel();
			this.panPayBills = new global::System.Windows.Forms.Panel();
			this.cboPayAccount = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.btnSchedulePayments = new global::System.Windows.Forms.Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.linkBack2 = new global::System.Windows.Forms.LinkLabel();
			this.panPayees = new global::System.Windows.Forms.Panel();
			this.panTransfer = new global::System.Windows.Forms.Panel();
			this.labToBal = new global::System.Windows.Forms.Label();
			this.labFromBal = new global::System.Windows.Forms.Label();
			this.btnTransfer = new global::System.Windows.Forms.Button();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.label12 = new global::System.Windows.Forms.Label();
			this.cboTo = new global::System.Windows.Forms.ComboBox();
			this.cboFrom = new global::System.Windows.Forms.ComboBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.linkLabel2 = new global::System.Windows.Forms.LinkLabel();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panRecurring = new global::System.Windows.Forms.Panel();
			this.label18 = new global::System.Windows.Forms.Label();
			this.cboPayAccount2 = new global::System.Windows.Forms.ComboBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.btnDoneRecurring = new global::System.Windows.Forms.Button();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label17 = new global::System.Windows.Forms.Label();
			this.linkLabel3 = new global::System.Windows.Forms.LinkLabel();
			this.panPayees2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panHome.SuspendLayout();
			this.panAccountDetail.SuspendLayout();
			this.panPayBills.SuspendLayout();
			this.panTransfer.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			this.panRecurring.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cboURLs);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1000, 40);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new global::System.Drawing.Point(480, 8);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(48, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Go";
			this.button1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label1.Location = new global::System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(56, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Addresss";
			this.cboURLs.Location = new global::System.Drawing.Point(80, 8);
			this.cboURLs.Name = "cboURLs";
			this.cboURLs.Size = new global::System.Drawing.Size(384, 21);
			this.cboURLs.TabIndex = 0;
			this.cboURLs.SelectedIndexChanged += new global::System.EventHandler(this.cboURLs_SelectedIndexChanged);
			this.panHome.BackColor = global::System.Drawing.Color.White;
			this.panHome.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panHome.Controls.Add(this.panAccounts);
			this.panHome.Controls.Add(this.linkRecurring);
			this.panHome.Controls.Add(this.labBankName);
			this.panHome.Controls.Add(this.label3);
			this.panHome.Controls.Add(this.label2);
			this.panHome.Controls.Add(this.linkTransfer);
			this.panHome.Controls.Add(this.linkPaybills);
			this.panHome.Location = new global::System.Drawing.Point(0, 40);
			this.panHome.Name = "panHome";
			this.panHome.Size = new global::System.Drawing.Size(416, 288);
			this.panHome.TabIndex = 1;
			this.panAccounts.AutoScroll = true;
			this.panAccounts.Location = new global::System.Drawing.Point(24, 112);
			this.panAccounts.Name = "panAccounts";
			this.panAccounts.Size = new global::System.Drawing.Size(152, 200);
			this.panAccounts.TabIndex = 8;
			this.linkRecurring.Location = new global::System.Drawing.Point(16, 40);
			this.linkRecurring.Name = "linkRecurring";
			this.linkRecurring.Size = new global::System.Drawing.Size(120, 16);
			this.linkRecurring.TabIndex = 7;
			this.linkRecurring.TabStop = true;
			this.linkRecurring.Text = "Recurring Payments";
			this.linkRecurring.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecurring_LinkClicked);
			this.labBankName.Font = new global::System.Drawing.Font("Impact", 26.25f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labBankName.ForeColor = global::System.Drawing.Color.Silver;
			this.labBankName.Location = new global::System.Drawing.Point(184, 216);
			this.labBankName.Name = "labBankName";
			this.labBankName.Size = new global::System.Drawing.Size(344, 72);
			this.labBankName.TabIndex = 6;
			this.labBankName.Text = "label4";
			this.labBankName.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label3.Font = new global::System.Drawing.Font("Impact", 36f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.label3.Location = new global::System.Drawing.Point(184, 16);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(344, 192);
			this.label3.TabIndex = 5;
			this.label3.Text = "Welcome to Online Banking at";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label2.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Gray;
			this.label2.Location = new global::System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(152, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Account Details:";
			this.linkTransfer.Location = new global::System.Drawing.Point(16, 64);
			this.linkTransfer.Name = "linkTransfer";
			this.linkTransfer.Size = new global::System.Drawing.Size(96, 16);
			this.linkTransfer.TabIndex = 1;
			this.linkTransfer.TabStop = true;
			this.linkTransfer.Text = "Transfer Funds";
			this.linkTransfer.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTransfer_LinkClicked);
			this.linkPaybills.Location = new global::System.Drawing.Point(16, 16);
			this.linkPaybills.Name = "linkPaybills";
			this.linkPaybills.Size = new global::System.Drawing.Size(96, 16);
			this.linkPaybills.TabIndex = 0;
			this.linkPaybills.TabStop = true;
			this.linkPaybills.Text = "Pay Bills";
			this.linkPaybills.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPaybills_LinkClicked);
			this.panAccountDetail.AutoScroll = true;
			this.panAccountDetail.BackColor = global::System.Drawing.Color.White;
			this.panAccountDetail.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panAccountDetail.Controls.Add(this.labAccountNumber);
			this.panAccountDetail.Controls.Add(this.labAccountBalance);
			this.panAccountDetail.Controls.Add(this.label14);
			this.panAccountDetail.Controls.Add(this.label13);
			this.panAccountDetail.Controls.Add(this.linkLabel1);
			this.panAccountDetail.Controls.Add(this.panTransactions);
			this.panAccountDetail.Location = new global::System.Drawing.Point(432, 56);
			this.panAccountDetail.Name = "panAccountDetail";
			this.panAccountDetail.Size = new global::System.Drawing.Size(560, 168);
			this.panAccountDetail.TabIndex = 2;
			this.panAccountDetail.Visible = false;
			this.labAccountNumber.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labAccountNumber.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.labAccountNumber.Location = new global::System.Drawing.Point(304, 8);
			this.labAccountNumber.Name = "labAccountNumber";
			this.labAccountNumber.Size = new global::System.Drawing.Size(144, 22);
			this.labAccountNumber.TabIndex = 7;
			this.labAccountBalance.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labAccountBalance.ForeColor = global::System.Drawing.Color.Gray;
			this.labAccountBalance.Location = new global::System.Drawing.Point(264, 40);
			this.labAccountBalance.Name = "labAccountBalance";
			this.labAccountBalance.Size = new global::System.Drawing.Size(120, 16);
			this.labAccountBalance.TabIndex = 6;
			this.label14.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Gray;
			this.label14.Location = new global::System.Drawing.Point(144, 40);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(120, 16);
			this.label14.TabIndex = 10;
			this.label14.Text = "Current Balance: ";
			this.label13.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.label13.Location = new global::System.Drawing.Point(16, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(280, 22);
			this.label13.TabIndex = 9;
			this.label13.Text = "Account History for  Account Number";
			this.linkLabel1.Location = new global::System.Drawing.Point(456, 8);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(80, 16);
			this.linkLabel1.TabIndex = 8;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Back To Main";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack2_LinkClicked);
			this.panTransactions.Location = new global::System.Drawing.Point(24, 64);
			this.panTransactions.Name = "panTransactions";
			this.panTransactions.Size = new global::System.Drawing.Size(504, 112);
			this.panTransactions.TabIndex = 0;
			this.panTransactions.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panTransactions_Paint);
			this.panPayBills.AutoScroll = true;
			this.panPayBills.BackColor = global::System.Drawing.Color.White;
			this.panPayBills.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panPayBills.Controls.Add(this.cboPayAccount);
			this.panPayBills.Controls.Add(this.label8);
			this.panPayBills.Controls.Add(this.btnSchedulePayments);
			this.panPayBills.Controls.Add(this.label5);
			this.panPayBills.Controls.Add(this.label4);
			this.panPayBills.Controls.Add(this.linkBack2);
			this.panPayBills.Controls.Add(this.panPayees);
			this.panPayBills.Location = new global::System.Drawing.Point(432, 320);
			this.panPayBills.Name = "panPayBills";
			this.panPayBills.Size = new global::System.Drawing.Size(560, 144);
			this.panPayBills.TabIndex = 3;
			this.panPayBills.Visible = false;
			this.cboPayAccount.Location = new global::System.Drawing.Point(208, 8);
			this.cboPayAccount.Name = "cboPayAccount";
			this.cboPayAccount.Size = new global::System.Drawing.Size(168, 21);
			this.cboPayAccount.TabIndex = 14;
			this.label8.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.label8.Location = new global::System.Drawing.Point(16, 8);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(184, 22);
			this.label8.TabIndex = 13;
			this.label8.Text = "Pay Bills from Account";
			this.btnSchedulePayments.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnSchedulePayments.Location = new global::System.Drawing.Point(184, 112);
			this.btnSchedulePayments.Name = "btnSchedulePayments";
			this.btnSchedulePayments.Size = new global::System.Drawing.Size(176, 24);
			this.btnSchedulePayments.TabIndex = 12;
			this.btnSchedulePayments.Text = "Schedule Payments";
			this.btnSchedulePayments.Click += new global::System.EventHandler(this.btnSchedulePayments_Click);
			this.label5.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Gray;
			this.label5.Location = new global::System.Drawing.Point(280, 40);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(88, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "Amount";
			this.label4.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Gray;
			this.label4.Location = new global::System.Drawing.Point(64, 40);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(96, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Payee Name";
			this.linkBack2.Location = new global::System.Drawing.Point(456, 8);
			this.linkBack2.Name = "linkBack2";
			this.linkBack2.Size = new global::System.Drawing.Size(80, 16);
			this.linkBack2.TabIndex = 8;
			this.linkBack2.TabStop = true;
			this.linkBack2.Text = "Back To Main";
			this.linkBack2.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack2_LinkClicked);
			this.panPayees.Location = new global::System.Drawing.Point(56, 80);
			this.panPayees.Name = "panPayees";
			this.panPayees.Size = new global::System.Drawing.Size(384, 16);
			this.panPayees.TabIndex = 0;
			this.panTransfer.AutoScroll = true;
			this.panTransfer.BackColor = global::System.Drawing.Color.White;
			this.panTransfer.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panTransfer.Controls.Add(this.labToBal);
			this.panTransfer.Controls.Add(this.labFromBal);
			this.panTransfer.Controls.Add(this.btnTransfer);
			this.panTransfer.Controls.Add(this.updAmount);
			this.panTransfer.Controls.Add(this.label12);
			this.panTransfer.Controls.Add(this.cboTo);
			this.panTransfer.Controls.Add(this.cboFrom);
			this.panTransfer.Controls.Add(this.label10);
			this.panTransfer.Controls.Add(this.label11);
			this.panTransfer.Controls.Add(this.label9);
			this.panTransfer.Controls.Add(this.linkLabel2);
			this.panTransfer.Controls.Add(this.label6);
			this.panTransfer.Controls.Add(this.label7);
			this.panTransfer.Location = new global::System.Drawing.Point(432, 504);
			this.panTransfer.Name = "panTransfer";
			this.panTransfer.Size = new global::System.Drawing.Size(560, 200);
			this.panTransfer.TabIndex = 4;
			this.panTransfer.Visible = false;
			this.labToBal.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labToBal.ForeColor = global::System.Drawing.Color.Gray;
			this.labToBal.Location = new global::System.Drawing.Point(424, 88);
			this.labToBal.Name = "labToBal";
			this.labToBal.Size = new global::System.Drawing.Size(104, 16);
			this.labToBal.TabIndex = 18;
			this.labToBal.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labFromBal.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labFromBal.ForeColor = global::System.Drawing.Color.Gray;
			this.labFromBal.Location = new global::System.Drawing.Point(424, 56);
			this.labFromBal.Name = "labFromBal";
			this.labFromBal.Size = new global::System.Drawing.Size(104, 16);
			this.labFromBal.TabIndex = 17;
			this.labFromBal.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.btnTransfer.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnTransfer.Location = new global::System.Drawing.Point(200, 168);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new global::System.Drawing.Size(152, 24);
			this.btnTransfer.TabIndex = 16;
			this.btnTransfer.Text = "Perform Transfer";
			this.btnTransfer.Click += new global::System.EventHandler(this.btnTransfer_Click);
			this.updAmount.Location = new global::System.Drawing.Point(216, 128);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(112, 20);
			this.updAmount.TabIndex = 15;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updAmount.ThousandsSeparator = true;
			this.label12.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.Gray;
			this.label12.Location = new global::System.Drawing.Point(128, 128);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(72, 16);
			this.label12.TabIndex = 14;
			this.label12.Text = "Amount: ";
			this.cboTo.Location = new global::System.Drawing.Point(104, 88);
			this.cboTo.Name = "cboTo";
			this.cboTo.Size = new global::System.Drawing.Size(168, 21);
			this.cboTo.TabIndex = 13;
			this.cboTo.Text = "comboBox2";
			this.cboTo.SelectedIndexChanged += new global::System.EventHandler(this.cboTo_SelectedIndexChanged);
			this.cboFrom.Location = new global::System.Drawing.Point(104, 56);
			this.cboFrom.Name = "cboFrom";
			this.cboFrom.Size = new global::System.Drawing.Size(168, 21);
			this.cboFrom.TabIndex = 12;
			this.cboFrom.Text = "comboBox1";
			this.cboFrom.SelectedIndexChanged += new global::System.EventHandler(this.cboFrom_SelectedIndexChanged);
			this.label10.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Gray;
			this.label10.Location = new global::System.Drawing.Point(40, 88);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(48, 16);
			this.label10.TabIndex = 11;
			this.label10.Text = "To: ";
			this.label11.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Gray;
			this.label11.Location = new global::System.Drawing.Point(296, 88);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(120, 16);
			this.label11.TabIndex = 10;
			this.label11.Text = "Current Balance: ";
			this.label9.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Gray;
			this.label9.Location = new global::System.Drawing.Point(40, 56);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(48, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "From: ";
			this.linkLabel2.Location = new global::System.Drawing.Point(456, 8);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new global::System.Drawing.Size(80, 16);
			this.linkLabel2.TabIndex = 8;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Back To Main";
			this.linkLabel2.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack2_LinkClicked);
			this.label6.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.label6.Location = new global::System.Drawing.Point(16, 8);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(408, 22);
			this.label6.TabIndex = 7;
			this.label6.Text = "Transfer Funds";
			this.label7.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Gray;
			this.label7.Location = new global::System.Drawing.Point(296, 56);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(120, 16);
			this.label7.TabIndex = 6;
			this.label7.Text = "Current Balance: ";
			this.panRecurring.AutoScroll = true;
			this.panRecurring.BackColor = global::System.Drawing.Color.White;
			this.panRecurring.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panRecurring.Controls.Add(this.label18);
			this.panRecurring.Controls.Add(this.cboPayAccount2);
			this.panRecurring.Controls.Add(this.label15);
			this.panRecurring.Controls.Add(this.btnDoneRecurring);
			this.panRecurring.Controls.Add(this.label16);
			this.panRecurring.Controls.Add(this.label17);
			this.panRecurring.Controls.Add(this.linkLabel3);
			this.panRecurring.Controls.Add(this.panPayees2);
			this.panRecurring.Location = new global::System.Drawing.Point(16, 400);
			this.panRecurring.Name = "panRecurring";
			this.panRecurring.Size = new global::System.Drawing.Size(392, 312);
			this.panRecurring.TabIndex = 5;
			this.panRecurring.Visible = false;
			this.label18.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Gray;
			this.label18.Location = new global::System.Drawing.Point(412, 48);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(88, 32);
			this.label18.TabIndex = 15;
			this.label18.Text = "Day of Month to Pay";
			this.label18.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.cboPayAccount2.Location = new global::System.Drawing.Point(208, 24);
			this.cboPayAccount2.Name = "cboPayAccount2";
			this.cboPayAccount2.Size = new global::System.Drawing.Size(168, 21);
			this.cboPayAccount2.TabIndex = 14;
			this.cboPayAccount2.SelectedIndexChanged += new global::System.EventHandler(this.cboPayAccount2_SelectedIndexChanged);
			this.label15.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.label15.Location = new global::System.Drawing.Point(16, 8);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(184, 40);
			this.label15.TabIndex = 13;
			this.label15.Text = "Setup Recurring Monthly Payments from";
			this.btnDoneRecurring.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnDoneRecurring.Location = new global::System.Drawing.Point(184, 136);
			this.btnDoneRecurring.Name = "btnDoneRecurring";
			this.btnDoneRecurring.Size = new global::System.Drawing.Size(176, 24);
			this.btnDoneRecurring.TabIndex = 12;
			this.btnDoneRecurring.Text = "Done";
			this.btnDoneRecurring.Click += new global::System.EventHandler(this.btnDoneRecurring_Click);
			this.label16.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.ForeColor = global::System.Drawing.Color.Gray;
			this.label16.Location = new global::System.Drawing.Point(280, 64);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(88, 16);
			this.label16.TabIndex = 10;
			this.label16.Text = "Amount";
			this.label17.Font = new global::System.Drawing.Font("Franklin Gothic Medium", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.ForeColor = global::System.Drawing.Color.Gray;
			this.label17.Location = new global::System.Drawing.Point(64, 64);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(96, 16);
			this.label17.TabIndex = 9;
			this.label17.Text = "Payee Name";
			this.linkLabel3.Location = new global::System.Drawing.Point(456, 8);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new global::System.Drawing.Size(80, 16);
			this.linkLabel3.TabIndex = 8;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Back To Main";
			this.linkLabel3.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack2_LinkClicked);
			this.panPayees2.Location = new global::System.Drawing.Point(56, 104);
			this.panPayees2.Name = "panPayees2";
			this.panPayees2.Size = new global::System.Drawing.Size(456, 16);
			this.panPayees2.TabIndex = 0;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(1000, 742);
			base.Controls.Add(this.panHome);
			base.Controls.Add(this.panRecurring);
			base.Controls.Add(this.panTransfer);
			base.Controls.Add(this.panPayBills);
			base.Controls.Add(this.panAccountDetail);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmOnlineBanking";
			base.ShowInTaskbar = false;
			this.Text = "Online Banking";
			this.panel1.ResumeLayout(false);
			this.panHome.ResumeLayout(false);
			this.panAccountDetail.ResumeLayout(false);
			this.panPayBills.ResumeLayout(false);
			this.panTransfer.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			this.panRecurring.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400035A RID: 858
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400035B RID: 859
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400035C RID: 860
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400035D RID: 861
		private global::System.Windows.Forms.Panel panHome;

		// Token: 0x0400035E RID: 862
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400035F RID: 863
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000360 RID: 864
		private global::System.Windows.Forms.ComboBox cboURLs;

		// Token: 0x04000361 RID: 865
		private global::System.Windows.Forms.Label labBankName;

		// Token: 0x04000362 RID: 866
		private global::System.Windows.Forms.Panel panAccountDetail;

		// Token: 0x04000363 RID: 867
		private global::System.Windows.Forms.Panel panTransactions;

		// Token: 0x04000364 RID: 868
		private global::System.Windows.Forms.LinkLabel linkTransfer;

		// Token: 0x04000365 RID: 869
		private global::System.Windows.Forms.LinkLabel linkPaybills;

		// Token: 0x04000366 RID: 870
		private global::System.Windows.Forms.Label labAccountBalance;

		// Token: 0x04000367 RID: 871
		private global::System.Windows.Forms.Label labAccountNumber;

		// Token: 0x04000368 RID: 872
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x04000369 RID: 873
		private global::System.Windows.Forms.Panel panPayBills;

		// Token: 0x0400036A RID: 874
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400036B RID: 875
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.Panel panPayees;

		// Token: 0x0400036D RID: 877
		private global::System.Windows.Forms.Button btnSchedulePayments;

		// Token: 0x0400036E RID: 878
		private global::System.Windows.Forms.LinkLabel linkBack2;

		// Token: 0x0400036F RID: 879
		private global::System.Windows.Forms.LinkLabel linkLabel2;

		// Token: 0x04000370 RID: 880
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000371 RID: 881
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000372 RID: 882
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000373 RID: 883
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000374 RID: 884
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000375 RID: 885
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000376 RID: 886
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000377 RID: 887
		private global::System.Windows.Forms.Button btnTransfer;

		// Token: 0x04000378 RID: 888
		private global::System.Windows.Forms.Label labToBal;

		// Token: 0x04000379 RID: 889
		private global::System.Windows.Forms.Label labFromBal;

		// Token: 0x0400037A RID: 890
		private global::System.Windows.Forms.ComboBox cboFrom;

		// Token: 0x0400037B RID: 891
		private global::System.Windows.Forms.ComboBox cboTo;

		// Token: 0x0400037C RID: 892
		private global::System.Windows.Forms.ComboBox cboPayAccount;

		// Token: 0x0400037D RID: 893
		private global::System.Windows.Forms.Panel panTransfer;

		// Token: 0x0400037E RID: 894
		private global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x0400037F RID: 895
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000380 RID: 896
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000381 RID: 897
		private global::System.Windows.Forms.LinkLabel linkRecurring;

		// Token: 0x04000382 RID: 898
		private global::System.Windows.Forms.Panel panRecurring;

		// Token: 0x04000383 RID: 899
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000384 RID: 900
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000385 RID: 901
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000386 RID: 902
		private global::System.Windows.Forms.LinkLabel linkLabel3;

		// Token: 0x04000387 RID: 903
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000388 RID: 904
		private global::System.Windows.Forms.ComboBox cboPayAccount2;

		// Token: 0x04000389 RID: 905
		private global::System.Windows.Forms.Button btnDoneRecurring;

		// Token: 0x0400038A RID: 906
		private global::System.Windows.Forms.Panel panPayees2;

		// Token: 0x0400038B RID: 907
		private global::System.Windows.Forms.Panel panAccounts;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400038C RID: 908
		private global::System.ComponentModel.Container components = null;
	}
}
