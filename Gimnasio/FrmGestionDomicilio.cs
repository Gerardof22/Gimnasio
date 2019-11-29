using Datos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmGestionDomicilio : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Domicilio domicilio = new Domicilio();

        //Está propiedad se encarga de capturar el id del domicilio que es seleccionado en la grilla.
        internal static int iddomicilio { get; set; }

        //Propiedades que se llenan con los datos de la fila seleccionada de la grilla.
        internal string calle { get; set; }
        internal int numero { get; set; }

        public FrmGestionDomicilio()
        {
            InitializeComponent();
            listarGrillaDomicilios();
        }

        private void listarGrillaDomicilios()
        {
            var listaDomicilios = from domicilio in dbGimnasio.Domicilios
                                  select new
                                  {
                                      iddomicilio = domicilio.domicilio_iddomicilio,
                                      calle = domicilio.Calle.nombre_calle,
                                      numero = domicilio.domocilio_numero,
                                      isDelete = domicilio.domocilio_delete
                                  };
            gridDomicilio.DataSource = listaDomicilios.Where(d => d.isDelete == false).ToList();
        }

        private void buscarDomicilio(string textoABuscar)
        {
            var listaDomicilios = from domicilio in dbGimnasio.Domicilios
                                  select new
                                  {
                                      iddomicilio = domicilio.domicilio_iddomicilio,
                                      calle = domicilio.Calle.nombre_calle,
                                      numero = domicilio.domocilio_numero,
                                      isDelete = domicilio.domocilio_delete
                                  };

            gridDomicilio.DataSource = listaDomicilios.Where(d => d.calle.Contains(textoABuscar))
                                                     .Where(d => d.isDelete == false).ToList();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            FrmNuevoEditarDomicilio frmNuevoEditarDomicilio = new FrmNuevoEditarDomicilio(dbGimnasio);
            frmNuevoEditarDomicilio.ShowDialog();
            listarGrillaDomicilios();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (gridDomicilio.Rows.Count > 0 && gridDomicilio.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridDomicilio, 0);

                FrmNuevoEditarDomicilio frmNuevoEditarDomicilio = new FrmNuevoEditarDomicilio(idSeleccionado, dbGimnasio);
                frmNuevoEditarDomicilio.ShowDialog();
                listarGrillaDomicilios();
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
            if (gridDomicilio.Rows.Count > 0 && gridDomicilio.SelectedRows.Count > 0)
            {
                DataGridViewCellCollection celdasFilaActual = gridDomicilio.CurrentRow.Cells;
                int idSeleccionado = (int)celdasFilaActual[0].Value;
                string dimicilioSeleccionado = (string)celdasFilaActual[1].Value;

                string mensaje = "¿Está seguro que desea eliminar: " + dimicilioSeleccionado + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    domicilio = dbGimnasio.Domicilios.Find(idSeleccionado);
                    domicilio.domocilio_delete = true;
                    dbGimnasio.SaveChanges();
                    listarGrillaDomicilios();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarDomicilio(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDomicilio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (gridDomicilio.RowCount > 0 && gridDomicilio.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    iddomicilio = (int)this.gridDomicilio.CurrentRow.Cells[0].Value;
                    calle = this.gridDomicilio.CurrentRow.Cells[1].Value.ToString();
                    numero = (int)this.gridDomicilio.CurrentRow.Cells[2].Value;
                    this.Close();
                }
            }
            
        }

        private void dgvDomicilio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDomicilio.RowCount > 0 && gridDomicilio.SelectedRows.Count > 0)
            {
                iddomicilio = (int)this.gridDomicilio.CurrentRow.Cells[0].Value;
                calle = this.gridDomicilio.CurrentRow.Cells[1].Value.ToString();
                numero = (int)this.gridDomicilio.CurrentRow.Cells[2].Value;
                this.Close();
            }
        }
    }
}
