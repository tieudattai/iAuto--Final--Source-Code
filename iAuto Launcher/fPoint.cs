using System;

namespace L
{
	// Token: 0x02000003 RID: 3
	internal class fPoint
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002199 File Offset: 0x00000399
		public fPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000021AF File Offset: 0x000003AF
		// (set) Token: 0x06000019 RID: 25 RVA: 0x000021B7 File Offset: 0x000003B7
		public double X { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000021C0 File Offset: 0x000003C0
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000021C8 File Offset: 0x000003C8
		public double Y { get; set; }
	}
}
