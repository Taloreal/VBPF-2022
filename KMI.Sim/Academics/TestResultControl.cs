using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000043 RID: 67
	public class TestResultControl : UserControl
	{
		// Token: 0x0600027C RID: 636 RVA: 0x00014DC2 File Offset: 0x00013DC2
		public TestResultControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00014DDC File Offset: 0x00013DDC
		public TestResultControl(int index, float score, AcademicGod g)
		{
			this.InitializeComponent();
			this.index = index;
			this.g = g;
			this.labResult.Text = S.R.GetString("Level {0} - {1}", new object[]
			{
				index + 1,
				Utilities.FP(score)
			});
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00014E48 File Offset: 0x00013E48
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

		// Token: 0x0600027F RID: 639 RVA: 0x00014E84 File Offset: 0x00013E84
		private void InitializeComponent()
		{
			this.labResult = new Label();
			this.labDetails = new Label();
			base.SuspendLayout();
			this.labResult.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labResult.Location = new Point(16, 8);
			this.labResult.Name = "labResult";
			this.labResult.Size = new Size(120, 16);
			this.labResult.TabIndex = 0;
			this.labResult.Text = "label1";
			this.labResult.TextAlign = ContentAlignment.BottomLeft;
			this.labDetails.Cursor = Cursors.Hand;
			this.labDetails.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, 0);
			this.labDetails.ForeColor = Color.FromArgb(0, 0, 192);
			this.labDetails.Location = new Point(152, 6);
			this.labDetails.Name = "labDetails";
			this.labDetails.Size = new Size(64, 16);
			this.labDetails.TabIndex = 1;
			this.labDetails.Text = "Details";
			this.labDetails.TextAlign = ContentAlignment.BottomLeft;
			this.labDetails.Click += this.labDetails_Click;
			base.Controls.Add(this.labDetails);
			base.Controls.Add(this.labResult);
			base.Name = "TestResultControl";
			base.Size = new Size(264, 32);
			base.ResumeLayout(false);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0001504C File Offset: 0x0001404C
		private void labDetails_Click(object sender, EventArgs e)
		{
			frmQuestions frmQuestions = new frmQuestions(frmQuestions.Modes.TestReview, this.g.FindAllAskedQuestions(this.index));
			frmQuestions.ShowDialog();
		}

		// Token: 0x040001A0 RID: 416
		private Label labResult;

		// Token: 0x040001A1 RID: 417
		private Label labDetails;

		// Token: 0x040001A2 RID: 418
		private Container components = null;

		// Token: 0x040001A3 RID: 419
		private int index;

		// Token: 0x040001A4 RID: 420
		private AcademicGod g;
	}
}
