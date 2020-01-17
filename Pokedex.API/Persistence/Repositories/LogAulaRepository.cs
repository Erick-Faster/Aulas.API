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
    public class LogAulaRepository : BaseRepository, ILogAulaRepository
    {
        public LogAulaRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<LogAula>> ListAsync()
        {
            return await _context.LogAulas.ToListAsync();
        }

        public async Task AddAsync(LogAula logAula)
        {
            await _context.LogAulas.AddAsync(logAula);
        }

        public async Task<LogAula> FindByIdAsync(Guid id)
        {
            return await _context.LogAulas.FindAsync(id);
        }

        public void Update(LogAula logAula)
        {
            _context.LogAulas.Update(logAula);
        }

        public void Remove(LogAula logAula)
        {
            _context.LogAulas.Remove(logAula);
        }
    }
}
