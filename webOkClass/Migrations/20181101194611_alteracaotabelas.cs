using Microsoft.EntityFrameworkCore.Migrations;

namespace webOkClass.Migrations
{
    public partial class alteracaotabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservaDaSala",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "ReservaDaSala",
                table: "Salas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
