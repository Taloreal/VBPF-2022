using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace KMI.Utility
{
	// Token: 0x02000006 RID: 6
	public class TableReader
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00004D30 File Offset: 0x00003D30
		public static object[] Read(Assembly assembly, Type type, string resource)
		{
			Stream manifestResourceStream = assembly.GetManifestResourceStream(resource);
			string text = new StreamReader(manifestResourceStream).ReadToEnd();
			manifestResourceStream.Close();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			ArrayList arrayList = new ArrayList();
			bool flag = true;
			PropertyInfo[] orderedProperties = null;
			foreach (string text2 in array)
			{
				string text3 = text2.TrimEnd(new char[]
				{
					'\r'
				});
				if (text3 != "")
				{
					if (flag)
					{
						orderedProperties = TableReader.GetOrderedProperties(type, text3);
						flag = false;
					}
					else
					{
						object value = TableReader.ObjectFromString(type, text3, orderedProperties);
						arrayList.Add(value);
					}
				}
			}
			return (object[])arrayList.ToArray(type);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004E18 File Offset: 0x00003E18
		public static object[] Read(Type type, string resource)
		{
			return TableReader.Read(type.Assembly, type, resource);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004E38 File Offset: 0x00003E38
		protected static PropertyInfo[] GetOrderedProperties(Type type, string r)
		{
			string[] array = r.Split(new char[]
			{
				'\t'
			});
			PropertyInfo[] array2 = new PropertyInfo[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = type.GetProperty(array[i]);
				if (array2[i] == null)
				{
					throw new Exception("The property name " + array[i] + " found in the table is not a property of the object.");
				}
			}
			return array2;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004EB4 File Offset: 0x00003EB4
		protected static object ObjectFromString(Type type, string text, PropertyInfo[] orderedProperties)
		{
			string[] array = text.Split(new char[]
			{
				'\t'
			});
			ConstructorInfo constructor = type.GetConstructor(new Type[0]);
			object obj = constructor.Invoke(new object[0]);
			int num = 0;
			foreach (PropertyInfo propertyInfo in orderedProperties)
			{
				object obj2 = TableReader.ConvertStringToPropertyType(array[num], propertyInfo);
				MethodInfo setMethod = propertyInfo.GetSetMethod();
				setMethod.Invoke(obj, new object[]
				{
					obj2
				});
				num++;
			}
			return obj;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004F54 File Offset: 0x00003F54
		protected static object ConvertStringToPropertyType(string s, PropertyInfo pi)
		{
			MethodInfo getMethod = pi.GetGetMethod();
			Type returnType = getMethod.ReturnType;
			try
			{
				if (returnType.Equals(typeof(int)))
				{
					return Convert.ToInt32(s);
				}
				if (returnType.Equals(typeof(float)))
				{
					return Convert.ToSingle(s);
				}
				if (returnType.Equals(typeof(DateTime)))
				{
					return Convert.ToDateTime(s);
				}
				if (returnType.Equals(typeof(bool)))
				{
					return Convert.ToBoolean(s);
				}
				if (returnType.Equals(typeof(string)))
				{
					return Convert.ToString(s);
				}
			}
			catch (Exception innerException)
			{
				Exception ex = new Exception(string.Concat(new string[]
				{
					"The value ",
					s,
					" for the property ",
					pi.Name,
					" could not be converted to type ",
					returnType.ToString(),
					"."
				}), innerException);
				throw ex;
			}
			Exception ex2 = new Exception(string.Concat(new string[]
			{
				"The property ",
				pi.Name,
				" is not of a type that TableReader can convert. Add type ",
				returnType.ToString(),
				" to ConvertStringToProperty routine."
			}));
			throw ex2;
		}
	}
}
