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

namespace Gimnasio
{
    public partial class FrmLogin : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        public Usuario usuario;
        internal static Tipo_Usuario tipo_Usuario;
        private int intentosFallidos = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (IsValidateAccess())
            {
                this.Close();
            }
            else
            {
                intentosFallidos++;
                if (intentosFallidos == 3)
                    Application.Exit();
                else
                {
                    MessageBox.Show("Error en usuario o contraseña ingresados");
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                }
            }
        }

        private bool IsValidateAccess()
        {
            int IsValidateUser = 0;
            int IsValidatePass = 0;
            bool isValid = false;

            string passwordHash = obtenerSha512Hash(txtPassword.Text);

            var listUser = dbGimnasio.Usuarios.ToList();
            
            if (listUser.Count() > 0)
            {
                foreach (var user in listUser)
                {
                    //Comparamos el usuario y el password que sean exactamentes iguales sencibles a mayúsculas y minúsculas
                    IsValidateUser = string.Compare(user.user, txtUser.Text, false);
                    IsValidatePass = string.Compare(user.password, passwordHash, false);

                    //Sí es igual a 0(cero) es porque son exactamente iguales.
                    if (IsValidateUser == 0 && IsValidatePass == 0)
                    {
                        isValid = true;
                        usuario = new Usuario();
                        usuario = dbGimnasio.Usuarios.Find(user.idusuario); //Buscamos el idusuario logeado.
                    }
                }
            }

            return isValid;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void llblNuevoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmNuevoEditarUsuario frmNuevoEditarUsuario = new FrmNuevoEditarUsuario();
            frmNuevoEditarUsuario.ShowDialog();
        }
    }
}
