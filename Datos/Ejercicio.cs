using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Ejercicio
    {
        [Key]
        public int ejercicio_idejercicio { get; set; }
        [Required]
        public int ejercicio_idrutina { get; set; }
        public virtual Rutina Rutina { get; set; }

        [Required]
        public string ejercicio_nombre { get; set; }
        
        public byte[] ejercicio_imagen { get; set; }

        public bool ejercicio_delete { get; set; } = false;

    }
}
