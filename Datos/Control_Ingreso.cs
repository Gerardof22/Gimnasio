using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Control_Ingreso
    {
        [Key]
        public int idcontrolingreso { get; set; }
        
        public int idcliente { get; set; } // int? representa un tipo de valor que se puede asignar nulo.
        public virtual Cliente Cliente { get; set; }
        [Required]
        public bool turno { get; set; }
        [Required]
        public DateTime fecha { get; set; }

        [DefaultValue(false)] //Estable el valor por defecto en 'false'.
        public bool IsDelete { get; set; } 
    }
}
