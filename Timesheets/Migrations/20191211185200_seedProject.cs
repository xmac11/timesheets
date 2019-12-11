using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class seedProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6907281a-c857-4c6d-bff0-78fc8826cc65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0df897-2058-40ac-9a16-f0238eb80e0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e54cd812-12aa-4a63-a61b-1db3a085d969");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerDeptId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8bbc6c8-edf4-475c-8b02-caac931d7607", "93012e54-a28e-48e6-8946-9ce032b16b16", "Admin", "ADMIN" },
                    { "fe253cab-ce53-4c83-9f5d-906eec04666e", "6f3f9b41-10c9-4564-b7b0-337302f8af2b", "Employee", "EMPLOYEE" },
                    { "9838fd37-9278-4d04-9d0d-7d688963e63b", "0bf7cf2e-0bcd-415a-9364-09c9870bcb5f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "OwnerDeptId" },
                values: new object[] { 1, "App Develpment", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerDeptId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e54cd812-12aa-4a63-a61b-1db3a085d969", "e820bb0a-bc14-409f-951a-02cb2940193d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6907281a-c857-4c6d-bff0-78fc8826cc65", "0804e8a5-2a56-4c32-8c98-d81fa4f0e531", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad0df897-2058-40ac-9a16-f0238eb80e0e", "552d33b5-028d-4c21-ad40-913bb6cf1bde", "Manager", "MANAGER" });
        }
    }
}
