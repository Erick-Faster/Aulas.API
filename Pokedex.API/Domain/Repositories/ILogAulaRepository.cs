using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface ILogAulaRepository
    {
        Task<IEnumerable<LogAula>> ListAsync();
        Task AddAsync(LogAula logAula);
        Task<LogAula> FindByIdAsync(Guid id);
        void Update(LogAula logAula);
        void Remove(LogAula logAula);
    }
}
