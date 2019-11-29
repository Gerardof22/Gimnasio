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
    public class Ejercicio
    {
        [Key]
        public int ejercicio_idejercicio { get; set; }

        [Required]
        public string ejercicio_nombre { get; set; }
        
        public byte[] ejercicio_imagen { get; set; }

        [DefaultValue(false)]
        public bool ejercicio_delete { get; set; }

        public virtual ObservableCollection<Rutina> Rutinas { get; set; }
    }
}
