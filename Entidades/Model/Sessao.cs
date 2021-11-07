﻿using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesApi.Model
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
        [JsonIgnore]
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
