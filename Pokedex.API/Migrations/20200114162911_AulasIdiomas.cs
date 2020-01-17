using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.API.Migrations
{
    public partial class AulasIdiomas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: true),
                    Idioma = table.Column<string>(nullable: true),
                    Nivel = table.Column<string>(maxLength: 5, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOGAULA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sucesso = table.Column<bool>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGAULA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(maxLength: 3, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Cidade = table.Column<string>(maxLength: 20, nullable: true),
                    Estado = table.Column<string>(maxLength: 2, nullable: true),
                    Id_Aluno = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENDERECO_ALUNO_Id_Aluno",
                        column: x => x.Id_Aluno,
                        principalTable: "ALUNO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HORARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Intervalo = table.Column<string>(nullable: true),
                    Disponivel = table.Column<bool>(nullable: false),
                    Id_Aluno = table.Column<Guid>(nullable: false),
                    Id_Pokedex = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HORARIO_ALUNO_Id_Aluno",
                        column: x => x.Id_Aluno,
                        principalTable: "ALUNO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HORARIO_LOGAULA_Id_Pokedex",
                        column: x => x.Id_Pokedex,
                        principalTable: "LOGAULA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_Id_Aluno",
                table: "ENDERECO",
                column: "Id_Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_HORARIO_Id_Aluno",
                table: "HORARIO",
                column: "Id_Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_HORARIO_Id_Pokedex",
                table: "HORARIO",
                column: "Id_Pokedex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "HORARIO");

            migrationBuilder.DropTable(
                name: "ALUNO");

            migrationBuilder.DropTable(
                name: "LOGAULA");
        }
    }
}
