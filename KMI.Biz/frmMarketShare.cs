using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000013 RID: 19
	public partial class frmMarketShare : Form
	{
		// Token: 0x0600007D RID: 125 RVA: 0x000084ED File Offset: 0x000074ED
		public frmMarketShare()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008508 File Offset: 0x00007508
		protected void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000852C File Offset: 0x0000752C
		protected bool GetData()
		{
			try
			{
				this.graphData = ((BizStateAdapter)S.SA).GetMarketShare();
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
				return false;
			}
			return true;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00008D10 File Offset: 0x00007D10
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00008D1A File Offset: 0x00007D1A
		private void optLineGraph_Click(object sender, EventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00008D24 File Offset: 0x00007D24
		private void optPieGraph_Click(object sender, EventArgs e)
		{
			this.UpdateForm();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00008D30 File Offset: 0x00007D30
		protected void UpdateForm()
		{
			try
			{
				if (this.graphData == null)
				{
					this.marketGraph.Visible = false;
				}
				else
				{
					this.marketGraph.Visible = true;
					if (this.optLineGraph.Checked)
					{
						this.marketGraph.GraphType = 1;
						this.marketGraph.Title = "Share of Revenue -- Last " + this.graphData.GetUpperBound(1) + " Weeks";
					}
					else
					{
						this.marketGraph.GraphType = 4;
						this.marketGraph.Title = "Share of Revenue -- Last Week";
					}
					this.marketGraph.Draw(this.graphData);
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00008E14 File Offset: 0x00007E14
		private void frmMarketShare_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00008E30 File Offset: 0x00007E30
		private void frmMarketShare_Load(object sender, EventArgs e)
		{
			S.MF.NewWeek += this.NewWeekHandler;
			this.optLineGraph.Checked = true;
			this.optPieGraph.Checked = false;
			this.marketGraph.YLabelFormat = "{0:0%}";
			if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00008E94 File Offset: 0x00007E94
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0400007D RID: 125
		protected object[,] graphData;
	}
}
