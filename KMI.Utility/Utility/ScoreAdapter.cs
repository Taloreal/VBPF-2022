using System;
using System.Collections;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x0200000A RID: 10
	public class ScoreAdapter : MarshalByRefObject
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00005760 File Offset: 0x00004760
		static ScoreAdapter()
		{
			AppSettingsReader appSettingsReader = new AppSettingsReader();
			ScoreAdapter.ServerName = (string)appSettingsReader.GetValue("ScoreAdapterServerName", typeof(string));
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005794 File Offset: 0x00004794
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void SendScore(string name, float amount)
		{
			if (this.scores.ContainsKey(name))
			{
				this.scores[name] = amount;
			}
			else
			{
				this.scores.Add(name, amount);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000057E0 File Offset: 0x000047E0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual Hashtable GetScores()
		{
			return (Hashtable)this.scores.Clone();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005804 File Offset: 0x00004804
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool Ping()
		{
			return true;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005818 File Offset: 0x00004818
		public static ScoreAdapter JoinScoring()
		{
			ScoreAdapter result;
			if (ScoreAdapter.ServerName == "")
			{
				result = null;
			}
			else
			{
				ScoreAdapter scoreAdapter = null;
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
				catch (Exception ex)
				{
					MessageBox.Show("Failed trying to open a channel to the host session. " + ex.Message);
					return null;
				}
				Type typeFromHandle = typeof(ScoreAdapter);
				bool flag = false;
				for (int i = 0; i < 10; i++)
				{
					int num = 20172 + i;
					string url = string.Concat(new object[]
					{
						"tcp://",
						ScoreAdapter.ServerName,
						":",
						num,
						"/VBC"
					});
					try
					{
						scoreAdapter = (ScoreAdapter)Activator.GetObject(typeFromHandle, url);
						flag = scoreAdapter.Ping();
						break;
					}
					catch (Exception)
					{
					}
				}
				if (!flag)
				{
					string caption = "Error While Joining";
					string text = "Could not connect to the session named VBC on the computer named " + ScoreAdapter.ServerName + ".  Please make sure your computer is connected to the network and the session and computer names are spelled correctly.";
					MessageBox.Show(text, caption);
					result = null;
				}
				else
				{
					result = scoreAdapter;
				}
			}
			return result;
		}

		// Token: 0x0400001E RID: 30
		private Hashtable scores = new Hashtable();

		// Token: 0x0400001F RID: 31
		protected static string ServerName;
	}
}
