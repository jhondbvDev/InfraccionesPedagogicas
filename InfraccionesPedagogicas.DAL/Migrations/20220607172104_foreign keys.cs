using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Infracciones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Salas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Infracciones",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
