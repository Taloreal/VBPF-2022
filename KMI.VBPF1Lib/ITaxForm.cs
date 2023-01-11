using System;
using System.Drawing;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for ITaxForm.
	/// </summary>
	// Token: 0x02000032 RID: 50
	public interface ITaxForm
	{
		// Token: 0x06000192 RID: 402
		int Year();

		// Token: 0x06000193 RID: 403
		void Print(Graphics g);
	}
}
