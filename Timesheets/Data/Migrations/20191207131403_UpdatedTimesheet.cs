using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Data.Migrations
{
    public partial class UpdatedTimesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Timesheets");
        }
    }
}
