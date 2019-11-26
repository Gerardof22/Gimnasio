using Datos;
using ImageMagick;
using System;
using System.Collections.Generic;
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

        static MemoryStream ms;
        static Image returnImage;

        internal static string ejercicio_nombre { get; set; }
        public static byte[] image { get; set; }

        public FrmNuevoEditarEjercicio()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            ejercicio = new Ejercicio();
        }

        public FrmNuevoEditarEjercicio(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            ejercicio = new Ejercicio();
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

        public static Image byteArrayToImage(byte[] ejercicio_imagen)
        {
            if (ejercicio_imagen != null)
            {
                ms = new MemoryStream(ejercicio_imagen);
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
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
            if (ejercicio.ejercicio_idejercicio > 0)
            {
                try
                {
                    ejercicio.ejercicio_nombre = txtNombreEjercicio.Text;
                    ejercicio.ejercicio_imagen = resizeImage(imageToByteArray(pbxImagen.Image));

                    dbGimnasio.Entry(ejercicio).State = EntityState.Modified;

                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbGimnasio.SaveChanges();
                    this.Close();
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
            else
            {
                if (string.IsNullOrEmpty(txtNombreEjercicio.Text))
                {
                    MessageBox.Show("El campo 'Ejercicio' no puede estar vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreEjercicio.Focus();
                }
                else
                {
                    ejercicio_nombre = txtNombreEjercicio.Text;
                    image = resizeImage(imageToByteArray(pbxImagen.Image));
                    this.Close();
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

            using (MagickImage img = new MagickImage(image))
            {
                img.Resize(500, 0);
                imageResize = img.ToByteArray();
            }

            return imageResize;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
