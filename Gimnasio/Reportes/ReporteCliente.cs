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

namespace Gimnasio.Reportes
{
    public partial class ReporteCliente : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();

        public ReporteCliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            var listaClientes = from cliente in dbGimnasio.Clientes
                                select new
                                {
                                    clientes_idcliente = cliente.idcliente,
                                    clientes_nombre = cliente.nombre,
                                    clientes_apellido = cliente.apellido,
                                    clientes_fechaIngreso = cliente.fechaIngreso,
                                    clientes_edad = cliente.edad,
                                    clientes_peso = cliente.peso
                                };
            clientesBindingSource.DataSource = listaClientes.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
