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
    public partial class FrmGestionCardio : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Cardio cardio = new Cardio();

        //Está propiedad se encarga de capturar el idcardio que es seleccionado en la grilla.
        internal static int idcardio { get; set; }

        //Propiedades que se llenan con los datos de la fila seleccionada de la grilla.
        internal static float duracion { get; set; }
        internal static  string ritmo { get; set; }


        public FrmGestionCardio()
        {
            InitializeComponent();
            listarGrillaCardios();
        }

        private void listarGrillaCardios()
        {
            var listaCardio = from cardio in dbGimnasio.Cardios
                              select new
                              {
                                  idcardio = cardio.cardio_idcardio,
                                  duracion = cardio.cardio_duracion,
                                  ritmo = cardio.cardio_ritmo,
                                  isDelected = cardio.cardio_delete
                              };

            gridCardio.DataSource = listaCardio.Where(c => c.isDelected == false).ToList();
        }

        private void buscarCardio(string textToSearch)
        {
            var listaCardio = from cardio in dbGimnasio.Cardios
                              select new
                              {
                                  idcardio = cardio.cardio_idcardio,
                                  duracion = cardio.cardio_duracion,
                                  ritmo = cardio.cardio_ritmo,
                                  isDelected = cardio.cardio_delete
                              };

            gridCardio.DataSource = listaCardio.Where(c => c.ritmo.Contains(textToSearch))
                                               .Where(c => c.isDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCardio frmNuevoEditarCardio = new FrmNuevoEditarCardio(dbGimnasio);
            frmNuevoEditarCardio.ShowDialog();
            listarGrillaCardios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridCardio.Rows.Count > 0 && gridCardio.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridCardio, 0);

                FrmNuevoEditarDomicilio frmNuevoEditarDomicilio = new FrmNuevoEditarDomicilio(idSeleccionado, dbGimnasio);
                frmNuevoEditarDomicilio.ShowDialog();
                listarGrillaCardios();
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
            if (gridCardio.Rows.Count > 0 && gridCardio.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridCardio, 0);

                string mensaje = "¿Está seguro que desea eliminar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    cardio = dbGimnasio.Cardios.Find(idSeleccionado);
                    cardio.cardio_delete = true;
                    dbGimnasio.SaveChanges();
                    listarGrillaCardios();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscarCardio(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridCardio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (gridCardio.RowCount > 0 && gridCardio.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    idcardio = (int)this.gridCardio.CurrentRow.Cells[0].Value;
                    duracion = (float)this.gridCardio.CurrentRow.Cells[1].Value;
                    ritmo = this.gridCardio.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                }
            }
        }

        private void gridCardio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCardio.RowCount > 0 && gridCardio.SelectedRows.Count > 0)
            {
                idcardio = (int)this.gridCardio.CurrentRow.Cells[0].Value;
                duracion = (float)this.gridCardio.CurrentRow.Cells[1].Value;
                ritmo = this.gridCardio.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
        }
    }
}
