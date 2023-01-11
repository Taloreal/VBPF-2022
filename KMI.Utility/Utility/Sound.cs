using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x0200000C RID: 12
	public class Sound
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00005D40 File Offset: 0x00004D40
		public static int PlaySoundFromFile(string sSoundFile)
		{
			return Sound.PlaySoundFromFile(sSoundFile, false, true, false, false, false);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005D60 File Offset: 0x00004D60
		private static int PlaySoundFromFile(string sSoundFile, bool bSynchronous, bool bIgnoreErrors, bool bNoDefault, bool bLoop, bool bNoStop)
		{
			sSoundFile = Application.StartupPath + "\\" + sSoundFile;
			if (File.Exists(sSoundFile))
			{
				int num = 0;
				if (!bSynchronous)
				{
					num = 1;
				}
				if (bNoDefault)
				{
					num += 2;
				}
				if (bLoop)
				{
					num += 8;
				}
				if (bNoStop)
				{
					num += 16;
				}
				try
				{
					return Sound.sndPlaySoundA(sSoundFile, num);
				}
				catch
				{
				}
			}
			return 0;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005DE8 File Offset: 0x00004DE8
		public static bool StopMidi()
		{
			int num = -1;
			try
			{
				num = Sound.mciSendString("stop midi", ref Sound.ns, 0, 0);
				num = Sound.mciSendString("close midi", ref Sound.ns, 0, 0);
			}
			catch
			{
			}
			return num == 0;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005E40 File Offset: 0x00004E40
		public static bool PlayMidiFromFile(string filename)
		{
			int num = -1;
			string path = Application.StartupPath + "\\" + filename;
			if (File.Exists(path))
			{
				try
				{
					string currentDirectory = Environment.CurrentDirectory;
					Environment.CurrentDirectory = Application.StartupPath;
					num = Sound.mciSendString("stop midi", ref Sound.ns, 0, 0);
					num = Sound.mciSendString("close midi", ref Sound.ns, 0, 0);
					num = Sound.mciSendString("open sequencer!" + filename + " alias midi", ref Sound.ns, 0, 0);
					num = Sound.mciSendString("play midi", ref Sound.ns, 0, 0);
					Environment.CurrentDirectory = currentDirectory;
				}
				catch
				{
				}
			}
			return num == 0;
		}

		// Token: 0x0600007E RID: 126
		[DllImport("winmm.dll")]
		private static extern int mciSendString(string lpstrCommand, ref string lpstrReturnString, int uReturnLength, int hwndCallback);

		// Token: 0x0600007F RID: 127
		[DllImport("winmm.dll")]
		private static extern int sndPlaySoundA(string lpszSoundName, int uFlags);

		// Token: 0x06000080 RID: 128
		[DllImport("winmm.dll")]
		private static extern int PlaySound(byte[] pszSound, short hMod, long fdwSound);

		// Token: 0x04000026 RID: 38
		private static string ns = "";
	}
}
