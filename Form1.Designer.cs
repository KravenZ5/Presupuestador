namespace Presupuestador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecioNeto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPorcentajeExtra = new System.Windows.Forms.TextBox();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lbNombreEmpresa = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.lbDatosFiscales = new System.Windows.Forms.Label();
            this.txtDatosFiscales = new System.Windows.Forms.TextBox();
            this.lbContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.btnCargarLogo = new System.Windows.Forms.Button();
            this.lblLogoPath = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inserta Nombre del producto ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(76, 241);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 31);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(341, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inserta descripción del producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Inserta precio del producto";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(15, 64);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(344, 93);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtPrecioNeto
            // 
            this.txtPrecioNeto.Location = new System.Drawing.Point(15, 176);
            this.txtPrecioNeto.Name = "txtPrecioNeto";
            this.txtPrecioNeto.Size = new System.Drawing.Size(157, 20);
            this.txtPrecioNeto.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Inserta porcentaje extra a cobrar";
            // 
            // txtPorcentajeExtra
            // 
            this.txtPorcentajeExtra.Location = new System.Drawing.Point(15, 215);
            this.txtPorcentajeExtra.Name = "txtPorcentajeExtra";
            this.txtPorcentajeExtra.Size = new System.Drawing.Size(157, 20);
            this.txtPorcentajeExtra.TabIndex = 8;
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Location = new System.Drawing.Point(377, 37);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresupuesto.Size = new System.Drawing.Size(677, 364);
            this.dgvPresupuesto.TabIndex = 9;
            this.dgvPresupuesto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresupuesto_CellContentClick);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(76, 395);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(108, 31);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar a excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lbNombreEmpresa
            // 
            this.lbNombreEmpresa.AutoSize = true;
            this.lbNombreEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreEmpresa.Location = new System.Drawing.Point(12, 275);
            this.lbNombreEmpresa.Name = "lbNombreEmpresa";
            this.lbNombreEmpresa.Size = new System.Drawing.Size(134, 13);
            this.lbNombreEmpresa.TabIndex = 11;
            this.lbNombreEmpresa.Text = "Nombre de la Empresa";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(15, 291);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(344, 20);
            this.txtNombreEmpresa.TabIndex = 12;
            // 
            // lbDatosFiscales
            // 
            this.lbDatosFiscales.AutoSize = true;
            this.lbDatosFiscales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatosFiscales.Location = new System.Drawing.Point(12, 314);
            this.lbDatosFiscales.Name = "lbDatosFiscales";
            this.lbDatosFiscales.Size = new System.Drawing.Size(86, 13);
            this.lbDatosFiscales.TabIndex = 13;
            this.lbDatosFiscales.Text = "DatosFiscales";
            // 
            // txtDatosFiscales
            // 
            this.txtDatosFiscales.Location = new System.Drawing.Point(15, 330);
            this.txtDatosFiscales.Name = "txtDatosFiscales";
            this.txtDatosFiscales.Size = new System.Drawing.Size(344, 20);
            this.txtDatosFiscales.TabIndex = 14;
            // 
            // lbContacto
            // 
            this.lbContacto.AutoSize = true;
            this.lbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContacto.Location = new System.Drawing.Point(12, 353);
            this.lbContacto.Name = "lbContacto";
            this.lbContacto.Size = new System.Drawing.Size(58, 13);
            this.lbContacto.TabIndex = 15;
            this.lbContacto.Text = "Contacto";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(15, 369);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(344, 20);
            this.txtContacto.TabIndex = 16;
            // 
            // btnCargarLogo
            // 
            this.btnCargarLogo.Location = new System.Drawing.Point(979, 404);
            this.btnCargarLogo.Name = "btnCargarLogo";
            this.btnCargarLogo.Size = new System.Drawing.Size(75, 31);
            this.btnCargarLogo.TabIndex = 17;
            this.btnCargarLogo.Text = "Cargar Logo";
            this.btnCargarLogo.UseVisualStyleBackColor = true;
            this.btnCargarLogo.Click += new System.EventHandler(this.btnCargarLogo_Click);
            // 
            // lblLogoPath
            // 
            this.lblLogoPath.AutoSize = true;
            this.lblLogoPath.Location = new System.Drawing.Point(374, 404);
            this.lblLogoPath.Name = "lblLogoPath";
            this.lblLogoPath.Size = new System.Drawing.Size(0, 13);
            this.lblLogoPath.TabIndex = 18;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(874, 404);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(87, 13);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "TOTAL: $0.00";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(191, 241);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 31);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Location = new System.Drawing.Point(191, 395);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(108, 31);
            this.btnExportarPDF.TabIndex = 21;
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(979, 9);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 22;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(898, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 437);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblLogoPath);
            this.Controls.Add(this.btnCargarLogo);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.lbContacto);
            this.Controls.Add(this.txtDatosFiscales);
            this.Controls.Add(this.lbDatosFiscales);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.lbNombreEmpresa);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvPresupuesto);
            this.Controls.Add(this.txtPorcentajeExtra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecioNeto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Presupuestador";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecioNeto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPorcentajeExtra;
        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lbNombreEmpresa;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Label lbDatosFiscales;
        private System.Windows.Forms.TextBox txtDatosFiscales;
        private System.Windows.Forms.Label lbContacto;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Button btnCargarLogo;
        private System.Windows.Forms.Label lblLogoPath;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
    }
}

