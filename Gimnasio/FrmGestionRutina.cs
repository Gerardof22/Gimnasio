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
    public partial class FrmGestionRutina : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Rutina rutina = new Rutina();

        public FrmGestionRutina()
        {
            InitializeComponent();
            this.CargarGrillaRutunas();
        }

        private void CargarGrillaRutunas()
        {
            var listaRutinas = from r in dbGimnasio.Rutinas
                               select new
                               {
                                   idrutina = r.idrutina,
                                   fechaDesde = r.fechaDesde,
                                   fechaHasta = r.fechaHasta,
                                   serie = r.serie,
                                   repeticion = r.repeticion,
                                   tiempoDuracion = r.tiempoduracion,
                                   descanso = r.descanso,
                                   pesoKG = r.pesokg,
                                   Cardio = r.Cardio.duracion + " " + r.Cardio.ritmo,
                                   Calentamiento = r.Calentamiento.duracion + " " + r.Calentamiento.descripcion,
                                   IsDelected = r.IsDelete
                               };

            gridRutina.DataSource = listaRutinas.Where(r => r.IsDelected == false).ToList();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridRutina.Rows.Count > 0 && gridRutina.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridRutina, 0);

                FrmEditarRutina frmEditarRutina = new FrmEditarRutina(idSeleccionado, dbGimnasio);
                frmEditarRutina.ShowDialog();
                CargarGrillaRutunas();
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
            if (gridRutina.Rows.Count > 0 && gridRutina.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridRutina, 0);
                string calleSeleccionada = (string)celdaFilaActual(gridRutina, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + calleSeleccionada + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    rutina = dbGimnasio.Rutinas.Find(idSeleccionado);
                    rutina.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    CargarGrillaRutunas();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
