using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cobranza
    {
        [Key]
        public int idcobranza { get; set; }
        [Required]
        public int idcliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public DateTime fechaPago { get; set; }
        [Required]
        public decimal cobranza_total { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        //Según la pagína de EF dice que, ésto es el equivalente de one to Many
        public virtual ObservableCollection<Detalle_Cobranza> DetalleCobranzas { get; set; }

    }
}
