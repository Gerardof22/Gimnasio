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
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace Gimnasio
{
    public partial class FrmNuevoEditarUsuario : Form
    {
        GimnasioContext dbGimnasio;
        Usuario usuario;
        Tipo_Usuario tipo_Usuario;
        private int intentosFallidos = 0;

        public FrmNuevoEditarUsuario()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            usuario = new Usuario();
        }

        public FrmNuevoEditarUsuario(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            usuario = new Usuario();
            this.CargarComboTipoUsuario(0);
        }

        public FrmNuevoEditarUsuario(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            usuario = new Usuario();
            this.CargarUsuario(idSeleccionado);
        }

        private void CargarUsuario(int idSeleccionado)
        {
            usuario = dbGimnasio.Usuarios.Find(idSeleccionado);
            this.CargarComboTipoUsuario(usuario.Tipo_Usuario.idtipousuario);
            txtUser.Text = usuario.user;
            txtPassword.Text = usuario.password;
        }

        private void CargarComboTipoUsuario(int id)
        {
            cboTipoUsuario.DataSource = dbGimnasio.Tipos_Usuarios.ToList();
            //campo que vera el usuario
            cboTipoUsuario.DisplayMember = "tipo_usuario";

            //campo que es el valor real
            cboTipoUsuario.ValueMember = "idtipousuario";
            cboTipoUsuario.SelectedValue = id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario.Tipo_Usuario = (Tipo_Usuario)cboTipoUsuario.SelectedItem;
                usuario.user = txtUser.Text;
                usuario.password = obtenerSha512Hash(txtPassword.Text);

                if (usuario.idusuario > 0)
                {
                    dbGimnasio.Entry(usuario).State = EntityState.Modified;
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbGimnasio.Usuarios.Add(usuario);
                    MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dbGimnasio.SaveChanges();
                this.Close();
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

        private string obtenerSha512Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputStringBuilder.ToString();
            }
        }

        private void AgregarTipoUsuario_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoUsuario frmNuevoEditarTipoUsuario = new FrmNuevoEditarTipoUsuario();
            frmNuevoEditarTipoUsuario.ShowDialog();
            CargarComboTipoUsuario(frmNuevoEditarTipoUsuario.tipo_Usuario.idtipousuario);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
