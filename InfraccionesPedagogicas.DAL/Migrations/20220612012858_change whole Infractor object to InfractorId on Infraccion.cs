using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class changewholeInfractorobjecttoInfractorIdonInfraccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infracciones_Infractores_InfractorId",
                table: "Infracciones");

            migrationBuilder.AlterColumn<string>(
                name: "InfractorId",
                table: "Infracciones",
                type: "character varying(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Infracciones_Infractores_InfractorId",
                table: "Infracciones",
                column: "InfractorId",
                principalTable: "Infractores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infracciones_Infractores_InfractorId",
                table: "Infracciones");

            migrationBuilder.AlterColumn<string>(
                name: "InfractorId",
                table: "Infracciones",
                type: "character varying(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)");

            migrationBuilder.AddForeignKey(
                name: "FK_Infracciones_Infractores_InfractorId",
                table: "Infracciones",
                column: "InfractorId",
                principalTable: "Infractores",
                principalColumn: "Id");
        }
    }
}
