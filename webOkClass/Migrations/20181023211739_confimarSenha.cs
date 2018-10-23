using Microsoft.EntityFrameworkCore.Migrations;

namespace webOkClass.Migrations
{
    public partial class confimarSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmarSenha",
                table: "Usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmarSenha",
                table: "Usuarios");
        }
    }
}
