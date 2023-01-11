using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using KMI.Sim.Academics;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200007E RID: 126
	public partial class frmMainBase : Form
	{
		// Token: 0x06000471 RID: 1137 RVA: 0x00020AF4 File Offset: 0x0001FAF4
		public frmMainBase()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00020B64 File Offset: 0x0001FB64
		public frmMainBase(string[] args, bool demo, bool vbc, bool academic)
		{
			frmLanguage frmLanguage = new frmLanguage();
			if (frmLanguage.LanguageCount > 0)
			{
				frmLanguage.ShowDialog(this);
			}
			this.InitializeComponent();
			this.isWin98 = (Environment.OSVersion.Platform != PlatformID.Win32NT);
			frmMainBase.instance = this;
			this.InitRemotingConfiguration();
			if (base.CreateGraphics().DpiX != 96f || base.CreateGraphics().DpiY != 96f)
			{
				MessageBox.Show("A DPI setting other than 96 was detected. This program is designed for 96 DPI and may not function properly. To correct this problem, change the DPI setting under Display on the Control Panel.", "Warning");
			}
			Cursor.Current = Cursors.WaitCursor;
			this.commandLineArgs = args;
			this.ConstructSimulator();
			S.I.VBC = vbc;
			S.I.Demo = demo;
			S.I.Academic = academic;
			if (S.I.VBC)
			{
				int vbcstudentOrgCode = this.GetVBCStudentOrgCode();
				if (vbcstudentOrgCode > 0)
				{
					WebRequest r = WebRequest.Create("http://vbc.knowledgematters.com/vbccommon/vbcvalidate.php?ss=" + vbcstudentOrgCode);
					string webPage = Utilities.GetWebPage(r, S.I.UserAdminSettings.ProxyAddress, S.I.UserAdminSettings.ProxyBypassList);
					if (!(webPage == "1"))
					{
						if (webPage == "")
						{
							MessageBox.Show("This special version of " + Application.ProductName + " could not connect to the Internet to confirm that a Virtual Business Challenge is currently running. Please check your Internet connection and try again.", "No Internet Connection");
							Application.Exit();
						}
						else
						{
							MessageBox.Show("There is no live challenge for " + Application.ProductName + " at this time.", "No Valid Virtual Business Challenge");
							Application.Exit();
						}
					}
				}
			}
			this.DesignerMode = false;
			foreach (View view in S.I.Views)
			{
				MenuItem item = new MenuItem(S.R.GetString(view.Name), new EventHandler(this.mnuViewView_Click));
				this.mnuView.MenuItems.Add(item);
			}
			this.mnuView.MenuItems.Add(new MenuItem("-"));
			this.CurrentEntityNamePanel.Text = S.R.GetString("Current") + " " + S.I.EntityName + ":";
			if (S.I.UserAdminSettings.NoSound)
			{
				this.mnuOptionsSoundEffects.Checked = false;
				this.mnuOptionsBackgroundMusic.Checked = false;
				this.mnuOptionsSoundEffects.Enabled = false;
				this.mnuOptionsBackgroundMusic.Enabled = false;
			}
			if (S.I.VBC)
			{
				this.mnuFileNew.Enabled = false;
				this.mnuFileOpenLesson.Enabled = false;
				this.mnuFileMultiplayerStart.Enabled = false;
				this.mnuFileMultiplayerJoin.Enabled = false;
			}
			if (S.I.Academic)
			{
				this.mnuFileOpenLesson.Visible = false;
				this.mnuFileMultiplayer.Visible = false;
				this.mnuOptionsTestResults.Visible = true;
			}
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00020F14 File Offset: 0x0001FF14
		public bool IsWin98
		{
			get
			{
				return this.isWin98;
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00020F2C File Offset: 0x0001FF2C
		public void AbortSession()
		{
			this.dirtySimState = false;
			this.mnuFileExit_Click(null, null);
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00020F40 File Offset: 0x0001FF40
		public static frmMainBase Instance
		{
			get
			{
				return frmMainBase.instance;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x0002263C File Offset: 0x0002163C
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x00022654 File Offset: 0x00021654
		public bool DirtySimState
		{
			get
			{
				return this.dirtySimState;
			}
			set
			{
				this.dirtySimState = value;
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0002265E File Offset: 0x0002165E
		public void SetDirty()
		{
			this.dirtySimState = true;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00022668 File Offset: 0x00021668
		protected virtual void UpdateStatusBar(SimStateAdapter.ViewUpdate viewUpdate)
		{
			this.Now = viewUpdate.Now;
			this.CurrentWeek = viewUpdate.CurrentWeek;
			this.EntityCriticalResourcePanel.Text = Utilities.FC(viewUpdate.Cash, S.I.CurrencyConversion);
			if (!S.I.Client && S.SS.LevelManagementOn)
			{
				this.Level.Text = S.R.GetString("Level {0}", new object[]
				{
					S.SS.Level.ToString()
				});
			}
			else
			{
				this.Level.Text = "";
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0002271C File Offset: 0x0002171C
		protected virtual void UpdateViewMenu(SimStateAdapter.ViewUpdate viewUpdate)
		{
			this.entityNames = viewUpdate.EntityNames;
			bool flag = false;
			int num = this.mnuView.MenuItems.Count - 1;
			while (num >= 0 && this.mnuView.MenuItems[num].Text != "-")
			{
				num--;
			}
			int num2 = num + 1;
			if (this.mnuView.MenuItems.Count - num2 != viewUpdate.EntityNames.Count)
			{
				flag = true;
			}
			else
			{
				int num3 = 0;
				foreach (object obj in viewUpdate.EntityNames.Values)
				{
					string b = (string)obj;
					if (this.mnuView.MenuItems[num2 + num3++].Text != b)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				num = this.mnuView.MenuItems.Count - 1;
				while (num >= 0 && this.mnuView.MenuItems[num].Text != "-")
				{
					this.mnuView.MenuItems.RemoveAt(num);
					num--;
				}
				foreach (object obj2 in viewUpdate.EntityNames.Values)
				{
					string text = (string)obj2;
					MenuItem menuItem = new MenuItem(text, new EventHandler(this.mnuViewEntity_Click));
					this.mnuView.MenuItems.Add(menuItem);
					menuItem.Checked = (menuItem.Text == this.EntityIDToName(this.CurrentEntityID));
				}
				this.CurrentEntityPanel.Text = this.EntityIDToName(this.CurrentEntityID);
				if (this.CurrentEntityID == -1L && viewUpdate.EntityNames.Count > 0)
				{
					IEnumerator enumerator = viewUpdate.EntityNames.Keys.GetEnumerator();
					//using (IEnumerator enumerator = viewUpdate.EntityNames.Keys.GetEnumerator())
					//{
						if (enumerator.MoveNext())
						{
							long entityID = (long)enumerator.Current;
							this.OnCurrentEntityChange(entityID);
						}
					//}
				}
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600047D RID: 1149 RVA: 0x000229F8 File Offset: 0x000219F8
		// (remove) Token: 0x0600047E RID: 1150 RVA: 0x00022A11 File Offset: 0x00021A11
		public event EventHandler NewHour;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600047F RID: 1151 RVA: 0x00022A2A File Offset: 0x00021A2A
		// (remove) Token: 0x06000480 RID: 1152 RVA: 0x00022A43 File Offset: 0x00021A43
		public event EventHandler NewDay;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000481 RID: 1153 RVA: 0x00022A5C File Offset: 0x00021A5C
		// (remove) Token: 0x06000482 RID: 1154 RVA: 0x00022A75 File Offset: 0x00021A75
		public event EventHandler NewWeek;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000483 RID: 1155 RVA: 0x00022A8E File Offset: 0x00021A8E
		// (remove) Token: 0x06000484 RID: 1156 RVA: 0x00022AA7 File Offset: 0x00021AA7
		public event EventHandler NewYear;

		// Token: 0x06000485 RID: 1157 RVA: 0x00022AC0 File Offset: 0x00021AC0
		private void FireNewTimeEvents(SimStateAdapter.ViewUpdate viewUpdate)
		{
			bool flag = this.Now != frmMainBase.DateNotSet && viewUpdate.Now.Year != this.Now.Year;
			bool flag2 = this.CurrentWeek != -1 && viewUpdate.CurrentWeek != this.CurrentWeek;
			bool flag3 = this.Now != frmMainBase.DateNotSet && (viewUpdate.Now.Day != this.Now.Day || viewUpdate.Now.Month != this.Now.Month || flag);
			bool flag4 = this.Now != frmMainBase.DateNotSet && (viewUpdate.Now.Hour != this.Now.Hour || flag3);
			if (flag4 && this.NewHour != null)
			{
				this.NewHour(this, new EventArgs());
			}
			if (flag3 && this.NewDay != null)
			{
				this.NewDay(this, new EventArgs());
			}
			if (flag2 && this.NewWeek != null)
			{
				this.NewWeek(this, new EventArgs());
				if (this.SoundOn)
				{
					Sound.PlaySoundFromFile("sounds\\NewWeek.wav");
				}
			}
			if (flag && this.NewYear != null)
			{
				this.NewYear(this, new EventArgs());
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00022C64 File Offset: 0x00021C64
		public Graphics BackBufferGraphics
		{
			get
			{
				return this.backBufferGraphics;
			}
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00022C7C File Offset: 0x00021C7C
		public void UpdateView()
		{
			SimStateAdapter.ViewUpdate viewUpdate = null;
			try
			{
				viewUpdate = S.SA.GetViewUpdate(this.CurrentViewName, this.CurrentEntityID, this.currentView.ViewerOptions);
			}
			catch (EntityNotFoundException ex)
			{
				this.OnCurrentEntityChange(ex.ExistingEntityID);
				this.UpdateView();
				return;
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e);
				return;
			}
			this.FireNewTimeEvents(viewUpdate);
			this.UpdateStatusBar(viewUpdate);
			this.UpdateViewMenu(viewUpdate);
			this.backBufferGraphics.Clear(Color.White);
			this.currentView.Drawables = viewUpdate.Drawables;
			this.currentView.Draw(this.backBufferGraphics);
			this.picMain.Refresh();
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00022D4C File Offset: 0x00021D4C
		protected internal void StopSimulation()
		{
			if (S.I.SimTimeRunning)
			{
				S.MF.mnuOptionsGoStop.PerformClick();
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00022D7C File Offset: 0x00021D7C
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x00022D94 File Offset: 0x00021D94
		public bool DesignerMode
		{
			get
			{
				return this.designerMode;
			}
			set
			{
				this.designerMode = value;
				this.mnuOptionsTuning.Visible = this.designerMode;
				this.mnuOptionsChangeOwner.Visible = this.designerMode;
				this.mnuOptionsMacros.Visible = this.designerMode;
				this.mnuOptionsRenameEntity.Visible = this.designerMode;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00022DF4 File Offset: 0x00021DF4
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x00022E0C File Offset: 0x00021E0C
		public string CurrentViewName
		{
			get
			{
				return this.currentViewName;
			}
			set
			{
				this.currentViewName = value;
				this.currentView = S.I.View(this.currentViewName);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x00022E2C File Offset: 0x00021E2C
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x00022E44 File Offset: 0x00021E44
		public long CurrentEntityID
		{
			get
			{
				return this.currentEntityID;
			}
			set
			{
				this.currentEntityID = value;
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00022E50 File Offset: 0x00021E50
		public string EntityIDToName(long ID)
		{
			string result;
			if (this.entityNames.ContainsKey(ID))
			{
				result = (string)this.entityNames[ID];
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x00022E98 File Offset: 0x00021E98
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x00022EB0 File Offset: 0x00021EB0
		public DateTime Now
		{
			get
			{
				return this.now;
			}
			set
			{
				this.now = value;
				if (this.now != frmMainBase.DateNotSet)
				{
					this.TimePanel.Text = this.now.ToShortTimeString();
					this.DayOfWeekPanel.Text = this.now.ToString("ddd");
					this.DatePanel.Text = this.now.ToString("MMMM dd, yyyy");
				}
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x00022F30 File Offset: 0x00021F30
		// (set) Token: 0x06000493 RID: 1171 RVA: 0x00022F48 File Offset: 0x00021F48
		public int CurrentWeek
		{
			get
			{
				return this.currentWeek;
			}
			set
			{
				this.currentWeek = value;
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00022F54 File Offset: 0x00021F54
		private void mnuFileNew_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			if (this.QuerySave())
			{
				if (S.I.Academic)
				{
					Form form = new frmChooseMathPack();
					form.ShowDialog();
				}
				DialogResult dialogResult = new frmDualChoiceDialog("What kind of " + S.I.NewWhatName.ToLower() + " would you like?", "Standard " + S.I.NewWhatName, "Random " + S.I.NewWhatName, true)
				{
					Text = "New " + S.I.EntityName + " Project"
				}.ShowDialog(this);
				if (dialogResult != DialogResult.Cancel)
				{
					SimSettings defaultSimSettings = S.I.DefaultSimSettings;
					if (dialogResult == DialogResult.Yes)
					{
						if (S.I.NewStandardProjectFromFile)
						{
							string filepath = string.Concat(new string[]
							{
								Application.StartupPath,
								"\\Project\\New ",
								S.I.EntityName,
								" Project.",
								S.I.DataFileTypeExtension
							});
							if (S.I.Academic)
							{
								filepath = string.Concat(new object[]
								{
									AcademicGod.PageBankPath,
									Path.DirectorySeparatorChar,
									"Project.",
									S.I.DataFileTypeExtension
								});
							}
							this.OpenSavedSim(filepath);
							this.lessonLoadedPromptSaveAs = true;
							return;
						}
						defaultSimSettings.RandomSeed = 0;
					}
					this.ReInit();
					this.currentFilePath = null;
					if (!this.DesignerMode || this.cacheDesignerSimSettings == null)
					{
						S.I.NewState(defaultSimSettings, false);
					}
					else
					{
						S.I.NewState(this.cacheDesignerSimSettings, false);
					}
					this.OnStateChanged();
					this.mnuOptionsGoStop.PerformClick();
				}
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00023190 File Offset: 0x00022190
		private void ReInit()
		{
			this.CloseOwnedForms();
			if (S.SA != null)
			{
				this.UnregisterClientEventHandlers();
			}
			if (this.DesignerMode && !S.I.Client && S.I.SimState != null)
			{
				this.cacheDesignerSimSettings = S.I.SimState.SimSettings;
			}
			S.I.SimState = null;
			S.I.PeriodicMessageTable.Clear();
			try
			{
				if (S.SA != null && !S.I.Client)
				{
					RemotingServices.Disconnect(S.SA);
				}
			}
			catch
			{
				throw new Exception("The state of the SimStateAdapter and the Client flag are somehow out of sync.");
			}
			S.I.Client = false;
			S.I.MultiplayerRoleName = "";
			this.CreateMessagePanel.Width = 0;
			S.I.SessionName = "";
			S.I.SimStateAdapter = S.I.SimFactory.CreateSimStateAdapter();
			S.I.ThisPlayerName = "";
			this.mnuFileSave.Enabled = true;
			this.mnuFileSaveAs.Enabled = true;
			this.mnuOptionsGoStop.Enabled = true;
			this.mnuOptionsFaster.Enabled = true;
			this.mnuOptionsSlower.Enabled = true;
			this.mnuOptionsIA.Enabled = true;
			this.mnuOptionsRunTo.Enabled = true;
			this.EnableMenuAndSubMenus(this.mnuReports);
			this.EnableMenuAndSubMenus(this.mnuActions);
			this.lessonLoadedPromptSaveAs = false;
			this.currentWeek = -1;
			this.Now = frmMainBase.DateNotSet;
			int num = this.mnuView.MenuItems.Count - 1;
			while (num >= 0 && this.mnuView.MenuItems[num].Text != "-")
			{
				this.mnuView.MenuItems.RemoveAt(num);
				num--;
			}
			this.CurrentViewName = S.I.Views[0].Name;
			this.CurrentEntityID = -1L;
			this.NewMessagesPanel.Width = 0;
			if (S.I.Messages)
			{
				this.messagesForm = new frmMessages();
				this.messagesForm.Owner = this;
				this.ShowMessageWindow();
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00023404 File Offset: 0x00022404
		private bool QuerySave()
		{
			bool result;
			if (S.I.Demo)
			{
				result = true;
			}
			else if (!this.dirtySimState || S.I.Client)
			{
				result = true;
			}
			else
			{
				DialogResult dialogResult = MessageBox.Show(S.I.Resource.GetString("MsgQuerySave"), Application.ProductName, MessageBoxButtons.YesNoCancel);
				if (dialogResult != DialogResult.Cancel)
				{
					switch (dialogResult)
					{
					case DialogResult.Yes:
						this.mnuFileSave_Click(new object(), new EventArgs());
						result = !this.dirtySimState;
						break;
					case DialogResult.No:
						this.dirtySimState = false;
						result = true;
						break;
					default:
						result = false;
						break;
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x000234BE File Offset: 0x000224BE
		private void mnuHelpTopicsAndIndex_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp();
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000234C7 File Offset: 0x000224C7
		private void mnuHelpTutorial_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp();
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x000234D0 File Offset: 0x000224D0
		public void mnuOptionsGoStop_Click(object sender, EventArgs e)
		{
			if (!S.I.SimTimeRunning)
			{
				this.dirtySimState = true;
				S.I.StartSimTimeRunning();
			}
			else
			{
				S.I.StopSimTimeRunning();
			}
			this.SynchGoStop();
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00023516 File Offset: 0x00022516
		protected void StartMusic()
		{
			this.backgroundMusicTimer.Stop();
			this.backgroundMusicTimer.Interval = S.I.BackgroundMusicLength;
			Sound.PlayMidiFromFile("sounds\\Background.Mid");
			this.backgroundMusicTimer.Start();
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00023552 File Offset: 0x00022552
		protected void StopMusic()
		{
			Sound.StopMidi();
			this.backgroundMusicTimer.Stop();
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00023568 File Offset: 0x00022568
		private void frmMainBase_Resize(object sender, EventArgs e)
		{
			int num = 0;
			if (this.picMain.Size.Height > this.pnlMain.Size.Height)
			{
				num = 17;
			}
			this.pnlMain.AutoScrollPosition = new Point(0, 0);
			this.picMain.Location = new Point(Math.Max(0, (this.pnlMain.Size.Width - num - this.picMain.Size.Width) / 2), Math.Max(0, (this.pnlMain.Size.Height - this.picMain.Size.Height) / 2));
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00023630 File Offset: 0x00022630
		private void tlbMain_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, e.Button.Text);
			if (menuItem != null)
			{
				menuItem.PerformClick();
				return;
			}
			throw new Exception("A main toolbar button click was unhandled. Check the toolbar buttons text property.");
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00023674 File Offset: 0x00022674
		private void mnuFileSave_Click(object sender, EventArgs e)
		{
			if (S.I.Demo)
			{
				MessageBox.Show(this, S.R.GetString("This feature is disabled in this demo edition."), S.R.GetString("Demo Edition"));
			}
			else if (this.currentFilePath == null | this.lessonLoadedPromptSaveAs)
			{
				this.mnuFileSaveAs_Click(new object(), new EventArgs());
			}
			else
			{
				try
				{
					this.SaveSim(this.currentFilePath);
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Concat(new string[]
					{
						S.R.GetString("Could not save file. File may be read-only or in use by another application."),
						"\r\n\r\n",
						S.R.GetString("Error details"),
						": ",
						ex.Message
					}), S.R.GetString("Could Not Save"));
					this.mnuFileSaveAs_Click(new object(), new EventArgs());
				}
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00023788 File Offset: 0x00022788
		private void mnuFileSaveAs_Click(object sender, EventArgs e)
		{
			if (S.I.Demo)
			{
				MessageBox.Show(this, S.R.GetString("This feature is disabled in this demo edition."), S.R.GetString("Demo Edition"));
			}
			else
			{
				bool flag = false;
				if (S.I.SimTimeRunning)
				{
					flag = true;
					this.mnuOptionsGoStop_Click(new object(), new EventArgs());
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = string.Concat(new string[]
				{
					S.I.DataFileTypeName,
					" files (*.",
					S.I.DataFileTypeExtension,
					")|*.",
					S.I.DataFileTypeExtension,
					"|All files (*.*)|*.*"
				});
				saveFileDialog.DefaultExt = S.I.DataFileTypeExtension;
				if (S.I.UserAdminSettings.DefaultDirectory != null)
				{
					saveFileDialog.InitialDirectory = S.I.UserAdminSettings.DefaultDirectory;
				}
				while (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						this.SaveSim(saveFileDialog.FileName);
						this.lessonLoadedPromptSaveAs = false;
						this.currentFilePath = saveFileDialog.FileName;
						this.Text = Path.GetFileNameWithoutExtension(this.currentFilePath) + " - " + Application.ProductName;
						if (S.I.SimStateAdapter.getMultiplayer())
						{
							string text = this.Text;
							this.Text = string.Concat(new string[]
							{
								text,
								" Multiplayer   Role: ",
								this.ClientOrHost(),
								"   Session Name: ",
								Simulator.Instance.SessionName
							});
						}
						break;
					}
					catch (Exception ex)
					{
						MessageBox.Show(string.Concat(new string[]
						{
							S.R.GetString("Could not save file. File may be read-only or in use by another application."),
							"\r\n\r\n",
							S.R.GetString("Error details"),
							": ",
							ex.Message
						}), S.R.GetString("Could Not Save"));
					}
				}
				if (flag)
				{
					this.mnuOptionsGoStop_Click(new object(), new EventArgs());
				}
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000239F4 File Offset: 0x000229F4
		private void SaveSim(string filename)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				S.ST.SavedEntityID = this.CurrentEntityID;
				S.ST.SavedViewName = this.CurrentViewName;
				S.I.SaveState(filename);
				this.dirtySimState = false;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00023A68 File Offset: 0x00022A68
		private void mnuFileOpenSavedSim_Click(object sender, EventArgs e)
		{
			if (S.I.Demo)
			{
				MessageBox.Show(this, S.R.GetString("This feature is disabled in this demo edition."), S.R.GetString("Demo Edition"));
			}
			else
			{
				if (S.I.SimTimeRunning)
				{
					this.mnuOptionsGoStop_Click(new object(), new EventArgs());
				}
				if (this.QuerySave())
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = string.Concat(new string[]
					{
						S.I.DataFileTypeName,
						" files (*.",
						S.I.DataFileTypeExtension,
						")|*.",
						S.I.DataFileTypeExtension,
						"|All files (*.*)|*.*"
					});
					openFileDialog.DefaultExt = S.I.DataFileTypeExtension;
					if (S.I.UserAdminSettings.DefaultDirectory != null)
					{
						openFileDialog.InitialDirectory = S.I.UserAdminSettings.DefaultDirectory;
					}
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						this.OpenSavedSim(openFileDialog.FileName);
					}
				}
			}
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00023BA0 File Offset: 0x00022BA0
		private void OpenSavedSim(string filepath)
		{
			this.Cursor = Cursors.WaitCursor;
			this.ReInit();
			try
			{
				S.I.LoadState(filepath);
				this.currentViewName = S.ST.SavedViewName;
				this.currentEntityID = S.ST.SavedEntityID;
				S.ST.SpeedIndex = S.ST.SpeedIndex;
				this.LoadStateHook();
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Concat(new string[]
				{
					S.R.GetString("An error occurred while opening the file. Check that the file is a valid {0} (.{1}) file. If the error continues, the file may have been corrupted.", new string[]
					{
						Application.ProductName,
						Simulator.Instance.DataFileTypeExtension
					}),
					"\r\n\r\n",
					S.R.GetString("Error details"),
					": ",
					ex.Message
				}), S.R.GetString("Error Opening File"));
				Form correctStartChoices = this.GetCorrectStartChoices();
				correctStartChoices.ShowDialog(this);
				return;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
			this.currentFilePath = filepath;
			if (S.SS.StudentOrg > 0)
			{
				MessageBox.Show("You have opened a Virtual Business Challenge file. The Instructor's Area will be disabled.", "Virtual Business Challenge");
			}
			else if (S.I.VBC)
			{
				MessageBox.Show(S.R.GetString("The file you are trying to load was not built for this Edition. It can be loaded only by the classroom version."));
				Form correctStartChoices = this.GetCorrectStartChoices();
				correctStartChoices.ShowDialog(this);
			}
			this.OnStateChanged();
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00023D44 File Offset: 0x00022D44
		protected virtual void LoadStateHook()
		{
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00023D48 File Offset: 0x00022D48
		private void OnStateChanged()
		{
			if (!S.I.Client && S.I.Demo)
			{
				S.SS.StopDate = S.SS.StartDate.AddDays((double)S.I.DemoDuration);
			}
			this.Text = Application.ProductName;
			if (this.currentFilePath != null)
			{
				this.Text = Path.GetFileNameWithoutExtension(this.currentFilePath) + " - " + this.Text;
			}
			bool multiplayer = S.I.SimStateAdapter.getMultiplayer();
			if (this.ScoreboardButton != null)
			{
				this.ScoreboardButton.Visible = multiplayer;
			}
			this.mnuFileMultiplayerScoreboard.Enabled = multiplayer;
			this.mnuFileMultiplayerTeamList.Visible = (multiplayer && S.I.Host);
			if (multiplayer)
			{
				if (S.I.Client)
				{
					this.CurrentEntityID = S.SA.GetAnEntityIdForPlayer(S.I.ThisPlayerName);
				}
				else
				{
					frmStartMultiplayerSession frmStartMultiplayerSession = new frmStartMultiplayerSession();
					if (frmStartMultiplayerSession.ShowDialog() == DialogResult.Cancel)
					{
						Form form = this.GetCorrectStartChoices();
						form.ShowDialog(this);
						return;
					}
					S.I.ThisPlayerName = "";
					S.ST.RoleBasedMultiplayer = frmStartMultiplayerSession.chkRequireRoles.Checked;
				}
				string text = this.Text;
				this.Text = string.Concat(new string[]
				{
					text,
					" Multiplayer ",
					this.ClientOrHost(),
					"   Session Name: ",
					Simulator.Instance.SessionName
				});
				if (S.I.MultiplayerRoleName != "")
				{
					this.Text = this.Text + "   Role: " + S.I.MultiplayerRoleName;
				}
			}
			this.OnCurrentEntityChange(this.CurrentEntityID);
			if (!S.I.Client)
			{
				this.OnSpeedChange();
			}
			else
			{
				S.I.SetSimEngineSpeed(new SimSpeed(S.I.UserAdminSettings.ClientDrawStepPeriod, 1));
				this.mnuFileSave.Enabled = false;
				this.mnuFileSaveAs.Enabled = false;
				this.mnuOptionsFaster.Enabled = false;
				this.mnuOptionsSlower.Enabled = false;
				this.mnuOptionsRunTo.Enabled = false;
				this.ReenableButtons();
			}
			if (this.CurrentViewName == "")
			{
				this.CurrentViewName = S.I.Views[0].Name;
			}
			this.OnViewChange(this.CurrentViewName);
			if (this.mnuHelpAssignment.Enabled)
			{
				Form form = this.FindOwnedForm(typeof(frmStartChoices));
				if (form != null)
				{
					form.Location = new Point(0, 30000);
				}
				if (MessageBox.Show("Do you want to view or print your assignment?", "View Assignment", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this.mnuHelpAssignment.PerformClick();
				}
			}
			this.RegisterClientEventHandlers();
			this.OnStateChangedHook();
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00024088 File Offset: 0x00023088
		protected virtual void OnStateChangedHook()
		{
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0002408C File Offset: 0x0002308C
		protected virtual void RegisterClientEventHandlers()
		{
			S.SA.PlaySoundEvent += ClientEventHandlers.Instance.PlaySoundHandler;
			S.SA.PlayerMessageEvent += ClientEventHandlers.Instance.PlayerMessageHandler;
			S.SA.ModalMessageEvent += ClientEventHandlers.Instance.ModalMessageHandler;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000240EC File Offset: 0x000230EC
		protected virtual void UnregisterClientEventHandlers()
		{
			try
			{
				S.SA.PlaySoundEvent -= ClientEventHandlers.Instance.PlaySoundHandler;
				S.SA.PlayerMessageEvent -= ClientEventHandlers.Instance.PlayerMessageHandler;
				S.SA.ModalMessageEvent -= ClientEventHandlers.Instance.ModalMessageHandler;
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00024168 File Offset: 0x00023168
		private void mnuFileOpenLesson_Click(object sender, EventArgs e)
		{
			if (S.I.Demo)
			{
				MessageBox.Show(this, S.R.GetString("Only a limited number of lessons are available in this demo edition."), S.R.GetString("Demo Edition"));
			}
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			if (this.QuerySave())
			{
				frmLessonsSimple frmLessonsSimple;
				try
				{
					frmLessonsSimple = new frmLessonsSimple();
				}
				catch (DirectoryNotFoundException)
				{
					MessageBox.Show(string.Concat(new string[]
					{
						"The Lessons directory is missing from the directory in which ",
						Application.ProductName,
						" was installed. Re-install ",
						Application.ProductName,
						"."
					}));
					return;
				}
				DialogResult dialogResult = frmLessonsSimple.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					this.OpenSavedSim(frmLessonsSimple.LessonFileName);
					this.lessonLoadedPromptSaveAs = true;
				}
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00024264 File Offset: 0x00023264
		private void mnuFileExit_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			base.Close();
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x000242A0 File Offset: 0x000232A0
		private void frmMainBase_Closing(object sender, CancelEventArgs e)
		{
			if (!this.QuerySave())
			{
				e.Cancel = true;
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000242C2 File Offset: 0x000232C2
		private void mnuActions_Select(object sender, EventArgs e)
		{
			this.dirtySimState = true;
			this.CloseActionForms();
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x000242D3 File Offset: 0x000232D3
		private void mnuOptionsFaster_Click(object sender, EventArgs e)
		{
			S.I.SimState.SpeedIndex++;
			this.OnSpeedChange();
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x000242F5 File Offset: 0x000232F5
		private void mnuOptionsSlower_Click(object sender, EventArgs e)
		{
			S.I.SimState.SpeedIndex--;
			this.OnSpeedChange();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00024318 File Offset: 0x00023318
		private void OnSpeedChange()
		{
			this.mnuOptionsFaster.Enabled = (S.I.SimState.SpeedIndex < S.ST.Speeds.Length - 1);
			this.mnuOptionsSlower.Enabled = (S.I.SimState.SpeedIndex > 0);
			this.ReenableButtons();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00024378 File Offset: 0x00023378
		private void mnuViewView_Click(object sender, EventArgs e)
		{
			this.OnViewChange(((MenuItem)sender).Text);
			if (this.SoundOn)
			{
				Sound.PlaySoundFromFile("sounds\\viewchange.wav");
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x000243B0 File Offset: 0x000233B0
		public void OnViewChange(string viewName)
		{
			this.CloseActionForms();
			View.ClearCurrentHit();
			this.CurrentViewName = viewName;
			this.picMain.Visible = false;
			this.backBuffer = new Bitmap(this.currentView.Size.Width, this.currentView.Size.Height, this.picMain.CreateGraphics());
			this.backBufferGraphics = Graphics.FromImage(this.backBuffer);
			this.picMain.Size = this.currentView.Size;
			this.frmMainBase_Resize(new object(), new EventArgs());
			this.UpdateView();
			this.picMain.Visible = true;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00024469 File Offset: 0x00023469
		private void mnuViewEntity_Click(object sender, EventArgs e)
		{
			this.OnCurrentEntityChange(this.EntityNameToID(((MenuItem)sender).Text));
			this.UpdateView();
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0002448C File Offset: 0x0002348C
		public long EntityNameToID(string entityName)
		{
			foreach (object obj in this.entityNames.Keys)
			{
				long num = (long)obj;
				if (((string)this.entityNames[num]).ToUpper() == entityName.ToUpper())
				{
					return num;
				}
			}
			return -1L;
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060004B3 RID: 1203 RVA: 0x0002452C File Offset: 0x0002352C
		// (remove) Token: 0x060004B4 RID: 1204 RVA: 0x00024545 File Offset: 0x00023545
		public event EventHandler EntityChanged;

		// Token: 0x060004B5 RID: 1205 RVA: 0x00024560 File Offset: 0x00023560
		public void OnCurrentEntityChange(long entityID)
		{
			this.CurrentEntityID = entityID;
			this.CloseActionForms();
			foreach (object obj in this.mnuView.MenuItems)
			{
				MenuItem menuItem = (MenuItem)obj;
				menuItem.Checked = (menuItem.Text == this.EntityIDToName(this.CurrentEntityID));
			}
			this.CurrentEntityPanel.Text = this.EntityIDToName(this.CurrentEntityID);
			try
			{
				this.EnableDisable();
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e);
			}
			MenuItem menuItem2 = Utilities.FindMenuEquivalent(this.mainMenu1, this.CurrentViewName);
			if (menuItem2 != null && !menuItem2.Enabled)
			{
				this.OnViewChange(S.I.Views[0].Name);
			}
			if (this.EntityChanged != null)
			{
				this.EntityChanged(this, new EventArgs());
			}
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00024698 File Offset: 0x00023698
		private void ReenableButtons()
		{
			foreach (object obj in this.tlbMain.Buttons)
			{
				ToolBarButton toolBarButton = (ToolBarButton)obj;
				MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, toolBarButton.Text);
				if (menuItem != null)
				{
					toolBarButton.Enabled = menuItem.Enabled;
				}
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00024728 File Offset: 0x00023728
		protected virtual void ConstructSimulator()
		{
			Simulator.InitSimulator(new SimFactory());
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00024738 File Offset: 0x00023738
		protected virtual void mnuFileMultiplayerJoin_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			if (this.QuerySave())
			{
				frmJoinMultiplayerSession frmJoinMultiplayerSession = new frmJoinMultiplayerSession();
				if (frmJoinMultiplayerSession.ShowDialog() != DialogResult.Cancel)
				{
					this.ReInit();
					S.I.Client = true;
					S.I.SimStateAdapter = frmJoinMultiplayerSession.RemoteAdapter;
					S.I.ThisPlayerName = frmJoinMultiplayerSession.TeamName;
					S.I.SessionName = frmJoinMultiplayerSession.SessionName;
					S.I.MultiplayerRoleName = frmJoinMultiplayerSession.MultiplayerRoleName;
					if (S.I.MultiplayerRoleName != "" && S.I.AllowIntraTeamMessaging)
					{
						this.CreateMessagePanel.Width = 60;
					}
					this.ClientJoinHook(frmJoinMultiplayerSession.Player);
					this.OnStateChanged();
					this.mnuOptionsGoStop.PerformClick();
				}
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00024848 File Offset: 0x00023848
		protected virtual void mnuFileMultiplayerStart_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			if (this.QuerySave())
			{
				this.ReInit();
				this.currentFilePath = null;
				if (!this.DesignerMode || this.cacheDesignerSimSettings == null)
				{
					S.I.NewState(S.I.DefaultSimSettings, true);
				}
				else
				{
					S.I.NewState(this.cacheDesignerSimSettings, true);
				}
				this.ServerStartHook();
				this.OnStateChanged();
				this.mnuOptionsGoStop.PerformClick();
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000248F6 File Offset: 0x000238F6
		protected virtual void ClientJoinHook(Player p)
		{
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000248F9 File Offset: 0x000238F9
		protected virtual void ServerStartHook()
		{
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000248FC File Offset: 0x000238FC
		private void frmMainBase_Load(object sender, EventArgs e)
		{
			this.Text = Application.ProductName;
			if (!base.DesignMode)
			{
				if (S.I.Academic)
				{
					Simulator i = S.I;
					i.DataFileTypeExtension += "A";
				}
				if (this.commandLineArgs == null || this.commandLineArgs.Length == 0)
				{
					Form correctStartChoices = this.GetCorrectStartChoices();
					correctStartChoices.ShowDialog(this);
				}
				else
				{
					this.OpenSavedSim(this.commandLineArgs[0]);
				}
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00024990 File Offset: 0x00023990
		public Form GetCorrectStartChoices()
		{
			return new frmStartChoices();
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x000249A8 File Offset: 0x000239A8
		private void mnuFilePrintView_Click(object sender, EventArgs e)
		{
			frmInputString frmInputString = new frmInputString(S.R.GetString("Student Name"), S.R.GetString("Enter your name to help identify your printout on a shared printer:"), this.printStudentName);
			frmInputString.ShowDialog(this);
			this.printStudentName = frmInputString.Response;
			Utilities.PrintWithExceptionHandling(this.Text, new PrintPageEventHandler(this.View_PrintPage));
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00024A0C File Offset: 0x00023A0C
		private void View_PrintPage(object sender, PrintPageEventArgs e)
		{
			try
			{
				Utilities.ResetFPU();
				Font font = new Font("Arial", 14f);
				string text = "";
				if (this.printStudentName != "")
				{
					text = text + "Student Name: " + this.printStudentName + "\r\n\r\n";
				}
				text = text + this.CurrentViewName + " View";
				if (S.I.EntityName != "")
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"\r\nCurrent ",
						S.I.EntityName,
						": ",
						this.EntityIDToName(this.CurrentEntityID)
					});
				}
				int num = (int)(e.Graphics.MeasureString(text, font).Height * 1.5f);
				Rectangle marginBounds = e.MarginBounds;
				Rectangle rectangle = new Rectangle(marginBounds.Left, marginBounds.Top + num, marginBounds.Width, marginBounds.Height - num);
				float num2 = Math.Min((float)rectangle.Width / (float)this.picMain.Width, (float)rectangle.Height / (float)this.picMain.Height);
				float dx = (float)rectangle.Left + ((float)rectangle.Width - (float)this.picMain.Width * num2) / 2f;
				float dy = (float)rectangle.Top + ((float)rectangle.Height - (float)this.picMain.Height * num2) / 2f;
				e.Graphics.TranslateTransform(dx, dy);
				e.Graphics.ScaleTransform(num2, num2);
				e.Graphics.DrawImageUnscaled(this.backBuffer, 0, 0);
				e.Graphics.ResetTransform();
				e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), (float)e.MarginBounds.Left, (float)e.MarginBounds.Top);
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00024C54 File Offset: 0x00023C54
		private void picMain_Paint(object sender, PaintEventArgs e)
		{
			if (!base.DesignMode && this.backBuffer != null)
			{
				e.Graphics.DrawImageUnscaled(this.backBuffer, 0, 0);
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00024C90 File Offset: 0x00023C90
		private void mnuHelpAssignment_Click(object sender, EventArgs e)
		{
			byte[] buffer = S.SA.getPdfAssignment();
			if (Thread.CurrentThread.CurrentUICulture.Name != "")
			{
				Hashtable hashtable = (Hashtable)S.ST.Reserved["LocalLanguageAssignments"];
				if (hashtable != null)
				{
					byte[] array = (byte[])hashtable[Thread.CurrentThread.CurrentUICulture.Name];
					if (array != null)
					{
						buffer = array;
					}
				}
			}
			string tempPath = Path.GetTempPath();
			string text = null;
			int num = 100;
			int i;
			for (i = 0; i < num; i++)
			{
				try
				{
					text = string.Concat(new object[]
					{
						tempPath,
						"Printable Virtual Business Assignment.pdf",
						i,
						"q.pdf"
					});
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					break;
				}
				catch (IOException)
				{
				}
			}
			if (i >= num)
			{
				MessageBox.Show("Too many assignment files are being viewed at one time.  Try closing some first, then try viewing this assignment again.");
			}
			else
			{
				try
				{
					FileStream fileStream = new FileStream(text, FileMode.Create);
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					binaryWriter.Write(buffer);
					fileStream.Close();
					Process.Start(text);
				}
				catch (Win32Exception)
				{
					MessageBox.Show("Could not find Adobe Acrobat Reader to display assignment. Either download and install Acrobat Reader from www.Adobe.com or have your instructor copy the assignment out of the Instructor's Manual.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not display assignment. Please have your instructor copy the assignment out of the Instructor's Manual.\r\n\r\nDetailed problem: " + ex.Message);
				}
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00024E38 File Offset: 0x00023E38
		protected void mnuOptionsIACustomizeYourSim_Click(object sender, EventArgs e)
		{
			frmPassword frmPassword = new frmPassword(S.I.UserAdminSettings.GetP());
			if (this.DesignerMode || frmPassword.ShowDialog(this) == DialogResult.OK)
			{
				frmEditSimSettings frmEditSimSettings = null;
				try
				{
					frmEditSimSettings = new frmEditSimSettings();
					frmEditSimSettings.ShowDialog();
					this.EnableDisable();
				}
				catch (Exception e2)
				{
					frmExceptionHandler.Handle(e2, frmEditSimSettings);
				}
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00024EB4 File Offset: 0x00023EB4
		private void mnuHelpAbout_Click(object sender, EventArgs e)
		{
			frmAbout frmAbout = new frmAbout();
			frmAbout.ShowDialog(this);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00024ED0 File Offset: 0x00023ED0
		public virtual void EnableDisable()
		{
			this.cachedSimSettings = S.I.SimStateAdapter.getSimSettings();
			bool flag = false;
			if (this.CurrentEntityID != -1L)
			{
				flag = (S.I.ThisPlayerName == S.I.SimStateAdapter.GetEntityPlayer(this.CurrentEntityID));
			}
			this.mnuHelpAssignment.Enabled = (this.cachedSimSettings.PdfAssignment != null);
			Utilities.FindButtonEquivalent(this.tlbMain, this.mnuHelpAssignment.Text).Enabled = this.mnuHelpAssignment.Enabled;
			bool flag2 = this.CurrentEntityID == -1L;
			bool flag3 = S.I.Multiplayer && !S.I.Client;
			PropertyInfo[] properties = this.cachedSimSettings.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				string str;
				if (flag)
				{
					str = "Owner";
				}
				else
				{
					str = "NonOwner";
				}
				int num = propertyInfo.Name.IndexOf("EnabledFor" + str);
				if (num > -1)
				{
					string text = propertyInfo.Name.Substring(0, num);
					MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, Utilities.AddSpaces(text));
					if (menuItem != null)
					{
						MethodInfo getMethod = propertyInfo.GetGetMethod();
						bool enabled = (bool)getMethod.Invoke(this.cachedSimSettings, new object[0]);
						if (flag2)
						{
							enabled = false;
						}
						else if (this.DesignerMode)
						{
							enabled = true;
						}
						else if (flag3)
						{
							enabled = this.IsReportMenuItem(menuItem);
						}
						menuItem.Enabled = enabled;
						ToolBarButton toolBarButton = Utilities.FindButtonEquivalent(this.tlbMain, menuItem.Text);
						if (toolBarButton != null)
						{
							toolBarButton.Enabled = menuItem.Enabled;
						}
					}
				}
			}
			if (S.I.MultiplayerRole != null)
			{
				string[] disableList = S.I.MultiplayerRole.DisableList;
				foreach (string text in disableList)
				{
					MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, text);
					if (menuItem != null)
					{
						menuItem.Enabled = false;
						ToolBarButton toolBarButton = Utilities.FindButtonEquivalent(this.tlbMain, menuItem.Text);
						if (toolBarButton != null)
						{
							toolBarButton.Enabled = menuItem.Enabled;
						}
					}
				}
			}
			foreach (object obj in this.mainMenu1.MenuItems)
			{
				MenuItem menuItem2 = (MenuItem)obj;
				foreach (object obj2 in menuItem2.MenuItems)
				{
					MenuItem menuItem3 = (MenuItem)obj2;
					if (menuItem3.MenuItems.Count > 0)
					{
						menuItem3.Enabled = false;
						foreach (object obj3 in menuItem3.MenuItems)
						{
							MenuItem menuItem4 = (MenuItem)obj3;
							if (menuItem4.Text != "-")
							{
								menuItem3.Enabled |= menuItem4.Enabled;
							}
						}
					}
				}
			}
			if (S.I.Client)
			{
				this.mnuOptionsIA.Enabled = false;
			}
			if (this.cachedSimSettings.StudentOrg > 0 && !S.MF.DesignerMode)
			{
				this.mnuOptionsIA.Enabled = false;
			}
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0002536C File Offset: 0x0002436C
		public virtual bool IsActionMenuItem(string menuItemText)
		{
			MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, menuItemText);
			bool result;
			if (menuItem != null)
			{
				MenuItem menuItem2 = (MenuItem)menuItem.Parent;
				while (menuItem2.Parent != this.mainMenu1)
				{
					menuItem2 = (MenuItem)menuItem2.Parent;
				}
				result = (menuItem2 == this.mnuActions);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000253D0 File Offset: 0x000243D0
		protected virtual bool IsReportMenuItem(MenuItem menuItem)
		{
			MenuItem menuItem2 = (MenuItem)menuItem.Parent;
			return menuItem2 == this.mnuReports || menuItem2 == this.mnuView;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00025404 File Offset: 0x00024404
		private string ClientOrHost()
		{
			string result;
			if (Simulator.Instance.Client)
			{
				result = "Client";
			}
			else
			{
				result = "Host";
			}
			return result;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00025434 File Offset: 0x00024434
		protected Form FindOwnedForm(Type type)
		{
			foreach (Form form in base.OwnedForms)
			{
				if (form.GetType() == type)
				{
					return form;
				}
			}
			return null;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00025480 File Offset: 0x00024480
		protected void CloseOwnedForms()
		{
			foreach (Form form in base.OwnedForms)
			{
				form.Close();
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x000254B4 File Offset: 0x000244B4
		protected void CloseActionForms()
		{
			foreach (Form form in base.OwnedForms)
			{
				if (form is IActionForm)
				{
					form.Close();
				}
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000254F7 File Offset: 0x000244F7
		private void mnuHelpSearch_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenSearch();
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00025500 File Offset: 0x00024500
		public bool GetEnablingFor(string menuCaption)
		{
			MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, menuCaption);
			return menuItem.Enabled;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00025528 File Offset: 0x00024528
		private void mnuFileMultiplayerScoreboard_Click(object sender, EventArgs e)
		{
			Form form = this.FindOwnedForm(typeof(frmScoreboard));
			if (form == null)
			{
				new frmScoreboard
				{
					Owner = this
				}.Show();
			}
			else
			{
				form.Focus();
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00025574 File Offset: 0x00024574
		protected virtual void mnuOptionsTuning_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00025578 File Offset: 0x00024578
		private void mnuOptionsChangeOwner_Click(object sender, EventArgs e)
		{
			frmInputString frmInputString = new frmInputString("Change Owner", "Enter the player name of the new owner. Enter USER for single player user. Enter AI for a new AI player.", "");
			if (frmInputString.ShowDialog() == DialogResult.OK)
			{
				string text = frmInputString.Response;
				if (text.ToUpper() == "USER")
				{
					text = "";
				}
				if (text.ToUpper() == "AI")
				{
					Player player = S.SA.CreatePlayer(Guid.NewGuid().ToString(), PlayerType.AI);
					text = player.PlayerName;
				}
				try
				{
					S.SA.ChangeEntityOwner(S.MF.CurrentEntityID, text);
				}
				catch (SimApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Couldn't change owner");
				}
				catch (Exception e2)
				{
					frmExceptionHandler.Handle(e2, frmInputString);
				}
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00025678 File Offset: 0x00024678
		public void ExplainNoFunctionality()
		{
			MessageBox.Show(this, "You will be receiving a technical update shortly that implements this functionality");
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00025688 File Offset: 0x00024688
		private void mnuOptionsBackgroundMusic_Click(object sender, EventArgs e)
		{
			this.mnuOptionsBackgroundMusic.Checked = !this.mnuOptionsBackgroundMusic.Checked;
			if (!this.mnuOptionsBackgroundMusic.Checked)
			{
				this.StopMusic();
			}
			if (this.mnuOptionsBackgroundMusic.Checked && S.I.SimTimeRunning)
			{
				this.StartMusic();
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000256EE File Offset: 0x000246EE
		private void mnuOptionsSoundEffects_Click(object sender, EventArgs e)
		{
			this.mnuOptionsSoundEffects.Checked = !this.mnuOptionsSoundEffects.Checked;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0002570B File Offset: 0x0002470B
		private void backgroundMusicTimer_Tick(object sender, EventArgs e)
		{
			this.StartMusic();
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00025718 File Offset: 0x00024718
		public bool SoundOn
		{
			get
			{
				return this.mnuOptionsSoundEffects.Checked;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00025738 File Offset: 0x00024738
		public bool MusicOn
		{
			get
			{
				return this.mnuOptionsBackgroundMusic.Checked;
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00025758 File Offset: 0x00024758
		protected void InitRemotingConfiguration()
		{
			AssemblyName name = Assembly.GetEntryAssembly().GetName();
			int startIndex = 1 + name.CodeBase.LastIndexOf("/");
			string str = name.CodeBase.Substring(startIndex);
			string filename = Application.StartupPath + "\\" + str + ".config";
			RemotingConfiguration.Configure(filename);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x000257B0 File Offset: 0x000247B0
		protected bool CanShowForm(Form f)
		{
			bool result;
			if (f is IConstrainedForm)
			{
				string text = ((IConstrainedForm)f).CanUse();
				if (text.Equals(""))
				{
					result = true;
				}
				else
				{
					MessageBox.Show(text, S.R.GetString("Action Not Allowed"));
					result = false;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00025814 File Offset: 0x00024814
		protected void ShowNonModalForm(Form frm)
		{
			Form form = this.FindOwnedForm(frm.GetType());
			if (form == null)
			{
				frm.Owner = this;
				if (this.CanShowForm(frm))
				{
					frm.Show();
				}
			}
			else
			{
				form.Focus();
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00025868 File Offset: 0x00024868
		private void mnuOptionsMacrosRecordMacro_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.macroFilename = saveFileDialog.FileName;
				this.mnuOptionsMacrosRecordMacro.Enabled = false;
				this.mnuOptionsMacroStopRecording.Enabled = true;
				this.mnuOptionsMacrosPlayMacro.Enabled = false;
				this.macroRecordingOn = true;
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000258CC File Offset: 0x000248CC
		private void mnuOptionsMacrosPlayMacro_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.macroActions.Clear();
				FileStream fileStream = null;
				try
				{
					fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
					IFormatter formatter = new BinaryFormatter();
					while (fileStream.Position < fileStream.Length)
					{
						MacroAction value = (MacroAction)formatter.Deserialize(fileStream);
						this.macroActions.Add(value);
					}
				}
				catch (Exception)
				{
					this.macroActions.Clear();
					MessageBox.Show("Had problems deserializing from " + openFileDialog.FileName);
				}
				finally
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				frmPlayMacro frmPlayMacro = new frmPlayMacro();
				if (frmPlayMacro.ShowDialog(this) == DialogResult.OK)
				{
					this.playLooping = frmPlayMacro.optContinuously.Checked;
					this.playIntervalMilliseconds = (long)frmPlayMacro.updInterval.Value;
					this.mnuOptionsMacrosPlayMacro.Enabled = false;
					this.mnuOptionsMacrosStopPlaying.Enabled = true;
					this.macroPlayingOn = true;
					this.mnuOptionsMacrosRecordMacro.Enabled = false;
					this.mnuOptionsMacrosStopPlaying.Enabled = true;
				}
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00025A30 File Offset: 0x00024A30
		public void SaveMacroAction(MacroAction action)
		{
			if (this.macroRecordingOn)
			{
				FileStream fileStream = new FileStream(this.macroFilename, FileMode.Append, FileAccess.Write, FileShare.None);
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(fileStream, action);
				fileStream.Close();
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00025A74 File Offset: 0x00024A74
		public void PlayMacroAction()
		{
			if (this.macroPlayingOn)
			{
				if (this.playLooping)
				{
					if (this.currentMacroActionIndex >= this.macroActions.Count)
					{
						this.currentMacroActionIndex = 0;
					}
					MacroAction macroAction = (MacroAction)this.macroActions[this.currentMacroActionIndex];
					if (!(this.nextMacroPlayTime >= DateTime.Now))
					{
						macroAction.Method.Invoke(S.SA, macroAction.ArgumentValues);
						this.nextMacroPlayTime = this.nextMacroPlayTime.AddMilliseconds((double)this.playIntervalMilliseconds);
						this.currentMacroActionIndex++;
					}
				}
				else if (!S.I.Client)
				{
					while (this.currentMacroActionIndex < this.macroActions.Count)
					{
						MacroAction macroAction = (MacroAction)this.macroActions[this.currentMacroActionIndex];
						if (macroAction.Timestamp >= S.ST.Now)
						{
							break;
						}
						macroAction.Method.Invoke(S.SA, macroAction.ArgumentValues);
						this.currentMacroActionIndex++;
					}
				}
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00025BC0 File Offset: 0x00024BC0
		private void mnuOptionsMacrosStopPlaying_Click(object sender, EventArgs e)
		{
			this.macroPlayingOn = false;
			this.macroActions = null;
			this.mnuOptionsMacrosStopPlaying.Enabled = false;
			this.mnuOptionsMacrosRecordMacro.Enabled = true;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00025BEB File Offset: 0x00024BEB
		private void mnuOptionsMacroStopRecording_Click(object sender, EventArgs e)
		{
			this.macroRecordingOn = false;
			this.mnuOptionsMacroStopRecording.Enabled = false;
			this.mnuOptionsMacrosRecordMacro.Enabled = true;
			this.mnuOptionsMacrosPlayMacro.Enabled = true;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00025C1C File Offset: 0x00024C1C
		private void frmMainBase_Closed(object sender, EventArgs e)
		{
			this.UnregisterClientEventHandlers();
			Application.Exit();
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00025C2C File Offset: 0x00024C2C
		public void AddPlayerMessage(PlayerMessage message)
		{
			if (this.messagesForm != null)
			{
				this.messagesForm.AddMessage(message);
				if (!this.messagesForm.Visible && this.NewMessagesPanel.Width != 120)
				{
					this.NewMessagesPanel.Width = 120;
				}
			}
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00025C88 File Offset: 0x00024C88
		public void ShowModalMessage(ModalMessage message)
		{
			bool flag = false;
			if (S.I.SimTimeRunning && !S.I.Multiplayer)
			{
				flag = true;
				this.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			if (message is RunToDateReachedMessage)
			{
				this.UpdateView();
				this.SynchGoStop();
			}
			else if (message is StopDateReachedMessage)
			{
				this.UpdateView();
				frmUpload frmUpload = new frmUpload();
				frmUpload.ShowDialog(S.MF);
				this.SynchGoStop();
			}
			else
			{
				if (message is ShowPageMessage)
				{
					Form form = new frmPage(((ShowPageMessage)message).Page);
					form.ShowDialog();
				}
				else if (message is LevelEndTestMessage)
				{
					LevelEndTestMessage levelEndTestMessage = (LevelEndTestMessage)message;
					AcademicGod.HandleLevelEnd(levelEndTestMessage);
					if (levelEndTestMessage.LastLevel)
					{
						return;
					}
				}
				else
				{
					MessageBox.Show(message.Message, message.Title, MessageBoxButtons.OK, message.Icon);
					if (message is GameOverMessage)
					{
						if (!S.I.Client)
						{
							this.SynchGoStop();
						}
						this.DirtySimState = false;
						Form form = this.GetCorrectStartChoices();
						form.ShowDialog(this);
						return;
					}
				}
				if (flag)
				{
					this.mnuOptionsGoStop_Click(new object(), new EventArgs());
				}
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00025E0C File Offset: 0x00024E0C
		public void SynchGoStop()
		{
			if (!S.I.SimTimeRunning && this.mnuOptionsGoStop.Text.EndsWith(S.I.Resource.GetString("Stop")))
			{
				ToolBarButton toolBarButton = Utilities.FindButtonEquivalent(this.tlbMain, this.mnuOptionsGoStop.Text);
				this.mnuOptionsGoStop.Text = S.I.Resource.GetString("Go");
				if (toolBarButton != null)
				{
					toolBarButton.Text = this.mnuOptionsGoStop.Text;
					toolBarButton.ImageIndex--;
				}
				this.StopMusic();
			}
			if (S.I.SimTimeRunning && this.mnuOptionsGoStop.Text.EndsWith(S.I.Resource.GetString("Go")))
			{
				ToolBarButton toolBarButton = Utilities.FindButtonEquivalent(this.tlbMain, this.mnuOptionsGoStop.Text);
				this.mnuOptionsGoStop.Text = S.I.Resource.GetString("Stop");
				if (toolBarButton != null)
				{
					toolBarButton.Text = this.mnuOptionsGoStop.Text;
					toolBarButton.ImageIndex++;
				}
				if (this.MusicOn)
				{
					this.StartMusic();
				}
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00025F74 File Offset: 0x00024F74
		public virtual bool OptOutModalMessageHook(ModalMessage message)
		{
			return false;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00025F88 File Offset: 0x00024F88
		private void staMain_PanelClick(object sender, StatusBarPanelClickEventArgs e)
		{
			if (e.StatusBarPanel == this.NewMessagesPanel)
			{
				this.ShowMessageWindow();
			}
			if (e.StatusBarPanel == this.CreateMessagePanel)
			{
				frmCreateMessage frmCreateMessage = new frmCreateMessage();
				frmCreateMessage.ShowDialog(this);
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00025FD8 File Offset: 0x00024FD8
		protected void ShowMessageWindow()
		{
			this.mnuOptionsShowMessages.Checked = true;
			this.messagesForm.Show();
			this.messagesForm.Location = base.PointToScreen(new Point(0, this.staMain.Top - this.messagesForm.Height));
			this.NewMessagesPanel.Width = 0;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0002603B File Offset: 0x0002503B
		public void HideMessageWindow()
		{
			this.mnuOptionsShowMessages.Checked = false;
			this.messagesForm.Hide();
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00026058 File Offset: 0x00025058
		protected virtual void mnuOptionsShowMessages_Click(object sender, EventArgs e)
		{
			if (!this.mnuOptionsShowMessages.Checked)
			{
				this.ShowMessageWindow();
			}
			else
			{
				this.HideMessageWindow();
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00026088 File Offset: 0x00025088
		protected virtual void mnuOptionsIAProvideCash_Click(object sender, EventArgs e)
		{
			frmPassword frmPassword = new frmPassword(S.I.UserAdminSettings.GetP());
			if (this.DesignerMode || frmPassword.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					Form form = new frmProvideCash();
					form.ShowDialog(this);
				}
				catch (Exception e2)
				{
					frmExceptionHandler.Handle(e2);
				}
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000260F8 File Offset: 0x000250F8
		private void mnuOptionsLanguage_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x000260FC File Offset: 0x000250FC
		public Rectangle MainWindowBounds
		{
			get
			{
				return new Rectangle(0, 0, this.picMain.Width, this.picMain.Height);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0002612C File Offset: 0x0002512C
		public ToolTip ViewToolTip
		{
			get
			{
				return this.viewToolTip;
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00026144 File Offset: 0x00025144
		public bool IsMenuItemEnabled(string menuItemText)
		{
			MenuItem menuItem = Utilities.FindMenuEquivalent(this.mainMenu1, menuItemText);
			if (menuItem == null)
			{
				throw new Exception("Can't find menu item " + menuItemText + " in IsMenuItemEnabled.");
			}
			return menuItem.Enabled;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0002618C File Offset: 0x0002518C
		private void mnuOptionsRenameEntity_Click(object sender, EventArgs e)
		{
			frmInputString frmInputString = new frmInputString("Rename " + S.I.EntityName, "Enter new name:", "");
			frmInputString.ShowDialog();
			if (frmInputString.Response != null && frmInputString.Response != "")
			{
				S.SA.RenameEntity(S.MF.CurrentEntityID, frmInputString.Response);
			}
			this.UpdateView();
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00026209 File Offset: 0x00025209
		private void picMain_Click(object sender, EventArgs e)
		{
			this.currentView.View_Click(sender, e);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0002621A File Offset: 0x0002521A
		private void picMain_MouseMove(object sender, MouseEventArgs e)
		{
			this.currentView.UpdateCurrentHit(e);
			this.currentView.View_MouseMove(sender, e);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00026238 File Offset: 0x00025238
		private void picMain_MouseUp(object sender, MouseEventArgs e)
		{
			this.currentView.View_MouseUp(sender, e);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00026249 File Offset: 0x00025249
		private void picMain_MouseDown(object sender, MouseEventArgs e)
		{
			this.currentView.View_MouseDown(sender, e);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0002625C File Offset: 0x0002525C
		private void mnuFileMultiplayerTeamList_Click(object sender, EventArgs e)
		{
			string text = "";
			foreach (object obj in S.ST.Player.Values)
			{
				Player player = (Player)obj;
				if (player.PlayerName != S.I.ThisPlayerName && player.PlayerType != PlayerType.AI)
				{
					text = text + S.R.GetString("Team Name: ") + player.PlayerName;
					if (S.I.UserAdminSettings.PasswordsForMultiplayer)
					{
						text = text + "     " + S.R.GetString("Password: ") + S.ST.GetMultiplayerTeamPassword(player.PlayerName);
					}
					text += "\r\n";
				}
			}
			MessageBox.Show(text, S.R.GetString("Teams That Have Logged In To This Session"));
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0002637C File Offset: 0x0002537C
		private void picMain_DoubleClick(object sender, EventArgs e)
		{
			this.currentView.View_DoubleClick(sender, e);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00026390 File Offset: 0x00025390
		private void mnuOptionsTestResults_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop.PerformClick();
			}
			Form form = new frmTestResults();
			form.ShowDialog(this);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000263CC File Offset: 0x000253CC
		private void mnuOptionsRunTo_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop.PerformClick();
			}
			Form form = new frmRunTo();
			form.ShowDialog(this);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00026408 File Offset: 0x00025408
		public void EnableMenuAndSubMenus(MenuItem m)
		{
			m.Enabled = true;
			foreach (object obj in m.MenuItems)
			{
				MenuItem m2 = (MenuItem)obj;
				this.EnableMenuAndSubMenus(m2);
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00026478 File Offset: 0x00025478
		public virtual int GetVBCStudentOrgCode()
		{
			return 0;
		}

		// Token: 0x0400031F RID: 799
		protected string[] commandLineArgs;

		// Token: 0x04000325 RID: 805
		protected bool isWin98;

		// Token: 0x04000326 RID: 806
		protected static frmMainBase instance;

		// Token: 0x04000349 RID: 841
		protected string currentFilePath;

		// Token: 0x0400034A RID: 842
		protected bool lessonLoadedPromptSaveAs;

		// Token: 0x0400034F RID: 847
		protected bool dirtySimState;

		// Token: 0x04000352 RID: 850
		protected ToolBarButton ScoreboardButton;

		// Token: 0x04000353 RID: 851
		private Hashtable entityNames = new Hashtable();

		// Token: 0x04000358 RID: 856
		protected View currentView;

		// Token: 0x04000359 RID: 857
		protected Bitmap backBuffer;

		// Token: 0x0400035A RID: 858
		protected Graphics backBufferGraphics;

		// Token: 0x0400035B RID: 859
		protected bool designerMode;

		// Token: 0x0400035C RID: 860
		protected SimSettings cacheDesignerSimSettings;

		// Token: 0x0400035D RID: 861
		protected string currentViewName;

		// Token: 0x0400035E RID: 862
		protected long currentEntityID = -1L;

		// Token: 0x0400035F RID: 863
		protected DateTime now;

		// Token: 0x04000360 RID: 864
		public static DateTime DateNotSet = new DateTime(2000, 1, 1);

		// Token: 0x04000361 RID: 865
		protected int currentWeek;

		// Token: 0x04000363 RID: 867
		protected string printStudentName = "";

		// Token: 0x04000364 RID: 868
		protected SimSettings cachedSimSettings;

		// Token: 0x04000365 RID: 869
		protected internal bool macroRecordingOn = false;

		// Token: 0x04000366 RID: 870
		protected internal string macroFilename;

		// Token: 0x04000367 RID: 871
		protected internal bool macroPlayingOn = false;

		// Token: 0x04000368 RID: 872
		protected internal bool playLooping = true;

		// Token: 0x04000369 RID: 873
		protected internal long playIntervalMilliseconds = 1000L;

		// Token: 0x0400036A RID: 874
		protected internal DateTime nextMacroPlayTime;

		// Token: 0x0400036B RID: 875
		protected internal int currentMacroActionIndex = 0;

		// Token: 0x0400036C RID: 876
		protected internal ArrayList macroActions = new ArrayList();

		// Token: 0x0400036D RID: 877
		protected frmMessages messagesForm;

		// Token: 0x0200007F RID: 127
		public class MenuItemEnabledNoEntities : MenuItem
		{
		}
	}
}
