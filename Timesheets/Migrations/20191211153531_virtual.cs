using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class @virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5772c9b2-05f5-4870-abfc-cc5dee41c0bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d0bc7fa-f313-4d16-abe7-f0a3510dde28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bdd5788-3fea-4108-92ca-71bea9e0eba5");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5772c9b2-05f5-4870-abfc-cc5dee41c0bb", "caf37fb4-d07f-4e7c-9177-11cd4b210710", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d0bc7fa-f313-4d16-abe7-f0a3510dde28", "80c6724c-00c8-4cf7-808e-f44aee1046bf", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bdd5788-3fea-4108-92ca-71bea9e0eba5", "c4f298df-498c-4479-a654-809e0d69b9e9", "Manager", "MANAGER" });
        }
    }
}
