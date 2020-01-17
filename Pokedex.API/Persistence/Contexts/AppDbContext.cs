using Microsoft.EntityFrameworkCore;
using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<LogAula> LogAulas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
      
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Aluno>().ToTable("ALUNO");
            builder.Entity<Aluno>().HasKey(p => p.Id);
            builder.Entity<Aluno>().Property(p => p.Id).IsRequired();
            builder.Entity<Aluno>().Property(p => p.Nome).HasMaxLength(30);
            builder.Entity<Aluno>().Property(p => p.Idioma);
            builder.Entity<Aluno>().Property(p => p.Nivel).HasMaxLength(5);
            builder.Entity<Aluno>().Property(p => p.Email).HasMaxLength(30);
            builder.Entity<Aluno>().HasMany(p => p.Enderecos).WithOne(p => p.Aluno).HasForeignKey(p => p.Id_Aluno);
            builder.Entity<Aluno>().HasMany(p => p.Horarios).WithOne(p => p.Aluno).HasForeignKey(p => p.Id_Aluno);


            builder.Entity<Endereco>().ToTable("ENDERECO");
            builder.Entity<Endereco>().HasKey(p => p.Id);
            builder.Entity<Endereco>().Property(p => p.Rua);
            builder.Entity<Endereco>().Property(p => p.Numero).HasMaxLength(3);
            builder.Entity<Endereco>().Property(p => p.Cep).HasMaxLength(10);
            builder.Entity<Endereco>().Property(p => p.Cidade).HasMaxLength(20);
            builder.Entity<Endereco>().Property(p => p.Estado).HasMaxLength(2);

            builder.Entity<Horario>().ToTable("HORARIO");
            builder.Entity<Horario>().HasKey(p => p.Id);
            builder.Entity<Horario>().Property(p => p.Intervalo);
            builder.Entity<Horario>().Property(p => p.Disponivel);

            builder.Entity<LogAula>().ToTable("LOGAULA");
            builder.Entity<LogAula>().HasKey(p => p.Id);
            builder.Entity<LogAula>().Property(p => p.Id).IsRequired();
            builder.Entity<LogAula>().Property(p => p.Sucesso);
            builder.Entity<LogAula>().Property(p => p.Observacoes);
            builder.Entity<LogAula>().HasMany(p => p.Horarios).WithOne(p => p.LogAula).HasForeignKey(p => p.Id_Pokedex);
        }
    }
}
