﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.API.Persistence.Contexts;

namespace Pokedex.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pokedex.API.Domain.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(30);

                    b.Property<string>("Idioma");

                    b.Property<string>("Nivel")
                        .HasMaxLength(5);

                    b.Property<string>("Nome")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("ALUNO");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cep")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .HasMaxLength(20);

                    b.Property<string>("Estado")
                        .HasMaxLength(2);

                    b.Property<Guid>("Id_Aluno");

                    b.Property<string>("Numero")
                        .HasMaxLength(3);

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.HasIndex("Id_Aluno");

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Horario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Disponivel");

                    b.Property<Guid>("Id_Aluno");

                    b.Property<Guid>("Id_Pokedex");

                    b.Property<string>("Intervalo");

                    b.HasKey("Id");

                    b.HasIndex("Id_Aluno");

                    b.HasIndex("Id_Pokedex");

                    b.ToTable("HORARIO");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.LogAula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Observacoes");

                    b.Property<bool>("Sucesso");

                    b.HasKey("Id");

                    b.ToTable("LOGAULA");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Endereco", b =>
                {
                    b.HasOne("Pokedex.API.Domain.Models.Aluno", "Aluno")
                        .WithMany("Enderecos")
                        .HasForeignKey("Id_Aluno")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Horario", b =>
                {
                    b.HasOne("Pokedex.API.Domain.Models.Aluno", "Aluno")
                        .WithMany("Horarios")
                        .HasForeignKey("Id_Aluno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pokedex.API.Domain.Models.LogAula", "LogAula")
                        .WithMany("Horarios")
                        .HasForeignKey("Id_Pokedex")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
