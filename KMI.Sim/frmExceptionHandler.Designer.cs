namespace KMI.Sim
{
	// Token: 0x0200004E RID: 78
	public partial class frmExceptionHandler : global::System.Windows.Forms.Form
	{
		// Token: 0x060002CC RID: 716 RVA: 0x00016118 File Offset: 0x00015118
		private void InitializeComponent()
		{
			this.errorTextTextBox = new global::System.Windows.Forms.TextBox();
			this.doneButton = new global::System.Windows.Forms.Button();
			this.reportButton = new global::System.Windows.Forms.Button();
			this.errorMessageTextBox = new global::System.Windows.Forms.TextBox();
			this.txtSchool = new global::System.Windows.Forms.TextBox();
			this.cdKeyLabel = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.errorTextTextBox.AcceptsReturn = true;
			this.errorTextTextBox.AcceptsTab = true;
			this.errorTextTextBox.Location = new global::System.Drawing.Point(16, 184);
			this.errorTextTextBox.Multiline = true;
			this.errorTextTextBox.Name = "errorTextTextBox";
			this.errorTextTextBox.ReadOnly = true;
			this.errorTextTextBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.errorTextTextBox.Size = new global::System.Drawing.Size(448, 112);
			this.errorTextTextBox.TabIndex = 3;
			this.errorTextTextBox.Text = "#error text";
			this.doneButton.Location = new global::System.Drawing.Point(384, 312);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new global::System.Drawing.Size(80, 24);
			this.doneButton.TabIndex = 5;
			this.doneButton.Text = "#text";
			this.doneButton.Click += new global::System.EventHandler(this.doneButton_Click);
			this.reportButton.Location = new global::System.Drawing.Point(288, 312);
			this.reportButton.Name = "reportButton";
			this.reportButton.Size = new global::System.Drawing.Size(80, 24);
			this.reportButton.TabIndex = 4;
			this.reportButton.Text = "Report";
			this.reportButton.Visible = false;
			this.reportButton.Click += new global::System.EventHandler(this.reportButton_Click);
			this.errorMessageTextBox.AcceptsReturn = true;
			this.errorMessageTextBox.AcceptsTab = true;
			this.errorMessageTextBox.Location = new global::System.Drawing.Point(16, 56);
			this.errorMessageTextBox.Multiline = true;
			this.errorMessageTextBox.Name = "errorMessageTextBox";
			this.errorMessageTextBox.ReadOnly = true;
			this.errorMessageTextBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.errorMessageTextBox.Size = new global::System.Drawing.Size(448, 112);
			this.errorMessageTextBox.TabIndex = 2;
			this.errorMessageTextBox.Text = "#error message";
			this.txtSchool.Location = new global::System.Drawing.Point(96, 16);
			this.txtSchool.MaxLength = 128;
			this.txtSchool.Name = "txtSchool";
			this.txtSchool.Size = new global::System.Drawing.Size(368, 20);
			this.txtSchool.TabIndex = 1;
			this.txtSchool.Text = "";
			this.cdKeyLabel.Location = new global::System.Drawing.Point(16, 16);
			this.cdKeyLabel.Name = "cdKeyLabel";
			this.cdKeyLabel.Size = new global::System.Drawing.Size(80, 24);
			this.cdKeyLabel.TabIndex = 0;
			this.cdKeyLabel.Text = "School:";
			this.cdKeyLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(482, 352);
			base.Controls.Add(this.txtSchool);
			base.Controls.Add(this.errorMessageTextBox);
			base.Controls.Add(this.errorTextTextBox);
			base.Controls.Add(this.cdKeyLabel);
			base.Controls.Add(this.reportButton);
			base.Controls.Add(this.doneButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmExceptionHandler";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ExceptionHandler";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmExceptionHandler_Closing);
			base.Load += new global::System.EventHandler(this.ExceptionHandler_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00016584 File Offset: 0x00015584
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

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.TextBox txtSchool;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.TextBox errorTextTextBox;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.TextBox errorMessageTextBox;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.Button doneButton;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.Button reportButton;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.Label cdKeyLabel;

		// Token: 0x040001C9 RID: 457
		private global::System.ComponentModel.Container components = null;
	}
}
