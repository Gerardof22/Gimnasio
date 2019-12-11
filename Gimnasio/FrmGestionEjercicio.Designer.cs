namespace Gimnasio
{
    partial class FrmGestionEjercicio
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pxbImagen = new System.Windows.Forms.PictureBox();
            this.gpbRutinas = new System.Windows.Forms.GroupBox();
            this.gridRutina = new System.Windows.Forms.DataGridView();
            this.gpbEjercicio = new System.Windows.Forms.GroupBox();
            this.gridEjercicio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pxbImagen)).BeginInit();
            this.gpbRutinas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRutina)).BeginInit();
            this.gpbEjercicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEjercicio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.Location = new System.Drawing.Point(668, 403);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEliminar.Location = new System.Drawing.Point(587, 403);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditar.Location = new System.Drawing.Point(505, 403);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(278, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(66, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(206, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Buscar";
            // 
            // pxbImagen
            // 
            this.pxbImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pxbImagen.Location = new System.Drawing.Point(1002, 44);
            this.pxbImagen.Name = "pxbImagen";
            this.pxbImagen.Size = new System.Drawing.Size(312, 342);
            this.pxbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pxbImagen.TabIndex = 33;
            this.pxbImagen.TabStop = false;
            // 
            // gpbRutinas
            // 
            this.gpbRutinas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbRutinas.Controls.Add(this.gridRutina);
            this.gpbRutinas.Location = new System.Drawing.Point(249, 44);
            this.gpbRutinas.Name = "gpbRutinas";
            this.gpbRutinas.Size = new System.Drawing.Size(747, 342);
            this.gpbRutinas.TabIndex = 34;
            this.gpbRutinas.TabStop = false;
            this.gpbRutinas.Text = "Rutinas";
            // 
            // gridRutina
            // 
            this.gridRutina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRutina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRutina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRutina.Location = new System.Drawing.Point(6, 19);
            this.gridRutina.Name = "gridRutina";
            this.gridRutina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRutina.Size = new System.Drawing.Size(735, 317);
            this.gridRutina.TabIndex = 4;
            // 
            // gpbEjercicio
            // 
            this.gpbEjercicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbEjercicio.Controls.Add(this.gridEjercicio);
            this.gpbEjercicio.Location = new System.Drawing.Point(14, 44);
            this.gpbEjercicio.Name = "gpbEjercicio";
            this.gpbEjercicio.Size = new System.Drawing.Size(229, 342);
            this.gpbEjercicio.TabIndex = 35;
            this.gpbEjercicio.TabStop = false;
            this.gpbEjercicio.Text = "Ejercicios";
            // 
            // gridEjercicio
            // 
            this.gridEjercicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridEjercicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEjercicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEjercicio.Location = new System.Drawing.Point(6, 19);
            this.gridEjercicio.Name = "gridEjercicio";
            this.gridEjercicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEjercicio.Size = new System.Drawing.Size(217, 317);
            this.gridEjercicio.TabIndex = 3;
            this.gridEjercicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEjercicio_CellClick);
            this.gridEjercicio.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEjercicio_RowEnter);
            this.gridEjercicio.SelectionChanged += new System.EventHandler(this.gridEjercicio_SelectionChanged);
            // 
            // FrmGestionEjercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 438);
            this.Controls.Add(this.gpbEjercicio);
            this.Controls.Add(this.gpbRutinas);
            this.Controls.Add(this.pxbImagen);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Name = "FrmGestionEjercicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGestionEjercicio";
            ((System.ComponentModel.ISupportInitialize)(this.pxbImagen)).EndInit();
            this.gpbRutinas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRutina)).EndInit();
            this.gpbEjercicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEjercicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pxbImagen;
        private System.Windows.Forms.GroupBox gpbRutinas;
        private System.Windows.Forms.DataGridView gridRutina;
        private System.Windows.Forms.GroupBox gpbEjercicio;
        private System.Windows.Forms.DataGridView gridEjercicio;
    }
}