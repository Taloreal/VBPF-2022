using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmInvesting.
	/// </summary>
	// Token: 0x0200008D RID: 141
	public partial class frmMyPortfolio : Form
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x0003BAF4 File Offset: 0x0003AAF4
		public frmMyPortfolio(bool retirement)
		{
			this.InitializeComponent();
			this.Retirement = retirement;
			if (retirement)
			{
				this.Text = "View Retirement Portfolio";
			}
			this.lnkBuy.Visible = !retirement;
			this.RefreshData();
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0003BB54 File Offset: 0x0003AB54
		public void RefreshData()
		{
			this.panFunds.Controls.Clear();
			this.myFunds = A.SA.GetInvestmentAccounts(A.MF.CurrentEntityID, this.Retirement);
			int y = 0;
			float total = 0f;
			Hashtable assetClasses = new Hashtable();
			foreach (object obj in this.myFunds.Values)
			{
				InvestmentAccount f = (InvestmentAccount)obj;
				FundControl fc = new FundControl(f, this.Retirement);
				fc.Top = y;
				this.panFunds.Controls.Add(fc);
				y += fc.Height;
				total += f.Value;
				string key = f.Fund.CategoryName;
				if (assetClasses.ContainsKey(key))
				{
					assetClasses[key] = (float)assetClasses[key] + f.Value;
				}
				else
				{
					assetClasses.Add(key, f.Value);
				}
			}
			if (this.panFunds.Controls.Count > 0)
			{
				this.labTotalLabel.Top = y;
				this.labTotal.Top = y;
				this.labTotal.Text = Utilities.FC(total, 2, A.I.CurrencyConversion);
				this.panFunds.Controls.Add(this.labTotalLabel);
				this.panFunds.Controls.Add(this.labTotal);
			}
			this.kmiGraph1.GraphType = 4;
			this.d = new object[1 + assetClasses.Count, 2];
			int count = 0;
			foreach (object obj2 in assetClasses.Keys)
			{
				string key = (string)obj2;
				this.d[1 + count, 1] = (float)assetClasses[key];
				this.d[1 + count, 0] = key;
				count++;
			}
			this.kmiGraph1.Draw(this.d);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0003CA78 File Offset: 0x0003BA78
		private void lnkBuy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				frmTrade f = new frmTrade(this.Retirement, true, null);
				f.ShowDialog(this);
				this.RefreshData();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0003CAC4 File Offset: 0x0003BAC4
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0003CACE File Offset: 0x0003BACE
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0003CAD8 File Offset: 0x0003BAD8
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x040004EA RID: 1258
		public MenuItem EnablingReference;

		// Token: 0x040004EB RID: 1259
		private bool Retirement;

		// Token: 0x040004EC RID: 1260
		private SortedList myFunds;

		// Token: 0x040004ED RID: 1261
		private object[,] d = null;
	}
}
