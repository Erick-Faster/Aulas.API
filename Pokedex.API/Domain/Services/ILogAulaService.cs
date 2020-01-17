using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services
{
    public interface ILogAulaService
    {
        Task<IEnumerable<LogAula>> ListAsync();
        Task<SaveLogAulaResponse> GetById(Guid id);
        Task<SaveLogAulaResponse> SaveAsync(LogAula logAula);
        Task<SaveLogAulaResponse> UpdateAsync(Guid id, LogAula logAula);
        Task<SaveLogAulaResponse> DeleteAsync(Guid id);
    }
}
