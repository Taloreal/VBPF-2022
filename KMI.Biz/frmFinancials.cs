using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x0200000D RID: 13
	public partial class frmFinancials : Form
	{
		// Token: 0x06000040 RID: 64 RVA: 0x000048CD File Offset: 0x000038CD
		public frmFinancials()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000048F8 File Offset: 0x000038F8
		protected void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.UpdateForm();
				this.hScroll.Value = this.hScroll.Maximum - (this.hScroll.LargeChange - 1);
				this.panCanvas.Refresh();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00004950 File Offset: 0x00003950
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00004968 File Offset: 0x00003968
		public MenuItem EnablingReference
		{
			get
			{
				return this.enablingReference;
			}
			set
			{
				this.enablingReference = value;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004974 File Offset: 0x00003974
		protected void EntityChangedHandler(object sender, EventArgs e)
		{
			if (this.enablingReference != null && !this.enablingReference.Enabled)
			{
				base.Close();
			}
			else if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000049BC File Offset: 0x000039BC
		protected bool GetData()
		{
			try
			{
				this.currentWeek = S.SA.getCurrentWeek();
				this.GL = S.SA.GetGL(S.MF.CurrentEntityID);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
				return false;
			}
			return true;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005CD8 File Offset: 0x00004CD8
		private void picCanvas_Paint(object sender, PaintEventArgs e)
		{
			int num = Math.Min(this.currentWeek, GeneralLedger.WeeksOfFinancialHistory - 1) / GeneralLedger.WeeksPerPeriod[(int)this.frequency];
			int count = this.AccountList.Count;
			int num2 = this.GL.MaxPrintingColumns(this.picCanvas.ClientSize.Width, this.AccountList, e.Graphics);
			int num3 = this.GL.MaxPrintingRows(this.picCanvas.ClientSize.Height, e.Graphics);
			int num4 = (GeneralLedger.WeeksOfFinancialHistory - 1) / GeneralLedger.WeeksPerPeriod[(int)this.frequency];
			int num5 = this.currentWeek / GeneralLedger.WeeksPerPeriod[(int)this.frequency];
			this.hScroll.Minimum = Math.Max(0, num5 - num4);
			this.hScroll.Maximum = this.hScroll.Minimum + Math.Max(0, num - num2 + (this.hScroll.LargeChange - 1));
			this.vScroll.Maximum = Math.Max(0, count - num3 + (this.vScroll.LargeChange - 1));
			int endPeriod = Math.Min(this.hScroll.Value + num2 - 1, this.hScroll.Minimum + num - 1);
			int endRow = Math.Min(this.vScroll.Value + num3 - 1, count - 1);
			this.GL.PrintToScreen(this.AccountList, this.statementName + " for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), this.vScroll.Value, endRow, this.hScroll.Value, endPeriod, this.frequency, this.optUnits.Checked, e.Graphics);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005E9D File Offset: 0x00004E9D
		private void hScroll_Scroll(object sender, ScrollEventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005EA8 File Offset: 0x00004EA8
		private void UpdateForm()
		{
			try
			{
				if (this.loaded)
				{
					if (this.optTable.Checked)
					{
						this.picCanvas.Refresh();
					}
					else
					{
						this.GL.Graph(this.AccountList, this.statementName + " for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), false, this.optUnits.Checked, this.currentWeek, this.kmiGraph1);
					}
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005F54 File Offset: 0x00004F54
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00005F5E File Offset: 0x00004F5E
		private void chkShowGrid_CheckedChanged(object sender, EventArgs e)
		{
			this.kmiGraph1.GridLinesY = this.chkShowGrid.Checked;
			this.UpdateForm();
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00005F80 File Offset: 0x00004F80
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00005F98 File Offset: 0x00004F98
		protected ArrayList AccountList
		{
			get
			{
				return this.accountList;
			}
			set
			{
				this.accountList = value;
				this.vScroll.Value = 0;
				this.hScroll.Value = this.hScroll.Minimum;
				this.UpdateForm();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00005FD0 File Offset: 0x00004FD0
		private void panCanvas_Resize(object sender, EventArgs e)
		{
			this.kmiGraph1.Size = this.panCanvas.Size;
			this.picCanvas.Width = this.panCanvas.Width - this.vScroll.Width;
			this.picCanvas.Height = this.panCanvas.Height - this.hScroll.Height;
			this.hScroll.Width = this.panCanvas.Width - this.vScroll.Width;
			this.hScroll.Location = new Point(0, this.picCanvas.Height);
			this.vScroll.Height = this.panCanvas.Height - this.hScroll.Height;
			this.vScroll.Location = new Point(this.picCanvas.Width, 0);
			this.UpdateForm();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000060C2 File Offset: 0x000050C2
		private void vScroll_Scroll(object sender, ScrollEventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000060CC File Offset: 0x000050CC
		private void optTableGraph_Click(object sender, EventArgs e)
		{
			this.chkShowGrid.Enabled = this.optGraph.Checked;
			this.kmiGraph1.Visible = this.optGraph.Checked;
			this.picCanvas.Visible = this.optTable.Checked;
			this.btnDetail.Enabled = this.optTable.Checked;
			this.optStatement_Click(new object(), new EventArgs());
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006147 File Offset: 0x00005147
		private void optDollarsUnits_Click(object sender, EventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00006154 File Offset: 0x00005154
		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (this.optTable.Checked)
			{
				this.GL.PrintToPrinter(this.AccountList, this.statementName + " for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), this.frequency, this.optUnits.Checked);
			}
			else
			{
				this.kmiGraph1.PrintGraph();
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000061CD File Offset: 0x000051CD
		private void btnExport_Click(object sender, EventArgs e)
		{
			this.GL.PrintToFile(this.AccountList, this.statementName + " for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), this.currentWeek);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000620C File Offset: 0x0000520C
		private void optFrequency_Click(object sender, EventArgs e)
		{
			if (this.optWeekly.Checked)
			{
				this.frequency = GeneralLedger.Frequency.Weekly;
			}
			if (this.optQuarterly.Checked)
			{
				this.frequency = GeneralLedger.Frequency.Quarterly;
			}
			if (this.optAnnually.Checked)
			{
				this.frequency = GeneralLedger.Frequency.Annually;
			}
			this.UpdateForm();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000626C File Offset: 0x0000526C
		private void optStatement_Click(object sender, EventArgs e)
		{
			if (this.optIncomeStatement.Checked)
			{
				this.statementName = this.optIncomeStatement.Text;
			}
			if (this.optBalanceSheet.Checked)
			{
				this.statementName = this.optBalanceSheet.Text;
			}
			if (this.optGraph.Checked)
			{
				this.AccountList = this.GL.AccountListForGraphing(this.statementName);
			}
			else
			{
				this.AccountList = this.GL.AccountList(this.statementName, this.detail);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000630C File Offset: 0x0000530C
		private void btnDetail_Click(object sender, EventArgs e)
		{
			this.detail = !this.detail;
			if (this.detail)
			{
				this.btnDetail.Text = "<< Less Detail";
			}
			else
			{
				this.btnDetail.Text = "More Detail >>";
			}
			this.AccountList = this.GL.AccountList(this.statementName, this.detail);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006378 File Offset: 0x00005378
		private void frmFinancials_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			S.MF.EntityChanged -= this.EntityChangedHandler;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000063A9 File Offset: 0x000053A9
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000063B8 File Offset: 0x000053B8
		private void picCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.rowHeight == 0f)
			{
				this.rowHeight = this.GL.RowHeight(this.picCanvas.CreateGraphics());
			}
			int num = (int)((float)(e.Y - 40) / this.rowHeight - 1f + (float)this.vScroll.Value);
			if (num < this.AccountList.Count && num >= 0)
			{
				this.picCanvas.Cursor = Cursors.Hand;
				if (!S.MF.IsWin98)
				{
					this.toolTip1.SetToolTip(this.picCanvas, "Show Definition");
				}
			}
			else
			{
				this.picCanvas.Cursor = Cursors.Default;
				if (!S.MF.IsWin98)
				{
					this.toolTip1.SetToolTip(this.picCanvas, "");
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000064A8 File Offset: 0x000054A8
		private void picCanvas_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.rowHeight == 0f)
			{
				this.rowHeight = this.GL.RowHeight(this.picCanvas.CreateGraphics());
			}
			int num = (int)((float)(e.Y - 40) / this.rowHeight - 1f + (float)this.vScroll.Value);
			if (num < this.AccountList.Count && num >= 0)
			{
				KMIHelp.OpenDefinitions(((GeneralLedger.Account)this.AccountList[num]).Name);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00006544 File Offset: 0x00005544
		private void frmFinancials_Load(object sender, EventArgs e)
		{
			if (this.EnablingReference == null)
			{
				throw new Exception("Enabling reference not set in " + this.Text);
			}
			S.MF.NewWeek += this.NewWeekHandler;
			S.MF.EntityChanged += this.EntityChangedHandler;
			if (this.GetData())
			{
				this.kmiGraph1.Location = new Point(0, 0);
				this.picCanvas.Location = new Point(0, 0);
				this.optTable.Checked = true;
				this.optDollars.Checked = true;
				this.optWeekly.Checked = true;
				this.optIncomeStatement.Checked = true;
				this.optTableGraph_Click(new object(), new EventArgs());
				this.optDollarsUnits_Click(new object(), new EventArgs());
				this.optFrequency_Click(new object(), new EventArgs());
				this.optStatement_Click(new object(), new EventArgs());
				if (!S.MF.IsWin98)
				{
					this.toolTip1.SetToolTip(this.btnPrint, "Print");
					this.toolTip1.SetToolTip(this.btnExport, "Export to Excel");
				}
				this.panCanvas_Resize(new object(), new EventArgs());
				this.loaded = true;
				this.UpdateForm();
			}
		}

		// Token: 0x04000040 RID: 64
		protected MenuItem enablingReference;

		// Token: 0x04000041 RID: 65
		private GeneralLedger GL;

		// Token: 0x04000042 RID: 66
		private int currentWeek;

		// Token: 0x04000043 RID: 67
		private string statementName;

		// Token: 0x04000044 RID: 68
		protected GeneralLedger.Frequency frequency = GeneralLedger.Frequency.Weekly;

		// Token: 0x04000045 RID: 69
		protected bool loaded;

		// Token: 0x04000046 RID: 70
		protected bool detail = false;

		// Token: 0x04000047 RID: 71
		protected ArrayList accountList;

		// Token: 0x04000048 RID: 72
		protected float rowHeight = 0f;
	}
}
