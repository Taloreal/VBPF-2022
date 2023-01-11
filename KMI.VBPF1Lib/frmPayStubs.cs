using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmPayStubs.
	/// </summary>
	// Token: 0x020000A6 RID: 166
	public partial class frmPayStubs : frmDrawnReport
	{
		// Token: 0x060004FC RID: 1276 RVA: 0x00048261 File Offset: 0x00047261
		public frmPayStubs()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000488E5 File Offset: 0x000478E5
		private void SynchBackNext()
		{
			this.btnBack.Enabled = (this.currentIndex > 0);
			this.btnNext.Enabled = (this.currentIndex < this.selectedForms.Count - 1);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0004891E File Offset: 0x0004791E
		private void btnNext_Click(object sender, EventArgs e)
		{
			this.currentIndex++;
			this.picReport.Refresh();
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0004893B File Offset: 0x0004793B
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.currentIndex--;
			this.picReport.Refresh();
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00048958 File Offset: 0x00047958
		private ArrayList UpdateSelectedForms(ArrayList forms)
		{
			ArrayList temp = new ArrayList();
			foreach (object obj in forms)
			{
				ITaxForm form = (ITaxForm)obj;
				if (form.Year() == (int)this.cboYear.SelectedItem)
				{
					temp.Add(form);
				}
			}
			return temp;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000489EC File Offset: 0x000479EC
		protected override void DrawReportVirtual(Graphics g)
		{
			if (this.selectedForms.Count == 0)
			{
				g.DrawString(A.R.GetString("No Forms Available for {0}", new object[]
				{
					this.cboYear.SelectedItem.ToString()
				}), frmPayStubs.font, frmPayStubs.brush, 30f, 30f);
			}
			else
			{
				ITaxForm t = (ITaxForm)this.selectedForms[this.currentIndex];
				t.Print(g);
			}
			this.SynchBackNext();
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00048A80 File Offset: 0x00047A80
		protected override void GetDataVirtual()
		{
			this.input = A.SA.GetTaxInfo(A.MF.CurrentEntityID);
			if (this.cboYear.Items.Count == 0)
			{
				for (int i = this.input.BeginYear; i <= this.input.EndYear; i++)
				{
					this.cboYear.Items.Add(i);
				}
				this.cboYear.SelectedIndex = this.cboYear.Items.Count - 1;
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00048B20 File Offset: 0x00047B20
		private void optShow_CheckedChanged(object sender, EventArgs e)
		{
			this.currentIndex = 0;
			if (this.optShow0.Checked)
			{
				this.selectedForms = this.UpdateSelectedForms(this.input.PayStubs);
				this.currentIndex = this.selectedForms.Count - 1;
			}
			if (this.optShow1.Checked)
			{
				this.selectedForms = this.UpdateSelectedForms(this.input.FW2s);
			}
			if (this.optShow2.Checked)
			{
				this.selectedForms = this.UpdateSelectedForms(this.input.F1099s);
			}
			this.picReport.Refresh();
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00048BD1 File Offset: 0x00047BD1
		private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.optShow_CheckedChanged(sender, e);
		}

		// Token: 0x040005FD RID: 1533
		private frmPayStubs.Input input;

		// Token: 0x040005FE RID: 1534
		private ArrayList selectedForms;

		// Token: 0x040005FF RID: 1535
		private int currentIndex = 0;

		// Token: 0x04000600 RID: 1536
		private static Font font = new Font("Arial", 8f);

		// Token: 0x04000601 RID: 1537
		private static Brush brush = new SolidBrush(Color.Black);

		// Token: 0x020000A7 RID: 167
		[Serializable]
		public struct Input
		{
			// Token: 0x04000602 RID: 1538
			public ArrayList PayStubs;

			// Token: 0x04000603 RID: 1539
			public ArrayList FW2s;

			// Token: 0x04000604 RID: 1540
			public ArrayList F1099s;

			// Token: 0x04000605 RID: 1541
			public int BeginYear;

			// Token: 0x04000606 RID: 1542
			public int EndYear;
		}
	}
}
