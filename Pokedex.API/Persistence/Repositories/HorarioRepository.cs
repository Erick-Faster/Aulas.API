using Microsoft.EntityFrameworkCore;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Persistence.Repositories
{
    public class HorarioRepository : BaseRepository, IHorarioRepository
    {
        public HorarioRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Horario>> ListAsync()
        {
            return await _context.Horarios.Include(p => p.Aluno)
                                          .Include(p => p.LogAula)
                                          .ToListAsync();
        }

        public async Task AddAsync(Horario horario)
        {
            await _context.Horarios.AddAsync(horario);
        }

        public async Task<Horario> FindByIdAsync(Guid id)
        {
            return await _context.Horarios.FindAsync(id);
        }

        public void Update(Horario horario)
        {
            _context.Horarios.Update(horario);
        }

        public void Remove(Horario horario)
        {
            _context.Horarios.Remove(horario);
        }
    }
}
