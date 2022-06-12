using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class addlazyreferencetoInfractoronDatosInfractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "DatosInfractor");

            migrationBuilder.AddColumn<string>(
                name: "InfractorId",
                table: "DatosInfractor",
                type: "character varying(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DatosInfractor_InfractorId",
                table: "DatosInfractor",
                column: "InfractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DatosInfractor_Infractores_InfractorId",
                table: "DatosInfractor",
                column: "InfractorId",
                principalTable: "Infractores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatosInfractor_Infractores_InfractorId",
                table: "DatosInfractor");

            migrationBuilder.DropIndex(
                name: "IX_DatosInfractor_InfractorId",
                table: "DatosInfractor");

            migrationBuilder.DropColumn(
                name: "InfractorId",
                table: "DatosInfractor");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "DatosInfractor",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
