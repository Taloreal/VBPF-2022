using System;
using System.Collections;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200005C RID: 92
	public class Resource
	{
		// Token: 0x06000364 RID: 868 RVA: 0x00019750 File Offset: 0x00018750
		public Resource(params ResourceManager[] rms)
		{
			foreach (ResourceManager value in rms)
			{
				this.resourceManagers.Add(value);
			}
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000197BC File Offset: 0x000187BC
		public string GetString(string Name)
		{
			if (this.resourceManagers.Count == 0)
			{
				throw new Exception("No string resource files were added to this solution.");
			}
			foreach (object obj in this.resourceManagers)
			{
				ResourceManager resourceManager = (ResourceManager)obj;
				string @string = resourceManager.GetString(Name);
				if (@string != null)
				{
					return @string;
				}
			}
			return Name;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00019860 File Offset: 0x00018860
		public string GetString(string Name, params object[] args)
		{
			string @string = this.GetString(Name);
			return string.Format(@string, args);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00019884 File Offset: 0x00018884
		public string GetStringByIndex(string Name, int index)
		{
			string @string = this.GetString(Name);
			string[] array = @string.Split(new char[]
			{
				'|'
			});
			return array[index];
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000198B8 File Offset: 0x000188B8
		public string GetRandomSubString(string resource, char[] delimiter)
		{
			string[] array = this.GetString(resource).Split(delimiter);
			return array[Simulator.Instance.SimState.Random.Next(array.GetLength(0))];
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000198F8 File Offset: 0x000188F8
		public Bitmap GetImage(string imageName)
		{
			Bitmap bitmap = (Bitmap)this.imageTable[imageName];
			if (bitmap != null)
			{
				return bitmap;
			}
			throw new Exception("Could not find image " + imageName);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00019938 File Offset: 0x00018938
		public Page GetPage(string pageName)
		{
			Page page = (Page)this.pageTable[pageName];
			if (page != null)
			{
				return page;
			}
			throw new Exception("Could not find page " + pageName);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00019978 File Offset: 0x00018978
		public Cursor GetCursor(string cursorName)
		{
			Cursor cursor = (Cursor)this.cursorTable[cursorName];
			if (cursor != null)
			{
				return cursor;
			}
			throw new Exception("Could not find cursor " + cursorName);
		}

		// Token: 0x170000CB RID: 203
		// (set) Token: 0x0600036C RID: 876 RVA: 0x000199BC File Offset: 0x000189BC
		public SortedList ImageTable
		{
			set
			{
				this.imageTable = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (set) Token: 0x0600036D RID: 877 RVA: 0x000199C6 File Offset: 0x000189C6
		public SortedList PageTable
		{
			set
			{
				this.pageTable = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (set) Token: 0x0600036E RID: 878 RVA: 0x000199D0 File Offset: 0x000189D0
		public SortedList CursorTable
		{
			set
			{
				this.cursorTable = value;
			}
		}

		// Token: 0x0400022E RID: 558
		private ArrayList resourceManagers = new ArrayList();

		// Token: 0x0400022F RID: 559
		protected SortedList imageTable = new SortedList();

		// Token: 0x04000230 RID: 560
		protected SortedList pageTable = new SortedList();

		// Token: 0x04000231 RID: 561
		protected SortedList cursorTable = new SortedList();
	}
}
