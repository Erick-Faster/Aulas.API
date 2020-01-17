using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class EnderecoResource
    {
        public Guid Id { get; set; }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public AlunoResource Aluno { get; set; } 

    }
}
