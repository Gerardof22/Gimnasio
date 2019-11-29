using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Tipo_Rutina
    {
        [Key]
        public int tipo_rutina_idtiporutina { get; set; }
        
        public int? tipo_rutina_idrutina { get; set; }
        public virtual Rutina Rutina { get; set; }
        [Required]
        [StringLength (50)]
        public string tipo_rutina_nombre { get; set; }

        [DefaultValue(false)]
        public bool tipo_rutina_delete { get; set; }
    }
}
