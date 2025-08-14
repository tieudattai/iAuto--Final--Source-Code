using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Threading;
using L.Properties;

namespace L
{
    internal partial class m : Form
    {
        private static string ss = Guid.NewGuid().ToString().Substring(0, 6);

        public m()
        {
            this.InitializeComponent();
            this.u.Select();
            try
            {
                m.d();
            }
            catch
            {
            }
            base.Icon = (this.hk.Icon = Resources.icon);
            this.hk.MouseClick += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (base.Visible && base.WindowState == FormWindowState.Normal)
                    {
                        base.Hide();
                    }
                    else
                    {
                        base.Visible = true;
                        base.WindowState = FormWindowState.Normal;
                        m.SetForegroundWindow(base.Handle);
                    }
                }
                if (e.Button == MouseButtons.Middle)
                {
                    base.Dispose();
                }
            };
            m.ni ni = m.ni.ll("-iAuto.ini");
            this.u.Text = ni.rr("User", "Email");
            this.p.Text = ni.rr("User", "Pass");
            base.TopMost = (ni.rr("User", "TopMost") == "True");
        }

        private static void d()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(SettingsSection));
            if (assembly != null)
            {
                Type type = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (type != null)
                {
                    object obj = type.InvokeMember("Section", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty, null, null, new object[0]);
                    if (obj != null)
                    {
                        FieldInfo field = type.GetField("useUnsafeHeaderParsing", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (field != null)
                        {
                            field.SetValue(obj, true);
                        }
                    }
                }
            }
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error) => true));
            ServicePointManager.ServerCertificateValidationCallback = ((object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error) => true);
        }

        public static string c(string u)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(u);
            httpWebRequest.Method = "GET";
            httpWebRequest.AllowAutoRedirect = true;
            httpWebRequest.Proxy = null;
            httpWebRequest.ServicePoint.Expect100Continue = false;
            httpWebRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
            string result;
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void ml(object sender, EventArgs e)
        {
        }

        private void th(object sender, EventArgs e)
        {
            Process.Start("http://darkauto.org/");
        }

        private void gj(object sender, EventArgs e)
        {
            this.p.PasswordChar = (this.kk.Checked ? '\0' : '*');
        }

        private void lu(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; this.ll.Enabled = false; this.btnR.Enabled = false;

            Task.Factory.StartNew(delegate ()
            {
                try
                {
                    var loginContext = new { ThisForm = this };
                    loginContext.ThisForm.Invoke(new Action(() =>
                    {
                        string loginUrl = string.Concat(new string[]
                        { "http://darkauto.org/dark.php?cmd=login&email=", HttpUtility.UrlEncode(this.u.Text), "&pass=", HttpUtility.UrlEncode(this.p.Text),"&hwid=",m.ss,  });

                        string loginResult = m.c(loginUrl);

                        if (loginResult == "success")
                        {
                            Assembly loadedAssembly = null;

                            if (loadedAssembly == null)
                            {
                                using (WebClient webClient = new WebClient())
                                {
                                    string downloadUrl = string.Concat(new string[]
                                    {
                                      "http://darkauto.org/dark.php?cmd=gui&email=",HttpUtility.UrlEncode(this.u.Text),"&pass=",HttpUtility.UrlEncode(this.p.Text),"&hwid=",m.ss });

                                    byte[] downloadData = webClient.DownloadData(downloadUrl);
                                    using (ZipArchive zipArchive = new ZipArchive(new MemoryStream(downloadData)))
                                    {
                                        ZipArchiveEntry entry = zipArchive.Entries.FirstOrDefault();
                                        if (entry != null)
                                        {
                                            using (Stream stream = entry.Open())
                                            {
                                                MemoryStream memoryStream = new MemoryStream();
                                                stream.CopyTo(memoryStream);
                                                loadedAssembly = Assembly.Load(memoryStream.ToArray());
                                            }
                                        }
                                    }
                                }
                            }

                            if (loadedAssembly != null)
                            {
                                Type[] types = loadedAssembly.GetTypes();
                                foreach (Type type in types)
                                {
                                    if (type.FullName.EndsWith("GUI"))
                                    {
                                        object instance = loadedAssembly.CreateInstance(type.FullName);
                                        UserControl userControl = (UserControl)instance.GetType()
                                            .GetMethod("Create").Invoke(instance, new object[]
                                            {
                                                                                                                    this.u.Text,
                                                                                                                                                        this.p.Text });

                                        this.Width = userControl.Width;
                                        this.Height = userControl.Height;
                                        userControl.Dock = DockStyle.Fill;
                                        this.Controls.Add(userControl);
                                        userControl.BringToFront();

                                        userControl.Disposed += (s, args) =>
                                        {
                                            this.Width = 300;
                                            this.Height = 180;
                                        };
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                m.mr.ss("Không thể load dll", this);
                            }
                        }
                        else
                        {
                            m.mr.ss(loginResult, this);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(() => m.mr.ss(ex.ToString(), this));
                }
                finally
                {
                    this.Invoke(delegate ()
                    {
                        this.ll.Enabled = true;
                        this.btnR.Enabled = true;
                    });
                }
            });

        }



        private void np(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.lu(this, e);
            }
        }

        private void yh(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.p.Select();
            }
        }

        private void ti(object sender, CancelEventArgs e)
        {
            this.ot.Checked = base.TopMost;
        }

        private void ls(object sender, EventArgs e)
        {
            base.TopMost = !this.ot.Checked;
        }

        private void no(object sender, EventArgs e)
        {
            this.hk.Dispose();
            base.Dispose();
        }

        private void fi(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                base.Hide();
                e.Cancel = true;
            }
        }

        private void m_Load(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPass.PasswordChar = (this.txtReTypePass.PasswordChar = (this.checkBox1.Checked ? '\0' : '*'));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnR.Enabled = false;
            this.ll.Enabled = false;
            Task.Run(delegate ()
            {
                try
                {
                    string registerUrl = string.Concat(new string[]
                    {
                        "http://darkauto.org/dark.php?cmd=reg&email=",
                        HttpUtility.UrlEncode(this.txtU.Text),
                        "&pass=",
                        HttpUtility.UrlEncode(this.txtPass.Text),
                        "&repass=",
                        HttpUtility.UrlEncode(this.txtReTypePass.Text),
                        "&hwid=",
                        m.ss
                    });

                    string registerResult = m.c(registerUrl);

                    this.Invoke(delegate ()
                    {
                        m.mr.ss(registerResult, this);
                    });
                }
                catch (Exception ex)
                {
                    Exception error = ex;
                    this.Invoke(delegate ()
                    {
                        m.mr.ss(error.ToString(), this);
                    });
                }
                finally
                {
                    this.Invoke(delegate ()
                    {
                        this.btnR.Enabled = true;
                        this.ll.Enabled = true;
                    });
                }
            });
        }

        private void u_TextChanged(object sender, EventArgs e)
        {
        }

        private class mr : UserControl
        {
            private IContainer components;
            private TextBox tt;
            private Button nl;
            private Button lp;

            protected override void Dispose(bool disposing)
            {
                if (disposing && this.components != null)
                {
                    this.components.Dispose();
                }
                base.Dispose(disposing);
            }

            public static m.mr ii { get; set; }

            public static void ss(string jj, Control kk)
            {
                m.mr.ii = new m.mr
                {
                    Dock = DockStyle.Fill,
                    Text = jj
                };
                m.mr.ii.Parent = kk;
                m.mr.ii.BringToFront();
            }

            public mr()
            {
                this.tt = new TextBox();
                this.nl = new Button();
                this.lp = new Button();
                base.SuspendLayout();
                this.tt.BackColor = Color.FromArgb(15, 157, 88);
                this.tt.BorderStyle = BorderStyle.None;
                this.tt.Dock = DockStyle.Fill;
                this.tt.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.tt.ForeColor = Color.White;
                this.tt.Location = new Point(5, 5);
                this.tt.Multiline = true;
                this.tt.Name = "textBox1";
                this.tt.ReadOnly = true;
                this.tt.Size = new Size(385, 422);
                this.tt.TabIndex = 0;
                this.nl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                this.nl.BackColor = Color.White;
                this.nl.FlatAppearance.BorderSize = 0;
                this.nl.FlatStyle = FlatStyle.Flat;
                this.nl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.nl.ForeColor = SystemColors.GrayText;
                this.nl.Location = new Point(115, 394);
                this.nl.Name = "nl";
                this.nl.Size = new Size(275, 33);
                this.nl.TabIndex = 1;
                this.nl.Text = "Ok";
                this.nl.UseVisualStyleBackColor = false;
                this.nl.Click += this.hu;
                this.lp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                this.lp.BackColor = Color.White;
                this.lp.FlatAppearance.BorderSize = 0;
                this.lp.FlatStyle = FlatStyle.Flat;
                this.lp.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.lp.ForeColor = SystemColors.GrayText;
                this.lp.Location = new Point(5, 394);
                this.lp.Name = "lp";
                this.lp.Size = new Size(111, 33);
                this.lp.TabIndex = 2;
                this.lp.Text = "Cancel";
                this.lp.UseVisualStyleBackColor = false;
                this.lp.Click += this.lo;
                base.AutoScaleDimensions = new SizeF(6f, 13f);
                base.AutoScaleMode = AutoScaleMode.Font;
                this.BackColor = Color.FromArgb(15, 157, 88);
                base.Controls.Add(this.lp);
                base.Controls.Add(this.nl);
                base.Controls.Add(this.tt);
                base.Name = "mr";
                base.Padding = new Padding(5);
                base.Size = new Size(395, 432);
                base.Load += this.ll;
                base.ResumeLayout(false);
                base.PerformLayout();
            }

            private void ll(object sender, EventArgs e)
            {
                this.tt.BackColor = Color.FromArgb(15, 157, 88);
                this.tt.ForeColor = Color.White;
            }

            public override string Text
            {
                set
                {
                    this.tt.Text = value;
                }
            }

            public EventHandler gt { get; set; }

            private void hu(object sender, EventArgs e)
            {
                if (this.gt != null)
                {
                    this.gt(this, null);
                }
                base.Dispose();
            }

            private void lo(object sender, EventArgs e)
            {
                base.Dispose();
            }
        }

        private class lo
        {
            public string ki { get; set; } = string.Empty;
            public string mi { get; set; } = string.Empty;

            public override int GetHashCode()
            {
                return ("[" + this.ki + "]" + this.mi).GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return obj != null && (obj as m.lo).ki == this.ki && (obj as m.lo).mi == this.mi;
            }
        }

        private class ni
        {
            private Dictionary<m.lo, string> jj = new Dictionary<m.lo, string>();

            public static string rf(string name)
            {
                if (!File.Exists(name))
                {
                    return string.Empty;
                }
                string result;
                try
                {
                    using (StreamReader streamReader = new StreamReader(name))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }

            public static m.ni ll(string path)
            {
                if (File.Exists(path))
                {
                    return new m.ni(m.ni.rf(path));
                }
                if (File.Exists(path + ".old"))
                {
                    return new m.ni(m.ni.rf(path + ".old"));
                }
                return new m.ni(string.Empty);
            }

            public ni(string ini)
            {
                string text = null;
                try
                {
                    TextReader textReader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(ini)));
                    for (string text2 = textReader.ReadLine(); text2 != null; text2 = textReader.ReadLine())
                    {
                        if (!text2.Equals(string.Empty))
                        {
                            if (text2.StartsWith("[") && text2.EndsWith("]"))
                            {
                                text = text2.Substring(1, text2.Length - 2);
                            }
                            else
                            {
                                string[] array = text2.Split(new char[]
                                {
                                    '='
                                }, 2);
                                m.lo lo = new m.lo();
                                if (text == null)
                                {
                                    text = "ROOT";
                                }
                                lo.ki = text;
                                lo.mi = array[0];
                                this.jj.Add(lo, array[1].Replace("\\n", "\r\n"));
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            public string rr(string cc, string kk)
            {
                m.lo key = new m.lo
                {
                    ki = cc,
                    mi = kk
                };
                if (!this.jj.ContainsKey(key))
                {
                    return string.Empty;
                }
                string text = this.jj[key];
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }
                return text;
            }
        }
    }
}