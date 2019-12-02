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
        public int iddetallecobranza { get; set; }
        [Required]
        public int idcobranza { get; set; }
        public virtual Cobranza Cobranza { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool aplazado { get; set; } //Sí es true se habilita el campo 'recargoMes'

        public decimal recargoMes { get; set; }
        [Required]
        public decimal importe { get; set; }
        [Required]
        public decimal detalleCobranza_total { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
