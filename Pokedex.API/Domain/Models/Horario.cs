using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Horario : Entity
    {
        public string Intervalo { get; set; }
        public bool Disponivel { get; set; }

        public Guid Id_Aluno { get; set; }
        public Aluno Aluno { get; set; }

        public Guid Id_Pokedex { get; set; }
        public LogAula LogAula { get; set; }

    }
}
