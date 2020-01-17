using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public string Nivel { get; set; }
        public string Email { get; set; }

        public IList<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public IList<Horario> Horarios { get; set; } = new List<Horario>();
    }
}
