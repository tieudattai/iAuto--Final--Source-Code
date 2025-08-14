using System;

namespace L
{
	// Token: 0x02000004 RID: 4
	internal class ComboboxValue
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000021D1 File Offset: 0x000003D1
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000021D9 File Offset: 0x000003D9
		public string Id { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000021E2 File Offset: 0x000003E2
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000021EA File Offset: 0x000003EA
		public string Name { get; private set; }

		// Token: 0x06000020 RID: 32 RVA: 0x000021F3 File Offset: 0x000003F3
		public ComboboxValue(string id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002209 File Offset: 0x00000409
		public override string ToString()
		{
			return this.Name;
		}
	}
}
