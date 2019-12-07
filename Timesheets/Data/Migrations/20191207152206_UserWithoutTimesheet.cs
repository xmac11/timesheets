using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Data.Migrations
{
    public partial class UserWithoutTimesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_TimesheetUsers_UserId",
                table: "Timesheets");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_UserId",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Timesheets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Timesheets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Timesheets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_UserId",
                table: "Timesheets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_TimesheetUsers_UserId",
                table: "Timesheets",
                column: "UserId",
                principalTable: "TimesheetUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
