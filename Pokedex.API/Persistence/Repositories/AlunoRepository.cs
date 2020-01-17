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
    public class AlunoRepository : BaseRepository, IAlunoRepository
    {
        public AlunoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Aluno>> ListAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task AddAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
        }

        public async Task<Aluno> FindByIdAsync(Guid id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public void Update(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public void Remove(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
        }
    }
}
