using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmInvesting.
	/// </summary>
	// Token: 0x02000085 RID: 133
	public partial class frmResearchFunds : Form
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x000385E0 File Offset: 0x000375E0
		public frmResearchFunds(object sender)
		{
			this.InitializeComponent();
			this.funds = A.SA.GetFunds();
			this.now = A.SA.Now();
			this.PrimeRate = A.SA.GetPrimeRate();
			this.cboSector.Items.Add(A.R.GetString("{All}"));
			foreach (string s in AppConstants.FundCategories)
			{
				this.cboSector.Items.Add(s);
			}
			this.cboSector.SelectedIndex = 0;
			this.kmiGraph1.TitleFontSize = 9f;
			this.Reset();
			if (sender is string)
			{
				this.lstFunds.SelectedIndex = this.lstFunds.FindStringExact((string)sender);
			}
			else
			{
				this.lstFunds.SelectedIndex = 0;
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00039D40 File Offset: 0x00038D40
		private void lstFunds_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			int days = this.yearsToShow * 365;
			Fund selectedFund = (Fund)this.lstFunds.SelectedItem;
			this.labFundName.Text = selectedFund.Name;
			this.labNav.Text = selectedFund.Price.ToString("N2");
			this.labPrevious.Text = selectedFund.Previous.ToString("N2");
			float change = selectedFund.Price - selectedFund.Previous;
			if (change >= 0f)
			{
				this.labChange.Text = "+" + change.ToString("N2");
				this.labChange.ForeColor = Color.Green;
			}
			else if (change < 0f)
			{
				this.labChange.Text = change.ToString("N2");
				this.labChange.ForeColor = Color.Red;
			}
			float jan = selectedFund.PriceOn(new DateTime(this.now.Year, 1, 1));
			this.labYTD.Text = Utilities.FP((selectedFund.Price - jan) / jan, 2);
			float dividend;
			if (selectedFund is MoneyMarketFund)
			{
				dividend = (this.PrimeRate + ((MoneyMarketFund)selectedFund).DiffToPrime - selectedFund.TotalExpenseRatio) * selectedFund.Price;
			}
			else
			{
				dividend = selectedFund.Dividend;
			}
			this.labYield.Text = Utilities.FP(dividend / selectedFund.Price, 2);
			this.labTER.Text = Utilities.FP(selectedFund.TotalExpenseRatio, 2);
			this.lab12b1.Text = Utilities.FP(selectedFund.Fees12B1, 2);
			this.labFront.Text = Utilities.FP(selectedFund.FrontEndLoad, 2);
			this.labBack.Text = Utilities.FP(selectedFund.BackEndLoad, 2);
			this.d = new object[2, days + 1];
			float min = float.MaxValue;
			float max = 0.01f;
			for (int i = 0; i < days; i++)
			{
				float f = (float)selectedFund.sharePrice[selectedFund.sharePrice.Count - days + i];
				this.d[1, i + 1] = f;
				if (f < min)
				{
					min = f;
				}
				if (f > max)
				{
					max = f;
				}
			}
			this.kmiGraph1.LineWidth = 1;
			if (max == min)
			{
				max = min * 1.5f;
				min = 0f;
				this.kmiGraph1.LineWidth = 2;
			}
			this.kmiGraph1.AutoScaleY = false;
			this.kmiGraph1.YMin = min;
			this.kmiGraph1.YMax = max;
			this.kmiGraph1.YTicks = 4;
			if (this.yearsToShow == 1)
			{
				this.kmiGraph1.XAxisTitle = "1 Year";
			}
			else
			{
				this.kmiGraph1.XAxisTitle = "5 Years";
			}
			this.kmiGraph1.Draw(this.d);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0003A090 File Offset: 0x00039090
		private void cboSector_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Reset();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0003A09C File Offset: 0x0003909C
		private void Reset()
		{
			this.lstFunds.Items.Clear();
			foreach (object obj in this.funds)
			{
				Fund s = (Fund)obj;
				if (this.cboSector.SelectedIndex == 0 || (string)this.cboSector.SelectedItem == s.CategoryName)
				{
					this.lstFunds.Items.Add(s);
				}
			}
			if (this.lstFunds.Items.Count > 0)
			{
				this.lstFunds.SelectedIndex = 0;
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0003A178 File Offset: 0x00039178
		private void lnk1Year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (sender == this.lnk1Year)
			{
				this.yearsToShow = 1;
			}
			else
			{
				this.yearsToShow = 5;
			}
			this.lstFunds_SelectedIndexChanged_1(new object(), new EventArgs());
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0003A1B7 File Offset: 0x000391B7
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0003A1C4 File Offset: 0x000391C4
		private void lnkBuy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				frmTrade f = new frmTrade(false, true, (Fund)this.lstFunds.SelectedItem);
				f.ShowDialog(this);
				frmMyPortfolio f2 = new frmMyPortfolio(false);
				f2.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0003A224 File Offset: 0x00039224
		public void ExportToExcel(ArrayList lines)
		{
			MessageBox.Show("Your data will be exported to a tab-delimited text file which can be opened with Excel.", "Export Format");
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Tab Delimited Text Files (*.txt)|*.txt|All files (*.*)|*.*";
			dlg.DefaultExt = ".txt";
			if (Simulator.Instance.UserAdminSettings.DefaultDirectory != null)
			{
				dlg.InitialDirectory = Simulator.Instance.UserAdminSettings.DefaultDirectory;
			}
			while (dlg.ShowDialog() == DialogResult.OK)
			{
				StreamWriter writer = null;
				try
				{
					writer = new StreamWriter(dlg.FileName);
					foreach (object obj in lines)
					{
						string s = (string)obj;
						writer.Write(s);
					}
					break;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not export to file. File may be read-only or in use by another application.\r\n\r\nError details: " + ex.Message, "Could Not Export");
				}
				finally
				{
					if (writer != null)
					{
						writer.Close();
					}
				}
			}
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0003A368 File Offset: 0x00039368
		private void lnkExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bool annual = false;
			if (A.MF.DesignerMode)
			{
				annual = (MessageBox.Show("Annual?", "", MessageBoxButtons.YesNo) == DialogResult.Yes);
			}
			ArrayList lines = new ArrayList();
			string tab = "\t";
			string s = tab;
			foreach (object obj in this.lstFunds.Items)
			{
				Fund f = (Fund)obj;
				s = s + f.Name + tab;
			}
			s += Environment.NewLine;
			lines.Add(s);
			s = "";
			DateTime begin = this.now.AddDays(-1825.0);
			for (int i = 0; i < 1825; i++)
			{
				s = s + begin.AddDays((double)i).ToShortDateString() + tab;
				foreach (object obj2 in this.lstFunds.Items)
				{
					Fund f = (Fund)obj2;
					s = s + f.sharePrice[f.sharePrice.Count - 1825 - 1 + i] + tab;
				}
				s += Environment.NewLine;
				if (!annual || i % 365 == 3)
				{
					lines.Add(s);
				}
				s = "";
			}
			this.ExportToExcel(lines);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0003A54C File Offset: 0x0003954C
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0003A556 File Offset: 0x00039556
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x040004B9 RID: 1209
		public MenuItem EnablingReference;

		// Token: 0x040004BA RID: 1210
		private int yearsToShow = 1;

		// Token: 0x040004BB RID: 1211
		private DateTime now;

		// Token: 0x040004BC RID: 1212
		private float PrimeRate;

		// Token: 0x040004BD RID: 1213
		private ArrayList funds;

		// Token: 0x040004BE RID: 1214
		private object[,] d = null;
	}
}
