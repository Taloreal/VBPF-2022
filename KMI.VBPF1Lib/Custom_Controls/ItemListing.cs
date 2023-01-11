using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBPF1Lib.Custom_Controls
{
	/// <summary>
	/// Summary description for ShoppingItem.
	/// </summary>
	// Token: 0x02000009 RID: 9
	public class ItemListing : UserControl
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00003927 File Offset: 0x00002927
		public ItemListing()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003940 File Offset: 0x00002940
		public ItemListing(PurchasableItem p)
		{
			this.InitializeComponent();
			this.labDescription.Text = p.Description;
			this.labImage.Image = A.R.GetImage(p.ImageName);
			this.labName.Text = p.FriendlyName;
			this.labPrice.Text = Utilities.FC(p.Price, A.I.CurrencyConversion);
			if (p.saleDiscount > 0f)
			{
				this.labPrice.ForeColor = Color.Red;
				this.labOnSale.Visible = true;
			}
			this.purchasableItem = p;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000028 RID: 40 RVA: 0x00003A00 File Offset: 0x00002A00
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
		// Token: 0x06000029 RID: 41 RVA: 0x00003A3C File Offset: 0x00002A3C
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			this.labImage = new Label();
			this.panel2 = new Panel();
			this.labOnSale = new Label();
			this.chkBuy = new CheckBox();
			this.label4 = new Label();
			this.labPrice = new Label();
			this.panel3 = new Panel();
			this.labName = new Label();
			this.labDescription = new Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.labImage);
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(168, 104);
			this.panel1.TabIndex = 0;
			this.labImage.Dock = DockStyle.Fill;
			this.labImage.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labImage.Location = new Point(0, 0);
			this.labImage.Name = "labImage";
			this.labImage.Size = new Size(168, 104);
			this.labImage.TabIndex = 0;
			this.panel2.Controls.Add(this.labOnSale);
			this.panel2.Controls.Add(this.chkBuy);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.labPrice);
			this.panel2.Dock = DockStyle.Right;
			this.panel2.DockPadding.All = 15;
			this.panel2.Location = new Point(392, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(104, 104);
			this.panel2.TabIndex = 1;
			this.labOnSale.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labOnSale.ForeColor = Color.Red;
			this.labOnSale.Location = new Point(12, 36);
			this.labOnSale.Name = "labOnSale";
			this.labOnSale.Size = new Size(74, 16);
			this.labOnSale.TabIndex = 3;
			this.labOnSale.Text = "On Sale!";
			this.labOnSale.TextAlign = ContentAlignment.MiddleRight;
			this.labOnSale.Visible = false;
			this.chkBuy.Location = new Point(72, 56);
			this.chkBuy.Name = "chkBuy";
			this.chkBuy.Size = new Size(16, 20);
			this.chkBuy.TabIndex = 2;
			this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(12, 56);
			this.label4.Name = "label4";
			this.label4.Size = new Size(52, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Buy It!";
			this.label4.TextAlign = ContentAlignment.MiddleLeft;
			this.labPrice.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labPrice.Location = new Point(4, 15);
			this.labPrice.Name = "labPrice";
			this.labPrice.Size = new Size(84, 16);
			this.labPrice.TabIndex = 0;
			this.labPrice.TextAlign = ContentAlignment.MiddleRight;
			this.panel3.Controls.Add(this.labName);
			this.panel3.Controls.Add(this.labDescription);
			this.panel3.Dock = DockStyle.Fill;
			this.panel3.DockPadding.All = 15;
			this.panel3.Location = new Point(168, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(224, 104);
			this.panel3.TabIndex = 2;
			this.labName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labName.Location = new Point(8, 4);
			this.labName.Name = "labName";
			this.labName.Size = new Size(208, 28);
			this.labName.TabIndex = 1;
			this.labDescription.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labDescription.Location = new Point(8, 36);
			this.labDescription.Name = "labDescription";
			this.labDescription.Size = new Size(204, 56);
			this.labDescription.TabIndex = 0;
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "ItemListing";
			base.Size = new Size(496, 104);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400002A RID: 42
		private Panel panel1;

		// Token: 0x0400002B RID: 43
		private Panel panel2;

		// Token: 0x0400002C RID: 44
		private Panel panel3;

		// Token: 0x0400002D RID: 45
		private Label label4;

		// Token: 0x0400002E RID: 46
		private Label labImage;

		// Token: 0x0400002F RID: 47
		private Label labDescription;

		// Token: 0x04000030 RID: 48
		private Label labPrice;

		// Token: 0x04000031 RID: 49
		public CheckBox chkBuy;

		// Token: 0x04000032 RID: 50
		public Label labName;

		// Token: 0x04000033 RID: 51
		private Label labOnSale;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000034 RID: 52
		private Container components = null;

		// Token: 0x04000035 RID: 53
		public PurchasableItem purchasableItem;
	}
}
