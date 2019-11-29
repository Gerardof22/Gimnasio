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
        public int rutina_idrutina { get; set; }
        
        public int? rutina_idcardio { get; set; }
        public virtual Cardio Cardio { get; set; }
        
        public int? rutina_idcalentamiento { get; set; }
        public virtual Calentamiento Calentamiento { get; set; }
        [Required]
        public int idcalentamiento { get; set; }
        public virtual Ejercicio Ejercicio { get; set; }

        public int? idcliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required]
        public DateTime rutina_fechaDesde { get; set; }

        public DateTime rutina_fechaHasta { get; set; }

        public int rutina_serie { get; set; }

        public int rutina_repeticion { get; set; }
        [StringLength (20)]
        public string rutina_tiempoduracion { get; set; }
        [StringLength (20)]
        public string rutina_descanso { get; set; }

        public float rutina_pesokg { get; set; }

        [DefaultValue(false)]
        public bool rutina_delete { get; set; }

        public virtual ObservableCollection<Tipo_Rutina> Tipos_Rutinas { get; set; }
    }
}
