﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Request
{
    public class AtivaContaRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}
