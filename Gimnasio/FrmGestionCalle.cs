using System;
using Datos;
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
    public partial class FrmGestionCalle : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Calle calle = new Calle();

        public FrmGestionCalle()
        {
            InitializeComponent();
            this.ListarGrillaCalles();
        }

        private void ListarGrillaCalles()
        {
            var listaCalles = from nommbre_calle in dbGimnasio.Calles
                              select new
                              {
                                  idcalle = nommbre_calle.idcalle,
                                  nombre = nommbre_calle.nombre_calle,
                                  IsDelected = nommbre_calle.IsDelected
                              };

            gridCalle.DataSource = listaCalles.Where(c => c.IsDelected == false).ToList();
        }

        private void BuscarCalle(string textToSearch)
        {
            var listaCalles = from nommbre_calle in dbGimnasio.Calles
                              select new
                              {
                                  idcalle = nommbre_calle.idcalle,
                                  nombre = nommbre_calle.nombre_calle,
                                  IsDelected = nommbre_calle.IsDelected
                              };

            gridCalle.DataSource = listaCalles.Where(c => c.nombre.Contains(textToSearch))
                                              .Where(c => c.IsDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCalle frmNuevoEditarCalle = new FrmNuevoEditarCalle(dbGimnasio);
            frmNuevoEditarCalle.ShowDialog();
            ListarGrillaCalles();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridCalle.Rows.Count > 0 && gridCalle.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridCalle, 0);

                FrmNuevoEditarCalle frmNuevoEditarCalle = new FrmNuevoEditarCalle(idSeleccionado, dbGimnasio);
                frmNuevoEditarCalle.ShowDialog();
                ListarGrillaCalles();
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
            if (gridCalle.Rows.Count > 0 && gridCalle.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridCalle, 0);
                string calleSeleccionada = (string)celdaFilaActual(gridCalle, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + calleSeleccionada + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    calle = dbGimnasio.Calles.Find(idSeleccionado);
                    calle.IsDelected = true;
                    dbGimnasio.SaveChanges();
                    ListarGrillaCalles();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarCalle(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
