using System;
using System.Runtime.Serialization;

namespace KMI.Sim
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class SimApplicationException : ApplicationException, ISerializable
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x00007310 File Offset: 0x00006310
		public SimApplicationException()
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000731B File Offset: 0x0000631B
		public SimApplicationException(string message)
		{
			this.applicationMessage = message;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000732D File Offset: 0x0000632D
		public SimApplicationException(SerializationInfo info, StreamingContext context)
		{
			this.applicationMessage = (string)info.GetValue("applicationMessage", typeof(string));
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00007358 File Offset: 0x00006358
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("applicationMessage", this.applicationMessage);
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00007370 File Offset: 0x00006370
		public override string Message
		{
			get
			{
				return this.applicationMessage;
			}
		}

		// Token: 0x0400006F RID: 111
		protected string applicationMessage;
	}
}
