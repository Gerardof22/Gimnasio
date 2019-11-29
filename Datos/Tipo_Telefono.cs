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
    public class Tipo_Telefono
    {
        [Key]
        public int    tipo_telefono_idtipotelefono { get; set; }
        [Required]
        [StringLength (45)]
        public string tipo_telefono_telefono { get; set; }

        [DefaultValue(false)]
        public bool   tipo_telefono_delete { get; set; }

        public virtual ObservableCollection<Telefono> Telefonos { get; set; }
    }
}
