using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Data.Migrations
{
    public partial class RolesAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00e3d5d7-8a9d-4a3a-b607-6e4764de6a02", "bb763021-8480-4c03-9114-a404fa9dca13", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d3c8cd9-8728-448e-8edd-13d7351e96d5", "b762b511-2c1e-41b1-ae27-5b7b7b959762", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2aced34-1222-45a0-845d-119dd4195bbc", "0deae288-4641-4ad4-ab1d-d6234507fe2d", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e3d5d7-8a9d-4a3a-b607-6e4764de6a02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d3c8cd9-8728-448e-8edd-13d7351e96d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2aced34-1222-45a0-845d-119dd4195bbc");
        }
    }
}
