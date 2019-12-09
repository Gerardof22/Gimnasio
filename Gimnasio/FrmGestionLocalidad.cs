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
    public partial class FrmGestionLocalidad : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Localidad localidad;

        public FrmGestionLocalidad()
        {
            InitializeComponent();
            listarLocalidades();
            Helper.OcultarColumnas(gridLocalidad, new int[] { 2 });
        }

        private void listarLocalidades()
        {
            var listaLocalidades = from localidads in dbGimnasio.Localidads
                                   select new
                                   {
                                       idlocalidad = localidads.idlocalidad,
                                       localidad = localidads.localidad,
                                       isDelected = localidads.IsDelete
                                   };
            gridLocalidad.DataSource = listaLocalidades.Where(l => l.isDelected == false).ToList();
        }

        private void buscarLocalidad(string textToSearch)
        {
            var listaLocalidades = from localidads in dbGimnasio.Localidads
                                   select new
                                   {
                                       idlocalidad = localidads.idlocalidad,
                                       localidad = localidads.localidad,
                                       isDelected = localidads.IsDelete
                                   };
            gridLocalidad.DataSource = listaLocalidades.Where(l => l.localidad.Contains(textToSearch))
                                                       .Where(l => l.isDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad(dbGimnasio);
            frmNuevaEditarLocalidad.ShowDialog();
            listarLocalidades();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridLocalidad.Rows.Count > 0 && gridLocalidad.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridLocalidad, 0);

                FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad(idSeleccionado, dbGimnasio);
                frmNuevaEditarLocalidad.ShowDialog();
                listarLocalidades();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridLocalidad);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridLocalidad.Rows.Count > 0 && gridLocalidad.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridLocalidad, 0);
                string localidadSeleccionada = (string)Helper.CeldaFilaActual(gridLocalidad, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + localidadSeleccionada + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    localidad = new Localidad();
                    localidad = dbGimnasio.Localidads.Find(idSeleccionado);
                    localidad.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    listarLocalidades();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarLocalidad(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
