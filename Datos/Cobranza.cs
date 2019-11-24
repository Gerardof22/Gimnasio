using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cobranza
    {
        [Key]
        public int cobranza_idcobranza { get; set; }
        [Required]
        public virtual Cliente Cliente { get; set; }
        [Required]
        public DateTime cobranza_fechaPago { get; set; }

        public DateTime cobranza_fechaCobro { get; set; }
        [Required]
        public decimal cobranza_total { get; set; }

        public bool cobranza_delete { get; set; } = false;

        //Según la pagína de EF dice que, ésto es el equivalente de one to Many
        public virtual ObservableCollection<Detalle_Cobranza> DetalleCobranzas { get; set; }

    }
}
