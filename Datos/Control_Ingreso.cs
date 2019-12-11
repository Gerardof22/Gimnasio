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
        
        [Required]
        public int idcliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public bool turno { get; set; }
        [Required]
        public DateTime fecha { get; set; }

        [DefaultValue(false)] //Estable el valor por defecto en 'false'.
        public bool IsDelete { get; set; } 
    }
}
