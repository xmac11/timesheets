using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class seeifitworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c80bfc2-bcfd-487c-93d5-181a494d5a4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dabd878-89c4-45eb-92c5-ac91b26f5b2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2353f9-399f-4ce7-9a63-45734f9eec06");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8b2353f9-399f-4ce7-9a63-45734f9eec06", "c63e0b4b-9107-4a8b-b2af-91667a6b0f27", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c80bfc2-bcfd-487c-93d5-181a494d5a4a", "b66f4a53-fcaf-4698-b17f-cd31480db4f3", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dabd878-89c4-45eb-92c5-ac91b26f5b2e", "edf64450-7a3d-4f03-bbfb-d454da50da91", "Manager", "MANAGER" });
        }
    }
}
