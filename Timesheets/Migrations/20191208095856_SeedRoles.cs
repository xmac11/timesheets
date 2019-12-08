using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "097653ae-56ef-4a64-875a-ef07529d13fa", "389572b1-5645-4bca-940d-03effd18f373", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "290e6d1c-b965-493f-94d2-524cde9f8e71", "bb3b0c56-72d2-4bec-b536-d9f9ba3c9a80", "Employee", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19933cc5-2035-4025-8f1d-2a51d8e12ea0", "d2a0ac75-f9a8-4ac8-9e30-6bc30f6746df", "Manager", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "097653ae-56ef-4a64-875a-ef07529d13fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19933cc5-2035-4025-8f1d-2a51d8e12ea0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "290e6d1c-b965-493f-94d2-524cde9f8e71");
        }
    }
}
