﻿using System;
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
    }
}
