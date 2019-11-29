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
                                         idtelefono = telefono.telefono_idtelefono,
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
                                 where telefonos.Cliente.clientes_idcliente != null && telefonos.telefono_idtelefono != null
                                 select new
                                 {
                                     idcliente = telefonos.Cliente.clientes_idcliente,
                                     idtelefono = telefonos.telefono_idtelefono,
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
            try
            {
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
            }
        }

        private void agregarAGrillaTelefono()
        {
            if (dbGimnasio.Tipo_Telefonos.Find(FrmNuevoEditarTelefono.idtipotelefono) != null)
            {
                telefono = new Telefono();
                telefono.telefono_idtelefono = FrmNuevoEditarTelefono.idtelefono;
                telefono.telefono_idtipotelefono = FrmNuevoEditarTelefono.idtipotelefono;
                telefono.Tipos_Telefonos = dbGimnasio.Tipo_Telefonos.Find(FrmNuevoEditarTelefono.idtipotelefono);
                telefono.telefono_numero = FrmNuevoEditarTelefono.numero.ToString();

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
            Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gridTelefonos.Rows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridTelefonos, 0);

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

        /// <summary>
        /// Obtiene la celda y la fila actual seleccionada.
        /// </summary>
        /// <param name="dataGridView"> Nombre del DataGridView.</param>
        /// <param name="column">Índice de columna del DataGridView.</param>
        /// <returns>Retorna un object.</returns>
        private object celdaFilaActual(DataGridView dataGridView, int column)
        {
            DataGridViewCellCollection celdasFilaActual = dataGridView.CurrentRow.Cells;

            return celdasFilaActual[column].Value;
        }
    }
}
