using System;

namespace KMI.Utility
{
	// Token: 0x0200000F RID: 15
	public class Phraser
	{
		// Token: 0x06000091 RID: 145 RVA: 0x00006580 File Offset: 0x00005580
		public Phraser(string[] phrases)
		{
			this.phrases = phrases;
			this.breakPoints = new double[phrases.Length - 1];
			for (int i = 0; i < this.breakPoints.Length; i++)
			{
				this.breakPoints[i] = (double)(i + 1) / (double)phrases.Length;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000065D8 File Offset: 0x000055D8
		public Phraser(string delimitedPhrases)
		{
			this.phrases = delimitedPhrases.Split(new char[]
			{
				'|'
			});
			this.breakPoints = new double[this.phrases.Length - 1];
			for (int i = 0; i < this.breakPoints.Length; i++)
			{
				this.breakPoints[i] = (double)(i + 1) / (double)this.phrases.Length;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000664C File Offset: 0x0000564C
		public Phraser(double[] breakPoints, string[] phrases)
		{
			this.phrases = phrases;
			this.breakPoints = breakPoints;
			if (this.phrases.Length != this.breakPoints.Length + 1)
			{
				throw new Exception("Must supply one fewer breakpoints than phrases.");
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006694 File Offset: 0x00005694
		public Phraser(double breakPoint, string phrase1, string phrase2)
		{
			this.phrases = new string[]
			{
				phrase1,
				phrase2
			};
			this.breakPoints = new double[]
			{
				breakPoint
			};
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000066D4 File Offset: 0x000056D4
		public Phraser(double breakPoint, string delimitedPhrases)
		{
			this.phrases = delimitedPhrases.Split(new char[]
			{
				'|'
			});
			this.breakPoints = new double[]
			{
				breakPoint
			};
			if (this.phrases.Length != this.breakPoints.Length + 1)
			{
				throw new Exception("Must supply one fewer breakpoints than phrases.");
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006738 File Offset: 0x00005738
		public Phraser(double[] breakPoints, string delimitedPhrases)
		{
			this.phrases = delimitedPhrases.Split(new char[]
			{
				'|'
			});
			this.breakPoints = breakPoints;
			if (this.phrases.Length != this.breakPoints.Length + 1)
			{
				throw new Exception("Must supply one fewer breakpoints than phrases.");
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006794 File Offset: 0x00005794
		public string GetPhrase(double val)
		{
			for (int i = 0; i < this.breakPoints.Length; i++)
			{
				if (val < this.breakPoints[i])
				{
					return this.phrases[i];
				}
			}
			return this.phrases[this.phrases.Length - 1];
		}

		// Token: 0x0400002A RID: 42
		protected string[] phrases;

		// Token: 0x0400002B RID: 43
		protected double[] breakPoints;
	}
}
