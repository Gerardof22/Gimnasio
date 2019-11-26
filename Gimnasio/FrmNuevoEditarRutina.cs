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
    public partial class FrmNuevoEditarRutina : Form
    {
        GimnasioContext dbGimnasio;
        Rutina rutina;
        Tipo_Rutina tipo_Rutina;
        Ejercicio ejercicio;

        public FrmNuevoEditarRutina()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            rutina = new Rutina();
        }

        public FrmNuevoEditarRutina(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
            cargarRutina(0);
        }

        public FrmNuevoEditarRutina(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
            cargarRutina(idSeleccionado);
        }

        private void cargarRutina(int idSeleccionado)
        {
            rutina = dbGimnasio.Rutinas.Find(idSeleccionado);
            dtpFechaDesde.Value              = rutina.rutina_fechaDesde;
            dtpFechaHasta.Value              = rutina.rutina_fechaHasta;
            txtSeries.Text                   = rutina.rutina_serie.ToString();
            txtRepeticiones.Text             = rutina.rutina_repeticion.ToString();
            txtTiempoDuracion.Text           = rutina.rutina_tiempoduracion;
            txtDescanso.Text                 = rutina.rutina_descanso;
            txtKg.Text                       = rutina.rutina_pesokg.ToString();
            rutina.Cardio                    = dbGimnasio.Cardios.Find(rutina.Cardio.cardio_idcardio);
            txtDuracionCardio.Text           = rutina.Cardio.cardio_duracion.ToString();
            txtRitmoCardio.Text              = rutina.Cardio.cardio_ritmo;
            rutina.Calentamiento             = dbGimnasio.Calentamientos.Find(rutina.Calentamiento.calentamiento_idcalentamiento);
            txtDuracionCalentamiento.Text    = rutina.Calentamiento.calentamiento_duracion;
            txtDescripcionCalentamiento.Text = rutina.Calentamiento.calentamiento_descripcion;
        }

        private void btnAgregarCardio_Click(object sender, EventArgs e)
        {
            FrmGestionCardio frmGestionCardio = new FrmGestionCardio();
            frmGestionCardio.ShowDialog();

            txtDuracionCardio.Text = frmGestionCardio.duracion.ToString();
            txtRitmoCardio.Text = frmGestionCardio.ritmo;
        }

        private void btnAgregarCalentamiento_Click(object sender, EventArgs e)
        {
            FrmGestionCaletamiento frmGestionCaletamiento = new FrmGestionCaletamiento();
            frmGestionCaletamiento.ShowDialog();

            txtDuracionCalentamiento.Text = FrmGestionCaletamiento.duracion;
            txtDescripcionCalentamiento.Text = FrmGestionCaletamiento.descripcion;
        }

        private void btnAgregarTipoRutina_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoRutina frmNuevoEditarTipoRutina = new FrmNuevoEditarTipoRutina();
            frmNuevoEditarTipoRutina.ShowDialog();
            llenarGrillaTipoRutina();
            cargarGrillaTipoRutina();
        }

        private void llenarGrillaTipoRutina()
        {
            tipo_Rutina = new Tipo_Rutina();
            tipo_Rutina.tipo_rutina_nombre = FrmNuevoEditarTipoRutina.tipo_rutina_nombre;

            if (rutina.Tipos_Rutinas == null)
            {
                rutina.Tipos_Rutinas = new ObservableCollection<Tipo_Rutina>();
            }

            rutina.Tipos_Rutinas.Add(tipo_Rutina);
        }

        private void cargarGrillaTipoRutina()
        {
            if (rutina.Tipos_Rutinas != null)
            {
                var listaTipoRutina = from tipo in rutina.Tipos_Rutinas
                                      select new
                                      {
                                          idtiporutina = tipo.tipo_rutina_idtiporutina,
                                          rutina = tipo.tipo_rutina_nombre,
                                          isDelected = tipo.tipo_rutina_delete
                                      };

                gridTipoRutina.DataSource = listaTipoRutina.Where(tr => tr.isDelected == false).ToList();
            }

            
        }

        private void btnQuitarTipoRutina_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)celdaFilaActual(gridTipoRutina, 0);

            string mensaje = "¿Está seguro que desea quitar?";
            string titulo = "Eliminación";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                int idDetalleSeleccionado = gridTipoRutina.CurrentRow.Index;
                rutina.Tipos_Rutinas.RemoveAt(idDetalleSeleccionado);
                cargarGrillaTipoRutina();
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

        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarEjercicio frmNuevoEditarEjercicio = new FrmNuevoEditarEjercicio();
            frmNuevoEditarEjercicio.ShowDialog();
            if (FrmNuevoEditarEjercicio.ejercicio_nombre != "" && FrmNuevoEditarEjercicio.image != null)
            {
                llenarGrillaEjercicio();
                cargarGrillaEjercicios();
            }
        }

        private void llenarGrillaEjercicio()
        {
            ejercicio = new Ejercicio();
            ejercicio.ejercicio_nombre = FrmNuevoEditarEjercicio.ejercicio_nombre;
            ejercicio.ejercicio_imagen = FrmNuevoEditarEjercicio.image;

            if (rutina.Ejercicios == null)
            {
                rutina.Ejercicios = new ObservableCollection<Ejercicio>();
            }

            rutina.Ejercicios.Add(ejercicio);

            FrmNuevoEditarEjercicio.ejercicio_nombre = "";
            FrmNuevoEditarEjercicio.image = null;
        }

        private void cargarGrillaEjercicios()
        {
            if (rutina.Ejercicios != null)
            {
                var listaEjercicios = from e in rutina.Ejercicios
                                      select new
                                      {
                                          idejercicio = e.ejercicio_idejercicio,
                                          nombre = e.ejercicio_nombre,
                                          imagen = FrmNuevoEditarEjercicio.byteArrayToImage(e.ejercicio_imagen),
                                          isDelected = e.ejercicio_delete
                                      };

                gridEjercicio.DataSource = listaEjercicios.Where(e => e.isDelected == false).ToList();
                ((DataGridViewImageColumn)gridEjercicio.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                ((DataGridViewImageColumn)gridEjercicio.Columns[2]).DefaultCellStyle.NullValue = null;
            }
        }

        private void btnQuitarEjercicio_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)celdaFilaActual(gridEjercicio, 0);

            string mensaje = "¿Está seguro que desea quitar?";
            string titulo = "Eliminación";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                int idDetalleSeleccionado = gridEjercicio.CurrentRow.Index;
                rutina.Ejercicios.RemoveAt(idDetalleSeleccionado);
                cargarGrillaEjercicios();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                rutina.rutina_fechaDesde = dtpFechaDesde.Value;
                rutina.rutina_fechaHasta = dtpFechaHasta.Value;
                rutina.rutina_serie = int.Parse(txtSeries.Text);
                rutina.rutina_repeticion = int.Parse(txtRepeticiones.Text);
                rutina.rutina_tiempoduracion = txtTiempoDuracion.Text;
                rutina.rutina_descanso = txtDescanso.Text;
                rutina.rutina_pesokg = float.Parse(txtKg.Text);
                this.validarRelacionesTablas();

                if (rutina.rutina_idrutina > 0)
                {
                    dbGimnasio.Entry(rutina).State = EntityState.Modified;
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbGimnasio.Rutinas.Add(rutina);
                    MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dbGimnasio.SaveChanges();
                Close();
            }
            catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
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
                throw;
            }
        }

        private void validarRelacionesTablas()
        {
            if (dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio) != null)
            {
                rutina.Cardio = dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio);
            }
            if (dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento) != null)
            {
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento);
            }
        }
    }
}
