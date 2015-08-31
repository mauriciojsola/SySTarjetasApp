namespace SySTarjetas.Desktop
{
    partial class MainTarjetas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTarjetas));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCupones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCargarCupones = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuListarCupones = new System.Windows.Forms.ToolStripMenuItem();
            this.comerciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListarComercios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTarjetas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResumenDeTarjetas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCargarNuevoCupon = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuCargarFechasDeCierre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArchivo,
            this.menuCupones,
            this.comerciosToolStripMenuItem,
            this.mnuTarjetas,
            this.mnuResumenDeTarjetas});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // menuArchivo
            // 
            this.menuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSalir});
            this.menuArchivo.Name = "menuArchivo";
            this.menuArchivo.Size = new System.Drawing.Size(60, 20);
            this.menuArchivo.Text = "Archivo";
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(96, 22);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // menuCupones
            // 
            this.menuCupones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCargarCupones,
            this.toolStripSeparator3,
            this.menuListarCupones});
            this.menuCupones.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuCupones.Name = "menuCupones";
            this.menuCupones.Size = new System.Drawing.Size(66, 20);
            this.menuCupones.Text = "&Cupones";
            // 
            // menuCargarCupones
            // 
            this.menuCargarCupones.Image = ((System.Drawing.Image)(resources.GetObject("menuCargarCupones.Image")));
            this.menuCargarCupones.ImageTransparentColor = System.Drawing.Color.Black;
            this.menuCargarCupones.Name = "menuCargarCupones";
            this.menuCargarCupones.Size = new System.Drawing.Size(159, 22);
            this.menuCargarCupones.Text = "&Cargar Cupones";
            this.menuCargarCupones.Click += new System.EventHandler(this.CargarCupones);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // menuListarCupones
            // 
            this.menuListarCupones.Name = "menuListarCupones";
            this.menuListarCupones.Size = new System.Drawing.Size(159, 22);
            this.menuListarCupones.Text = "Listar Cupones";
            this.menuListarCupones.Click += new System.EventHandler(this.menuListarCupones_Click);
            // 
            // comerciosToolStripMenuItem
            // 
            this.comerciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuListarComercios});
            this.comerciosToolStripMenuItem.Name = "comerciosToolStripMenuItem";
            this.comerciosToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.comerciosToolStripMenuItem.Text = "Comercios";
            // 
            // mnuListarComercios
            // 
            this.mnuListarComercios.Name = "mnuListarComercios";
            this.mnuListarComercios.Size = new System.Drawing.Size(162, 22);
            this.mnuListarComercios.Text = "Listar Comercios";
            this.mnuListarComercios.Click += new System.EventHandler(this.mnuListarComercios_Click);
            // 
            // mnuTarjetas
            // 
            this.mnuTarjetas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCargarFechasDeCierre});
            this.mnuTarjetas.Name = "mnuTarjetas";
            this.mnuTarjetas.Size = new System.Drawing.Size(60, 20);
            this.mnuTarjetas.Text = "Tarjetas";
            // 
            // mnuResumenDeTarjetas
            // 
            this.mnuResumenDeTarjetas.Name = "mnuResumenDeTarjetas";
            this.mnuResumenDeTarjetas.Size = new System.Drawing.Size(129, 20);
            this.mnuResumenDeTarjetas.Text = "Resumen De Tarjetas";
            this.mnuResumenDeTarjetas.Click += new System.EventHandler(this.mnuResumenDeTarjetas_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCargarNuevoCupon});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(632, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // btnCargarNuevoCupon
            // 
            this.btnCargarNuevoCupon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCargarNuevoCupon.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarNuevoCupon.Image")));
            this.btnCargarNuevoCupon.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnCargarNuevoCupon.Name = "btnCargarNuevoCupon";
            this.btnCargarNuevoCupon.Size = new System.Drawing.Size(23, 22);
            this.btnCargarNuevoCupon.Text = "Cargar Cupones";
            this.btnCargarNuevoCupon.Click += new System.EventHandler(this.CargarCupones);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // mnuCargarFechasDeCierre
            // 
            this.mnuCargarFechasDeCierre.Name = "mnuCargarFechasDeCierre";
            this.mnuCargarFechasDeCierre.Size = new System.Drawing.Size(198, 22);
            this.mnuCargarFechasDeCierre.Text = "Cargar Fechas de Cierre";
            this.mnuCargarFechasDeCierre.Click += new System.EventHandler(this.mnuCargarFechasDeCierre_Click);
            // 
            // MainTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainTarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SySTarjetas - Control de cupones de tarjetas de Crédito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuCupones;
        private System.Windows.Forms.ToolStripMenuItem menuCargarCupones;
        private System.Windows.Forms.ToolStripButton btnCargarNuevoCupon;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem menuArchivo;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem comerciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuListarComercios;
        private System.Windows.Forms.ToolStripMenuItem menuListarCupones;
        private System.Windows.Forms.ToolStripMenuItem mnuResumenDeTarjetas;
        private System.Windows.Forms.ToolStripMenuItem mnuTarjetas;
        private System.Windows.Forms.ToolStripMenuItem mnuCargarFechasDeCierre;
    }
}



