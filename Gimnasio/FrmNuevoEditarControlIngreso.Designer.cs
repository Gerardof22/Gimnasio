namespace Gimnasio
{
    partial class FrmNuevoEditarControlIngreso
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
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.rbtnMañana = new System.Windows.Forms.RadioButton();
            this.rbtnTarde = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarNuevoCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Location = new System.Drawing.Point(53, 117);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaIngreso.TabIndex = 5;
            // 
            // rbtnMañana
            // 
            this.rbtnMañana.AutoSize = true;
            this.rbtnMañana.Checked = true;
            this.rbtnMañana.Location = new System.Drawing.Point(53, 75);
            this.rbtnMañana.Name = "rbtnMañana";
            this.rbtnMañana.Size = new System.Drawing.Size(64, 17);
            this.rbtnMañana.TabIndex = 3;
            this.rbtnMañana.TabStop = true;
            this.rbtnMañana.Text = "Mañana";
            this.rbtnMañana.UseVisualStyleBackColor = true;
            // 
            // rbtnTarde
            // 
            this.rbtnTarde.AutoSize = true;
            this.rbtnTarde.Location = new System.Drawing.Point(189, 75);
            this.rbtnTarde.Name = "rbtnTarde";
            this.rbtnTarde.Size = new System.Drawing.Size(53, 17);
            this.rbtnTarde.TabIndex = 4;
            this.rbtnTarde.Text = "Tarde";
            this.rbtnTarde.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(53, 165);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(178, 165);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Turno";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(53, 22);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(200, 21);
            this.cboCliente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cliente";
            // 
            // btnAgregarNuevoCliente
            // 
            this.btnAgregarNuevoCliente.Location = new System.Drawing.Point(259, 22);
            this.btnAgregarNuevoCliente.Name = "btnAgregarNuevoCliente";
            this.btnAgregarNuevoCliente.Size = new System.Drawing.Size(26, 23);
            this.btnAgregarNuevoCliente.TabIndex = 2;
            this.btnAgregarNuevoCliente.Text = "...";
            this.btnAgregarNuevoCliente.UseVisualStyleBackColor = true;
            this.btnAgregarNuevoCliente.Click += new System.EventHandler(this.btnAgregarNuevoCliente_Click);
            // 
            // FrmNuevoEditarControlIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 210);
            this.Controls.Add(this.btnAgregarNuevoCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rbtnTarde);
            this.Controls.Add(this.rbtnMañana);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmNuevoEditarControlIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIngresoDiarioClientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.RadioButton rbtnMañana;
        private System.Windows.Forms.RadioButton rbtnTarde;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarNuevoCliente;
    }
}