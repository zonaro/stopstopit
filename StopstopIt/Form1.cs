using System.Runtime.InteropServices;
using Microsoft.Win32;
using WebView2.DevTools.Dom;

namespace StopstopIt
{
    public partial class Form1 : Form

    {
        #region Private Fields

        private string linkPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\StopStop.it.url";

        #endregion Private Fields

        #region Private Methods

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(out LASTINPUTINFO plii);

        private void abrirFormulárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrar();
        }

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

        private void d1_Click(object sender, EventArgs e)
        {
            deschecar();
            minutos = 1;
            d1.Checked = true;
        }

        private void d10_Click(object sender, EventArgs e)
        {
            deschecar();
            minutos = 10;
            d10.Checked = true;
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

        private void deschecar()
        {
            d1.Checked = false;
            d3.Checked = false;
            d5.Checked = false;
            d10.Checked = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            navegar();
            this.Hide();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            notifyIcon1.Visible = true;
            webView21.CoreWebView2.Navigate("https://runrun.it/pt-BR/user_session/new");

            timer1.Enabled = true;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        private void mostrar()
        {
            navegar();
            this.Show();
        }

        private void navegar()
        {
            if (!webView21.Source.GetLeftPart(UriPartial.Path).Contains("https://runrun.it/pt-BR/me/tasks"))
            {
                var wait = true;
                webView21.CoreWebView2.Navigate("https://runrun.it/pt-BR/me/tasks");
                void hh(object? o, EventArgs e)
                {
                    wait = false;
                    webView21.CoreWebView2.NavigationCompleted -= hh;
                }
                webView21.CoreWebView2.NavigationCompleted += hh;
                while (wait)
                {
                    Application.DoEvents();
                }
            }
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

        private async Task<HtmlButtonElement> PegarBotao()
        {
            // Create one instance per CoreWebView2 Reuse devToolsContext if possible, dispose (via
            // DisposeAsync) before creating new instance Make sure to call DisposeAsync when
            // finished or await using as per this example Add using WebView2.DevTools.Dom; to
            // access the CreateDevToolsContextAsync extension method
            await using var devtoolsContext = await webView21.CoreWebView2.CreateDevToolsContextAsync();
            var bt = await devtoolsContext.QuerySelectorAsync<HtmlButtonElement>("button[data-onboarding=play-pause-button]");
            if (bt != null)
            {
                var i = await bt.QuerySelectorAsync("i.fa-pause");
                if (i != null)
                {
                    return bt;

                }

            }
            return null;
        }

        private void RemoveStartup()
        {
            if (System.IO.File.Exists(linkPath)) { System.IO.File.Delete(linkPath); }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            winstart.Checked = System.IO.File.Exists(linkPath);

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            trypause();
        }

        private async void trypause()
        {
            var botao = await PegarBotao();

            if (botao != null)
            {
                IsRunRunPaused = true;
                await botao.ClickAsync();
                notifyIcon1.ShowBalloonTip(3000, "Runrun.It", "RunRun pausado!", ToolTipIcon.Warning);

                if (lockme.Checked)
                {
                    ProcessChecker.LockWorkStation();
                }
            }
        }

        private void winstart_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(linkPath))
            {
                RemoveStartup();
            }
            else
            {
                AddStartup();
            }

            winstart.Checked = System.IO.File.Exists(linkPath);
        }

        #endregion Private Methods

        #region Private Structs

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

        #endregion Private Structs

        #region Public Fields

        public int LastTask = 0;

        public int minutos = 3;

        #endregion Public Fields

        #region Public Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public int idleTime { get; set; } = 0;

        public bool IsOnPC => idleTime <= (60 * minutos);

        public bool IsRunRunPaused { get; set; } = true;

        #endregion Public Properties

        #region Public Methods

        public void OnIdle()
        {
            if (IsOnPC == false && IsRunRunPaused == false)
            {
                trypause();
            }
            else
            {
                if (idleTime == 0)
                {
                    this.Text = $"RunRun.it";

                }
                else
                {
                    this.Text = $"RunRun.it - Pausando em {minutos * 60 - idleTime} segundos";

                }
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

        #endregion Public Methods
    }
}