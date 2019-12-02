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
    public class Domicilio
    {
        [Key]
        public int iddomicilio { get; set; }

        [Required]
        public int idcalle { get; set; }
        public virtual Calle Calle { get; set; }

        public int numero { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public virtual ObservableCollection<Cliente> Clientes { get; set; }
        
    }
}
