namespace Gimnasio.Reportes
{
    partial class ReporteEjercicio
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EjercicioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RutinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EjercicioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RutinaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ejercicio";
            reportDataSource1.Value = this.EjercicioBindingSource;
            reportDataSource2.Name = "Rutinas";
            reportDataSource2.Value = this.RutinaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gimnasio.Reportes.Ejercicio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // EjercicioBindingSource
            // 
            this.EjercicioBindingSource.DataSource = typeof(Datos.Ejercicio);
            // 
            // RutinaBindingSource
            // 
            this.RutinaBindingSource.DataSource = typeof(Datos.Rutina);
            // 
            // ReporteEjercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteEjercicio";
            this.Text = "ReporteEjercicio";
            this.Load += new System.EventHandler(this.ReporteEjercicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EjercicioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RutinaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EjercicioBindingSource;
        private System.Windows.Forms.BindingSource RutinaBindingSource;
    }
}