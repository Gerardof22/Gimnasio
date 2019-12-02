using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Telefono
    {
        [Key]
        public int idtelefono { get; set; }
        [Required]
        public int idtipotelefono { get; set; }
        public virtual Tipo_Telefono Tipos_Telefonos { get; set; }

        public int? idcliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public string numero { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
