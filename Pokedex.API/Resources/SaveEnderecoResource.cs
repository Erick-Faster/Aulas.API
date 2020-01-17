using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SaveEnderecoResource
    {
        [Required]
        [MaxLength(50)]
        public string Rua { get; set; }

        [Required]
        [MaxLength(3)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(25)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        public Guid Id_Aluno { get; set; }
    }
}
