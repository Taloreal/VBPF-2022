using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Security;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200002E RID: 46
	public partial class frmStartMultiplayerSession : Form
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x0000EE3A File Offset: 0x0000DE3A
		public frmStartMultiplayerSession()
		{
			this.InitializeComponent();
			this.chkRequireRoles.Visible = S.I.AllowRoleBasedMultiplayer;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000F2BC File Offset: 0x0000E2BC
		private void cmdOK_Click(object sender, EventArgs e)
		{
			BinaryServerFormatterSinkProvider binaryServerFormatterSinkProvider = new BinaryServerFormatterSinkProvider();
			binaryServerFormatterSinkProvider.TypeFilterLevel = TypeFilterLevel.Full;
			IDictionary dictionary = new Hashtable();
			for (int i = 0; i < S.I.UserAdminSettings.MultiplayerPortCount; i++)
			{
				try
				{
					BinaryClientFormatterSinkProvider clientSinkProvider = new BinaryClientFormatterSinkProvider();
					dictionary["port"] = S.I.UserAdminSettings.MultiplayerBasePort + i;
					if (frmStartMultiplayerSession.serverChannel == null)
					{
						frmStartMultiplayerSession.serverChannel = new TcpChannel(dictionary, clientSinkProvider, binaryServerFormatterSinkProvider);
						if (ChannelServices.GetChannel(frmStartMultiplayerSession.serverChannel.ChannelName) == null)
						{
							ChannelServices.RegisterChannel(frmStartMultiplayerSession.serverChannel);
						}
					}
					break;
				}
				catch (SecurityException ex)
				{
					MessageBox.Show("Your application was not granted permission to open a channel for a host session on this computer. " + ex.Message);
					base.DialogResult = DialogResult.Cancel;
					base.Close();
					return;
				}
				catch
				{
				}
			}
			if (frmStartMultiplayerSession.serverChannel == null)
			{
				MessageBox.Show("Could not make a host session available from this computer.  This is most likely due to network security settings.  Please have your network administrator contact us to resolve this.");
				base.DialogResult = DialogResult.Cancel;
				base.Close();
				return;
			}
			try
			{
				RemotingServices.Marshal(S.SA, this.txtSessionName.Text, S.SA.GetType());
				Simulator.Instance.SessionName = this.txtSessionName.Text;
			}
			catch (SecurityException ex)
			{
				MessageBox.Show("Your application was not granted permission to host a session on this computer. " + ex.Message);
				base.DialogResult = DialogResult.Cancel;
				base.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show("Could not start a host session session. " + ex2.Message);
				base.DialogResult = DialogResult.Cancel;
				base.Close();
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000F4A8 File Offset: 0x0000E4A8
		private void txtSessionName_Validating(object sender, CancelEventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				MessageBox.Show("You must enter a session name. It may be any name you choose. Please retry.");
				base.ActiveControl = (Control)sender;
				e.Cancel = true;
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000F4F4 File Offset: 0x0000E4F4
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("MULTIPLAYER");
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000F502 File Offset: 0x0000E502
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x04000127 RID: 295
		private static TcpChannel serverChannel;
	}
}
