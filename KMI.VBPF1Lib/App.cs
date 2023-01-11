using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace KMI.VBPF1Lib
{
	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// Token: 0x0200005E RID: 94
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	internal class App
	{
		// Token: 0x0600027D RID: 637 RVA: 0x00028EAE File Offset: 0x00027EAE
		internal App()
		{
		}

		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00028EBC File Offset: 0x00027EBC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(App.resourceMan, null))
				{
					ResourceManager temp = new ResourceManager("KMI.VBPF1Lib.App", typeof(App).Assembly);
					App.resourceMan = temp;
				}
				return App.resourceMan;
			}
		}

		/// <summary>
		///   Overrides the current thread's CurrentUICulture property for all
		///   resource lookups using this strongly typed resource class.
		/// </summary>
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00028F08 File Offset: 0x00027F08
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00028F1F File Offset: 0x00027F1F
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return App.resourceCulture;
			}
			set
			{
				App.resourceCulture = value;
			}
		}

		// Token: 0x040002F1 RID: 753
		private static ResourceManager resourceMan;

		// Token: 0x040002F2 RID: 754
		private static CultureInfo resourceCulture;
	}
}
