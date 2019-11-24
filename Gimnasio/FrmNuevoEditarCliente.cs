using Datos;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
            txtNombre.Text          = cliente.clientes_nombre;
            txtApellido.Text        = cliente.clientes_apellido;
            txtEdad.Text            = cliente.clientes_edad.ToString();
            validateGenero();
            cargarComboLocalidad(cliente.localidad.localidad_idlocalidad);
            dtpFechaIngreso.Value   = cliente.clientes_fechaIngreso;
            cliente.domicilio       = dbGimnasio.Domicilios.Find((int)cliente.domicilio.domicilio_iddomicilio);
            txtNombreCalle.Text     = cliente.domicilio.domicilio_calle;
            txtNumCalle.Text        = cliente.domicilio.domocilio_numero.ToString();
            cargarGrillaTelefono(idSeleccionado);
            txtObjetivos.Text       = cliente.clientes_objetivos;
            txtLecturaCorporal.Text = cliente.clientes_lecturaCorporal;
            txtPeso.Text            = cliente.clientes_peso.ToString();
        }

        private void cargarGrillaTelefono()
        {
            if (cliente.Telefonos != null)
            {
                var listaTelefonos = from telefono in cliente.Telefonos
                                     select new
                                     {
                                         //idtelefono = telefono.telefono_idtelefono,
                                         //idtipotelefono = telefono.Tipos_Telefonos.tipo_telefono_idtipotelefono,
                                         tipotelefono = telefono.Tipos_Telefonos.tipo_telefono_telefono,
                                         numero = telefono.telefono_numero,
                                         isDelected = telefono.telefono_delete
                                     };

                gridTelefonos.DataSource = listaTelefonos.Where(t => t.isDelected == false).ToList();
            }
        }

        private void cargarGrillaTelefono(int idSeleccionado)
        {
            var listaTelefonos = from telefonos in cliente.Telefonos
                                 //Validamos el campo idcliente de la tabla para que nos ignore aquellos que son null,
                                 //sí no hariamos esta validación nos daria un error de referencia nula en el bloque select new
                                 where telefonos.Cliente.clientes_idcliente != null 
                                 select new
                                 {
                                     idcliente = telefonos.Cliente.clientes_idcliente,
                                     tipo = telefonos.Tipos_Telefonos.tipo_telefono_telefono,
                                     numero = telefonos.telefono_numero
                                 };
            gridTelefonos.DataSource = listaTelefonos.Where(t => t.idcliente == idSeleccionado).ToList();
        }

        private void cargarComboLocalidad(int idlocalidad)
        {
            cboLocalidad.DataSource = dbGimnasio.Localidads.ToList();
            //campo que vera el usuario
            cboLocalidad.DisplayMember = "localidad_localidad";

            //campo que es el valor real
            cboLocalidad.ValueMember = "localidad_idlocalidad";
            cboLocalidad.SelectedValue = idlocalidad;
        }

        private void validateGenero()
        {
            if (cliente.clientes_genero)
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
            //telefono = new Telefono();
            cliente.clientes_nombre = txtNombre.Text;
            cliente.clientes_apellido = txtApellido.Text;
            cliente.clientes_edad = Int32.Parse(txtEdad.Text);
            genero();
            cliente.localidad = (Localidad)cboLocalidad.SelectedItem;
            cliente.clientes_fechaIngreso = dtpFechaIngreso.Value;
            if (dbGimnasio.Domicilios.Find(FrmGestionDomicilio.iddomicilio) != null)
            {
                cliente.domicilio = dbGimnasio.Domicilios.Find(FrmGestionDomicilio.iddomicilio);
            }
            cliente.clientes_objetivos = txtObjetivos.Text;
            cliente.clientes_lecturaCorporal = txtLecturaCorporal.Text;
            cliente.clientes_peso = float.Parse(txtPeso.Text);


            if (cliente.clientes_idcliente > 0)
            {
                dbGimnasio.Entry(cliente).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Clientes.Add(cliente);
                MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dbGimnasio.SaveChanges();
            Close();
        }

        private void genero()
        {
            if (rbtnHombre.Checked)
            {
                cliente.clientes_genero = true;
            }
            else
            {
                if (rbtnMujer.Checked)
                {
                    cliente.clientes_genero = false;
                }
            }
        }

        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad();
            frmNuevaEditarLocalidad.ShowDialog();
            cargarComboLocalidad(frmNuevaEditarLocalidad.localidad.localidad_idlocalidad);
        }

        private void btnSeleccionarDomicilio_Click(object sender, EventArgs e)
        {
            FrmGestionDomicilio frmGestionDomicilio = new FrmGestionDomicilio();
            frmGestionDomicilio.ShowDialog();
            txtNombreCalle.Text = frmGestionDomicilio.calle;
            txtNumCalle.Text = frmGestionDomicilio.numero.ToString();
        }

        private void btnSeleccionarTelefono_Click(object sender, EventArgs e)
        {
            FrmGestionTelefono frmGestionTelefono = new FrmGestionTelefono();
            frmGestionTelefono.ShowDialog();
            agregarAGrillaTelefono(frmGestionTelefono);
            cargarGrillaTelefono();
            //Close();
        }

        private void agregarAGrillaTelefono(FrmGestionTelefono frmGestionTelefono)
        {
            if (dbGimnasio.Tipo_Telefonos.Find(frmGestionTelefono.idTipoTelefono) != null)
            {
                telefono = new Telefono();
                telefono.telefono_idtelefono = frmGestionTelefono.idTelefono;
                telefono.telefono_idtipotelefono = frmGestionTelefono.idTipoTelefono;
                telefono.Tipos_Telefonos = dbGimnasio.Tipo_Telefonos.Find(frmGestionTelefono.idTipoTelefono);
                telefono.telefono_numero = frmGestionTelefono.numeroTelefono;

                if (cliente.Telefonos == null)
                {
                    cliente.Telefonos = new ObservableCollection<Telefono>();
                }
                cliente.Telefonos.Add(telefono);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
