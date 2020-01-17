using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> ListAsync();
        Task AddAsync(Aluno aluno);
        Task<Aluno> FindByIdAsync(Guid id);
        void Update(Aluno aluno);
        void Remove(Aluno aluno);
    }
}
