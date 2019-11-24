using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cardio
    {
        [Key]
        public int cardio_idcardio { get; set; }
        [Required]
        public float cardio_duracion { get; set; }
        [Required]
        [StringLength (50)]
        public string cardio_ritmo { get; set; }

        public bool cardio_delete { get; set; } = false;

        public virtual ObservableCollection<Rutina> Rutinas { get; set; }
    }
}
