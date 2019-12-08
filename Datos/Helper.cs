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
    }
}
