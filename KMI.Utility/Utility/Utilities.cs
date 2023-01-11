using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace KMI.Utility
{
	// Token: 0x02000002 RID: 2
	public sealed class Utilities
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		private Utilities()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000105C
		public static string PathOnly(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			return fileInfo.Directory.ToString();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002080 File Offset: 0x00001080
		public static string MakePlural(int n)
		{
			string result;
			if (n != 1)
			{
				result = "s";
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020AC File Offset: 0x000010AC
		public static string MakePossessive(string s)
		{
			return s + "'s";
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020CC File Offset: 0x000010CC
		public static string AddAOrAn(string s)
		{
			string result;
			if (s.Substring(0, 1).ToLower() == "a" || s.Substring(0, 1).ToLower() == "e" || s.Substring(0, 1).ToLower() == "i" || s.Substring(0, 1).ToLower() == "o" || s.Substring(0, 1).ToLower() == "u")
			{
				result = "an " + s;
			}
			else
			{
				result = "a " + s;
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002188 File Offset: 0x00001188
		public static string NoAmpersand(string s)
		{
			s = s.Replace("&", "");
			return s.Replace("  ", " ");
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021BC File Offset: 0x000011BC
		public static string NoEllipsis(string s)
		{
			return s.Replace("...", "");
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021E0 File Offset: 0x000011E0
		public static string NoHyphen(string s)
		{
			return s.Replace("-", " ");
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002204 File Offset: 0x00001204
		public static string NoForwardSlash(string s)
		{
			return s.Replace("/", " ");
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002228 File Offset: 0x00001228
		public static float RoundUpToPowerOfTen(float number, int zeroes)
		{
			return (float)((long)((double)number / Math.Pow(10.0, (double)zeroes) + 1.0) * (long)Math.Pow(10.0, (double)zeroes));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000226C File Offset: 0x0000126C
		public static float RoundDownToPowerOfTen(float number, int zeroes)
		{
			return (float)((long)((double)number / Math.Pow(10.0, (double)zeroes)) * (long)Math.Pow(10.0, (double)zeroes));
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022A8 File Offset: 0x000012A8
		public static float GetNormalDistribution(float middle, float twoStdDev, Random random)
		{
			float num = 0f;
			int num2 = 10;
			for (int i = 0; i < num2; i++)
			{
				num += (float)((double)middle - (double)twoStdDev * 2.5 + random.NextDouble() * 2.0 * (double)twoStdDev * 2.5) / (float)num2;
			}
			return num;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000230C File Offset: 0x0000130C
		public static object PickRandom(IList list, Random random)
		{
			object result;
			if (list == null || list.Count == 0)
			{
				result = null;
			}
			else
			{
				result = list[random.Next(list.Count)];
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000234C File Offset: 0x0000134C
		public static MenuItem FindMenuEquivalent(MainMenu SearchMenu, string TargetMenuText)
		{
			TargetMenuText = Utilities.NoHyphen(Utilities.NoForwardSlash(TargetMenuText));
			foreach (object obj in SearchMenu.MenuItems)
			{
				MenuItem searchMenu = (MenuItem)obj;
				if (Utilities.FindMenuEquivalent(searchMenu, TargetMenuText) != null)
				{
					return Utilities.FindMenuEquivalent(searchMenu, TargetMenuText);
				}
			}
			return null;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000023DC File Offset: 0x000013DC
		public static MenuItem FindMenuEquivalent(MenuItem SearchMenu, string TargetMenuText)
		{
			MenuItem result;
			if (Utilities.NoEllipsis(Utilities.NoAmpersand(Utilities.NoHyphen(Utilities.NoForwardSlash(SearchMenu.Text)))) == TargetMenuText)
			{
				result = SearchMenu;
			}
			else
			{
				foreach (object obj in SearchMenu.MenuItems)
				{
					MenuItem searchMenu = (MenuItem)obj;
					if (Utilities.FindMenuEquivalent(searchMenu, TargetMenuText) != null)
					{
						return Utilities.FindMenuEquivalent(searchMenu, TargetMenuText);
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002488 File Offset: 0x00001488
		public static ToolBarButton FindButtonEquivalent(ToolBar toolBar, string TargetButtonText)
		{
			foreach (object obj in toolBar.Buttons)
			{
				ToolBarButton toolBarButton = (ToolBarButton)obj;
				if (toolBarButton.Text == Utilities.NoEllipsis(Utilities.NoAmpersand(TargetButtonText)))
				{
					return toolBarButton;
				}
			}
			return null;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002510 File Offset: 0x00001510
		public static object DeepCopyBySerialization(object objectToCopy)
		{
			Stream stream = new MemoryStream();
			IFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, objectToCopy);
			stream.Position = 0L;
			object result = formatter.Deserialize(stream);
			stream.Close();
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002550 File Offset: 0x00001550
		public static long MeasureBinaryFormattedSize(object objectToCopy)
		{
			Stream stream = new MemoryStream();
			IFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, objectToCopy);
			long length = stream.Length;
			stream.Close();
			return length;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002588 File Offset: 0x00001588
		public static string FC(float amount, int decimalPlaces, float currencyConversion)
		{
			return (amount * currencyConversion).ToString("C" + decimalPlaces);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000025B8 File Offset: 0x000015B8
		public static string FC(float amount, float currencyConversion)
		{
			return (amount * currencyConversion).ToString("C0");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000025DC File Offset: 0x000015DC
		public static string FU(int amount)
		{
			return amount.ToString("N0");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000025FC File Offset: 0x000015FC
		public static string FP(float amount)
		{
			return amount.ToString("P0");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000261C File Offset: 0x0000161C
		public static string FP(float amount, int decimalPlaces)
		{
			return amount.ToString("P" + decimalPlaces);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002648 File Offset: 0x00001648
		public static float Clamp(float amount)
		{
			float result;
			if (amount < 0f)
			{
				result = 0f;
			}
			else if (amount > 1f)
			{
				result = 1f;
			}
			else
			{
				result = amount;
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000268C File Offset: 0x0000168C
		public static float Clamp(float amount, float max)
		{
			float result;
			if (amount < 0f)
			{
				result = 0f;
			}
			else if (amount > max)
			{
				result = max;
			}
			else
			{
				result = amount;
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026C8 File Offset: 0x000016C8
		public static float Clamp(float amount, float min, float max)
		{
			float result;
			if (amount < min)
			{
				result = min;
			}
			else if (amount > max)
			{
				result = max;
			}
			else
			{
				result = amount;
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000026FC File Offset: 0x000016FC
		public static string ConvertNumberToDescription(int x)
		{
			string text = x.ToString();
			string text2 = text.Substring(text.Length - 1);
			if (text2 != null)
			{
				if (text2 == "1")
				{
					text += "st";
					goto IL_7C;
				}
				if (text2 == "2")
				{
					text += "nd";
					goto IL_7C;
				}
				if (text2 == "3")
				{
					text += "rd";
					goto IL_7C;
				}
			}
			text += "th";
			IL_7C:
			if (text.Substring(text.Length - 2) == "11" || text.Substring(text.Length - 2) == "12" || text.Substring(text.Length - 2) == "13")
			{
				text = x + "th";
			}
			return text;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000027F4 File Offset: 0x000017F4
		public static void Shuffle(object[] list, Random rnd)
		{
			if (list == null)
			{
				throw new NullReferenceException("In Utility.Shuffle, got a null list");
			}
			if (rnd == null)
			{
				throw new NullReferenceException("In Utility.Shuffle, got a null random number generator");
			}
			int num = list.Length;
			for (int i = 0; i < 3 * num; i++)
			{
				int num2 = rnd.Next(num);
				int num3 = rnd.Next(num);
				object obj = list[num2];
				list[num2] = list[num3];
				list[num3] = obj;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002870 File Offset: 0x00001870
		public static void Shuffle(ArrayList list, Random rnd)
		{
			if (list == null)
			{
				throw new NullReferenceException("In Utility.Shuffle, got a null array list");
			}
			if (rnd == null)
			{
				throw new NullReferenceException("In Utility.Shuffle, got a null random number generator");
			}
			int count = list.Count;
			for (int i = 0; i < 3 * count; i++)
			{
				int index = rnd.Next(count);
				int index2 = rnd.Next(count);
				object value = list[index];
				list[index] = list[index2];
				list[index2] = value;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002904 File Offset: 0x00001904
		public static int PickFromDistribution(float[] pdf, Random random)
		{
			int num = pdf.Length;
			float num2 = 0f;
			for (int i = 0; i < num; i++)
			{
				num2 += pdf[i];
			}
			float num3 = (float)random.NextDouble() * num2;
			float num4 = 0f;
			for (int i = 0; i < num; i++)
			{
				num4 += pdf[i];
				if (num4 >= num3)
				{
					return i;
				}
			}
			return num - 1;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000297C File Offset: 0x0000197C
		public static string AddSpaces(string s)
		{
			if (s.Length > 0)
			{
				s = s.Substring(0, 1).ToUpper() + s.Substring(1);
				for (int i = s.Length - 1; i > 0; i--)
				{
					if (s.Substring(i, 1).ToUpper() == s.Substring(i, 1))
					{
						s = s.Substring(0, i) + " " + s.Substring(i);
					}
				}
			}
			return s;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A10 File Offset: 0x00001A10
		public static string URLEncode(string url)
		{
			url = url.Replace("%", "%25");
			url = url.Replace(" ", "%20");
			url = url.Replace("!", "%21");
			url = url.Replace("\"", "%22");
			url = url.Replace("#", "%23");
			url = url.Replace("$", "%24");
			url = url.Replace("&", "%26");
			url = url.Replace("'", "%27");
			url = url.Replace("(", "%28");
			url = url.Replace(")", "%29");
			url = url.Replace("*", "%2a");
			url = url.Replace("+", "%2b");
			url = url.Replace(",", "%2c");
			url = url.Replace("-", "%2d");
			url = url.Replace(".", "%2e");
			url = url.Replace("/", "%2f");
			return url;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002B44 File Offset: 0x00001B44
		public static Type GetTypeFromEntryAssembly()
		{
			return Assembly.GetEntryAssembly().GetTypes()[0];
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002B64 File Offset: 0x00001B64
		public static string GetWebPage(WebRequest r, string proxyAddress, string proxyBypassList)
		{
			if (proxyAddress != null && proxyAddress != "")
			{
				r.Proxy = new WebProxy
				{
					Address = new Uri(proxyAddress),
					BypassList = proxyBypassList.Split(new char[]
					{
						';'
					})
				};
			}
			return Utilities.GetWebPage(r);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002BCC File Offset: 0x00001BCC
		public static string GetWebPage(WebRequest r)
		{
			WebResponse response;
			try
			{
				response = r.GetResponse();
			}
			catch
			{
				return "";
			}
			Stream responseStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002C28 File Offset: 0x00001C28
		public static string Parse(string searchString, string delimiter1, string delimiter2)
		{
			int num = searchString.IndexOf(delimiter1);
			int num2 = searchString.IndexOf(delimiter2, num);
			if (num < 0 || num2 < 0)
			{
				throw new Exception("Delimiter not found.");
			}
			return searchString.Substring(num + delimiter1.Length, num2 - (num + delimiter1.Length));
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002C80 File Offset: 0x00001C80
		public static DateTime GetTimeViaInternet()
		{
			WebRequest r = WebRequest.Create("http://vbc.knowledgematters.com/vbccommon/time.asp");
			string webPage = Utilities.GetWebPage(r);
			return Convert.ToDateTime(webPage);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002CAC File Offset: 0x00001CAC
		public static string FormatCommaSeries(string s)
		{
			string result;
			if (s == "")
			{
				result = s;
			}
			else
			{
				s = s.TrimEnd(new char[]
				{
					' ',
					','
				});
				int num = s.LastIndexOf(", ");
				if (num > -1)
				{
					result = s.Substring(0, num) + " and " + s.Substring(num + 2);
				}
				else
				{
					result = s;
				}
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002D24 File Offset: 0x00001D24
		public static void SerializeBinaryFormatObjectToFile(object obj, string filename)
		{
			Stream stream = null;
			string text = Application.StartupPath + "\\" + filename;
			try
			{
				stream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.None);
			}
			catch
			{
				throw new IOException("Could not open file for writing:" + text);
			}
			IFormatter formatter = new BinaryFormatter();
			try
			{
				formatter.Serialize(stream, obj);
			}
			catch
			{
				throw new Exception("Could not serialize binary configuration to " + text);
			}
			finally
			{
				stream.Close();
			}
		}

		// Token: 0x06000028 RID: 40
		[DllImport("msvcrt.dll")]
		private static extern int _controlfp(int IN_New, int IN_Mask);

		// Token: 0x06000029 RID: 41 RVA: 0x00002DC4 File Offset: 0x00001DC4
		public static void ResetFPU()
		{
			Utilities._controlfp(524319, 16);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002DD4 File Offset: 0x00001DD4
		public static void DrawComment(Graphics g, string text, Point anchor, Rectangle bounds, int commentWidth, Font font, Color color)
		{
			Brush brush = new SolidBrush(Color.White);
			Brush brush2 = new SolidBrush(color);
			Pen pen = new Pen(brush2);
			SizeF sizeF = g.MeasureString(text, font, commentWidth);
			SizeF sizeF2 = new SizeF(sizeF.Width + 16f, sizeF.Height + 16f);
			bool flag = (float)anchor.X + sizeF2.Width + 15f > (float)bounds.Width;
			int num = 0;
			if ((float)anchor.Y - sizeF2.Height - 15f < 0f)
			{
				if ((float)anchor.Y + sizeF2.Height + 15f > (float)bounds.Height)
				{
					num = 1;
				}
				else
				{
					num = 2;
				}
			}
			if (flag)
			{
				if (num == 2)
				{
					Point point = new Point(anchor.X - 15, anchor.Y + 15);
					g.FillRectangle(brush, (float)point.X - sizeF2.Width, (float)point.Y, sizeF2.Width, sizeF2.Height);
					g.DrawRectangle(pen, (float)point.X - sizeF2.Width, (float)point.Y, sizeF2.Width, sizeF2.Height);
					g.DrawString(text, font, brush2, new RectangleF((float)point.X - sizeF2.Width + 8f, (float)(point.Y + 8), sizeF.Width, sizeF.Height));
					Point[] points = new Point[]
					{
						anchor,
						new Point(point.X, point.Y + 8),
						point,
						new Point(point.X - 8, point.Y),
						anchor
					};
					g.FillPolygon(brush2, points);
				}
				else if (num == 1)
				{
					Point point = new Point(anchor.X - 15, anchor.Y - 15);
					Point[] points = new Point[]
					{
						anchor,
						new Point(point.X, point.Y - 8),
						point,
						new Point(point.X - 8, point.Y),
						anchor
					};
					g.FillPolygon(brush2, points);
					g.FillRectangle(brush, (float)point.X - sizeF2.Width, (float)point.Y - sizeF2.Height / 2f, sizeF2.Width, sizeF2.Height);
					g.DrawRectangle(pen, (float)point.X - sizeF2.Width, (float)point.Y - sizeF2.Height / 2f, sizeF2.Width, sizeF2.Height);
					g.DrawString(text, font, brush2, new RectangleF((float)point.X - sizeF2.Width + 8f, (float)point.Y - sizeF2.Height / 2f + 8f, sizeF.Width, sizeF.Height));
				}
				else
				{
					Point point = new Point(anchor.X - 15, anchor.Y - 15);
					g.FillRectangle(brush, (float)point.X - sizeF2.Width, (float)point.Y - sizeF2.Height, sizeF2.Width, sizeF2.Height);
					g.DrawRectangle(pen, (float)point.X - sizeF2.Width, (float)point.Y - sizeF2.Height, sizeF2.Width, sizeF2.Height);
					g.DrawString(text, font, brush2, new RectangleF((float)point.X - sizeF2.Width + 8f, (float)point.Y - sizeF2.Height + 8f, sizeF.Width, sizeF.Height));
					Point[] points = new Point[]
					{
						anchor,
						new Point(point.X, point.Y - 8),
						point,
						new Point(point.X - 8, point.Y),
						anchor
					};
					g.FillPolygon(brush2, points);
				}
			}
			else if (num == 2)
			{
				Point point = new Point(anchor.X + 15, anchor.Y + 15);
				g.FillRectangle(brush, (float)point.X, (float)point.Y, sizeF2.Width, sizeF2.Height);
				g.DrawRectangle(pen, (float)point.X, (float)point.Y, sizeF2.Width, sizeF2.Height);
				g.DrawString(text, font, brush2, new RectangleF((float)(point.X + 8), (float)(point.Y + 8), sizeF.Width, sizeF.Height));
				Point[] points = new Point[]
				{
					anchor,
					new Point(point.X, point.Y + 8),
					point,
					new Point(point.X + 8, point.Y),
					anchor
				};
				g.FillPolygon(brush2, points);
			}
			else if (num == 1)
			{
				Point point = new Point(anchor.X + 15, anchor.Y - 15);
				Point[] points = new Point[]
				{
					anchor,
					new Point(point.X, point.Y - 8),
					point,
					new Point(point.X + 8, point.Y),
					anchor
				};
				g.FillPolygon(brush2, points);
				g.FillRectangle(brush, (float)point.X, (float)point.Y - sizeF2.Height / 2f, sizeF2.Width, sizeF2.Height);
				g.DrawRectangle(pen, (float)point.X, (float)point.Y - sizeF2.Height / 2f, sizeF2.Width, sizeF2.Height);
				g.DrawString(text, font, brush2, new RectangleF((float)(point.X + 8), (float)point.Y - sizeF2.Height / 2f + 8f, sizeF.Width, sizeF.Height));
			}
			else
			{
				Point point = new Point(anchor.X + 15, anchor.Y - 15);
				g.FillRectangle(brush, (float)point.X, (float)point.Y - sizeF2.Height, sizeF2.Width, sizeF2.Height);
				g.DrawRectangle(pen, (float)point.X, (float)point.Y - sizeF2.Height, sizeF2.Width, sizeF2.Height);
				g.DrawString(text, font, brush2, new RectangleF((float)(point.X + 8), (float)point.Y - sizeF2.Height + 8f, sizeF.Width, sizeF.Height));
				Point[] points = new Point[]
				{
					anchor,
					new Point(point.X, point.Y - 8),
					point,
					new Point(point.X + 8, point.Y),
					anchor
				};
				g.FillPolygon(brush2, points);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000036C8 File Offset: 0x000026C8
		public static void DrawComment(Graphics g, string text, Point anchor, Rectangle bounds, int commentWidth)
		{
			Font font = new Font("Arial", 9f);
			Color steelBlue = Color.SteelBlue;
			Utilities.DrawComment(g, text, anchor, bounds, commentWidth, font, steelBlue);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000036FA File Offset: 0x000026FA
		public static void DrawComment(Graphics g, string text, Point anchor, Rectangle bounds, Font font, Color color)
		{
			Utilities.DrawComment(g, text, anchor, bounds, 150, font, color);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003710 File Offset: 0x00002710
		public static void DrawComment(Graphics g, string text, Point anchor, Rectangle bounds)
		{
			Utilities.DrawComment(g, text, anchor, bounds, 150);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003724 File Offset: 0x00002724
		public static string GetRandomMaleFirstName(Random rng)
		{
			string[] array = Utilities.rm.GetString("MaleFirstNames").Split(new char[]
			{
				'|'
			});
			return array[rng.Next(array.Length)];
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003764 File Offset: 0x00002764
		public static string GetRandomFemaleFirstName(Random rng)
		{
			string[] array = Utilities.rm.GetString("FemaleFirstNames").Split(new char[]
			{
				'|'
			});
			return array[rng.Next(array.Length)];
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000037A4 File Offset: 0x000027A4
		public static string GetRandomFirstName(Random rng)
		{
			string result;
			if (rng.Next(2) == 0)
			{
				result = Utilities.GetRandomMaleFirstName(rng);
			}
			else
			{
				result = Utilities.GetRandomFemaleFirstName(rng);
			}
			return result;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000037D8 File Offset: 0x000027D8
		public static string GetRandomLastName(Random rng)
		{
			string[] array = Utilities.rm.GetString("LastNames").Split(new char[]
			{
				'|'
			});
			return array[rng.Next(array.Length)];
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003818 File Offset: 0x00002818
		public static string GetRandomMaleFullName(Random rng)
		{
			string[] array = Utilities.rm.GetString("MaleFirstNames").Split(new char[]
			{
				'|'
			});
			string[] array2 = Utilities.rm.GetString("LastNames").Split(new char[]
			{
				'|'
			});
			return array[rng.Next(array.Length)] + " " + array2[rng.Next(array2.Length)];
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003890 File Offset: 0x00002890
		public static string GetRandomFemaleFullName(Random rng)
		{
			string[] array = Utilities.rm.GetString("FemaleFirstNames").Split(new char[]
			{
				'|'
			});
			string[] array2 = Utilities.rm.GetString("LastNames").Split(new char[]
			{
				'|'
			});
			return array[rng.Next(array.Length)] + " " + array2[rng.Next(array2.Length)];
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003908 File Offset: 0x00002908
		public static string GetRandomFullName(Random rng)
		{
			string result;
			if (rng.Next(2) == 0)
			{
				result = Utilities.GetRandomMaleFullName(rng);
			}
			else
			{
				result = Utilities.GetRandomFemaleFullName(rng);
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000393C File Offset: 0x0000293C
		public static bool PolygonContains(PointF point, PointF[] cornerPoints)
		{
			int num = 0;
			float x = point.X;
			float y = point.Y;
			for (int i = 1; i < cornerPoints.Length; i++)
			{
				if (Utilities.DoesIntersect(point, cornerPoints[i], cornerPoints[i - 1]))
				{
					num++;
				}
			}
			if (Utilities.DoesIntersect(point, cornerPoints[cornerPoints.Length - 1], cornerPoints[0]))
			{
				num++;
			}
			return num % 2 != 0;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000039E4 File Offset: 0x000029E4
		public static float DistanceBetween(PointF p1, PointF p2)
		{
			return (float)Math.Sqrt(Math.Pow((double)(p1.X - p2.X), 2.0) + Math.Pow((double)(p1.Y - p2.Y), 2.0));
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003A3C File Offset: 0x00002A3C
		public static float DistanceBetweenIsometric(PointF p1, PointF p2)
		{
			return (float)Math.Sqrt(Math.Pow((double)(p1.X - p2.X), 2.0) + Math.Pow((double)(2f * (p1.Y - p2.Y)), 2.0));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003A98 File Offset: 0x00002A98
		public static float DistanceBetweenPointAndLine(PointF p1, PointF e1, PointF e2)
		{
			PointF p2 = Point.Empty;
			float num;
			if (e1.Y == e2.Y)
			{
				num = float.MaxValue;
			}
			else
			{
				num = (e2.Y - e1.Y) / (e2.X - e1.X);
			}
			p2.X = (num * num * e1.Y + p1.X + num * p1.Y - num * e1.Y) / (num * num + 1f);
			p2.X = Math.Min(p2.X, Math.Max(e1.X, e2.X));
			p2.X = Math.Max(p2.X, Math.Min(e1.X, e2.X));
			p2.Y = num * (p2.X - e1.X) + e1.Y;
			return Utilities.DistanceBetween(p1, p2);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003BA8 File Offset: 0x00002BA8
		private static bool DoesIntersect(PointF point, PointF point1, PointF point2)
		{
			float x = point2.X;
			float y = point2.Y;
			float x2 = point1.X;
			float y2 = point1.Y;
			bool result;
			if ((x < point.X && x2 >= point.X) || (x >= point.X && x2 < point.X))
			{
				float num = (y - y2) / (x - x2) * (point.X - x2) + y2;
				result = (num > point.Y);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003C3C File Offset: 0x00002C3C
		public static string Encrypt(string clearString, string key)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(clearString);
			byte[] bytes2 = Encoding.ASCII.GetBytes(key);
			byte[] array = new byte[bytes.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(bytes[i] ^ bytes2[i % bytes2.Length]);
			}
			return Convert.ToBase64String(array);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003CA0 File Offset: 0x00002CA0
		public static string Decrypt(string cipherString, string key)
		{
			byte[] array = Convert.FromBase64String(cipherString);
			byte[] bytes = Encoding.ASCII.GetBytes(key);
			byte[] array2 = new byte[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = (byte)(array[i] ^ bytes[i % bytes.Length]);
			}
			return Encoding.ASCII.GetString(array2);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003D04 File Offset: 0x00002D04
		public static float Vary(float center, float maxVariation, Random random)
		{
			return center + ((float)random.NextDouble() * 2f - 1f) * maxVariation;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003D30 File Offset: 0x00002D30
		public static PointF SpreadOut(PointF p, float spread, Random r)
		{
			float num = (float)r.NextDouble() * spread - spread / 2f;
			float num2 = (float)r.NextDouble() * spread / 2f - spread / 4f;
			return new PointF(p.X + num, p.Y + num2);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003D84 File Offset: 0x00002D84
		public static bool Intersects(PointF line1Begin, PointF line1End, PointF line2Begin, PointF line2End)
		{
			float num = (line1End.Y - line1Begin.Y) / (line1End.X - line1Begin.X);
			float num2 = (line2End.Y - line2Begin.Y) / (line2End.X - line2Begin.X);
			if (float.IsInfinity(num))
			{
				num = 10000f;
			}
			if (float.IsInfinity(num2))
			{
				num2 = 10000f;
			}
			float num3 = line1Begin.Y - num * line1Begin.X;
			float num4 = line2Begin.Y - num2 * line2Begin.X;
			bool result;
			if (num == num2)
			{
				result = false;
			}
			else
			{
				float num5 = (num4 - num3) / (num - num2);
				float num6 = num * num5 + num3;
				if (line1End.X == line1Begin.X)
				{
					num5 = line1End.X;
				}
				if (line2End.X == line2Begin.X)
				{
					num5 = line2End.X;
				}
				result = (num5 <= Math.Max(line1Begin.X, line1End.X) && num5 <= Math.Max(line2Begin.X, line2End.X) && num5 >= Math.Min(line1Begin.X, line1End.X) && num5 >= Math.Min(line2Begin.X, line2End.X) && num6 <= Math.Max(line1Begin.Y, line1End.Y) && num6 <= Math.Max(line2Begin.Y, line2End.Y) && num6 >= Math.Min(line1Begin.Y, line1End.Y) && num6 >= Math.Min(line2Begin.Y, line2End.Y));
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003F54 File Offset: 0x00002F54
		public static bool Intersects(PointF line1Begin, PointF line1End, RectangleF rect)
		{
			PointF[] array = Utilities.DiamondFFromRect(rect);
			for (int i = 0; i < array.Length; i++)
			{
				if (Utilities.Intersects(line1Begin, line1End, array[i], array[(i + 1) % array.Length]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003FB0 File Offset: 0x00002FB0
		public static bool Intersects(RectangleF rect1, RectangleF rect2)
		{
			PointF[] array = Utilities.DiamondFFromRect(rect1);
			PointF[] array2 = Utilities.DiamondFFromRect(rect2);
			foreach (PointF point in array)
			{
				if (Utilities.PolygonContains(point, array2))
				{
					return true;
				}
			}
			foreach (PointF point in array2)
			{
				if (Utilities.PolygonContains(point, array))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004054 File Offset: 0x00003054
		public static PointF[] DiamondFFromRect(RectangleF rect)
		{
			float x = (rect.Right + rect.Left) / 2f;
			float num = (rect.Top + rect.Bottom) / 2f;
			return new PointF[]
			{
				new PointF(x, num - rect.Width / 4f),
				new PointF(rect.Right, num),
				new PointF(x, num + rect.Width / 4f),
				new PointF(rect.Left, num)
			};
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004110 File Offset: 0x00003110
		public static Point[] DiamondFromRect(RectangleF rect)
		{
			float x = (rect.Right + rect.Left) / 2f;
			float num = (rect.Top + rect.Bottom) / 2f;
			return new Point[]
			{
				Point.Round(new PointF(x, num - rect.Width / 4f)),
				Point.Round(new PointF(rect.Right, num)),
				Point.Round(new PointF(x, num + rect.Width / 4f)),
				Point.Round(new PointF(rect.Left, num))
			};
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000041E0 File Offset: 0x000031E0
		public static string FormatCommaSeriesDuplicatesToNumbers(string series)
		{
			series = series.Replace(", ", ",");
			series = series.TrimEnd(new char[]
			{
				','
			});
			string[] array = series.Split(new char[]
			{
				','
			});
			Hashtable hashtable = new Hashtable();
			foreach (string key in array)
			{
				if (hashtable.ContainsKey(key))
				{
					hashtable[key] = (int)hashtable[key] + 1;
				}
				else
				{
					hashtable.Add(key, 1);
				}
			}
			string text = "";
			foreach (object obj in hashtable.Keys)
			{
				string text2 = (string)obj;
				int num = (int)hashtable[text2];
				if (num > 1)
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						text2,
						" (",
						num.ToString(),
						"), "
					});
				}
				else
				{
					text = text + text2 + ", ";
				}
			}
			return Utilities.FormatCommaSeries(text);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004370 File Offset: 0x00003370
		public static string FormatCommaSeriesDuplicatesToNumbers2(string series)
		{
			series = series.Replace(", ", ",");
			series = series.TrimEnd(new char[]
			{
				','
			});
			string[] array = series.Split(new char[]
			{
				','
			});
			Hashtable hashtable = new Hashtable();
			foreach (string key in array)
			{
				if (hashtable.ContainsKey(key))
				{
					hashtable[key] = (int)hashtable[key] + 1;
				}
				else
				{
					hashtable.Add(key, 1);
				}
			}
			string text = "";
			foreach (object obj in hashtable.Keys)
			{
				string text2 = (string)obj;
				int num = (int)hashtable[text2];
				if (num > 1)
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"(",
						num.ToString(),
						") ",
						text2,
						", "
					});
				}
				else
				{
					text = text + text2 + ", ";
				}
			}
			return Utilities.FormatCommaSeries(text);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000450C File Offset: 0x0000350C
		public static void PrintWithExceptionHandling(string title, PrintPageEventHandler p)
		{
			PrintDialog printDialog = new PrintDialog();
			PrintDocument printDocument = new PrintDocument();
			printDocument.PrintPage += p;
			printDialog.Document = printDocument;
			printDialog.AllowPrintToFile = false;
			if (printDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					printDocument.PrinterSettings = printDialog.PrinterSettings;
					printDocument.Print();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not print. " + ex.Message + ".", "Error Printing");
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000045A0 File Offset: 0x000035A0
		public static PointF cartesianToIsometric(float x, float y, float offsetx, float offsety, float scalex, float scaley)
		{
			return new PointF(offsetx + (x * scalex * 1f - y * scaley * 1f), offsety + (x * scalex * 0.5f + y * scaley * 0.5f));
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000045E8 File Offset: 0x000035E8
		public static PointF cartesianToIsometric(float x, float y, float offsetx, float offsety)
		{
			return Utilities.cartesianToIsometric(x, y, offsetx, offsety, 1f, 1f);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004610 File Offset: 0x00003610
		public static PointF cartesianToIsometric(float x, float y)
		{
			return Utilities.cartesianToIsometric(x, y, 0f, 0f, 1f, 1f);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004640 File Offset: 0x00003640
		public static Point AddPoints(Point p1, Point p2)
		{
			return new Point(p1.X + p2.X, p1.Y + p2.Y);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004678 File Offset: 0x00003678
		public static PointF AddPointFs(PointF p1, PointF p2)
		{
			return new PointF(p1.X + p2.X, p1.Y + p2.Y);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000046B0 File Offset: 0x000036B0
		public static Point[] cartesianToIsometricRectangle(float offsetx, float offsety, float width, float height)
		{
			Point[] array = new Point[4];
			PointF pointF = Utilities.cartesianToIsometric(0f, 0f, offsetx, offsety, width, height);
			array[0] = new Point((int)pointF.X, (int)pointF.Y);
			pointF = Utilities.cartesianToIsometric(1f, 0f, offsetx, offsety, width, height);
			array[1] = new Point((int)pointF.X, (int)pointF.Y);
			pointF = Utilities.cartesianToIsometric(1f, 1f, offsetx, offsety, width, height);
			array[2] = new Point((int)pointF.X, (int)pointF.Y);
			pointF = Utilities.cartesianToIsometric(0f, 1f, offsetx, offsety, width, height);
			array[3] = new Point((int)pointF.X, (int)pointF.Y);
			return array;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000047A0 File Offset: 0x000037A0
		public static float[] SplitStringsIntoFloats(string itemDelimString)
		{
			string[] array = itemDelimString.Split(new char[]
			{
				'|'
			});
			float[] array2 = new float[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = float.Parse(array[i]);
			}
			return array2;
		}

		// Token: 0x04000001 RID: 1
		private const int _MCW_EM = 524319;

		// Token: 0x04000002 RID: 2
		private const int _EM_INVALID = 16;

		// Token: 0x04000003 RID: 3
		private static ResourceManager rm = new ResourceManager("KMI.Utility.Names", Assembly.GetAssembly(typeof(Utilities)));
	}
}
