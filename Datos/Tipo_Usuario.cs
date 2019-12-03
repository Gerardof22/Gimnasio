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
    public class Tipo_Usuario
    {
        [Key]
        public int idtipousuario { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_usuario { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public virtual ObservableCollection<Usuario> Usuarios { get; set; }
    }
}
