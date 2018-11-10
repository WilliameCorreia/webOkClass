using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webOkClass.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaDeAulaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroDaSala = table.Column<int>(nullable: false),
                    TipoDeSala = table.Column<int>(nullable: false),
                    StatusDaSala = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaDeAulaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 15, nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(maxLength: 15, nullable: false),
                    Nome = table.Column<string>(maxLength: 15, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 15, nullable: false),
                    Campus = table.Column<int>(nullable: false),
                    TipoFuncionario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    ReservaSalaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusReserva = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    SalaDeAulaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.ReservaSalaID);
                    table.ForeignKey(
                        name: "FK_reservas_Salas_SalaDeAulaId",
                        column: x => x.SalaDeAulaId,
                        principalTable: "Salas",
                        principalColumn: "SalaDeAulaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservas_SalaDeAulaId",
                table: "reservas",
                column: "SalaDeAulaId");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_UsuarioId",
                table: "reservas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
