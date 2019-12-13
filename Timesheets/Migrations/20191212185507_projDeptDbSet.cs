using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class projDeptDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProject_Departments_DepartmentId",
                table: "DepartmentProject");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProject_Projects_ProjectId",
                table: "DepartmentProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentProject",
                table: "DepartmentProject");

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

            migrationBuilder.RenameTable(
                name: "DepartmentProject",
                newName: "DepartmentProjects");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentProject_ProjectId",
                table: "DepartmentProjects",
                newName: "IX_DepartmentProjects_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentProjects",
                table: "DepartmentProjects",
                columns: new[] { "DepartmentId", "ProjectId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5465d384-0411-4c77-bc22-11724d88a39b", "d1497e0c-6905-4e17-a4e4-8a330c9d5b4c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c544d7f-1178-4e54-95c5-cb7aedeb3a62", "695d7053-8afd-4277-9f68-219cce2d819f", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52fffd16-f9bd-4028-a93e-d96a65f17e8d", "418d59ac-ea73-49d9-8723-6d81e267d195", "Manager", "MANAGER" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProjects_Departments_DepartmentId",
                table: "DepartmentProjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProjects_Projects_ProjectId",
                table: "DepartmentProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProjects_Departments_DepartmentId",
                table: "DepartmentProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProjects_Projects_ProjectId",
                table: "DepartmentProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentProjects",
                table: "DepartmentProjects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52fffd16-f9bd-4028-a93e-d96a65f17e8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5465d384-0411-4c77-bc22-11724d88a39b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c544d7f-1178-4e54-95c5-cb7aedeb3a62");

            migrationBuilder.RenameTable(
                name: "DepartmentProjects",
                newName: "DepartmentProject");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentProjects_ProjectId",
                table: "DepartmentProject",
                newName: "IX_DepartmentProject_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentProject",
                table: "DepartmentProject",
                columns: new[] { "DepartmentId", "ProjectId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProject_Departments_DepartmentId",
                table: "DepartmentProject",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProject_Projects_ProjectId",
                table: "DepartmentProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
