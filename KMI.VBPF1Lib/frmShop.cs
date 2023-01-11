using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;
using KMI.VBPF1Lib.Custom_Controls;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmShop.
	/// </summary>
	// Token: 0x02000098 RID: 152
	public partial class frmShop : Form
	{
		// Token: 0x060004B9 RID: 1209 RVA: 0x00043554 File Offset: 0x00042554
		public frmShop(string sellerName, ArrayList purchasableItems, bool car)
		{
			this.InitializeComponent();
			this.PurchasableItems = purchasableItems;
			this.Car = car;
			int i = 0;
			foreach (object obj in this.PurchasableItems)
			{
				PurchasableItem p = (PurchasableItem)obj;
				ItemListing c = new ItemListing(p);
				c.Top = i * c.Height;
				if (i % 2 == 0)
				{
					c.BackColor = Color.LightGray;
				}
				this.panListings.Controls.Add(c);
				i++;
			}
			this.sellerName = sellerName;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000439AF File Offset: 0x000429AF
		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x000439BC File Offset: 0x000429BC
		private void btnOK_Click(object sender, EventArgs e)
		{
			ArrayList itemNames = new ArrayList();
			string items = "";
			float totalPrice = 0f;
			foreach (object obj in this.panListings.Controls)
			{
				ItemListing c = (ItemListing)obj;
				if (c.chkBuy.Checked)
				{
					itemNames.Add(c.purchasableItem.Name);
					items = items + c.labName.Text + ", ";
					totalPrice += c.purchasableItem.Price;
				}
			}
			if (itemNames.Count > 0)
			{
				if (!this.CheckSimilarPurchase(itemNames))
				{
					items = Utilities.FormatCommaSeries(items);
					Bill bill = A.SA.CreateBill(this.sellerName, "", totalPrice, null);
					Form f;
					if (this.Car)
					{
						f = new frmPayForCar(bill, itemNames);
					}
					else
					{
						f = new frmPayBy(bill, itemNames);
					}
					f.ShowDialog(this);
					base.Close();
				}
			}
			else
			{
				MessageBox.Show(A.R.GetString("Please select one or more items to buy."), A.R.GetString("Input Required"));
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00043B2C File Offset: 0x00042B2C
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Shop For Goods"));
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00043B44 File Offset: 0x00042B44
		protected bool CheckSimilarPurchase(ArrayList items)
		{
			ArrayList temp = new ArrayList();
			foreach (object obj in items)
			{
				string s = (string)obj;
				if (!s.StartsWith("Art") && !s.StartsWith("Platter"))
				{
					string s2 = s.Substring(0, s.Length - 1);
					if (temp.Contains(s2))
					{
						string place = "apartment";
						if (s2 == "Car")
						{
							place = "garage";
						}
						MessageBox.Show(A.R.GetString("You are trying to purchase more than one {0}. There is room for only one in your {1}. Please modify your purchases.", new object[]
						{
							s2,
							place
						}));
						return true;
					}
					temp.Add(s2);
				}
			}
			return false;
		}

		// Token: 0x0400059B RID: 1435
		private string sellerName;

		// Token: 0x0400059C RID: 1436
		private ArrayList PurchasableItems;

		// Token: 0x0400059D RID: 1437
		private bool Car = false;
	}
}
