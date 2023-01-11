using System;

namespace KMI.Sim
{
	// Token: 0x02000002 RID: 2
	public class S
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000105C
		public static Simulator I
		{
			get
			{
				return Simulator.Instance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002074 File Offset: 0x00001074
		public static frmMainBase MF
		{
			get
			{
				return frmMainBase.Instance;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000208C File Offset: 0x0000108C
		public static SimState ST
		{
			get
			{
				return Simulator.Instance.SimState;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020A8 File Offset: 0x000010A8
		public static SimSettings SS
		{
			get
			{
				return Simulator.Instance.SimState.SimSettings;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020CC File Offset: 0x000010CC
		public static SimStateAdapter SA
		{
			get
			{
				return Simulator.Instance.SimStateAdapter;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E8 File Offset: 0x000010E8
		public static Resource R
		{
			get
			{
				return Simulator.Instance.Resource;
			}
		}
	}
}
