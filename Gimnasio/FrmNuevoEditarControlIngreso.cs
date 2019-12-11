using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            this.CargarComboClientes(0);
        }

        public FrmNuevoEditarControlIngreso(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            control_Ingreso = new Control_Ingreso();
            this.CargarComboClientes(0);
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
            this.CargarComboClientes(control_Ingreso.Cliente.idcliente);
            this.validarTurno();
            dtpFechaIngreso.Value = control_Ingreso.fecha;
        }

        private void validarTurno()
        {
            if (control_Ingreso.turno)
            {
                rbtnMañana.Checked = true;
            }
            else
            {
                rbtnTarde.Checked = true;
            }
        }

        private void CargarComboClientes(int idcliente)
        {
            cboCliente.DataSource = this.CargarClientes();
            //campo que vera el usuario
            cboCliente.DisplayMember = "nombre";

            //campo que es el valor real
            cboCliente.ValueMember = "idcliente";
            cboCliente.SelectedValue = idcliente;


            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Cliente cliente in dbGimnasio.Clientes)
            {
                string nom_apel = cliente.nombre + " " + cliente.apellido;
                autoCompletadoCbo.Add(nom_apel);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboCliente.AutoCompleteCustomSource = autoCompletadoCbo;

        }

        private IList CargarClientes()
        {
            var clientes = from c in dbGimnasio.Clientes
                           select new
                           {
                               idcliente = c.idcliente,
                               nombre = c.nombre + " " + c.apellido
                           };
            return clientes.ToList();
        }

        private void Turnos()
        {
            if (rbtnMañana.Checked)
            {
                control_Ingreso.turno = true;
            }
            else
            {
                if (rbtnTarde.Checked)
                {
                    control_Ingreso.turno = false;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Lo cargamos de este modo porque el combo esta cargado con tipos anonimos.
                control_Ingreso.Cliente = dbGimnasio.Clientes.Find(cboCliente.SelectedValue); 
                this.Turnos();
                control_Ingreso.fecha = dtpFechaIngreso.Value;

                if (control_Ingreso.idcontrolingreso > 0)
                {
                    dbGimnasio.Entry(control_Ingreso).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (cboCliente.SelectedIndex != -1)
                    {
                        dbGimnasio.Control_Ingresos.Add(control_Ingreso);
                        dbGimnasio.SaveChanges();
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Se debe seleccionar un Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboCliente.Focus();
                    }
                }
            }
            catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
            {
                foreach (var dbEntityValidation in ex.EntityValidationErrors)
                {
                    Console.WriteLine("El tipo de entidad \"{0}\" en el estado \"{1}\" tiene los siguientes errores de validación:",
                        dbEntityValidation.Entry.Entity.GetType().Name, dbEntityValidation.Entry.State);
                    foreach (var ve in dbEntityValidation.ValidationErrors)
                    {
                        Console.WriteLine("- Propiedad: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            FrmGestionControlIngreso.botonGuardarPresionado = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente();
            frmNuevoEditarCliente.ShowDialog();
            if (frmNuevoEditarCliente.cliente.idcliente != 0)
            {
                this.CargarComboClientes(frmNuevoEditarCliente.cliente.idcliente);
            }
        }
    }
}
