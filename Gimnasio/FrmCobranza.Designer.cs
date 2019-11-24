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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chekDebe = new System.Windows.Forms.CheckBox();
            this.numRecargo = new System.Windows.Forms.NumericUpDown();
            this.numImporte = new System.Windows.Forms.NumericUpDown();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.gpbDetalleCobranza = new System.Windows.Forms.GroupBox();
            this.gridDetalleCobranza = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(588, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numTotal);
            this.groupBox1.Controls.Add(this.numImporte);
            this.groupBox1.Controls.Add(this.numRecargo);
            this.groupBox1.Controls.Add(this.chekDebe);
            this.groupBox1.Location = new System.Drawing.Point(16, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // chekDebe
            // 
            this.chekDebe.AutoSize = true;
            this.chekDebe.Location = new System.Drawing.Point(38, 38);
            this.chekDebe.Name = "chekDebe";
            this.chekDebe.Size = new System.Drawing.Size(52, 17);
            this.chekDebe.TabIndex = 0;
            this.chekDebe.Text = "Debe";
            this.chekDebe.UseVisualStyleBackColor = true;
            // 
            // numRecargo
            // 
            this.numRecargo.Location = new System.Drawing.Point(182, 35);
            this.numRecargo.Name = "numRecargo";
            this.numRecargo.Size = new System.Drawing.Size(92, 20);
            this.numRecargo.TabIndex = 1;
            // 
            // numImporte
            // 
            this.numImporte.Location = new System.Drawing.Point(348, 35);
            this.numImporte.Name = "numImporte";
            this.numImporte.Size = new System.Drawing.Size(92, 20);
            this.numImporte.TabIndex = 2;
            // 
            // numTotal
            // 
            this.numTotal.Location = new System.Drawing.Point(517, 35);
            this.numTotal.Name = "numTotal";
            this.numTotal.Size = new System.Drawing.Size(92, 20);
            this.numTotal.TabIndex = 3;
            // 
            // gpbDetalleCobranza
            // 
            this.gpbDetalleCobranza.Controls.Add(this.btnFinalizar);
            this.gpbDetalleCobranza.Controls.Add(this.btnEditar);
            this.gpbDetalleCobranza.Controls.Add(this.btnEliminar);
            this.gpbDetalleCobranza.Controls.Add(this.gridDetalleCobranza);
            this.gpbDetalleCobranza.Location = new System.Drawing.Point(16, 192);
            this.gpbDetalleCobranza.Name = "gpbDetalleCobranza";
            this.gpbDetalleCobranza.Size = new System.Drawing.Size(772, 182);
            this.gpbDetalleCobranza.TabIndex = 7;
            this.gpbDetalleCobranza.TabStop = false;
            this.gpbDetalleCobranza.Text = "Detalle cobranzas";
            // 
            // gridDetalleCobranza
            // 
            this.gridDetalleCobranza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalleCobranza.Location = new System.Drawing.Point(6, 19);
            this.gridDetalleCobranza.Name = "gridDetalleCobranza";
            this.gridDetalleCobranza.Size = new System.Drawing.Size(657, 150);
            this.gridDetalleCobranza.TabIndex = 0;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Importe";
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
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(681, 46);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(681, 86);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(669, 35);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(681, 125);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // FrmCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.gpbDetalleCobranza);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.label1);
            this.Name = "FrmCobranza";
            this.Text = "FrmCobranza";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            this.gpbDetalleCobranza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleCobranza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}