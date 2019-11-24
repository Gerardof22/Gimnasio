﻿using Datos;
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
    public partial class FrmGestionLocalidad : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Localidad localidad;

        public FrmGestionLocalidad()
        {
            InitializeComponent();
            listarLocalidades();
        }

        private void listarLocalidades()
        {
            var listaLocalidades = from localidads in dbGimnasio.Localidads
                                   select new
                                   {
                                       idlocalidad = localidads.localidad_idlocalidad,
                                       localidad = localidads.localidad_localidad,
                                       isDelected = localidads.localidad_delete
                                   };
            gridLocalidad.DataSource = listaLocalidades.Where(l => l.isDelected == false).ToList();
        }

        private void buscarLocalidad(string textToSearch)
        {
            var listaLocalidades = from localidads in dbGimnasio.Localidads
                                   select new
                                   {
                                       idlocalidad = localidads.localidad_idlocalidad,
                                       localidad = localidads.localidad_localidad,
                                       isDelected = localidads.localidad_delete
                                   };
            gridLocalidad.DataSource = listaLocalidades.Where(l => l.localidad.Contains(textToSearch))
                                                       .Where(l => l.isDelected == false).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad(dbGimnasio);
            frmNuevaEditarLocalidad.ShowDialog();
            listarLocalidades();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)celdaFilaActual(gridLocalidad, 0);

            FrmNuevaEditarLocalidad frmNuevaEditarLocalidad = new FrmNuevaEditarLocalidad(idSeleccionado, dbGimnasio);
            frmNuevaEditarLocalidad.ShowDialog();
            listarLocalidades();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)celdaFilaActual(gridLocalidad, 0);
            string localidadSeleccionada = (string)celdaFilaActual(gridLocalidad, 1);

            string mensaje = "¿Está seguro que desea eliminar: " + localidadSeleccionada + "?";
            string titulo = "Eliminación";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                localidad = new Localidad();
                localidad = dbGimnasio.Localidads.Find(idSeleccionado);
                localidad.localidad_delete = true;
                dbGimnasio.SaveChanges();
                listarLocalidades();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarLocalidad(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}