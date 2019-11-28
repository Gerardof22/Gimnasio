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
                                    clientes_idcliente = cliente.clientes_idcliente,
                                    clientes_nombre = cliente.clientes_nombre,
                                    clientes_apellido = cliente.clientes_apellido,
                                    clientes_fechaIngreso = cliente.clientes_fechaIngreso,
                                    clientes_edad = cliente.clientes_edad,
                                    clientes_peso = cliente.clientes_peso
                                };
            clientesBindingSource.DataSource = listaClientes.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
