namespace Gimnasio
{
    partial class FrmNuevoEditarTelefono
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
            this.cboTipoTelefono = new System.Windows.Forms.ComboBox();
            this.txtNumeroTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevoTipo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo teléfono";
            // 
            // cboTipoTelefono
            // 
            this.cboTipoTelefono.FormattingEnabled = true;
            this.cboTipoTelefono.Location = new System.Drawing.Point(96, 13);
            this.cboTipoTelefono.Name = "cboTipoTelefono";
            this.cboTipoTelefono.Size = new System.Drawing.Size(132, 21);
            this.cboTipoTelefono.TabIndex = 1;
            // 
            // txtNumeroTelefono
            // 
            this.txtNumeroTelefono.Location = new System.Drawing.Point(96, 45);
            this.txtNumeroTelefono.Name = "txtNumeroTelefono";
            this.txtNumeroTelefono.Size = new System.Drawing.Size(132, 20);
            this.txtNumeroTelefono.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número teléfono";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(96, 88);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(56, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(172, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevoTipo
            // 
            this.btnNuevoTipo.Location = new System.Drawing.Point(234, 13);
            this.btnNuevoTipo.Name = "btnNuevoTipo";
            this.btnNuevoTipo.Size = new System.Drawing.Size(25, 23);
            this.btnNuevoTipo.TabIndex = 2;
            this.btnNuevoTipo.Text = "...";
            this.btnNuevoTipo.UseVisualStyleBackColor = true;
            this.btnNuevoTipo.Click += new System.EventHandler(this.btnNuevoTipo_Click);
            // 
            // FrmNuevoEditarTelefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 128);
            this.Controls.Add(this.btnNuevoTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroTelefono);
            this.Controls.Add(this.cboTipoTelefono);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmNuevoEditarTelefono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telefono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.ComboBox cboTipoTelefono;
        internal System.Windows.Forms.TextBox txtNumeroTelefono;
        private System.Windows.Forms.Button btnNuevoTipo;
    }
}