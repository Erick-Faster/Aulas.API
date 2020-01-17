using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class LogAula : Entity
    {

        public bool Sucesso { get; set; }
        public string Observacoes { get; set; }

        public IList<Horario> Horarios { get; set; } = new List<Horario>(); 
    }
}
