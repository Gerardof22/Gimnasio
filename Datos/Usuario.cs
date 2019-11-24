﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario
    {
        [Key]
        public int usuario_idusuario { get; set; }
        [Required]
        [MaxLength (60)]
        public string usuario_user { get; set; }
        [MaxLength (128)]
        public string usuario_password { get; set; }

        public bool login_delete { get; set; } = false;

        public virtual ObservableCollection<Tipo_Usuario> Tipos_Usuarios { get; set; }
    }
}