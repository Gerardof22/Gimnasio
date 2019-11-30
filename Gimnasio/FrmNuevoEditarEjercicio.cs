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
            this.cargarEjercicio(idSeleccionado);
        }

        private void cargarEjercicio(int idSeleccionado)
        {
            ejercicio = dbGimnasio.Ejercicios.Find(idSeleccionado);
            txtNombreEjercicio.Text = ejercicio.ejercicio_nombre;
            pbxImagen.Image = byteArrayToImage(ejercicio.ejercicio_imagen);
        }

        private void cargarComboCliente(int idSeleccionado)
        {
            cboClientes.DataSource = dbGimnasio.Clientes.ToList();
            cboClientes.DisplayMember = "clientes_nombre";
            cboClientes.ValueMember = "clientes_idcliente";
            cboClientes.SelectedValue = idSeleccionado;

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Cliente cliente in dbGimnasio.Clientes)
            {
                autoCompletadoCbo.Add(cliente.clientes_nombre);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboClientes.AutoCompleteCustomSource = autoCompletadoCbo;
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
            ejercicio.ejercicio_nombre = txtNombreEjercicio.Text;
            ejercicio.ejercicio_imagen = resizeImage(imageToByteArray(pbxImagen.Image));

            if (ejercicio.ejercicio_idejercicio > 0)
            {
                try
                {
                    dbGimnasio.Entry(ejercicio).State = EntityState.Modified;

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
            if (frmNuevoEditarCliente.cliente.clientes_idcliente != 0)
            {
                cargarComboCliente(frmNuevoEditarCliente.cliente.clientes_idcliente);
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IsValidateControls())
            {
                rutina = new Rutina();
                rutina.rutina_fechaDesde = dtpFechaDesde.Value;
                rutina.rutina_fechaHasta = dtpFechaHasta.Value;
                rutina.rutina_serie = int.Parse(txtSeries.Text);
                rutina.rutina_repeticion = int.Parse(txtRepeticiones.Text);
                rutina.rutina_tiempoduracion = txtTiempoDuracion.Text;
                rutina.rutina_pesokg = float.Parse(txtKg.Text);
                rutina.rutina_descanso = txtDescanso.Text;
                rutina.Cardio = dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio);
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento);
                rutina.Cliente = dbGimnasio.Clientes.Find(cboClientes.SelectedValue);

                if (ejercicio.Rutinas == null)
                {
                    ejercicio.Rutinas = new ObservableCollection<Rutina>();
                }

                ejercicio.Rutinas.Add(rutina);
                actualizarGrillaDetalle();
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
                                       idrutina = r.rutina_idrutina,
                                       fechaDesde = r.rutina_fechaDesde,
                                       fechaHasta = r.rutina_fechaHasta,
                                       serie = r.rutina_serie,
                                       repeticiones = r.rutina_repeticion,
                                       tiempoDuracion = r.rutina_tiempoduracion,
                                       descanso = r.rutina_descanso,
                                       pesoKG = r.rutina_pesokg,
                                       duracionCardio = r.Cardio?.cardio_duracion, // <-- la expreción r.Cardio? nos permite null
                                       ritmoCardio = r.Cardio?.cardio_ritmo,
                                       duracionCalentamiento = r.Calentamiento?.calentamiento_duracion,
                                       descripcionCalentamiento = r.Calentamiento?.calentamiento_descripcion,
                                       IsDelected = r.rutina_delete
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
            FrmNuevoEditarTipoRutina frmNuevoEditarTipoRutina = new FrmNuevoEditarTipoRutina();
            frmNuevoEditarTipoRutina.ShowDialog();
            if (!string.IsNullOrEmpty(FrmNuevoEditarTipoRutina.tipo_rutina_nombre))
            {
                llenarGrillaTipoRutina();
                cargarGrillaTipoRutina();
            }
        }

        private void llenarGrillaTipoRutina()
        {
            tipo_Rutina = new Tipo_Rutina();
            tipo_Rutina.tipo_rutina_nombre = FrmNuevoEditarTipoRutina.tipo_rutina_nombre;

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
                                          idtiporutina = tipo.tipo_rutina_idtiporutina,
                                          rutina = tipo.tipo_rutina_nombre,
                                          isDelected = tipo.tipo_rutina_delete
                                      };

                gridTiposRutinas.DataSource = listaTipoRutina.Where(tr => tr.isDelected == false).ToList();
            }


        }

        private void btnQuitarTipoRutina_Click(object sender, EventArgs e)
        {
            if (gridTiposRutinas.Rows.Count > 0 && gridTiposRutinas.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridTiposRutinas, 0);

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

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboClientes.SelectedIndex > -1 && cboClientes.SelectedValue.GetType() == typeof(Int32))
            {
                gpbCamposRutina.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridRutinas.Rows.Count > 0)
            {
                int detalleSeleccionado = gridRutinas.CurrentRow.Index;
                Rutina rutinaDetalle = ejercicio.Rutinas[detalleSeleccionado];
                dtpFechaDesde.Value = rutinaDetalle.rutina_fechaDesde;
                dtpFechaHasta.Value = rutinaDetalle.rutina_fechaHasta;
                txtSeries.Text = rutinaDetalle.rutina_serie.ToString();
                txtRepeticiones.Text = rutinaDetalle.rutina_repeticion.ToString();
                txtTiempoDuracion.Text = rutinaDetalle.rutina_tiempoduracion;
                txtDescanso.Text = rutinaDetalle.rutina_descanso;
                txtKg.Text = rutinaDetalle.rutina_pesokg.ToString();
                this.ValidarCardioAndCalentamiento(rutinaDetalle);
                ejercicio.Rutinas.RemoveAt(detalleSeleccionado);
                actualizarGrillaDetalle();
            }
        }

        private void ValidarCardioAndCalentamiento(Rutina rutinaDetalle)
        {
            if (rutinaDetalle.Cardio != null)
            {
                txtDuracionCardio.Text = rutinaDetalle.Cardio.cardio_duracion.ToString();
                txtRitmoCardio.Text = rutinaDetalle.Cardio.cardio_ritmo;
            }

            if (rutina.Calentamiento != null)
            {
                txtDuracionCalentamiento.Text = rutina.Calentamiento.calentamiento_duracion;
                txtDescripcionCalentamiento.Text = rutinaDetalle.Calentamiento.calentamiento_descripcion;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gridRutinas.RowCount > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridRutinas, 0);

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
