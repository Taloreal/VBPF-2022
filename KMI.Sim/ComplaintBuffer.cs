using System;
using System.Collections;

namespace KMI.Sim
{
	// Token: 0x0200001E RID: 30
	[Serializable]
	public class ComplaintBuffer
	{
		// Token: 0x06000162 RID: 354 RVA: 0x0000C425 File Offset: 0x0000B425
		public ComplaintBuffer(Entity parent)
		{
			this.parent = parent;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000C450 File Offset: 0x0000B450
		public void AddComplaint(string from, string complaintKey)
		{
			string key = from + complaintKey;
			int num;
			if (this.complaints.ContainsKey(key))
			{
				num = (int)this.complaints[key] + 1;
				this.complaints[key] = num;
			}
			else
			{
				num = 1;
				this.complaints.Add(key, num);
			}
			ComplaintBuffer.MessageTable messageTable = (ComplaintBuffer.MessageTable)this.messageTables[key];
			if (messageTable != null)
			{
				for (int i = 0; i < messageTable.levels.Length; i++)
				{
					if (num == messageTable.levels[i])
					{
						this.parent.Player.SendMessage(string.Format(messageTable.messages[i], num), from, messageTable.colors[i]);
						break;
					}
				}
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000C53C File Offset: 0x0000B53C
		public int Count(string from, string complaintKey)
		{
			string key = from + complaintKey;
			int result;
			if (this.complaints.ContainsKey(key))
			{
				result = (int)this.complaints[key];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000C580 File Offset: 0x0000B580
		public void Clear(string from, string complaintKey)
		{
			string key = from + complaintKey;
			this.complaints.Remove(key);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000C5A4 File Offset: 0x0000B5A4
		public void AddMessageTable(string from, string complaintKey, int[] levels, string[] messages, NotificationColor[] notificationColors)
		{
			string key = from + complaintKey;
			if (levels.Length != messages.Length)
			{
				throw new Exception("Length of Level, Messages, and NotificationColors do not match in ComplaintBuffer.SetMessages.");
			}
			this.ClearMessageTable(from, complaintKey);
			this.messageTables.Add(key, new ComplaintBuffer.MessageTable(levels, messages, notificationColors));
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000C5F4 File Offset: 0x0000B5F4
		public void AddMessageTable(string from, string complaintKey, int[] levels, string[] messages)
		{
			NotificationColor[] array = new NotificationColor[levels.Length];
			for (int i = 0; i < levels.Length; i++)
			{
				array[i] = NotificationColor.Yellow;
			}
			this.AddMessageTable(from, complaintKey, levels, messages, array);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000C630 File Offset: 0x0000B630
		public void AddMessageTable(string from, string complaintKey, int[] levels, string message)
		{
			string[] array = new string[levels.Length];
			for (int i = 0; i < levels.Length; i++)
			{
				array[i] = message;
			}
			this.AddMessageTable(from, complaintKey, levels, array);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000C66C File Offset: 0x0000B66C
		public void AddMessageTable(string from, string complaintKey, int[] levels, string message, NotificationColor[] notificationColors)
		{
			string[] array = new string[levels.Length];
			for (int i = 0; i < levels.Length; i++)
			{
				array[i] = message;
			}
			this.AddMessageTable(from, complaintKey, levels, array, notificationColors);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000C6A8 File Offset: 0x0000B6A8
		public void ClearMessageTable(string from, string complaintKey)
		{
			string key = from + complaintKey;
			this.messageTables.Remove(key);
		}

		// Token: 0x040000E4 RID: 228
		protected Hashtable complaints = new Hashtable();

		// Token: 0x040000E5 RID: 229
		protected Hashtable messageTables = new Hashtable();

		// Token: 0x040000E6 RID: 230
		protected Entity parent;

		// Token: 0x0200001F RID: 31
		[Serializable]
		private class MessageTable
		{
			// Token: 0x0600016B RID: 363 RVA: 0x0000C6CB File Offset: 0x0000B6CB
			public MessageTable(int[] levels, string[] messages, NotificationColor[] colors)
			{
				this.levels = levels;
				this.messages = messages;
				this.colors = colors;
			}

			// Token: 0x040000E7 RID: 231
			public int[] levels;

			// Token: 0x040000E8 RID: 232
			public string[] messages;

			// Token: 0x040000E9 RID: 233
			public NotificationColor[] colors;
		}
	}
}
