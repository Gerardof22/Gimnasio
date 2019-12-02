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
        public int idcalentamiento { get; set; }
        [Required]
        [StringLength (10)]
        public string duracion { get; set; }
        
        [StringLength (200)]
        public string descripcion { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }


        public virtual ObservableCollection<Rutina> Rutinas { get; set; }
        public virtual ObservableCollection<Tipo_Calentamiento> Tipos_Calentamientos { get; set; }
    }
}
