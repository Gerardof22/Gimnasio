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
    public class Cardio
    {
        [Key]
        public int idcardio { get; set; }
        [Required]
        [StringLength(12)]
        public string Duracion { get; set; }
        [Required]
        [StringLength (50)]
        public string ritmo { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public virtual ObservableCollection<Rutina> Rutinas { get; set; }
    }
}
