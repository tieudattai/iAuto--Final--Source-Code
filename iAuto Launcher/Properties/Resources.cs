using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace L.Properties
{
	// Token: 0x02000026 RID: 38
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x0000253C File Offset: 0x0000073C
		internal Resources()
		{
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x000029A0 File Offset: 0x00000BA0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("L.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x000029CC File Offset: 0x00000BCC
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x000029D3 File Offset: 0x00000BD3
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x000029DB File Offset: 0x00000BDB
		internal static Icon icon
		{
			get
			{
				return (Icon)Resources.ResourceManager.GetObject("icon", Resources.resourceCulture);
			}
		}

		// Token: 0x040000AC RID: 172
		private static ResourceManager resourceMan;

		// Token: 0x040000AD RID: 173
		private static CultureInfo resourceCulture;
	}
}
