﻿using System;
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
    public partial class FrmAdministradorTipoUsuario : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Tipo_Usuario tipo_Usuario = new Tipo_Usuario();
        public FrmAdministradorTipoUsuario()
        {
            InitializeComponent();
            this.ListarGrillaTipoUsuario();
            Helper.OcultarColumnas(gridTipoUsuario, new int[] { 2 });
        }

        private void ListarGrillaTipoUsuario()
        {
            var listaTipoUsuario = from t_u in dbGimnasio.Tipos_Usuarios
                                   select new
                                   {
                                       id = t_u.idtipousuario,
                                       tipo_usuario = t_u.tipo,
                                       IsDelected = t_u.IsDelete
                                   };

            gridTipoUsuario.DataSource = listaTipoUsuario.Where(tu => tu.IsDelected == false).ToList();
        }

        private void BuscarTipoUsuario(string TextToSearch)
        {
            var listaTipoUsuario = from t_u in dbGimnasio.Tipos_Usuarios
                                   select new
                                   {
                                       id = t_u.idtipousuario,
                                       tipo_usuario = t_u.tipo,
                                       IsDelected = t_u.IsDelete
                                   };

            gridTipoUsuario.DataSource = listaTipoUsuario.Where(tu => tu.tipo_usuario.Contains(TextToSearch))
                                                         .Where(tu => tu.IsDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoUsuario frmNuevoEditarTipoUsuario = new FrmNuevoEditarTipoUsuario(dbGimnasio);
            frmNuevoEditarTipoUsuario.ShowDialog();
            ListarGrillaTipoUsuario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridTipoUsuario.Rows.Count > 0 && gridTipoUsuario.SelectedRows.Count > 0 && gridTipoUsuario.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTipoUsuario, 0);

                FrmNuevoEditarTipoUsuario frmNuevoEditarTipoUsuario = new FrmNuevoEditarTipoUsuario(idSeleccionado, dbGimnasio);
                frmNuevoEditarTipoUsuario.ShowDialog();
                ListarGrillaTipoUsuario();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridTipoUsuario.Rows.Count > 0 && gridTipoUsuario.SelectedRows.Count > 0 && gridTipoUsuario.CurrentRow != null)
            {
                int idSeleccionado = (int)Helper.CeldaFilaActual(gridTipoUsuario, 0);
                string TipoUserSeleccionada = (string)Helper.CeldaFilaActual(gridTipoUsuario, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + TipoUserSeleccionada + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    tipo_Usuario = dbGimnasio.Tipos_Usuarios.Find(idSeleccionado);
                    tipo_Usuario.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    ListarGrillaTipoUsuario();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarTipoUsuario(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
