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
            Helper.OcultarColumnas(gridGestionTelefono, new int[] { 4 });
        }

        private void cargarGrillaTelefonos()
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

            gridGestionTelefono.DataSource = listaTelefonos.Where(t => t.isDelected == false).ToList();
        }

        private void BuscarTelefonos(string textoABuscar)
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
                                                           .Where(t => t.isDelected == false).ToList();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (gridGestionTelefono.Rows.Count > 0 && gridGestionTelefono.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridGestionTelefono, 0);
                string numTelefonoSeleccionado = (string)Helper.CeldaFilaActual(gridGestionTelefono, 3);

                FrmNuevoEditarTelefono frmNuevoEditarTelefono = new FrmNuevoEditarTelefono(idSeleccionado, dbGimnasio);
                frmNuevoEditarTelefono.ShowDialog();
                this.cargarGrillaTelefonos();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridGestionTelefono);
            }    
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (gridGestionTelefono.Rows.Count > 0 && gridGestionTelefono.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridGestionTelefono, 0);
                string telefonoSeleccionado = (string)Helper.CeldaFilaActual(gridGestionTelefono, 2);

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

        private void txtBuscar_TextChanged(object sender, System.EventArgs e)
        {
            this.BuscarTelefonos(txtBuscar.Text);
        }

        private void gridGestionTelefono_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
