using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class changedasistenciareferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Asistencias");

            migrationBuilder.AddColumn<string>(
                name: "InfractorId",
                table: "Asistencias",
                type: "character varying(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_InfractorId",
                table: "Asistencias",
                column: "InfractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Infractores_InfractorId",
                table: "Asistencias",
                column: "InfractorId",
                principalTable: "Infractores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Infractores_InfractorId",
                table: "Asistencias");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_InfractorId",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "InfractorId",
                table: "Asistencias");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Asistencias",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
