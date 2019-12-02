using Datos;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmGestionTelefono : Form
    {
        private GimnasioContext dbGimnasio = new GimnasioContext();
        Telefono telefono = new Telefono();

        public int idTelefono { get; set; }
        public int idTipoTelefono { get; set; }
        public string tipoTelefono { get; set; }
        public string numeroTelefono { get; set; }


        public FrmGestionTelefono()
        {
            InitializeComponent();
            cargarGrillaTelefonos();
        }

        private void cargarGrillaTelefonos()
        {
            var listaTelefonos = from telefono in dbGimnasio.Telefonos
                                     /*join tipoTelefono in dbGimnasio.Tipo_Telefonos on telefono.telefono_idtipotelefono equals tipoTelefono.tipo_telefono_idtipotelefono
                                 /*join cliente in dbGimnasio.Clientes on telefono.telefono_idcliente equals cliente.clientes_idcliente*/
                                 select new
                                 {
                                     idtelefono = telefono.idtelefono,
                                     idtipotelefono = telefono.Tipos_Telefonos.idtipotelefono,
                                     tipotelefono = telefono.Tipos_Telefonos.tipo_telefono,
                                     //cliente = cliente.clientes_nombre + " " + cliente.clientes_apellido,
                                     numero = telefono.numero,
                                     isDelected = telefono.IsDelete
                                 };

            gridGestionTelefono.DataSource = listaTelefonos.Where(t => t.isDelected == false).ToList();
        }

        private void cargarGrillaTelefonos(string textoABuscar)
        {
            var listaTelefonos = from telefono in dbGimnasio.Telefonos
                                 join tipoTelefono in dbGimnasio.Tipos_Telefonos on telefono.idtipotelefono equals tipoTelefono.idtipotelefono
                                 join cliente in dbGimnasio.Clientes on telefono.idcliente equals cliente.idcliente
                                 select new
                                 {
                                     idtelefono = telefono.idtelefono,
                                     tipotelefono = tipoTelefono.tipo_telefono,
                                     cliente = cliente.nombre + " " + cliente.apellido,
                                     numero = telefono.numero,
                                     isDelected = telefono.IsDelete
                                 };

            gridGestionTelefono.DataSource = listaTelefonos.Where(t => t.cliente.Contains(textoABuscar))
                                                           .Where(t => t.tipotelefono.Contains(textoABuscar))
                                                           .Where(t => t.numero.Contains(textoABuscar))
                                                           .Where(t => t.isDelected == false).ToList();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (gridGestionTelefono.Rows.Count > 0 && gridGestionTelefono.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)this.celdaFilaActual(gridGestionTelefono, 0);
                string numTelefonoSeleccionado = (string)this.celdaFilaActual(gridGestionTelefono, 3);

                FrmNuevoEditarTelefono frmNuevoEditarTelefono = new FrmNuevoEditarTelefono(idSeleccionado, dbGimnasio);
                frmNuevoEditarTelefono.ShowDialog();
                this.cargarGrillaTelefonos();
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

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (gridGestionTelefono.Rows.Count > 0 && gridGestionTelefono.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridGestionTelefono, 0);
                string telefonoSeleccionado = (string)celdaFilaActual(gridGestionTelefono, 2);

                string mensaje = "¿Está seguro que desea eliminar: " + telefonoSeleccionado + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    telefono = dbGimnasio.Telefonos.Find(idSeleccionado);
                    telefono.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    cargarGrillaTelefonos();
                }
            }
        }

        private void btnNuevoTipo_Click(object sender, System.EventArgs e)
        {
            FrmNuevoEditarTipoTelefono frmNuevoEditarTipoTelefono = new FrmNuevoEditarTipoTelefono(dbGimnasio);
            frmNuevoEditarTipoTelefono.ShowDialog();
        }

        private void gridGestionTelefono_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (gridGestionTelefono.RowCount > 0 && gridGestionTelefono.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    idTelefono = (int)this.gridGestionTelefono.CurrentRow.Cells[0].Value;
                    idTipoTelefono = (int)this.gridGestionTelefono.CurrentRow.Cells[1].Value;
                    tipoTelefono = this.gridGestionTelefono.CurrentRow.Cells[2].Value.ToString();
                    numeroTelefono = this.gridGestionTelefono.CurrentRow.Cells[3].Value.ToString();
                    this.Close();
                }
            }
        }

        private void gridGestionTelefono_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            idTelefono = (int)this.gridGestionTelefono.CurrentRow.Cells[0].Value;
            idTipoTelefono = (int)this.gridGestionTelefono.CurrentRow.Cells[1].Value;
            tipoTelefono = this.gridGestionTelefono.CurrentRow.Cells[2].Value.ToString();
            numeroTelefono = this.gridGestionTelefono.CurrentRow.Cells[3].Value.ToString();
            this.Close();
            
        }
    }
}
