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
	// Token: 0x02000014 RID: 20
	public partial class frmProductReport : Form
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00008EA3 File Offset: 0x00007EA3
		public frmProductReport()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00008EE0 File Offset: 0x00007EE0
		protected void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.UpdateForm();
				this.hScroll.Value = this.hScroll.Maximum - (this.hScroll.LargeChange - 1);
				this.panCanvas.Refresh();
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00008F38 File Offset: 0x00007F38
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00008F50 File Offset: 0x00007F50
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

		// Token: 0x0600008D RID: 141 RVA: 0x00008F5C File Offset: 0x00007F5C
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

		// Token: 0x0600008E RID: 142 RVA: 0x00008FA4 File Offset: 0x00007FA4
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

		// Token: 0x06000091 RID: 145 RVA: 0x0000A494 File Offset: 0x00009494
		private void picCanvas_Paint(object sender, PaintEventArgs e)
		{
			int num = Math.Min(this.currentWeek, GeneralLedger.WeeksOfProductHistory - 1) / GeneralLedger.WeeksPerPeriod[(int)this.frequency];
			int count = this.AccountList.Count;
			int num2 = this.GL.MaxPrintingColumns(this.picCanvas.ClientSize.Width, this.AccountList, e.Graphics);
			int num3 = this.GL.MaxPrintingRows(this.picCanvas.ClientSize.Height, e.Graphics);
			this.hScroll.Minimum = Math.Max(0, this.currentWeek - (GeneralLedger.WeeksOfProductHistory - 1));
			this.hScroll.Maximum = this.hScroll.Minimum + Math.Max(0, num - num2 + (this.hScroll.LargeChange - 1));
			this.vScroll.Maximum = Math.Max(0, count - num3 + (this.vScroll.LargeChange - 1));
			int endPeriod = Math.Min(this.hScroll.Value + num2 - 1, this.hScroll.Minimum + num - 1);
			int endRow = Math.Min(this.vScroll.Value + num3 - 1, count - 1);
			this.GL.PrintToScreen(this.AccountList, "Product Report for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), this.vScroll.Value, endRow, this.hScroll.Value, endPeriod, GeneralLedger.Frequency.Weekly, false, e.Graphics);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000A622 File Offset: 0x00009622
		private void hScroll_Scroll(object sender, ScrollEventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000A62C File Offset: 0x0000962C
		private void UpdateForm()
		{
			try
			{
				if (this.loaded && !this.suppressUpdates)
				{
					if (this.optTable.Checked)
					{
						this.picCanvas.Refresh();
					}
					else
					{
						this.GL.Graph(this.AccountList, "Product Report for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), this.units, false, this.currentWeek, this.kmiGraph1);
					}
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000A6D4 File Offset: 0x000096D4
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000A6DE File Offset: 0x000096DE
		private void chkShowGrid_CheckedChanged(object sender, EventArgs e)
		{
			this.kmiGraph1.GridLinesY = this.chkShowGrid.Checked;
			this.UpdateForm();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000A700 File Offset: 0x00009700
		private void chkProduct_CheckedChanged(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			if (this.chkProduct.Checked)
			{
				arrayList.Add("Total");
			}
			foreach (object obj in this.panProduct.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				if (checkBox.Checked)
				{
					arrayList.Add(checkBox.Text);
				}
			}
			this.ProductNames = arrayList;
			this.AccountList = this.GL.AccountList(this.DataSeriesNames, this.ProductNames, this.Units);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000A7D0 File Offset: 0x000097D0
		private void chkData_CheckedChanged(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.grpData.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				if (checkBox.Checked)
				{
					arrayList.Add(checkBox.Text);
				}
			}
			this.DataSeriesNames = arrayList;
			this.AccountList = this.GL.AccountList(this.DataSeriesNames, this.ProductNames, this.Units);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000A884 File Offset: 0x00009884
		// (set) Token: 0x06000099 RID: 153 RVA: 0x0000A89C File Offset: 0x0000989C
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

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000A8D4 File Offset: 0x000098D4
		// (set) Token: 0x0600009B RID: 155 RVA: 0x0000A8EC File Offset: 0x000098EC
		protected ArrayList DataSeriesNames
		{
			get
			{
				return this.dataSeriesNames;
			}
			set
			{
				this.dataSeriesNames = value;
				this.AccountList = this.GL.AccountList(this.dataSeriesNames, this.productNames, this.units);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000A91C File Offset: 0x0000991C
		// (set) Token: 0x0600009D RID: 157 RVA: 0x0000A934 File Offset: 0x00009934
		protected ArrayList ProductNames
		{
			get
			{
				return this.productNames;
			}
			set
			{
				this.productNames = value;
				this.AccountList = this.GL.AccountList(this.dataSeriesNames, this.productNames, this.units);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000A964 File Offset: 0x00009964
		// (set) Token: 0x0600009F RID: 159 RVA: 0x0000A97C File Offset: 0x0000997C
		protected bool Units
		{
			get
			{
				return this.units;
			}
			set
			{
				this.units = value;
				this.AccountList = this.GL.AccountList(this.dataSeriesNames, this.productNames, this.units);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A9AC File Offset: 0x000099AC
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

		// Token: 0x060000A1 RID: 161 RVA: 0x0000AA9E File Offset: 0x00009A9E
		private void vScroll_Scroll(object sender, ScrollEventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000AAA8 File Offset: 0x00009AA8
		private void optTableGraph_Click(object sender, EventArgs e)
		{
			this.chkShowGrid.Enabled = this.optGraph.Checked;
			this.kmiGraph1.Visible = this.optGraph.Checked;
			this.picCanvas.Visible = this.optTable.Checked;
			this.UpdateForm();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000AB02 File Offset: 0x00009B02
		private void optDollarsUnits_Click(object sender, EventArgs e)
		{
			this.Units = this.optUnits.Checked;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000AB18 File Offset: 0x00009B18
		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panProduct.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				checkBox.Checked = true;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000AB84 File Offset: 0x00009B84
		private void btnUncheckAll_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panProduct.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				checkBox.Checked = false;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000ABF0 File Offset: 0x00009BF0
		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (this.optTable.Checked)
			{
				this.GL.PrintToPrinter(this.AccountList, "Product Report for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), GeneralLedger.Frequency.Weekly, false);
			}
			else
			{
				this.kmiGraph1.PrintGraph();
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000AC54 File Offset: 0x00009C54
		private void btnExport_Click(object sender, EventArgs e)
		{
			this.GL.PrintToFile(this.AccountList, "Product Report for " + S.MF.EntityIDToName(S.MF.CurrentEntityID), this.currentWeek);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000AC8D File Offset: 0x00009C8D
		private void frmSales_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			S.MF.EntityChanged -= this.EntityChangedHandler;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000ACBE File Offset: 0x00009CBE
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000ACD0 File Offset: 0x00009CD0
		private void picCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.rowHeight == 0)
			{
				this.rowHeight = (int)this.GL.RowHeight(this.picCanvas.CreateGraphics());
			}
			int num = (e.Y - 40) / this.rowHeight - 1;
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

		// Token: 0x060000AB RID: 171 RVA: 0x0000ADAC File Offset: 0x00009DAC
		private void picCanvas_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.rowHeight == 0)
			{
				this.rowHeight = (int)this.GL.RowHeight(this.picCanvas.CreateGraphics());
			}
			int num = (e.Y - 40) / this.rowHeight - 1;
			if (num < this.AccountList.Count && num >= 0)
			{
				string text = ((GeneralLedger.Account)this.AccountList[num]).Name;
				text = text.Substring(0, text.IndexOf(" -"));
				KMIHelp.OpenDefinitions(text);
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000AE46 File Offset: 0x00009E46
		private void panProduct_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AE49 File Offset: 0x00009E49
		private void chkHalf1_CheckedChanged(object sender, EventArgs e)
		{
			this.CheckHalf(0, this.chkHalf1.Checked);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000AE5F File Offset: 0x00009E5F
		private void chkHalf2_CheckedChanged(object sender, EventArgs e)
		{
			this.CheckHalf(1, this.chkHalf2.Checked);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AE78 File Offset: 0x00009E78
		protected void CheckHalf(int half, bool check)
		{
			if (check)
			{
				this.chkProduct.Checked = false;
				if (half == 0)
				{
					this.chkHalf2.Checked = false;
				}
				if (half == 1)
				{
					this.chkHalf1.Checked = false;
				}
			}
			this.suppressUpdates = true;
			if (half == 0)
			{
				for (int i = 0; i < this.panProduct.Controls.Count / 2; i++)
				{
					((CheckBox)this.panProduct.Controls[i]).Checked = check;
				}
			}
			else
			{
				for (int i = this.panProduct.Controls.Count / 2; i < this.panProduct.Controls.Count; i++)
				{
					((CheckBox)this.panProduct.Controls[i]).Checked = check;
				}
			}
			this.suppressUpdates = false;
			this.UpdateForm();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AF7C File Offset: 0x00009F7C
		private void chkProduct_Click(object sender, EventArgs e)
		{
			if (this.chkProduct.Checked)
			{
				this.chkHalf2.Checked = false;
				this.chkHalf1.Checked = false;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000AFB8 File Offset: 0x00009FB8
		private void frmSales_Load(object sender, EventArgs e)
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
				this.optGraph.Checked = true;
				this.optDollars.Checked = true;
				this.optTableGraph_Click(new object(), new EventArgs());
				this.optDollarsUnits_Click(new object(), new EventArgs());
				if (!S.MF.IsWin98)
				{
					this.toolTip1.SetToolTip(this.btnPrint, "Print");
					this.toolTip1.SetToolTip(this.btnExport, "Export to Excel");
				}
				this.chkHalf1.Text = S.R.GetString("Products {0}-{1}", new object[]
				{
					1,
					this.GL.ProductNames.Length / 2
				});
				this.chkHalf2.Text = S.R.GetString("Products {0}-{1}", new object[]
				{
					this.GL.ProductNames.Length / 2 + 1,
					this.GL.ProductNames.Length
				});
				int num = 0;
				foreach (string text in this.GL.ProductNames)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Size = this.chkProduct.Size;
					checkBox.Left = this.chkProduct.Left;
					checkBox.Top = num * 13;
					checkBox.Font = this.panProduct.Font;
					this.panProduct.Controls.Add(checkBox);
					checkBox.Text = text;
					checkBox.CheckedChanged += this.chkProduct_CheckedChanged;
					num++;
				}
				ArrayList productAccountBaseNames = this.GL.ProductAccountBaseNames;
				this.grpData.Controls.Clear();
				for (int j = 0; j < productAccountBaseNames.Count; j++)
				{
					CheckBox checkBox2 = new CheckBox();
					checkBox2.Size = this.chkData.Size;
					checkBox2.Left = this.chkData.Left + j / 3 * this.chkData.Width;
					checkBox2.Top = j % 3 * 18 + this.chkData.Top;
					this.grpData.Controls.Add(checkBox2);
					checkBox2.Text = (string)productAccountBaseNames[j];
					checkBox2.CheckedChanged += this.chkData_CheckedChanged;
				}
				((CheckBox)this.grpData.Controls[0]).Checked = true;
				this.chkProduct.Checked = true;
				this.panCanvas_Resize(new object(), new EventArgs());
				this.loaded = true;
				this.UpdateForm();
			}
		}

		// Token: 0x0400009D RID: 157
		protected MenuItem enablingReference;

		// Token: 0x0400009E RID: 158
		private GeneralLedger GL;

		// Token: 0x0400009F RID: 159
		private int currentWeek;

		// Token: 0x040000A0 RID: 160
		protected GeneralLedger.Frequency frequency = GeneralLedger.Frequency.Weekly;

		// Token: 0x040000A1 RID: 161
		protected bool loaded;

		// Token: 0x040000A2 RID: 162
		protected ArrayList accountList;

		// Token: 0x040000A3 RID: 163
		protected ArrayList dataSeriesNames = new ArrayList();

		// Token: 0x040000A4 RID: 164
		protected ArrayList productNames = new ArrayList();

		// Token: 0x040000A5 RID: 165
		protected bool units;

		// Token: 0x040000A6 RID: 166
		protected int rowHeight = 0;

		// Token: 0x040000A7 RID: 167
		protected bool suppressUpdates = false;
	}
}
