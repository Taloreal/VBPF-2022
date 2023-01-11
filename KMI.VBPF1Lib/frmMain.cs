using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// The applications Main Form.
	/// </summary>
	// Token: 0x0200008E RID: 142
	public partial class frmMain : frmMainBase
	{
		/// <summary>
		/// Default Constructor.
		/// </summary>
		// Token: 0x06000455 RID: 1109 RVA: 0x0003CAE7 File Offset: 0x0003BAE7
		public frmMain()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Constructs the application's Main Form using the given
		/// Icon and arguments.
		/// </summary>
		/// <param name="args">Arguments to pass to this Form.</param>
		// Token: 0x06000456 RID: 1110 RVA: 0x0003CB00 File Offset: 0x0003BB00
		public frmMain(string[] args, bool demo, bool vbc, bool academic) : base(args, demo, vbc, academic)
		{
			this.InitializeComponent();
			this.Init();
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0003CB25 File Offset: 0x0003BB25
		public static void HandleError(Exception ex)
		{
			frmExceptionHandler.Handle(ex);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0003CB30 File Offset: 0x0003BB30
		public void Init()
		{
			KMIHelp.LocalPath = Application.StartupPath + "\\Help\\index.htm";
			KMIHelp.RemotePath = "http://help.knowledgematters.com/vbpf1/Help/index.htm";
			S.I.DataFileTypeExtension = "VBPF1";
			this.ScoreboardButton = this.scoreboardButton;
			S.I.EntityName = A.R.GetString("Career");
			City.BuildingTypes = (BuildingType[])TableReader.Read(base.GetType().Assembly, typeof(BuildingType), "KMI.VBPF1Lib.Data.BuildingTypes.txt");
			for (int i = 0; i < City.BuildingTypes.Length; i++)
			{
				City.BuildingTypes[i].Height = A.R.GetImage("Building" + i).Height;
			}
			this.EntityCriticalResourceNamePanel.Text = A.R.GetString("Net Worth");
			this.CurrentEntityNamePanel.Text = "";
			S.I.SafeViewsForNoEntity.Add(S.I.Views[1].Name);
			Journal.JournalSeriesName = A.R.GetString("Net Worth");
			Journal.ScoreSeriesName = A.R.GetString("Net Worth");
			Journal.JournalNumericDataSeriesNames = new string[]
			{
				"Net Worth"
			};
			this.CurrentEntityPanel.MinWidth = 0;
			this.CurrentEntityPanel.Width = 0;
			this.mnuOptionsProvideFood.Visible = A.MF.DesignerMode;
			this.menuMessagesSep.Visible = false;
			S.I.DemoDuration = 180;
			this.tlbMain.labLogo.Image = A.R.GetImage("HRLogo");
			this.tlbMain.labLogo.Width = this.tlbMain.labLogo.Image.Width;
		}

		/// <summary>
		/// Constructs the application's Simulator.
		/// </summary>
		// Token: 0x06000459 RID: 1113 RVA: 0x0003CD19 File Offset: 0x0003BD19
		protected override void ConstructSimulator()
		{
			Simulator.InitSimulator(new AppFactory());
		}

		/// <summary>
		/// Displays the actions journal for the current entity.
		/// </summary>
		// Token: 0x0600045C RID: 1116 RVA: 0x0003E434 File Offset: 0x0003D434
		private void mnuReportsActionsJournal_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmActionsJournal(true)
			{
				EnablingReference = this.mnuReportsActionsJournal
			});
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0003E460 File Offset: 0x0003D460
		protected override void LoadStateHook()
		{
			base.LoadStateHook();
			A.I.Views[1].ViewerOptions = A.ST.ViewerOptions1;
			A.ST.UpdateCarAndGasData();
			foreach (object obj in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj;
				if (e.Reserved == null)
				{
					e.SetUpReserved();
				}
			}
			if (A.ST.RunToDate == DateTime.MinValue)
			{
				A.ST.RunToDate = DateTime.MaxValue;
			}
			if (A.SS.BlockMessagesContaining == null)
			{
				A.SS.BlockMessagesContaining = "";
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0003E55C File Offset: 0x0003D55C
		private void mnuActionsMMBillPaying_Click(object sender, EventArgs e)
		{
			try
			{
				frmPayBills f = new frmPayBills();
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0003E5A0 File Offset: 0x0003D5A0
		private void mnuActionsMMBanking_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("For all banking functions, switch to the City view, mouse-over the banks, and click for a menu of options.", A.R.GetImage("Building8"));
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0003E5D8 File Offset: 0x0003D5D8
		private void mnuReportsCreditCardStatements_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmCreditCardStatement();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0003E618 File Offset: 0x0003D618
		private void mnuReportsBankStatements_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmBankStatement();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0003E658 File Offset: 0x0003D658
		private void mnuActionsAutoInsurance_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmAutoInsurance();
				f.ShowDialog();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0003E694 File Offset: 0x0003D694
		private void mnuReportsHealth_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmHealth2
				{
					EnablingReference = this.mnuReportsHealth
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0003E6E0 File Offset: 0x0003D6E0
		private void mnuActionsLivingHousing_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To select housing, switch to the City view, mouse-over the apartment buildings, and click to rent.", A.R.GetImage("Building1"));
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0003E716 File Offset: 0x0003D716
		private void mnuActionsIncomeEducation_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To find courses, switch to the City view, mouse-over the university buildings, and click to enroll.", A.R.GetImage("Building5"));
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0003E74C File Offset: 0x0003D74C
		private void mnuActionsIncomeWork_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To find jobs, switch to the City view, mouse-over possible workplaces, and click to apply.", A.R.GetImage("Building2"));
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0003E784 File Offset: 0x0003D784
		private void mnuActionsOnlineBanking_Click(object sender, EventArgs e)
		{
			frmOnlineBanking f = null;
			try
			{
				f = new frmOnlineBanking();
				f.ShowDialog();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, f);
			}
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0003E7C4 File Offset: 0x0003D7C4
		private void mnuReportsSnapshot_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmSnapshot
				{
					EnablingReference = this.mnuReportsSnapshot
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0003E810 File Offset: 0x0003D810
		private void mnuReportsWealth_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmPersonalBalanceSheet
				{
					EnablingReference = this.mnuReportsPersonalBalanceSheet
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0003E85C File Offset: 0x0003D85C
		private void mnuReportsTaxes_Click(object sender, EventArgs e)
		{
			frmTaxes f = null;
			try
			{
				f = new frmTaxes(frmTaxes.Mode.Past);
				string canUseMessage = f.CanUse();
				if (canUseMessage == "")
				{
					f.ShowDialog();
				}
				else
				{
					MessageBox.Show(canUseMessage, A.R.GetString("Taxes"));
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, f);
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0003E8D0 File Offset: 0x0003D8D0
		private void mnuActionsTaxes_Click(object sender, EventArgs e)
		{
			frmTaxes f = null;
			try
			{
				f = new frmTaxes(frmTaxes.Mode.Current);
				string canUseMessage = f.CanUse();
				if (canUseMessage == "")
				{
					f.ShowDialog();
				}
				else
				{
					MessageBox.Show(canUseMessage, A.R.GetString("Taxes"));
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, f);
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0003E944 File Offset: 0x0003D944
		private void mnuActionsLivingTimeMgt_Click(object sender, EventArgs e)
		{
			Form f = null;
			try
			{
				f = new frmDailyRoutine();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, f);
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0003E984 File Offset: 0x0003D984
		private void mnuReportsCreditScore_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmCreditScore
				{
					EnablingReference = this.mnuReportsCreditScore
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0003E9D0 File Offset: 0x0003D9D0
		public override void EnableDisable()
		{
			base.EnableDisable();
			try
			{
				if (!A.SA.HasEntity(A.I.ThisPlayerName) && !A.I.Host)
				{
					this.mnuActionsLivingHousing.Enabled = ((AppSimSettings)A.SA.getSimSettings()).ApartmentsForRentEnabledForOwner;
					if (this.mnuActionsLivingHousing.Enabled)
					{
						this.mnuActionsLiving.Enabled = true;
					}
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0003EA70 File Offset: 0x0003DA70
		private void mnuActionsLivingTransportation_Click(object sender, EventArgs e)
		{
			frmTransportation f = null;
			try
			{
				f = new frmTransportation();
				f.ShowDialog();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, f);
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0003EAB0 File Offset: 0x0003DAB0
		protected override void OnStateChangedHook()
		{
			base.OnStateChangedHook();
			A.I.Views[0].ViewerOptions = new object[]
			{
				0,
				0,
				PointF.Empty,
				A.I.ThisPlayerName
			};
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0003EB0C File Offset: 0x0003DB0C
		private void mnuReportsCheckbook_Click(object sender, EventArgs e)
		{
			Form f = null;
			try
			{
				f = new frmCheckbook();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, f);
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0003EB4C File Offset: 0x0003DB4C
		private void mnuReportsPayAndTaxRecords_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmPayStubs
				{
					EnablingReference = this.mnuReportsPayAndTaxRecords
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0003EB98 File Offset: 0x0003DB98
		private void mnuLoanStatements_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmLoanStatement();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0003EBD8 File Offset: 0x0003DBD8
		public void MessageBoxWithIcon(string message, Bitmap icon)
		{
			frmMessageBoxWithIcon f = new frmMessageBoxWithIcon(message, icon);
			f.ShowDialog(this);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0003EBF6 File Offset: 0x0003DBF6
		private void mnuActionsCreditCreditCards_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To get a credit card or close a credit account, switch to the City view, mouse-over the banks, and click for a menu of options.", A.R.GetImage("Building8"));
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0003EC2C File Offset: 0x0003DC2C
		private void mnuActionsCreditInternet_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To subscribe or unsubscribe to Internet access,  a credit account, mouse-over the internet access provider, and click for a menu of options.", A.R.GetImage("Building14"));
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0003EC64 File Offset: 0x0003DC64
		private void mnuActionsCreditShopForFood_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList purchasableItems = A.SA.GetShopFood(A.MF.CurrentEntityID);
				frmShop f = new frmShop(A.R.GetString("SuperMarket, Inc."), purchasableItems, false);
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0003ECCC File Offset: 0x0003DCCC
		private void mnuActionsCreditForGoods_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To shop for goods, click one or more of the department stores and compare prices.", A.R.GetImage("Building12"));
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0003ED04 File Offset: 0x0003DD04
		private void mnuActionsCreditShopForGas_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList purchasableItems = A.SA.GetShopAutoRepair(A.MF.CurrentEntityID);
				frmShop f = new frmShop(A.R.GetString("Gas & Repairs, Inc."), purchasableItems, false);
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0003ED6C File Offset: 0x0003DD6C
		private void mnuActionsCreditShopForCar_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList purchasableItems = A.SA.GetCarShop(A.MF.CurrentEntityID);
				frmShop f = new frmShop(A.R.GetString("Taranti Auto"), purchasableItems, true);
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0003EDD4 File Offset: 0x0003DDD4
		private void mnuActionsCreditSellCar_Click(object sender, EventArgs e)
		{
			try
			{
				string dealMessage = A.SA.GetCarPrice(A.MF.CurrentEntityID);
				if (MessageBox.Show(dealMessage, A.R.GetString("Confirm Sale"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					A.SA.SellCar(A.MF.CurrentEntityID);
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0003EE50 File Offset: 0x0003DE50
		private void mnuReportsInvestmentStatements_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmInvestmentStatement();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0003EE90 File Offset: 0x0003DE90
		public bool Disabled(MenuItem m)
		{
			if (!m.Enabled)
			{
				MessageBox.Show(A.R.GetString("The action, {0}, is not currently enabled.", new object[]
				{
					Utilities.NoEllipsis(m.Text)
				}), A.R.GetString("Action Not Enabled"));
			}
			return !m.Enabled;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0003EEF0 File Offset: 0x0003DEF0
		private void mnuActionsShopBusTokens_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList purchasableItems = A.SA.GetShopBusTokens(A.MF.CurrentEntityID);
				frmShop f = new frmShop(A.R.GetString("City Bus"), purchasableItems, false);
				f.ShowDialog(A.MF);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0003EF58 File Offset: 0x0003DF58
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.mnuView.Visible = false;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0003EF68 File Offset: 0x0003DF68
		private void mnuActionsInsuranceHealth_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmHealthInsurance();
				f.ShowDialog();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0003EFA4 File Offset: 0x0003DFA4
		private void mnuActionsInsuranceRenters_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmRentersInsurance();
				f.ShowDialog();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0003EFE0 File Offset: 0x0003DFE0
		private void mnuActionsIncomeWitholding_Click(object sender, EventArgs e)
		{
			MessageBox.Show("To change your witholding, click on the Schedule button, click the job, then click Witholding.", "Change Witholding");
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0003EFF3 File Offset: 0x0003DFF3
		private void mnuActionsIncomePayment_Click(object sender, EventArgs e)
		{
			MessageBox.Show("To change your method of payment, click on the Schedule button, click the job, then click Payment.", "Change Method of Payment");
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0003F008 File Offset: 0x0003E008
		private void mnuReportsResume_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmResume
				{
					EnablingReference = this.mnuReportsResume
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0003F054 File Offset: 0x0003E054
		private void mnuActionsIncome401K_Click(object sender, EventArgs e)
		{
			MessageBox.Show("To change your retirement contribution, click on the Schedule button, click the job, then click 401K.", "Change 401K Contribution");
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0003F068 File Offset: 0x0003E068
		private void mnuReportsRetirementStatements_Click(object sender, EventArgs e)
		{
			try
			{
				frmRetirementStatement f = new frmRetirementStatement();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0003F0A8 File Offset: 0x0003E0A8
		private void frmReportsCreditReport_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmCreditReport
				{
					EnablingReference = this.mnuReportsCreditReport
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0003F0F4 File Offset: 0x0003E0F4
		private void mnuActionsInsuranceHomeowners_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To change your homeowner's insurance on a condo you own, switch to the City view and click on the condo.", A.R.GetImage("Building1"));
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0003F12A File Offset: 0x0003E12A
		private void mnuActionsLivingCondo_Click(object sender, EventArgs e)
		{
			base.OnViewChange(A.I.Views[0].Name);
			this.MessageBoxWithIcon("To select housing, switch to the City view, mouse-over the apartment/condo buildings, and click for info on a buying condo.", A.R.GetImage("Building1"));
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0003F160 File Offset: 0x0003E160
		public void mnuActionsInvestingResearchFunds_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmResearchFunds(sender)
				{
					EnablingReference = this.mnuActionsInvestingResearchFunds
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0003F1AC File Offset: 0x0003E1AC
		private void mnuActionsInvestingMyPortfolio_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmMyPortfolio(false)
				{
					EnablingReference = this.mnuActionsInvestingMyPortfolio
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0003F1F8 File Offset: 0x0003E1F8
		private void menuItem10_Click(object sender, EventArgs e)
		{
			try
			{
				base.ShowNonModalForm(new frmMyPortfolio(true)
				{
					EnablingReference = this.mnuActionsInvestingMyPortfolio
				});
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0003F244 File Offset: 0x0003E244
		private void mnuOptionsLegend_Click(object sender, EventArgs e)
		{
			try
			{
				frmLegend f = new frmLegend();
				f.Location = new Point(base.Bounds.Right - f.Width - 6, base.Bounds.Top + 100);
				base.ShowNonModalForm(f);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0003F2B8 File Offset: 0x0003E2B8
		private void mnuOptionsProvideFood_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 5000; i++)
			{
				((AppEntity)A.ST.Entity[A.MF.CurrentEntityID]).Food.Add(A.ST.Now);
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0003F318 File Offset: 0x0003E318
		protected override void mnuOptionsIAProvideCash_Click(object sender, EventArgs e)
		{
			frmPassword f = new frmPassword(S.I.UserAdminSettings.GetP());
			if (base.DesignerMode || f.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					Form f2 = new frmAppProvideCash();
					f2.ShowDialog(this);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0003F388 File Offset: 0x0003E388
		public override int GetVBCStudentOrgCode()
		{
			return 4;
		}
	}
}
