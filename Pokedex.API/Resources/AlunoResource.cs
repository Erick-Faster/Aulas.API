using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class AlunoResource
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public string Nivel { get; set; }
        public string Email { get; set; }



    }
}
