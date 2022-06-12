using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class addedCodigoInfracciontoInfracciontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoInfraccion",
                table: "Infracciones",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoInfraccion",
                table: "Infracciones");
        }
    }
}
