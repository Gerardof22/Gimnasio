using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmGestionClientes : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Cliente cliente;

        bool botonPresionado = false;

        public FrmGestionClientes()
        {
            InitializeComponent();
            listarGrillaClientes();
        }

        /// <summary>
        /// Lista los clientes en la grilla
        /// </summary>
        private void listarGrillaClientes()
        {
            var listaCliente = from cliente in dbGimnasio.Clientes
                               join domicilio in dbGimnasio.Domicilios on cliente.Domicilio.iddomicilio equals domicilio.iddomicilio
                               join localidad in dbGimnasio.Localidads on cliente.Localidad.idlocalidad equals localidad.idlocalidad
                               select
                               new
                               {
                                   idcliente = cliente.idcliente,
                                   nombre_apellido = cliente.nombre + " " + cliente.apellido,
                                   direccion = domicilio.Calle.nombre_calle + " " + domicilio.numero,
                                   localidad = localidad.localidad,
                                   fechaIngreso = cliente.fechaIngreso,
                                   genero = cliente.genero,
                                   edad = cliente.edad,
                                   peso = cliente.peso,
                                   objetivos = cliente.objetivos,
                                   lectura_corporal = cliente.lecturaCorporal,
                                   isDelected = cliente.IsDelete
                               };

            gridClientes.DataSource = listaCliente.Where(c => c.isDelected == false).ToList();
        }

        /// <summary>
        /// Filtra los clientes en la grilla por Nombre y Apelledo, Dirección, Localidad.
        /// </summary>
        /// <param name="textToSearch">Texto el cual se desea buscar</param>
        private void buscarCliente(string textToSearch)
        {
            var listaCliente = from cliente in dbGimnasio.Clientes
                               join domicilio in dbGimnasio.Domicilios on cliente.Domicilio.iddomicilio equals domicilio.iddomicilio
                               join localidad in dbGimnasio.Localidads on cliente.Localidad.idlocalidad equals localidad.idlocalidad

                               select new
                               {
                                   idcliente = cliente.idcliente,
                                   nombre_apellido = cliente.nombre + " " + cliente.apellido,
                                   direccion = domicilio.Calle.nombre_calle + " " + domicilio.numero,
                                   localidad = localidad.localidad,
                                   fechaIngreso = cliente.fechaIngreso,
                                   genero = cliente.genero,
                                   edad = cliente.edad,
                                   peso = cliente.peso,
                                   objetivos = cliente.objetivos,
                                   lectura_corporal = cliente.lecturaCorporal,
                                   isDelected = cliente.IsDelete
                               };

            gridClientes.DataSource = listaCliente.Where(c => c.nombre_apellido.Contains(textToSearch) || c.direccion.Contains                  (textToSearch) || c.localidad.Contains(textToSearch)).Where(c => c.isDelected == false).ToList();
        }

        private void SeleccionarUltimaFila()
        {
            gridClientes.CurrentCell = gridClientes.Rows[gridClientes.Rows.Count - 1].Cells[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente(dbGimnasio);
            frmNuevoEditarCliente.ShowDialog();
            listarGrillaClientes();
            this.SeleccionarUltimaFila();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridClientes.Rows.Count > 0 && gridClientes.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridClientes, 0);

                FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente(idSeleccionado, dbGimnasio);
                frmNuevoEditarCliente.ShowDialog();
                listarGrillaClientes();
                Helper.SeleccionarFilaActivaEditada(idSeleccionado, gridClientes);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridClientes.Rows.Count > 0 && gridClientes.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridClientes, 0);
                string clienteSeleccionado = (string)celdaFilaActual(gridClientes, 1);

                string mensaje = "¿Está seguro que desea eliminar: " + clienteSeleccionado + "?";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    cliente = new Cliente();
                    cliente = dbGimnasio.Clientes.Find(idSeleccionado);
                    cliente.IsDelete = true;
                    dbGimnasio.SaveChanges();
                    listarGrillaClientes();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarCliente(txtBuscar.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            botonPresionado = true;
            if (botonPresionado)
            {
                consultarDatos();
            }
        }

        private void consultarDatos()
        {
            if (gridClientes.Rows.Count > 0 && gridClientes.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)celdaFilaActual(gridClientes, 0);

                FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente(idSeleccionado, dbGimnasio);
                frmNuevoEditarCliente.ShowDialog();
                desabilitarCampos(frmNuevoEditarCliente);
            }
            
            botonPresionado = false;
        }

        private void desabilitarCampos(FrmNuevoEditarCliente frmNuevoEditarCliente)
        {
            
            frmNuevoEditarCliente.gpbDatosPersonales.Enabled = false;
            frmNuevoEditarCliente.gpbDomicilio.Enabled = false;
            frmNuevoEditarCliente.gpbContactos.Enabled = false;
            frmNuevoEditarCliente.gpbObservaciones.Enabled = false;
            Console.WriteLine("Se preciono");

            
        }
    }
}
