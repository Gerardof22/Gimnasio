using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Domicilio
    {
        [Key]
        public int domicilio_iddomicilio { get; set; }
        [StringLength (50)]
        public string domicilio_calle { get; set; }
        
        public int domocilio_numero { get; set; }

        public bool domocilio_delete { get; set; } = false;

        public virtual ObservableCollection<Cliente> Clientes { get; set; }
        
    }
}
