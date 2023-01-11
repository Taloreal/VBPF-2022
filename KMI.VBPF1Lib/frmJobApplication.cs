using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmJobApplication.
	/// </summary>
	// Token: 0x0200004D RID: 77
	public partial class frmJobApplication : Form
	{
		// Token: 0x0600020E RID: 526 RVA: 0x0001FF04 File Offset: 0x0001EF04
		public frmJobApplication()
		{
			this.InitializeComponent();
			ArrayList offerings = A.SA.GetOfferings();
			foreach (object obj in offerings)
			{
				Offering o = (Offering)obj;
				if (o is Course)
				{
					foreach (object obj2 in this.panEducation.Controls)
					{
						ComboBox c = (ComboBox)obj2;
						if (c.FindStringExact(o.ToString()) < 0)
						{
							c.Items.Add(o);
						}
					}
				}
				if (o is Job)
				{
					foreach (object obj3 in this.panWork.Controls)
					{
						ComboBox c = (ComboBox)obj3;
						if (c.FindStringExact(o.ToString()) < 0)
						{
							c.Items.Add(o);
						}
					}
				}
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000212C1 File Offset: 0x000202C1
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000212CC File Offset: 0x000202CC
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.JobApp.Name = this.txtName.Text;
			foreach (object obj in this.panEducation.Controls)
			{
				ComboBox c = (ComboBox)obj;
				if (c.SelectedIndex > -1 && !this.JobApp.ReportedClassNames.Contains(c.SelectedItem.ToString()))
				{
					this.JobApp.ReportedClassNames.Add(c.SelectedItem.ToString());
				}
			}
			int i = 0;
			foreach (object obj2 in this.panWork.Controls)
			{
				ComboBox c = (ComboBox)obj2;
				if (c.SelectedIndex > -1 && !this.JobApp.ReportedJobNamesAndMonths.ContainsKey(c.SelectedItem.ToString()))
				{
					this.JobApp.ReportedJobNamesAndMonths.Add(c.SelectedItem.ToString(), (int)((NumericUpDown)this.panWorkMonths.Controls[i]).Value);
				}
				i++;
			}
			this.JobApp.Car = this.chkCar.Checked;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00021480 File Offset: 0x00020480
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Applying For A Job"));
		}

		// Token: 0x0400024E RID: 590
		public JobApplication JobApp = new JobApplication();
	}
}
