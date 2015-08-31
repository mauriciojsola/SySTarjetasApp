namespace SySTarjetas.Desktop
{
    partial class EditarFechasCierre
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
            this.label7 = new System.Windows.Forms.Label();
            this.cboTitulares = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.cboTarjetas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMeses = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAnios = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFechaDeCierreSeleccionada = new System.Windows.Forms.Label();
            this.lnkSeleccionarFechaCierre = new System.Windows.Forms.LinkLabel();
            this.lblFechaCierre = new System.Windows.Forms.Label();
            this.lnkCancelar = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Titular";
            // 
            // cboTitulares
            // 
            this.cboTitulares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitulares.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitulares.FormattingEnabled = true;
            this.cboTitulares.Location = new System.Drawing.Point(80, 19);
            this.cboTitulares.Name = "cboTitulares";
            this.cboTitulares.Size = new System.Drawing.Size(241, 25);
            this.cboTitulares.TabIndex = 16;
            this.cboTitulares.SelectedIndexChanged += new System.EventHandler(this.cboTitulares_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tarjeta";
            // 
            // txtFechaCierre
            // 
            this.txtFechaCierre.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaCierre.Location = new System.Drawing.Point(145, 154);
            this.txtFechaCierre.Name = "txtFechaCierre";
            this.txtFechaCierre.Size = new System.Drawing.Size(103, 24);
            this.txtFechaCierre.TabIndex = 18;
            // 
            // cboTarjetas
            // 
            this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjetas.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarjetas.FormattingEnabled = true;
            this.cboTarjetas.Location = new System.Drawing.Point(80, 50);
            this.cboTarjetas.Name = "cboTarjetas";
            this.cboTarjetas.Size = new System.Drawing.Size(410, 25);
            this.cboTarjetas.TabIndex = 17;
            this.cboTarjetas.SelectedIndexChanged += new System.EventHandler(this.cboTarjetas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mes";
            // 
            // cboMeses
            // 
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(237, 89);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(114, 25);
            this.cboMeses.TabIndex = 23;
            this.cboMeses.SelectedIndexChanged += new System.EventHandler(this.cboMeses_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Año";
            // 
            // cboAnios
            // 
            this.cboAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnios.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnios.FormattingEnabled = true;
            this.cboAnios.Location = new System.Drawing.Point(83, 89);
            this.cboAnios.Name = "cboAnios";
            this.cboAnios.Size = new System.Drawing.Size(87, 25);
            this.cboAnios.TabIndex = 22;
            this.cboAnios.SelectedIndexChanged += new System.EventHandler(this.cboAnios_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(32, 206);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFechaDeCierreSeleccionada
            // 
            this.lblFechaDeCierreSeleccionada.AutoSize = true;
            this.lblFechaDeCierreSeleccionada.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeCierreSeleccionada.Location = new System.Drawing.Point(26, 153);
            this.lblFechaDeCierreSeleccionada.Name = "lblFechaDeCierreSeleccionada";
            this.lblFechaDeCierreSeleccionada.Size = new System.Drawing.Size(258, 22);
            this.lblFechaDeCierreSeleccionada.TabIndex = 28;
            this.lblFechaDeCierreSeleccionada.Text = "No hay fecha seleccionada";
            // 
            // lnkSeleccionarFechaCierre
            // 
            this.lnkSeleccionarFechaCierre.AutoSize = true;
            this.lnkSeleccionarFechaCierre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSeleccionarFechaCierre.Location = new System.Drawing.Point(348, 156);
            this.lnkSeleccionarFechaCierre.Name = "lnkSeleccionarFechaCierre";
            this.lnkSeleccionarFechaCierre.Size = new System.Drawing.Size(76, 16);
            this.lnkSeleccionarFechaCierre.TabIndex = 29;
            this.lnkSeleccionarFechaCierre.TabStop = true;
            this.lnkSeleccionarFechaCierre.Text = "Seleccionar";
            this.lnkSeleccionarFechaCierre.Visible = false;
            this.lnkSeleccionarFechaCierre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSeleccionarFechaCierre_LinkClicked);
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.AutoSize = true;
            this.lblFechaCierre.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCierre.Location = new System.Drawing.Point(26, 156);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(113, 17);
            this.lblFechaCierre.TabIndex = 20;
            this.lblFechaCierre.Text = "Fecha de Cierre";
            // 
            // lnkCancelar
            // 
            this.lnkCancelar.AutoSize = true;
            this.lnkCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCancelar.Location = new System.Drawing.Point(424, 156);
            this.lnkCancelar.Name = "lnkCancelar";
            this.lnkCancelar.Size = new System.Drawing.Size(59, 16);
            this.lnkCancelar.TabIndex = 30;
            this.lnkCancelar.TabStop = true;
            this.lnkCancelar.Text = "Cancelar";
            this.lnkCancelar.Visible = false;
            this.lnkCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancelar_LinkClicked);
            // 
            // EditarFechasCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(516, 252);
            this.Controls.Add(this.lnkCancelar);
            this.Controls.Add(this.lnkSeleccionarFechaCierre);
            this.Controls.Add(this.lblFechaDeCierreSeleccionada);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMeses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboAnios);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTitulares);
            this.Controls.Add(this.lblFechaCierre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFechaCierre);
            this.Controls.Add(this.cboTarjetas);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarFechasCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Fechas de Cierre de Tarjetas";
            this.Load += new System.EventHandler(this.EditarFechasCierre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTitulares;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFechaCierre;
        private System.Windows.Forms.ComboBox cboTarjetas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMeses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAnios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFechaDeCierreSeleccionada;
        private System.Windows.Forms.LinkLabel lnkSeleccionarFechaCierre;
        private System.Windows.Forms.Label lblFechaCierre;
        private System.Windows.Forms.LinkLabel lnkCancelar;
    }
}