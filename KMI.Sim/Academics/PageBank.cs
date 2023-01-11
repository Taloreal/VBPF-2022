using System;
using System.IO;
using System.Xml.Serialization;

namespace KMI.Sim.Academics
{
	// Token: 0x02000032 RID: 50
	[Serializable]
	public class PageBank
	{
		// Token: 0x060001F0 RID: 496 RVA: 0x00010614 File Offset: 0x0000F614
		public static PageBank LoadFromXML(string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PageBank));
			try
			{
				TextReader textReader = new StreamReader(fileName);
				return (PageBank)xmlSerializer.Deserialize(textReader);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e);
			}
			return null;
		}

		// Token: 0x04000140 RID: 320
		public string Name;

		// Token: 0x04000141 RID: 321
		public Level[] Levels;
	}
}
