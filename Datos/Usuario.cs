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
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }

        [Required]
        public int idtipo_usuario { get; set; }
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }

        [Required]
        [MaxLength (60)]
        public string user { get; set; }

        [MaxLength (128)]
        public string password { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
