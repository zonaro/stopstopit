namespace StopstopIt
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            abrirFormulárioToolStripMenuItem = new ToolStripMenuItem();
            lockme = new ToolStripMenuItem();
            winstart = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            d1 = new ToolStripMenuItem();
            d3 = new ToolStripMenuItem();
            d5 = new ToolStripMenuItem();
            d10 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            sairToolStripMenuItem = new ToolStripMenuItem();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "StopStop.it";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { abrirFormulárioToolStripMenuItem, lockme, winstart, toolStripSeparator1, d1, d3, d5, d10, toolStripSeparator2, sairToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(232, 192);
            // 
            // abrirFormulárioToolStripMenuItem
            // 
            abrirFormulárioToolStripMenuItem.Name = "abrirFormulárioToolStripMenuItem";
            abrirFormulárioToolStripMenuItem.Size = new Size(231, 22);
            abrirFormulárioToolStripMenuItem.Text = "Mostrar Tarefas";
            abrirFormulárioToolStripMenuItem.Click += abrirFormulárioToolStripMenuItem_Click;
            // 
            // lockme
            // 
            lockme.Checked = true;
            lockme.CheckOnClick = true;
            lockme.CheckState = CheckState.Checked;
            lockme.Name = "lockme";
            lockme.Size = new Size(231, 22);
            lockme.Text = "Travar computador ao pausar";
            // 
            // winstart
            // 
            winstart.CheckOnClick = true;
            winstart.Name = "winstart";
            winstart.Size = new Size(231, 22);
            winstart.Text = "Iniciar com Windows";
            winstart.Click += winstart_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(228, 6);
            // 
            // d1
            // 
            d1.CheckOnClick = true;
            d1.Name = "d1";
            d1.Size = new Size(231, 22);
            d1.Text = "Definir pausa para 1 minuto";
            d1.Click += d1_Click;
            // 
            // d3
            // 
            d3.Checked = true;
            d3.CheckOnClick = true;
            d3.CheckState = CheckState.Checked;
            d3.Name = "d3";
            d3.Size = new Size(231, 22);
            d3.Text = "Definir pausa para 3 minutos";
            d3.Click += d3_Click;
            // 
            // d5
            // 
            d5.CheckOnClick = true;
            d5.Name = "d5";
            d5.Size = new Size(231, 22);
            d5.Text = "Definir pausa para 5 minutos";
            d5.Click += d5_Click;
            // 
            // d10
            // 
            d10.CheckOnClick = true;
            d10.Name = "d10";
            d10.Size = new Size(231, 22);
            d10.Text = "Definir pausa para 10 minutos";
            d10.Click += d10_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(228, 6);
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(231, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(1064, 425);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 425);
            Controls.Add(webView21);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "StopStop.it";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem d1;
        private System.Windows.Forms.ToolStripMenuItem d3;
        private System.Windows.Forms.ToolStripMenuItem d5;
        private System.Windows.Forms.ToolStripMenuItem d10;
        private System.Windows.Forms.ToolStripMenuItem abrirFormulárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockme;
        private System.Windows.Forms.ToolStripMenuItem winstart;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}

