using Datos;
using ImageMagick;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmNuevoEditarEjercicio : Form
    {
        GimnasioContext dbGimnasio;
        Ejercicio ejercicio;
        Rutina rutina;
        Tipo_Rutina tipo_Rutina;
        Cliente cliente;

        static MemoryStream ms;
        MemoryStream ms2;
        static Image returnImage;

        internal static string ejercicio_nombre { get; set; }
        public static byte[] image { get; set; }

        public FrmNuevoEditarEjercicio()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            ejercicio = new Ejercicio();
            cargarComboCliente(0);
        }

        public FrmNuevoEditarEjercicio(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            ejercicio = new Ejercicio();
            cargarComboCliente(0);
        }

        public FrmNuevoEditarEjercicio(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            ejercicio = new Ejercicio();
            rutina = new Rutina();
            cliente = new Cliente();
            this.cargarEjercicio(idSeleccionado);
        }

        private void cargarEjercicio(int idSeleccionado)
        {
            
            ejercicio = dbGimnasio.Ejercicios.Find(idSeleccionado);
            rutina = dbGimnasio.Rutinas.Find(ejercicio.idejercicio);
            txtNombreEjercicio.Text = ejercicio.nombre;
            if (ejercicio.imagen != null)
            {
                pbxImagen.Image = byteArrayToImage(ejercicio.imagen);
            }
            this.CargarGrillaRutina(idSeleccionado);
            this.CargarTipoRutina(idSeleccionado);
            this.cargarComboCliente(rutina.Cliente.idcliente);
        }

        private void CargarTipoRutina(int idSeleccionado)
        {
            var listTipoRutina = from e in dbGimnasio.Ejercicios join r in dbGimnasio.Rutinas on e.idejercicio equals                               r.idejercicio join tr in dbGimnasio.Tipos_Rutinas on r.idrutina equals tr.Rutina.idrutina
                                 select new
                                 {
                                     idejercicio = e.idejercicio,
                                     idrutina = r.idrutina,
                                     idtipo_rutina = tr.idtiporutina,
                                     tipo_rutina = tr.nombre
                                 };

            gridTiposRutinas.DataSource = listTipoRutina.Where(e => e.idejercicio == idSeleccionado).ToList();
        }

        private void CargarGrillaRutina(int idSeleccionado)
        {
            var listaRutina = from r in ejercicio.Rutinas

                              select new
                              {
                                  idejercicio = r.idejercicio,
                                  idrutina = r.idrutina,
                                  fechaDesde = r.fechaDesde,
                                  fechaHasta = r.fechaHasta,
                                  serie = r.serie,
                                  repticion = r.repeticion,
                                  tiempoDuracion = r.tiempoduracion,
                                  descanso = r.descanso,
                                  Kg = r.pesokg,
                                  duracion_cardio = r.Cardio?.duracion,
                                  ritmo_cardio = r.Cardio?.ritmo,
                                  duracion_calentamiento = r.Calentamiento?.duracion,
                                  descripcion_calentamiento = r.Calentamiento?.descripcion
                              };

            gridRutinas.DataSource = listaRutina.Where(r => r.idejercicio == idSeleccionado).ToList();
        }

        private void cargarComboCliente(int idSeleccionado)
        {
            cboClientes.DataSource = this.CargarClientes();
            cboClientes.DisplayMember = "nombre";
            cboClientes.ValueMember = "idcliente";
            cboClientes.SelectedValue = idSeleccionado;

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Cliente cliente in dbGimnasio.Clientes)
            {
                autoCompletadoCbo.Add(cliente.nombre);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboClientes.AutoCompleteCustomSource = autoCompletadoCbo;
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

        public static Image byteArrayToImage(byte[] ejercicio_imagen)
        {
            if (ejercicio_imagen != null)
            {
                ms = new MemoryStream(ejercicio_imagen);
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

        public  byte[] imageToByteArray(Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            else
            {
                return null;
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            string filtro = "Todas las imágenes|*.jpg;*.gif;*.png;*.bmp";
            filtro += "|JPG (*.jpg)|*.jpg";
            filtro += "|GIF* (*.gif)|*.gif";
            filtro += "|PNG* (*.png)|*.pnj";
            filtro += "|BMP (*.bmp)|*.bmp";

            abrirArchivo.Filter = filtro;
            abrirArchivo.ShowDialog();

            if (abrirArchivo.FileName != "")
            {
                pbxImagen.ImageLocation = abrirArchivo.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ejercicio.nombre = txtNombreEjercicio.Text;
            ejercicio.imagen = resizeImage(imageToByteArray(pbxImagen.Image));

            if (ejercicio.idejercicio > 0)
            {
                try
                {
                    dbGimnasio.Entry(ejercicio).State = EntityState.Modified;
                    dbGimnasio.Configuration.AutoDetectChangesEnabled = true;

                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbGimnasio.SaveChanges();
                    this.Close();
                }
                catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
                {
                    this.validarCatch(ex);
                    throw;
                }

            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(txtNombreEjercicio.Text))
                    {
                        MessageBox.Show("El campo 'Ejercicio' no puede estar vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreEjercicio.Focus();
                    }
                    else
                    {
                        dbGimnasio.Ejercicios.Add(ejercicio);
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbGimnasio.SaveChanges();
                        this.Close();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    this.validarCatch(ex);
                    throw;
                }
            }

            Reportes.ReporteEjercicio reporteEjercicio = new Reportes.ReporteEjercicio(ejercicio.idejercicio);
            reporteEjercicio.ShowDialog();
        }

        /// <summary>
        /// Redimenciona una imagen.
        /// </summary>
        /// <param name="image">Array de byte de la imagen.</param>
        /// <returns></returns>
        private byte[] resizeImage(byte[] image)
        {
            byte[] imageResize = new byte[0];

            if (image != null)
            {
                using (MagickImage img = new MagickImage(image))
                {
                    img.Resize(500, 0);
                    imageResize = img.ToByteArray();
                }
                return imageResize;
            }
            else
            {
                return null;
            }
        }

        private void validarCatch(DbEntityValidationException ex)
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarCardio_Click(object sender, EventArgs e)
        {
            FrmGestionCardio frmGestionCardio = new FrmGestionCardio();
            frmGestionCardio.ShowDialog();

            if (FrmGestionCardio.duracion != 0 && FrmGestionCardio.ritmo != "")
            {
                txtDuracionCardio.Text = FrmGestionCardio.duracion.ToString();
                txtRitmoCardio.Text = FrmGestionCardio.ritmo;
            }
        }

        private void btnAgregarCalentamiento_Click(object sender, EventArgs e)
        {
            FrmGestionCaletamiento frmGestionCaletamiento = new FrmGestionCaletamiento();
            frmGestionCaletamiento.ShowDialog();

            if (FrmGestionCaletamiento.duracion != "")
            {
                txtDuracionCalentamiento.Text = FrmGestionCaletamiento.duracion;
                txtDescripcionCalentamiento.Text = FrmGestionCaletamiento.descripcion;
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente();
            frmNuevoEditarCliente.ShowDialog();
            if (frmNuevoEditarCliente.cliente.idcliente != 0)
            {
                cargarComboCliente(frmNuevoEditarCliente.cliente.idcliente);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IsValidateControls())
            {
                rutina = new Rutina();
                rutina.fechaDesde = dtpFechaDesde.Value.Date;
                rutina.fechaHasta = dtpFechaHasta.Value.Date;
                rutina.serie = int.Parse(txtSeries.Text);
                rutina.repeticion = int.Parse(txtRepeticiones.Text);
                rutina.tiempoduracion = txtTiempoDuracion.Text;
                rutina.pesokg = float.Parse(txtKg.Text);
                rutina.descanso = txtDescanso.Text;
                rutina.Cardio = dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio);
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento);
                rutina.Cliente = dbGimnasio.Clientes.Find(cboClientes.SelectedValue);

                if (ejercicio.Rutinas == null)
                {
                    ejercicio.Rutinas = new ObservableCollection<Rutina>();
                }

                ejercicio.Rutinas.Add(rutina);
                actualizarGrillaDetalle();
                Helper.OcultarColumnas(gridRutinas, new int[] { 0, 12 });
                limpiarPanel();
            }
        }

        private bool IsValidateControls()
        {
            ArrayList arrayTextBox = new ArrayList();
            bool val = true;

            foreach (Control control in gpbCamposRutina.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;

                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        val = false;
                    }
                }
            }
            
            return val;
        }

        private void actualizarGrillaDetalle()
        {
            if (ejercicio.Rutinas != null)
            {
                var listaRutinas = from r in ejercicio.Rutinas
                                   select new
                                   {
                                       idrutina = r.idrutina,
                                       fechaDesde = r.fechaDesde,
                                       fechaHasta = r.fechaHasta,
                                       serie = r.serie,
                                       repeticiones = r.repeticion,
                                       tiempoDuracion = r.tiempoduracion,
                                       descanso = r.descanso,
                                       pesoKG = r.pesokg,
                                       duracionCardio = r.Cardio?.duracion, // <-- la expreción r.Cardio? nos permite null
                                       ritmoCardio = r.Cardio?.ritmo,
                                       duracionCalentamiento = r.Calentamiento?.duracion,
                                       descripcionCalentamiento = r.Calentamiento?.descripcion,
                                       IsDelected = r.IsDelete
                                   };

                gridRutinas.DataSource = listaRutinas.Where(r => r.IsDelected == false).ToList();
            }
        }

        private void limpiarPanel()
        {
            DateTime now = DateTime.Today;
            dtpFechaDesde.Value = now;
            dtpFechaHasta.Value = now;
            txtSeries.Text = "";
            txtRepeticiones.Text = "";
            txtKg.Text = "";
            txtTiempoDuracion.Text = "";
            txtDescanso.Text = "";
            txtDuracionCardio.Text = "";
            txtRitmoCardio.Text = "";
            txtDuracionCalentamiento.Text = "";
            txtDescripcionCalentamiento.Text = "";
            FrmGestionCardio.idcardio = 0;
            FrmGestionCaletamiento.idcalentamiento = 0;
        }

        private void validarRelacionesTablas()
        {
            if (dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio) != null)
            {
                rutina.Cardio = dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio);
            }
            if (dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento) != null)
            {
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento);
            }
        }

        private void btnAgregarTipoRutina_Click(object sender, EventArgs e)
        {
            if (gridRutinas.RowCount > 0)
            {
                FrmNuevoEditarTipoRutina frmNuevoEditarTipoRutina = new FrmNuevoEditarTipoRutina();
                frmNuevoEditarTipoRutina.ShowDialog();
                if (!string.IsNullOrEmpty(FrmNuevoEditarTipoRutina.tipo_rutina_nombre))
                {
                    llenarGrillaTipoRutina();
                    cargarGrillaTipoRutina();
                    Helper.OcultarColumnas(gridTiposRutinas, new int[] { 2 });
                }
            }
            else
            {
                MessageBox.Show("Debe de agregar primero una Rutina, luego indicar el Tipo de Rutina.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void llenarGrillaTipoRutina()
        {
            tipo_Rutina = new Tipo_Rutina();
            tipo_Rutina.nombre = FrmNuevoEditarTipoRutina.tipo_rutina_nombre;

            if (rutina.Tipos_Rutinas == null)
            {
                rutina.Tipos_Rutinas = new ObservableCollection<Tipo_Rutina>();
            }

            rutina.Tipos_Rutinas.Add(tipo_Rutina);

            FrmNuevoEditarTipoRutina.tipo_rutina_nombre = "";
        }

        private void cargarGrillaTipoRutina()
        {
            if (rutina.Tipos_Rutinas != null)
            {
                var listaTipoRutina = from tipo in rutina.Tipos_Rutinas
                                      select new
                                      {
                                          idtiporutina = tipo.idtiporutina,
                                          rutina = tipo.nombre,
                                          isDelected = tipo.IsDelete
                                      };

                gridTiposRutinas.DataSource = listaTipoRutina.Where(tr => tr.isDelected == false).ToList();
            }


        }

        private void btnQuitarTipoRutina_Click(object sender, EventArgs e)
        {
            if (gridTiposRutinas.Rows.Count > 0 && gridTiposRutinas.SelectedRows.Count > 0 && gridTiposRutinas.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTiposRutinas, 0);

                string mensaje = "¿Está seguro que desea quitar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    int idDetalleSeleccionado = gridTiposRutinas.CurrentRow.Index;
                    rutina.Tipos_Rutinas.RemoveAt(idDetalleSeleccionado);
                    cargarGrillaTipoRutina();
                }
            }
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboClientes.SelectedIndex > -1 && cboClientes.SelectedValue.GetType() == typeof(Int32))
            {
                gpbCamposRutina.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridRutinas.Rows.Count > 0 && gridRutinas.SelectedRows.Count > 0 && gridRutinas.CurrentRow != null)
            {
                int detalleSeleccionado = gridRutinas.CurrentRow.Index;
                Rutina rutinaDetalle = ejercicio.Rutinas[detalleSeleccionado];
                dtpFechaDesde.Value = rutinaDetalle.fechaDesde;
                dtpFechaHasta.Value = rutinaDetalle.fechaHasta;
                txtSeries.Text = rutinaDetalle.serie.ToString();
                txtRepeticiones.Text = rutinaDetalle.repeticion.ToString();
                txtTiempoDuracion.Text = rutinaDetalle.tiempoduracion;
                txtDescanso.Text = rutinaDetalle.descanso;
                txtKg.Text = rutinaDetalle.pesokg.ToString();
                this.ValidarCardioAndCalentamiento(rutinaDetalle);
                ejercicio.Rutinas.RemoveAt(detalleSeleccionado);
                actualizarGrillaDetalle();
            }
        }

        private void ValidarCardioAndCalentamiento(Rutina rutinaDetalle)
        {
            if (rutinaDetalle.Cardio != null)
            {
                txtDuracionCardio.Text = rutinaDetalle.Cardio.duracion.ToString();
                txtRitmoCardio.Text = rutinaDetalle.Cardio.ritmo;
            }

            if (rutina.Calentamiento != null)
            {
                txtDuracionCalentamiento.Text = rutina.Calentamiento.duracion;
                txtDescripcionCalentamiento.Text = rutinaDetalle.Calentamiento.descripcion;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gridRutinas.RowCount > 0 && gridRutinas.SelectedRows.Count > 0 && gridRutinas.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridRutinas, 0);

                string mensaje = "¿Está seguro que desea quitar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    int idDetalleSeleccionado = gridRutinas.CurrentRow.Index;
                    ejercicio.Rutinas.RemoveAt(idDetalleSeleccionado);
                    actualizarGrillaDetalle();
                }
            }
        }
    }
}
