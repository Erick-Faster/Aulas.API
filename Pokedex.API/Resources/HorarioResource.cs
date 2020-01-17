using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class HorarioResource
    {
        public Guid Id { get; set; }

        public string Intervalo { get; set; }
        public bool Disponivel { get; set; }

        public AlunoResource Aluno { get; set; }
        public LogAulaResource LogAula { get; set; }
    }
}
