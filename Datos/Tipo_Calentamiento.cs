using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Tipo_Calentamiento
    {
        [Key]
        public int tipoCalentamiento_idtipocalentamiento { get; set; }
        [Required]
        public int tipoCalentamiento_idcalentamiento { get; set; }
        public virtual Calentamiento Calentamiento { get; set; }
        [Required]
        [StringLength (50)]
        public string tipoCalentamiento_nombre { get; set; }

        public bool tipoCalentamiento_delete { get; set; } = false;
    }
}
