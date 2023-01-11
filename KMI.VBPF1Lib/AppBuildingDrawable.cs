using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for AppBuildingDrawable.
	/// </summary>
	// Token: 0x02000022 RID: 34
	[Serializable]
	public class AppBuildingDrawable : BuildingDrawable
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00010A90 File Offset: 0x0000FA90
		public AppBuildingDrawable(Point location, string imageName, BuildingType bldgType, int avenue, int street, int lot, long ownerID, ArrayList offerings, string clickString, bool isOwnersDwelling) : base(location, imageName, bldgType, avenue, street, lot, ownerID, 0f, 0f, "")
		{
			base.VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom;
			this.Offerings = offerings;
			this.clickString = clickString;
			this.OwnerID = ownerID;
			this.IsOwnersDwelling = isOwnersDwelling;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00010AE8 File Offset: 0x0000FAE8
		public override void DrawSelected(Graphics g)
		{
			if (this.clickString != null && this.clickString != "")
			{
				Point topCenter = new Point(this.location.X + this.Size.Width / 2 + this.offsetX, this.location.Y + this.offsetY + this.Size.Height / 3);
				Font font = new Font("Arial", 8f);
				Utilities.DrawComment(g, this.clickString, topCenter, Rectangle.Round(g.VisibleClipBounds), 300, font, Color.SteelBlue);
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00010BA0 File Offset: 0x0000FBA0
		private void DeletionHandler(object sender, EventArgs e)
		{
			int index = ((MenuItem)sender).Index;
			int i = 0;
			foreach (object obj in this.Offerings)
			{
				Offering o = (Offering)obj;
				if (index == 0 || index - 1 == i++)
				{
					A.SA.DeleteOffering(o.ID);
				}
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00010C3C File Offset: 0x0000FC3C
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (A.MF.DesignerMode)
			{
				if (MessageBox.Show("Delete offerings?", "Designer Mode", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					ContextMenu m2 = new ContextMenu();
					m2.MenuItems.Add(new MenuItem("All", new EventHandler(this.DeletionHandler)));
					for (int i = 0; i < this.Offerings.Count; i++)
					{
						m2.MenuItems.Add(new MenuItem((i + 1).ToString(), new EventHandler(this.DeletionHandler)));
					}
					m2.Show(A.MF, base.Location);
					return;
				}
			}
			ContextMenu j = new ContextMenu();
			switch (this.BuildingType.Index)
			{
			case 0:
				return;
			case 5:
				j.MenuItems.Add(A.R.GetString("Enter"), new EventHandler(this.EnterHandler));
				foreach (object obj in this.Offerings)
				{
					Course c = (Course)obj;
					j.MenuItems.Add(A.R.GetString("Enroll in {0}", new object[]
					{
						c.Name
					}), new EventHandler(this.CourseHandler));
				}
				this.Enable(j, A.MF.mnuActionsIncomeEducation);
				goto IL_88D;
			case 6:
				j.MenuItems.Add(A.R.GetString("Shop"), new EventHandler(this.ShopBusTokensHandler));
				this.Enable(j, A.MF.mnuActionsShopBusTokens);
				goto IL_88D;
			case 8:
				j.MenuItems.Add(A.R.GetString("Open Checking Account"), new EventHandler(this.BankHandler));
				j.MenuItems.Add(A.R.GetString("Open Savings Account"), new EventHandler(this.BankHandler));
				j.MenuItems.Add(A.R.GetString("Apply for Credit Card"), new EventHandler(this.BankHandler));
				j.MenuItems.Add("-");
				j.MenuItems.Add(A.R.GetString("Deposit Funds"), new EventHandler(this.BankHandler));
				j.MenuItems.Add(A.R.GetString("Withdraw Funds"), new EventHandler(this.BankHandler));
				j.MenuItems.Add(A.R.GetString("Transfer Funds"), new EventHandler(this.BankHandler));
				j.MenuItems.Add("-");
				j.MenuItems.Add(A.R.GetString("Close Account"), new EventHandler(this.BankHandler));
				this.Enable(j, A.MF.mnuActionsMMBanking);
				goto IL_88D;
			case 9:
				j.MenuItems.Add(A.R.GetString("Shop for Car"), new EventHandler(this.CarShopHandler));
				j.MenuItems.Add(A.R.GetString("Sell Car"), new EventHandler(this.SellCarHandler));
				this.Enable(j, A.MF.mnuActionsCreditShopForCar);
				goto IL_88D;
			case 10:
				goto IL_88D;
			case 11:
				j.MenuItems.Add(A.R.GetString("Healthcare"), new EventHandler(this.InsuranceHandler));
				j.MenuItems.Add(A.R.GetString("Renters"), new EventHandler(this.InsuranceHandler));
				j.MenuItems.Add(A.R.GetString("Homeowners"), new EventHandler(this.InsuranceHandler));
				j.MenuItems.Add(A.R.GetString("Automobile"), new EventHandler(this.InsuranceHandler));
				this.Enable(j, A.MF.mnuActionsInsurance);
				goto IL_88D;
			case 12:
				j.MenuItems.Add(A.R.GetString("Shop"), new EventHandler(this.ShopHandler));
				this.Enable(j, A.MF.mnuActionsCreditForGoods);
				goto IL_88D;
			case 13:
				j.MenuItems.Add(A.R.GetString("Shop"), new EventHandler(this.ShopFoodHandler));
				this.Enable(j, A.MF.mnuActionsCreditShopForFood);
				goto IL_88D;
			case 14:
				j.MenuItems.Add(A.R.GetString("Subscribe to Internet Access ($45-$55/mo)"), new EventHandler(this.InternetSubscribeHandler));
				j.MenuItems.Add(A.R.GetString("Cancel Subscription"), new EventHandler(this.InternetUnSubscribeHandler));
				this.Enable(j, A.MF.mnuActionsCreditInternet);
				goto IL_88D;
			case 15:
				j.MenuItems.Add(A.R.GetString("Shop"), new EventHandler(this.ShopAutoRepairHandler));
				this.Enable(j, A.MF.mnuActionsCreditShopForGas);
				goto IL_88D;
			case 16:
				j.MenuItems.Add(A.R.GetString("Research Funds"), new EventHandler(this.InvestmentAccountsHandler));
				j.MenuItems.Add(A.R.GetString("View Portfolio"), new EventHandler(this.InvestmentAccountsHandler));
				j.MenuItems.Add(A.R.GetString("View Retirement Portfolio"), new EventHandler(this.InvestmentAccountsHandler));
				this.Enable(j, A.MF.mnuActionsInvestingResearchFunds);
				goto IL_88D;
			}
			j.MenuItems.Add(A.R.GetString("Enter"), new EventHandler(this.EnterHandler));
			int k = 1;
			foreach (object obj2 in this.Offerings)
			{
				Offering o = (Offering)obj2;
				if (o is Job)
				{
					j.MenuItems.Add(A.R.GetString("Apply for Job {0}", new object[]
					{
						k
					}), new EventHandler(this.JobHandler));
					if (!o.Taken)
					{
						k++;
					}
					else
					{
						j.MenuItems[j.MenuItems.Count - 1].Visible = false;
					}
					this.Enable(j, A.MF.mnuActionsIncomeWork);
				}
				else if (o is DwellingOffer)
				{
					if (((DwellingOffer)o).Condo)
					{
						if (!o.Taken)
						{
							j.MenuItems.Add(A.R.GetString("Buy Condo"), new EventHandler(this.BuyCondoHandler));
						}
						else if (this.OwnerID == A.MF.CurrentEntityID)
						{
							if (!this.IsOwnersDwelling)
							{
								j.MenuItems.Add("Move to Condo", new EventHandler(this.MoveToCondoHandler));
								j.MenuItems.Add("Sell Condo", new EventHandler(this.SellCondoHandler));
							}
							j.MenuItems.Add("Change Insurance", new EventHandler(this.HomeOwnersHandler));
						}
					}
					else if (!o.Taken)
					{
						j.MenuItems.Add(A.R.GetString("Rent Apartment"), new EventHandler(this.DwellingHandler));
					}
					this.Enable(j, A.MF.mnuActionsLivingHousing);
				}
			}
			IL_88D:
			if (this.BuildingType.Index == 4 || this.BuildingType.Index == 17 || this.BuildingType.Index == 2 || this.BuildingType.Index == 3 || this.BuildingType.Index == 18 || this.BuildingType.Index == 19)
			{
				j.MenuItems[0].Visible = false;
			}
			if (j.MenuItems.Count == 1 && j.MenuItems[0].Enabled && j.MenuItems[0].Visible)
			{
				j.MenuItems[0].PerformClick();
			}
			else
			{
				j.Show(A.MF.picMain, base.Location);
			}
			KMI.Sim.View.ClearCurrentHit();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000115F0 File Offset: 0x000105F0
		private void DwellingHandler(object sender, EventArgs e)
		{
			try
			{
				int index = ((MenuItem)sender).Index;
				DwellingOffer offering = (DwellingOffer)this.Offerings[index - 1];
				if (!A.SA.HasEntity(A.I.ThisPlayerName))
				{
					Form f = new frmChooseCharacter(A.I.ThisPlayerName);
					f.ShowDialog(A.MF);
				}
				string msg = A.SA.GetMovingMessage(A.MF.CurrentEntityID, offering);
				if (msg == null || MessageBox.Show(msg, "Confirm Move", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					A.SA.AddOffering(A.MF.CurrentEntityID, offering.ID, null);
					MessageBox.Show("Congratulations! You got the apartment!", "Got Apartment");
				}
				A.MF.UpdateView();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000116E8 File Offset: 0x000106E8
		private void BuyCondoHandler(object sender, EventArgs e)
		{
			try
			{
				int index = ((MenuItem)sender).Index;
				DwellingOffer offering = (DwellingOffer)this.Offerings[index - 1];
				frmMortgage f = new frmMortgage(offering);
				if (f.ShowDialog(A.MF) == DialogResult.OK)
				{
					if (MessageBox.Show("Do you want to move into your new condo at this time? If you have any months left on an existing lease, you will be charged for them.", "Confirm Move", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						A.SA.MoveTo(A.MF.CurrentEntityID, offering.ID);
					}
					MessageBox.Show("Congratulations. You bought yourself a condo!", "Got Condo");
				}
			}
			catch (EntityNotFoundException ex)
			{
				MessageBox.Show(A.R.GetString("You do not have enough money to buy a condo. Get an apartment first."), A.R.GetString("Condo Purchase"));
			}
			catch (Exception ex2)
			{
				frmExceptionHandler.Handle(ex2);
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000117D8 File Offset: 0x000107D8
		private void MoveToCondoHandler(object sender, EventArgs e)
		{
			try
			{
				int index = ((MenuItem)sender).Index;
				DwellingOffer offering = (DwellingOffer)this.Offerings[0];
				if (MessageBox.Show("Are you sure you want to move? If you have any months left on an existing lease, you will be charged for them.", "Confirm Move", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					A.SA.MoveTo(A.MF.CurrentEntityID, offering.ID);
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0001185C File Offset: 0x0001085C
		private void SellCondoHandler(object sender, EventArgs e)
		{
			try
			{
				int index = ((MenuItem)sender).Index;
				DwellingOffer offering = (DwellingOffer)this.Offerings[0];
				string dealMessage = A.SA.GetCondoPrice(A.MF.CurrentEntityID, offering);
				if (MessageBox.Show(dealMessage, A.R.GetString("Confirm Sale"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					A.SA.SellCondo(A.MF.CurrentEntityID, offering);
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000118F8 File Offset: 0x000108F8
		private void JobHandler(object sender, EventArgs e)
		{
			try
			{
				int index = ((MenuItem)sender).Index;
				Job offering = (Job)this.Offerings[index - 1];
				frmJobApplication f2 = new frmJobApplication();
				if (f2.ShowDialog(A.MF) == DialogResult.OK)
				{
					AppBuildingDrawable.AddOfferingInfo result = A.SA.AddOffering(A.MF.CurrentEntityID, offering.ID, f2.JobApp);
					MessageBox.Show("Congratulations! You got the job!  Your employer needs a little more information so you can get paid properly...", "Got Job");
					Form f3 = new frmMethodOfPay(result.TaskID);
					f3.ShowDialog();
					f3 = new frmW4(result.TaskID);
					f3.ShowDialog();
					if (result.IsFirstTravel)
					{
						AppBuildingDrawable.PickTravelMode();
					}
					if (((WorkTask)offering.PrototypeTask).R401KMatch > -1f)
					{
						if (MessageBox.Show("This job offers a 401K retirement savings plan. Would you like to participate? If you answer yes, you will be asked how you want to allocate your investments.", "401K Plan", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							Form f4 = new frm401K(result.TaskID);
							f4.ShowDialog(A.MF);
						}
					}
				}
				A.MF.UpdateView();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00011A50 File Offset: 0x00010A50
		private void CourseHandler(object sender, EventArgs e)
		{
			try
			{
				int index = ((MenuItem)sender).Index;
				Course offering = (Course)this.Offerings[index - 1];
				frmStudentLoan f = new frmStudentLoan(offering);
				f.ShowDialog(A.MF);
				A.MF.UpdateView();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00011AC0 File Offset: 0x00010AC0
		private void BankHandler(object sender, EventArgs e)
		{
			try
			{
				switch (((MenuItem)sender).Index)
				{
				case 0:
				{
					frmOpenBankAccount f = new frmOpenBankAccount(this.Avenue, this.Street, this.Lot, true);
					f.ShowDialog(A.MF);
					break;
				}
				case 1:
				{
					frmOpenBankAccount f = new frmOpenBankAccount(this.Avenue, this.Street, this.Lot, false);
					f.ShowDialog(A.MF);
					break;
				}
				case 2:
				{
					CreditCardAccount offer = A.SA.GetCreditCardOffer(A.MF.CurrentEntityID, (CreditCardAccount)this.Offerings[2]);
					string dealMessage = A.R.GetString("We are pleased to offer you a {0} credit card at low {1} APR!. High credit limit of {2}. Late payment fee is {3}. Would you like to receive this card?", new object[]
					{
						offer.BankName,
						Utilities.FP(offer.InterestRate),
						Utilities.FC(offer.CreditLimit, A.I.CurrencyConversion),
						Utilities.FC(offer.LatePaymentFee, A.I.CurrencyConversion)
					});
					if (MessageBox.Show(dealMessage, A.R.GetString("Credit Card Offer"), MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						A.SA.SetCreditCardAccount(A.MF.CurrentEntityID, offer);
						MessageBox.Show(A.R.GetString("Your card has been issued."), A.R.GetString("Congratulations!"));
					}
					break;
				}
				case 4:
					MessageBox.Show(A.R.GetString("To deposit cash, click on the cash pile on your desk in your apartment. To deposit checks, click on the pile of checks on your desk in your apartment."), A.R.GetString("Deposit Funds"));
					break;
				case 5:
				{
					Form f2 = new frmDepositWithdrawCash(((BankAccount)this.Offerings[0]).BankName, true);
					f2.ShowDialog(A.MF);
					break;
				}
				case 6:
				{
					Form f3 = new frmTransferFunds(((BankAccount)this.Offerings[0]).BankName);
					f3.ShowDialog(A.MF);
					break;
				}
				case 8:
				{
					Form f4 = new frmCloseAccount(((BankAccount)this.Offerings[0]).BankName);
					f4.ShowDialog(A.MF);
					break;
				}
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00011D28 File Offset: 0x00010D28
		private void ShopHandler(object sender, EventArgs e)
		{
			try
			{
				ArrayList purchasableItems = A.SA.GetShop(A.MF.CurrentEntityID, this.BuildingID);
				string storeName = base.ClickString.Substring(0, base.ClickString.IndexOf(":"));
				frmShop f = new frmShop(storeName, purchasableItems, false);
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00011DA4 File Offset: 0x00010DA4
		private void ShopFoodHandler(object sender, EventArgs e)
		{
			A.MF.mnuActionsCreditShopForFood.PerformClick();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00011DB7 File Offset: 0x00010DB7
		private void ShopAutoRepairHandler(object sender, EventArgs e)
		{
			A.MF.mnuActionsCreditShopForGas.PerformClick();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00011DCA File Offset: 0x00010DCA
		private void ShopBusTokensHandler(object sender, EventArgs e)
		{
			A.MF.mnuActionsShopBusTokens.PerformClick();
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00011DDD File Offset: 0x00010DDD
		private void CarShopHandler(object sender, EventArgs e)
		{
			A.MF.mnuActionsCreditShopForCar.PerformClick();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00011DF0 File Offset: 0x00010DF0
		private void SellCarHandler(object sender, EventArgs e)
		{
			A.MF.mnuActionsCreditSellCar.PerformClick();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00011E04 File Offset: 0x00010E04
		private void InvestmentAccountsHandler(object sender, EventArgs e)
		{
			int index = ((MenuItem)sender).Index;
			if (index == 0)
			{
				A.MF.mnuActionsInvestingResearchFunds.PerformClick();
			}
			else if (index == 1)
			{
				A.MF.mnuActionsInvestingMyPortfolio.PerformClick();
			}
			else if (index == 2)
			{
				A.MF.mnuActionsInvestingRetirement.PerformClick();
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00011E74 File Offset: 0x00010E74
		private void EnterHandler(object sender, EventArgs e)
		{
			InsideView v = (InsideView)A.I.Views[1];
			v.ViewerOptions = new object[]
			{
				this.Avenue,
				this.Street,
				this.Lot
			};
			if (!S.I.Client)
			{
				A.ST.ViewerOptions1 = v.ViewerOptions;
			}
			v.SetBackground(this.BuildingType.Index);
			A.MF.OnViewChange(v.Name);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00011F10 File Offset: 0x00010F10
		private void InternetSubscribeHandler(object sender, EventArgs e)
		{
			try
			{
				A.SA.InternetSubscribe(A.MF.CurrentEntityID);
				MessageBox.Show("Your internet connection is now turned on.", "Confirm Subscription");
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00011F64 File Offset: 0x00010F64
		private void InternetUnSubscribeHandler(object sender, EventArgs e)
		{
			try
			{
				A.SA.InternetUnSubscribe(A.MF.CurrentEntityID);
				MessageBox.Show("Your internet connection is now turned off.", "Confirm Cancellation");
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00011FB8 File Offset: 0x00010FB8
		public void Enable(ContextMenu m, MenuItem mainMenuItem)
		{
			foreach (object obj in m.MenuItems)
			{
				MenuItem sub = (MenuItem)obj;
				if (sub.Text != A.R.GetString("Enter"))
				{
					sub.Enabled = mainMenuItem.Enabled;
				}
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00012044 File Offset: 0x00011044
		public static void PickTravelMode()
		{
			MessageBox.Show(A.R.GetString("Since this is your first activity outside your home, you will be asked to choose a mode of transportation."), "Travel Mode");
			frmTransportation f = new frmTransportation();
			f.ShowDialog();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0001207C File Offset: 0x0001107C
		private void InsuranceHandler(object sender, EventArgs e)
		{
			try
			{
				switch (((MenuItem)sender).Index)
				{
				case 0:
					A.MF.mnuActionsInsuranceHealth.PerformClick();
					break;
				case 1:
					A.MF.mnuActionsInsuranceRenters.PerformClick();
					break;
				case 2:
					A.MF.mnuActionsInsuranceHomeowners.PerformClick();
					break;
				case 3:
					A.MF.mnuActionsInsuranceAuto.PerformClick();
					break;
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00012118 File Offset: 0x00011118
		private void HomeOwnersHandler(object sender, EventArgs e)
		{
			try
			{
				frmHomeOwnersInsurance f = new frmHomeOwnersInsurance((Offering)this.Offerings[0]);
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0400011D RID: 285
		public ArrayList Offerings;

		// Token: 0x0400011E RID: 286
		public bool IsOwnersDwelling;

		// Token: 0x0400011F RID: 287
		public long BuildingID;

		// Token: 0x02000023 RID: 35
		[Serializable]
		public struct AddOfferingInfo
		{
			// Token: 0x04000120 RID: 288
			public bool IsFirstTravel;

			// Token: 0x04000121 RID: 289
			public long TaskID;
		}
	}
}
