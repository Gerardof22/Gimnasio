﻿using Datos;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmCobranza : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Cobranza cobranza = new Cobranza();
        Detalle_Cobranza detalle_cobranza;

        public FrmCobranza()
        {
            InitializeComponent();
            cargarComboCliente(0);
            actualizarGrillaDetalle();
        }

        private void actualizarGrillaDetalle()
        {
            if (cobranza.DetalleCobranzas != null)
            {
                var listaClientesAbonados = from detalle_cobranza in cobranza.DetalleCobranzas
                                            
                                            select new
                                            {
                                                iddetalle = detalle_cobranza.iddetallecobranza,
                                                recargo = detalle_cobranza.recargoMes,
                                                importe = detalle_cobranza.importe,
                                                total = detalle_cobranza.detalleCobranza_total
                                            };

                gridDetalleCobranza.DataSource = listaClientesAbonados.ToList();
            }
        }

        private void cargarComboCliente(int idSeleccionado)
        {
            cboClientes.DataSource = this.CargarCliente();
            cboClientes.DisplayMember = "nombre";
            cboClientes.ValueMember = "idcliente";
            cboClientes.SelectedValue = idSeleccionado;

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Cliente cliente in dbGimnasio.Clientes)
            {
                string nom_apel = cliente.nombre + " " + cliente.apellido;
                autoCompletadoCbo.Add(nom_apel);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboClientes.AutoCompleteCustomSource = autoCompletadoCbo;
        }

        private IList CargarCliente()
        {
            var clientes = from c in dbGimnasio.Clientes
                           select new
                           {
                               idcliente = c.idcliente,
                               nombre = c.nombre + " " + c.apellido
                           };
            return clientes.ToList();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente();
            frmNuevoEditarCliente.ShowDialog();
            cargarComboCliente(frmNuevoEditarCliente.cliente.idcliente);
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboClientes.SelectedIndex > -1 &&
                cboClientes.SelectedValue.GetType() == typeof(Int32))
            {
                gpbCampos.Enabled = true;
            }
        }

        private void numImporte_ValueChanged(object sender, EventArgs e)
        {
            if (chekDebe.Checked)
            {
                numTotal.Value = numRecargo.Value + numImporte.Value;
            }
            else
            {
                numTotal.Value = numImporte.Value;
            }
        }

        private void numRecargo_ValueChanged(object sender, EventArgs e)
        {
            if (chekDebe.Checked)
            {
                numTotal.Value = numRecargo.Value + numImporte.Value;
            }
            else
            {
                numTotal.Value = numImporte.Value;
            }
        }

        private void numTotal_ValueChanged(object sender, EventArgs e)
        {
            if (chekDebe.Checked)
            {
                numTotal.Value = numRecargo.Value + numImporte.Value;
            }
            else
            {
                numTotal.Value = numImporte.Value;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Agregar();
        }

        private void Agregar()
        {
            if (numImporte.Value != 0)
            {
                detalle_cobranza = new Detalle_Cobranza();
                detalle_cobranza.recargoMes = numRecargo.Value;
                detalle_cobranza.importe = numImporte.Value;
                detalle_cobranza.detalleCobranza_total = numTotal.Value;
                if (cobranza.DetalleCobranzas == null)
                {
                    cobranza.DetalleCobranzas = new ObservableCollection<Detalle_Cobranza>();
                }
                cobranza.DetalleCobranzas.Add(detalle_cobranza);
                actualizarGrillaDetalle();
                Helper.OcultarColumnas(gridDetalleCobranza, new int[] { 0 });
                limpiarPanel();
                calcularTotales();
            }
        }

        private void limpiarPanel()
        {
            chekDebe.Checked = false;
            numRecargo.Value = 0;
            numImporte.Value = 0;
            numTotal.Value = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridDetalleCobranza.Rows.Count > 0 && gridDetalleCobranza.SelectedRows.Count > 0 && gridDetalleCobranza.CurrentRow != null)
            {
                int idSeleccionado = (int)gridDetalleCobranza.CurrentRow.Cells[0].Value;
                string mensaje = "¿Está seguro que desea eliminar";
                string titulo = "Eliminación";
                DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    int detalleSeleccionado = gridDetalleCobranza.CurrentRow.Index;
                    cobranza.DetalleCobranzas.RemoveAt(detalleSeleccionado);
                    actualizarGrillaDetalle();
                    calcularTotales();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridDetalleCobranza.Rows.Count > 0 && gridDetalleCobranza.SelectedRows.Count > 0 && gridDetalleCobranza.CurrentRow != null)
            {
                int detalleSeleccionado = gridDetalleCobranza.CurrentRow.Index;
                Detalle_Cobranza detalle_Cobranza = cobranza.DetalleCobranzas[detalleSeleccionado];
                chekDebe.Checked = detalle_Cobranza.aplazado;
                numRecargo.Value = detalle_Cobranza.recargoMes;
                numImporte.Value = detalle_Cobranza.importe;
                numTotal.Value = detalle_Cobranza.detalleCobranza_total;
                cobranza.DetalleCobranzas.RemoveAt(detalleSeleccionado);
                actualizarGrillaDetalle();
                calcularTotales();
            }
        }

        private void calcularTotales()
        {
            float total = 0;
            foreach (Detalle_Cobranza detalle_Cobranza in cobranza.DetalleCobranzas)
            {
                total += (float)detalle_Cobranza.detalleCobranza_total;
            }
            cobranza.cobranza_total = (decimal)total;
            txtTotalCobranza.Text = cobranza.cobranza_total.ToString();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDetalleCobranza.Rows.Count > 0)
                {
                    Cliente cliente = dbGimnasio.Clientes.Find(cboClientes.SelectedValue);
                    cobranza.Cliente = cliente;
                    cobranza.Cliente.idcliente = cliente.idcliente;
                    cobranza.fechaPago = dtpFecha.Value;
                    dbGimnasio.Cobranzas.Add(cobranza);
                    dbGimnasio.SaveChanges();
                    this.Close();
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

            if ((int)cboClientes.SelectedIndex > -1 && cboClientes.SelectedValue.GetType() == typeof(Int32) && gridDetalleCobranza.RowCount > 0)
            {
                Reportes.ReporteCobranza cobranzas = new Reportes.ReporteCobranza(this.cobranza.idcobranza);
                cobranzas.ShowDialog();
            }
            
        }

        private void chekDebe_CheckedChanged(object sender, EventArgs e)
        {
            if (chekDebe.Checked)
            {
                numRecargo.Enabled = true;
            }
            else
            {
                numRecargo.Value = 0;
                numRecargo.Enabled = false;
            }
        }

        private void numImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Agregar();
            }
        }
    }
}
