using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace L
{
    internal static class StringExtensions
    {
        public static string RemoveVietnameseSigns(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            StringBuilder stringBuilder = new StringBuilder(str);
            for (int i = 1; i < StringExtensions.VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < StringExtensions.VietnameseSigns[i].Length; j++)
                {
                    stringBuilder.Replace(StringExtensions.VietnameseSigns[i][j], StringExtensions.VietnameseSigns[0][i - 1]);
                }
            }
            return stringBuilder.ToString();
        }

        public static int IndexOf(this string[] list, string input)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == input)
                {
                    return i;
                }
            }
            return -1;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }

        public static string VietLen(this string str)
        {
            return StringExtensions.VietLien(str);
        }

        public static string VietLien(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return StringExtensions.ClearSign(str).Replace(" ", "").Replace("\r", "").ToLower();
        }

        public static string ClearSign(string str)
        {
            for (int i = 1; i < StringExtensions.VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < StringExtensions.VietnameseSigns[i].Length; j++)
                {
                    str = str.Replace(StringExtensions.VietnameseSigns[i][j], StringExtensions.VietnameseSigns[0][i - 1]);
                }
            }
            return str;
        }

        public static string RemoveSign4VietnameseString(this string str)
        {
            for (int i = 1; i < StringExtensions.VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < StringExtensions.VietnameseSigns[i].Length; j++)
                {
                    str = str.Replace(StringExtensions.VietnameseSigns[i][j], StringExtensions.VietnameseSigns[0][i - 1]);
                }
            }
            return str;
        }

        public static void AppendTextTop(this RichTextBox box, string text, Color color, bool nosu = false)
        {
            box.Text = box.Text.Insert(0, text);
            StringExtensions.RichTextBoxChangeWordColor(box, 0, text.Length, color, nosu);
        }

        public static void CopyTo(this Stream i, Stream p)
        {
            byte[] array = new byte[16384];
            int count;
            while ((count = i.Read(array, 0, array.Length)) > 0)
            {
                p.Write(array, 0, count);
            }
        }

        public static byte[] ToByteArray(this uint I16)
        {
            return BitConverter.GetBytes(I16);
        }

        public static List<Point> GetAllWordsIndecesBetween(string intoText, string fromThis, string toThis, bool withSigns = true)
        {
            List<Point> list = new List<Point>();
            Stack<int> stack = new Stack<int>();
            bool flag = false;
            for (int i = 0; i < intoText.Length; i++)
            {
                string text = intoText.Substring(i);
                if (text.StartsWith(fromThis) && ((fromThis == toThis && !flag) || !text.StartsWith(toThis)))
                {
                    if (!withSigns)
                    {
                        i += fromThis.Length;
                    }
                    flag = true;
                    stack.Push(i);
                }
                else if (text.StartsWith(toThis))
                {
                    if (withSigns)
                    {
                        i += toThis.Length;
                    }
                    flag = false;
                    if (stack.Count > 0)
                    {
                        int x = stack.Pop();
                        list.Add(new Point(x, i));
                    }
                }
            }
            return list;
        }

        public static string ToBinaryString(this string hexString)
        {
            string text = "";
            foreach (char c in hexString)
            {
                if (c != ' ')
                {
                    try
                    {
                        string text2 = Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2);
                        while (text2.Length < 4)
                        {
                            text2 = "0" + text2;
                        }
                        for (int j = 0; j < text2.Length; j++)
                        {
                            if (text2[j] == '0')
                            {
                                text += "0";
                            }
                            else
                            {
                                text += "1";
                            }
                        }
                    }
                    catch
                    {
                        text += "0000";
                    }
                }
            }
            return text;
        }

        public static string Between(this string input, string beginString, string endString = "")
        {
            int num = input.IndexOf(beginString);
            if (num == -1)
            {
                return string.Empty;
            }
            int num2 = (endString != "") ? input.IndexOf(endString, num + beginString.Length) : input.Length;
            if (num2 == -1)
            {
                return string.Empty;
            }
            return input.Substring(num + beginString.Length, num2 - num - beginString.Length);
        }

        public static string ToHexString(this string binaryString)
        {
            string text = "";
            int num = 8 - binaryString.Length % 8;
            binaryString = binaryString.PadRight(binaryString.Length + num, '0');
            for (int i = 0; i < binaryString.Length; i += 8)
            {
                string value = binaryString.Substring(i, 8);
                int num2 = 0;
                try
                {
                    num2 = Convert.ToInt32(value, 2);
                }
                catch (FormatException)
                {
                    num2 = 0;
                }
                text += num2.ToString("X2");
            }
            return text;
        }

        public static RichTextBox RichTextBoxChangeWordColor(RichTextBox rtb, int start, int end, Color color, bool nosu = false)
        {
            rtb.SuspendLayout();
            rtb.SelectionStart = 0;
            rtb.SelectionLength = end;
            rtb.SelectionColor = color;
            rtb.ResumeLayout(true);
            return rtb;
        }

        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void ScroolToEnd(this RichTextBox box)
        {
            box.SelectionStart = box.Text.Length;
            box.ScrollToCaret();
        }

        public static T DeepClone<T>(this T obj)
        {
            T result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0L;
                result = (T)((object)binaryFormatter.Deserialize(memoryStream));
            }
            return result;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref StringExtensions.LVITEM lvi);

        public static void SelectAllItems(this ListView listView)
        {
            StringExtensions.SetItemState(listView, -1, 2, 2);
        }

        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T obj in @this)
            {
                action(obj);
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static void Invoke(this Control control, Action action)
        {
            control.Invoke(action);
        }

        public static void SetItemState(ListView listView, int itemIndex, int mask, int value)
        {
            StringExtensions.LVITEM lvitem = default(StringExtensions.LVITEM);
            lvitem.stateMask = mask;
            lvitem.state = value;
            StringExtensions.SendMessage(new HandleRef(listView, listView.Handle), 4139, itemIndex, ref lvitem);
        }

        public static void Invoke(this Form form, Action a)
        {
            form.Invoke(new Action(a.Invoke));
        }

        public static double DistanceToLine(this Point point, Point x, Point y)
        {
            int num = x.Y - y.Y;
            int num2 = y.X - x.X;
            int num3 = num * (0 - x.X) + num2 * (0 - x.Y);
            return (double)Math.Abs(num * point.X + num2 * point.Y + num3) / Math.Sqrt((double)(num * num + num2 * num2));
        }

        public static bool IsInLine(this Point point, Point x, Point y)
        {
            int num = x.Y - y.Y;
            int num2 = y.X - x.X;
            int num3 = num * (0 - x.X) + num2 * (0 - x.Y);
            return num * point.X + num2 * point.Y + num3 == 0;
        }

        public static bool IsInLine(this fPoint point, Point x, Point y)
        {
            int num = x.Y - y.Y;
            int num2 = y.X - x.X;
            int num3 = num * (0 - x.X) + num2 * (0 - x.Y);
            return (double)num * point.X + (double)num2 * point.Y + (double)num3 == 0.0;
        }

        public static bool IsClockwise(this Point from, Point to, Point tam)
        {
            from.X -= tam.X;
            to.X -= tam.X;
            from.Y = tam.Y - from.Y;
            to.Y = tam.Y - to.Y;
            return (to.X - from.X) * (to.Y + from.Y) > 0;
        }

        public static int TimDelta(Point x, Point y, Point m, float R)
        {
            int num = x.Y - y.Y;
            int num2 = y.X - x.X;
            int num3 = num * (0 - x.X) + num2 * (0 - x.Y);
            num = -num / num2;
            num2 = -num3 / num2;
            int x2 = m.X;
            int y2 = m.Y;
            return (int)((double)((float)(4 * (num * (num2 - y2) - x2) * (num * (num2 - y2) - x2)) - (float)(4 * (num * num + 1)) * ((float)(x2 * x2 + (num2 - y2) * (num2 - y2)) - R * R)));
        }

        public static List<fPoint> TimGiaoDiem(Point x, Point y, Point m, float R)
        {
            List<fPoint> list = new List<fPoint>();
            double num = (double)(x.Y - y.Y);
            double num2 = (double)(y.X - x.X);
            double num3 = num * (double)(0 - x.X) + num2 * (double)(0 - x.Y);
            if (num2 == 0.0)
            {
                double num4 = (double)x.X;
                double num5 = (double)(4 * m.Y * m.Y) - 4.0 * ((double)(m.Y * m.Y) + (num4 - (double)m.X) * (num4 - (double)m.X) - (double)(R * R));
                if (num5 == 0.0)
                {
                    double y2 = (double)(2 * m.Y / 2);
                    list.Add(new fPoint(num4, y2));
                    return list;
                }
                if (num5 > 0.0)
                {
                    double y3 = ((double)(2 * m.Y) + Math.Sqrt(num5)) / 2.0;
                    double y4 = ((double)(2 * m.Y) - Math.Sqrt(num5)) / 2.0;
                    list.Add(new fPoint(num4, y3));
                    list.Add(new fPoint(num4, y4));
                    return list;
                }
            }
            else if (num == 0.0)
            {
                double num6 = (double)x.Y;
                double num5 = (double)(4 * m.X * m.X) - 4.0 * ((double)(m.X * m.X) + (num6 - (double)m.Y) * (num6 - (double)m.Y) - (double)(R * R));
                if (num5 == 0.0)
                {
                    double x2 = (double)(2 * m.X / 2);
                    list.Add(new fPoint(x2, num6));
                    return list;
                }
                if (num5 > 0.0)
                {
                    double x3 = ((double)(2 * m.X) + Math.Sqrt(num5)) / 2.0;
                    double x4 = ((double)(2 * m.X) - Math.Sqrt(num5)) / 2.0;
                    list.Add(new fPoint(x3, num6));
                    list.Add(new fPoint(x4, num6));
                    return list;
                }
            }
            else
            {
                num = -num / num2;
                num2 = -num3 / num2;
                double num5 = 4.0 * (num * (num2 - (double)m.Y) - (double)m.X) * (num * (num2 - (double)m.Y) - (double)m.X) - 4.0 * (num * num + 1.0) * ((double)m.X + (num2 - (double)m.Y) * (num2 - (double)m.Y) - (double)(R * R));
                if (num5 == 0.0)
                {
                    double num7 = -2.0 * (num * (num2 - (double)m.Y) - (double)m.X) / (2.0 * (num * num + 1.0));
                    list.Add(new fPoint(num7, num * num7 + num2));
                    return list;
                }
                if (num5 > 0.0)
                {
                    double num8 = (-2.0 * (num * (num2 - (double)m.Y) - (double)m.X) + Math.Sqrt(num5)) / (2.0 * (num * num + 1.0));
                    double num9 = (-2.0 * (num * (num2 - (double)m.Y) - (double)m.X) - Math.Sqrt(num5)) / (2.0 * (num * num + 1.0));
                    list.Add(new fPoint(num8, num * num8 + num2));
                    list.Add(new fPoint(num9, num * num9 + num2));
                    return list;
                }
            }
            return list;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (int i = 0; i < array.Length; i += size)
            {
                yield return array.Skip(i).Take(size);
            }
        }

        public static IEnumerable<T> AllControls<T>(this Control startingPoint) where T : Control
        {
            var controls = startingPoint.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => ctrl.AllControls<T>())
                .Concat(controls)
                .Where(c => c is T)
                .Cast<T>();
        }

        public static IEnumerable<Control> GetControlHierarchy(this Control root)
        {
            var queue = new Queue<Control>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var control = queue.Dequeue();
                yield return control;

                foreach (Control child in control.Controls)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public static void WriteFile(string name, string content)
        {
            try
            {
                new FileStream(name, FileMode.Create).Close();
                StreamWriter streamWriter = new StreamWriter(name);
                streamWriter.Write(content);
                streamWriter.Close();
            }
            catch
            {
            }
        }

        public static void SafeSave(this string content, string path)
        {
            StringExtensions.WriteFile(path, content);
        }

        public static IEnumerable<Control> GetAllChildren(this Control root)
        {
            foreach (Control child in root.Controls)
            {
                yield return child;
                foreach (Control descendant in GetAllChildren(child))
                {
                    yield return descendant;
                }
            }
        }

        public static int ToInt(this string val)
        {
            IEnumerable<char> source = val.Where(c => char.IsDigit(c));
            if (!source.Any())
            {
                return 0;
            }
            int num = source.Aggregate(0, (acc, digit) => acc * 10 + (int)(digit - '0'));
            if (val.StartsWith("-"))
            {
                return -num;
            }
            return num;
        }

        public static ulong ToBigInt(this string val)
        {
            string text = string.Empty;
            for (int i = 0; i < val.Length; i++)
            {
                if (char.IsDigit(val[i]))
                {
                    text += val[i].ToString();
                }
            }
            if (string.IsNullOrEmpty(text))
            {
                return 0UL;
            }
            ulong num = 0UL;
            ulong.TryParse(text, out num);
            if (val.StartsWith("-"))
            {
                return 0UL - num;
            }
            return num;
        }

        public static int ToInt(this bool val)
        {
            if (val)
            {
                return 1;
            }
            return 0;
        }

        public static IEnumerable<Control> GetDescendants(this Control control)
        {
            IEnumerable<Control> enumerable = control.Controls.Cast<Control>();
            return enumerable.Concat(enumerable.SelectMany(c => c.GetDescendants()));
        }

        public static IEnumerable<ToolStripMenuItem> GetDescendants(this ToolStripMenuItem control)
        {
            IEnumerable<ToolStripMenuItem> enumerable = (from ToolStripItem i in control.DropDownItems
                                                         where i.GetType() == typeof(ToolStripMenuItem)
                                                         select i).Cast<ToolStripMenuItem>();
            return enumerable.Concat(enumerable.SelectMany(c => c.GetDescendants()));
        }

        public static string MergeLine(this string input, string delimiter = "-")
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (input == null)
            {
                return string.Empty;
            }
            using (StringReader stringReader = new StringReader(input))
            {
                string value;
                while ((value = stringReader.ReadLine()) != null)
                {
                    stringBuilder.Append(value).Append(delimiter);
                }
            }
            return stringBuilder.ToString();
        }

        public static string EmptyIfNull(this object value)
        {
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        public static IEnumerable<string> SplitToLines(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (StringReader sr = new StringReader(input))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static int ToNumber(this string o)
        {
            if (string.IsNullOrEmpty(o))
            {
                return -1;
            }
            int num = 0;
            string text = string.Empty;
            for (int i = 0; i < o.Length; i++)
            {
                if (char.IsDigit(o[i]))
                {
                    text += o[i].ToString();
                }
                else if (text.Length > 0)
                {
                    break;
                }
            }
            if (text.Length > 0)
            {
                num = int.Parse(text);
            }
            if (o.StartsWith("-"))
            {
                return -num;
            }
            return num;
        }

        private static readonly string[] VietnameseLowerSigns = new string[]
        {
            "aaeeoouuiiddyy",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        internal const int LVM_FIRST = 4096;
        private const int LVM_SETITEMSTATE = 4139;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns;
            public IntPtr puColumns;
        }
    }

    //public struct fPoint
    //{
    //    public double X;
    //    public double Y;

    //    public fPoint(double x, double y)
    //    {
    //        X = x;
    //        Y = y;
    //    }
    //}
}