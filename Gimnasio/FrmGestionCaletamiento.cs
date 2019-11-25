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
    public partial class FrmGestionCaletamiento : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Calentamiento calentamiento = new Calentamiento();

        //Está propiedad se encarga de capturar el id del domicilio que es seleccionado en la grilla.
        internal static int idcalentamiento { get; set; }

        //Propiedades que se llenan con los datos de la fila seleccionada de la grilla.
        internal static string duracion { get; set; }
        internal static string descripcion { get; set; }

        public FrmGestionCaletamiento()
        {
            InitializeComponent();
            listarCalentaientos();
        }

        private void listarCalentaientos()
        {
            var listaCalentamientos = from calentamiento in dbGimnasio.Calentamientos
                                      select new
                                      {
                                          idcalentamiento = calentamiento.calentamiento_idcalentamiento,
                                          duracion = calentamiento.calentamiento_duracion,
                                          descripcion = calentamiento.calentamiento_descripcion,
                                          isDelected = calentamiento.calentamiento_delete
                                      };

            gridCalentamiento.DataSource = listaCalentamientos.Where(c => c.isDelected == false).ToList();
        }

        private void buscarCalentaientos(string textToSearch)
        {
            var listaCalentamientos = from calentamiento in dbGimnasio.Calentamientos
                                      select new
                                      {
                                          idcalentamiento = calentamiento.calentamiento_idcalentamiento,
                                          duracion = calentamiento.calentamiento_duracion,
                                          descripcion = calentamiento.calentamiento_descripcion,
                                          isDelected = calentamiento.calentamiento_delete
                                      };

            gridCalentamiento.DataSource = listaCalentamientos.Where(c => c.descripcion.Contains(textToSearch))
                                                              .Where(c => c.isDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCalentamiento frmNuevoEditarCalentamiento = new FrmNuevoEditarCalentamiento();
            frmNuevoEditarCalentamiento.ShowDialog();
            listarCalentaientos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)celdaFilaActual(gridCalentamiento, 0);

            FrmNuevoEditarDomicilio frmNuevoEditarDomicilio = new FrmNuevoEditarDomicilio(idSeleccionado, dbGimnasio);
            frmNuevoEditarDomicilio.ShowDialog();
            listarCalentaientos();
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
            int idSeleccionado = (int)celdaFilaActual(gridCalentamiento, 0);

            string mensaje = "¿Está seguro que desea eliminar?";
            string titulo = "Eliminación";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                calentamiento = dbGimnasio.Calentamientos.Find(idSeleccionado);
                calentamiento.calentamiento_delete = true;
                dbGimnasio.SaveChanges();
                listarCalentaientos();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarCalentaientos(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridCalentamiento_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (gridCalentamiento.RowCount > 0 && gridCalentamiento.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    idcalentamiento = (int)this.gridCalentamiento.CurrentRow.Cells[0].Value;
                    duracion = this.gridCalentamiento.CurrentRow.Cells[1].Value.ToString();
                    descripcion = this.gridCalentamiento.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                }
            }
        }

        private void gridCalentamiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCalentamiento.RowCount > 0 && gridCalentamiento.SelectedRows.Count > 0)
            {
                idcalentamiento = (int)this.gridCalentamiento.CurrentRow.Cells[0].Value;
                duracion = this.gridCalentamiento.CurrentRow.Cells[1].Value.ToString();
                descripcion = this.gridCalentamiento.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
        }
    }
}
