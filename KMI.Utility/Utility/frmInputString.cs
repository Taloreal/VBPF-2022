using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x02000010 RID: 16
	public partial class frmInputString : Form
	{
		// Token: 0x06000098 RID: 152 RVA: 0x000067EC File Offset: 0x000057EC
		public frmInputString(string title, string text, string defaultResponse)
		{
			this.InitializeComponent();
			this.Text = title;
			this.labText.Text = text;
			this.txtResponse.Text = defaultResponse;
			this.RequireResponse = true;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006B58 File Offset: 0x00005B58
		private void txtResponse_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtResponse.Text == "" && this.requireResponse)
			{
				MessageBox.Show("You must enter a value.", "Please Retry");
				e.Cancel = true;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006BA7 File Offset: 0x00005BA7
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.txtResponse.Text = "";
			base.Close();
		}

		// Token: 0x17000006 RID: 6
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00006BC2 File Offset: 0x00005BC2
		public bool RequireResponse
		{
			set
			{
				this.requireResponse = value;
				this.btnCancel.Visible = !this.requireResponse;
				base.ControlBox = !this.requireResponse;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00006BF4 File Offset: 0x00005BF4
		public string Response
		{
			get
			{
				return this.txtResponse.Text;
			}
		}

		// Token: 0x04000031 RID: 49
		protected bool requireResponse;
	}
}
