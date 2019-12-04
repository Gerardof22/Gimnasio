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

namespace Gimnasio.Reportes
{
    public partial class ReporteCobranza : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        private int idcobranza;

        public ReporteCobranza(int idenviado)
        {
            InitializeComponent();
            this.idcobranza = idenviado;
        }

        private void ReporteCobranza_Load(object sender, EventArgs e)
        {
            var listaCobranza = from cobranza in dbGimnasio.Detalle_Cobranzas
                                join detalle in dbGimnasio.Detalle_Cobranzas on cobranza.idcobranza equals detalle.Cobranza.idcobranza
                                where cobranza.idcobranza == this.idcobranza
                                select new
                                {
                                    idcobranza = cobranza.idcobranza,
                                    fechaPago = cobranza.Cobranza.fechaPago,
                                    recargoMes = detalle.recargoMes,
                                    importe = detalle.importe,
                                    detalleCobranza_total = detalle.detalleCobranza_total,
                                    cobranza_total = cobranza.Cobranza.cobranza_total
                                };
            CobranzaBindingSource.DataSource = listaCobranza.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
