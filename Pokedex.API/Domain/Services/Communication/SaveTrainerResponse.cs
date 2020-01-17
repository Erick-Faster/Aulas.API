using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SaveAlunoResponse : BaseResponse
    {
        public Aluno Aluno { get; private set; }

        private SaveAlunoResponse(bool success, string message, Aluno aluno) : base(success, message)
        {
            Aluno = aluno;
        }

        public SaveAlunoResponse(Aluno aluno) : this(true, string.Empty, aluno)
        {

        }

        public SaveAlunoResponse(string message) : this(false, message, null)
        {

        }
    }
}
