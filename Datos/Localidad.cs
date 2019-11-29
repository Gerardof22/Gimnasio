﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Localidad
    {
        [Key]
        public int localidad_idlocalidad { get; set; }
        [Required]
        [StringLength (70)]
        public string localidad_localidad { get; set; }

        [DefaultValue(false)]
        public bool localidad_delete { get; set; }

        public virtual ObservableCollection<Cliente> clientes { get; set; }

    }
}
