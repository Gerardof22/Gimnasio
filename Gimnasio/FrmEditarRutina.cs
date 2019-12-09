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
    public partial class FrmEditarRutina : Form
    {
        GimnasioContext dbGimnasio;

        Rutina rutina;
        Cardio cardio;
        Calentamiento calentamiento;
        Ejercicio ejercicio;
        Tipo_Rutina tipo_Rutina;

        public FrmEditarRutina()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            rutina = new Rutina();
        }

        public FrmEditarRutina(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
        }

        public FrmEditarRutina(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
            cardio = new Cardio();
            calentamiento = new Calentamiento();
            ejercicio = new Ejercicio();
            tipo_Rutina = new Tipo_Rutina();
            cargarRutina(idSeleccionado);
        }

        private void cargarRutina(int idSeleccionado)
        {
            rutina = dbGimnasio.Rutinas.Find(idSeleccionado);
            dtpFechaDesde.Value              = rutina.fechaDesde;
            dtpFechaHasta.Value              = rutina.fechaHasta;
            txtSeries.Text                   = rutina.serie.ToString();
            txtRepeticiones.Text             = rutina.repeticion.ToString();
            txtTiempoDuracion.Text           = rutina.tiempoduracion;
            txtDescanso.Text                 = rutina.descanso;
            txtKg.Text                       = rutina.pesokg.ToString();
            this.ValidarCardio();
            this.ValidarCalentamiento();
            
        }


        /// <summary>
        /// Validamos si los campos son null no cargamos nada.
        /// NOTA: ? nos permite validar un objeto null y compararlo, en caso contrario la expresion siempre será true dentro del
        /// if.
        /// </summary>
        private void ValidarCardio()
        {
            if (rutina.Cardio?.idcardio != null)
            {
                rutina.Cardio = dbGimnasio.Cardios.Find(rutina.Cardio.idcardio);
            }
            if (!string.IsNullOrEmpty(rutina.Cardio?.duracion.ToString()))
            {
                txtDuracionCardio.Text = rutina.Cardio.duracion.ToString();
            }
            if (!string.IsNullOrEmpty(rutina.Cardio?.ritmo))
            {
                txtRitmoCardio.Text = rutina.Cardio.ritmo;
            }
        }

        /// <summary>
        /// Validamos si los campos son null no cargamos nada.
        /// 
        /// NOTA: ? nos permite validar un objeto null y compararlo, en caso contrario la expresion siempre será true dentro del
        /// if.
        /// </summary>
        private void ValidarCalentamiento()
        {
            if (rutina.Calentamiento?.idcalentamiento != null)
            {
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(rutina.Calentamiento.idcalentamiento);
            }

            if (rutina.Calentamiento?.duracion != null)
            {
                txtDuracionCalentamiento.Text = rutina.Calentamiento.duracion;
            }

            if (rutina.Calentamiento?.descripcion != null)
            {
                txtDescripcionCalentamiento.Text = rutina.Calentamiento.descripcion;
            }
        }

        private void btnAgregarCardio_Click(object sender, EventArgs e)
        {
            FrmGestionCardio frmGestionCardio = new FrmGestionCardio();
            frmGestionCardio.ShowDialog();

            if (FrmGestionCardio.duracion != 0 && FrmGestionCardio.ritmo != "")
            {
                txtDuracionCardio.Text = FrmGestionCardio.duracion.ToString();
                txtRitmoCardio.Text = FrmGestionCardio.ritmo;
            }

        }

        private void btnAgregarCalentamiento_Click(object sender, EventArgs e)
        {
            FrmGestionCaletamiento frmGestionCaletamiento = new FrmGestionCaletamiento();
            frmGestionCaletamiento.ShowDialog();
            if (FrmGestionCaletamiento.duracion != "")
            {
                txtDuracionCalentamiento.Text = FrmGestionCaletamiento.duracion;
                txtDescripcionCalentamiento.Text = FrmGestionCaletamiento.descripcion;
            }
        }

        private void btnAgregarTipoRutina_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoRutina frmNuevoEditarTipoRutina = new FrmNuevoEditarTipoRutina();
            frmNuevoEditarTipoRutina.ShowDialog();
            if (!string.IsNullOrEmpty(FrmNuevoEditarTipoRutina.tipo_rutina_nombre))
            {
                llenarGrillaTipoRutina();
                cargarGrillaTipoRutina();
            }
        }

        private void llenarGrillaTipoRutina()
        {
            tipo_Rutina = new Tipo_Rutina();
            tipo_Rutina.nombre = FrmNuevoEditarTipoRutina.tipo_rutina_nombre;

            if (rutina.Tipos_Rutinas == null)
            {
                rutina.Tipos_Rutinas = new ObservableCollection<Tipo_Rutina>();
            }

            rutina.Tipos_Rutinas.Add(tipo_Rutina);

            FrmNuevoEditarTipoRutina.tipo_rutina_nombre = "";
        }

        private void cargarGrillaTipoRutina()
        {
            if (rutina.Tipos_Rutinas != null)
            {
                var listaTipoRutina = from tipo in rutina.Tipos_Rutinas
                                      select new
                                      {
                                          idtiporutina = tipo.idtiporutina,
                                          rutina = tipo.nombre,
                                          isDelected = tipo.IsDelete
                                      };

                gridTipoRutina.DataSource = listaTipoRutina.Where(tr => tr.isDelected == false).ToList();
            }

            
        }

        private void btnQuitarTipoRutina_Click(object sender, EventArgs e)
        {
            if (gridTipoRutina.Rows.Count > 0 && gridTipoRutina.SelectedRows.Count > 0)
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
            //FrmNuevoEditarEjercicio frmNuevoEditarEjercicio = new FrmNuevoEditarEjercicio();
            //frmNuevoEditarEjercicio.ShowDialog();
            //if (FrmNuevoEditarEjercicio.ejercicio_nombre != "" && FrmNuevoEditarEjercicio.image != null)
            //{
            //    llenarGrillaEjercicio();
            //    cargarGrillaEjercicios();
            //}
        }

        //private void llenarGrillaEjercicio()
        //{
        //    ejercicio = new Ejercicio();
        //    ejercicio.ejercicio_nombre = FrmNuevoEditarEjercicio.ejercicio_nombre;
        //    ejercicio.ejercicio_imagen = FrmNuevoEditarEjercicio.image;

        //    if (rutina.Ejercicios == null)
        //    {
        //        rutina.Ejercicios = new ObservableCollection<Ejercicio>();
        //    }

        //    rutina.Ejercicios.Add(ejercicio);

        //    FrmNuevoEditarEjercicio.ejercicio_nombre = "";
        //    FrmNuevoEditarEjercicio.image = null;
        //}

        //private void cargarGrillaEjercicios()
        //{
        //    if (rutina.Ejercicios != null)
        //    {
        //        var listaEjercicios = from e in rutina.Ejercicios
        //                              select new
        //                              {
        //                                  idejercicio = e.ejercicio_idejercicio,
        //                                  nombre = e.ejercicio_nombre,
        //                                  imagen = FrmNuevoEditarEjercicio.byteArrayToImage(e.ejercicio_imagen),
        //                                  isDelected = e.ejercicio_delete
        //                              };

        //        gridEjercicio.DataSource = listaEjercicios.Where(e => e.isDelected == false).ToList();
        //        ((DataGridViewImageColumn)gridEjercicio.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Zoom;
        //        ((DataGridViewImageColumn)gridEjercicio.Columns[2]).DefaultCellStyle.NullValue = null;
        //    }
        //}

        //private void btnQuitarEjercicio_Click(object sender, EventArgs e)
        //{
        //    if (gridEjercicio.Rows.Count > 0 && gridEjercicio.SelectedRows.Count > 0)
        //    {
        //        int idSeleccionado = (int)celdaFilaActual(gridEjercicio, 0);

        //        string mensaje = "¿Está seguro que desea quitar?";
        //        string titulo = "Eliminación";
        //        DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (respuesta == DialogResult.Yes)
        //        {
        //            int idDetalleSeleccionado = gridEjercicio.CurrentRow.Index;
        //            rutina.Ejercicios.RemoveAt(idDetalleSeleccionado);
        //            cargarGrillaEjercicios();
        //        }
        //    }
        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                rutina.fechaDesde = dtpFechaDesde.Value;
                rutina.fechaHasta = dtpFechaHasta.Value;
                rutina.serie = int.Parse(txtSeries.Text);
                rutina.repeticion = int.Parse(txtRepeticiones.Text);
                rutina.tiempoduracion = txtTiempoDuracion.Text;
                rutina.descanso = txtDescanso.Text;
                rutina.pesokg = float.Parse(txtKg.Text);
                this.validarRelacionesTablas();

                if (rutina.idrutina > 0)
                {
                    dbGimnasio.Entry(rutina).State = EntityState.Modified;
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dbGimnasio.SaveChanges();
                Close();
            }
            catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
            {
                this.ValidarCatch(ex);
                throw;
            }
        }

        private void ValidarCatch(DbEntityValidationException ex)
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
