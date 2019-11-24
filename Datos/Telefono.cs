using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Telefono
    {
        [Key]
        public int telefono_idtelefono { get; set; }
        [Required]
        public int telefono_idtipotelefono { get; set; }
        public virtual Tipo_Telefono Tipos_Telefonos { get; set; }

        public int? telefono_idcliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public string telefono_numero { get; set; }

        public bool telefono_delete { get; set; } = false;
    }
}
