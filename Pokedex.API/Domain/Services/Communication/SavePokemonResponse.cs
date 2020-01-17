using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SaveHorarioResponse : BaseResponse
    {
        public Horario Horario { get; protected set; }

        private SaveHorarioResponse(bool success, string message, Horario horario) : base(success, message)
        {
            Horario = horario;
        }

        public SaveHorarioResponse(Horario horario) : this(true, string.Empty, horario)
        {

        }

        public SaveHorarioResponse(string message) : this(false, message, null)
        {

        }
    }
}
