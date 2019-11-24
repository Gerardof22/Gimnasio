using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Detalle_Cobranza
    {
        [Key]
        public int detalleCobranza_iddetallecobranza { get; set; }
        [Required]
        public int detalleCobranza_idcobranza { get; set; }
        public virtual Cobranza Cobranza { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool detalleCobranza_debe { get; set; } //Sí es true se habilita el campo 'recargoMes'

        public decimal detalleCobranza_recargoMes { get; set; }
        [Required]
        public decimal detalleCobranza_importe { get; set; }
        [Required]
        public decimal detalleCobranza_total { get; set; }

        public bool detalleCobranza_delete { get; set; } = false;
    }
}
