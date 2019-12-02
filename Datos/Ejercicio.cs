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
        public int idejercicio { get; set; }

        [Required]
        public string nombre { get; set; }
        
        public byte[] imagen { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public virtual ObservableCollection<Rutina> Rutinas { get; set; }
    }
}
