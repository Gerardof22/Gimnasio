using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Control_Ingreso
    {
        [Key]
        public int control_ingreso_idcontrolingreso { get; set; }
        
        public int control_ingreso_idcliente { get; set; } // int? representa un tipo de valor que se puede asignar nulo.
        public virtual Cliente Cliente { get; set; }
        [Required]
        public bool control_ingreso_turno { get; set; }
        [Required]
        public DateTime control_ingreso_fecha { get; set; }

        public bool control_ingreso_delete { get; set; } = false; //Estable el valor por defecto en 'false'.
    }
}
