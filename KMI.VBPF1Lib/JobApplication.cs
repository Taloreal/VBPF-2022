using System;
using System.Collections;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for JobApplication.
	/// </summary>
	// Token: 0x02000076 RID: 118
	[Serializable]
	public class JobApplication
	{
		// Token: 0x040003D5 RID: 981
		public string Name;

		// Token: 0x040003D6 RID: 982
		public ArrayList ReportedClassNames = new ArrayList();

		// Token: 0x040003D7 RID: 983
		public Hashtable ReportedJobNamesAndMonths = new Hashtable();

		// Token: 0x040003D8 RID: 984
		public bool Car;
	}
}
