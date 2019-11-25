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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente();
            frmNuevoEditarCliente.ShowDialog();
        }

        private void gestiónClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionClientes frmGestionClientes = new FrmGestionClientes();
            frmGestionClientes.ShowDialog();
        }

        private void nuevoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarControlIngreso frmNuevoEditarControlIngreso = new FrmNuevoEditarControlIngreso();
            frmNuevoEditarControlIngreso.ShowDialog();
        }

        private void gestiónIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionControlIngreso frmGestionControlIngreso = new FrmGestionControlIngreso();
            frmGestionControlIngreso.ShowDialog();
        }

        private void nuevaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad();
            frmNuevaEditarLocalidad.ShowDialog();
        }

        private void gestiónLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionLocalidad frmGestionLocalidad = new FrmGestionLocalidad();
            frmGestionLocalidad.ShowDialog();
        }

        private void nuevaCobranzaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCobranza frmCobranza = new FrmCobranza();
            frmCobranza.ShowDialog();
        }

        private void gestiónTelefonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionTelefono frmGestionTelefono = new FrmGestionTelefono();
            frmGestionTelefono.ShowDialog();
        }
    }
}
