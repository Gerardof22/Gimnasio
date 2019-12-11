using Datos;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmNuevoEditarCliente : Form
    {
        GimnasioContext dbGimnasio;

        public Cliente cliente;

        Telefono telefono;

        public FrmNuevoEditarCliente()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            cliente = new Cliente();
            cargarComboLocalidad(0);
        }

        public FrmNuevoEditarCliente(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            cliente = new Cliente();
            cargarComboLocalidad(0);

        }

        public FrmNuevoEditarCliente(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            cliente = new Cliente();
            cargarCliente(idSeleccionado);
        }

        private void cargarCliente(int idSeleccionado)
        {
            cliente                 = dbGimnasio.Clientes.Find(idSeleccionado);
            txtNombre.Text          = cliente.nombre;
            txtApellido.Text        = cliente.apellido;
            dtpFechaNacimiento.Value = cliente.fechaNacimiento;
            txtEdad.Text            = cliente.edad.ToString();
            validateGenero();
            cargarComboLocalidad(cliente.Localidad.idlocalidad);
            dtpFechaIngreso.Value   = cliente.fechaIngreso;
            cliente.Domicilio       = dbGimnasio.Domicilios.Find((int)cliente.Domicilio.iddomicilio);
            txtNombreCalle.Text     = cliente.Domicilio.Calle.nombre_calle;
            txtNumCalle.Text        = cliente.Domicilio.numero.ToString();
            cargarGrillaTelefono(idSeleccionado);
            txtObjetivos.Text       = cliente.objetivos;
            txtLecturaCorporal.Text = cliente.lecturaCorporal;
            if (cliente.peso == 0)
            {
                txtPeso.Text = "";
            }
            else
            {
                txtPeso.Text = cliente.peso.ToString();
            }
        }

        private void cargarGrillaTelefono()
        {
            if (cliente.Telefonos != null)
            {
                var listaTelefonos = from telefono in cliente.Telefonos
                                     select new
                                     {
                                         idtelefono = telefono.idtelefono,
                                         tipotelefono = telefono.Tipos_Telefonos.tipo_telefono,
                                         numero = telefono.numero,
                                         isDelected = telefono.IsDelete
                                     };

                gridTelefonos.DataSource = listaTelefonos.Where(t => t.isDelected == false).ToList();
            }
        }

        private void cargarGrillaTelefono(int idSeleccionado)
        {
            var listaTelefonos = from telefonos in cliente.Telefonos
                                 //Validamos el campo idcliente de la tabla para que nos ignore aquellos que son null,
                                 //sí no hariamos esta validación nos daria un error de referencia nula en el bloque select new
                                 where telefonos.Cliente.idcliente != null && telefonos.idtelefono != null
                                 select new
                                 {
                                     idcliente = telefonos.Cliente.idcliente,
                                     idtelefono = telefonos.idtelefono,
                                     tipo = telefonos.Tipos_Telefonos.tipo_telefono,
                                     numero = telefonos.numero
                                 };
            gridTelefonos.DataSource = listaTelefonos.Where(t => t.idcliente == idSeleccionado).ToList();
        }

        private void cargarComboLocalidad(int idlocalidad)
        {
            cboLocalidad.DataSource = dbGimnasio.Localidads.Where(l => l.IsDelete == false).ToList();
            //campo que vera el usuario
            cboLocalidad.DisplayMember = "localidad";

            //campo que es el valor real
            cboLocalidad.ValueMember = "idlocalidad";
            cboLocalidad.SelectedValue = idlocalidad;
        }

        private void validateGenero()
        {
            if (cliente.genero)
            {
                rbtnHombre.Checked = true;
            }
            else
            {
                rbtnMujer.Checked = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.nombre = txtNombre.Text;
                cliente.apellido = txtApellido.Text;
                cliente.fechaNacimiento = dtpFechaNacimiento.Value;
                cliente.edad = Int32.Parse(CalcularEdad(dtpFechaNacimiento.Value).ToString());
                genero();
                cliente.Localidad = (Localidad)cboLocalidad.SelectedItem;
                cliente.fechaIngreso = dtpFechaIngreso.Value;
                if (dbGimnasio.Domicilios.Find(FrmGestionDomicilio.iddomicilio) != null)
                {
                    cliente.Domicilio = dbGimnasio.Domicilios.Find(FrmGestionDomicilio.iddomicilio);
                }
                cliente.objetivos = txtObjetivos.Text;
                cliente.lecturaCorporal = txtLecturaCorporal.Text;
                if (!string.IsNullOrEmpty(txtPeso.Text))
                {
                    cliente.peso = float.Parse(txtPeso.Text);
                }

                if (cliente.idcliente > 0)
                {
                    dbGimnasio.Entry(cliente).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (this.IsValidate())
                    {
                        dbGimnasio.Clientes.Add(cliente);
                        dbGimnasio.SaveChanges();
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los campos de Nombre, Apellido, Localidad, Domicilio y Peso son requeridos, por favor complete todos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private bool IsValidate()
        {
            if (dbGimnasio.Domicilios.Find(FrmGestionDomicilio.iddomicilio) != null && cboLocalidad.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtPeso.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void genero()
        {
            if (rbtnHombre.Checked)
            {
                cliente.genero = true;
            }
            else
            {
                if (rbtnMujer.Checked)
                {
                    cliente.genero = false;
                }
            }
        }

        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad();
            frmNuevaEditarLocalidad.ShowDialog();
            cargarComboLocalidad(frmNuevaEditarLocalidad.localidad.idlocalidad);
        }

        private void btnSeleccionarDomicilio_Click(object sender, EventArgs e)
        {
            FrmGestionDomicilio frmGestionDomicilio = new FrmGestionDomicilio();
            frmGestionDomicilio.ShowDialog();
            if (frmGestionDomicilio.calle != "" && frmGestionDomicilio.numero != 0)
            {
                txtNombreCalle.Text = frmGestionDomicilio.calle;
                txtNumCalle.Text = frmGestionDomicilio.numero.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTelefono frmNuevoEditarTelefono = new FrmNuevoEditarTelefono();
            frmNuevoEditarTelefono.ShowDialog();
            if (FrmNuevoEditarTelefono.idtipotelefono != 0 && FrmNuevoEditarTelefono.numero != "")
            {
                agregarAGrillaTelefono();
                cargarGrillaTelefono();
                Helper.OcultarColumnas(gridTelefonos, new int[] { 0, 3 });
            }
        }

        private void agregarAGrillaTelefono()
        {
            if (dbGimnasio.Tipos_Telefonos.Find(FrmNuevoEditarTelefono.idtipotelefono) != null)
            {
                telefono = new Telefono();
                telefono.idtelefono = FrmNuevoEditarTelefono.idtelefono;
                telefono.idtipotelefono = FrmNuevoEditarTelefono.idtipotelefono;
                telefono.Tipos_Telefonos = dbGimnasio.Tipos_Telefonos.Find(FrmNuevoEditarTelefono.idtipotelefono);
                telefono.numero = FrmNuevoEditarTelefono.numero.ToString();

                if (cliente.Telefonos == null)
                {
                    cliente.Telefonos = new ObservableCollection<Telefono>();
                }
                cliente.Telefonos.Add(telefono);

                FrmNuevoEditarTelefono.idtipotelefono = 0;
                FrmNuevoEditarTelefono.numero = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gridTelefonos.Rows.Count > 0 && gridTelefonos.SelectedRows.Count > 0 && gridTelefonos.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTelefonos, 0);

                string mensaje = "¿Está seguro que desea quitar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    int idDetalleSeleccionado = gridTelefonos.CurrentRow.Index;
                    cliente.Telefonos.RemoveAt(idDetalleSeleccionado);
                    cargarGrillaTelefono();
                }
            }
        }

        public int CalcularEdad(DateTime FechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int edad = now.Year - FechaNacimiento.Year;

            if (FechaNacimiento.AddYears(edad) > now)
            {
                edad--;
            }

            return edad;
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            txtEdad.Text = CalcularEdad(dtpFechaNacimiento.Value).ToString();
        }

        private void FrmNuevoEditarCliente_Load(object sender, EventArgs e)
        {
            //DisableControls(this);
        }

        private void DisableControls(Control con)
        {
            foreach (Control control in con.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox groupBox = (GroupBox)control;
                    groupBox.Enabled = false;
                }

                if (control is Button)
                {
                    Button button = (Button)control;
                    if (button.Name == btnGuardar.Name)
                    {
                        button.Enabled = false;
                    }
                }
            }
            
        }
    }
}
