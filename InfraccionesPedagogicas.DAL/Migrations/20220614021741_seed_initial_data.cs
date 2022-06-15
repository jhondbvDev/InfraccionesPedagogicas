using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class seed_initial_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b358884-cb8c-43c8-a6e5-77354b6869c6", "c2497a9f-ecbc-41d6-9c19-9037e3520b88", "TMB", "TMB" },
                    { "e141c43f-2e6c-441a-8985-8982cc57e72a", "9f70a4b4-161f-46db-a338-11d3cdcce888", "SM", "SM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b358884-cb8c-43c8-a6e5-77354b6869c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e141c43f-2e6c-441a-8985-8982cc57e72a");
        }
    }
}
