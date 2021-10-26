﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.DTOs
{
    public class UpdateFilmeDto
    {
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O campo genero precisa de no mínimo 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "O campo duração deve ter no mínimo 1 e no maximo 600 minutos")]

        public int Duracao { get; set; }
    }
}
