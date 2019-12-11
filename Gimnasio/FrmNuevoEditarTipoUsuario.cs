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
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Gimnasio
{
    public partial class FrmNuevoEditarTipoUsuario : Form
    {
        GimnasioContext dbGimnasio;
        public Tipo_Usuario tipo_Usuario;

        public FrmNuevoEditarTipoUsuario()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            tipo_Usuario = new Tipo_Usuario();
        }

        public FrmNuevoEditarTipoUsuario(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_Usuario = new Tipo_Usuario();
        }

        public FrmNuevoEditarTipoUsuario(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            this.CargarTipoUsuario(idSeleccionado);
        }

        private void CargarTipoUsuario(int idSeleccionado)
        {
            tipo_Usuario = dbGimnasio.Tipos_Usuarios.Find(idSeleccionado);
            txtTipoUsuario.Text = tipo_Usuario.tipo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo_Usuario.tipo = txtTipoUsuario.Text;

                if (tipo_Usuario.idtipousuario > 0)
                {
                    dbGimnasio.Entry(tipo_Usuario).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtTipoUsuario.Text))
                    {
                        dbGimnasio.Tipos_Usuarios.Add(tipo_Usuario);
                        dbGimnasio.SaveChanges();
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La caja de texto no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTipoUsuario.Focus();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                this.ValidateCatch(ex);
                throw;
            }
        }

        private void ValidateCatch(DbEntityValidationException ex)
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
