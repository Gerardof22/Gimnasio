namespace Gimnasio
{
    partial class FrmNuevoEditarCliente
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
            this.gpbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarLocalidad = new System.Windows.Forms.Button();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtnMujer = new System.Windows.Forms.RadioButton();
            this.rbtnHombre = new System.Windows.Forms.RadioButton();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbContactos = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.gridTelefonos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gpbDomicilio = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarDomicilio = new System.Windows.Forms.Button();
            this.txtNumCalle = new System.Windows.Forms.TextBox();
            this.txtNombreCalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbObservaciones = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObjetivos = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLecturaCorporal = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbDatosPersonales.SuspendLayout();
            this.gpbContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTelefonos)).BeginInit();
            this.gpbDomicilio.SuspendLayout();
            this.gpbObservaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDatosPersonales
            // 
            this.gpbDatosPersonales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDatosPersonales.Controls.Add(this.dtpFechaNacimiento);
            this.gpbDatosPersonales.Controls.Add(this.label13);
            this.gpbDatosPersonales.Controls.Add(this.dtpFechaIngreso);
            this.gpbDatosPersonales.Controls.Add(this.label7);
            this.gpbDatosPersonales.Controls.Add(this.btnAgregarLocalidad);
            this.gpbDatosPersonales.Controls.Add(this.cboLocalidad);
            this.gpbDatosPersonales.Controls.Add(this.label9);
            this.gpbDatosPersonales.Controls.Add(this.rbtnMujer);
            this.gpbDatosPersonales.Controls.Add(this.rbtnHombre);
            this.gpbDatosPersonales.Controls.Add(this.txtEdad);
            this.gpbDatosPersonales.Controls.Add(this.label3);
            this.gpbDatosPersonales.Controls.Add(this.label4);
            this.gpbDatosPersonales.Controls.Add(this.txtApellido);
            this.gpbDatosPersonales.Controls.Add(this.label2);
            this.gpbDatosPersonales.Controls.Add(this.txtNombre);
            this.gpbDatosPersonales.Controls.Add(this.label1);
            this.gpbDatosPersonales.Location = new System.Drawing.Point(12, 12);
            this.gpbDatosPersonales.Name = "gpbDatosPersonales";
            this.gpbDatosPersonales.Size = new System.Drawing.Size(872, 94);
            this.gpbDatosPersonales.TabIndex = 0;
            this.gpbDatosPersonales.TabStop = false;
            this.gpbDatosPersonales.Text = "Datos personales";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(645, 19);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaNacimiento.TabIndex = 3;
            this.dtpFechaNacimiento.ValueChanged += new System.EventHandler(this.dtpFechaNacimiento_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(544, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Fecha nacimiento";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(645, 58);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaIngreso.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(593, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Ingreso";
            // 
            // btnAgregarLocalidad
            // 
            this.btnAgregarLocalidad.Location = new System.Drawing.Point(499, 57);
            this.btnAgregarLocalidad.Name = "btnAgregarLocalidad";
            this.btnAgregarLocalidad.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarLocalidad.TabIndex = 7;
            this.btnAgregarLocalidad.Text = "Agregar";
            this.btnAgregarLocalidad.UseVisualStyleBackColor = true;
            this.btnAgregarLocalidad.Click += new System.EventHandler(this.btnAgregarLocalidad_Click);
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(331, 58);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(162, 21);
            this.cboLocalidad.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Localidad";
            // 
            // rbtnMujer
            // 
            this.rbtnMujer.AutoSize = true;
            this.rbtnMujer.Location = new System.Drawing.Point(207, 65);
            this.rbtnMujer.Name = "rbtnMujer";
            this.rbtnMujer.Size = new System.Drawing.Size(51, 17);
            this.rbtnMujer.TabIndex = 5;
            this.rbtnMujer.Text = "Mujer";
            this.rbtnMujer.UseVisualStyleBackColor = true;
            // 
            // rbtnHombre
            // 
            this.rbtnHombre.AutoSize = true;
            this.rbtnHombre.Checked = true;
            this.rbtnHombre.Location = new System.Drawing.Point(58, 63);
            this.rbtnHombre.Name = "rbtnHombre";
            this.rbtnHombre.Size = new System.Drawing.Size(62, 17);
            this.rbtnHombre.TabIndex = 4;
            this.rbtnHombre.TabStop = true;
            this.rbtnHombre.Text = "Hombre";
            this.rbtnHombre.UseVisualStyleBackColor = true;
            // 
            // txtEdad
            // 
            this.txtEdad.Enabled = false;
            this.txtEdad.Location = new System.Drawing.Point(803, 20);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(63, 20);
            this.txtEdad.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(766, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Edad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Género";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(331, 19);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(58, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // gpbContactos
            // 
            this.gpbContactos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbContactos.Controls.Add(this.btnQuitar);
            this.gpbContactos.Controls.Add(this.gridTelefonos);
            this.gpbContactos.Controls.Add(this.btnAgregar);
            this.gpbContactos.Location = new System.Drawing.Point(12, 195);
            this.gpbContactos.Name = "gpbContactos";
            this.gpbContactos.Size = new System.Drawing.Size(531, 118);
            this.gpbContactos.TabIndex = 2;
            this.gpbContactos.TabStop = false;
            this.gpbContactos.Text = "Contactos";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(442, 71);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // gridTelefonos
            // 
            this.gridTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTelefonos.Location = new System.Drawing.Point(11, 19);
            this.gridTelefonos.Name = "gridTelefonos";
            this.gridTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTelefonos.Size = new System.Drawing.Size(421, 93);
            this.gridTelefonos.TabIndex = 20;
            this.gridTelefonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTelefonos_CellContentClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(442, 42);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gpbDomicilio
            // 
            this.gpbDomicilio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDomicilio.Controls.Add(this.btnSeleccionarDomicilio);
            this.gpbDomicilio.Controls.Add(this.txtNumCalle);
            this.gpbDomicilio.Controls.Add(this.txtNombreCalle);
            this.gpbDomicilio.Controls.Add(this.label5);
            this.gpbDomicilio.Controls.Add(this.label6);
            this.gpbDomicilio.Location = new System.Drawing.Point(12, 112);
            this.gpbDomicilio.Name = "gpbDomicilio";
            this.gpbDomicilio.Size = new System.Drawing.Size(548, 77);
            this.gpbDomicilio.TabIndex = 3;
            this.gpbDomicilio.TabStop = false;
            this.gpbDomicilio.Text = "Domicilio";
            // 
            // btnSeleccionarDomicilio
            // 
            this.btnSeleccionarDomicilio.Location = new System.Drawing.Point(438, 38);
            this.btnSeleccionarDomicilio.Name = "btnSeleccionarDomicilio";
            this.btnSeleccionarDomicilio.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarDomicilio.TabIndex = 9;
            this.btnSeleccionarDomicilio.Text = "Seleccionar domicilio";
            this.btnSeleccionarDomicilio.UseVisualStyleBackColor = true;
            this.btnSeleccionarDomicilio.Click += new System.EventHandler(this.btnSeleccionarDomicilio_Click);
            // 
            // txtNumCalle
            // 
            this.txtNumCalle.Enabled = false;
            this.txtNumCalle.Location = new System.Drawing.Point(344, 38);
            this.txtNumCalle.Name = "txtNumCalle";
            this.txtNumCalle.Size = new System.Drawing.Size(88, 20);
            this.txtNumCalle.TabIndex = 13;
            // 
            // txtNombreCalle
            // 
            this.txtNombreCalle.Enabled = false;
            this.txtNombreCalle.Location = new System.Drawing.Point(44, 38);
            this.txtNombreCalle.Name = "txtNombreCalle";
            this.txtNombreCalle.Size = new System.Drawing.Size(225, 20);
            this.txtNombreCalle.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Número";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Calle";
            // 
            // gpbObservaciones
            // 
            this.gpbObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbObservaciones.Controls.Add(this.label14);
            this.gpbObservaciones.Controls.Add(this.txtObjetivos);
            this.gpbObservaciones.Controls.Add(this.txtPeso);
            this.gpbObservaciones.Controls.Add(this.label12);
            this.gpbObservaciones.Controls.Add(this.label10);
            this.gpbObservaciones.Controls.Add(this.label11);
            this.gpbObservaciones.Controls.Add(this.txtLecturaCorporal);
            this.gpbObservaciones.Location = new System.Drawing.Point(12, 319);
            this.gpbObservaciones.Name = "gpbObservaciones";
            this.gpbObservaciones.Size = new System.Drawing.Size(866, 174);
            this.gpbObservaciones.TabIndex = 4;
            this.gpbObservaciones.TabStop = false;
            this.gpbObservaciones.Text = "Observaciones";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(137, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Kg";
            // 
            // txtObjetivos
            // 
            this.txtObjetivos.Location = new System.Drawing.Point(65, 22);
            this.txtObjetivos.Multiline = true;
            this.txtObjetivos.Name = "txtObjetivos";
            this.txtObjetivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjetivos.Size = new System.Drawing.Size(282, 82);
            this.txtObjetivos.TabIndex = 12;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(65, 134);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(66, 20);
            this.txtPeso.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Peso";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Objetivos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(359, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Lectura corporal";
            // 
            // txtLecturaCorporal
            // 
            this.txtLecturaCorporal.Location = new System.Drawing.Point(448, 22);
            this.txtLecturaCorporal.Multiline = true;
            this.txtLecturaCorporal.Name = "txtLecturaCorporal";
            this.txtLecturaCorporal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLecturaCorporal.Size = new System.Drawing.Size(412, 146);
            this.txtLecturaCorporal.TabIndex = 13;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.Location = new System.Drawing.Point(255, 516);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(468, 516);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmNuevoEditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 551);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gpbObservaciones);
            this.Controls.Add(this.gpbDomicilio);
            this.Controls.Add(this.gpbContactos);
            this.Controls.Add(this.gpbDatosPersonales);
            this.Name = "FrmNuevoEditarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoEditarCliente";
            this.Load += new System.EventHandler(this.FrmNuevoEditarCliente_Load);
            this.gpbDatosPersonales.ResumeLayout(false);
            this.gpbDatosPersonales.PerformLayout();
            this.gpbContactos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTelefonos)).EndInit();
            this.gpbDomicilio.ResumeLayout(false);
            this.gpbDomicilio.PerformLayout();
            this.gpbObservaciones.ResumeLayout(false);
            this.gpbObservaciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnMujer;
        private System.Windows.Forms.RadioButton rbtnHombre;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipoTelefono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregarLocalidad;
        private System.Windows.Forms.TextBox txtObjetivos;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLecturaCorporal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSeleccionarDomicilio;
        public System.Windows.Forms.TextBox txtNumCalle;
        public System.Windows.Forms.TextBox txtNombreCalle;
        internal System.Windows.Forms.DataGridView gridTelefonos;
        private System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.GroupBox gpbContactos;
        private System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.GroupBox gpbDatosPersonales;
        public System.Windows.Forms.GroupBox gpbDomicilio;
        public System.Windows.Forms.GroupBox gpbObservaciones;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Button btnGuardar;
    }
}