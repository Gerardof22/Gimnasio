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
    public class Rutina
    {
        [Key]
        public int idrutina { get; set; }
        
        public int? idcardio { get; set; }
        public virtual Cardio Cardio { get; set; }
        
        public int? idcalentamiento { get; set; }
        public virtual Calentamiento Calentamiento { get; set; }
        [Required]
        public int idejercicio { get; set; }
        public virtual Ejercicio Ejercicio { get; set; }

        public int? idcliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required]
        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        public int serie { get; set; }

        public int repeticion { get; set; }
        [StringLength (20)]
        public string tiempoduracion { get; set; }
        [StringLength (20)]
        public string descanso { get; set; }

        public float pesokg { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public virtual ObservableCollection<Tipo_Rutina> Tipos_Rutinas { get; set; }
    }
}
