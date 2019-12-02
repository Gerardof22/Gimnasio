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
        public int idtiporutina { get; set; }
        
        public int? idrutina { get; set; }
        public virtual Rutina Rutina { get; set; }
        [Required]
        [StringLength (50)]
        public string nombre { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
