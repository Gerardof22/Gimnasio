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
    public class Calentamiento
    {
        [Key]
        public int calentamiento_idcalentamiento { get; set; }
        [Required]
        [StringLength (10)]
        public string calentamiento_duracion { get; set; }
        
        [StringLength (200)]
        public string calentamiento_descripcion { get; set; }

        [DefaultValue(false)]
        public bool calentamiento_delete { get; set; }


        public virtual ObservableCollection<Rutina> Rutinas { get; set; }
        public virtual ObservableCollection<Tipo_Calentamiento> Tipos_Calentamientos { get; set; }
    }
}
