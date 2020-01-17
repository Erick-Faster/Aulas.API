using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface IHorarioRepository
    {
        Task<IEnumerable<Horario>> ListAsync();
        Task AddAsync(Horario horario);
        Task<Horario> FindByIdAsync(Guid id);
        void Update(Horario horario);
        void Remove(Horario horario);
    }
}
