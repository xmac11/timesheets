using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class seedProj2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "746e9f5f-8386-4bec-9649-a1cf75cea776", "d73bb382-324f-489c-8304-43c8bec65447", "Admin", "ADMIN" },
                    { "d6055ac6-a63e-4462-a709-69d2120c0091", "b8c0ca25-cda6-41dc-b1e2-9441f588133a", "Employee", "EMPLOYEE" },
                    { "2437b5b1-73f3-45d1-b5e5-c3faf809aa7b", "f91ed2aa-3a19-437b-9623-1263ea36e173", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "App Development");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "OwnerDeptId" },
                values: new object[] { 2, "Website Development", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2437b5b1-73f3-45d1-b5e5-c3faf809aa7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "746e9f5f-8386-4bec-9649-a1cf75cea776");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6055ac6-a63e-4462-a709-69d2120c0091");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f7b58499-527d-4eb1-9f14-803094652847", "8c6e12cc-ccd7-4d13-a59b-7941e4e2751a", "Admin", "ADMIN" },
                    { "7abe649d-b4b8-4d8b-854f-7d6f44e6d72f", "fc5424e3-85ce-43eb-bd7b-1ecdf94e330d", "Employee", "EMPLOYEE" },
                    { "04c106fa-dee3-463a-9f31-010085c0af91", "e803e932-0abe-47b2-a972-b0f347140e8e", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "App Develpment");
        }
    }
}
