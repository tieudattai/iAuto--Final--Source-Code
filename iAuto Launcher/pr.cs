using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace L
{
	// Token: 0x02000020 RID: 32
	internal static class pr
	{
		// Token: 0x060000DA RID: 218 RVA: 0x00006C2C File Offset: 0x00004E2C
		[STAThread]
		private static void Main()
		{
			if (!pr.IsRunAsAdmin())
			{
				pr.Elevate();
				Application.Exit();
				return;
			}
			StringBuilder builder = new StringBuilder(100);
			Process[] processesByName = Process.GetProcessesByName("iAuto_DarkMode");
			for (int i = 0; i < processesByName.Length; i++)
			{
				Process process = processesByName[i];
				IntPtr handle = IntPtr.Zero;
				pr.EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
				{
					int num;
					pr.GetWindowThreadProcessId(hWnd, out num);
					if (process.Id == num)
					{
						pr.GetClassName(hWnd, builder, 100);
						if (builder.ToString().Contains("WindowsForms10.Window.8.app"))
						{
							handle = hWnd;
							return true;
						}
					}
					return true;
				}, IntPtr.Zero);
				if (handle != IntPtr.Zero)
				{
					pr.Active(handle);
				}
			}
			bool flag = true;
			using (new Mutex(true, "iAuto_DarkMode", out flag))
			{
				if (flag)
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new m());
				}
			}
		}

		// Token: 0x060000DB RID: 219
		[DllImport("user32.dll")]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		// Token: 0x060000DC RID: 220
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x060000DD RID: 221
		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		// Token: 0x060000DE RID: 222
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		// Token: 0x060000DF RID: 223 RVA: 0x00006D1C File Offset: 0x00004F1C
		public static void Active(IntPtr handle)
		{
			pr.RECT rect;
			pr.GetWindowRect(handle, out rect);
			bool flag = rect.Left == -32000;
			if (!pr.IsWindowVisible(handle))
			{
				pr.ShowWindow(handle, pr.WindowShowStyle.Show);
			}
			if (flag)
			{
				pr.ShowWindow(handle, pr.WindowShowStyle.Restore);
			}
			if (pr.GetForegroundWindow() != handle)
			{
				pr.SetForegroundWindow(handle);
			}
		}

		// Token: 0x060000E0 RID: 224
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumWindows(pr.EnumWindowsProc lpEnumFunc, IntPtr lParam);

		// Token: 0x060000E1 RID: 225
		[DllImport("user32.dll")]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// Token: 0x060000E2 RID: 226
		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hwnd, out pr.RECT lpRect);

		// Token: 0x060000E3 RID: 227
		[DllImport("user32.dll")]
		public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

		// Token: 0x060000E4 RID: 228
		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x060000E5 RID: 229
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x060000E6 RID: 230
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, pr.WindowShowStyle nCmdShow);

		// Token: 0x060000E7 RID: 231 RVA: 0x0000298A File Offset: 0x00000B8A
		internal static bool IsRunAsAdmin()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006D70 File Offset: 0x00004F70
		private static bool Elevate()
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				UseShellExecute = true,
				WorkingDirectory = Environment.CurrentDirectory,
				FileName = Application.ExecutablePath,
				Verb = "runas"
			};
			bool result;
			try
			{
				Process.Start(startInfo);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000095 RID: 149
		public const int SW_RESTORE = 9;

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x060000EA RID: 234
		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		// Token: 0x02000022 RID: 34
		public struct RECT
		{
			// Token: 0x04000096 RID: 150
			public int Left;

			// Token: 0x04000097 RID: 151
			public int Top;

			// Token: 0x04000098 RID: 152
			public int Right;

			// Token: 0x04000099 RID: 153
			public int Bottom;
		}

		// Token: 0x02000023 RID: 35
		public enum WindowShowStyle : uint
		{
			// Token: 0x0400009B RID: 155
			Hide,
			// Token: 0x0400009C RID: 156
			ShowNormal,
			// Token: 0x0400009D RID: 157
			ShowMinimized,
			// Token: 0x0400009E RID: 158
			ShowMaximized,
			// Token: 0x0400009F RID: 159
			Maximize = 3U,
			// Token: 0x040000A0 RID: 160
			ShowNormalNoActivate,
			// Token: 0x040000A1 RID: 161
			Show,
			// Token: 0x040000A2 RID: 162
			Minimize,
			// Token: 0x040000A3 RID: 163
			ShowMinNoActivate,
			// Token: 0x040000A4 RID: 164
			ShowNoActivate,
			// Token: 0x040000A5 RID: 165
			Restore,
			// Token: 0x040000A6 RID: 166
			ShowDefault,
			// Token: 0x040000A7 RID: 167
			ForceMinimized
		}
	}
}
