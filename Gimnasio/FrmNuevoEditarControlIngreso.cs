using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmNuevoEditarControlIngreso : Form
    {
        GimnasioContext dbGimnasio;
        Control_Ingreso control_Ingreso;

        public FrmNuevoEditarControlIngreso()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            control_Ingreso = new Control_Ingreso();
            this.cargarComboClientes(0);
        }

        public FrmNuevoEditarControlIngreso(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            control_Ingreso = new Control_Ingreso();
            this.cargarComboClientes(0);
        }

        public FrmNuevoEditarControlIngreso(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            control_Ingreso = new Control_Ingreso();
            this.cargarIngreso(idSeleccionado);
        }

        private void cargarIngreso(int idSeleccionado)
        {
            control_Ingreso = dbGimnasio.Control_Ingresos.Find(idSeleccionado);
            this.cargarComboClientes(control_Ingreso.Cliente.clientes_idcliente);
            this.validarTurno();
            dtpFechaIngreso.Value = control_Ingreso.control_ingreso_fecha;
        }

        private void validarTurno()
        {
            if (control_Ingreso.control_ingreso_turno)
            {
                rbtnMañana.Checked = true;
            }
            else
            {
                rbtnTarde.Checked = true;
            }
        }

        private void cargarComboClientes(int idcliente)
        {
            cboCliente.DataSource = dbGimnasio.Clientes.ToList();
            //campo que vera el usuario
            cboCliente.DisplayMember = "clientes_nombre";

            //campo que es el valor real
            cboCliente.ValueMember = "clientes_idcliente";
            cboCliente.SelectedValue = idcliente;
        }

        private void Turnos()
        {
            if (rbtnMañana.Checked)
            {
                control_Ingreso.control_ingreso_turno = true;
            }
            else
            {
                if (rbtnTarde.Checked)
                {
                    control_Ingreso.control_ingreso_turno = false;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            control_Ingreso.Cliente = (Cliente)this.cboCliente.SelectedItem;
            this.Turnos();
            control_Ingreso.control_ingreso_fecha = dtpFechaIngreso.Value;

            if (control_Ingreso.control_ingreso_idcontrolingreso > 0)
            {
                dbGimnasio.Entry(control_Ingreso).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Control_Ingresos.Add(control_Ingreso);
                MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dbGimnasio.SaveChanges();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
