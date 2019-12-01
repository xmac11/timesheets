using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Data.Migrations
{
    public partial class ProjectDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deparments",
                columns: table => new
                {
                    DepartmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetUsers",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    OwnerDeparmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Deparments_OwnerDeparmentId",
                        column: x => x.OwnerDeparmentId,
                        principalTable: "Deparments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    TimesheetId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    HoursWorked = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.TimesheetId);
                    table.ForeignKey(
                        name: "FK_Timesheets_TimesheetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TimesheetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsDepartments",
                columns: table => new
                {
                    ProjectId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsDepartments", x => new { x.ProjectId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_ProjectsDepartments_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsDepartments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerDeparmentId",
                table: "Projects",
                column: "OwnerDeparmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsDepartments_DepartmentId",
                table: "ProjectsDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_UserId",
                table: "Timesheets",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsDepartments");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TimesheetUsers");

            migrationBuilder.DropTable(
                name: "Deparments");
        }
    }
}
