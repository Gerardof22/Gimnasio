namespace Gimnasio
{
    partial class FrmCobranza
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
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.gpbCampos = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.numImporte = new System.Windows.Forms.NumericUpDown();
            this.numRecargo = new System.Windows.Forms.NumericUpDown();
            this.chekDebe = new System.Windows.Forms.CheckBox();
            this.gpbDetalleCobranza = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gridDetalleCobranza = new System.Windows.Forms.DataGridView();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtTotalCobranza = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecargo)).BeginInit();
            this.gpbDetalleCobranza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleCobranza)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(54, 10);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(182, 21);
            this.cboClientes.TabIndex = 1;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(683, 13);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(105, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // gpbCampos
            // 
            this.gpbCampos.Controls.Add(this.btnAgregar);
            this.gpbCampos.Controls.Add(this.label5);
            this.gpbCampos.Controls.Add(this.label4);
            this.gpbCampos.Controls.Add(this.label3);
            this.gpbCampos.Controls.Add(this.numTotal);
            this.gpbCampos.Controls.Add(this.numImporte);
            this.gpbCampos.Controls.Add(this.numRecargo);
            this.gpbCampos.Controls.Add(this.chekDebe);
            this.gpbCampos.Enabled = false;
            this.gpbCampos.Location = new System.Drawing.Point(16, 65);
            this.gpbCampos.Name = "gpbCampos";
            this.gpbCampos.Size = new System.Drawing.Size(772, 83);
            this.gpbCampos.TabIndex = 4;
            this.gpbCampos.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(681, 35);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Recargo";
            // 
            // numTotal
            // 
            this.numTotal.Enabled = false;
            this.numTotal.Location = new System.Drawing.Point(517, 35);
            this.numTotal.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numTotal.Name = "numTotal";
            this.numTotal.Size = new System.Drawing.Size(92, 20);
            this.numTotal.TabIndex = 3;
            this.numTotal.ValueChanged += new System.EventHandler(this.numTotal_ValueChanged);
            // 
            // numImporte
            // 
            this.numImporte.Location = new System.Drawing.Point(348, 35);
            this.numImporte.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numImporte.Name = "numImporte";
            this.numImporte.Size = new System.Drawing.Size(92, 20);
            this.numImporte.TabIndex = 2;
            this.numImporte.ValueChanged += new System.EventHandler(this.numImporte_ValueChanged);
            // 
            // numRecargo
            // 
            this.numRecargo.Enabled = false;
            this.numRecargo.Location = new System.Drawing.Point(182, 35);
            this.numRecargo.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numRecargo.Name = "numRecargo";
            this.numRecargo.Size = new System.Drawing.Size(92, 20);
            this.numRecargo.TabIndex = 1;
            this.numRecargo.ValueChanged += new System.EventHandler(this.numRecargo_ValueChanged);
            // 
            // chekDebe
            // 
            this.chekDebe.AutoSize = true;
            this.chekDebe.Location = new System.Drawing.Point(38, 38);
            this.chekDebe.Name = "chekDebe";
            this.chekDebe.Size = new System.Drawing.Size(68, 17);
            this.chekDebe.TabIndex = 0;
            this.chekDebe.Text = "Atrazado";
            this.chekDebe.UseVisualStyleBackColor = true;
            this.chekDebe.CheckedChanged += new System.EventHandler(this.chekDebe_CheckedChanged);
            // 
            // gpbDetalleCobranza
            // 
            this.gpbDetalleCobranza.Controls.Add(this.btnFinalizar);
            this.gpbDetalleCobranza.Controls.Add(this.btnEditar);
            this.gpbDetalleCobranza.Controls.Add(this.btnEliminar);
            this.gpbDetalleCobranza.Controls.Add(this.gridDetalleCobranza);
            this.gpbDetalleCobranza.Location = new System.Drawing.Point(16, 167);
            this.gpbDetalleCobranza.Name = "gpbDetalleCobranza";
            this.gpbDetalleCobranza.Size = new System.Drawing.Size(772, 182);
            this.gpbDetalleCobranza.TabIndex = 7;
            this.gpbDetalleCobranza.TabStop = false;
            this.gpbDetalleCobranza.Text = "Detalle cobranzas";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(681, 125);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(681, 86);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(681, 46);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gridDetalleCobranza
            // 
            this.gridDetalleCobranza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalleCobranza.Location = new System.Drawing.Point(6, 19);
            this.gridDetalleCobranza.Name = "gridDetalleCobranza";
            this.gridDetalleCobranza.Size = new System.Drawing.Size(657, 150);
            this.gridDetalleCobranza.TabIndex = 0;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Location = new System.Drawing.Point(242, 10);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCliente.TabIndex = 11;
            this.btnAgregarCliente.Text = "Agregar";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txtTotalCobranza
            // 
            this.txtTotalCobranza.Location = new System.Drawing.Point(579, 364);
            this.txtTotalCobranza.Name = "txtTotalCobranza";
            this.txtTotalCobranza.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCobranza.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total";
            // 
            // FrmCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalCobranza);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.gpbDetalleCobranza);
            this.Controls.Add(this.gpbCampos);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.label1);
            this.Name = "FrmCobranza";
            this.Text = "FrmCobranza";
            this.gpbCampos.ResumeLayout(false);
            this.gpbCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecargo)).EndInit();
            this.gpbDetalleCobranza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleCobranza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gpbCampos;
        private System.Windows.Forms.CheckBox chekDebe;
        private System.Windows.Forms.NumericUpDown numImporte;
        private System.Windows.Forms.NumericUpDown numRecargo;
        private System.Windows.Forms.NumericUpDown numTotal;
        private System.Windows.Forms.GroupBox gpbDetalleCobranza;
        private System.Windows.Forms.DataGridView gridDetalleCobranza;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.TextBox txtTotalCobranza;
        private System.Windows.Forms.Label label6;
    }
}