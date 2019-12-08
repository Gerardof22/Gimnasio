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
    public partial class FrmNuevaEditarLocalidad : Form
    {
        GimnasioContext dbGimnasio;
        public Localidad localidad;

        public FrmNuevaEditarLocalidad()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            localidad = new Localidad();
        }

        public FrmNuevaEditarLocalidad(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            localidad = new Localidad();
            cargarLocalidad(0);
        }

        public FrmNuevaEditarLocalidad(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            localidad = new Localidad();
            cargarLocalidad(idSeleccionado);
        }

        private void cargarLocalidad(int idSeleccionado)
        {
            localidad = dbGimnasio.Localidads.Find(idSeleccionado);
            txtLocalidadNombre.Text = localidad.localidad;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar()
        {
            try
            {
                localidad.localidad = txtLocalidadNombre.Text;

                if (localidad.idlocalidad > 0)
                {
                    dbGimnasio.Entry(localidad).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtLocalidadNombre.Text))
                    {
                        dbGimnasio.Localidads.Add(localidad);
                        dbGimnasio.SaveChanges();
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El campo de texto no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLocalidadNombre.Focus();
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

        private void txtLocalidadNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Guardar();
            }
        }
    }
}
