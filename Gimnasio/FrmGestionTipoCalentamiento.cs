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
    public partial class FrmGestionTipoCalentamiento : Form
    {

        GimnasioContext dbGimnasio = new GimnasioContext();
        Tipo_Calentamiento tipo_Calentamiento = new Tipo_Calentamiento();


        public FrmGestionTipoCalentamiento()
        {
            InitializeComponent();
            this.ListarTiposCalentamientos();
            Helper.OcultarColumnas(gridTipoCalentamiento, new int[] { 2 });
        }

        private void ListarTiposCalentamientos()
        {
            var listaTipoCalentamiento = from tc in dbGimnasio.Tipos_Calentamientos
                                         select new
                                         {
                                             id = tc.idtipocalentamiento,
                                             nombre_calentamiento = tc.nombre,
                                             IsDelected = tc.IsDelete
                                         };

            gridTipoCalentamiento.DataSource = listaTipoCalentamiento.Where(tc => tc.IsDelected == false).ToList();
        }

        private void BuscarTiposCalentamientos(string TextToSearch)
        {
            var listaTipoCalentamiento = from tc in dbGimnasio.Tipos_Calentamientos
                                         select new
                                         {
                                             id = tc.idtipocalentamiento,
                                             nombre_calentamiento = tc.nombre,
                                             IsDelected = tc.IsDelete
                                         };

            gridTipoCalentamiento.DataSource = listaTipoCalentamiento.Where(tc => tc.nombre_calentamiento.Contains(TextToSearch))
                                                                     .Where(tc => tc.IsDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoTipoCalentamiento frmNuevoTipoCalentamiento = new FrmNuevoTipoCalentamiento(dbGimnasio);
            frmNuevoTipoCalentamiento.ShowDialog();
            ListarTiposCalentamientos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridTipoCalentamiento.Rows.Count > 0 && gridTipoCalentamiento.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTipoCalentamiento, 0);

                FrmNuevoTipoCalentamiento frmNuevoTipoCalentamiento = new FrmNuevoTipoCalentamiento(idSeleccionado, dbGimnasio);
                frmNuevoTipoCalentamiento.ShowDialog();
                ListarTiposCalentamientos();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridTipoCalentamiento);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridTipoCalentamiento.Rows.Count > 0)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTipoCalentamiento, 0);

                string mensaje = "¿Está seguro que desea eliminar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    tipo_Calentamiento = dbGimnasio.Tipos_Calentamientos.Find(idSeleccionado);
                    tipo_Calentamiento.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    ListarTiposCalentamientos();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarTiposCalentamientos(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
