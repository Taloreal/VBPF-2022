using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Security;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200000A RID: 10
	public partial class frmJoinMultiplayerSession : Form
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x000063B4 File Offset: 0x000053B4
		public frmJoinMultiplayerSession()
		{
			this.InitializeComponent();
			this.txtTeamName.MaxLength = 12;
			if (S.I.UserAdminSettings.PasswordsForMultiplayer)
			{
				this.labPassword.Visible = true;
				this.txtPassword.Visible = true;
				this.labPasswordHelp.Visible = true;
				base.Height += 56;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006D38 File Offset: 0x00005D38
		private void cmdOK_Click(object sender, EventArgs e)
		{
			this.labWait.Visible = true;
			this.labWait.Refresh();
			if (this.txtComputerName.Text == "" || this.txtSessionName.Text == "" || this.txtTeamName.Text == "")
			{
				MessageBox.Show("Please fill in all fields.");
				if (this.txtComputerName.Text == "")
				{
					this.txtComputerName.Focus();
				}
				else if (this.txtSessionName.Text == "")
				{
					this.txtSessionName.Focus();
				}
				else
				{
					this.txtTeamName.Focus();
				}
			}
			else
			{
				this.Cursor = Cursors.WaitCursor;
				try
				{
					BinaryClientFormatterSinkProvider clientSinkProvider = new BinaryClientFormatterSinkProvider();
					BinaryServerFormatterSinkProvider binaryServerFormatterSinkProvider = new BinaryServerFormatterSinkProvider();
					binaryServerFormatterSinkProvider.TypeFilterLevel = TypeFilterLevel.Full;
					IDictionary dictionary = new Hashtable();
					dictionary["port"] = 0;
					TcpChannel tcpChannel = new TcpChannel(dictionary, clientSinkProvider, binaryServerFormatterSinkProvider);
					if (ChannelServices.GetChannel(tcpChannel.ChannelName) == null)
					{
						ChannelServices.RegisterChannel(tcpChannel);
					}
				}
				catch (RemotingException)
				{
				}
				catch (SecurityException ex)
				{
					MessageBox.Show("Your application was not granted permission to open a channel to a host session. " + ex.Message);
					this.CleanupForCancel();
					return;
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Failed trying to open a channel to the host session. " + ex2.Message);
					this.CleanupForCancel();
					return;
				}
				try
				{
					IPHostEntry hostByName = Dns.GetHostByName(this.txtComputerName.Text);
				}
				catch (Exception ex2)
				{
				}
				Type type = Simulator.Instance.SimFactory.CreateSimStateAdapter().GetType();
				this.remoteAdapter = null;
				bool flag = false;
				for (int i = 0; i < S.I.UserAdminSettings.MultiplayerPortCount; i++)
				{
					int num = S.I.UserAdminSettings.MultiplayerBasePort + i;
					string url = string.Concat(new object[]
					{
						"tcp://",
						this.txtComputerName.Text,
						":",
						num,
						"/",
						this.txtSessionName.Text
					});
					try
					{
						this.remoteAdapter = (SimStateAdapter)Activator.GetObject(type, url);
						flag = this.remoteAdapter.Ping();
						break;
					}
					catch (MemberAccessException ex3)
					{
						MessageBox.Show("This member was invoked with a late-binding mechanism. " + ex3.Message);
						this.CleanupForCancel();
						return;
					}
					catch (Exception)
					{
					}
				}
				if (!flag)
				{
					string caption = "Error While Joining";
					string text = string.Concat(new string[]
					{
						"Could not connect to the session named ",
						this.txtSessionName.Text,
						" on the computer named ",
						this.txtComputerName.Text,
						".  Please make sure your computer is connected to the network and the session and computer names are spelled correctly."
					});
					MessageBox.Show(this, text, caption);
					this.labWait.Visible = false;
					this.Cursor = Cursors.Default;
				}
				else if (this.remoteAdapter.GetSimulatorID() == S.I.GUID)
				{
					string caption = "Error While Joining";
					string text = "You have just tried to connect this host session to itself.  If you would like to join this host session from from a client session on this computer, you need to join from a new " + Application.ProductName + " simulation.";
					MessageBox.Show(this, text, caption);
					this.labWait.Visible = false;
					this.Cursor = Cursors.Default;
				}
				else
				{
					try
					{
						Player player = this.remoteAdapter.CreateClientPlayer(this.txtTeamName.Text, this.txtPassword.Text);
						this.player = player;
						this.txtTeamName.Text = player.PlayerName;
						if (this.remoteAdapter.RoleBasedMultiplayer())
						{
							base.Hide();
							frmMultiplayerRole frmMultiplayerRole = new frmMultiplayerRole();
							frmMultiplayerRole.ShowDialog(this);
							this.MultiplayerRoleName = frmMultiplayerRole.RoleName;
						}
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
					catch (frmJoinMultiplayerSession.BadTeamPasswordException)
					{
						MessageBox.Show(S.R.GetString("Password incorrect. Please try again. Note: Passwords must be at least {0} characters long.", new object[]
						{
							3
						}), S.R.GetString("Password Incorrect"));
						this.Cursor = Cursors.Default;
					}
					catch (frmJoinMultiplayerSession.OverMultiplayerLimitException)
					{
						MessageBox.Show("The host session is full.  No other players may join.");
						this.CleanupForCancel();
					}
				}
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007240 File Offset: 0x00006240
		private void CleanupForCancel()
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00007252 File Offset: 0x00006252
		private void txtComputerName_Validating(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00007255 File Offset: 0x00006255
		private void txtSessionName_Validating(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007258 File Offset: 0x00006258
		private void txtTeamName_Validating(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000725B File Offset: 0x0000625B
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("MULTIPLAYER");
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00007269 File Offset: 0x00006269
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000727C File Offset: 0x0000627C
		public SimStateAdapter RemoteAdapter
		{
			get
			{
				return this.remoteAdapter;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00007294 File Offset: 0x00006294
		public string TeamName
		{
			get
			{
				return this.txtTeamName.Text;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000072B4 File Offset: 0x000062B4
		public string SessionName
		{
			get
			{
				return this.txtSessionName.Text;
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000072D1 File Offset: 0x000062D1
		private void labPasswordHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show(S.R.GetString("If this is the first time you are joining a multiplayer session under this team name, type any password to set your team password. If you are rejoining the multiplayer session, type the password you previously entered for your team name."), S.R.GetString("Multiplayer Passwords"));
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000072F8 File Offset: 0x000062F8
		public Player Player
		{
			get
			{
				return this.player;
			}
		}

		// Token: 0x0400006C RID: 108
		protected SimStateAdapter remoteAdapter;

		// Token: 0x0400006D RID: 109
		public string MultiplayerRoleName = "";

		// Token: 0x0400006E RID: 110
		protected Player player;

		// Token: 0x0200000C RID: 12
		[Serializable]
		public class OverMultiplayerLimitException : SimApplicationException
		{
			// Token: 0x060000B6 RID: 182 RVA: 0x00007388 File Offset: 0x00006388
			public OverMultiplayerLimitException()
			{
			}

			// Token: 0x060000B7 RID: 183 RVA: 0x00007393 File Offset: 0x00006393
			public OverMultiplayerLimitException(string messageStringResource) : base(messageStringResource)
			{
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x0000739F File Offset: 0x0000639F
			public OverMultiplayerLimitException(SerializationInfo info, StreamingContext context)
			{
			}
		}

		// Token: 0x0200000D RID: 13
		[Serializable]
		public class BadTeamPasswordException : SimApplicationException
		{
			// Token: 0x060000B9 RID: 185 RVA: 0x000073AA File Offset: 0x000063AA
			public BadTeamPasswordException()
			{
			}

			// Token: 0x060000BA RID: 186 RVA: 0x000073B5 File Offset: 0x000063B5
			public BadTeamPasswordException(string messageStringResource) : base(messageStringResource)
			{
			}

			// Token: 0x060000BB RID: 187 RVA: 0x000073C1 File Offset: 0x000063C1
			public BadTeamPasswordException(SerializationInfo info, StreamingContext context)
			{
			}
		}
	}
}
