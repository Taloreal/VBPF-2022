using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x0200000D RID: 13
	public sealed class KMIHelp
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00005F0C File Offset: 0x00004F0C
		public static void OpenHelp()
		{
			string queryString = "";
			KMIHelp.OpenBrowser(queryString);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005F28 File Offset: 0x00004F28
		public static void OpenHelp(string topic)
		{
			string queryString = "?topic=" + KMIHelp.MakeSafeForDHTML(topic);
			KMIHelp.OpenBrowser(queryString);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00005F50 File Offset: 0x00004F50
		public static void OpenDefinitions()
		{
			string queryString = "?topic=DEFINITIONS";
			KMIHelp.OpenBrowser(queryString);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005F6C File Offset: 0x00004F6C
		public static void OpenDefinitions(string definition)
		{
			string queryString = "?topic=DEFINITIONS&term=" + KMIHelp.MakeSafeForDHTML(definition);
			KMIHelp.OpenBrowser(queryString);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005F94 File Offset: 0x00004F94
		public static void OpenSearch()
		{
			string queryString = "?search=true";
			KMIHelp.OpenBrowser(queryString);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005FB0 File Offset: 0x00004FB0
		public static void OpenSearch(string query)
		{
			string queryString = "?search=true&query=" + Utilities.URLEncode(query);
			KMIHelp.OpenBrowser(queryString);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005FD8 File Offset: 0x00004FD8
		private static void OpenBrowser(string queryString)
		{
			try
			{
				string str;
				try
				{
					WebRequest r = WebRequest.Create(KMIHelp.RemotePath);
					string webPage = Utilities.GetWebPage(r);
					if (webPage == "")
					{
						str = KMIHelp.LocalFileURLEncode("file:///" + KMIHelp.LocalPath.Replace("\\", "/"));
					}
					else
					{
						str = KMIHelp.RemotePath;
					}
				}
				catch
				{
					str = KMIHelp.LocalFileURLEncode("file:///" + KMIHelp.LocalPath.Replace("\\", "/"));
				}
				string executableFile = KMIHelp.GetExecutableFile(KMIHelp.LocalPath);
				Process.Start(executableFile, str + queryString);
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show(KMIHelp.rm.GetString("Could not find help files.  Please check that the following path is valid:") + "\r\n\r\n" + KMIHelp.LocalPath, "Knowledge Matters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (KMIHelp.BrowserNotFoundException)
			{
				MessageBox.Show(KMIHelp.rm.GetString("Could not find the default browser's executable file."), "Knowledge Matters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Win32Exception)
			{
				MessageBox.Show(KMIHelp.rm.GetString("Could not start the default browser."), "Knowledge Matters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Exception)
			{
				MessageBox.Show(KMIHelp.rm.GetString("Unspecified error opening help."), "Knowledge Matters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006164 File Offset: 0x00005164
		public static string MakeSafeForDHTML(string topic)
		{
			string result;
			if (topic.Equals(""))
			{
				result = topic;
			}
			else
			{
				topic = topic.Replace(" ", "_");
				topic = topic.Replace("!", "");
				topic = topic.Replace("@", "");
				topic = topic.Replace("#", "");
				topic = topic.Replace("$", "");
				topic = topic.Replace("%", "");
				topic = topic.Replace("^", "");
				topic = topic.Replace("&", "");
				topic = topic.Replace("*", "");
				topic = topic.Replace("(", "");
				topic = topic.Replace(")", "");
				topic = topic.Replace("=", "");
				topic = topic.Replace("+", "");
				topic = topic.Replace("~", "");
				topic = topic.Replace("`", "");
				topic = topic.Replace("|", "");
				topic = topic.Replace("\\", "");
				topic = topic.Replace("/", "");
				topic = topic.Replace("[", "");
				topic = topic.Replace("]", "");
				topic = topic.Replace("{", "");
				topic = topic.Replace("}", "");
				topic = topic.Replace(";", "");
				topic = topic.Replace(":", "");
				topic = topic.Replace("'", "");
				topic = topic.Replace("\"", "");
				topic = topic.Replace("?", "");
				topic = topic.Replace(",", "");
				topic = topic.Replace("<", "");
				topic = topic.Replace(">", "");
				topic = topic.Replace(".", "");
				if (char.IsNumber(topic, 0))
				{
					topic = "NuM" + topic;
				}
				result = topic;
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000063DC File Offset: 0x000053DC
		public static string MakeSafeForJavaScriptStringLiteral(string str)
		{
			str = str.Replace("\\", "\\\\");
			str = str.Replace("\"", "\\\"");
			return str;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006414 File Offset: 0x00005414
		public static string LocalFileURLEncode(string url)
		{
			url = url.Replace("%", "%25");
			url = url.Replace("^", "%5E");
			url = url.Replace("{", "%7B");
			url = url.Replace("}", "%7D");
			url = url.Replace("[", "%5B");
			url = url.Replace("]", "%5D");
			url = url.Replace("`", "%60");
			url = url.Replace(";", "%3b");
			url = url.Replace("#", "%23");
			url = url.Replace(" ", "%20");
			return url;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000064DC File Offset: 0x000054DC
		private static string GetExecutableFile(string path)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException();
			}
			StringBuilder stringBuilder = new StringBuilder(260);
			int num = KMIHelp.FindExecutable(path, "", stringBuilder);
			if (num >= 32)
			{
				return stringBuilder.ToString();
			}
			throw new KMIHelp.BrowserNotFoundException();
		}

		// Token: 0x0600008D RID: 141
		[DllImport("shell32.dll")]
		private static extern int FindExecutable(string file, string dir, StringBuilder buffer);

		// Token: 0x04000027 RID: 39
		public static string LocalPath = Application.StartupPath + "\\Help\\index.htm";

		// Token: 0x04000028 RID: 40
		public static string RemotePath = "http://help.knowledgematters.com/vbx1/help/index.htm";

		// Token: 0x04000029 RID: 41
		private static ResourceManager rm = new ResourceManager("KMI.Utility.Utility", Assembly.GetAssembly(typeof(KMIHelp)));

		// Token: 0x0200000E RID: 14
		private class BrowserNotFoundException : Exception
		{
		}
	}
}
