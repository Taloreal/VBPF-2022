using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000057 RID: 87
	public partial class frmTestResults : Form
	{
		// Token: 0x06000320 RID: 800 RVA: 0x00018840 File Offset: 0x00017840
		public frmTestResults()
		{
			this.InitializeComponent();
			this.g = S.SA.GetAcademicGod();
			float num = 0f;
			for (int i = 0; i < this.g.AcademicLevel; i++)
			{
				float num2 = this.g.GradeForLevel(i);
				num += num2;
				TestResultControl testResultControl = new TestResultControl(i, num2, this.g);
				testResultControl.Top = (i + 1) * testResultControl.Height;
				testResultControl.Left = 24;
				this.panResults.Controls.Add(testResultControl);
			}
			if (this.g.AcademicLevel > 0)
			{
				this.labAverage.Text = S.R.GetString("Average: {0}", new object[]
				{
					Utilities.FP(num / (float)this.g.AcademicLevel)
				});
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00018B7A File Offset: 0x00017B7A
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040001FB RID: 507
		private AcademicGod g;
	}
}
