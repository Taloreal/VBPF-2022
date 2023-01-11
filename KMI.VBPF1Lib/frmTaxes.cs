using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmTaxes.
	/// </summary>
	// Token: 0x02000066 RID: 102
	public partial class frmTaxes : Form, IConstrainedForm
	{
		// Token: 0x06000296 RID: 662 RVA: 0x000298A0 File Offset: 0x000288A0
		public frmTaxes(frmTaxes.Mode mode)
		{
			this.InitializeComponent();
			this.mode = mode;
			this.fedTaxAccount = A.SA.GetFedTaxAccount(A.MF.CurrentEntityID);
			if (mode == frmTaxes.Mode.Past)
			{
				this.lastYear = A.SA.GetLastYear();
				this.taxReturns = A.SA.GetTaxes(A.MF.CurrentEntityID);
				if (this.taxReturns.Count == 0)
				{
					throw new SimApplicationException("You have no past tax returns at this time.");
				}
				this.taxReturns.Reverse();
				foreach (object obj in this.taxReturns)
				{
					TaxReturn t = (TaxReturn)obj;
					this.cboOldReturns.Items.Add(t);
				}
				this.cboOldReturns.SelectedIndex = 0;
				this.btnFile.Visible = false;
				this.Instructions.Visible = false;
			}
			if (mode == frmTaxes.Mode.Current)
			{
				this.lastYear = A.SA.TaxYearDue(A.MF.CurrentEntityID);
				if (this.lastYear != -1)
				{
					if (!A.SA.UseAccountant())
					{
						this.CurrentReturn = A.SA.GetNewF1040EZ(A.MF.CurrentEntityID, this.lastYear);
					}
					else
					{
						this.CurrentReturn = A.SA.GetNewAccountantsReport(A.MF.CurrentEntityID, this.lastYear);
						this.Instructions.Visible = false;
						MessageBox.Show("Since you are past Level 1 or in an investing lesson or special competition, your tax return has been prepared for you by a tax professional. When you click File Tax Return, the tax return prepared by the professional will be sent to the IRS.", "Tax Return");
					}
					this.TaxYear.Visible = false;
					this.cboOldReturns.Visible = false;
				}
			}
			this.panMain.BackgroundImage = A.R.GetImage("1040EZ");
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0002AE90 File Offset: 0x00029E90
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x1700002F RID: 47
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0002AE94 File Offset: 0x00029E94
		protected TaxReturn CurrentReturn
		{
			set
			{
				this.currentReturn = value;
				if (value is F1040EZ)
				{
					this.panReport.Visible = false;
					this.panMain.Visible = true;
					this.Year.Text = value.ToString();
					foreach (object obj in this.panMain.Controls)
					{
						Control c = (Control)obj;
						for (int i = 0; i < this.panMain.Controls.Count; i++)
						{
							if (c.Name == "t" + i)
							{
								if (value.Values[i] > 0)
								{
									c.Text = value.Values[i].ToString();
								}
								else
								{
									c.Text = "";
								}
								if (this.mode == frmTaxes.Mode.Past)
								{
									c.BackColor = Color.White;
									c.Enabled = false;
								}
							}
							if (c.Name == "l" + i)
							{
								c.Text = value.Lines[i];
							}
						}
					}
				}
				else
				{
					this.panMain.Visible = false;
					this.panReport.Visible = true;
					this.panReport.Refresh();
				}
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0002B04C File Offset: 0x0002A04C
		private void btnFile_Click(object sender, EventArgs e)
		{
			if (this.currentReturn is F1040EZ)
			{
				foreach (object obj in this.panMain.Controls)
				{
					Control c = (Control)obj;
					for (int i = 0; i < this.panMain.Controls.Count; i++)
					{
						if (c.Name == "t" + i)
						{
							try
							{
								if (c.Text.Length == 0)
								{
									this.currentReturn.Values[i] = 0;
								}
								else
								{
									this.currentReturn.Values[i] = int.Parse(c.Text);
								}
							}
							catch
							{
								MessageBox.Show(A.R.GetString("Incorrect entry. Please retry. Remember to use the whole dollar method."), A.R.GetString("Please Retry"));
								((TextBox)c).SelectAll();
								c.Focus();
								return;
							}
						}
					}
				}
				foreach (TextBox tb in new TextBox[]
				{
					this.t0,
					this.t2,
					this.t4,
					this.t6
				})
				{
					if (tb.Text.Length == 0)
					{
						string msg = A.R.GetString("Information is required on lines 1, 4, 6 and 11 of Form 1040EZ. If the correct amount is zero, enter the numeral 0.");
						MessageBox.Show(msg, A.R.GetString("More Information Required"));
						return;
					}
				}
				if (this.t7.Text.Length == 0 && this.t8.Text.Length == 0)
				{
					string msg = A.R.GetString("You must make an entry on line 12a or line 13 of Form 1040EZ. If the correct amount is zero, enter the numeral 0.");
					MessageBox.Show(msg, A.R.GetString("More Information Required"));
					return;
				}
			}
			try
			{
				float refund = (float)this.currentReturn.Values[7];
				float owe = (float)this.currentReturn.Values[8];
				if (refund != 0f && owe != 0f)
				{
					MessageBox.Show(A.R.GetString("You cannot have a refund and payment due. Please recheck your calculations."), A.R.GetString("Please Retry"));
				}
				else if (refund < 0f || owe < 0f)
				{
					MessageBox.Show(A.R.GetString("Your refund or payment must be greater than or equal to 0. Please recheck your calculations."), A.R.GetString("Please Retry"));
				}
				else
				{
					if (owe > 0f)
					{
						Bill taxBill = A.SA.CreateBill(A.R.GetString("IRS"), "Income Taxes for " + this.lastYear, owe, this.fedTaxAccount);
						frmPayBy f = new frmPayBy(taxBill);
						if (f.ShowDialog(this) != DialogResult.OK)
						{
							return;
						}
					}
					A.SA.SetTaxes(A.MF.CurrentEntityID, this.currentReturn);
					MessageBox.Show(A.R.GetString("Your return has been filed!"), A.R.GetString("Success"));
					base.Close();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0002B454 File Offset: 0x0002A454
		private void cboOldReturns_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CurrentReturn = (TaxReturn)this.cboOldReturns.SelectedItem;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0002B470 File Offset: 0x0002A470
		public string CanUse()
		{
			string result;
			if (this.mode == frmTaxes.Mode.Past && this.taxReturns.Count == 0)
			{
				result = A.R.GetString("You have no past tax returns.");
			}
			else if (this.mode == frmTaxes.Mode.Current && A.SA.TaxYearDue(A.MF.CurrentEntityID) == -1)
			{
				result = A.R.GetString("You do not have any tax returns that can be filed at this time.");
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0002B4F8 File Offset: 0x0002A4F8
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0002B504 File Offset: 0x0002A504
		private void linkTaxTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			new frmTaxTable
			{
				Owner = this
			}.Show();
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0002B527 File Offset: 0x0002A527
		private void textBox3_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0002B52A File Offset: 0x0002A52A
		private void panReport_Paint(object sender, PaintEventArgs e)
		{
			this.PrintAccountantsReport(e.Graphics, 0);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0002B53C File Offset: 0x0002A53C
		protected void PrintAccountantsReport(Graphics g, int y)
		{
			ArrayList fontList = new ArrayList(new string[]
			{
				"Courier New",
				"Lucida Console"
			});
			Font f = null;
			int i = 0;
			while (i < fontList.Count)
			{
				f = new Font((string)fontList[i], 12f);
				i++;
				if (fontList.Contains(f.FontFamily.Name))
				{
					break;
				}
			}
			AccountantsReport r = (AccountantsReport)this.currentReturn;
			g.DrawString(r.Report, f, new SolidBrush(Color.Black), new Rectangle(this.panReport.Bounds.X, this.panReport.Bounds.Y + y, this.panReport.Width, this.panReport.Height));
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0002B628 File Offset: 0x0002A628
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0002B638 File Offset: 0x0002A638
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.studentName = "";
			frmInputString form = new frmInputString(S.R.GetString("Student Name"), S.R.GetString("Enter your name to help identify your printout on a shared printer:"), this.studentName);
			form.ShowDialog(this);
			this.studentName = form.Response;
			Utilities.PrintWithExceptionHandling(this.Text, new PrintPageEventHandler(this.PrintPage));
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0002B6A8 File Offset: 0x0002A6A8
		protected void PrintPage(object sender, PrintPageEventArgs e)
		{
			Utilities.ResetFPU();
			SolidBrush b = new SolidBrush(Color.Black);
			Pen pen = new Pen(b, 1f);
			StringFormat sfr = new StringFormat();
			sfr.Alignment = StringAlignment.Far;
			int y = 10;
			if (this.studentName.Length > 0)
			{
				e.Graphics.DrawString(A.R.GetString("This report belongs to: {0}", new object[]
				{
					this.studentName
				}), this.Font, b, 0f, (float)y);
			}
			y += 30;
			if (this.currentReturn is F1040EZ)
			{
				y += 30;
				e.Graphics.ScaleTransform(1.1f, 1.1f);
				e.Graphics.DrawImageUnscaled(A.R.GetImage("1040EZ"), 0, y);
				int i = 0;
				foreach (object obj in this.panMain.Controls)
				{
					Control c = (Control)obj;
					if ((c is TextBox || c is Label) && c.Text != "")
					{
						Rectangle r = new Rectangle(c.Left + 10, (int)(1.04 * (double)(y + c.Top)), c.Width - 1, c.Height);
						StringFormat sf = new StringFormat();
						if (!(c is Label))
						{
							sf = sfr;
						}
						e.Graphics.DrawString(c.Text, c.Font, b, r, sf);
						i++;
					}
				}
			}
			else
			{
				this.PrintAccountantsReport(e.Graphics, y);
			}
		}

		// Token: 0x04000325 RID: 805
		public frmTaxes.Mode mode;

		// Token: 0x04000326 RID: 806
		private ArrayList taxReturns;

		// Token: 0x04000327 RID: 807
		private int lastYear;

		// Token: 0x04000328 RID: 808
		private BankAccount fedTaxAccount;

		// Token: 0x04000329 RID: 809
		protected TaxReturn currentReturn;

		// Token: 0x0400032A RID: 810
		private string studentName;

		// Token: 0x02000067 RID: 103
		public enum Mode
		{
			// Token: 0x0400032C RID: 812
			Past,
			// Token: 0x0400032D RID: 813
			Current
		}
	}
}
