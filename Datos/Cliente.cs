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
    public class Cliente
    {
        [Key]
        public int idcliente { get; set; }

        [Required]
        public int iddomicilio { get; set; }
        public virtual Domicilio Domicilio { get; set; }

        [Required]
        public int idlocalidad { get; set; }
        public virtual Localidad Localidad { get; set; }

        [Required]
        [StringLength (60)]
        public string nombre { get; set; }

        [Required]
        [StringLength (60)]
        public string apellido { get; set; }

        [Required]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        public DateTime fechaIngreso { get; set; }
        [Required]
        public bool genero { get; set; }

        public int edad { get; set; }
        
        public float peso { get; set; }

        [StringLength (200)]
        public string objetivos { get; set; }

        [StringLength (400)]
        public string lecturaCorporal { get; set; }
        
        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public virtual ObservableCollection<Telefono> Telefonos { get; set; }
        public virtual ObservableCollection<Control_Ingreso> Controles_Ingresos { get; set; }
        public virtual ObservableCollection<Cobranza> Cobranzas { get; set; }
    }
}
