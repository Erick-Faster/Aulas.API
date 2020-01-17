using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SaveAlunoResource
    {
        //[Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        //[Required]
        [MaxLength(15)]
        public string Idioma { get; set; }

        //[Required]
        [MaxLength(5)]
        public string Nivel { get; set; }

        //[Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
