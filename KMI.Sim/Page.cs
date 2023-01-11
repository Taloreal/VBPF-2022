using System;
using System.Drawing;

namespace KMI.Sim
{
	// Token: 0x02000003 RID: 3
	public class Page
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002104 File Offset: 0x00001104
		public Page(Bitmap bitmap, int cols, int rows, int anchorX, int anchorY)
		{
			this.bitmap = bitmap;
			this.rows = rows;
			this.cols = cols;
			this.width = bitmap.Width;
			this.height = bitmap.Height;
			this.anchorX = anchorX;
			this.anchorY = anchorY;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002188 File Offset: 0x00001188
		public Bitmap Bitmap
		{
			get
			{
				return this.bitmap;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000021A0 File Offset: 0x000011A0
		public int Cols
		{
			get
			{
				return this.cols;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000021B8 File Offset: 0x000011B8
		public int Rows
		{
			get
			{
				return this.rows;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021D0 File Offset: 0x000011D0
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021E8 File Offset: 0x000011E8
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002200 File Offset: 0x00001200
		public int AnchorX
		{
			get
			{
				return this.anchorX;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002218 File Offset: 0x00001218
		public int AnchorY
		{
			get
			{
				return this.anchorY;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002230 File Offset: 0x00001230
		public int CellWidth
		{
			get
			{
				return this.width / this.cols;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002250 File Offset: 0x00001250
		public int CellHeight
		{
			get
			{
				return this.height / this.rows;
			}
		}

		// Token: 0x04000001 RID: 1
		private Bitmap bitmap = null;

		// Token: 0x04000002 RID: 2
		private int cols = 1;

		// Token: 0x04000003 RID: 3
		private int rows = 1;

		// Token: 0x04000004 RID: 4
		private int width = 1;

		// Token: 0x04000005 RID: 5
		private int height = 1;

		// Token: 0x04000006 RID: 6
		private int anchorX = 0;

		// Token: 0x04000007 RID: 7
		private int anchorY = 0;
	}
}
