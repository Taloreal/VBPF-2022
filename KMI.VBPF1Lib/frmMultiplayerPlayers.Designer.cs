namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmMultiplayerPlayers.
	/// </summary>
	// Token: 0x02000077 RID: 119
	public partial class frmMultiplayerPlayers : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000305 RID: 773 RVA: 0x00033788 File Offset: 0x00032788
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
		// Token: 0x06000306 RID: 774 RVA: 0x000337C4 File Offset: 0x000327C4
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.updPlayers = new global::System.Windows.Forms.NumericUpDown();
			((global::System.ComponentModel.ISupportInitialize)this.updPlayers).BeginInit();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(72, 116);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(136, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Continue";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label1.Location = new global::System.Drawing.Point(48, 32);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(192, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Approximately how many students will participate in this session?";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.updPlayers.Location = new global::System.Drawing.Point(112, 76);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updPlayers;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updPlayers;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Minimum = new decimal(array);
			this.updPlayers.Name = "updPlayers";
			this.updPlayers.Size = new global::System.Drawing.Size(60, 20);
			this.updPlayers.TabIndex = 2;
			this.updPlayers.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.updPlayers;
			array = new int[4];
			array[0] = 5;
			numericUpDown3.Value = new decimal(array);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(280, 160);
			base.Controls.Add(this.updPlayers);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmMultiplayerPlayers";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Students in Session";
			base.Closed += new global::System.EventHandler(this.frmMultiplayerPlayers_Closed);
			((global::System.ComponentModel.ISupportInitialize)this.updPlayers).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040003D9 RID: 985
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040003DA RID: 986
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003DB RID: 987
		private global::System.Windows.Forms.NumericUpDown updPlayers;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040003DC RID: 988
		private global::System.ComponentModel.Container components = null;
	}
}
