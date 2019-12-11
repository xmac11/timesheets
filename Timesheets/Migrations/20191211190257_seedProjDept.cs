using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class seedProjDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9838fd37-9278-4d04-9d0d-7d688963e63b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8bbc6c8-edf4-475c-8b02-caac931d7607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe253cab-ce53-4c83-9f5d-906eec04666e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f7b58499-527d-4eb1-9f14-803094652847", "8c6e12cc-ccd7-4d13-a59b-7941e4e2751a", "Admin", "ADMIN" },
                    { "7abe649d-b4b8-4d8b-854f-7d6f44e6d72f", "fc5424e3-85ce-43eb-bd7b-1ecdf94e330d", "Employee", "EMPLOYEE" },
                    { "04c106fa-dee3-463a-9f31-010085c0af91", "e803e932-0abe-47b2-a972-b0f347140e8e", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentProject",
                columns: new[] { "DepartmentId", "ProjectId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04c106fa-dee3-463a-9f31-010085c0af91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7abe649d-b4b8-4d8b-854f-7d6f44e6d72f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b58499-527d-4eb1-9f14-803094652847");

            migrationBuilder.DeleteData(
                table: "DepartmentProject",
                keyColumns: new[] { "DepartmentId", "ProjectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DepartmentProject",
                keyColumns: new[] { "DepartmentId", "ProjectId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8bbc6c8-edf4-475c-8b02-caac931d7607", "93012e54-a28e-48e6-8946-9ce032b16b16", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe253cab-ce53-4c83-9f5d-906eec04666e", "6f3f9b41-10c9-4564-b7b0-337302f8af2b", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9838fd37-9278-4d04-9d0d-7d688963e63b", "0bf7cf2e-0bcd-415a-9364-09c9870bcb5f", "Manager", "MANAGER" });
        }
    }
}
