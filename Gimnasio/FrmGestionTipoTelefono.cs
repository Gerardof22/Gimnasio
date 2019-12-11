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
    public partial class FrmGestionTipoTelefono : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Tipo_Telefono tipo_Telefono = new Tipo_Telefono();

        public FrmGestionTipoTelefono()
        {
            InitializeComponent();
            this.ListarGrillaTipoTelefonos();
            Helper.OcultarColumnas(gridTipoTelefono, new int[] { 2 });
        }

        private void ListarGrillaTipoTelefonos()
        {
            var listaTipoTelefono = from tipoT in dbGimnasio.Tipos_Telefonos
                                    select new
                                    {
                                        id = tipoT.idtipotelefono,
                                        tipo = tipoT.tipo_telefono,
                                        IsDelected = tipoT.IsDelete
                                    };

            gridTipoTelefono.DataSource = listaTipoTelefono.Where(t => t.IsDelected == false).ToList(); 
        }

        private void BuscarTipoTelefonos(string TextToSearch)
        {
            var listaTipoTelefono = from tipoT in dbGimnasio.Tipos_Telefonos
                                    select new
                                    {
                                        id = tipoT.idtipotelefono,
                                        tipo = tipoT.tipo_telefono,
                                        IsDelected = tipoT.IsDelete
                                    };

            gridTipoTelefono.DataSource = listaTipoTelefono.Where(t => t.tipo.Contains(TextToSearch))
                                                           .Where(t => t.IsDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoTelefono tipoTelefono = new FrmNuevoEditarTipoTelefono(dbGimnasio);
            tipoTelefono.ShowDialog();
            ListarGrillaTipoTelefonos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridTipoTelefono.Rows.Count > 0 && gridTipoTelefono.SelectedRows.Count > 0 && gridTipoTelefono.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTipoTelefono, 0);

                FrmNuevoEditarTipoTelefono tipoTelefono = new FrmNuevoEditarTipoTelefono(idSeleccionado, dbGimnasio);
                tipoTelefono.ShowDialog();
                ListarGrillaTipoTelefonos();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridTipoTelefono);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridTipoTelefono.Rows.Count > 0 && gridTipoTelefono.SelectedRows.Count > 0 && gridTipoTelefono.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTipoTelefono, 0);
                string TipoTelefonoSeleccionado = (string)Helper.CeldaFilaActual(gridTipoTelefono, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + TipoTelefonoSeleccionado + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    tipo_Telefono = dbGimnasio.Tipos_Telefonos.Find(idSeleccionado);
                    tipo_Telefono.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    ListarGrillaTipoTelefonos();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarTipoTelefonos(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
