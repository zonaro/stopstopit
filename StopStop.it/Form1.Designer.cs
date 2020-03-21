namespace StopStop.it
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirFormulárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockme = new System.Windows.Forms.ToolStripMenuItem();
            this.winstart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.d1 = new System.Windows.Forms.ToolStripMenuItem();
            this.d3 = new System.Windows.Forms.ToolStripMenuItem();
            this.d5 = new System.Windows.Forms.ToolStripMenuItem();
            this.d10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "StopStop.it";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirFormulárioToolStripMenuItem,
            this.lockme,
            this.winstart,
            this.toolStripSeparator1,
            this.d1,
            this.d3,
            this.d5,
            this.d10,
            this.toolStripSeparator2,
            this.sairToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(232, 192);
            // 
            // abrirFormulárioToolStripMenuItem
            // 
            this.abrirFormulárioToolStripMenuItem.Name = "abrirFormulárioToolStripMenuItem";
            this.abrirFormulárioToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.abrirFormulárioToolStripMenuItem.Text = "Mostrar Tarefas";
            this.abrirFormulárioToolStripMenuItem.Click += new System.EventHandler(this.abrirFormulárioToolStripMenuItem_Click);
            // 
            // lockme
            // 
            this.lockme.Checked = true;
            this.lockme.CheckOnClick = true;
            this.lockme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockme.Name = "lockme";
            this.lockme.Size = new System.Drawing.Size(231, 22);
            this.lockme.Text = "Travar computador ao pausar";
            // 
            // winstart
            // 
            this.winstart.CheckOnClick = true;
            this.winstart.Name = "winstart";
            this.winstart.Size = new System.Drawing.Size(231, 22);
            this.winstart.Text = "Iniciar com Windows";
            this.winstart.Click += new System.EventHandler(this.winstart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // d1
            // 
            this.d1.CheckOnClick = true;
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(231, 22);
            this.d1.Text = "Definir pausa para 1 minuto";
            this.d1.Click += new System.EventHandler(this.d1_Click);
            // 
            // d3
            // 
            this.d3.Checked = true;
            this.d3.CheckOnClick = true;
            this.d3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(231, 22);
            this.d3.Text = "Definir pausa para 3 minutos";
            this.d3.Click += new System.EventHandler(this.d3_Click);
            // 
            // d5
            // 
            this.d5.CheckOnClick = true;
            this.d5.Name = "d5";
            this.d5.Size = new System.Drawing.Size(231, 22);
            this.d5.Text = "Definir pausa para 5 minutos";
            this.d5.Click += new System.EventHandler(this.d5_Click);
            // 
            // d10
            // 
            this.d10.CheckOnClick = true;
            this.d10.Name = "d10";
            this.d10.Size = new System.Drawing.Size(231, 22);
            this.d10.Text = "Definir pausa para 10 minutos";
            this.d10.Click += new System.EventHandler(this.d10_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(912, 368);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://runrun.it/pt-BR/me/tasks", System.UriKind.Absolute);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 368);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "StopStop.it";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.WebBrowser webBrowser1;
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
    }
}

