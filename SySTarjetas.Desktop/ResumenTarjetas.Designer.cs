namespace SySTarjetas.Desktop
{
    partial class ResumenTarjetas
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.gridCupones = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTarjetas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAnios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMeses = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTitulares = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnActualizarCuponesVerificados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCupones
            // 
            this.gridCupones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCupones.AutoSize = true;
            this.gridCupones.AutoSizeRows = true;
            this.gridCupones.BackColor = System.Drawing.SystemColors.Control;
            this.gridCupones.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCupones.Font = new System.Drawing.Font("Arial", 11.25F);
            this.gridCupones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridCupones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridCupones.Location = new System.Drawing.Point(12, 49);
            // 
            // gridCupones
            // 
            this.gridCupones.MasterTemplate.AllowAddNewRow = false;
            this.gridCupones.MasterTemplate.AllowColumnResize = false;
            this.gridCupones.MasterTemplate.AllowDeleteRow = false;
            this.gridCupones.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.MaxLength = 37;
            gridViewTextBoxColumn1.MaxWidth = 1;
            gridViewTextBoxColumn1.MinWidth = 1;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 1;
            gridViewTextBoxColumn2.FieldName = "CuponId";
            gridViewTextBoxColumn2.HeaderText = "CuponId";
            gridViewTextBoxColumn2.MaxWidth = 1;
            gridViewTextBoxColumn2.MinWidth = 1;
            gridViewTextBoxColumn2.Name = "CuponId";
            gridViewTextBoxColumn2.Width = 1;
            gridViewTextBoxColumn3.FieldName = "FechaCompra";
            gridViewTextBoxColumn3.HeaderText = "Fecha Compra";
            gridViewTextBoxColumn3.MaxWidth = 120;
            gridViewTextBoxColumn3.MinWidth = 100;
            gridViewTextBoxColumn3.Name = "FechaCompra";
            gridViewTextBoxColumn3.Width = 119;
            gridViewTextBoxColumn4.FieldName = "NroComprobante";
            gridViewTextBoxColumn4.HeaderText = "Comprobante";
            gridViewTextBoxColumn4.MaxWidth = 120;
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Name = "NroComprobante";
            gridViewTextBoxColumn4.Width = 120;
            gridViewTextBoxColumn5.FieldName = "RazonSocial";
            gridViewTextBoxColumn5.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn5.HeaderText = "Razón Social";
            gridViewTextBoxColumn5.MaxWidth = 370;
            gridViewTextBoxColumn5.Name = "RazonSocial";
            gridViewTextBoxColumn5.Width = 369;
            gridViewTextBoxColumn6.FieldName = "Cuota";
            gridViewTextBoxColumn6.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn6.HeaderText = "Cuota";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.Name = "Cuota";
            gridViewTextBoxColumn6.Width = 120;
            gridViewCheckBoxColumn1.FieldName = "Verificado";
            gridViewCheckBoxColumn1.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewCheckBoxColumn1.HeaderText = "Verificado";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Verificado";
            gridViewCheckBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn1.Width = 93;
            gridViewTextBoxColumn7.FieldName = "ImporteFormateado";
            gridViewTextBoxColumn7.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn7.HeaderText = "Importe";
            gridViewTextBoxColumn7.MaxWidth = 100;
            gridViewTextBoxColumn7.MinWidth = 80;
            gridViewTextBoxColumn7.Name = "Importe";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 100;
            this.gridCupones.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn7});
            this.gridCupones.MasterTemplate.EnableAlternatingRowColor = true;
            this.gridCupones.MasterTemplate.EnableFiltering = true;
            this.gridCupones.Name = "gridCupones";
            this.gridCupones.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gridCupones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.gridCupones.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gridCupones.Size = new System.Drawing.Size(940, 450);
            this.gridCupones.TabIndex = 3;
            this.gridCupones.Text = "radGridView1";
            this.gridCupones.ValueChanged += new System.EventHandler(this.gridCupones_ValueChanged);
            this.gridCupones.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridCupones_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tarjeta";
            // 
            // cboTarjetas
            // 
            this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjetas.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarjetas.FormattingEnabled = true;
            this.cboTarjetas.Location = new System.Drawing.Point(292, 12);
            this.cboTarjetas.Name = "cboTarjetas";
            this.cboTarjetas.Size = new System.Drawing.Size(375, 25);
            this.cboTarjetas.TabIndex = 0;
            this.cboTarjetas.SelectedIndexChanged += new System.EventHandler(this.cboTarjetas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(672, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Año";
            // 
            // cboAnios
            // 
            this.cboAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnios.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnios.FormattingEnabled = true;
            this.cboAnios.Location = new System.Drawing.Point(706, 12);
            this.cboAnios.Name = "cboAnios";
            this.cboAnios.Size = new System.Drawing.Size(87, 25);
            this.cboAnios.TabIndex = 1;
            this.cboAnios.SelectedIndexChanged += new System.EventHandler(this.cboAnios_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(801, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mes";
            // 
            // cboMeses
            // 
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(837, 12);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(114, 25);
            this.cboMeses.TabIndex = 2;
            this.cboMeses.SelectedIndexChanged += new System.EventHandler(this.cboMeses_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Titular";
            // 
            // cboTitulares
            // 
            this.cboTitulares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitulares.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitulares.FormattingEnabled = true;
            this.cboTitulares.Location = new System.Drawing.Point(60, 12);
            this.cboTitulares.Name = "cboTitulares";
            this.cboTitulares.Size = new System.Drawing.Size(175, 25);
            this.cboTitulares.TabIndex = 16;
            this.cboTitulares.SelectedIndexChanged += new System.EventHandler(this.cboTitulares_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(738, 516);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Total: ";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(812, 515);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 23);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnActualizarCuponesVerificados
            // 
            this.btnActualizarCuponesVerificados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarCuponesVerificados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarCuponesVerificados.Location = new System.Drawing.Point(378, 510);
            this.btnActualizarCuponesVerificados.Name = "btnActualizarCuponesVerificados";
            this.btnActualizarCuponesVerificados.Size = new System.Drawing.Size(289, 34);
            this.btnActualizarCuponesVerificados.TabIndex = 20;
            this.btnActualizarCuponesVerificados.Text = "Actualizar Cupones Verificados";
            this.btnActualizarCuponesVerificados.UseVisualStyleBackColor = true;
            this.btnActualizarCuponesVerificados.Click += new System.EventHandler(this.btnActualizarCuponesVerificados_Click);
            // 
            // ResumenTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 562);
            this.Controls.Add(this.btnActualizarCuponesVerificados);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTitulares);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMeses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboAnios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTarjetas);
            this.Controls.Add(this.gridCupones);
            this.Name = "ResumenTarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Tarjeta Mensual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResumenTarjetas_FormClosing);
            this.Load += new System.EventHandler(this.ResumenTarjetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridCupones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTarjetas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAnios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMeses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTitulares;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnActualizarCuponesVerificados;
    }
}