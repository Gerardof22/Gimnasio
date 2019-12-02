using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Tipo_Calentamiento
    {
        [Key]
        public int idtipocalentamiento { get; set; }
        [Required]
        public int idcalentamiento { get; set; }
        public virtual Calentamiento Calentamiento { get; set; }
        [Required]
        [StringLength (50)]
        public string nombre { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
