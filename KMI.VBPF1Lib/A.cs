using System;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// This class contains several static properties that
	/// act as syntactic shortcuts to important sim variables.
	/// </summary>
	// Token: 0x0200000C RID: 12
	public class A
	{
		/// <summary>
		/// Shortcut to AppSimSettings.
		/// </summary>
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00004210 File Offset: 0x00003210
		public static AppSimSettings SS
		{
			get
			{
				return (AppSimSettings)Simulator.Instance.SimState.SimSettings;
			}
		}

		/// <summary>
		/// Shortcut to AppSimState.
		/// </summary>
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00004238 File Offset: 0x00003238
		public static AppSimState ST
		{
			get
			{
				return (AppSimState)Simulator.Instance.SimState;
			}
		}

		/// <summary>
		/// Shortcut to AppStateAdapter.
		/// </summary>
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000425C File Offset: 0x0000325C
		public static AppStateAdapter SA
		{
			get
			{
				return (AppStateAdapter)Simulator.Instance.SimStateAdapter;
			}
		}

		/// <summary>
		/// Shortcut to the singleton instance of Simulator.
		/// </summary>
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00004280 File Offset: 0x00003280
		public static Simulator I
		{
			get
			{
				return Simulator.Instance;
			}
		}

		/// <summary>
		/// Shortcut to the singleton instance of the Main Form.
		/// </summary>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00004298 File Offset: 0x00003298
		public static frmMain MF
		{
			get
			{
				return (frmMain)frmMainBase.Instance;
			}
		}

		/// <summary>
		/// Shortcut to the application's resource handler.
		/// </summary>
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000042B4 File Offset: 0x000032B4
		public static Resource R
		{
			get
			{
				return Simulator.Instance.Resource;
			}
		}
	}
}
