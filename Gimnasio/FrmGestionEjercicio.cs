using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmGestionEjercicio : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Ejercicio ejercicio = new Ejercicio();

        //Está propiedad se encarga de capturar el idcardio que es seleccionado en la grilla.
        internal static int idejercicio { get; set; }

        //Propiedades que se llenan con los datos de la fila seleccionada de la grilla.
        internal static float ejercicio_nombre { get; set; }
        internal static Image image { get; set; }

        public FrmGestionEjercicio()
        {
            InitializeComponent();
            listarEjrcicios();
            ocultarColumnas();
        }

        private void ocultarColumnas()
        {
            this.gridEjercicio.Columns[0].Visible = false;
            this.gridEjercicio.Columns[3].Visible = false;
        }

        private void listarEjrcicios()
        {
            var listaEjercicio = from e in dbGimnasio.Ejercicios
                                 select new
                                 {
                                     idEjercicio = e.idejercicio,
                                     nombre = e.nombre,
                                     imagen = e.imagen,
                                     isDelected = e.IsDelete
                                 };

            gridEjercicio.DataSource = listaEjercicio.Where(e => e.isDelected == false).ToList();
            ((DataGridViewImageColumn)gridEjercicio.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            ((DataGridViewImageColumn)gridEjercicio.Columns[2]).DefaultCellStyle.NullValue = null;
        }

        private void CargarGillaRutinas(int idSeleccionado)
        {
            var listaRutina = from e in dbGimnasio.Ejercicios
                              join r in dbGimnasio.Rutinas on e.idejercicio equals r.Ejercicio.idejercicio
                              where e.idejercicio == idSeleccionado
                              select new
                              {
                                  idrutina = r.idrutina,
                                  fechaDesde = r.fechaDesde,
                                  fechaHasta = r.fechaHasta,
                                  serie = r.serie,
                                  repeticion = r.repeticion,
                                  tiempoDuracion = r.tiempoduracion,
                                  descanso = r.descanso,
                                  pesoKG = r.pesokg,
                                  Cardio = r.Cardio.duracion + " " + r.Cardio.duracion,
                                  Calentamiento = r.Calentamiento.duracion + " " + r.Calentamiento.descripcion,
                                  IsDelected = r.IsDelete
                              };

            gridRutina.DataSource = listaRutina.ToList();
        }

        private void buscarEjrcicios(string textToSearch)
        {
            var listaEjercicio = from e in dbGimnasio.Ejercicios
                                 select new
                                 {
                                     idEjercicio = e.idejercicio,
                                     nombre = e.nombre,
                                     imagen = e.imagen,
                                     isDelected = e.IsDelete
                                 };

            gridEjercicio.DataSource = listaEjercicio.Where(e => e.nombre.Contains(textToSearch))
                                                     .Where(e => e.isDelected == false).ToList();
            ((DataGridViewImageColumn)gridEjercicio.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            ((DataGridViewImageColumn)gridEjercicio.Columns[2]).DefaultCellStyle.NullValue = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarEjercicio frmNuevoEditarEjercicio = new FrmNuevoEditarEjercicio(dbGimnasio);
            frmNuevoEditarEjercicio.ShowDialog();
            listarEjrcicios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridEjercicio.Rows.Count > 0 && gridEjercicio.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridEjercicio, 0);

                FrmEditarEjercicio frmEditarEjercicio = new FrmEditarEjercicio(idSeleccionado, dbGimnasio);
                frmEditarEjercicio.ShowDialog();
                listarEjrcicios();
            }
        }

        /// <summary>
        /// Obtiene la celda y la fila actual seleccionada.
        /// </summary>
        /// <param name="dataGridView"> Corresponde al nombre del DataGridView.</param>
        /// <param name="column">Correspone al índice de columna del DataGridView.</param>
        /// <returns>Retorna un object.</returns>
        private object celdaFilaActual(DataGridView dataGridView, int column)
        {
            DataGridViewCellCollection celdasFilaActual = dataGridView.CurrentRow.Cells;

            return celdasFilaActual[column].Value;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridEjercicio.Rows.Count > 0 && gridEjercicio.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridEjercicio, 0);

                string mensaje = "¿Está seguro que desea eliminar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    ejercicio = dbGimnasio.Ejercicios.Find(idSeleccionado);
                    ejercicio.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    listarEjrcicios();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarEjrcicios(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridEjercicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridEjercicio.CurrentRow != null)
            {
                int idEjercicioSeleccionado = (int)celdaFilaActual(gridEjercicio, 0);

                if (celdaFilaActual(gridEjercicio, 2) != null)
                {
                    this.pxbImagen.Image = FrmNuevoEditarEjercicio.byteArrayToImage((byte[])celdaFilaActual(gridEjercicio, 2));
                }
                else
                {
                    this.pxbImagen.Image = null;
                }

                this.CargarGillaRutinas(idEjercicioSeleccionado);
            }
        }

        private void gridEjercicio_RowEnter(object sender, DataGridViewCellEventArgs celdaSeleccionada)
        {
            gridEjercicio_CellClick(gridEjercicio, celdaSeleccionada);
        }

        private void gridEjercicio_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEjercicio.CurrentRow != null)
            {
                if (celdaFilaActual(gridEjercicio, 2) != null)
                {
                    this.pxbImagen.Image = FrmNuevoEditarEjercicio.byteArrayToImage((byte[])celdaFilaActual(gridEjercicio, 2));
                }
                else
                {
                    this.pxbImagen.Image = null;
                }
            }
        }
    }
}
