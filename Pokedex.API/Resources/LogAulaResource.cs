using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class LogAulaResource
    {
        public Guid Id { get; set; }
        public bool Sucesso { get; set; }
        public string Observacoes { get; set; }
    }
}
