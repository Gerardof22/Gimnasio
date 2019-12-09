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
        private int idColumnHide;

        public FrmGestionCalle()
        {
            InitializeComponent();
            this.ListarGrillaCalles();
            Helper.OcultarColumnas(gridCalle, new int[] { 2 });
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
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridCalle, 0);

                FrmNuevoEditarCalle frmNuevoEditarCalle = new FrmNuevoEditarCalle(idSeleccionado, dbGimnasio);
                frmNuevoEditarCalle.ShowDialog();
                ListarGrillaCalles();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridCalle);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridCalle.Rows.Count > 0 && gridCalle.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridCalle, 0);
                string calleSeleccionada = (string)Helper.CeldaFilaActual(gridCalle, 1);

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

        private void gridCalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                idColumnHide = (int)gridCalle[0, e.RowIndex].Value;

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Text = "";
            }
        }
    }
}
