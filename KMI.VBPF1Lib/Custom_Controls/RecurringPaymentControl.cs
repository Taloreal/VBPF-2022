using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.VBPF1Lib.Custom_Controls
{
	/// <summary>
	/// Summary description for RecurringPayment.
	/// </summary>
	// Token: 0x020000AB RID: 171
	public class RecurringPaymentControl : UserControl
	{
		// Token: 0x06000516 RID: 1302 RVA: 0x00049C40 File Offset: 0x00048C40
		public RecurringPaymentControl()
		{
			this.InitializeComponent();
			for (int i = 0; i < 28; i++)
			{
				this.Day.Items.Add(i + 1);
			}
			this.Day.SelectedIndex = 0;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000517 RID: 1303 RVA: 0x00049C9C File Offset: 0x00048C9C
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
		// Token: 0x06000518 RID: 1304 RVA: 0x00049CD8 File Offset: 0x00048CD8
		private void InitializeComponent()
		{
			this.PayeeName = new Label();
			this.Amount = new TextBox();
			this.Day = new ComboBox();
			base.SuspendLayout();
			this.PayeeName.AutoSize = true;
			this.PayeeName.Location = new Point(8, 0);
			this.PayeeName.Name = "PayeeName";
			this.PayeeName.Size = new Size(0, 16);
			this.PayeeName.TabIndex = 0;
			this.Amount.Location = new Point(224, 0);
			this.Amount.Name = "Amount";
			this.Amount.Size = new Size(88, 20);
			this.Amount.TabIndex = 1;
			this.Amount.Text = "";
			this.Amount.TextAlign = HorizontalAlignment.Right;
			this.Day.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Day.Location = new Point(382, 0);
			this.Day.Name = "Day";
			this.Day.Size = new Size(40, 21);
			this.Day.TabIndex = 2;
			base.Controls.Add(this.Day);
			base.Controls.Add(this.Amount);
			base.Controls.Add(this.PayeeName);
			base.Name = "RecurringPayment";
			base.Size = new Size(424, 24);
			base.ResumeLayout(false);
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00049EB0 File Offset: 0x00048EB0
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00049E7C File Offset: 0x00048E7C
		public RecurringPayment RecurringPayment
		{
			get
			{
				if (this.Amount.Text != "")
				{
					float amount = float.Parse(this.Amount.Text);
					if (amount > 0f)
					{
						return new RecurringPayment
						{
							PayeeName = this.PayeeName.Text,
							Amount = amount,
							PayeeAccountNumber = this.PayeeAccountNumber,
							Day = (int)this.Day.SelectedItem
						};
					}
				}
				return null;
			}
			set
			{
				this.Amount.Text = value.Amount.ToString("N2");
				this.Day.SelectedIndex = value.Day - 1;
			}
		}

		// Token: 0x0400061A RID: 1562
		public Label PayeeName;

		// Token: 0x0400061B RID: 1563
		public TextBox Amount;

		// Token: 0x0400061C RID: 1564
		public ComboBox Day;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400061D RID: 1565
		private Container components = null;

		// Token: 0x0400061E RID: 1566
		public long PayeeAccountNumber;
	}
}
