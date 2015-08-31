using SySTarjetas.Desktop.Controls;

namespace SySTarjetas.Desktop
{
    partial class EditarCupones
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
            this.cboTarjetas = new System.Windows.Forms.ComboBox();
            this.txtFechaCupon = new System.Windows.Forms.DateTimePicker();
            this.cboComercios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Cuotas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cboTitulares = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCuotas = new SySTarjetas.Desktop.Controls.CustomTextBox();
            this.txtNroCupon = new SySTarjetas.Desktop.Controls.CustomTextBox();
            this.txtImporte = new SySTarjetas.Desktop.Controls.CustomTextBox();
            this.txtObservaciones = new SySTarjetas.Desktop.Controls.CustomTextBox();
            this.SuspendLayout();
            // 
            // cboTarjetas
            // 
            this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjetas.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarjetas.FormattingEnabled = true;
            this.cboTarjetas.Location = new System.Drawing.Point(87, 44);
            this.cboTarjetas.Name = "cboTarjetas";
            this.cboTarjetas.Size = new System.Drawing.Size(410, 25);
            this.cboTarjetas.TabIndex = 1;
            this.cboTarjetas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTarjetas_KeyUp);
            // 
            // txtFechaCupon
            // 
            this.txtFechaCupon.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCupon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaCupon.Location = new System.Drawing.Point(22, 102);
            this.txtFechaCupon.Name = "txtFechaCupon";
            this.txtFechaCupon.Size = new System.Drawing.Size(103, 24);
            this.txtFechaCupon.TabIndex = 2;
            this.txtFechaCupon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFechaCupon_KeyUp);
            // 
            // cboComercios
            // 
            this.cboComercios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComercios.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboComercios.FormattingEnabled = true;
            this.cboComercios.Location = new System.Drawing.Point(144, 101);
            this.cboComercios.Name = "cboComercios";
            this.cboComercios.Size = new System.Drawing.Size(353, 25);
            this.cboComercios.TabIndex = 3;
            this.cboComercios.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboComercios_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tarjeta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Comercio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nro Cupón";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(171, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Importe";
            // 
            // Cuotas
            // 
            this.Cuotas.AutoSize = true;
            this.Cuotas.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cuotas.Location = new System.Drawing.Point(320, 140);
            this.Cuotas.Name = "Cuotas";
            this.Cuotas.Size = new System.Drawing.Size(55, 17);
            this.Cuotas.TabIndex = 11;
            this.Cuotas.Text = "Cuotas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Observaciones";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(22, 299);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cboTitulares
            // 
            this.cboTitulares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitulares.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitulares.FormattingEnabled = true;
            this.cboTitulares.Location = new System.Drawing.Point(87, 13);
            this.cboTitulares.Name = "cboTitulares";
            this.cboTitulares.Size = new System.Drawing.Size(241, 25);
            this.cboTitulares.TabIndex = 0;
            this.cboTitulares.SelectedIndexChanged += new System.EventHandler(this.cboTitulares_SelectedIndexChanged);
            this.cboTitulares.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTitulares_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Titular";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(103, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCuotas
            // 
            this.txtCuotas.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotas.Location = new System.Drawing.Point(323, 160);
            this.txtCuotas.MaxLength = 2;
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(100, 24);
            this.txtCuotas.TabIndex = 6;
            this.txtCuotas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCuotas_KeyUp);
            // 
            // txtNroCupon
            // 
            this.txtNroCupon.BackColor = System.Drawing.Color.White;
            this.txtNroCupon.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCupon.Location = new System.Drawing.Point(25, 160);
            this.txtNroCupon.MaxLength = 10;
            this.txtNroCupon.Name = "txtNroCupon";
            this.txtNroCupon.Size = new System.Drawing.Size(100, 24);
            this.txtNroCupon.TabIndex = 4;
            this.txtNroCupon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNroCupon_KeyUp);
            // 
            // txtImporte
            // 
            this.txtImporte.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(174, 159);
            this.txtImporte.MaxLength = 10;
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 24);
            this.txtImporte.TabIndex = 5;
            this.txtImporte.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtImporte_KeyUp);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(22, 219);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(475, 62);
            this.txtObservaciones.TabIndex = 7;
            // 
            // EditarCupones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 335);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTitulares);
            this.Controls.Add(this.txtCuotas);
            this.Controls.Add(this.txtNroCupon);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.Cuotas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboComercios);
            this.Controls.Add(this.txtFechaCupon);
            this.Controls.Add(this.cboTarjetas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarCupones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Cupones";
            this.Load += new System.EventHandler(this.EditarCupones_Load);
            this.Resize += new System.EventHandler(this.EditarCupones_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTarjetas;
        private System.Windows.Forms.DateTimePicker txtFechaCupon;
        private System.Windows.Forms.ComboBox cboComercios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Cuotas;
        private CustomTextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGrabar;
        private CustomTextBox txtImporte;
        private CustomTextBox txtNroCupon;
        private CustomTextBox txtCuotas;
        private System.Windows.Forms.ComboBox cboTitulares;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
    }
}