using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webOkClass.Migrations
{
    public partial class Class_Salas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmarSenha",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaDeAulaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroDaSala = table.Column<int>(nullable: false),
                    TipoDeSala = table.Column<int>(nullable: false),
                    StatusDaSala = table.Column<int>(nullable: false),
                    ReservaDaSala = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaDeAulaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmarSenha",
                table: "Usuarios",
                nullable: true);
        }
    }
}
