using System;
using System.Collections;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x02000005 RID: 5
	public class ControlArray : CollectionBase
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00004BD6 File Offset: 0x00003BD6
		public ControlArray(Form form)
		{
			this.hostForm = form;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004BE8 File Offset: 0x00003BE8
		public void AddExistingControl(Control control)
		{
			base.List.Add(control);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004BF8 File Offset: 0x00003BF8
		public void AddNewControl(Control control)
		{
			base.List.Add(control);
			this.hostForm.Controls.Add(control);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004C1C File Offset: 0x00003C1C
		public void Remove(int index, bool fromForm)
		{
			base.List.RemoveAt(index);
			if (fromForm)
			{
				this.hostForm.Controls.Remove(this[index]);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004C5C File Offset: 0x00003C5C
		public void Remove(object control, bool fromForm)
		{
			base.List.Remove(control);
			if (fromForm)
			{
				this.hostForm.Controls.Remove((Control)control);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004C98 File Offset: 0x00003C98
		public int IndexOf(object control)
		{
			int result;
			if (!base.List.Contains(control) || this.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = base.List.IndexOf(control);
			}
			return result;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00004CE0 File Offset: 0x00003CE0
		public new int Count
		{
			get
			{
				return base.List.Count;
			}
		}

		// Token: 0x17000003 RID: 3
		public Control this[int index]
		{
			get
			{
				return (Control)base.List[index];
			}
		}

		// Token: 0x0400000F RID: 15
		protected Form hostForm;
	}
}
