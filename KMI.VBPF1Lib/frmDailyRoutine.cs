using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmDailyRoutine.
	/// </summary>
	// Token: 0x0200004E RID: 78
	public partial class frmDailyRoutine : Form
	{
		// Token: 0x06000214 RID: 532 RVA: 0x00021498 File Offset: 0x00020498
		public frmDailyRoutine()
		{
			this.InitializeComponent();
			this.DrawSchedule(this.panMainWD);
			this.DrawSchedule(this.panMainWE);
			this.panMains = new Panel[]
			{
				this.panMainWD,
				this.panMainWE
			};
			this.simSettings = (AppSimSettings)A.SA.getSimSettings();
			this.panSpecialEvents.Visible = (this.simSettings.HealthFactorsToConsider > 4);
			if (this.simSettings.ScheduleReadOnly)
			{
				foreach (object obj in base.Controls)
				{
					Control c = (Control)obj;
					if (c is LinkLabel)
					{
						c.Enabled = false;
					}
				}
			}
			this.UpdateForm();
			this.btnChangeTravel.Enabled = A.MF.mnuActionsLivingTransportation.Enabled;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00022894 File Offset: 0x00021894
		private void Task_Click(object sender, EventArgs e)
		{
			if (this.simSettings.ScheduleReadOnly)
			{
				MessageBox.Show("You can view but not change your schedule in this lesson.", "Changes Disabled");
			}
			else
			{
				try
				{
					Control c = (Control)sender;
					Task t = (Task)c.Tag;
					Form f = new frmChangeTask(t, true, t.Weekend);
					f.ShowDialog(this);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00022914 File Offset: 0x00021914
		public void UpdateForm()
		{
			this.dailyRoutines = A.SA.GetDailyRoutines(A.MF.CurrentEntityID);
			for (int i = 0; i < 2; i++)
			{
				ArrayList j = new ArrayList(this.panMains[i].Controls);
				foreach (object obj in j)
				{
					Control c = (Control)obj;
					if (c.Tag != null)
					{
						this.panMains[i].Controls.Remove(c);
					}
				}
				foreach (object obj2 in this.dailyRoutines[i].Tasks.Values)
				{
					Task a = (Task)obj2;
					Label l3 = new Label();
					l3.Location = new Point(-1, 43 + a.StartPeriod * 7 - this.panMains[i].Top + 4);
					l3.Tag = a;
					this.panMains[i].Controls.Add(l3);
					if (a.StartPeriod <= a.EndPeriod)
					{
						l3.Size = new Size(this.panMains[i].Width - 12, a.Duration * 7);
					}
					else
					{
						l3.Size = new Size(this.panMains[i].Width - 12, (48 - a.StartPeriod) * 7);
						Label l4 = new Label();
						l4.Tag = l3.Tag;
						l4.Location = new Point(-1, 43 - this.panMains[i].Top + 4);
						l4.Size = new Size(this.panMains[i].Width - 12, a.EndPeriod * 7);
						this.panMains[i].Controls.Add(l4);
					}
				}
				foreach (object obj3 in this.panMains[i].Controls)
				{
					Control c = (Control)obj3;
					if (c.Tag != null)
					{
						Task a = (Task)c.Tag;
						Label lab = (Label)c;
						lab.BackColor = a.GetColor();
						lab.BorderStyle = BorderStyle.FixedSingle;
						lab.BringToFront();
						if (!(a is TravelTask))
						{
							lab.Click += this.Task_Click;
							lab.Cursor = Cursors.Hand;
							lab.TextAlign = ContentAlignment.MiddleCenter;
							lab.Text = a.CategoryName();
						}
						else
						{
							lab.Width = 12;
							lab.Left = this.panMains[i].Width - 12;
						}
					}
				}
			}
			SortedList events = A.SA.GetOneTimeEventsInvitedTo(A.MF.CurrentEntityID);
			SortedList eventsAttending = A.SA.GetOneTimeEventsAttending(A.MF.CurrentEntityID);
			int k = 0;
			this.chkEvents.Items.Clear();
			foreach (object obj4 in events.Values)
			{
				OneTimeEvent d = (OneTimeEvent)obj4;
				this.chkEvents.Items.Add(d);
				if (eventsAttending.ContainsKey(d.Key))
				{
					this.chkEvents.SetItemChecked(k, true);
				}
				k++;
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00022D9C File Offset: 0x00021D9C
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00022DA6 File Offset: 0x00021DA6
		private void AddWorkout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.AddTask(new Exercise(), bool.Parse((string)((Control)sender).Tag));
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00022DCA File Offset: 0x00021DCA
		private void AddSleep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.AddTask(new Sleep(), bool.Parse((string)((Control)sender).Tag));
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00022DEE File Offset: 0x00021DEE
		private void AddRelaxation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.AddTask(new Relax(), bool.Parse((string)((Control)sender).Tag));
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00022E14 File Offset: 0x00021E14
		private void AddTask(Task task, bool weekend)
		{
			try
			{
				Form f = new frmChangeTask(task, false, weekend);
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00022E54 File Offset: 0x00021E54
		private void AddEat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.AddTask(new Eat(), bool.Parse((string)((Control)sender).Tag));
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00022E78 File Offset: 0x00021E78
		private void btnChangeTravel_Click(object sender, EventArgs e)
		{
			A.MF.mnuActionsLivingTransportation.PerformClick();
			this.UpdateForm();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00022E92 File Offset: 0x00021E92
		private void label4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00022E98 File Offset: 0x00021E98
		protected void DrawSchedule(Panel p)
		{
			for (int i = 0; i < 48; i++)
			{
				Label j = new Label();
				j.Text = new DateTime(1, 1, 1).AddHours((double)((float)i / 2f)).ToShortTimeString();
				j.Location = new Point(p.Left - 48, 45 + i * 7);
				j.Font = new Font("Arial", 7f);
				j.Size = new Size(46, 16);
				j.TextAlign = ContentAlignment.TopRight;
				j.ForeColor = Color.FromArgb(110, 110, 110);
				Label l2 = new Label();
				l2.BackColor = Color.LightGray;
				if (i % 2 == 0)
				{
					l2.BackColor = Color.DarkGray;
				}
				l2.Location = new Point(0, j.Top - p.Top + 2);
				l2.Size = new Size(p.Width, 1);
				p.Controls.Add(l2);
				l2.Enabled = false;
				if (i % 2 == 0)
				{
					base.Controls.Add(j);
				}
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00022FD8 File Offset: 0x00021FD8
		private void btnHostAParty_Click(object sender, EventArgs e)
		{
			frmChooseEventTime f = new frmChooseEventTime();
			f.ShowDialog(this);
			this.UpdateForm();
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00022FFC File Offset: 0x00021FFC
		private void chkEvents_SelectedValueChanged(object sender, EventArgs e)
		{
			ArrayList ids = new ArrayList();
			foreach (object obj in this.chkEvents.CheckedItems)
			{
				Task t = (Task)obj;
				ids.Add(t.ID);
			}
			A.SA.SetOneTimeEvents(A.MF.CurrentEntityID, ids);
			this.UpdateForm();
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00023098 File Offset: 0x00022098
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0400024F RID: 591
		private const int hrSpacing = 7;

		// Token: 0x04000251 RID: 593
		private AppSimSettings simSettings;

		// Token: 0x04000252 RID: 594
		private DailyRoutine[] dailyRoutines;

		// Token: 0x04000253 RID: 595
		private Panel[] panMains;
	}
}
