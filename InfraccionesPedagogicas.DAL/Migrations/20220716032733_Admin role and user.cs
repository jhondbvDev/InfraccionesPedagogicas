using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraccionesPedagogicas.Infrastructure.Migrations
{
    public partial class Adminroleanduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba3bc22c-0eda-4245-85a6-82ad5e0ca266",
                column: "ConcurrencyStamp",
                value: "5a948013-d69a-4e2b-aaf6-f89faa70c74b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf24",
                column: "ConcurrencyStamp",
                value: "77cd8f90-b8ba-4305-ad62-93f2fd2376e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf25", "ca1c3a9f-3bdb-4e17-9958-53e5ab479c47", "ADMIN", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5b8ed22-b18a-4496-bd9c-5be0dedee5a2",
                columns: new[] { "ConcurrencyStamp", "Nombre", "PasswordHash" },
                values: new object[] { "548638e2-1138-454d-adf7-c63d8f335a5c", "TMB", "AQAAAAEAACcQAAAAECfQ5aZNyGSJT00sEeRu55HfwnsnobLFnn9G0qB7QarAI2D1G5vukNU3Dy1vXV7aKw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b5b8ed22-b18a-4496-bd9c-5be0dedee5a3", 0, "bdf7a7d7-0a3e-4a81-9a57-f405785b0c6d", "admin@transitobello.com", false, false, null, "Admin", null, "ADMIN@TRANSITOBELLO.COM", "AQAAAAEAACcQAAAAEOeGzGxeLcQCPaPJp7MUCyfi/WcvhQnCfvtffS4GSN/2azfHCZY/x6/QINpvJH0fcQ==", null, false, "00000000-0000-0000-0000-000000000000", false, "admin@transitobello.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf25", "b5b8ed22-b18a-4496-bd9c-5be0dedee5a3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf25", "b5b8ed22-b18a-4496-bd9c-5be0dedee5a3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf25");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5b8ed22-b18a-4496-bd9c-5be0dedee5a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba3bc22c-0eda-4245-85a6-82ad5e0ca266",
                column: "ConcurrencyStamp",
                value: "1acbe538-612e-4d52-8bb7-924e6c5a6b9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf24",
                column: "ConcurrencyStamp",
                value: "6dbb9de4-90e1-404d-891f-fc864fc3e79f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5b8ed22-b18a-4496-bd9c-5be0dedee5a2",
                columns: new[] { "ConcurrencyStamp", "Nombre", "PasswordHash" },
                values: new object[] { "4b527bda-d940-494b-8595-e0f3fe7acc7d", "Admin", "AQAAAAEAACcQAAAAELpNQH8l3o7bcDGlPTVYx2+SVyF1F1lKrjDWAdfcV+HbAbpGxwOPzT4Md5lcDvUN6Q==" });
        }
    }
}
