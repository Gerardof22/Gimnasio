using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class Helper
    {
        /// <summary>
        /// Selecciona la fila que fue editada.
        /// </summary>
        /// <param name="idSeleccionado">Id de la fila seleccionada para editar</param>
        /// <param name="dataGridView">Nombre del DataGridView</param>
        public static void SeleccionarFilaActivaEditada(int idSeleccionado, DataGridView dataGridView)
        {
            if (idSeleccionado != 0)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (idSeleccionado == (int)dataGridView.Rows[i].Cells[0].Value)
                    {
                        dataGridView.Rows[i].Selected = true;
                        //Seleccionamos la primera celda para que esté visible.
                        dataGridView.CurrentCell = dataGridView.Rows[i].Cells[0];
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Oculta las columnas de un DataGridView.
        /// </summary>
        /// <param name="dataGridView">Bombre del DataGridView</param>
        /// <param name="column">Indices de columnas que se desean ocultar.</param>
        public static void OcultarColumnas(DataGridView dataGridView, int[] column)
        {
            for (int i = 0; i < column.Length; i++)
            {
                dataGridView.Columns[column[i]].Visible = false;
            }
        }

        /// <summary>
        /// Obtiene la celda y la fila actual seleccionada.
        /// </summary>
        /// <param name="dataGridView"> Corresponde al nombre del DataGridView.</param>
        /// <param name="column">Correspone al índice de columna del DataGridView.</param>
        /// <returns>Retorna un object.</returns>
        public static object CeldaFilaActual(DataGridView dataGridView, int column)
        {
            DataGridViewCellCollection celdasFilaActual = dataGridView.CurrentRow.Cells;

            return celdasFilaActual[column].Value;
        }
    }
}
