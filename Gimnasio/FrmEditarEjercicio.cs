using System;
using Datos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Validation;
using ImageMagick;

namespace Gimnasio
{
    public partial class FrmEditarEjercicio : Form
    {
        GimnasioContext dbGimnasio;
        Ejercicio ejercicio;


        static MemoryStream ms;
        MemoryStream ms2;
        static Image returnImage;
        

        public FrmEditarEjercicio()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            ejercicio = new Ejercicio();
        }

        public FrmEditarEjercicio(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            ejercicio = new Ejercicio();
        }

        public FrmEditarEjercicio(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            ejercicio = new Ejercicio();
            this.CargarEjercicio(idSeleccionado);
        }

        private void CargarEjercicio(int idSeleccionado)
        {
            ejercicio = dbGimnasio.Ejercicios.Find(idSeleccionado);
            txtNombreEjercicio.Text = ejercicio.nombre;
            if (ejercicio.imagen != null)
            {
                pbxImagen.Image = byteArrayToImage(ejercicio.imagen);
            }
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
                    dbGimnasio.SaveChanges();
                    this.Close();

                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
                {
                    this.ValidarCatch(ex);
                    throw;
                }

            }
        }

        private void ValidarCatch(DbEntityValidationException ex)
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
    }
}
