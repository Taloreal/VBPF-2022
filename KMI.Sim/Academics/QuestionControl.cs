using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace KMI.Sim.Academics
{
	// Token: 0x02000079 RID: 121
	public class QuestionControl : UserControl
	{
		// Token: 0x06000456 RID: 1110 RVA: 0x0001F293 File Offset: 0x0001E293
		public QuestionControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0001F2A8 File Offset: 0x0001E2A8
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

		// Token: 0x170000FD RID: 253
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x0001F2E4 File Offset: 0x0001E2E4
		public Question Question
		{
			set
			{
				this.labQuestion.Text = value.Text;
				this.txtAnswer.Text = value.Answer;
				if (value.Answer != null)
				{
					if (value.Correct)
					{
						this.labRightWrong.Image = this.imlRightWrong.Images[0];
						this.txtAnswer.Enabled = false;
					}
					else
					{
						this.labRightWrong.Image = this.imlRightWrong.Images[1];
					}
				}
				this.txtAnswer.Select(0, 0);
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0001F38C File Offset: 0x0001E38C
		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(QuestionControl));
			this.txtAnswer = new TextBox();
			this.labRightWrong = new Label();
			this.labQuestion = new Label();
			this.imlRightWrong = new ImageList(this.components);
			base.SuspendLayout();
			this.txtAnswer.Location = new Point(8, 80);
			this.txtAnswer.Name = "txtAnswer";
			this.txtAnswer.Size = new Size(240, 20);
			this.txtAnswer.TabIndex = 1;
			this.txtAnswer.Text = "";
			this.txtAnswer.TextAlign = HorizontalAlignment.Right;
			this.labRightWrong.Location = new Point(280, 80);
			this.labRightWrong.Name = "labRightWrong";
			this.labRightWrong.Size = new Size(24, 24);
			this.labRightWrong.TabIndex = 2;
			this.labQuestion.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labQuestion.Location = new Point(8, 8);
			this.labQuestion.Name = "labQuestion";
			this.labQuestion.Size = new Size(448, 64);
			this.labQuestion.TabIndex = 3;
			this.labQuestion.Text = "label1";
			this.imlRightWrong.ColorDepth = ColorDepth.Depth32Bit;
			this.imlRightWrong.ImageSize = new Size(16, 14);
			this.imlRightWrong.ImageStream = (ImageListStreamer)resourceManager.GetObject("imlRightWrong.ImageStream");
			this.imlRightWrong.TransparentColor = Color.Transparent;
			base.Controls.Add(this.labQuestion);
			base.Controls.Add(this.labRightWrong);
			base.Controls.Add(this.txtAnswer);
			base.Name = "QuestionControl";
			base.Size = new Size(456, 112);
			base.ResumeLayout(false);
		}

		// Token: 0x040002DB RID: 731
		private Label labRightWrong;

		// Token: 0x040002DC RID: 732
		public TextBox txtAnswer;

		// Token: 0x040002DD RID: 733
		private Label labQuestion;

		// Token: 0x040002DE RID: 734
		private ImageList imlRightWrong;

		// Token: 0x040002DF RID: 735
		private IContainer components;

		// Token: 0x040002E0 RID: 736
		protected Question question;
	}
}
