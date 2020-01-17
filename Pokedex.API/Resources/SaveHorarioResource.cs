using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SaveHorarioResource
    {
        [Required]
        [MaxLength(25)]
        public string Intervalo { get; set; }

        [Required]
        public bool Disponivel { get; set; }

        public Guid Id_Aluno { get; set; }

        [Required]
        public Guid Id_Pokedex { get; set; }
    }
}
