namespace KMI.Sim
{
	// Token: 0x0200007E RID: 126
	public partial class frmMainBase : global::System.Windows.Forms.Form
	{
		// Token: 0x06000476 RID: 1142 RVA: 0x00020F58 File Offset: 0x0001FF58
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

		// Token: 0x06000477 RID: 1143 RVA: 0x00020F94 File Offset: 0x0001FF94
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::KMI.Sim.frmMainBase));
			this.mainMenu1 = new global::System.Windows.Forms.MainMenu();
			this.mnuFile = new global::System.Windows.Forms.MenuItem();
			this.mnuFileNew = new global::System.Windows.Forms.MenuItem();
			this.mnuFileOpenLesson = new global::System.Windows.Forms.MenuItem();
			this.mnuFileOpenSavedSim = new global::System.Windows.Forms.MenuItem();
			this.mnuSep1 = new global::System.Windows.Forms.MenuItem();
			this.mnuFileSave = new global::System.Windows.Forms.MenuItem();
			this.mnuFileSaveAs = new global::System.Windows.Forms.MenuItem();
			this.mnuFileUploadSeparator = new global::System.Windows.Forms.MenuItem();
			this.mnuFileMultiplayer = new global::System.Windows.Forms.MenuItem();
			this.mnuFileMultiplayerJoin = new global::System.Windows.Forms.MenuItem();
			this.mnuFileMultiplayerStart = new global::System.Windows.Forms.MenuItem();
			this.mnuFileMultiplayerScoreboard = new global::System.Windows.Forms.MenuItem();
			this.mnuFileMultiplayerTeamList = new global::System.Windows.Forms.MenuItem();
			this.menuItem3 = new global::System.Windows.Forms.MenuItem();
			this.mnuFilePrintView = new global::System.Windows.Forms.MenuItem();
			this.mnuSep3 = new global::System.Windows.Forms.MenuItem();
			this.mnuFileExit = new global::System.Windows.Forms.MenuItem();
			this.mnuView = new global::System.Windows.Forms.MenuItem();
			this.mnuReports = new global::System.Windows.Forms.MenuItem();
			this.mnuActions = new global::System.Windows.Forms.MenuItem();
			this.mnuOptions = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsGoStop = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsFaster = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsSlower = new global::System.Windows.Forms.MenuItem();
			this.mnuSep9385 = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsRunTo = new global::System.Windows.Forms.MenuItem();
			this.menuMessagesSep = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsShowMessages = new global::System.Windows.Forms.MenuItem();
			this.mnuSep4 = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsBackgroundMusic = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsSoundEffects = new global::System.Windows.Forms.MenuItem();
			this.mnuSep6 = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsIA = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsIACustomizeYourSim = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsIAProvideCash = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsTuning = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsChangeOwner = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsRenameEntity = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsMacros = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsMacrosRecordMacro = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsMacroStopRecording = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsMacrosPlayMacro = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsMacrosStopPlaying = new global::System.Windows.Forms.MenuItem();
			this.mnuOptionsTestResults = new global::System.Windows.Forms.MenuItem();
			this.mnuHelp = new global::System.Windows.Forms.MenuItem();
			this.mnuHelpTopicsAndIndex = new global::System.Windows.Forms.MenuItem();
			this.mnuHelpTutorial = new global::System.Windows.Forms.MenuItem();
			this.mnuHelpSearch = new global::System.Windows.Forms.MenuItem();
			this.mnuSep7 = new global::System.Windows.Forms.MenuItem();
			this.mnuHelpAssignment = new global::System.Windows.Forms.MenuItem();
			this.mnuSep8 = new global::System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new global::System.Windows.Forms.MenuItem();
			this.staMain = new global::System.Windows.Forms.StatusBar();
			this.DatePanel = new global::System.Windows.Forms.StatusBarPanel();
			this.DayOfWeekPanel = new global::System.Windows.Forms.StatusBarPanel();
			this.TimePanel = new global::System.Windows.Forms.StatusBarPanel();
			this.NewMessagesPanel = new global::System.Windows.Forms.StatusBarPanel();
			this.CreateMessagePanel = new global::System.Windows.Forms.StatusBarPanel();
			this.Level = new global::System.Windows.Forms.StatusBarPanel();
			this.SpacerPanel = new global::System.Windows.Forms.StatusBarPanel();
			this.CurrentEntityNamePanel = new global::System.Windows.Forms.StatusBarPanel();
			this.CurrentEntityPanel = new global::System.Windows.Forms.StatusBarPanel();
			this.EntityCriticalResourceNamePanel = new global::System.Windows.Forms.StatusBarPanel();
			this.EntityCriticalResourcePanel = new global::System.Windows.Forms.StatusBarPanel();
			this.tlbMain = new global::KMI.Sim.ToolbarSponsored();
			this.ilsMainToolBar = new global::System.Windows.Forms.ImageList(this.components);
			this.pnlMain = new global::System.Windows.Forms.Panel();
			this.picMain = new global::System.Windows.Forms.PictureBox();
			this.viewToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.backgroundMusicTimer = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.DatePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.DayOfWeekPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.TimePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.NewMessagesPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.CreateMessagePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.Level).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.SpacerPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityNamePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourceNamePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourcePanel).BeginInit();
			this.pnlMain.SuspendLayout();
			base.SuspendLayout();
			this.mainMenu1.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuFile,
				this.mnuView,
				this.mnuReports,
				this.mnuActions,
				this.mnuOptions,
				this.mnuHelp
			});
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuFileNew,
				this.mnuFileOpenLesson,
				this.mnuFileOpenSavedSim,
				this.mnuSep1,
				this.mnuFileSave,
				this.mnuFileSaveAs,
				this.mnuFileUploadSeparator,
				this.mnuFileMultiplayer,
				this.menuItem3,
				this.mnuFilePrintView,
				this.mnuSep3,
				this.mnuFileExit
			});
			this.mnuFile.Text = "&File";
			this.mnuFileNew.Index = 0;
			this.mnuFileNew.Text = "&New...";
			this.mnuFileNew.Click += new global::System.EventHandler(this.mnuFileNew_Click);
			this.mnuFileOpenLesson.Index = 1;
			this.mnuFileOpenLesson.Text = "&Open Lesson...";
			this.mnuFileOpenLesson.Click += new global::System.EventHandler(this.mnuFileOpenLesson_Click);
			this.mnuFileOpenSavedSim.Index = 2;
			this.mnuFileOpenSavedSim.Text = "Open S&aved Sim...";
			this.mnuFileOpenSavedSim.Click += new global::System.EventHandler(this.mnuFileOpenSavedSim_Click);
			this.mnuSep1.Index = 3;
			this.mnuSep1.Text = "-";
			this.mnuFileSave.Index = 4;
			this.mnuFileSave.Text = "Sa&ve";
			this.mnuFileSave.Click += new global::System.EventHandler(this.mnuFileSave_Click);
			this.mnuFileSaveAs.Index = 5;
			this.mnuFileSaveAs.Text = "Sav&e As...";
			this.mnuFileSaveAs.Click += new global::System.EventHandler(this.mnuFileSaveAs_Click);
			this.mnuFileUploadSeparator.Index = 6;
			this.mnuFileUploadSeparator.Text = "-";
			this.mnuFileUploadSeparator.Visible = false;
			this.mnuFileMultiplayer.Index = 7;
			this.mnuFileMultiplayer.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuFileMultiplayerJoin,
				this.mnuFileMultiplayerStart,
				this.mnuFileMultiplayerScoreboard,
				this.mnuFileMultiplayerTeamList
			});
			this.mnuFileMultiplayer.Text = "&Multiplayer";
			this.mnuFileMultiplayerJoin.Index = 0;
			this.mnuFileMultiplayerJoin.Text = "&Join Session";
			this.mnuFileMultiplayerJoin.Click += new global::System.EventHandler(this.mnuFileMultiplayerJoin_Click);
			this.mnuFileMultiplayerStart.Index = 1;
			this.mnuFileMultiplayerStart.Text = "&Start Session";
			this.mnuFileMultiplayerStart.Click += new global::System.EventHandler(this.mnuFileMultiplayerStart_Click);
			this.mnuFileMultiplayerScoreboard.Index = 2;
			this.mnuFileMultiplayerScoreboard.Text = "S&coreboard";
			this.mnuFileMultiplayerScoreboard.Click += new global::System.EventHandler(this.mnuFileMultiplayerScoreboard_Click);
			this.mnuFileMultiplayerTeamList.Index = 3;
			this.mnuFileMultiplayerTeamList.Text = "&Team List";
			this.mnuFileMultiplayerTeamList.Click += new global::System.EventHandler(this.mnuFileMultiplayerTeamList_Click);
			this.menuItem3.Index = 8;
			this.menuItem3.Text = "-";
			this.mnuFilePrintView.Index = 9;
			this.mnuFilePrintView.Text = "&Print View...";
			this.mnuFilePrintView.Click += new global::System.EventHandler(this.mnuFilePrintView_Click);
			this.mnuSep3.Index = 10;
			this.mnuSep3.Text = "-";
			this.mnuFileExit.Index = 11;
			this.mnuFileExit.Text = "E&xit";
			this.mnuFileExit.Click += new global::System.EventHandler(this.mnuFileExit_Click);
			this.mnuView.Index = 1;
			this.mnuView.Text = "&View";
			this.mnuReports.Index = 2;
			this.mnuReports.Text = "&Reports";
			this.mnuActions.Index = 3;
			this.mnuActions.Text = "&Actions";
			this.mnuActions.Select += new global::System.EventHandler(this.mnuActions_Select);
			this.mnuOptions.Index = 4;
			this.mnuOptions.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuOptionsGoStop,
				this.mnuOptionsFaster,
				this.mnuOptionsSlower,
				this.mnuSep9385,
				this.mnuOptionsRunTo,
				this.menuMessagesSep,
				this.mnuOptionsShowMessages,
				this.mnuSep4,
				this.mnuOptionsBackgroundMusic,
				this.mnuOptionsSoundEffects,
				this.mnuSep6,
				this.mnuOptionsIA,
				this.mnuOptionsTuning,
				this.mnuOptionsChangeOwner,
				this.mnuOptionsRenameEntity,
				this.mnuOptionsMacros,
				this.mnuOptionsTestResults
			});
			this.mnuOptions.Text = "&Options";
			this.mnuOptionsGoStop.Index = 0;
			this.mnuOptionsGoStop.Text = "&Go";
			this.mnuOptionsGoStop.Click += new global::System.EventHandler(this.mnuOptionsGoStop_Click);
			this.mnuOptionsFaster.Index = 1;
			this.mnuOptionsFaster.Text = "&Faster";
			this.mnuOptionsFaster.Click += new global::System.EventHandler(this.mnuOptionsFaster_Click);
			this.mnuOptionsSlower.Index = 2;
			this.mnuOptionsSlower.Text = "&Slower";
			this.mnuOptionsSlower.Click += new global::System.EventHandler(this.mnuOptionsSlower_Click);
			this.mnuSep9385.Index = 3;
			this.mnuSep9385.Text = "-";
			this.mnuOptionsRunTo.Index = 4;
			this.mnuOptionsRunTo.Text = "Run to...";
			this.mnuOptionsRunTo.Click += new global::System.EventHandler(this.mnuOptionsRunTo_Click);
			this.menuMessagesSep.Index = 5;
			this.menuMessagesSep.Text = "-";
			this.mnuOptionsShowMessages.Checked = true;
			this.mnuOptionsShowMessages.Index = 6;
			this.mnuOptionsShowMessages.Text = "Show Messages";
			this.mnuOptionsShowMessages.Click += new global::System.EventHandler(this.mnuOptionsShowMessages_Click);
			this.mnuSep4.Index = 7;
			this.mnuSep4.Text = "-";
			this.mnuOptionsBackgroundMusic.Index = 8;
			this.mnuOptionsBackgroundMusic.Text = "&Background Music";
			this.mnuOptionsBackgroundMusic.Click += new global::System.EventHandler(this.mnuOptionsBackgroundMusic_Click);
			this.mnuOptionsSoundEffects.Checked = true;
			this.mnuOptionsSoundEffects.Index = 9;
			this.mnuOptionsSoundEffects.Text = "S&ound Effects";
			this.mnuOptionsSoundEffects.Click += new global::System.EventHandler(this.mnuOptionsSoundEffects_Click);
			this.mnuSep6.Index = 10;
			this.mnuSep6.Text = "-";
			this.mnuOptionsIA.Index = 11;
			this.mnuOptionsIA.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuOptionsIACustomizeYourSim,
				this.mnuOptionsIAProvideCash
			});
			this.mnuOptionsIA.Text = "&Instructor's Area";
			this.mnuOptionsIACustomizeYourSim.Index = 0;
			this.mnuOptionsIACustomizeYourSim.Text = "Enable/Disable &Features...";
			this.mnuOptionsIACustomizeYourSim.Click += new global::System.EventHandler(this.mnuOptionsIACustomizeYourSim_Click);
			this.mnuOptionsIAProvideCash.Index = 1;
			this.mnuOptionsIAProvideCash.Text = "&Provide Cash...";
			this.mnuOptionsIAProvideCash.Click += new global::System.EventHandler(this.mnuOptionsIAProvideCash_Click);
			this.mnuOptionsTuning.Index = 12;
			this.mnuOptionsTuning.Text = "Tuning";
			this.mnuOptionsTuning.Click += new global::System.EventHandler(this.mnuOptionsTuning_Click);
			this.mnuOptionsChangeOwner.Index = 13;
			this.mnuOptionsChangeOwner.Text = "Change Owner";
			this.mnuOptionsChangeOwner.Click += new global::System.EventHandler(this.mnuOptionsChangeOwner_Click);
			this.mnuOptionsRenameEntity.Index = 14;
			this.mnuOptionsRenameEntity.Text = "Rename Entity";
			this.mnuOptionsRenameEntity.Click += new global::System.EventHandler(this.mnuOptionsRenameEntity_Click);
			this.mnuOptionsMacros.Index = 15;
			this.mnuOptionsMacros.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuOptionsMacrosRecordMacro,
				this.mnuOptionsMacroStopRecording,
				this.mnuOptionsMacrosPlayMacro,
				this.mnuOptionsMacrosStopPlaying
			});
			this.mnuOptionsMacros.Text = "&Macros";
			this.mnuOptionsMacrosRecordMacro.Index = 0;
			this.mnuOptionsMacrosRecordMacro.Text = "&Record Macro";
			this.mnuOptionsMacrosRecordMacro.Click += new global::System.EventHandler(this.mnuOptionsMacrosRecordMacro_Click);
			this.mnuOptionsMacroStopRecording.Enabled = false;
			this.mnuOptionsMacroStopRecording.Index = 1;
			this.mnuOptionsMacroStopRecording.Text = "&Stop Recording";
			this.mnuOptionsMacroStopRecording.Click += new global::System.EventHandler(this.mnuOptionsMacroStopRecording_Click);
			this.mnuOptionsMacrosPlayMacro.Index = 2;
			this.mnuOptionsMacrosPlayMacro.Text = "&Play Macro";
			this.mnuOptionsMacrosPlayMacro.Click += new global::System.EventHandler(this.mnuOptionsMacrosPlayMacro_Click);
			this.mnuOptionsMacrosStopPlaying.Enabled = false;
			this.mnuOptionsMacrosStopPlaying.Index = 3;
			this.mnuOptionsMacrosStopPlaying.Text = "S&top Playing";
			this.mnuOptionsMacrosStopPlaying.Click += new global::System.EventHandler(this.mnuOptionsMacrosStopPlaying_Click);
			this.mnuOptionsTestResults.Index = 16;
			this.mnuOptionsTestResults.Text = "Test Results...";
			this.mnuOptionsTestResults.Visible = false;
			this.mnuOptionsTestResults.Click += new global::System.EventHandler(this.mnuOptionsTestResults_Click);
			this.mnuHelp.Index = 5;
			this.mnuHelp.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuHelpTopicsAndIndex,
				this.mnuHelpTutorial,
				this.mnuHelpSearch,
				this.mnuSep7,
				this.mnuHelpAssignment,
				this.mnuSep8,
				this.mnuHelpAbout
			});
			this.mnuHelp.Text = "&Help";
			this.mnuHelpTopicsAndIndex.Index = 0;
			this.mnuHelpTopicsAndIndex.Text = "&Topics && Index...";
			this.mnuHelpTopicsAndIndex.Click += new global::System.EventHandler(this.mnuHelpTopicsAndIndex_Click);
			this.mnuHelpTutorial.Index = 1;
			this.mnuHelpTutorial.Text = "T&utorial...";
			this.mnuHelpTutorial.Click += new global::System.EventHandler(this.mnuHelpTutorial_Click);
			this.mnuHelpSearch.Index = 2;
			this.mnuHelpSearch.Text = "Sear&ch...";
			this.mnuHelpSearch.Click += new global::System.EventHandler(this.mnuHelpSearch_Click);
			this.mnuSep7.Index = 3;
			this.mnuSep7.Text = "-";
			this.mnuHelpAssignment.Index = 4;
			this.mnuHelpAssignment.Text = "A&ssignment...";
			this.mnuHelpAssignment.Click += new global::System.EventHandler(this.mnuHelpAssignment_Click);
			this.mnuSep8.Index = 5;
			this.mnuSep8.Text = "-";
			this.mnuHelpAbout.Index = 6;
			this.mnuHelpAbout.Text = "&About...";
			this.mnuHelpAbout.Click += new global::System.EventHandler(this.mnuHelpAbout_Click);
			this.staMain.Location = new global::System.Drawing.Point(0, 318);
			this.staMain.Name = "staMain";
			this.staMain.Panels.AddRange(new global::System.Windows.Forms.StatusBarPanel[]
			{
				this.DatePanel,
				this.DayOfWeekPanel,
				this.TimePanel,
				this.NewMessagesPanel,
				this.CreateMessagePanel,
				this.Level,
				this.SpacerPanel,
				this.CurrentEntityNamePanel,
				this.CurrentEntityPanel,
				this.EntityCriticalResourceNamePanel,
				this.EntityCriticalResourcePanel
			});
			this.staMain.ShowPanels = true;
			this.staMain.Size = new global::System.Drawing.Size(632, 16);
			this.staMain.SizingGrip = false;
			this.staMain.TabIndex = 2;
			this.staMain.PanelClick += new global::System.Windows.Forms.StatusBarPanelClickEventHandler(this.staMain_PanelClick);
			this.DatePanel.Alignment = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.DayOfWeekPanel.Width = 40;
			this.TimePanel.Alignment = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.TimePanel.Width = 60;
			this.NewMessagesPanel.BorderStyle = global::System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.NewMessagesPanel.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("NewMessagesPanel.Icon");
			this.NewMessagesPanel.MinWidth = 0;
			this.NewMessagesPanel.Text = "New Messages";
			this.NewMessagesPanel.Width = 0;
			this.CreateMessagePanel.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("CreateMessagePanel.Icon");
			this.CreateMessagePanel.MinWidth = 0;
			this.CreateMessagePanel.ToolTipText = "Send Memo to Team";
			this.CreateMessagePanel.Width = 0;
			this.Level.BorderStyle = global::System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.Level.Width = 70;
			this.SpacerPanel.AutoSize = global::System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.SpacerPanel.BorderStyle = global::System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.SpacerPanel.Width = 101;
			this.CurrentEntityNamePanel.Alignment = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.CurrentEntityNamePanel.AutoSize = global::System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.CurrentEntityNamePanel.BorderStyle = global::System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.CurrentEntityNamePanel.Text = "#";
			this.CurrentEntityNamePanel.Width = 20;
			this.EntityCriticalResourceNamePanel.Alignment = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.EntityCriticalResourceNamePanel.AutoSize = global::System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.EntityCriticalResourceNamePanel.BorderStyle = global::System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.EntityCriticalResourceNamePanel.Text = "Cash";
			this.EntityCriticalResourceNamePanel.Width = 41;
			this.EntityCriticalResourcePanel.Alignment = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.tlbMain.Appearance = global::System.Windows.Forms.ToolBarAppearance.Flat;
			this.tlbMain.DropDownArrows = true;
			this.tlbMain.ImageList = this.ilsMainToolBar;
			this.tlbMain.Location = new global::System.Drawing.Point(0, 0);
			this.tlbMain.Name = "tlbMain";
			this.tlbMain.ShowToolTips = true;
			this.tlbMain.Size = new global::System.Drawing.Size(632, 42);
			this.tlbMain.TabIndex = 0;
			this.tlbMain.ButtonClick += new global::System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbMain_ButtonClick);
			this.ilsMainToolBar.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth24Bit;
			this.ilsMainToolBar.ImageSize = new global::System.Drawing.Size(24, 24);
			this.ilsMainToolBar.TransparentColor = global::System.Drawing.Color.Transparent;
			this.pnlMain.AutoScroll = true;
			this.pnlMain.BackColor = global::System.Drawing.Color.White;
			this.pnlMain.Controls.Add(this.picMain);
			this.pnlMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new global::System.Drawing.Point(0, 42);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new global::System.Drawing.Size(632, 276);
			this.pnlMain.TabIndex = 1;
			this.picMain.BackColor = global::System.Drawing.Color.White;
			this.picMain.Location = new global::System.Drawing.Point(72, 40);
			this.picMain.Name = "picMain";
			this.picMain.Size = new global::System.Drawing.Size(312, 184);
			this.picMain.TabIndex = 0;
			this.picMain.TabStop = false;
			this.picMain.Click += new global::System.EventHandler(this.picMain_Click);
			this.picMain.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picMain_Paint);
			this.picMain.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.picMain_MouseUp);
			this.picMain.DoubleClick += new global::System.EventHandler(this.picMain_DoubleClick);
			this.picMain.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.picMain_MouseMove);
			this.picMain.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.picMain_MouseDown);
			this.viewToolTip.AutomaticDelay = 200;
			this.backgroundMusicTimer.Tick += new global::System.EventHandler(this.backgroundMusicTimer_Tick);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(632, 334);
			base.Controls.Add(this.pnlMain);
			base.Controls.Add(this.tlbMain);
			base.Controls.Add(this.staMain);
			base.Menu = this.mainMenu1;
			base.Name = "frmMainBase";
			this.Text = "#";
			base.Resize += new global::System.EventHandler(this.frmMainBase_Resize);
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmMainBase_Closing);
			base.Load += new global::System.EventHandler(this.frmMainBase_Load);
			base.Closed += new global::System.EventHandler(this.frmMainBase_Closed);
			((global::System.ComponentModel.ISupportInitialize)this.DatePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.DayOfWeekPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.TimePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.NewMessagesPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.CreateMessagePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.Level).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.SpacerPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityNamePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourceNamePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourcePanel).EndInit();
			this.pnlMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000304 RID: 772
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.MenuItem mnuFileUploadSeparator;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.Timer backgroundMusicTimer;

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.MenuItem mnuOptionsMacros;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.MenuItem mnuOptionsMacrosRecordMacro;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.MenuItem mnuOptionsMacroStopRecording;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.MenuItem mnuOptionsMacrosPlayMacro;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.MenuItem mnuOptionsMacrosStopPlaying;

		// Token: 0x0400030C RID: 780
		protected global::System.Windows.Forms.StatusBarPanel NewMessagesPanel;

		// Token: 0x0400030D RID: 781
		protected global::System.Windows.Forms.StatusBarPanel DatePanel;

		// Token: 0x0400030E RID: 782
		protected global::System.Windows.Forms.StatusBarPanel DayOfWeekPanel;

		// Token: 0x0400030F RID: 783
		protected global::System.Windows.Forms.StatusBarPanel TimePanel;

		// Token: 0x04000310 RID: 784
		protected global::System.Windows.Forms.StatusBarPanel CurrentEntityNamePanel;

		// Token: 0x04000311 RID: 785
		protected global::System.Windows.Forms.StatusBarPanel CurrentEntityPanel;

		// Token: 0x04000312 RID: 786
		protected global::System.Windows.Forms.StatusBarPanel EntityCriticalResourceNamePanel;

		// Token: 0x04000313 RID: 787
		protected global::System.Windows.Forms.StatusBarPanel EntityCriticalResourcePanel;

		// Token: 0x04000314 RID: 788
		protected global::System.Windows.Forms.StatusBarPanel SpacerPanel;

		// Token: 0x04000315 RID: 789
		protected global::System.Windows.Forms.MenuItem mnuOptionsShowMessages;

		// Token: 0x04000316 RID: 790
		private global::System.Windows.Forms.MenuItem mnuOptionsIAProvideCash;

		// Token: 0x04000317 RID: 791
		private global::System.Windows.Forms.MenuItem mnuOptionsRenameEntity;

		// Token: 0x04000318 RID: 792
		protected global::System.Windows.Forms.MenuItem menuMessagesSep;

		// Token: 0x04000319 RID: 793
		private global::System.Windows.Forms.MenuItem mnuFileMultiplayerTeamList;

		// Token: 0x0400031A RID: 794
		private global::System.Windows.Forms.StatusBarPanel Level;

		// Token: 0x0400031B RID: 795
		private global::System.Windows.Forms.StatusBarPanel CreateMessagePanel;

		// Token: 0x0400031C RID: 796
		private global::System.Windows.Forms.MenuItem mnuOptionsTestResults;

		// Token: 0x0400031D RID: 797
		private global::System.Windows.Forms.MenuItem mnuOptionsRunTo;

		// Token: 0x0400031E RID: 798
		private global::System.Windows.Forms.MenuItem mnuSep9385;

		// Token: 0x04000320 RID: 800
		private global::System.Windows.Forms.MenuItem mnuOptionsIACustomizeYourSim;

		// Token: 0x04000321 RID: 801
		private global::System.Windows.Forms.MenuItem mnuHelpSearch;

		// Token: 0x04000322 RID: 802
		protected global::System.Windows.Forms.MenuItem mnuFileMultiplayerScoreboard;

		// Token: 0x04000323 RID: 803
		private global::System.Windows.Forms.MenuItem mnuOptionsTuning;

		// Token: 0x04000324 RID: 804
		private global::System.Windows.Forms.MenuItem mnuOptionsChangeOwner;

		// Token: 0x04000327 RID: 807
		protected global::System.Windows.Forms.MainMenu mainMenu1;

		// Token: 0x04000328 RID: 808
		private global::System.Windows.Forms.MenuItem mnuFile;

		// Token: 0x04000329 RID: 809
		public global::System.Windows.Forms.MenuItem mnuFileNew;

		// Token: 0x0400032A RID: 810
		public global::System.Windows.Forms.MenuItem mnuFileOpenLesson;

		// Token: 0x0400032B RID: 811
		public global::System.Windows.Forms.MenuItem mnuFileOpenSavedSim;

		// Token: 0x0400032C RID: 812
		private global::System.Windows.Forms.MenuItem mnuFileSave;

		// Token: 0x0400032D RID: 813
		public global::System.Windows.Forms.MenuItem mnuFileSaveAs;

		// Token: 0x0400032E RID: 814
		private global::System.Windows.Forms.MenuItem mnuFilePrintView;

		// Token: 0x0400032F RID: 815
		public global::System.Windows.Forms.MenuItem mnuFileExit;

		// Token: 0x04000330 RID: 816
		protected global::System.Windows.Forms.MenuItem mnuView;

		// Token: 0x04000331 RID: 817
		protected global::System.Windows.Forms.MenuItem mnuReports;

		// Token: 0x04000332 RID: 818
		protected global::System.Windows.Forms.MenuItem mnuActions;

		// Token: 0x04000333 RID: 819
		protected global::System.Windows.Forms.MenuItem mnuOptions;

		// Token: 0x04000334 RID: 820
		private global::System.Windows.Forms.MenuItem mnuHelp;

		// Token: 0x04000335 RID: 821
		private global::System.Windows.Forms.MenuItem mnuHelpTopicsAndIndex;

		// Token: 0x04000336 RID: 822
		public global::System.Windows.Forms.MenuItem mnuHelpTutorial;

		// Token: 0x04000337 RID: 823
		private global::System.Windows.Forms.MenuItem mnuHelpAssignment;

		// Token: 0x04000338 RID: 824
		private global::System.Windows.Forms.MenuItem mnuHelpAbout;

		// Token: 0x04000339 RID: 825
		protected internal global::System.Windows.Forms.MenuItem mnuOptionsGoStop;

		// Token: 0x0400033A RID: 826
		private global::System.Windows.Forms.MenuItem mnuOptionsFaster;

		// Token: 0x0400033B RID: 827
		private global::System.Windows.Forms.MenuItem mnuOptionsSlower;

		// Token: 0x0400033C RID: 828
		private global::System.Windows.Forms.MenuItem mnuOptionsBackgroundMusic;

		// Token: 0x0400033D RID: 829
		private global::System.Windows.Forms.MenuItem mnuOptionsSoundEffects;

		// Token: 0x0400033E RID: 830
		protected global::System.Windows.Forms.MenuItem mnuOptionsIA;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.MenuItem mnuSep1;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.MenuItem mnuSep3;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.MenuItem mnuSep4;

		// Token: 0x04000342 RID: 834
		private global::System.Windows.Forms.MenuItem mnuSep6;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.MenuItem mnuSep7;

		// Token: 0x04000344 RID: 836
		private global::System.Windows.Forms.MenuItem mnuSep8;

		// Token: 0x04000345 RID: 837
		protected internal global::System.Windows.Forms.StatusBar staMain;

		// Token: 0x04000346 RID: 838
		protected global::KMI.Sim.ToolbarSponsored tlbMain;

		// Token: 0x04000347 RID: 839
		private global::System.Windows.Forms.Panel pnlMain;

		// Token: 0x04000348 RID: 840
		public global::System.Windows.Forms.PictureBox picMain;

		// Token: 0x0400034B RID: 843
		protected global::System.Windows.Forms.MenuItem mnuFileMultiplayer;

		// Token: 0x0400034C RID: 844
		private global::System.Windows.Forms.MenuItem menuItem3;

		// Token: 0x0400034D RID: 845
		public global::System.Windows.Forms.MenuItem mnuFileMultiplayerJoin;

		// Token: 0x0400034E RID: 846
		public global::System.Windows.Forms.MenuItem mnuFileMultiplayerStart;

		// Token: 0x04000350 RID: 848
		protected global::System.Windows.Forms.ImageList ilsMainToolBar;

		// Token: 0x04000351 RID: 849
		private global::System.Windows.Forms.ToolTip viewToolTip;
	}
}
