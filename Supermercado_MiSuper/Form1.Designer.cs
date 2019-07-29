namespace Supermercado_MiSuper
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
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.Panel();
            this.btnpuntodeventa = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblnivel = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.btnproveedor = new System.Windows.Forms.Button();
            this.btnproductos = new System.Windows.Forms.Button();
            this.btncliente = new System.Windows.Forms.Button();
            this.btnempleado = new System.Windows.Forms.Button();
            this.pbxmini = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.barratitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.minimizar = new System.Windows.Forms.PictureBox();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.btnslide = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contenedor = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.barratitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnslide)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.Controls.Add(this.btnpuntodeventa);
            this.menu.Controls.Add(this.pictureBox4);
            this.menu.Controls.Add(this.lblnivel);
            this.menu.Controls.Add(this.lbluser);
            this.menu.Controls.Add(this.btnproveedor);
            this.menu.Controls.Add(this.btnproductos);
            this.menu.Controls.Add(this.btncliente);
            this.menu.Controls.Add(this.btnempleado);
            this.menu.Controls.Add(this.pbxmini);
            this.menu.Controls.Add(this.pictureBox1);
            this.menu.Controls.Add(this.pictureBox3);
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(250, 634);
            this.menu.TabIndex = 0;
            // 
            // btnpuntodeventa
            // 
            this.btnpuntodeventa.FlatAppearance.BorderSize = 0;
            this.btnpuntodeventa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnpuntodeventa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnpuntodeventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpuntodeventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpuntodeventa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnpuntodeventa.Image = global::Supermercado_MiSuper.Properties.Resources.venta;
            this.btnpuntodeventa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpuntodeventa.Location = new System.Drawing.Point(7, 308);
            this.btnpuntodeventa.Name = "btnpuntodeventa";
            this.btnpuntodeventa.Size = new System.Drawing.Size(250, 45);
            this.btnpuntodeventa.TabIndex = 12;
            this.btnpuntodeventa.Text = "Punto de Venta";
            this.btnpuntodeventa.UseVisualStyleBackColor = true;
            this.btnpuntodeventa.Visible = false;
            this.btnpuntodeventa.Click += new System.EventHandler(this.Btnpuntodeventa_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Supermercado_MiSuper.Properties.Resources._54528;
            this.pictureBox4.Location = new System.Drawing.Point(4, 593);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // lblnivel
            // 
            this.lblnivel.AutoSize = true;
            this.lblnivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnivel.ForeColor = System.Drawing.Color.White;
            this.lblnivel.Location = new System.Drawing.Point(85, 546);
            this.lblnivel.Name = "lblnivel";
            this.lblnivel.Size = new System.Drawing.Size(145, 16);
            this.lblnivel.TabIndex = 10;
            this.lblnivel.Text = "Nivel administrativo";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser.ForeColor = System.Drawing.Color.White;
            this.lbluser.Location = new System.Drawing.Point(85, 525);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(62, 16);
            this.lbluser.TabIndex = 8;
            this.lbluser.Text = "Usuario";
            // 
            // btnproveedor
            // 
            this.btnproveedor.FlatAppearance.BorderSize = 0;
            this.btnproveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnproveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnproveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnproveedor.Image = global::Supermercado_MiSuper.Properties.Resources.compras;
            this.btnproveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproveedor.Location = new System.Drawing.Point(7, 330);
            this.btnproveedor.Name = "btnproveedor";
            this.btnproveedor.Size = new System.Drawing.Size(250, 45);
            this.btnproveedor.TabIndex = 5;
            this.btnproveedor.Text = "Proveedor";
            this.btnproveedor.UseVisualStyleBackColor = true;
            this.btnproveedor.Click += new System.EventHandler(this.Btnproveedor_Click);
            // 
            // btnproductos
            // 
            this.btnproductos.FlatAppearance.BorderSize = 0;
            this.btnproductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnproductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnproductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnproductos.Image = global::Supermercado_MiSuper.Properties.Resources.producto;
            this.btnproductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproductos.Location = new System.Drawing.Point(7, 279);
            this.btnproductos.Name = "btnproductos";
            this.btnproductos.Size = new System.Drawing.Size(250, 45);
            this.btnproductos.TabIndex = 4;
            this.btnproductos.Text = "Productos";
            this.btnproductos.UseVisualStyleBackColor = true;
            this.btnproductos.Click += new System.EventHandler(this.Btnproductos_Click);
            // 
            // btncliente
            // 
            this.btncliente.FlatAppearance.BorderSize = 0;
            this.btncliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btncliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btncliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btncliente.Image = global::Supermercado_MiSuper.Properties.Resources.clientes;
            this.btncliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncliente.Location = new System.Drawing.Point(4, 228);
            this.btncliente.Name = "btncliente";
            this.btncliente.Size = new System.Drawing.Size(250, 45);
            this.btncliente.TabIndex = 3;
            this.btncliente.Text = "Cliente";
            this.btncliente.UseVisualStyleBackColor = true;
            this.btncliente.Click += new System.EventHandler(this.Btncliente_Click);
            // 
            // btnempleado
            // 
            this.btnempleado.FlatAppearance.BorderSize = 0;
            this.btnempleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnempleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnempleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnempleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnempleado.Image = global::Supermercado_MiSuper.Properties.Resources.empleados1;
            this.btnempleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnempleado.Location = new System.Drawing.Point(7, 177);
            this.btnempleado.Name = "btnempleado";
            this.btnempleado.Size = new System.Drawing.Size(250, 45);
            this.btnempleado.TabIndex = 2;
            this.btnempleado.Text = "Empleado";
            this.btnempleado.UseVisualStyleBackColor = true;
            this.btnempleado.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbxmini
            // 
            this.pbxmini.Image = global::Supermercado_MiSuper.Properties.Resources.logoPro;
            this.pbxmini.Location = new System.Drawing.Point(-16, 8);
            this.pbxmini.Name = "pbxmini";
            this.pbxmini.Size = new System.Drawing.Size(100, 50);
            this.pbxmini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxmini.TabIndex = 1;
            this.pbxmini.TabStop = false;
            this.pbxmini.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Supermercado_MiSuper.Properties.Resources.logoPro;
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Supermercado_MiSuper.Properties.Resources.boss_man_128;
            this.pictureBox3.Location = new System.Drawing.Point(-16, 512);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // barratitulo
            // 
            this.barratitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.barratitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barratitulo.Controls.Add(this.label1);
            this.barratitulo.Controls.Add(this.minimizar);
            this.barratitulo.Controls.Add(this.cerrar);
            this.barratitulo.Controls.Add(this.btnslide);
            this.barratitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barratitulo.Location = new System.Drawing.Point(250, 0);
            this.barratitulo.Name = "barratitulo";
            this.barratitulo.Size = new System.Drawing.Size(1034, 50);
            this.barratitulo.TabIndex = 1;
            this.barratitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barratitulo_MouseDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(887, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // minimizar
            // 
            this.minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizar.Image = global::Supermercado_MiSuper.Properties.Resources.minimazar;
            this.minimizar.Location = new System.Drawing.Point(978, 5);
            this.minimizar.Name = "minimizar";
            this.minimizar.Size = new System.Drawing.Size(20, 20);
            this.minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizar.TabIndex = 2;
            this.minimizar.TabStop = false;
            this.minimizar.Click += new System.EventHandler(this.minimizar_Click);
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = global::Supermercado_MiSuper.Properties.Resources.cerrar;
            this.cerrar.Location = new System.Drawing.Point(1007, 5);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(20, 20);
            this.cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cerrar.TabIndex = 1;
            this.cerrar.TabStop = false;
            this.cerrar.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnslide
            // 
            this.btnslide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnslide.Image = global::Supermercado_MiSuper.Properties.Resources.menu_movil;
            this.btnslide.Location = new System.Drawing.Point(1, 8);
            this.btnslide.Name = "btnslide";
            this.btnslide.Size = new System.Drawing.Size(35, 35);
            this.btnslide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnslide.TabIndex = 0;
            this.btnslide.TabStop = false;
            this.btnslide.Click += new System.EventHandler(this.btnslide_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contenedor
            // 
            this.contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedor.BackgroundImage = global::Supermercado_MiSuper.Properties.Resources.logoPro;
            this.contenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.contenedor.Location = new System.Drawing.Point(250, 50);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1034, 584);
            this.contenedor.TabIndex = 2;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.Contenedor_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1284, 634);
            this.ControlBox = false;
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.barratitulo);
            this.Controls.Add(this.menu);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.barratitulo.ResumeLayout(false);
            this.barratitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnslide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel barratitulo;
        private System.Windows.Forms.PictureBox btnslide;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbxmini;
        private System.Windows.Forms.PictureBox minimizar;
        private System.Windows.Forms.PictureBox cerrar;
        private System.Windows.Forms.Button btnempleado;
        private System.Windows.Forms.Button btncliente;
        private System.Windows.Forms.Button btnproductos;
        private System.Windows.Forms.Button btnproveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Label lblnivel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnpuntodeventa;
    }
}

