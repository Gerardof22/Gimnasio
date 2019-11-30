namespace Gimnasio
{
    partial class FrmNuevoEditarEjercicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.txtNombreEjercicio = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbEjercicio = new System.Windows.Forms.GroupBox();
            this.gpbRutinas = new System.Windows.Forms.GroupBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.btnQuitarTipoRutina = new System.Windows.Forms.Button();
            this.btnAgregarTipoRutina = new System.Windows.Forms.Button();
            this.gpbDetalleRutinas = new System.Windows.Forms.GroupBox();
            this.gridRutinas = new System.Windows.Forms.DataGridView();
            this.gpbTiposRutinas = new System.Windows.Forms.GroupBox();
            this.gridTiposRutinas = new System.Windows.Forms.DataGridView();
            this.gpbCamposRutina = new System.Windows.Forms.GroupBox();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.txtTiempoDuracion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionCalentamiento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDuracionCalentamiento = new System.Windows.Forms.TextBox();
            this.btnAgregarCalentamiento = new System.Windows.Forms.Button();
            this.txtDescanso = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRitmoCardio = new System.Windows.Forms.TextBox();
            this.btnAgregarCardio = new System.Windows.Forms.Button();
            this.txtDuracionCardio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRepeticiones = new System.Windows.Forms.TextBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.gpbEjercicio.SuspendLayout();
            this.gpbRutinas.SuspendLayout();
            this.gpbDetalleRutinas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRutinas)).BeginInit();
            this.gpbTiposRutinas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTiposRutinas)).BeginInit();
            this.gpbCamposRutina.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ejercicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imagen";
            // 
            // pbxImagen
            // 
            this.pbxImagen.Location = new System.Drawing.Point(74, 157);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(264, 177);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImagen.TabIndex = 2;
            this.pbxImagen.TabStop = false;
            // 
            // txtNombreEjercicio
            // 
            this.txtNombreEjercicio.Location = new System.Drawing.Point(74, 32);
            this.txtNombreEjercicio.Name = "txtNombreEjercicio";
            this.txtNombreEjercicio.Size = new System.Drawing.Size(264, 20);
            this.txtNombreEjercicio.TabIndex = 1;
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(344, 235);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(75, 23);
            this.btnExaminar.TabIndex = 2;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(479, 628);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Gurardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(608, 628);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gpbEjercicio
            // 
            this.gpbEjercicio.Controls.Add(this.pbxImagen);
            this.gpbEjercicio.Controls.Add(this.label2);
            this.gpbEjercicio.Controls.Add(this.txtNombreEjercicio);
            this.gpbEjercicio.Controls.Add(this.btnExaminar);
            this.gpbEjercicio.Controls.Add(this.label1);
            this.gpbEjercicio.Location = new System.Drawing.Point(12, 12);
            this.gpbEjercicio.Name = "gpbEjercicio";
            this.gpbEjercicio.Size = new System.Drawing.Size(428, 340);
            this.gpbEjercicio.TabIndex = 7;
            this.gpbEjercicio.TabStop = false;
            this.gpbEjercicio.Text = "Ejercicio";
            // 
            // gpbRutinas
            // 
            this.gpbRutinas.Controls.Add(this.btnAgregarCliente);
            this.gpbRutinas.Controls.Add(this.btnQuitarTipoRutina);
            this.gpbRutinas.Controls.Add(this.btnAgregarTipoRutina);
            this.gpbRutinas.Controls.Add(this.gpbDetalleRutinas);
            this.gpbRutinas.Controls.Add(this.gpbTiposRutinas);
            this.gpbRutinas.Controls.Add(this.gpbCamposRutina);
            this.gpbRutinas.Controls.Add(this.btnQuitar);
            this.gpbRutinas.Controls.Add(this.btnEditar);
            this.gpbRutinas.Controls.Add(this.label3);
            this.gpbRutinas.Controls.Add(this.cboClientes);
            this.gpbRutinas.Location = new System.Drawing.Point(446, 12);
            this.gpbRutinas.Name = "gpbRutinas";
            this.gpbRutinas.Size = new System.Drawing.Size(912, 583);
            this.gpbRutinas.TabIndex = 8;
            this.gpbRutinas.TabStop = false;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Location = new System.Drawing.Point(256, 29);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCliente.TabIndex = 4;
            this.btnAgregarCliente.Text = "Agregar";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // btnQuitarTipoRutina
            // 
            this.btnQuitarTipoRutina.Location = new System.Drawing.Point(746, 544);
            this.btnQuitarTipoRutina.Name = "btnQuitarTipoRutina";
            this.btnQuitarTipoRutina.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarTipoRutina.TabIndex = 18;
            this.btnQuitarTipoRutina.Text = "Quitar";
            this.btnQuitarTipoRutina.UseVisualStyleBackColor = true;
            this.btnQuitarTipoRutina.Click += new System.EventHandler(this.btnQuitarTipoRutina_Click);
            // 
            // btnAgregarTipoRutina
            // 
            this.btnAgregarTipoRutina.Location = new System.Drawing.Point(665, 544);
            this.btnAgregarTipoRutina.Name = "btnAgregarTipoRutina";
            this.btnAgregarTipoRutina.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTipoRutina.TabIndex = 17;
            this.btnAgregarTipoRutina.Text = "Agregar";
            this.btnAgregarTipoRutina.UseVisualStyleBackColor = true;
            this.btnAgregarTipoRutina.Click += new System.EventHandler(this.btnAgregarTipoRutina_Click);
            // 
            // gpbDetalleRutinas
            // 
            this.gpbDetalleRutinas.Controls.Add(this.gridRutinas);
            this.gpbDetalleRutinas.Location = new System.Drawing.Point(9, 335);
            this.gpbDetalleRutinas.Name = "gpbDetalleRutinas";
            this.gpbDetalleRutinas.Size = new System.Drawing.Size(532, 203);
            this.gpbDetalleRutinas.TabIndex = 34;
            this.gpbDetalleRutinas.TabStop = false;
            this.gpbDetalleRutinas.Text = "Rutinas";
            // 
            // gridRutinas
            // 
            this.gridRutinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRutinas.Location = new System.Drawing.Point(6, 19);
            this.gridRutinas.Name = "gridRutinas";
            this.gridRutinas.Size = new System.Drawing.Size(520, 172);
            this.gridRutinas.TabIndex = 0;
            // 
            // gpbTiposRutinas
            // 
            this.gpbTiposRutinas.Controls.Add(this.gridTiposRutinas);
            this.gpbTiposRutinas.Location = new System.Drawing.Point(547, 335);
            this.gpbTiposRutinas.Name = "gpbTiposRutinas";
            this.gpbTiposRutinas.Size = new System.Drawing.Size(359, 203);
            this.gpbTiposRutinas.TabIndex = 33;
            this.gpbTiposRutinas.TabStop = false;
            this.gpbTiposRutinas.Text = "Tipos de rutinas";
            // 
            // gridTiposRutinas
            // 
            this.gridTiposRutinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTiposRutinas.Location = new System.Drawing.Point(7, 19);
            this.gridTiposRutinas.Name = "gridTiposRutinas";
            this.gridTiposRutinas.Size = new System.Drawing.Size(346, 172);
            this.gridTiposRutinas.TabIndex = 34;
            // 
            // gpbCamposRutina
            // 
            this.gpbCamposRutina.Controls.Add(this.txtKg);
            this.gpbCamposRutina.Controls.Add(this.txtTiempoDuracion);
            this.gpbCamposRutina.Controls.Add(this.label5);
            this.gpbCamposRutina.Controls.Add(this.groupBox2);
            this.gpbCamposRutina.Controls.Add(this.txtDescanso);
            this.gpbCamposRutina.Controls.Add(this.groupBox1);
            this.gpbCamposRutina.Controls.Add(this.label6);
            this.gpbCamposRutina.Controls.Add(this.label7);
            this.gpbCamposRutina.Controls.Add(this.dtpFechaDesde);
            this.gpbCamposRutina.Controls.Add(this.label4);
            this.gpbCamposRutina.Controls.Add(this.btnAgregar);
            this.gpbCamposRutina.Controls.Add(this.label12);
            this.gpbCamposRutina.Controls.Add(this.txtRepeticiones);
            this.gpbCamposRutina.Controls.Add(this.dtpFechaHasta);
            this.gpbCamposRutina.Controls.Add(this.label13);
            this.gpbCamposRutina.Controls.Add(this.txtSeries);
            this.gpbCamposRutina.Controls.Add(this.label14);
            this.gpbCamposRutina.Enabled = false;
            this.gpbCamposRutina.Location = new System.Drawing.Point(9, 56);
            this.gpbCamposRutina.Name = "gpbCamposRutina";
            this.gpbCamposRutina.Size = new System.Drawing.Size(785, 234);
            this.gpbCamposRutina.TabIndex = 32;
            this.gpbCamposRutina.TabStop = false;
            // 
            // txtKg
            // 
            this.txtKg.Location = new System.Drawing.Point(312, 42);
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(100, 20);
            this.txtKg.TabIndex = 9;
            // 
            // txtTiempoDuracion
            // 
            this.txtTiempoDuracion.Location = new System.Drawing.Point(312, 101);
            this.txtTiempoDuracion.Name = "txtTiempoDuracion";
            this.txtTiempoDuracion.Size = new System.Drawing.Size(100, 20);
            this.txtTiempoDuracion.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tiempo de duración";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDescripcionCalentamiento);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDuracionCalentamiento);
            this.groupBox2.Controls.Add(this.btnAgregarCalentamiento);
            this.groupBox2.Location = new System.Drawing.Point(440, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 100);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calentamiento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Descripción";
            // 
            // txtDescripcionCalentamiento
            // 
            this.txtDescripcionCalentamiento.Enabled = false;
            this.txtDescripcionCalentamiento.Location = new System.Drawing.Point(81, 59);
            this.txtDescripcionCalentamiento.Name = "txtDescripcionCalentamiento";
            this.txtDescripcionCalentamiento.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcionCalentamiento.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Duración";
            // 
            // txtDuracionCalentamiento
            // 
            this.txtDuracionCalentamiento.Enabled = false;
            this.txtDuracionCalentamiento.Location = new System.Drawing.Point(81, 21);
            this.txtDuracionCalentamiento.Name = "txtDuracionCalentamiento";
            this.txtDuracionCalentamiento.Size = new System.Drawing.Size(100, 20);
            this.txtDuracionCalentamiento.TabIndex = 25;
            // 
            // btnAgregarCalentamiento
            // 
            this.btnAgregarCalentamiento.Location = new System.Drawing.Point(198, 39);
            this.btnAgregarCalentamiento.Name = "btnAgregarCalentamiento";
            this.btnAgregarCalentamiento.Size = new System.Drawing.Size(26, 23);
            this.btnAgregarCalentamiento.TabIndex = 13;
            this.btnAgregarCalentamiento.Text = "...";
            this.btnAgregarCalentamiento.UseVisualStyleBackColor = true;
            this.btnAgregarCalentamiento.Click += new System.EventHandler(this.btnAgregarCalentamiento_Click);
            // 
            // txtDescanso
            // 
            this.txtDescanso.Location = new System.Drawing.Point(312, 160);
            this.txtDescanso.Name = "txtDescanso";
            this.txtDescanso.Size = new System.Drawing.Size(100, 20);
            this.txtDescanso.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtRitmoCardio);
            this.groupBox1.Controls.Add(this.btnAgregarCardio);
            this.groupBox1.Controls.Add(this.txtDuracionCardio);
            this.groupBox1.Location = new System.Drawing.Point(440, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 88);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cardio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ritmo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Duración";
            // 
            // txtRitmoCardio
            // 
            this.txtRitmoCardio.Enabled = false;
            this.txtRitmoCardio.Location = new System.Drawing.Point(71, 58);
            this.txtRitmoCardio.Name = "txtRitmoCardio";
            this.txtRitmoCardio.Size = new System.Drawing.Size(110, 20);
            this.txtRitmoCardio.TabIndex = 23;
            // 
            // btnAgregarCardio
            // 
            this.btnAgregarCardio.Location = new System.Drawing.Point(198, 37);
            this.btnAgregarCardio.Name = "btnAgregarCardio";
            this.btnAgregarCardio.Size = new System.Drawing.Size(26, 23);
            this.btnAgregarCardio.TabIndex = 12;
            this.btnAgregarCardio.Text = "...";
            this.btnAgregarCardio.UseVisualStyleBackColor = true;
            this.btnAgregarCardio.Click += new System.EventHandler(this.btnAgregarCardio_Click);
            // 
            // txtDuracionCardio
            // 
            this.txtDuracionCardio.Enabled = false;
            this.txtDuracionCardio.Location = new System.Drawing.Point(71, 20);
            this.txtDuracionCardio.Name = "txtDuracionCardio";
            this.txtDuracionCardio.Size = new System.Drawing.Size(110, 20);
            this.txtDuracionCardio.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Descanso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Peso Kg";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(80, 19);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Repeticiones";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(704, 101);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Desde";
            // 
            // txtRepeticiones
            // 
            this.txtRepeticiones.Location = new System.Drawing.Point(80, 193);
            this.txtRepeticiones.Name = "txtRepeticiones";
            this.txtRepeticiones.Size = new System.Drawing.Size(100, 20);
            this.txtRepeticiones.TabIndex = 8;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(80, 72);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Series";
            // 
            // txtSeries
            // 
            this.txtSeries.Location = new System.Drawing.Point(80, 131);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(100, 20);
            this.txtSeries.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Hasta";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(298, 544);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 16;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(217, 544);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cliente";
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(60, 29);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(190, 21);
            this.cboClientes.TabIndex = 3;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // FrmNuevoEditarEjercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 663);
            this.Controls.Add(this.gpbRutinas);
            this.Controls.Add(this.gpbEjercicio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmNuevoEditarEjercicio";
            this.Text = "FrmNuevoEditarEjercicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.gpbEjercicio.ResumeLayout(false);
            this.gpbEjercicio.PerformLayout();
            this.gpbRutinas.ResumeLayout(false);
            this.gpbRutinas.PerformLayout();
            this.gpbDetalleRutinas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRutinas)).EndInit();
            this.gpbTiposRutinas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTiposRutinas)).EndInit();
            this.gpbCamposRutina.ResumeLayout(false);
            this.gpbCamposRutina.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.TextBox txtNombreEjercicio;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gpbEjercicio;
        private System.Windows.Forms.GroupBox gpbRutinas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView gridRutinas;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.GroupBox gpbCamposRutina;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.TextBox txtTiempoDuracion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionCalentamiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDuracionCalentamiento;
        private System.Windows.Forms.Button btnAgregarCalentamiento;
        private System.Windows.Forms.TextBox txtDescanso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRitmoCardio;
        private System.Windows.Forms.Button btnAgregarCardio;
        private System.Windows.Forms.TextBox txtDuracionCardio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRepeticiones;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSeries;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gpbDetalleRutinas;
        private System.Windows.Forms.GroupBox gpbTiposRutinas;
        private System.Windows.Forms.DataGridView gridTiposRutinas;
        private System.Windows.Forms.Button btnQuitarTipoRutina;
        private System.Windows.Forms.Button btnAgregarTipoRutina;
        private System.Windows.Forms.Button btnAgregarCliente;
    }
}