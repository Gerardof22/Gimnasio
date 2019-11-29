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
    public class Calle
    {
        [Key]
        public int idcalle { get; set; }

        [Required]
        [StringLength(60)]
        public string nombre_calle { get; set; }

        [DefaultValue(false)]
        public bool IsDelected { get; set; }

        public virtual ObservableCollection<Domicilio> Domicilios { get; set; }
    }
}
