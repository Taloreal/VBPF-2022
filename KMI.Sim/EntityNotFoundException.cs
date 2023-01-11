using System;
using System.Collections;
using System.Runtime.Serialization;

namespace KMI.Sim
{
	// Token: 0x02000080 RID: 128
	[Serializable]
	public class EntityNotFoundException : SimApplicationException
	{
		// Token: 0x060004FA RID: 1274 RVA: 0x000264A9 File Offset: 0x000254A9
		public EntityNotFoundException()
		{
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x000264B4 File Offset: 0x000254B4
		public EntityNotFoundException(string messageStringResource) : base(messageStringResource)
		{
			this.existingEntityID = -1L;
			if (S.ST.Entity != null)
			{
				IEnumerator enumerator = S.ST.Entity.Values.GetEnumerator();
				//using (IEnumerator enumerator = S.ST.Entity.Values.GetEnumerator())
				//{
					if (enumerator.MoveNext())
					{
						Entity entity = (Entity)enumerator.Current;
						this.existingEntityID = entity.ID;
					}
				//}
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00026550 File Offset: 0x00025550
		public EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.existingEntityID = (long)info.GetValue("existingEntityID", typeof(long));
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00026580 File Offset: 0x00025580
		public long ExistingEntityID
		{
			get
			{
				return this.existingEntityID;
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00026598 File Offset: 0x00025598
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("existingEntityID", this.existingEntityID);
		}

		// Token: 0x0400036E RID: 878
		protected long existingEntityID;
	}
}
