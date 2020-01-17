using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SaveLogAulaResponse : BaseResponse
    {
        public LogAula LogAula { get; protected set; }
        
        private SaveLogAulaResponse(bool success, string message, LogAula logAula) : base(success, message)
        {
            LogAula = logAula;
        }

        public SaveLogAulaResponse(LogAula logAula) : this(true, string.Empty, logAula)
        {

        }

        public SaveLogAulaResponse(string message) : this(false, message, null)
        {

        }

    }
}
