using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class seedDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3376940d-f67e-47ad-a385-a71d153b4ece");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfe2fd19-d79f-4fe7-b8ef-bab4e67791d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3632061-9fea-464c-a2a5-ca87b5614eca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5772c9b2-05f5-4870-abfc-cc5dee41c0bb", "caf37fb4-d07f-4e7c-9177-11cd4b210710", "Admin", "ADMIN" },
                    { "6d0bc7fa-f313-4d16-abe7-f0a3510dde28", "80c6724c-00c8-4cf7-808e-f44aee1046bf", "Employee", "EMPLOYEE" },
                    { "8bdd5788-3fea-4108-92ca-71bea9e0eba5", "c4f298df-498c-4479-a654-809e0d69b9e9", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentHeadId", "Name" },
                values: new object[,]
                {
                    { 1, null, "IT" },
                    { 2, null, "R&D" },
                    { 3, null, "Human Resources" },
                    { 4, null, "Accounting" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3632061-9fea-464c-a2a5-ca87b5614eca", "a98a6938-c3bc-4564-afa0-4c691d4df01d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3376940d-f67e-47ad-a385-a71d153b4ece", "b6902e5b-f52d-49fb-aede-a67ee60e00f0", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfe2fd19-d79f-4fe7-b8ef-bab4e67791d5", "11d49e39-e3c2-48fa-a391-2fac7d0efb74", "Manager", "MANAGER" });
        }
    }
}
