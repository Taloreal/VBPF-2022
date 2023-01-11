using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000069 RID: 105
	public partial class frmQuestions : Form
	{
		// Token: 0x060003D9 RID: 985 RVA: 0x0001C1C4 File Offset: 0x0001B1C4
		public frmQuestions(frmQuestions.Modes mode, Question[] questions)
		{
			this.InitializeComponent();
			this.Mode = mode;
			this.questions = questions;
			int num = 0;
			int num2 = 0;
			foreach (Question question in questions)
			{
				if (this.Mode == frmQuestions.Modes.LevelEndTest)
				{
					question.Answer = null;
				}
				QuestionControl questionControl = new QuestionControl();
				questionControl.Question = question;
				if (num++ % 2 == 0)
				{
					questionControl.BackColor = Color.FromArgb(240, 240, 240);
				}
				else
				{
					questionControl.BackColor = Color.FromArgb(230, 230, 230);
				}
				questionControl.Top = num2;
				num2 += questionControl.Height;
				this.panQuestions.Controls.Add(questionControl);
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0001C7E0 File Offset: 0x0001B7E0
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (this.Mode == frmQuestions.Modes.LevelEndTest || this.Mode == frmQuestions.Modes.TestReview)
			{
				float num = 0f;
				for (int i = 0; i < this.questions.Length; i++)
				{
					QuestionControl questionControl = (QuestionControl)this.panQuestions.Controls[i];
					this.questions[i].Answer = questionControl.txtAnswer.Text;
					questionControl.Question = this.questions[i];
					questionControl.txtAnswer.Enabled = false;
					if (this.questions[i].Correct)
					{
						num += 1f;
					}
				}
				this.labScore.Text = Utilities.FP(num / (float)this.questions.Length);
				this.btnSubmit.Enabled = false;
				this.btnContinue.Enabled = true;
				this.panScore.Visible = true;
			}
			else
			{
				bool flag = true;
				for (int i = 0; i < this.questions.Length; i++)
				{
					QuestionControl questionControl = (QuestionControl)this.panQuestions.Controls[i];
					this.questions[i].Answer = questionControl.txtAnswer.Text;
					questionControl.Question = this.questions[i];
					flag = (this.questions[i].Correct && flag);
				}
				this.btnSubmit.Enabled = !flag;
				this.btnContinue.Enabled = flag;
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001C971 File Offset: 0x0001B971
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001C97C File Offset: 0x0001B97C
		private void frmQuestions_Closing(object sender, CancelEventArgs e)
		{
			if (!this.btnContinue.Enabled)
			{
				e.Cancel = true;
			}
			if (base.Owner != null)
			{
				((frmPage)base.Owner).okToClose = true;
				base.Owner.Close();
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001C9D0 File Offset: 0x0001B9D0
		private void frmQuestions_Load(object sender, EventArgs e)
		{
			if (this.Mode == frmQuestions.Modes.TestReview)
			{
				this.btnSubmit.PerformClick();
			}
		}

		// Token: 0x04000286 RID: 646
		public frmQuestions.Modes Mode = frmQuestions.Modes.Quiz;

		// Token: 0x04000287 RID: 647
		private Question[] questions;

		// Token: 0x0200006A RID: 106
		public enum Modes
		{
			// Token: 0x04000289 RID: 649
			Quiz,
			// Token: 0x0400028A RID: 650
			LevelEndTest,
			// Token: 0x0400028B RID: 651
			TestReview
		}
	}
}
