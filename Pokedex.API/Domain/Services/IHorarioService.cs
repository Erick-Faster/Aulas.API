using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services
{
    public interface IHorarioService
    {
        Task<IEnumerable<Horario>> ListAsync();
        Task<SaveHorarioResponse> GetById(Guid id);
        Task<SaveHorarioResponse> SaveAsync(Horario horario);
        Task<SaveHorarioResponse> UpdateAsync(Guid id, Horario horario);
        Task<SaveHorarioResponse> DeleteAsync(Guid id);
    }
}
