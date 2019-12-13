using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class tryToSolveExceptionInEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c9c361b-39ee-411c-bc0f-ede6505e3e5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9366cc1c-0967-4c61-a31d-114995e7d2f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1e3ae1-701e-429a-8c89-aa5ce31b363e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4ac2ce5-91cb-4c3d-b251-0637b6bdd7b9", "a8432d48-5e8b-4cfc-b05f-1b92891e2c4f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71b2adf3-110f-4fc2-b10d-4d50b29e0d05", "35ab4555-6f02-47e9-93f5-814fdda2d52e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cbe45bc-a5eb-41de-9f85-0a09875004be", "c6d7dc9c-4e2f-4128-98a3-1d1dd78310a2", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cbe45bc-a5eb-41de-9f85-0a09875004be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71b2adf3-110f-4fc2-b10d-4d50b29e0d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4ac2ce5-91cb-4c3d-b251-0637b6bdd7b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9366cc1c-0967-4c61-a31d-114995e7d2f8", "5be14590-c9e2-4e1f-bf09-f547a0c52be3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed1e3ae1-701e-429a-8c89-aa5ce31b363e", "637f55a8-8a47-4be1-8281-095eddace618", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c9c361b-39ee-411c-bc0f-ede6505e3e5a", "9dff5efa-90a1-4588-a751-8b362007407a", "Manager", "MANAGER" });
        }
    }
}
