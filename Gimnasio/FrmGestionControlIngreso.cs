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
    public partial class FrmGestionControlIngreso : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Control_Ingreso control_Ingreso;

        public FrmGestionControlIngreso()
        {
            InitializeComponent();
            this.listarControlIngreso();
        }

        private void listarControlIngreso()
        {
            var listaControlIngreso = from controlIngreso in dbGimnasio.Control_Ingresos
                                       select new
                                       {
                                           idcontrol = controlIngreso.idcontrolingreso,
                                           cliente = controlIngreso.Cliente.nombre + " " + controlIngreso.Cliente.apellido,
                                           turno = controlIngreso.turno,
                                           fecha = controlIngreso.fecha,
                                           isDelected = controlIngreso.IsDelete
                                       };
            gridControlIngreso.DataSource = listaControlIngreso.Where(ctrl => ctrl.isDelected == false).ToList();
        }

        private void buscarControlIngreso(string textToSearch)
        {
            var listaControlIngreso = from controlIngreso in dbGimnasio.Control_Ingresos
                                      select new
                                      {
                                          idcontrol = controlIngreso.idcontrolingreso,
                                          cliente = controlIngreso.Cliente.nombre + " " + controlIngreso.Cliente.apellido,
                                          turno = controlIngreso.turno,
                                          fecha = controlIngreso.fecha,
                                          isDelected = controlIngreso.IsDelete
                                      };
            gridControlIngreso.DataSource = listaControlIngreso.Where(ctrl => ctrl.cliente.Contains(textToSearch))
                                                               .Where(ctrl => ctrl.isDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarControlIngreso frmNuevoEditarControlIngreso = new FrmNuevoEditarControlIngreso(dbGimnasio);
            frmNuevoEditarControlIngreso.ShowDialog();
            listarControlIngreso();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridControlIngreso.Rows.Count > 0 && gridControlIngreso.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridControlIngreso, 0);

                FrmNuevoEditarControlIngreso frmNuevoEditarControlIngreso = new FrmNuevoEditarControlIngreso(idSeleccionado, dbGimnasio);
                frmNuevoEditarControlIngreso.ShowDialog();
                listarControlIngreso();
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridControlIngreso.Rows.Count > 0 && gridControlIngreso.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridControlIngreso, 0);
                string clienteSeleccionado = (string)celdaFilaActual(gridControlIngreso, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + clienteSeleccionado + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    control_Ingreso = new Control_Ingreso();
                    control_Ingreso = dbGimnasio.Control_Ingresos.Find(idSeleccionado);
                    control_Ingreso.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    listarControlIngreso();
                }
            }
        }
        
        /// <summary>
        /// Obtiene la celda y la fila actual seleccionada.
        /// </summary>
        /// <param name="dataGridView"> Nombre del DataGridView.</param>
        /// <param name="column">Índice de columna del DataGridView.</param>
        /// <returns>Retorna un object.</returns>
        private object celdaFilaActual(DataGridView dataGridView, int column)
        {
            DataGridViewCellCollection celdasFilaActual = dataGridView.CurrentRow.Cells;

            return celdasFilaActual[column].Value;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarControlIngreso(txtBuscar.Text);
        }
    }
}
