using System;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200005D RID: 93
	public class MultiplayerRole
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000370 RID: 880 RVA: 0x000199E8 File Offset: 0x000189E8
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00019A00 File Offset: 0x00018A00
		public string RoleName
		{
			get
			{
				return this.roleName;
			}
			set
			{
				this.roleName = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00019A0C File Offset: 0x00018A0C
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00019A24 File Offset: 0x00018A24
		public string DisableListConcatenated
		{
			get
			{
				return this.disableListConcatenated;
			}
			set
			{
				this.disableListConcatenated = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00019A30 File Offset: 0x00018A30
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00019A48 File Offset: 0x00018A48
		public bool ReceivesMessages
		{
			get
			{
				return this.receivesMessages;
			}
			set
			{
				this.receivesMessages = value;
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00019A54 File Offset: 0x00018A54
		public bool DisableListContains(string text)
		{
			foreach (string b in this.DisableList)
			{
				if (Utilities.NoAmpersand(Utilities.NoEllipsis(text)) == b)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00019AA8 File Offset: 0x00018AA8
		public static void LoadRolesFromTable(Type type, string resource)
		{
			MultiplayerRole.Roles = (MultiplayerRole[])TableReader.Read(type.Assembly, typeof(MultiplayerRole), resource);
			foreach (MultiplayerRole multiplayerRole in MultiplayerRole.Roles)
			{
				multiplayerRole.DisableList = multiplayerRole.DisableListConcatenated.Split(new char[]
				{
					'|'
				});
				multiplayerRole.DisableListConcatenated = null;
			}
		}

		// Token: 0x04000232 RID: 562
		public static MultiplayerRole[] Roles;

		// Token: 0x04000233 RID: 563
		protected string roleName;

		// Token: 0x04000234 RID: 564
		protected string disableListConcatenated;

		// Token: 0x04000235 RID: 565
		public bool receivesMessages;

		// Token: 0x04000236 RID: 566
		public string[] DisableList;
	}
}
