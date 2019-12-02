using Datos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmNuevoEditarCalentamiento : Form
    {
        GimnasioContext dbGimnasio;
        public Calentamiento calentamiento;
        Tipo_Calentamiento tipo_calentamiento;

        public FrmNuevoEditarCalentamiento()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            calentamiento = new Calentamiento();
        }

        public FrmNuevoEditarCalentamiento(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            calentamiento = new Calentamiento();
            cargarCalentamiento(0);
        }

        public FrmNuevoEditarCalentamiento(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            calentamiento = new Calentamiento();
            cargarCalentamiento(idSeleccionado);
        }

        private void cargarCalentamiento(int idSeleccionado)
        {
            calentamiento = dbGimnasio.Calentamientos.Find(idSeleccionado);
            txtDuracion.Text = calentamiento.duracion;
            txtDescripcion.Text = calentamiento.descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                calentamiento.duracion = txtDuracion.Text;
                calentamiento.descripcion = txtDescripcion.Text;

                if (calentamiento.idcalentamiento > 0)
                {
                    dbGimnasio.Entry(calentamiento).State = EntityState.Modified;
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbGimnasio.Calentamientos.Add(calentamiento);
                    MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dbGimnasio.SaveChanges();
                this.Close();
            }
            catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
            {
                this.ValidateCatch(ex);
                throw;
            }
        }

        private void ValidateCatch(DbEntityValidationException ex)
        {
            foreach (var dbEntityValidation in ex.EntityValidationErrors)
            {
                Console.WriteLine("El tipo de entidad \"{0}\" en el estado \"{1}\" tiene los siguientes errores de validación:",
                    dbEntityValidation.Entry.Entity.GetType().Name, dbEntityValidation.Entry.State);
                foreach (var ve in dbEntityValidation.ValidationErrors)
                {
                    Console.WriteLine("- Propiedad: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoTipoCalentamiento tipoCalentamiento = new FrmNuevoTipoCalentamiento();
            tipoCalentamiento.ShowDialog();

            if (!string.IsNullOrEmpty(FrmNuevoTipoCalentamiento.nombre_tipo_calentamiento))
            {
                this.AgregarGrillaTipoCalentamiento();
                this.CargarGrillaTipoCalentamiento();
            }
        }

        private void AgregarGrillaTipoCalentamiento()
        {
            
            tipo_calentamiento = new Tipo_Calentamiento();
            tipo_calentamiento.nombre = FrmNuevoTipoCalentamiento.nombre_tipo_calentamiento;

            if (calentamiento.Tipos_Calentamientos == null)
            {
                calentamiento.Tipos_Calentamientos = new ObservableCollection<Tipo_Calentamiento>();
            }

            calentamiento.Tipos_Calentamientos.Add(tipo_calentamiento);

            FrmNuevoTipoCalentamiento.nombre_tipo_calentamiento = "";
            
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gridTipoCalentamiento.Rows.Count > 0)
            {

                int idSeleccionado = (int)celdaFilaActual(gridTipoCalentamiento, 0);

                string mensaje = "¿Está seguro que desea quitar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    int idDetalleSeleccionado = gridTipoCalentamiento.CurrentRow.Index;
                    calentamiento.Tipos_Calentamientos.RemoveAt(idDetalleSeleccionado);
                    this.CargarGrillaTipoCalentamiento();
                }
            }
        }

        private void CargarGrillaTipoCalentamiento()
        {
            if (calentamiento.Tipos_Calentamientos != null)
            {
                var listaTipoCalentamiento = from tipoC in calentamiento.Tipos_Calentamientos
                                             select new
                                             {
                                                 id = tipoC.idtipocalentamiento,
                                                 Tipo = tipoC.nombre,
                                                 IsDelected = tipoC.IsDelete
                                             };

                gridTipoCalentamiento.DataSource = listaTipoCalentamiento.Where(t => t.IsDelected == false).ToList();
            }
        }

        /// <summary>
        /// Obtiene la celda y la fila actual seleccionada.
        /// </summary>
        /// <param name="dataGridView"> Nombre del DataGridView.</param>
        /// <param name="column">Índice de columna del DataGridView.</param>
        /// <returns>Retorna un object.</returns>
        private object celdaFilaActual(DataGridView dataGridView, int column)
        {
            DataGridViewCellCollection celdasFilaActual = dataGridView.CurrentRow.Cells;

            return celdasFilaActual[column].Value;
        }
    }
}
