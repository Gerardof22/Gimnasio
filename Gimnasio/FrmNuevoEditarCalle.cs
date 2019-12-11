using Datos;
using System;
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
    public partial class FrmNuevoEditarCalle : Form
    {
        GimnasioContext dbGimnasio;
        public Calle calle;

        public FrmNuevoEditarCalle()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            calle = new Calle();
        }

        public FrmNuevoEditarCalle(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            calle = new Calle();
        }

        public FrmNuevoEditarCalle(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            calle = new Calle();
            this.CargarCalle(idSeleccionado);
        }

        private void CargarCalle(int idSeleccionado)
        {
            calle = dbGimnasio.Calles.Find(idSeleccionado);
            txtNombreCalle.Text = calle.nombre_calle;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                calle.nombre_calle = txtNombreCalle.Text;

                if (calle.idcalle > 0)
                {
                    dbGimnasio.Entry(calle).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtNombreCalle.Text))
                    {
                        dbGimnasio.Calles.Add(calle);
                        dbGimnasio.SaveChanges();
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La caja de texto no puede estar vacia.", "Advertendcia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreCalle.Focus();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                this.ValidarCatch(ex);
                throw;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
