using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StopStop.it
{
    public partial class Form1 : Form

    {
        public int LastTask = 0;

        public int minutos = 3;

        public bool IsOnPC { get { return idleTime <= (60 * minutos); } }
        public bool IsRunRunPaused { get; set; } = true;

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(out LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public static readonly int SizeOf =
                   Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;

            [MarshalAs(UnmanagedType.U4)]
            public int dwTime;
        }

        public Form1()
        {
            InitializeComponent();
        }

        public int idleTime { get; set; } = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            winstart.Checked = File.Exists(linkPath);

            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            int envTicks = Environment.TickCount;

            if (GetLastInputInfo(out lastInputInfo))
            {
                int lastInputTick = lastInputInfo.dwTime;
                idleTime = envTicks - lastInputTick;
            }

            idleTime = idleTime / 1000;

            OnIdle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            webBrowser1.ScriptErrorsSuppressed = true;
            timer1.Enabled = true;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        public void OnIdle()
        {
            if (IsOnPC == false && IsRunRunPaused == false)
            {
                trypause();
            }

            if (IsOnPC)
            {
                if (IsRunRunPaused == true)
                {
                    IsRunRunPaused = false;
                    notifyIcon1.ShowBalloonTip(3000, "Runrun.It", "Aperte o play no Runrun", ToolTipIcon.Warning);
                    mostrar();
                }
            }
        }

        private string linkPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\StopStop.it.url";

        private void AddStartup()
        {
            using (StreamWriter writer = new StreamWriter(linkPath))
            {
                string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
            }
        }

        private void RemoveStartup()
        {
            if (File.Exists(linkPath)) { File.Delete(linkPath); }
        }

        private HtmlElement PegarBotao()
        {
            var all = webBrowser1.Document.GetElementsByTagName("button").Cast<HtmlElement>();

            var stringas = all.Select(x => x.GetAttribute("className"));

            return all.FirstOrDefault(x => x.GetAttribute("className").Contains("task-pause"));
        }

        private void trypause()
        {
            if (webBrowser1.Url.ToString() != "https://runrun.it/pt-BR/me/tasks")
            {
                webBrowser1.Navigate("https://runrun.it/pt-BR/me/tasks");
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }

            var botao = PegarBotao();

            if (botao != null)
            {
                notifyIcon1.ShowBalloonTip(3000, "Runrun.It", "RunRun pausado!", ToolTipIcon.Warning);
                IsRunRunPaused = true;
                botao.InvokeMember("click");

                if (lockme.Checked)
                {
                    LockIt.LockWorkStation();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            webBrowser1.Navigate("https://runrun.it/pt-BR/me/tasks");
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Close();
            }
            else
            {
                mostrar();

            }
        }

        private void mostrar()
        {
            if (webBrowser1.Url.ToString() != "https://runrun.it/pt-BR/me/tasks")
                webBrowser1.Navigate("https://runrun.it/pt-BR/me/tasks");
            this.Show();
        }

        private void deschecar()
        {
            d1.Checked = false;
            d3.Checked = false;
            d5.Checked = false;
            d10.Checked = false;
        }

        private void d1_Click(object sender, EventArgs e)
        {
            deschecar();
            minutos = 1;
            d1.Checked = true;
        }

        private void d3_Click(object sender, EventArgs e)
        {
            deschecar();
            minutos = 3;
            d3.Checked = true;
        }

        private void d5_Click(object sender, EventArgs e)
        {
            deschecar();
            minutos = 5;
            d5.Checked = true;
        }

        private void d10_Click(object sender, EventArgs e)
        {
            deschecar();
            minutos = 10;
            d10.Checked = true;
        }

        private void abrirFormulárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trypause();
            if (IsRunRunPaused)
            {
                SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
                Application.Exit();
                System.Environment.Exit(1);
            }
        }

        private void winstart_Click(object sender, EventArgs e)
        {
            if (File.Exists(linkPath))
            {
                RemoveStartup();
            }
            else
            {
                AddStartup();
            }

            winstart.Checked = File.Exists(linkPath);
        }

        public void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock || e.Reason == SessionSwitchReason.SessionLogoff)
            {
                trypause();
            }

            if (e.Reason == SessionSwitchReason.SessionLogoff)
            {
                SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;

                Application.Exit();
                System.Environment.Exit(1);
            }
        }
    }
}