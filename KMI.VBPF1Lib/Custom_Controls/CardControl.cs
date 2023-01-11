using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib.Custom_Controls
{
	/// <summary>
	/// Summary description for CardControl.
	/// </summary>
	// Token: 0x02000071 RID: 113
	public class CardControl : UserControl
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x00032ECA File Offset: 0x00031ECA
		public CardControl(BankAccount ba)
		{
			this.InitializeComponent();
			this.Account = ba;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002F4 RID: 756 RVA: 0x00032EEC File Offset: 0x00031EEC
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x060002F5 RID: 757 RVA: 0x00032F27 File Offset: 0x00031F27
		private void InitializeComponent()
		{
			base.Name = "CardControl";
			base.Size = new Size(204, 129);
			base.Load += this.CardControl_Load;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00032F5F File Offset: 0x00031F5F
		private void CardControl_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00032F64 File Offset: 0x00031F64
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Font f = new Font("Arial", 9f);
			Font f2 = new Font("Arial", 8f);
			Brush b = new SolidBrush(Color.White);
			Brush b2 = new SolidBrush(Color.Black);
			string prefix = "CCard";
			if (this.Account is CheckingAccount)
			{
				prefix = "DCard";
			}
			e.Graphics.DrawImageUnscaled(A.R.GetImage(prefix + this.Account.BankName), 2, 2);
			if (this.Selected)
			{
				e.Graphics.DrawRectangle(new Pen(b2, 5f), 0, 0, base.Width, base.Height);
			}
			e.Graphics.DrawString(this.Account.OwnerName, f, b, 20f, (float)(base.Height - 20));
			e.Graphics.DrawString("1234 5678 9012 " + this.Account.AccountNumber.ToString(), f, b, 40f, (float)(base.Height / 2 + 5));
			e.Graphics.DrawString("Expires 02/99", f2, b, 60f, (float)(base.Height / 2 + 28));
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x040003CC RID: 972
		private Container components = null;

		// Token: 0x040003CD RID: 973
		public BankAccount Account;

		// Token: 0x040003CE RID: 974
		public bool Selected;
	}
}
