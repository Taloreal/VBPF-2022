using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for Classified.
	/// </summary>
	// Token: 0x0200001D RID: 29
	public class Classified : UserControl
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000B87C File Offset: 0x0000A87C
		public Classified()
		{
			this.InitializeComponent();
			if (Classified.SFTW == null)
			{
				Classified.SFTW = new StringFormat();
				Classified.SFTW.Trimming = StringTrimming.Word;
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060000A1 RID: 161 RVA: 0x0000B8C8 File Offset: 0x0000A8C8
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
		// Token: 0x060000A2 RID: 162 RVA: 0x0000B904 File Offset: 0x0000A904
		private void InitializeComponent()
		{
			this.labText = new Label();
			this.opt = new RadioButton();
			base.SuspendLayout();
			this.labText.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labText.Location = new Point(32, 8);
			this.labText.Name = "labText";
			this.labText.Size = new Size(152, 32);
			this.labText.TabIndex = 0;
			this.labText.Text = "labText";
			this.labText.TextChanged += this.labText_TextChanged;
			this.opt.Location = new Point(8, 16);
			this.opt.Name = "opt";
			this.opt.Size = new Size(16, 16);
			this.opt.TabIndex = 1;
			this.opt.Text = "radioButton1";
			this.BackColor = Color.White;
			base.Controls.Add(this.opt);
			base.Controls.Add(this.labText);
			base.Name = "Classified";
			base.Size = new Size(190, 48);
			base.ResumeLayout(false);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000BA70 File Offset: 0x0000AA70
		private void labText_TextChanged(object sender, EventArgs e)
		{
			this.labText.Height = (int)this.labText.CreateGraphics().MeasureString(this.labText.Text, this.labText.Font, this.labText.Width, Classified.SFTW).Height;
			base.Height = this.labText.Height + 8;
			this.opt.Top = (base.Height + 10 - this.opt.Height) / 2;
		}

		// Token: 0x0400010D RID: 269
		public Label labText;

		// Token: 0x0400010E RID: 270
		public RadioButton opt;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400010F RID: 271
		private Container components = null;

		// Token: 0x04000110 RID: 272
		public static StringFormat SFTW;
	}
}
