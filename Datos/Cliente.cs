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
        public int clientes_idcliente { get; set; }
        [Required]
        public int clientes_iddomicilio { get; set; }
        public virtual Domicilio domicilio { get; set; }
        [Required]
        public int clientes_idlocalidad { get; set; }
        public virtual Localidad localidad { get; set; }
        [Required]
        [StringLength (60)]
        public string clientes_nombre { get; set; }
        [Required]
        [StringLength (60)]
        public string clientes_apellido { get; set; }
        [Required]
        public DateTime clientes_fechaIngreso { get; set; }
        [Required]
        public bool clientes_genero { get; set; }

        public int clientes_edad { get; set; }
        
        public float clientes_peso { get; set; }
        [StringLength (200)]
        public string clientes_objetivos { get; set; }
        [StringLength (300)]
        public string clientes_lecturaCorporal { get; set; }
        
        [DefaultValue(true)]
        public bool clientes_delete { get; set; }

        public virtual ObservableCollection<Telefono> Telefonos { get; set; }
        public virtual ObservableCollection<Control_Ingreso> Control_Ingresos { get; set; }
        public virtual ObservableCollection<Cobranza> Cobranzas { get; set; }
    }
}
