using Datos;
using System;
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
    public partial class FrmAdministracionUsuarios : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Usuario usuario = new Usuario();
        Tipo_Usuario tipo_Usuario = new Tipo_Usuario();
        

        public FrmAdministracionUsuarios()
        {
            InitializeComponent();
            this.listarGrillaUsuarios();
            Helper.OcultarColumnas(gridUsuarios, new int[] { 3 });
        }

        private void listarGrillaUsuarios()
        {
            var listaUsuarios = from u in dbGimnasio.Usuarios
                                //join t_u in dbGimnasio.Tipos_Usuarios on u.Tipo_Usuario.idtipousuario equals t_u.idtipousuario
                                select new
                                {
                                    idusuario = u.idusuario,
                                    tipo_usuario = u.Tipo_Usuario.tipo,
                                    usuario = u.user,
                                    IsDeleted = u.IsDelete
                                };

            gridUsuarios.DataSource = listaUsuarios.Where(u => u.IsDeleted == false).ToList();
        }

        private void BuscarUsuario(string TextToSearch)
        {
            var listaUsuarios = from u in dbGimnasio.Usuarios
                                join t_u in dbGimnasio.Tipos_Usuarios on u.Tipo_Usuario.idtipousuario equals t_u.idtipousuario
                                select new
                                {
                                    idusuario = u.idusuario,
                                    tipo_usuario = t_u.tipo,
                                    usuario = u.user,
                                    IsDeleted = u.IsDelete
                                };

            gridUsuarios.DataSource = listaUsuarios.Where(u => u.IsDeleted == false)
                                                   .Where(u => u.usuario.Contains(TextToSearch) || 
                                                   u.tipo_usuario.Contains(TextToSearch)).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarUsuario frmNuevoEditarUsuario = new FrmNuevoEditarUsuario(dbGimnasio);
            frmNuevoEditarUsuario.ShowDialog();
            listarGrillaUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridUsuarios.Rows.Count > 0 && gridUsuarios.SelectedRows.Count > 0 && gridUsuarios.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridUsuarios, 0);

                FrmNuevoEditarUsuario frmNuevoEditarUsuario = new FrmNuevoEditarUsuario(idSeleccionado, dbGimnasio);
                frmNuevoEditarUsuario.ShowDialog();
                listarGrillaUsuarios();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridUsuarios);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridUsuarios.Rows.Count > 0 && gridUsuarios.SelectedRows.Count > 0 && gridUsuarios.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridUsuarios, 0);

                string mensaje = "¿Está seguro que desea eliminar?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    usuario = dbGimnasio.Usuarios.Find(idSeleccionado);
                    usuario.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    listarGrillaUsuarios();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuario(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Text = "";
            }
        }
    }
}
