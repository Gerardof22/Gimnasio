using Datos;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmCobranza : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        Cobranza cobranza = new Cobranza();
        Detalle_Cobranza detalle_Cobranza;

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
                var listaClientesAbonados = from cobranza in dbGimnasio.Cobranzas
                                            join cliente in dbGimnasio.Clientes on cobranza.Cliente.clientes_idcliente equals cliente.clientes_idcliente
                                            from detalle_cobranza in cobranza.DetalleCobranzas
                                            select new
                                            {
                                                cliente = cobranza.Cliente.clientes_nombre,
                                                recargo = detalle_Cobranza.detalleCobranza_recargoMes,
                                                importe = detalle_Cobranza.detalleCobranza_importe,
                                                total = detalle_Cobranza.detalleCobranza_total
                                            };

                gridDetalleCobranza.DataSource = listaClientesAbonados.ToList();
            }
        }

        private void cargarComboCliente(int idSeleccionar)
        {
            cboClientes.DisplayMember = "clientes_nombre";
            cboClientes.ValueMember = "clientes_idcliente";
            cboClientes.SelectedValue = idSeleccionar;
            cboClientes.DataSource = dbGimnasio.Clientes.ToList();

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Cliente cliente in dbGimnasio.Clientes)
            {
                autoCompletadoCbo.Add(cliente.clientes_nombre);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboClientes.AutoCompleteCustomSource = autoCompletadoCbo;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCliente frmNuevoEditarCliente = new FrmNuevoEditarCliente();
            frmNuevoEditarCliente.ShowDialog();
            cargarComboCliente(frmNuevoEditarCliente.cliente.clientes_idcliente);
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboClientes.SelectedIndex > -1 &&
                cboClientes.SelectedValue.GetType() == typeof(Int32))
            {
                gpbCampos.Enabled = true;
            }
        }

        private void numTotal_ValueChanged(object sender, EventArgs e)
        {
            if (chekDebe.Checked)
            {
                numTotal.Value = numRecargo.Value + numImporte.Value;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            detalle_Cobranza = new Detalle_Cobranza();
            cobranza.Cliente = dbGimnasio.Clientes.Find((int)cboClientes.SelectedItem);
            cobranza.Cliente.clientes_idcliente = (int)cboClientes.SelectedValue;
            detalle_Cobranza.detalleCobranza_debe = chekDebe.Checked;
            detalle_Cobranza.detalleCobranza_importe = numImporte.Value;
            detalle_Cobranza.detalleCobranza_total = numTotal.Value;
            if (cobranza.DetalleCobranzas == null)
            {
                cobranza.DetalleCobranzas = new ObservableCollection<Detalle_Cobranza>();
            }
            cobranza.DetalleCobranzas.Add(detalle_Cobranza);
            actualizarGrillaDetalle();
            limpiarPanel();
        }

        private void limpiarPanel()
        {
            cboClientes.SelectedValue = 0;
            chekDebe.Checked = false;
            numRecargo.Value = 0;
            numImporte.Value = 0;
            numTotal.Value = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string clienteSeleccionado = (string)gridDetalleCobranza.CurrentRow.Cells[1].Value;
            string mensaje = "¿Está seguro que desea eliminar: " + clienteSeleccionado + "?";
            string titulo = "Eliminación";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                int detalleSeleccionado = gridDetalleCobranza.CurrentRow.Index;
                cobranza.DetalleCobranzas.RemoveAt(detalleSeleccionado);
                actualizarGrillaDetalle();
                calcularTotales();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int detalleSeleccionado = gridDetalleCobranza.CurrentRow.Index;
            Detalle_Cobranza detalle_Cobranza = cobranza.DetalleCobranzas[detalleSeleccionado];
            cboClientes.SelectedValue = cobranza.Cliente.clientes_idcliente;
            chekDebe.Checked = detalle_Cobranza.detalleCobranza_debe;
            numRecargo.Value = detalle_Cobranza.detalleCobranza_recargoMes;
            numImporte.Value = detalle_Cobranza.detalleCobranza_importe;
            numTotal.Value = detalle_Cobranza.detalleCobranza_total;
            cobranza.DetalleCobranzas.RemoveAt(detalleSeleccionado);
            actualizarGrillaDetalle();
            calcularTotales();
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
            Cliente cliente = dbGimnasio.Clientes.Find(cboClientes.SelectedItem);
            cobranza.Cliente = cliente;
            cobranza.Cliente.clientes_idcliente = cliente.clientes_idcliente;
            cobranza.cobranza_fechaPago = dtpFecha.Value;
            dbGimnasio.Cobranzas.Add(cobranza);
            dbGimnasio.SaveChanges();
        }
    }
}
