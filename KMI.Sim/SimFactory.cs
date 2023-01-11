using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim.Surveys;

namespace KMI.Sim
{
	// Token: 0x02000071 RID: 113
	public class SimFactory
	{
		// Token: 0x0600041D RID: 1053 RVA: 0x0001DCA0 File Offset: 0x0001CCA0
		public virtual Simulator CreateSimulator()
		{
			return new Simulator(this);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0001DCB8 File Offset: 0x0001CCB8
		public virtual SimState CreateSimState(SimSettings simSettings, bool multiplayer)
		{
			return new SimState(simSettings, multiplayer);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001DCD4 File Offset: 0x0001CCD4
		public virtual View[] CreateViews()
		{
			return new View[0];
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001DCEC File Offset: 0x0001CCEC
		public virtual SortedList CreateImageTable()
		{
			return null;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0001DD00 File Offset: 0x0001CD00
		public virtual SortedList CreatePageTable()
		{
			return null;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0001DD14 File Offset: 0x0001CD14
		public virtual SortedList CreateCursorTable()
		{
			return null;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0001DD28 File Offset: 0x0001CD28
		public virtual UserAdminSettings CreateUserAdminSettings()
		{
			UserAdminSettings userAdminSettings = new UserAdminSettings();
			AppSettingsReader appSettingsReader = new AppSettingsReader();
			userAdminSettings.DefaultDirectory = (string)appSettingsReader.GetValue("DefaultDirectory", typeof(string));
			userAdminSettings.P = (int)appSettingsReader.GetValue("P", typeof(int));
			userAdminSettings.ProxyAddress = (string)appSettingsReader.GetValue("ProxyAddress", typeof(string));
			userAdminSettings.ProxyBypassList = (string)appSettingsReader.GetValue("ProxyBypassList", typeof(string));
			userAdminSettings.NoSound = (bool)appSettingsReader.GetValue("NoSound", typeof(bool));
			userAdminSettings.MultiplayerBasePort = (int)appSettingsReader.GetValue("MultiplayerBasePort", typeof(int));
			userAdminSettings.MultiplayerPortCount = (int)appSettingsReader.GetValue("MultiplayerPortCount", typeof(int));
			userAdminSettings.ClientDrawStepPeriod = (int)appSettingsReader.GetValue("ClientDrawStepPeriod", typeof(int));
			userAdminSettings.PasswordsForMultiplayer = (bool)appSettingsReader.GetValue("PasswordsForMultiplayer", typeof(bool));
			return userAdminSettings;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0001DE70 File Offset: 0x0001CE70
		public virtual SimEngine CreateSimEngine()
		{
			return new SimEngine();
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0001DE88 File Offset: 0x0001CE88
		public virtual Resource CreateResource()
		{
			ResourceManager resourceManager = new ResourceManager("KMI.Sim.Sim", Assembly.GetAssembly(typeof(SimFactory)));
			return new Resource(new ResourceManager[]
			{
				resourceManager
			});
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0001DEC8 File Offset: 0x0001CEC8
		public virtual Entity CreateEntity(Player player, string entityName)
		{
			return new Entity(player, entityName);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0001DEE4 File Offset: 0x0001CEE4
		public virtual Player CreatePlayer(string playerName, PlayerType playerType)
		{
			return new Player(playerName, playerType);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001DF00 File Offset: 0x0001CF00
		public virtual SimStateAdapter CreateSimStateAdapter()
		{
			return new SimStateAdapter();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001DF18 File Offset: 0x0001CF18
		protected Bitmap CBmp(Type typeFromAssembly, string filename)
		{
			Bitmap bitmap = new Bitmap(typeFromAssembly, filename);
			bitmap.SetResolution(96f, 96f);
			if (bitmap == null)
			{
				throw new Exception("In SimFactory.CreateCompatibleBitmap, could not get image from filename " + filename);
			}
			Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, S.MF.picMain.CreateGraphics());
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImageUnscaled(bitmap, 0, 0);
			return bitmap2;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0001DF9C File Offset: 0x0001CF9C
		protected Page CPage(Type typeFromAssembly, string filename, int cols, int rows, int anchorX, int anchorY)
		{
			return new Page(this.CBmp(typeFromAssembly, filename), cols, rows, anchorX, anchorY);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0001DFC4 File Offset: 0x0001CFC4
		protected Cursor CCursor(Type typeFromAssembly, string filename)
		{
			Bitmap bitmap = this.CBmp(typeFromAssembly, filename);
			return new Cursor(bitmap.GetHicon());
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0001DFEC File Offset: 0x0001CFEC
		public virtual SimSettings CreateSimSettings()
		{
			return new SimSettings();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0001E004 File Offset: 0x0001D004
		public virtual Survey CreateSurvey(long entityID, DateTime date, string[] entityNames, ArrayList surveyQuestions)
		{
			return new Survey(entityID, date, entityNames, surveyQuestions);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001E020 File Offset: 0x0001D020
		protected void LoadWithCompassPoints(SortedList table, Type type, string baseResourceName, string fileExtension)
		{
			string[] array = baseResourceName.Split(new char[]
			{
				'.'
			});
			string str = array[array.Length - 1];
			foreach (string text in new string[]
			{
				"N",
				"S"
			})
			{
				foreach (string text2 in new string[]
				{
					"E",
					"W"
				})
				{
					table.Add(str + text + text2, this.CBmp(type, string.Concat(new string[]
					{
						baseResourceName,
						text,
						text2,
						".",
						fileExtension
					})));
				}
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001E114 File Offset: 0x0001D114
		protected void LoadWith8CompassPoints(SortedList table, Type type, string baseResourceName, string fileExtension)
		{
			this.LoadWithCompassPoints(table, type, baseResourceName, fileExtension);
			string[] array = baseResourceName.Split(new char[]
			{
				'.'
			});
			string str = array[array.Length - 1];
			foreach (string str2 in new string[]
			{
				"N",
				"S",
				"E",
				"W"
			})
			{
				table.Add(str + str2, this.CBmp(type, baseResourceName + str2 + "." + fileExtension));
			}
		}
	}
}
