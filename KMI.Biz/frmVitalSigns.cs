using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000011 RID: 17
	public partial class frmVitalSigns : Form
	{
		// Token: 0x06000071 RID: 113 RVA: 0x000077F1 File Offset: 0x000067F1
		public frmVitalSigns()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000780C File Offset: 0x0000680C
		protected virtual void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.UpdateForm();
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00007830 File Offset: 0x00006830
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00007848 File Offset: 0x00006848
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

		// Token: 0x06000075 RID: 117 RVA: 0x00007854 File Offset: 0x00006854
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

		// Token: 0x06000076 RID: 118 RVA: 0x0000789C File Offset: 0x0000689C
		protected virtual bool GetData()
		{
			try
			{
				this.input = ((BizStateAdapter)S.SA).getVitalSigns(S.MF.CurrentEntityID);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
				return false;
			}
			return true;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000078F4 File Offset: 0x000068F4
		protected virtual void UpdateForm()
		{
			try
			{
				this.labProfitLabel.Text = "Cumulative Profit";
				if (this.input.MultipleEntities)
				{
					Label label = this.labProfitLabel;
					label.Text = label.Text + " for All Your " + S.I.EntityName + "s";
				}
				this.labCumProfit.Text = Utilities.FC(this.input.CumProfit, S.I.CurrencyConversion);
				if (this.input.CumProfit < 0f)
				{
					this.labCumProfit.ForeColor = Color.Red;
				}
				else
				{
					this.labCumProfit.ForeColor = Color.Black;
				}
				this.kmiGraph1.Title = "Revenue";
				this.kmiGraph1.Legend = false;
				this.kmiGraph1.XAxisLabels = false;
				object[,] array = new object[2, 9];
				array[1, 0] = "";
				for (int i = 0; i < this.input.Sales.Length; i++)
				{
					array[1, i + 1] = this.input.Sales[i];
				}
				this.kmiGraph1.Draw(array);
				this.kmiGraph2.Title = "Profit";
				this.kmiGraph2.Legend = false;
				this.kmiGraph2.XAxisLabels = false;
				object[,] array2 = new object[2, 9];
				array2[1, 0] = "";
				for (int i = 0; i < this.input.Profit.Length; i++)
				{
					array2[1, i + 1] = this.input.Profit[i];
				}
				this.kmiGraph2.Draw(array2);
				this.kmiGraph3.Title = "Customers";
				this.kmiGraph3.Legend = false;
				this.kmiGraph3.XAxisLabels = false;
				this.kmiGraph3.YLabelFormat = "{0:N0}";
				this.kmiGraph3.MinimumYMax = 5f;
				object[,] array3 = new object[2, 9];
				array3[1, 0] = "";
				for (int i = 0; i < this.input.Customers.Length; i++)
				{
					array3[1, i + 1] = this.input.Customers[i];
				}
				this.kmiGraph3.Draw(array3);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008454 File Offset: 0x00007454
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000845E File Offset: 0x0000745E
		private void frmVitalSigns_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			S.MF.EntityChanged -= this.EntityChangedHandler;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00008490 File Offset: 0x00007490
		private void frmVitalSigns_Load(object sender, EventArgs e)
		{
			if (!base.DesignMode)
			{
				S.MF.NewWeek += this.NewWeekHandler;
				S.MF.EntityChanged += this.EntityChangedHandler;
				if (this.GetData())
				{
					this.UpdateForm();
				}
			}
		}

		// Token: 0x04000064 RID: 100
		public const int RECENTWEEKS = 8;

		// Token: 0x0400006C RID: 108
		protected MenuItem enablingReference;

		// Token: 0x0400006D RID: 109
		protected frmVitalSigns.Input input;

		// Token: 0x02000012 RID: 18
		[Serializable]
		public struct Input
		{
			// Token: 0x0400006E RID: 110
			public float[] Sales;

			// Token: 0x0400006F RID: 111
			public float[] Profit;

			// Token: 0x04000070 RID: 112
			public int[] Customers;

			// Token: 0x04000071 RID: 113
			public float CumProfit;

			// Token: 0x04000072 RID: 114
			public bool MultipleEntities;
		}
	}
}
