namespace SySTarjetas.Desktop
{
    partial class ListarComercios
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
            this.gridComercios = new Telerik.WinControls.UI.RadGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridComercios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComercios.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gridComercios
            // 
            this.gridComercios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridComercios.AutoSize = true;
            this.gridComercios.AutoSizeRows = true;
            this.gridComercios.BackColor = System.Drawing.SystemColors.Control;
            this.gridComercios.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridComercios.Font = new System.Drawing.Font("Arial", 11.25F);
            this.gridComercios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridComercios.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridComercios.Location = new System.Drawing.Point(12, 28);
            // 
            // gridComercios
            // 
            this.gridComercios.MasterTemplate.AllowAddNewRow = false;
            this.gridComercios.MasterTemplate.AllowColumnResize = false;
            this.gridComercios.MasterTemplate.AllowDeleteRow = false;
            this.gridComercios.MasterTemplate.AllowEditRow = false;
            this.gridComercios.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.MaxLength = 7;
            gridViewTextBoxColumn1.MinWidth = 25;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 111;
            gridViewTextBoxColumn2.FieldName = "RazonSocial";
            gridViewTextBoxColumn2.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn2.HeaderText = "Razón Social";
            gridViewTextBoxColumn2.Name = "RazonSocial";
            gridViewTextBoxColumn2.Width = 325;
            gridViewTextBoxColumn3.FieldName = "CUIT";
            gridViewTextBoxColumn3.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn3.HeaderText = "CUIT";
            gridViewTextBoxColumn3.MaxWidth = 120;
            gridViewTextBoxColumn3.Name = "CUIT";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.FieldName = "Direccion";
            gridViewTextBoxColumn4.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn4.HeaderText = "Dirección";
            gridViewTextBoxColumn4.Name = "Direccion";
            gridViewTextBoxColumn4.Width = 365;
            this.gridComercios.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gridComercios.MasterTemplate.EnableAlternatingRowColor = true;
            this.gridComercios.MasterTemplate.EnableFiltering = true;
            this.gridComercios.Name = "gridComercios";
            this.gridComercios.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gridComercios.ReadOnly = true;
            this.gridComercios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.gridComercios.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gridComercios.Size = new System.Drawing.Size(940, 471);
            this.gridComercios.TabIndex = 0;
            this.gridComercios.Text = "radGridView1";
            this.gridComercios.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridComercios_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 515);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
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
            this.btnEdit.TabIndex = 2;
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
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ListarComercios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 562);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridComercios);
            this.Name = "ListarComercios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listar Comercios";
            this.Load += new System.EventHandler(this.ListarComercios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridComercios.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComercios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridComercios;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}