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

        private void gestiónEjercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionEjercicio frmGestionEjercicio = new FrmGestionEjercicio();
            frmGestionEjercicio.ShowDialog();
        }

        private void nuevaRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarRutina frmNuevoEditarRutina = new FrmNuevoEditarRutina();
            frmNuevoEditarRutina.ShowDialog();
        }

        private void gestiónRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gestiónCallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionCalle frmGestionCalle = new FrmGestionCalle();
            frmGestionCalle.ShowDialog();
        }

        private void nuevoEjercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarEjercicio frmNuevoEditarEjercicio = new FrmNuevoEditarEjercicio();
            frmNuevoEditarEjercicio.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema realizado por Gerardo Ferreyra.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void entrenamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema realizado por Gerardo Ferreyra.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente();
            frmNuevoEditarCliente.ShowDialog();
        }

        private void gestiónClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGestionClientes frmGestionClientes = new FrmGestionClientes();
            frmGestionClientes.ShowDialog();
        }

        private void nuevoIngresoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarControlIngreso frmNuevoEditarControlIngreso = new FrmNuevoEditarControlIngreso();
            frmNuevoEditarControlIngreso.ShowDialog();
        }

        private void gestiónDeIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionControlIngreso frmGestionControlIngreso = new FrmGestionControlIngreso();
            frmGestionControlIngreso.ShowDialog();
        }

        private void nuevoDomicilioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarDomicilio frmNuevoEditarDomicilio = new FrmNuevoEditarDomicilio();
            frmNuevoEditarDomicilio.ShowDialog();
        }

        private void gestiónDomicilioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionDomicilio frmGestionDomicilio = new FrmGestionDomicilio();
            frmGestionDomicilio.ShowDialog();
        }

        private void nuevoTelefonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTelefono frmNuevoEditarTelefono = new FrmNuevoEditarTelefono();
            frmNuevoEditarTelefono.ShowDialog();
        }

        private void nuevoTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoTelefono frmNuevoEditarTipoTelefono = new FrmNuevoEditarTipoTelefono();
            frmNuevoEditarTipoTelefono.ShowDialog();
        }

        private void gestiónDeTiposDeTelefonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionTipoTelefono frmGestionTipoTelefono = new FrmGestionTipoTelefono();
            frmGestionTipoTelefono.ShowDialog();
        }

        private void nuevaCobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCobranza frmCobranza = new FrmCobranza();
            frmCobranza.ShowDialog();
        }

        private void nuevoEjercicioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarEjercicio frmNuevoEditarEjercicio = new FrmNuevoEditarEjercicio();
            frmNuevoEditarEjercicio.ShowDialog();
        }

        private void nuevoCalentamientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCalentamiento frmNuevoEditarCalentamiento = new FrmNuevoEditarCalentamiento();
            frmNuevoEditarCalentamiento.ShowDialog();
        }

        private void nuevoCardioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCardio frmNuevoEditarCardio = new FrmNuevoEditarCardio();
            frmNuevoEditarCardio.ShowDialog();
        }

        private void gestiónCardioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionCardio frmGestionCardio = new FrmGestionCardio();
            frmGestionCardio.ShowDialog();
        }

        private void gestiónTiposDeCalentamientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGestionTipoCalentamiento frmGestionTipoCalentamiento = new FrmGestionTipoCalentamiento();
            frmGestionTipoCalentamiento.ShowDialog();
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministracionUsuarios frmAdministracionUsuarios = new FrmAdministracionUsuarios();
            frmAdministracionUsuarios.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void administradorTipoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministradorTipoUsuario frmAdministradorTipoUsuario = new FrmAdministradorTipoUsuario();
            frmAdministradorTipoUsuario.ShowDialog();
        }
    }
}
