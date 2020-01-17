using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ListAsync();
        Task<SaveAlunoResponse> GetById(Guid id);
        Task<SaveAlunoResponse> SaveAsync(Aluno aluno);
        Task<SaveAlunoResponse> UpdateAsync(Guid id, Aluno aluno);
        Task<SaveAlunoResponse> DeleteAsync(Guid id);

        
    }
}
