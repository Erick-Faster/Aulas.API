using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SaveLogAulaResource
    {
        [Required]
        public bool Sucesso { get; set; }

        public string Observacoes { get; set; }
    }
}
