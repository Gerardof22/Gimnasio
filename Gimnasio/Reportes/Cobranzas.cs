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

namespace Gimnasio.Reportes
{
    public partial class Cobranzas : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        public int idcobranza;

        public Cobranzas(int idCobranzaEnviado)
        {
            InitializeComponent();
            this.idcobranza = idCobranzaEnviado;
        }

        private void Cobranzas_Load(object sender, EventArgs e)
        {
            var listaCobranza = from cobranza in dbGimnasio.Cobranzas
                                join detalleCobranza in dbGimnasio.Detalle_Cobranzas on cobranza.idcobranza equals detalleCobranza.Cobranza.idcobranza
                                where cobranza.idcobranza == this.idcobranza
                                select new
                                {
                                    cobranza_idcobranza = cobranza.idcobranza,
                                    cobranza_fechaPago = cobranza.fechaPago,
                                    cobranza_total = cobranza.cobranza_total,
                                    detalleCobranza_recargoMes = detalleCobranza.recargoMes,
                                    detalleCobranza_importe = detalleCobranza.importe,
                                    detalleCobranza_total = detalleCobranza.detalleCobranza_total
                                };

            cobranzasBindingSource.DataSource = listaCobranza.ToList();
            detalleCobranzaBindingSource.DataSource = listaCobranza.ToList();

            this.reportViewer1.RefreshReport();
        }
    }
}
