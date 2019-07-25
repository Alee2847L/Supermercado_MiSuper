namespace Supermercado_MiSuper.formularios
{
    partial class Compras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbdatos = new System.Windows.Forms.GroupBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtide = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbdetalles = new System.Windows.Forms.GroupBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.txtnombreprod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sUPERMERCADODataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sUPERMERCADODataSet = new Supermercado_MiSuper.SUPERMERCADODataSet();
            this.productoTableAdapter = new Supermercado_MiSuper.SUPERMERCADODataSetTableAdapters.ProductoTableAdapter();
            this.dgvproductos = new System.Windows.Forms.DataGridView();
            this.dgvfactura = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtidemp = new System.Windows.Forms.TextBox();
            this.gbdatos.SuspendLayout();
            this.gbdetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUPERMERCADODataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUPERMERCADODataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfactura)).BeginInit();
            this.SuspendLayout();
            // 
            // gbdatos
            // 
            this.gbdatos.Controls.Add(this.btnbuscar);
            this.gbdatos.Controls.Add(this.txtnombre);
            this.gbdatos.Controls.Add(this.txtide);
            this.gbdatos.Controls.Add(this.label2);
            this.gbdatos.Controls.Add(this.label1);
            this.gbdatos.Location = new System.Drawing.Point(12, 12);
            this.gbdatos.Name = "gbdatos";
            this.gbdatos.Size = new System.Drawing.Size(299, 93);
            this.gbdatos.TabIndex = 0;
            this.gbdatos.TabStop = false;
            this.gbdatos.Text = "Datos del Cliente";
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(219, 12);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 1;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.Btnbuscar_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(124, 59);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(100, 20);
            this.txtnombre.TabIndex = 3;
            // 
            // txtide
            // 
            this.txtide.Enabled = false;
            this.txtide.Location = new System.Drawing.Point(124, 23);
            this.txtide.Name = "txtide";
            this.txtide.Size = new System.Drawing.Size(43, 20);
            this.txtide.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id del cliente";
            // 
            // gbdetalles
            // 
            this.gbdetalles.Controls.Add(this.txttotal);
            this.gbdetalles.Controls.Add(this.label11);
            this.gbdetalles.Controls.Add(this.btnagregar);
            this.gbdetalles.Controls.Add(this.txtnombreprod);
            this.gbdetalles.Controls.Add(this.label8);
            this.gbdetalles.Controls.Add(this.txtprecio);
            this.gbdetalles.Controls.Add(this.txtcantidad);
            this.gbdetalles.Controls.Add(this.txtcodigo);
            this.gbdetalles.Controls.Add(this.label5);
            this.gbdetalles.Controls.Add(this.label4);
            this.gbdetalles.Controls.Add(this.label3);
            this.gbdetalles.Location = new System.Drawing.Point(48, 121);
            this.gbdetalles.Name = "gbdetalles";
            this.gbdetalles.Size = new System.Drawing.Size(211, 260);
            this.gbdetalles.TabIndex = 1;
            this.gbdetalles.TabStop = false;
            this.gbdetalles.Text = "Producto";
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(99, 181);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(78, 20);
            this.txttotal.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Total";
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(23, 207);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(143, 39);
            this.btnagregar.TabIndex = 6;
            this.btnagregar.Text = "Agregar  a Factura";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.Btnagregar_Click);
            // 
            // txtnombreprod
            // 
            this.txtnombreprod.Location = new System.Drawing.Point(102, 68);
            this.txtnombreprod.Name = "txtnombreprod";
            this.txtnombreprod.Size = new System.Drawing.Size(78, 20);
            this.txtnombreprod.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Nombre Producto";
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(99, 138);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(78, 20);
            this.txtprecio.TabIndex = 7;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(99, 99);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(78, 20);
            this.txtcantidad.TabIndex = 6;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(102, 36);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(78, 20);
            this.txtcodigo.TabIndex = 1;
            this.txtcodigo.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.txtcodigo.Enter += new System.EventHandler(this.Txtcodigo_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Precio unidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo Producto";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataMember = "Producto";
            this.productoBindingSource.DataSource = this.sUPERMERCADODataSetBindingSource;
            // 
            // sUPERMERCADODataSetBindingSource
            // 
            this.sUPERMERCADODataSetBindingSource.DataSource = this.sUPERMERCADODataSet;
            this.sUPERMERCADODataSetBindingSource.Position = 0;
            // 
            // sUPERMERCADODataSet
            // 
            this.sUPERMERCADODataSet.DataSetName = "SUPERMERCADODataSet";
            this.sUPERMERCADODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // dgvproductos
            // 
            this.dgvproductos.AllowUserToAddRows = false;
            this.dgvproductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvproductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproductos.Location = new System.Drawing.Point(317, 71);
            this.dgvproductos.Name = "dgvproductos";
            this.dgvproductos.RowHeadersVisible = false;
            this.dgvproductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvproductos.Size = new System.Drawing.Size(610, 161);
            this.dgvproductos.TabIndex = 4;
            this.dgvproductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgvproductos_CellClick);
            this.dgvproductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgvproductos_CellDoubleClick);
            this.dgvproductos.SelectionChanged += new System.EventHandler(this.Dgvproductos_SelectionChanged);
            this.dgvproductos.DoubleClick += new System.EventHandler(this.Dgvproductos_DoubleClick);
            // 
            // dgvfactura
            // 
            this.dgvfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfactura.Location = new System.Drawing.Point(320, 259);
            this.dgvfactura.Name = "dgvfactura";
            this.dgvfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfactura.Size = new System.Drawing.Size(607, 162);
            this.dgvfactura.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(319, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Detalles Factura";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(319, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "Detalles";
            // 
            // txtidemp
            // 
            this.txtidemp.Location = new System.Drawing.Point(352, 12);
            this.txtidemp.Name = "txtidemp";
            this.txtidemp.Size = new System.Drawing.Size(100, 20);
            this.txtidemp.TabIndex = 8;
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.txtidemp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvfactura);
            this.Controls.Add(this.dgvproductos);
            this.Controls.Add(this.gbdetalles);
            this.Controls.Add(this.gbdatos);
            this.Name = "Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Compras_Load);
            this.gbdatos.ResumeLayout(false);
            this.gbdatos.PerformLayout();
            this.gbdetalles.ResumeLayout(false);
            this.gbdetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUPERMERCADODataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUPERMERCADODataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbuscar;
        public System.Windows.Forms.TextBox txtnombre;
        public System.Windows.Forms.TextBox txtide;
        public System.Windows.Forms.GroupBox gbdatos;
        private System.Windows.Forms.GroupBox gbdetalles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource sUPERMERCADODataSetBindingSource;
        private SUPERMERCADODataSet sUPERMERCADODataSet;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private SUPERMERCADODataSetTableAdapters.ProductoTableAdapter productoTableAdapter;
        private System.Windows.Forms.DataGridView dgvproductos;
        private System.Windows.Forms.TextBox txtnombreprod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvfactura;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtidemp;
    }
}