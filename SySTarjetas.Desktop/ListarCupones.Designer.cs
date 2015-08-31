namespace SySTarjetas.Desktop
{
    partial class ListarCupones
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
            this.gridCupones = new Telerik.WinControls.UI.RadGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.chkTodosLosCupones = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones.MasterTemplate)).BeginInit();
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
            this.gridCupones.MasterTemplate.AllowEditRow = false;
            this.gridCupones.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.MaxLength = 7;
            gridViewTextBoxColumn1.MaxWidth = 1;
            gridViewTextBoxColumn1.MinWidth = 1;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 1;
            gridViewTextBoxColumn2.FieldName = "FechaCompra";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Fecha Compra";
            gridViewTextBoxColumn2.MaxWidth = 130;
            gridViewTextBoxColumn2.MinWidth = 120;
            gridViewTextBoxColumn2.Name = "FechaCompra";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 122;
            gridViewTextBoxColumn3.FieldName = "NumeroCupon";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Número Cupón";
            gridViewTextBoxColumn3.MaxWidth = 150;
            gridViewTextBoxColumn3.MinWidth = 130;
            gridViewTextBoxColumn3.Name = "NumeroCupon";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 145;
            gridViewTextBoxColumn4.FieldName = "RazonSocial";
            gridViewTextBoxColumn4.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Razón Social";
            gridViewTextBoxColumn4.Name = "RazonSocial";
            gridViewTextBoxColumn4.Width = 329;
            gridViewTextBoxColumn5.FieldName = "Cuotas";
            gridViewTextBoxColumn5.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Cuotas";
            gridViewTextBoxColumn5.MaxWidth = 120;
            gridViewTextBoxColumn5.Name = "Cuotas";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 102;
            gridViewTextBoxColumn6.FieldName = "ImporteFormateado";
            gridViewTextBoxColumn6.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Importe";
            gridViewTextBoxColumn6.MinWidth = 0;
            gridViewTextBoxColumn6.Name = "Importe";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 224;
            this.gridCupones.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gridCupones.MasterTemplate.EnableAlternatingRowColor = true;
            this.gridCupones.MasterTemplate.EnableFiltering = true;
            this.gridCupones.Name = "gridCupones";
            this.gridCupones.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gridCupones.ReadOnly = true;
            this.gridCupones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.gridCupones.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gridCupones.Size = new System.Drawing.Size(940, 450);
            this.gridCupones.TabIndex = 3;
            this.gridCupones.Text = "radGridView1";
            this.gridCupones.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridCupones_CellDoubleClick);
            this.gridCupones.Click += new System.EventHandler(this.gridCupones_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 515);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Nuevo";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(94, 515);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(175, 515);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tarjeta";
            // 
            // cboTarjetas
            // 
            this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjetas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarjetas.FormattingEnabled = true;
            this.cboTarjetas.Location = new System.Drawing.Point(271, 12);
            this.cboTarjetas.Name = "cboTarjetas";
            this.cboTarjetas.Size = new System.Drawing.Size(338, 24);
            this.cboTarjetas.TabIndex = 0;
            this.cboTarjetas.SelectedIndexChanged += new System.EventHandler(this.cboTarjetas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(612, 15);
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
            this.cboAnios.Location = new System.Drawing.Point(646, 12);
            this.cboAnios.Name = "cboAnios";
            this.cboAnios.Size = new System.Drawing.Size(87, 25);
            this.cboAnios.TabIndex = 1;
            this.cboAnios.SelectedIndexChanged += new System.EventHandler(this.cboAnios_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(741, 15);
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
            this.cboMeses.Location = new System.Drawing.Point(777, 12);
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
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Titular";
            // 
            // cboTitulares
            // 
            this.cboTitulares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTitulares.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitulares.FormattingEnabled = true;
            this.cboTitulares.Location = new System.Drawing.Point(60, 12);
            this.cboTitulares.Name = "cboTitulares";
            this.cboTitulares.Size = new System.Drawing.Size(154, 24);
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
            this.label4.Size = new System.Drawing.Size(69, 22);
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
            // chkTodosLosCupones
            // 
            this.chkTodosLosCupones.AutoSize = true;
            this.chkTodosLosCupones.Location = new System.Drawing.Point(899, 17);
            this.chkTodosLosCupones.Name = "chkTodosLosCupones";
            this.chkTodosLosCupones.Size = new System.Drawing.Size(56, 17);
            this.chkTodosLosCupones.TabIndex = 20;
            this.chkTodosLosCupones.Text = "Todos";
            this.chkTodosLosCupones.UseVisualStyleBackColor = true;
            this.chkTodosLosCupones.CheckedChanged += new System.EventHandler(this.chkTodosLosCupones_CheckedChanged);
            // 
            // ListarCupones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 562);
            this.Controls.Add(this.chkTodosLosCupones);
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
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridCupones);
            this.Name = "ListarCupones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Cupones";
            this.Load += new System.EventHandler(this.ListarCupones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridCupones;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
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
        private System.Windows.Forms.CheckBox chkTodosLosCupones;
    }
}